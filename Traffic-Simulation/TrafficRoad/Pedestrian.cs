using System;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace TrafficRoad
{
    class Pedestrian : Traffic
    {
        public void spawnTraffic(int leftX, int topY, string direction, Road road)
        {
            trafficPB = new PictureBox();
            //trafficPB.Image = Properties.Resources.ferrari;
            trafficPB.BackColor = Color.Transparent;
            trafficPB.SizeMode = PictureBoxSizeMode.StretchImage;
            trafficPB.Size = new Size(15, 30);

            this.direction = direction;

            trafficPB.Left = leftX;
            trafficPB.Top = topY;
        }
    }
}
