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
        public void spawnTraffic(int leftX, int topY, int width, int height, Path path)
        {
            trafficPB = new PictureBox();
            trafficPB.Image = Properties.Resources.pedestrian;
            trafficPB.BackColor = Color.Transparent;
            trafficPB.Size = new Size(2, 2);
            this.path = path;
            trafficPB.Left = leftX;
            trafficPB.Top = topY;
            this.width = width;
            this.height = height;
        }
    }
}
