namespace AGVServer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbMinY = new System.Windows.Forms.TextBox();
            this.btnRunRandom = new System.Windows.Forms.Button();
            this.tbMinX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbMaxX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMaxY = new System.Windows.Forms.TextBox();
            this.btnRotateShelf = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbRotateDirectionShelf = new System.Windows.Forms.ComboBox();
            this.btnUP = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLay = new System.Windows.Forms.Button();
            this.btnJack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTargetX = new System.Windows.Forms.TextBox();
            this.tbTargetY = new System.Windows.Forms.TextBox();
            this.btnShelfCalibrate = new System.Windows.Forms.Button();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.tbnStopCharge = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbChargeOrientation = new System.Windows.Forms.ComboBox();
            this.tbChargeDistanace = new System.Windows.Forms.TextBox();
            this.btnGoToCharge = new System.Windows.Forms.Button();
            this.btnGoToTarget = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tbSX = new System.Windows.Forms.TextBox();
            this.tbSY = new System.Windows.Forms.TextBox();
            this.btnSimulink = new System.Windows.Forms.Button();
            this.tbEX = new System.Windows.Forms.TextBox();
            this.tbEY = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbNetState = new System.Windows.Forms.Label();
            this.mapPicBox1 = new AGVServer.mapPicBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.cbIP = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.btnSetTcp = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1163, 869);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1155, 843);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "地图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 274F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 97.08738F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.912621F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.mapPicBox1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 818F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1149, 837);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnRotateShelf);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbRotateDirectionShelf);
            this.panel1.Controls.Add(this.btnUP);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnLay);
            this.panel1.Controls.Add(this.btnJack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbTargetX);
            this.panel1.Controls.Add(this.tbTargetY);
            this.panel1.Controls.Add(this.btnShelfCalibrate);
            this.panel1.Controls.Add(this.btnCalibrate);
            this.panel1.Controls.Add(this.tbnStopCharge);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbChargeOrientation);
            this.panel1.Controls.Add(this.tbChargeDistanace);
            this.panel1.Controls.Add(this.btnGoToCharge);
            this.panel1.Controls.Add(this.btnGoToTarget);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnContinue);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.tbSX);
            this.panel1.Controls.Add(this.tbSY);
            this.panel1.Controls.Add(this.btnSimulink);
            this.panel1.Controls.Add(this.tbEX);
            this.panel1.Controls.Add(this.tbEY);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 812);
            this.panel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMinY);
            this.groupBox1.Controls.Add(this.btnRunRandom);
            this.groupBox1.Controls.Add(this.tbMinX);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbMaxX);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbMaxY);
            this.groupBox1.Location = new System.Drawing.Point(6, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 85);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "随即跑";
            // 
            // tbMinY
            // 
            this.tbMinY.Location = new System.Drawing.Point(136, 20);
            this.tbMinY.Name = "tbMinY";
            this.tbMinY.Size = new System.Drawing.Size(65, 21);
            this.tbMinY.TabIndex = 33;
            // 
            // btnRunRandom
            // 
            this.btnRunRandom.Location = new System.Drawing.Point(216, 20);
            this.btnRunRandom.Name = "btnRunRandom";
            this.btnRunRandom.Size = new System.Drawing.Size(31, 48);
            this.btnRunRandom.TabIndex = 37;
            this.btnRunRandom.Text = "开始";
            this.btnRunRandom.UseVisualStyleBackColor = true;
            this.btnRunRandom.Click += new System.EventHandler(this.btnRunRandom_Click);
            // 
            // tbMinX
            // 
            this.tbMinX.Location = new System.Drawing.Point(62, 20);
            this.tbMinX.Name = "tbMinX";
            this.tbMinX.Size = new System.Drawing.Size(65, 21);
            this.tbMinX.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 36;
            this.label10.Text = "最大XY";
            // 
            // tbMaxX
            // 
            this.tbMaxX.Location = new System.Drawing.Point(62, 47);
            this.tbMaxX.Name = "tbMaxX";
            this.tbMaxX.Size = new System.Drawing.Size(65, 21);
            this.tbMaxX.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 36;
            this.label9.Text = "最小XY";
            // 
            // tbMaxY
            // 
            this.tbMaxY.Location = new System.Drawing.Point(136, 47);
            this.tbMaxY.Name = "tbMaxY";
            this.tbMaxY.Size = new System.Drawing.Size(65, 21);
            this.tbMaxY.TabIndex = 35;
            // 
            // btnRotateShelf
            // 
            this.btnRotateShelf.Location = new System.Drawing.Point(6, 763);
            this.btnRotateShelf.Name = "btnRotateShelf";
            this.btnRotateShelf.Size = new System.Drawing.Size(139, 23);
            this.btnRotateShelf.TabIndex = 31;
            this.btnRotateShelf.Text = "货架指定方向旋转";
            this.btnRotateShelf.UseVisualStyleBackColor = true;
            this.btnRotateShelf.Click += new System.EventHandler(this.btnRotateShelf_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 722);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "货架旋转方向:";
            // 
            // cbRotateDirectionShelf
            // 
            this.cbRotateDirectionShelf.FormattingEnabled = true;
            this.cbRotateDirectionShelf.Items.AddRange(new object[] {
            "A面朝前",
            "B面超前",
            "C面超前",
            "D面超前",
            "180°",
            "左转90°",
            "右转90°"});
            this.cbRotateDirectionShelf.Location = new System.Drawing.Point(6, 737);
            this.cbRotateDirectionShelf.Name = "cbRotateDirectionShelf";
            this.cbRotateDirectionShelf.Size = new System.Drawing.Size(137, 20);
            this.cbRotateDirectionShelf.TabIndex = 29;
            // 
            // btnUP
            // 
            this.btnUP.Location = new System.Drawing.Point(6, 658);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(139, 23);
            this.btnUP.TabIndex = 28;
            this.btnUP.Text = "升降装置升起";
            this.btnUP.UseVisualStyleBackColor = true;
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(6, 687);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(139, 23);
            this.btnDown.TabIndex = 27;
            this.btnDown.Text = "升降装置降落";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLay
            // 
            this.btnLay.Location = new System.Drawing.Point(6, 629);
            this.btnLay.Name = "btnLay";
            this.btnLay.Size = new System.Drawing.Size(139, 23);
            this.btnLay.TabIndex = 26;
            this.btnLay.Text = "前往目标点并放下货架";
            this.btnLay.UseVisualStyleBackColor = true;
            this.btnLay.Click += new System.EventHandler(this.btnLay_Click);
            // 
            // btnJack
            // 
            this.btnJack.Location = new System.Drawing.Point(6, 600);
            this.btnJack.Name = "btnJack";
            this.btnJack.Size = new System.Drawing.Size(139, 23);
            this.btnJack.TabIndex = 25;
            this.btnJack.Text = "前往目标点并顶起货架";
            this.btnJack.UseVisualStyleBackColor = true;
            this.btnJack.Click += new System.EventHandler(this.btnJack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "目标点坐标：";
            // 
            // tbTargetX
            // 
            this.tbTargetX.Location = new System.Drawing.Point(6, 352);
            this.tbTargetX.Name = "tbTargetX";
            this.tbTargetX.Size = new System.Drawing.Size(66, 21);
            this.tbTargetX.TabIndex = 22;
            // 
            // tbTargetY
            // 
            this.tbTargetY.Location = new System.Drawing.Point(78, 352);
            this.tbTargetY.Name = "tbTargetY";
            this.tbTargetY.Size = new System.Drawing.Size(67, 21);
            this.tbTargetY.TabIndex = 23;
            // 
            // btnShelfCalibrate
            // 
            this.btnShelfCalibrate.Location = new System.Drawing.Point(6, 571);
            this.btnShelfCalibrate.Name = "btnShelfCalibrate";
            this.btnShelfCalibrate.Size = new System.Drawing.Size(139, 23);
            this.btnShelfCalibrate.TabIndex = 21;
            this.btnShelfCalibrate.Text = "货架校准";
            this.btnShelfCalibrate.UseVisualStyleBackColor = true;
            this.btnShelfCalibrate.Click += new System.EventHandler(this.btnShelfCalibrate_Click);
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(6, 542);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(139, 23);
            this.btnCalibrate.TabIndex = 20;
            this.btnCalibrate.Text = "坐标校准";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // tbnStopCharge
            // 
            this.tbnStopCharge.Location = new System.Drawing.Point(6, 512);
            this.tbnStopCharge.Name = "tbnStopCharge";
            this.tbnStopCharge.Size = new System.Drawing.Size(139, 23);
            this.tbnStopCharge.TabIndex = 19;
            this.tbnStopCharge.Text = "强制停止充电";
            this.tbnStopCharge.UseVisualStyleBackColor = true;
            this.tbnStopCharge.Click += new System.EventHandler(this.tbnStopCharge_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(80, 438);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "充电桩方位";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 438);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "充电桩距离";
            // 
            // cbChargeOrientation
            // 
            this.cbChargeOrientation.FormattingEnabled = true;
            this.cbChargeOrientation.Items.AddRange(new object[] {
            "90",
            "180",
            "270",
            "360"});
            this.cbChargeOrientation.Location = new System.Drawing.Point(78, 455);
            this.cbChargeOrientation.Name = "cbChargeOrientation";
            this.cbChargeOrientation.Size = new System.Drawing.Size(67, 20);
            this.cbChargeOrientation.TabIndex = 17;
            // 
            // tbChargeDistanace
            // 
            this.tbChargeDistanace.Location = new System.Drawing.Point(6, 455);
            this.tbChargeDistanace.Name = "tbChargeDistanace";
            this.tbChargeDistanace.Size = new System.Drawing.Size(66, 21);
            this.tbChargeDistanace.TabIndex = 16;
            // 
            // btnGoToCharge
            // 
            this.btnGoToCharge.Location = new System.Drawing.Point(6, 482);
            this.btnGoToCharge.Name = "btnGoToCharge";
            this.btnGoToCharge.Size = new System.Drawing.Size(139, 23);
            this.btnGoToCharge.TabIndex = 15;
            this.btnGoToCharge.Text = "前往目标点并充电";
            this.btnGoToCharge.UseVisualStyleBackColor = true;
            this.btnGoToCharge.Click += new System.EventHandler(this.btnGoToCharge_Click);
            // 
            // btnGoToTarget
            // 
            this.btnGoToTarget.Location = new System.Drawing.Point(6, 408);
            this.btnGoToTarget.Name = "btnGoToTarget";
            this.btnGoToTarget.Size = new System.Drawing.Size(139, 23);
            this.btnGoToTarget.TabIndex = 14;
            this.btnGoToTarget.Text = "前往目标点";
            this.btnGoToTarget.UseVisualStyleBackColor = true;
            this.btnGoToTarget.Click += new System.EventHandler(this.btnRunOnPath_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(87, 379);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(58, 23);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(6, 379);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(66, 23);
            this.btnContinue.TabIndex = 12;
            this.btnContinue.Text = "继续";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 192);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(253, 129);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // tbSX
            // 
            this.tbSX.Location = new System.Drawing.Point(6, 7);
            this.tbSX.Name = "tbSX";
            this.tbSX.Size = new System.Drawing.Size(66, 21);
            this.tbSX.TabIndex = 1;
            // 
            // tbSY
            // 
            this.tbSY.Location = new System.Drawing.Point(78, 7);
            this.tbSY.Name = "tbSY";
            this.tbSY.Size = new System.Drawing.Size(67, 21);
            this.tbSY.TabIndex = 1;
            // 
            // btnSimulink
            // 
            this.btnSimulink.Location = new System.Drawing.Point(151, 7);
            this.btnSimulink.Name = "btnSimulink";
            this.btnSimulink.Size = new System.Drawing.Size(110, 23);
            this.btnSimulink.TabIndex = 0;
            this.btnSimulink.Text = "模拟行进";
            this.btnSimulink.UseVisualStyleBackColor = true;
            this.btnSimulink.Click += new System.EventHandler(this.btnSimulink_Click);
            // 
            // tbEX
            // 
            this.tbEX.Location = new System.Drawing.Point(6, 36);
            this.tbEX.Name = "tbEX";
            this.tbEX.Size = new System.Drawing.Size(66, 21);
            this.tbEX.TabIndex = 3;
            // 
            // tbEY
            // 
            this.tbEY.Location = new System.Drawing.Point(78, 36);
            this.tbEY.Name = "tbEY";
            this.tbEY.Size = new System.Drawing.Size(67, 21);
            this.tbEY.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbNetState);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1055, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(67, 812);
            this.panel2.TabIndex = 8;
            // 
            // lbNetState
            // 
            this.lbNetState.BackColor = System.Drawing.Color.Red;
            this.lbNetState.Location = new System.Drawing.Point(3, 5);
            this.lbNetState.Name = "lbNetState";
            this.lbNetState.Size = new System.Drawing.Size(57, 23);
            this.lbNetState.TabIndex = 0;
            this.lbNetState.Text = "网络";
            this.lbNetState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mapPicBox1
            // 
            this.mapPicBox1.AutoScroll = true;
            this.mapPicBox1.Location = new System.Drawing.Point(277, 3);
            this.mapPicBox1.Name = "mapPicBox1";
            this.mapPicBox1.Size = new System.Drawing.Size(772, 812);
            this.mapPicBox1.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtbMessage);
            this.tabPage2.Controls.Add(this.cbIP);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbPort);
            this.tabPage2.Controls.Add(this.tbIP);
            this.tabPage2.Controls.Add(this.btnSetTcp);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1155, 843);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "通信设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtbMessage
            // 
            this.rtbMessage.Location = new System.Drawing.Point(10, 105);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(329, 96);
            this.rtbMessage.TabIndex = 5;
            this.rtbMessage.Text = "";
            // 
            // cbIP
            // 
            this.cbIP.FormattingEnabled = true;
            this.cbIP.Location = new System.Drawing.Point(10, 58);
            this.cbIP.Name = "cbIP";
            this.cbIP.Size = new System.Drawing.Size(157, 20);
            this.cbIP.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "IP";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(171, 30);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(87, 21);
            this.tbPort.TabIndex = 2;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(9, 30);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(157, 21);
            this.tbIP.TabIndex = 1;
            // 
            // btnSetTcp
            // 
            this.btnSetTcp.Location = new System.Drawing.Point(264, 30);
            this.btnSetTcp.Name = "btnSetTcp";
            this.btnSetTcp.Size = new System.Drawing.Size(75, 23);
            this.btnSetTcp.TabIndex = 0;
            this.btnSetTcp.Text = "确定";
            this.btnSetTcp.UseVisualStyleBackColor = true;
            this.btnSetTcp.Click += new System.EventHandler(this.btnSetTcp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 869);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShelfCalibrate;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Button tbnStopCharge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbChargeOrientation;
        private System.Windows.Forms.TextBox tbChargeDistanace;
        private System.Windows.Forms.Button btnGoToCharge;
        private System.Windows.Forms.Button btnGoToTarget;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox tbSX;
        private System.Windows.Forms.TextBox tbSY;
        private System.Windows.Forms.Button btnSimulink;
        private System.Windows.Forms.TextBox tbEX;
        private System.Windows.Forms.TextBox tbEY;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbNetState;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.ComboBox cbIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Button btnSetTcp;
        private mapPicBox mapPicBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTargetX;
        private System.Windows.Forms.TextBox tbTargetY;
        private System.Windows.Forms.Button btnUP;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLay;
        private System.Windows.Forms.Button btnJack;
        private System.Windows.Forms.Button btnRotateShelf;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbRotateDirectionShelf;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbMinY;
        private System.Windows.Forms.Button btnRunRandom;
        private System.Windows.Forms.TextBox tbMinX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbMaxX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbMaxY;
    }
}

