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
        public int flipped;
        public int trafficLightStatus = 0;
        public PictureBox trafficLightsPB;

        public TrafficLights(int width, int height, int leftX, int topY, int flipped, int trafficLightStatus)
        {
            this.width = width;

            this.height = height;

            this.leftX = leftX;

            this.topY = topY;

            this.flipped = flipped;

            this.trafficLightStatus = trafficLightStatus;

            trafficLightsPB = new PictureBox();
        }

        public void InitTrafficLights(int width, int height, int leftX, int topY, int flipped, int trafficLightStatus)
        {
            trafficLightsPB = new PictureBox();

            trafficLightsPB.Image = Properties.Resources.light_stop;

            trafficLightsPB.BackColor = Color.Transparent;

            trafficLightsPB.SizeMode = PictureBoxSizeMode.StretchImage;

            trafficLightsPB.Width = width;

            trafficLightsPB.Height = height;

            trafficLightsPB.Left = leftX;

            trafficLightsPB.Top = topY;

            if (flipped == 90)
            {
                trafficLightsPB.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            else if (flipped == 180)
            {
                trafficLightsPB.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }

            else if (flipped == 270)
            {
                trafficLightsPB.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
        }

        public void checkTrafficLightStatus()
        {
            for (int i = 0; i < trafficLights.Count; i++)
            {
                if (trafficLights[i].trafficLightStatus == 0)
                {
                    trafficLights[i].trafficLightsPB.Image = Properties.Resources.light_stop;
                }

                else if (trafficLights[i].trafficLightStatus == 1)
                {
                    trafficLights[i].trafficLightsPB.Image = Properties.Resources.light_go;
                }
            }
        }
    }
}
