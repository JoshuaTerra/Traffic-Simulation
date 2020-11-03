using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficRoad
{
    

    class TrafficLights
    {
        public List<TrafficLights> trafficLights = new List<TrafficLights>();
        public int width = 0;
        public int height = 0;
        public int leftX = 0;
        public int topY = 0;
        public string direction = "";
        public PictureBox trafficLightsPB;

        public TrafficLights(int width, int height, int leftX, int topY, string direction)
        {
            this.width = width;

            this.height = height;

            this.leftX = leftX;

            this.topY = topY;

            this.direction = direction;

            trafficLightsPB = new PictureBox();
        }

        public void InitTrafficLights(int width, int height, int leftX, int topY, string direction)
        {
            trafficLightsPB = new PictureBox();

            trafficLightsPB.Image = Properties.Resources.light_stop;

            trafficLightsPB.BackColor = Color.Transparent;

            trafficLightsPB.SizeMode = PictureBoxSizeMode.StretchImage;

            trafficLightsPB.Width = width;

            trafficLightsPB.Height = height;

            trafficLightsPB.Left = leftX;

            trafficLightsPB.Top = topY;

        }
    }
}
