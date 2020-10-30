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
        public void addCar(int left, int top)
        {
            trafficPB = new PictureBox();

            trafficPB.Image = Properties.Resources.ferrari;

            trafficPB.BackColor = Color.Transparent;

            trafficPB.SizeMode = PictureBoxSizeMode.StretchImage;

            trafficPB.Size = new Size(15, 30);

            trafficPB.Left = left;

            trafficPB.Top = top;
        }
    }
}
