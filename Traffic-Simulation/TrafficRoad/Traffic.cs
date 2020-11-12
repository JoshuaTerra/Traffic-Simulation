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
        protected string direction;
        private bool isFlipped = false;
        public int prevRotation = 0;

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
            flip();
            deleteTraffic();

            int roadX = road.leftX;
            int roadY = road.topY;
            int carX = trafficPB.Location.X;
            int carY = trafficPB.Location.Y;

            // if statement to set the right direction of the car when getting onto another lane (road)
            if (carY + 2 >= roadY && direction == "down")
            {
                direction = road.direction;
            }
            else if (carX - 2 >= roadX && direction == "right")
            {
                direction = road.direction;
            }
            else if (carY - 2 <= roadY && direction == "up")
            {
                direction = road.direction;
            }
            else if (carX + 2 <= roadX && direction == "left")
            {
                direction = road.direction;
            }

            // if statement that moves the picturebox in the right direction and flips the image
            if (direction == "right")
            {
                trafficPB.Left += 1 * speed;
                trafficPB.Top += 0 * speed;
                if (!isFlipped)
                {
                    flip();
                    isFlipped = true;
                }
                trafficPB.Size = new Size(30, 15);
            }
            else if (direction == "down")
            {
                trafficPB.Left += 0 * speed;
                trafficPB.Top += 1 * speed;
                trafficPB.Size = new Size(15, 30);
            }
            else if (direction == "left")
            {
                trafficPB.Left -= 1 * speed;
                trafficPB.Top += 0 * speed;
                if (!isFlipped)
                {
                    flip();
                    isFlipped = true;
                }
                trafficPB.Size = new Size(30, 15);
            }
            else if (direction == "up")
            {
                trafficPB.Left += 0 * speed;
                trafficPB.Top -= 1 * speed;
                if (!isFlipped)
                {
                    flip();
                    isFlipped = true;
                }
                trafficPB.Size = new Size(15, 30);
            }
        }

        public void flip()
        {
            if (direction == "right")
            {
                if (prevRotation == 0)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    prevRotation = 90;
                }
                if (prevRotation == 90)
                {
                    prevRotation = 90;
                }
                if (prevRotation == 180)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    prevRotation = 90;
                }
                if (prevRotation == 270)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    prevRotation = 90;
                }
            }
            else if (direction == "down")
            {
                if (prevRotation == 0)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    prevRotation = 180;
                }
                if (prevRotation == 90)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    prevRotation = 180;
                }
                if (prevRotation == 180)
                {
                    prevRotation = 180;
                }
                if (prevRotation == 270)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    prevRotation = 180;
                }
            }
            else if (direction == "left")
            {
                if (prevRotation == 0)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    prevRotation = 270;
                }
                if (prevRotation == 90)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    prevRotation = 270;
                }
                if (prevRotation == 180)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    prevRotation = 270;
                }
                if (prevRotation == 270)
                {
                    prevRotation = 270;
                }
            }
            else if (direction == "up")
            {
                if (prevRotation == 0)
                {
                    prevRotation = 0;
                }
                if (prevRotation == 90)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    prevRotation = 0;
                }
                if (prevRotation == 180)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    prevRotation = 0;
                }
                if (prevRotation == 270)
                {
                    trafficPB.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    prevRotation = 0;
                }
            }
        }

        public void deleteTraffic()
        {
            if (trafficPB.Location.X < -20 || trafficPB.Location.X > 922)
            {
                trafficPB.Dispose();
            }
            else if (trafficPB.Location.Y < -20 || trafficPB.Location.Y > 527)
            {
                trafficPB.Dispose();
            }
        }

        public bool collisionDetection(List<Traffic> traffic)
        {
            List<Traffic> trafficList = traffic;

            if (trafficList.Count == 0)
            {
                return false;
            }

            Rectangle rectangle = new Rectangle();
            if (direction == "up")
            {
                rectangle = new Rectangle(trafficPB.Left, trafficPB.Top - 15, trafficPB.Width, 15);
            }

            if (direction == "down")
            {
                rectangle = new Rectangle(trafficPB.Left, trafficPB.Top + trafficPB.Height, trafficPB.Width, 15);
            }

            if (direction == "right")
            {
                rectangle = new Rectangle(trafficPB.Left + trafficPB.Width, trafficPB.Top, 15, trafficPB.Height);
            }

            if (direction == "left")
            {
                rectangle = new Rectangle(trafficPB.Left - 15, trafficPB.Top, 15, trafficPB.Height);
            }

            foreach (Traffic t in trafficList)
            {
                if (rectangle.IntersectsWith(t.trafficPB.Bounds) && t.direction == direction)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
