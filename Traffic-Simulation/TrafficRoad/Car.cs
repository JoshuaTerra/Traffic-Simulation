using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficRoad
{
    class Car : Traffic
    {
        public void spawnTraffic(int left, int top)
        {
            t = new PictureBox();

            t.Size = new Size(23, 39);

            t.BackColor = Color.Transparent;

            t.SizeMode = PictureBoxSizeMode.StretchImage;

            t.Left = left;

            t.Top = top;
        }
    }
}
