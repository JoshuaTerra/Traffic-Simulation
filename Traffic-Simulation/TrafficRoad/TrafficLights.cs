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
        public int width = 0;
        public int height = 0;
        public int leftX = 0;
        public int topY = 0;
        public int flipped;
        public int trafficLightStatus = 0;
        public PictureBox trafficLightsPB;

        public void InitTrafficLights(int width, int height, int leftX, int topY, int flipped, int trafficLightStatus)
        {
            this.trafficLightsPB = new PictureBox();

            this.trafficLightsPB.Image = Properties.Resources.light_stop;

            this.trafficLightsPB.BackColor = Color.Transparent;

            this.trafficLightsPB.SizeMode = PictureBoxSizeMode.StretchImage;

            this.trafficLightsPB.Width = width;

            this.trafficLightsPB.Height = height;

            this.trafficLightsPB.Left = leftX;

            this.trafficLightsPB.Top = topY;

            if (flipped == 90)
            {
                this.trafficLightsPB.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            else if (flipped == 180)
            {
                this.trafficLightsPB.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }

            else if (flipped == 270)
            {
                this.trafficLightsPB.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
        }

        public void checkTrafficLightStatus()
        {
            /*for (int i = 0; i < trafficLights.Count; i++)
            {
                if (trafficLights[i].trafficLightStatus == 0)
                {
                    trafficLights[i].trafficLightsPB.Image = Properties.Resources.light_stop;
                }

                else if (trafficLights[i].trafficLightStatus == 1)
                {
                    trafficLights[i].trafficLightsPB.Image = Properties.Resources.light_go;
                }
            }*/
        }
    }
}
