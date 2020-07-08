using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AGVServer
{
    public partial class mapPicBox : UserControl
    {
        public int length;
        Bitmap backBtm;
        Bitmap foreBtm;
        int column;
        int row;
        public mapPicBox()
        {
            InitializeComponent();
        }
        public void drawMap(int column, int row)
        {
            this.column = column;
            this.row = row;
            if (backBtm != null)
            {
                backBtm.Dispose();
            }
            backBtm = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            Pen p = new Pen(Color.Black, (float)0.1);
            //SolidBrush brush = new SolidBrush(Color.Green);
            Graphics g = Graphics.FromImage(backBtm);
            g.Clear(Color.White);
            if (this.Size.Width / column < this.Size.Height / row)
            {
                length = this.Size.Width / column;
            }
            else
            {
                length = this.Size.Height / row;
            }
            for (int i = 0; i <= column; i++)//画竖线
            {
                g.DrawLine(p, length * i, 0, length * i, length * row);
            }
            for (int i = 0; i <= row; i++)//画横线
            {
                g.DrawLine(p, 0, length * i, length * column, length * i);
            }
            foreBtm = (Bitmap)backBtm.Clone();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = (Image)foreBtm.Clone();

            p.Dispose();
            g.Dispose();
        }

        public void addPoint(int x, int y, Color color)
        {
            SolidBrush brush = new SolidBrush(color);
            Graphics g = Graphics.FromImage(backBtm);
            g.FillRectangle(brush, x * length + (float)0.1, y * length + (float)0.1, length - (float)0.1 * 2, length - (float)0.1 * 2);
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = (Image)backBtm.Clone();
            g.Dispose();
            brush.Dispose();
        }
        public void dispPoint(int x, int y, Color color)
        {
            if (foreBtm != null)
            {
                foreBtm.Dispose();
            }
            foreBtm = (Bitmap)backBtm.Clone();
            SolidBrush brush = new SolidBrush(color);
            Graphics g = Graphics.FromImage(foreBtm);
            g.FillRectangle(brush, x * length + (float)0.1, y * length + (float)0.1, length - (float)0.1 * 2, length - (float)0.1 * 2);
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = (Image)foreBtm.Clone();
            g.Dispose();
            brush.Dispose();
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            if (backBtm == null)
            {
                return;
            }
            //if (this.Size.Width / column < this.Size.Height / row)
            //{
            //    length = this.Size.Width / column;
            //}
            //else
            //{
            //    length = this.Size.Height / row;
            //}

        }
    }
}
