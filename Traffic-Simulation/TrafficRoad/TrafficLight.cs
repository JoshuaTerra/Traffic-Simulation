using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficRoad
{
    public class TrafficLight
    {
        public int flipped = 0;
        public int trafficLightStatus;
        public PictureBox trafficLightPB;

        public void addTrafficLight(int width, int height, int leftX, int topY, int flipped, int trafficLightStatus)
        {
            trafficLightPB = new PictureBox();
            trafficLightPB.Image = Properties.Resources.light_stop;
            trafficLightPB.BackColor = Color.Transparent;
            trafficLightPB.SizeMode = PictureBoxSizeMode.StretchImage;
            trafficLightPB.Width = width;
            trafficLightPB.Height = height;
            trafficLightPB.Left = leftX;
            trafficLightPB.Top = topY;
            this.flipped = flipped;
            this.trafficLightStatus = trafficLightStatus;

            if (flipped == 90)
            {
                trafficLightPB.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (flipped == 180)
            {
                trafficLightPB.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            else if (flipped == 270)
            {
                trafficLightPB.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
        }

        public void checkTrafficLightStatus()
        {
            if (trafficLightStatus == 0)
            {
                trafficLightPB.Image = Properties.Resources.light_stop;
            }
            else if (trafficLightStatus == 1)
            {
                trafficLightPB.Image = Properties.Resources.light_go;
            }

            if (flipped == 90)
            {
                trafficLightPB.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (flipped == 180)
            {
                trafficLightPB.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            else if (flipped == 270)
            {
                trafficLightPB.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }   
        }
    }
}
