using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficRoad
{
    class Traffic
    {
        public PictureBox t;

        public String direction = "forward";

        public int width = 23;
        public int lenght = 39;

        public void spawnTraffic(int left, int top)
        {
            t = new PictureBox();
            t.Image = Properties.Resources.vwgolf;

            t.BackColor = Color.Transparent;

            t.SizeMode = PictureBoxSizeMode.StretchImage;

            t.Size = new Size(23, 39);

            t.Left = left;
            t.Top = top;
        }

    }
}
