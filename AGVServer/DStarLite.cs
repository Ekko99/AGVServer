using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace AGVServer
{

    /// <summary>
    /// 表示节点
    /// </summary>
    public class point : IComparable<point>   //key为长度2的数组，g为到终点的实际路程
    {
        public bool isObstacle = false;
        public static readonly int infinite = 1000000000;
        public int x, y;
        public int rhs, g;
        public Key key;

        public point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public struct Key
        {
            double k1;
            double k2;
            public Key(double k1, double k2)
            {
                this.k1 = k1;
                this.k2 = k2;
            }
            public static bool operator >(Key key1, Key key2)
            {
                if (key1.k1 > key2.k1)
                {
                    return true;
                }
                else
                {
                    if (key1.k1 < key2.k1) { return false; }
                    else { return key1.k2 > key2.k2; }
                }
            }
            public static bool operator <(Key key1, Key key2)
            {
                if (key1.k1 < key2.k1)
                {
                    return true;
                }
                else
                {
                    if (key1.k1 > key2.k1) { return false; }
                    else { return key1.k2 < key2.k2; }
                }
            }
        }
        public int CompareTo(point comparP)
        {
            if (this.key < comparP.key)
            {
                return -1;
            }
            else
            {
                if (this.key > comparP.key)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public void initialize()
        {
            rhs = infinite;
            g = infinite;
        }
    }


    class DStarLite
    {
        public point[,] S;

        int row, column;
        double km;
        point pStart, pGoal;
        List<point> piorityU;
        //byte huristicNum = 0;
        public bool changeObstacle = false;
        public point[] changingPoint;
        //------------------------------------
        //public mapPanel mapPanel1;//画板
        public mapPicBox mapPicBox1;

        //------------------------------------
        public DStarLite(int row, int column)
        {
            this.row = row;
            this.column = column;
            S = new point[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    S[i, j] = new point(j, i);
                }
            }
            changingPoint = new point[0];
        }
        private int min(int num1, int num2)//返回两个数中的较小者
        {
            if (num1 <= num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }
        private int cost(point p1, point p2)//计算cost
        {
            try
            {
                if (!p1.isObstacle && !p2.isObstacle)
                {
                    if ((Math.Abs(p1.x - p2.x) + Math.Abs(p1.y - p2.y)) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return point.infinite;
                    }
                }
                else
                {
                    return point.infinite;
                }
            }
            catch
            {
                return point.infinite;
            }
        }
        private double huristicMHD(point p1, point p2)//计算h启发值
        {
            double dx = Math.Abs(p1.x - p2.x);
            double dy = Math.Abs(p1.y - p2.y);
            double h;
            h = dx + dy;
            //switch (huristicNum)//最后发现这里只有0和2可以用
            //{
            //    case 0://曼哈顿距离
            //        h = dx + dy;
            //        break;
            //    case 1://改进曼哈顿，优点：会优先沿一个方向搜索；缺陷：当45度时会左右摇摆
            //        h = dx + dy + 0.0001 * ((0.707 * (dx + dy)) / Math.Pow((dx * dx + dy * dy + 0.0001), 0.5) - 1);
            //        break;
            //    case 2://欧几里得距离
            //        h = Math.Pow((dx * dx + dy * dy), 0.5);
            //        break;
            //    case 3://改进曼哈顿2，优先搜索使角度减小的方向
            //        //h = (Math.Abs(dx-dy)<5 ? dx + dy + (0.707 * (dx + dy) / Math.Pow((dx * dx + dy * dy + 0.0001), 0.5) - 1) 
            //        //                : dx + dy + (0.707 * (dx) / Math.Pow((dx * dx + dy * dy + 0.0001), 0.5) - 1)  );
            //        h = dx + dy + (1000 * 0.707 * (dx) / Math.Pow((dx * dx + dy * dy + 0.0001), 0.5));
            //        break;
            //    default:
            //        h = dx + dy;
            //        break;
            //}
            return h;
        }
        private point.Key calculateKey(point p)//计算k
        {
            return new point.Key(min(p.g, p.rhs) + huristicMHD(pStart, p) + km, min(p.g, p.rhs));
        }
        private void initialize()//初始化
        {
            piorityU = new List<point>();
            km = 0;
            for (int i = 0; i < S.GetLength(0); i++)//行
            {
                for (int j = 0; j < S.GetLength(1); j++)//列
                {
                    S[i, j].initialize();
                }
            }
            pGoal.rhs = 0;
            pGoal.key = new point.Key(huristicMHD(pStart, pGoal), 0);
            piorityU.Add(pGoal);
        }
        private void updateVertex(point p)//更新节点
        {
            if (p.g != p.rhs)
            {
                if (piorityU.Exists(tem => p.Equals(tem)))
                {
                    p.key = calculateKey(p);
                }
                else
                {
                    p.key = calculateKey(p);
                    piorityU.Add(p);
                    //mapPanel1.drawPoint(p.x, p.y, Color.Yellow);
                }
            }
            else//g==rhs
            {
                if (piorityU.Exists(tem => tem.Equals(p)))
                {
                    piorityU.Remove(p);
                    //mapPanel1.drawPoint(p.x, p.y, Color.DimGray);
                }
            }
        }
        private point[] getNeighbor(point p)//获取邻接节点
        {
            point[] neighbor = new point[0];
            try
            {
                point p1 = S[p.y, p.x - 1];
                if (!p1.isObstacle)
                {
                    Array.Resize(ref neighbor, neighbor.Length + 1);
                    neighbor[neighbor.Length - 1] = p1;
                }
            }
            catch { }
            try
            {
                point p1 = S[p.y, p.x + 1];
                if (!p1.isObstacle)
                {
                    Array.Resize(ref neighbor, neighbor.Length + 1);
                    neighbor[neighbor.Length - 1] = p1;
                }
            }
            catch { }
            try
            {
                point p1 = S[p.y - 1, p.x];
                if (!p1.isObstacle)
                {
                    Array.Resize(ref neighbor, neighbor.Length + 1);
                    neighbor[neighbor.Length - 1] = p1;
                }
            }
            catch { }
            try
            {
                point p1 = S[p.y + 1, p.x];
                if (!p1.isObstacle)
                {
                    Array.Resize(ref neighbor, neighbor.Length + 1);
                    neighbor[neighbor.Length - 1] = p1;
                }
            }
            catch { }
            return neighbor;
        }
        private void computeShortestPath()//计算最短路径
        {

            while (piorityU.Min().key < calculateKey(pStart) || pStart.rhs > pStart.g)
            {
                point u = piorityU.Min();
                point.Key k_old = u.key;
                point.Key k_new = calculateKey(u);
                if (k_old < k_new)
                {
                    u.key = k_new;
                }
                else
                {
                    if (u.g > u.rhs)
                    {
                        u.g = u.rhs;
                        piorityU.Remove(u);
                        //mapPanel1.drawPoint(u.x, u.y, Color.Gray);
                        //int rhs1 = point.infinite,rhs2=point.infinite,rhs3=point.infinite,rhs4=point.infinite;
                        foreach (point p in getNeighbor(u))
                        {
                            if (p != pGoal)
                            {
                                p.rhs = min(p.rhs, cost(p, u) + u.g);
                                updateVertex(p);
                            }
                        }
                    }
                    else
                    {
                        int g_old = u.g;
                        u.g = point.infinite;
                        point[] neighbor = getNeighbor(u);
                        Array.Resize(ref neighbor, neighbor.Length + 1);
                        neighbor[neighbor.Length - 1] = u;//把u自身加进去
                        foreach (point p in neighbor)
                        {
                            if (p.rhs == cost(p, u) + g_old)
                            {
                                if (p != pGoal)
                                {
                                    p.rhs = point.infinite;
                                    foreach (point s in getNeighbor(p))
                                    {
                                        p.rhs = min(p.rhs, cost(p, s) + s.g);
                                    }
                                }
                            }
                            updateVertex(p);
                        }
                    }
                }
            }
        }


        public void main(point start, point goal)//
        {
            Form1.isMoving = true;
            pStart = start;
            pGoal = goal;
            //this.huristicNum = huristicNum;

            point pLast = pStart;
            initialize();
            lock (Form1.myLock)
            {
                computeShortestPath();
            }
            while (pStart != pGoal)
            {
                if (pStart.rhs == point.infinite)
                {
                    return;
                }
                point temp = new point(0, 0);
                temp.g = point.infinite + 1;
                point[] neighbor = getNeighbor(pStart);
                foreach (point s in neighbor)
                {
                    if (cost(pStart, temp) + temp.g >= cost(pStart, s) + s.g)
                    {
                        temp = s;
                    }
                }
                pStart = temp;
                // Move to pStart-----------------------------------------------
                mapPicBox1.Invoke(new EventHandler(delegate{ mapPicBox1.dispPoint((int)pStart.x, (int)pStart.y, Color.Red); }));
                //------------------------------------------------------------

                #region 检测到地图变化
                lock (Form1.myLock)
                {
                    if (changeObstacle)
                    {
                        km += huristicMHD(pLast, pStart);
                        pLast = pStart;
                        foreach (point chP in changingPoint)
                        {
                            point tempP = new point(chP.x, chP.y);
                            tempP.isObstacle = chP.isObstacle;
                            chP.isObstacle = !chP.isObstacle;
                            point[] neighborChP = getNeighbor(chP);
                            //Array.Resize(ref neighborChP, neighborChP.Length + 1);
                            //neighborChP[neighborChP.Length - 1] = chP;
                            foreach (point sucChP in neighborChP)//在临近节点中，有经过chP的点要更新rhs
                            {
                                int c_old = cost(tempP, sucChP);
                                //chP.isObstacle = !chP.isObstacle;
                                if (c_old > cost(sucChP, chP))
                                {
                                    if (!sucChP.Equals(pGoal))
                                    {
                                        sucChP.rhs = min(sucChP.rhs, cost(sucChP, chP) + chP.g);
                                    }
                                }
                                else
                                {
                                    if (sucChP.rhs == c_old + chP.g)
                                    {
                                        if (!sucChP.Equals(pGoal))
                                        {
                                            sucChP.rhs = point.infinite;
                                            foreach (point s_ in getNeighbor(sucChP))
                                            {
                                                sucChP.rhs = min(sucChP.rhs, cost(sucChP, s_) + s_.g);
                                            }
                                        }
                                    }
                                }
                                updateVertex(sucChP);
                            }
                            //chP.rhs = point.infinite;
                        }
                        //pStart.rhs = point.infinite;//test---------------
                        computeShortestPath();
                        changeObstacle = false;
                        changingPoint = new point[0];
                    }
                }
                #endregion


                Thread.Sleep(100);
            }
            Form1.isMoving = false;
        }

        public void changePoint(int x, int y)
        {
            S[y, x].isObstacle = !S[y, x].isObstacle;
        }


        /// <summary>
        /// 按井智agv的协议获取路径数组   sx: 起始点x坐标，从0开始.例如：协议中的10001，坐标(sx,xy)为(0,0)
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="ex"></param>
        /// <param name="ey"></param>
        /// <param name="pathBytes"></param>
        public void getShortestPath(int sx,int sy,int ex,int ey,ref byte[] pathBytes)
        {
            Form1.isMoving = true;
            pStart = S[sy,sx];
            pGoal = S[ey,ex];
            int pathPoint;
            point pLast = pStart;
            point pLastLast = pLast;
            initialize();
            lock (Form1.myLock)
            {
                computeShortestPath();
            }
            while (pStart != pGoal)
            {
                if (pStart.rhs == point.infinite)
                {
                    pathBytes = null;
                    return;
                }
                point temp = new point(0, 0);
                temp.g = point.infinite + 1;
                point[] neighbor = getNeighbor(pStart);
                foreach (point s in neighbor)
                {
                    if (cost(pStart, temp) + temp.g >= cost(pStart, s) + s.g)
                    {
                        temp = s;
                    }
                }
                pLastLast = pLast;
                pLast = pStart;
                pStart = temp;
                // Move to pStart-----------------------------------------------
                if (pStart.x != pLastLast.x && pStart.y != pLastLast.y)//判断是不是转折点(只需要把转折点发送给agv)
                {
                    //mapPicBox1.addPoint(pLast.x, pLast.y, Color.Red);
                    pathPoint = (pLast.y + 1) * 10000 + (pLast.x + 1);
                    Array.Resize(ref pathBytes, pathBytes.Length + 4);
                    for (int i = 0; i < 4; i++)
                    {
                        pathBytes[pathBytes.Length - 1 - i] = (byte)((pathPoint >> (i * 8)) & 0xff);//大端传输
                    }
                }
                //------------------------------------------------------------

            }
            pathPoint = (pGoal.y + 1) * 10000 + (pGoal.x + 1);
            Array.Resize(ref pathBytes, pathBytes.Length + 4);
            for (int i = 0; i < 4; i++)
            {
                pathBytes[pathBytes.Length - 1 - i] = (byte)((pathPoint >> (i * 8)) & 0xff);//大端传输
            }

            Form1.isMoving = false;

        }

    }
}
