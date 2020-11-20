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
        public void checkTrafficLightStatus()
        {
            if (trafficLightStatus == 0)
            {
                trafficLightPB.Image = Properties.Resources.bus_stop;
            }
            else if (trafficLightStatus == 1)
            {
                trafficLightPB.Image = Properties.Resources.bus_right_go;
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
