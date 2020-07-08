using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AGVServer
{
    public partial class Form1 : Form
    {
        public static object myLock = new object();
        myMap map = new myMap(100, 100);
        DStarLite d;
        public static bool isMoving=false;
        #region tcp参数
        IPAddress ip;
        int port = 51888;
        Thread thStartListen;
        Thread thReceiveConnect;
        bool isListenning = false;
        Socket tcpServer;
        Color colorConnected = Color.LightSeaGreen;
        Color colorUnconnected = Color.DimGray;
        #endregion

        byte[] pathBytes;
        Thread thRunRandom = null;
        bool runRandom;
        ToolTip tip = new ToolTip();

        public Form1()
        {
            InitializeComponent();
            d = new DStarLite(map.row, map.column);
            //d.mapPanel1 = this.mapPanel1;
            d.mapPicBox1 = this.mapPicBox1;
            mapPicBox1.pictureBox1.MouseClick += MapPicBox1_MouseClick;
            mapPicBox1.drawMap(map.column, map.row);

            //设置障碍------------------------------
            for (int j = 1; j < 3 * map.column / 4; j++)
            {
                d.S[map.row / 4, j].isObstacle = true;
                //mapPicBox1.addPoint(j, map.row / 4, Color.Black);
            }
            for (int j = map.column / 4; j < map.column - 1; j++)
            {
                d.S[3 * map.row / 4, j].isObstacle = true;
                //mapPicBox1.addPoint(j, 3 * map.row / 4, Color.Black);
            }
            foreach(point p in d.S)
            {
                if (p.isObstacle)
                {
                    mapPicBox1.addPoint(p.x, p.y, Color.Black);
                }
            }

            //------------------------------------


            //尝试侦听
            string hostName = Dns.GetHostName();
            IPAddress[] iPAddresses = Dns.GetHostAddresses(hostName);
            for (int i = 0; i < iPAddresses.Length; i++)
            {
                if (iPAddresses[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    cbIP.Items.Add(iPAddresses[i].ToString());
                }
            }
            ip = IPAddress.Parse(cbIP.Items[0].ToString());
            tbIP.Text = ip.ToString();
            tbPort.Text = port.ToString();


            thStartListen = new Thread(delegate ()
            {
                while (true)
                {
                    try
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            this.Text = "AGV Server" + ip.ToString();
                        }));
                    }
                    catch { }

                    if (!isListenning)
                    {
                        try
                        {
                            tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            IPEndPoint ipPort = new IPEndPoint(ip, port);
                            tcpServer.Bind(ipPort);
                            tcpServer.Listen(20);
                            isListenning = true;
                            lbNetState.BackColor = colorConnected;
                            try
                            {
                                thReceiveConnect.Abort();
                            }
                            catch { }
                            thReceiveConnect = new Thread(delegate () { receiveConnect(); });
                            thReceiveConnect.IsBackground = true;
                            thReceiveConnect.Start();
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new EventHandler(delegate
                            {
                                //rtbMessage.AppendText( ex.Message);
                                lbNetState.BackColor = colorUnconnected;
                            }));
                        }
                    }
                    Thread.Sleep(100);
                }
            });
            thStartListen.IsBackground = true;
            thStartListen.Start();

        }

        private void MapPicBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / mapPicBox1.length;
            int y = e.Y / mapPicBox1.length;
            if (0 <= x && x < map.column && 0 <= y && y < map.row)
            {
                if (isMoving)
                {
                    lock (myLock)
                    {
                        for (int i = 0; i < d.changingPoint.Length; i++)
                        {
                            if (d.changingPoint[i].Equals(d.S[y, x]))
                            {
                                return;
                            }
                        }
                        d.changeObstacle = true;
                        Array.Resize(ref d.changingPoint, d.changingPoint.Length + 1);
                        d.changingPoint[d.changingPoint.Length - 1] = d.S[y, x];
                        Color color = d.S[y, x].isObstacle ? Color.White : Color.Black;
                        mapPicBox1.addPoint(x, y, color);
                    }
                }
                else
                {
                    Thread thChangePoint = new Thread(() => d.changePoint(x,y));
                    thChangePoint.IsBackground = true;
                    thChangePoint.Start();
                    Color color = d.S[y, x].isObstacle ? Color.White : Color.Black;
                    mapPicBox1.addPoint(x, y, color);
                }
            }
        }


        private void receiveConnect()//侦听连接
        {
            while (isListenning)
            {
                Socket connectClient = null;
                try
                {
                    connectClient = tcpServer.Accept();
                }
                catch
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        isListenning = false;
                        tcpServer.Close();
                        lbNetState.BackColor = colorUnconnected;
                    }));
                }
                if (connectClient != null)
                {
                    new AGV(connectClient);
                    RadioButton radioButton = new RadioButton();
                    radioButton.BackColor = AGV.AGVList[connectClient.RemoteEndPoint.ToString()].agvColor;
                    radioButton.Text = "AGV";
                    radioButton.Font = new Font("Microsoft YaHei UI", (float)10.5);
                    radioButton.ForeColor = Color.White;
                    radioButton.Name = connectClient.RemoteEndPoint.ToString();
                    //radioButton.MouseMove += RadioButton_MouseMove;
                    this.Invoke(new EventHandler(delegate { flowLayoutPanel1.Controls.Add(radioButton); }));
                    Thread thReceiveMsg = new Thread(receiveMsg);
                    thReceiveMsg.IsBackground = true;
                    thReceiveMsg.Start(connectClient);



                }
            }
        }
        private void receiveMsg(object o)//接收消息
        {
            Socket socketForClient = o as Socket;
            try
            {
                while (true)
                {
                    byte[] msgByte = new byte[1024 * 1024];
                    //msgByte = new byte[1];
                    int length = socketForClient.Receive(msgByte);
                    if (length > 0)
                    {
                        if (msgByte[3] == 0x10)
                        {
                            AGV agv = AGV.AGVList[socketForClient.RemoteEndPoint.ToString()];
                            agv.battery = msgByte[15];
                            agv.isBusy = msgByte[16];
                            agv.agvFault = (uint)(msgByte[17] | (msgByte[18] << 8) | (msgByte[19] << 16) | (msgByte[20] << 24));
                            agv.nowCoordinate = (uint)(msgByte[21] | (msgByte[22] << 8) | (msgByte[23] << 16) | (msgByte[24] << 24));
                            agv.subPathCoordinate = (uint)(msgByte[25] | (msgByte[26] << 8) | (msgByte[27] << 16) | (msgByte[28] << 24));
                            agv.targetCoordinate = (uint)(msgByte[29] | (msgByte[30] << 8) | (msgByte[31] << 16) | (msgByte[32] << 24));
                            agv.hasShelf = msgByte[33];
                            agv.shelfOrientation = msgByte[34];
                            agv.shelfCode = (uint)(msgByte[35] | (msgByte[36] << 8) | (msgByte[37] << 16) | (msgByte[38] << 24));
                            agv.readCode = msgByte[39];
                            agv.runState = msgByte[40];

                            string strFault = string.Empty;
                            foreach (AGV.enumAgvFault fault in Enum.GetValues(typeof(AGV.enumAgvFault)))
                            {
                                if ((agv.agvFault & (uint)fault) != 0)
                                {
                                    strFault += $"[{fault}]";
                                }
                            }
                            tip.ShowAlways = true;
                            this.Invoke(new EventHandler(delegate
                            {
                                RadioButton radioButton = flowLayoutPanel1.Controls.Find(socketForClient.RemoteEndPoint.ToString(), false)[0] as RadioButton;
                                if (agv.runState == 0x05)
                                {
                                    radioButton.BackColor = Color.Red;
                                }
                                else
                                {
                                    radioButton.BackColor = agv.agvColor;
                                }
                                tip.SetToolTip(radioButton, $"电池电量:{(agv.battery / 100.0).ToString("0.##%")}\n" +
                                    $"车辆状态:{Enum.GetName(typeof(AGV.enumIsBusy), agv.isBusy)}\n" +
                                     $"车辆故障:{strFault}\n" +
                                     $"当前坐标:{agv.nowCoordinate}\n" +
                                     $"读码状态:{Enum.GetName(typeof(AGV.enumReadCod), agv.readCode)}\n" +
                                     $"运行状态:{Enum.GetName(typeof(AGV.enumRunState), agv.runState)}");
                                mapPicBox1.dispPoint((int)(agv.nowCoordinate % 10000) - 1, (int)(agv.nowCoordinate / 10000) - 1, agv.agvColor);
                            }));
                        }
                        //string msgStr = Convert.ToString(msgByte);
                        string hexStr = string.Empty;
                        for (int i = 0; i < length; i++)
                        {
                            hexStr += (msgByte[i].ToString("X2") + " ");
                        }
                        this.Invoke(new EventHandler(delegate
                        {
                            rtbMessage.AppendText(hexStr + "\n");
                        }));

                    }
                    Thread.Sleep(0);
                }
            }
            catch
            {
                this.Invoke(new EventHandler(delegate
                {
                    flowLayoutPanel1.Controls.Remove((RadioButton)flowLayoutPanel1.Controls.Find(socketForClient.RemoteEndPoint.ToString(), false)[0]);
                    AGV.AGVList[socketForClient.RemoteEndPoint.ToString()] = null;
                    AGV.AGVList.Remove(socketForClient.RemoteEndPoint.ToString());
                    socketForClient.Close();
                }));
            }
        }





        /// <summary>
        /// 生成发送的指令并发送，vehiclleID 2字节，dataID 4字节，系统时间自动生成，dataByte为系统时间之后到校验码的数据
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="vehicleID"></param>
        /// <param name="dataID"></param>
        /// <param name="dataByte"></param>
        private void sendData(byte commandType, ushort vehicleID, uint dataID, byte[] dataByte)//发送数据
        {
            byte[] sendByte = new byte[dataByte.Length + 16];
            sendByte[0] = 0x7f;
            sendByte[1] = 0x7f;
            sendByte[2] = 0x7f;
            sendByte[3] = commandType;//包类型
            sendByte[4] = (byte)(dataByte.Length + 10);//包长度
            sendByte[5] = (byte)(vehicleID & 0xff);
            sendByte[6] = (byte)((vehicleID >> 8) & 0xff);//车辆编号，小端传输(低字节先发送)
            sendByte[7] = (byte)(dataID & 0xff);
            sendByte[8] = (byte)((dataID >> 8) & 0xff);
            sendByte[9] = (byte)((dataID >> 16) & 0xff);
            sendByte[10] = (byte)((dataID >> 24) & 0xff);//数据包ID，小端传输
            uint time = uint.Parse(DateTime.Now.ToString("HHmmss"));
            sendByte[11] = (byte)(time & 0xff);
            sendByte[12] = (byte)((time >> 8) & 0xff);
            sendByte[13] = (byte)((time >> 16) & 0xff);
            sendByte[14] = (byte)((time >> 24) & 0xff);//时间，小端传输

            for (int i = 0; i < dataByte.Length; i++)
            {
                sendByte[i + 15] = dataByte[i];
            }
            byte bcc = 0;
            for (int i = 0; i < sendByte.Length - 1; i++)
            {
                bcc = (byte)(bcc ^ sendByte[i]);
            }
            sendByte[sendByte.Length - 1] = bcc;
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                RadioButton rd = control as RadioButton;//若control不是RadioButtton,则会返回null
                if (rd != null)
                {
                    if (rd.Checked)
                    {
                        try
                        {
                            AGV.AGVList[rd.Name].agvSocket.Send(sendByte);
                        }
                        catch (Exception ex)
                        {
                            AGV.AGVList[rd.Name].agvSocket.Close();
                            MessageBox.Show(ex.Message);
                            AGV.AGVList.Remove(rd.Name);
                            flowLayoutPanel1.Controls.Remove(rd);
                        }
                    }
                }
            }
        }

        private void btnSetTcp_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IPAddress.TryParse(tbIP.Text, out IPAddress iP))
                {
                    MessageBox.Show("输入IP格式不正确");
                }
                else
                {
                    tcpServer.Close();
                    isListenning = false;
                    ip = iP;
                    port = int.Parse(tbPort.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)//前进
        {
            sendData(0x01, 0, 0, new byte[] { 0x02, 0x00, 0x00, 0x00 });
        }
        private void btnStop_Click(object sender, EventArgs e)//停止
        {
            sendData(0x01, 0, 0, new byte[] { 0x01, 0x00, 0x00, 0x00 });
        }

        private void getPathBytes()
        {
            int ex, ey;
            try
            {
                ex = int.Parse(tbTargetX.Text) - 1;
                ey = int.Parse(tbTargetY.Text) - 1;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }

            int sx,sy;
            AGV selectedAgv=null;
            foreach(Control control in flowLayoutPanel1.Controls)
            {
                RadioButton rd = control as RadioButton;
                if (rd.Checked)
                {
                    selectedAgv = AGV.AGVList[rd.Name];
                    break;
                }
            }
            if (selectedAgv == null)
            {
                pathBytes = null;
            }
            else
            {
                sx = (int)(selectedAgv.nowCoordinate % 10000) - 1;
                sy = (int)(selectedAgv.nowCoordinate / 10000) - 1;
                pathBytes = new byte[0];
                d.getShortestPath(sx, sy, ex, ey, ref pathBytes);
            }

        }
        private void btnRunOnPath_Click(object sender, EventArgs e)//到达指定点
        {
            getPathBytes();
            if (pathBytes == null)
            {
                MessageBox.Show("请先选择车辆或路径");
                return;
            }
            byte[] sendByte = new byte[pathBytes.Length + 4];
            sendByte[2] = (byte)(pathBytes.Length / 4);//第三个字节，表示路径的个数
            for (int i = 0; i < pathBytes.Length; i++)
            {
                sendByte[4 + i] = pathBytes[i];
            }
            sendData(0x04, 0, 0, sendByte);
            pathBytes = null;
        }

        private void btnGoToCharge_Click(object sender, EventArgs e)//充电
        {
            getPathBytes();
            if (pathBytes == null)
            {
                MessageBox.Show("请先选择车辆或路径");
                return;
            }
            byte[] sendByte = new byte[pathBytes.Length + 4];
            short distance = 0;
            byte orientation = 0x01;
            try
            {
                distance = short.Parse(tbChargeDistanace.Text);
                if (distance >= 1000)
                {
                    MessageBox.Show("距离超出范围");
                    return;
                }
                switch (cbChargeOrientation.SelectedItem)
                {
                    case "90":
                        orientation = 0x01;
                        break;
                    case "180":
                        orientation = 0x02;
                        break;
                    case "270":
                        orientation = 0x03;
                        break;
                    case "360":
                        orientation = 0x04;
                        break;
                    default:
                        MessageBox.Show("请选择充电桩方向");
                        return;
                        //break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            sendByte[0] = (byte)((distance >> 8) & 0xff);
            sendByte[1] = (byte)(distance & 0xff);
            sendByte[2] = (byte)(pathBytes.Length / 4);//第三个字节，表示路径点的个数
            sendByte[3] = orientation;
            for (int i = 0; i < pathBytes.Length; i++)
            {
                sendByte[4 + i] = pathBytes[i];
            }
            sendData(0x03, 0, 0, sendByte);
            pathBytes = null;
        }

        private void tbnStopCharge_Click(object sender, EventArgs e)//停止充电
        {
            sendData(0x0c, 0, 0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
        }

        private void btnCalibrate_Click(object sender, EventArgs e)//坐标校准
        {
            sendData(0x0b, 0, 0, new byte[] { 0x0a, 0x00, 0x00, 0x00 });
        }

        private void btnShelfCalibrate_Click(object sender, EventArgs e)//货架校准
        {
            sendData(0x0b, 0, 0, new byte[] { 0x0b, 0x00, 0x00, 0x00 });
        }

        private void btnSimulink_Click(object sender, EventArgs e)//-----------------
        {
            Thread thConmutePath = new Thread(delegate () { d.main(d.S[int.Parse(tbSY.Text)-1, int.Parse(tbSX.Text)-1], d.S[int.Parse(tbEY.Text)-1, int.Parse(tbEX.Text)-1]); });
            thConmutePath.IsBackground = true;
            thConmutePath.Start();
        }

        private void btnJack_Click(object sender, EventArgs e)
        {
            getPathBytes();
            if (pathBytes == null)
            {
                MessageBox.Show("请先选择车辆或路径");
                return;
            }
            byte[] sendByte = new byte[pathBytes.Length + 4];
            sendByte[2] = (byte)(pathBytes.Length / 4);//第三个字节，表示路径的个数
            for (int i = 0; i < pathBytes.Length; i++)
            {
                sendByte[4 + i] = pathBytes[i];
            }
            sendData(0x05, 0, 0, sendByte);
            pathBytes = null;
        }

        private void btnLay_Click(object sender, EventArgs e)
        {
            getPathBytes();
            if (pathBytes == null)
            {
                MessageBox.Show("请先选择车辆或路径");
                return;
            }
            byte[] sendByte = new byte[pathBytes.Length + 4];
            sendByte[2] = (byte)(pathBytes.Length / 4);//第三个字节，表示路径的个数
            for (int i = 0; i < pathBytes.Length; i++)
            {
                sendByte[4 + i] = pathBytes[i];
            }
            sendData(0x06, 0, 0, sendByte);
            pathBytes = null;
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            sendData(0x07, 0, 0, new byte[] { 0x01, 0x00, 0x00, 0x00 });
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            sendData(0x07, 0, 0, new byte[] { 0x02, 0x00, 0x00, 0x00 });
        }

        private void btnRotateShelf_Click(object sender, EventArgs e)
        {
            byte[] sendByte = new byte[4];
            sendByte[0] = (byte)(cbRotateDirectionShelf.SelectedIndex + 1);
            sendData(0x08, 0, 0, sendByte);
        }

        private void btnRunRandom_Click(object sender, EventArgs e)
        {
            switch (btnRunRandom.Text) 
            {
                case "开始":
                    AGV agv = null;
                    Random rd=new Random();
                    runRandom = true;
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        RadioButton rb = control as RadioButton;
                        if (rb.Checked)
                        {
                            agv = AGV.AGVList[rb.Name];
                            break;
                        }
                    }
                    if (agv == null)
                    {
                        return;
                    }
                    int minX, minY, maxX, maxY;
                    minX = int.Parse(tbMinX.Text)-1;
                    minY = int.Parse(tbMinY.Text)-1;
                    maxX = int.Parse(tbMaxX.Text)-1;
                    maxY = int.Parse(tbMaxY.Text)-1;
                    thRunRandom = new Thread(delegate ()
                    {
                        int sx, sy, ex, ey;
                        while (runRandom)
                        {
                            sx = (int)(agv.nowCoordinate % 10000) - 1;
                            sy = (int)(agv.nowCoordinate / 10000) - 1;
                            ex = rd.Next(minX, maxX);
                            ey = rd.Next(minY, maxY);
                            if (d.S[ey, ex].isObstacle)
                            {
                                Thread.Sleep(100);
                                continue;
                            }
                            pathBytes = new byte[0];
                            d.getShortestPath(sx, sy, ex, ey, ref pathBytes);
                            byte[] sendByte = new byte[pathBytes.Length + 4];
                            sendByte[2] = (byte)(pathBytes.Length / 4);//第三个字节，表示路径的个数
                            for (int i = 0; i < pathBytes.Length; i++)
                            {
                                sendByte[4 + i] = pathBytes[i];
                            }
                            sendData(0x04, 0, 0, sendByte);
                            pathBytes = null;
                            while (agv.nowCoordinate != ex + 1 + (ey + 1) * 10000&&runRandom)
                            {
                                Thread.Sleep(200);
                            }
                        }

                    });
                    thRunRandom.IsBackground = true;
                    thRunRandom.Start();
                    btnRunRandom.Text = "停止";
                    break;
                case "停止":
                    btnRunRandom.Text = "开始";
                    runRandom = false;
                    break;
            }
        }
    }
}
