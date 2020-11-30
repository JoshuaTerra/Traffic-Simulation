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
        public string nameT;

        public void addTrafficLight(int width, int height, int leftX, int topY, int flipped, int trafficLightStatus, string nameT)
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
            this.nameT = nameT;

            flipFunction(flipped);
        }

        public void checkTrafficLightStatus()
        {
            if (trafficLightStatus == 0)
            {
                /*trafficLightPB.Image = Properties.Resources.light_slow;
                await Task.Delay(3000);*/
                trafficLightPB.Image = Properties.Resources.light_stop;
            }
            
            else if (trafficLightStatus == 1)
            {
                trafficLightPB.Image = Properties.Resources.light_go;
            }

            flipFunction(flipped);  
        }

        public void checkTrafficLightStatusBus()
        {
            if (trafficLightStatus == 0)
            {
                /*trafficLightPB.Image = Properties.Resources.light_slow;
                trafficLightPB.Update();
                await Task.Delay(3000);*/
                trafficLightPB.Image = Properties.Resources.bus_stop;
            }

            else if (trafficLightStatus == 1)
            {
                trafficLightPB.Image = Properties.Resources.bus_right_go;
            }

            flipFunction(flipped);
        }

        public void flipFunction(int flipped)
        {
            switch (flipped)
            {
                case 90:
                    trafficLightPB.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;

                case 180:
                    trafficLightPB.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;

                case 270:
                    trafficLightPB.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }
        }

    }
}
