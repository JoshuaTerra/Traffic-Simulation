using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TrafficRoad
{
    class Traffic
    {
        public PictureBox trafficPB;

        protected Road road = null;

        public string direction = "";

        protected int width = 15;
        protected int height = 30;

        public void spawnTraffic(int leftX, int topY, string direction, Road road)
        {
            trafficPB = new PictureBox();

            trafficPB.Image = Properties.Resources.ferrari;

            trafficPB.BackColor = Color.Transparent;

            trafficPB.SizeMode = PictureBoxSizeMode.StretchImage;

            trafficPB.Size = new Size(15, 30);

            trafficPB.Left = leftX;

            trafficPB.Top = topY;

            this.direction = direction;

            this.road = road;
        }

        public void movement(int speed)
        {
            int roadX = road.leftX;
            int roadY = road.topY;

            int carX = trafficPB.Location.X;
            int carY = trafficPB.Location.Y;

            Console.WriteLine("roadX: " + roadX);
            Console.WriteLine("roadY: " + roadY);

            Console.WriteLine("carX: " + carX);
            Console.WriteLine("carY: " + carY);

            if(carY == roadY)
            {
                this.direction = road.direction;
            }


            if (this.direction == "right")
            {
                trafficPB.Left += 1 * speed;
                trafficPB.Top += 0 * speed;
            }

            if (this.direction == "down")
            {
                trafficPB.Left += 0 * speed;
                trafficPB.Top += 1 * speed;
            }
        }

        public int getLocationTop()
        {
            return trafficPB.Top;
        }
    }
}
