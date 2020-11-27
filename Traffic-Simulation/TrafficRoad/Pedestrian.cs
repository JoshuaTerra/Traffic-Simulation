using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TrafficRoad
{
    class Pedestrian : Traffic
    {
        public new void spawnTraffic(int leftX, int topY, int width, int height, Path path)
        {
            trafficPB = new PictureBox();
            trafficPB.Image = Properties.Resources.pedestrian;
            trafficPB.BackColor = Color.Transparent;
            trafficPB.Size = new Size(width, height);
            trafficPB.Left = leftX;
            trafficPB.Top = topY;
            this.width = width;
            this.height = height;
            this.path = path;
        }
    }
}
