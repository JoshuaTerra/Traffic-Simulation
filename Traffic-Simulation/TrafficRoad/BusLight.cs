using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficRoad
{
    class BusLight : TrafficLight
    {
        public new void addTrafficLight(int width, int height, int leftX, int topY, int flipped, int trafficLightStatus, string nameT)
        {
            trafficLightPB = new PictureBox();
            trafficLightPB.Image = Properties.Resources.bus_stop;
            trafficLightPB.BackColor = Color.Transparent;
            trafficLightPB.SizeMode = PictureBoxSizeMode.StretchImage;
            trafficLightPB.Width = width;
            trafficLightPB.Height = height;
            trafficLightPB.Left = leftX;
            trafficLightPB.Top = topY;
            this.flipped = flipped;
            this.trafficLightStatus = trafficLightStatus;
            this.nameT = nameT;

            flipFunction(flipped);
        }
    }
}
