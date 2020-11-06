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
        public int flipped = 0;
        public int trafficLightStatus;
        public PictureBox trafficLightsPB;

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
            this.flipped = flipped;
            this.trafficLightStatus = trafficLightStatus;

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
            if (trafficLightStatus == 0)
            {
                trafficLightsPB.Image = Properties.Resources.light_stop;
            }
            else if (trafficLightStatus == 1)
            {
                trafficLightsPB.Image = Properties.Resources.light_go;
            }

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
    }
}
