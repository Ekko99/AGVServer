using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AGVServer
{
    class AGV
    {
        static public Dictionary<string, AGV> AGVList = new Dictionary<string, AGV>();
        static public byte[] colorRGB = new byte[3] { 0, 1, 82 };
        public enum enumIsBusy : byte { 忙碌 = 0, 空闲 = 1 };
        public enum enumAgvFault : uint
        {
            通讯中断 = 1, 左右电机驱动中断 = 2, 导航相机通讯中断 = 4, 避障相机通讯中断 = 8,
            task通讯中断 = 0x10, 二维码地图错误 = 0x20, CAN通讯数据错误 = 0x80, 二维码丢失 = 0x100, 陀螺仪角度突变故障 = 0x200,
            电机故障 = 0x400, 顶旋电机驱动通讯中断 = 0x800, 货架相机通讯中断 = 0x20000, base通讯中断 = 0x40000,
            电池bms通讯中断 = 0x80000, 上限位报警 = 0x100000, 铁电数据错误 = 0x400000, 防撞条触发 = 0x800000, 导航二维码丢失 = 0x1000000, 货架二维码丢失 = 0x2000000
        };
        public enum enumHasShelf : byte { 有货架 = 1, 无货架 = 0 };
        public enum enumReadCod : byte { 读到码 = 1, 未读到码 = 2 };
        public enum enumRunState : byte { 正常运行 = 1, 避障状态 = 2, 管制状态 = 3, 充电状态 = 4, 车辆故障 = 5 };
        //static public int numOfAGV = 0;
        public Socket agvSocket;
        public Color agvColor;

        public ushort agvID;
        public byte battery;
        public byte isBusy;
        public uint agvFault;
        public uint nowCoordinate;
        public uint subPathCoordinate;
        public uint targetCoordinate;
        public byte hasShelf;
        public byte shelfOrientation;
        public uint shelfCode;
        public byte readCode;
        public byte runState;

        public AGV(Socket socket)
        {
            do
            {
                colorRGB[0] += 31;
                colorRGB[1] += 72;
                colorRGB[2] += 93;
            } while (false);
            AGVList.Add($"{socket.RemoteEndPoint}", this);
            agvSocket = socket;
            agvColor = Color.FromArgb(colorRGB[0], colorRGB[1], colorRGB[2]);


        }

    }
}
