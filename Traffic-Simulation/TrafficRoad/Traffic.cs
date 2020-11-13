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
        public bool stop = false;

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
            if (carY + 2 >= roadY && direction == "south")
            {
                direction = road.direction;
            }
            else if (carX - 2 >= roadX && direction == "east")
            {
                direction = road.direction;
            }
            else if (carY - 2 <= roadY && direction == "north")
            {
                direction = road.direction;
            }
            else if (carX + 2 <= roadX && direction == "west")
            {
                direction = road.direction;
            }

            // if statement that moves the picturebox in the right direction and flips the image
            if (direction == "east" && !stop)
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
            else if (direction == "south" && !stop)
            {
                trafficPB.Left += 0 * speed;
                trafficPB.Top += 1 * speed;
                trafficPB.Size = new Size(15, 30);
            }
            else if (direction == "west" && !stop)
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
            else if (direction == "north" && !stop)
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

        // this function takes care of flipping all the traffic images
        public void flip()
        {
            if (direction == "east")
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
            else if (direction == "south")
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
            else if (direction == "west")
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
            else if (direction == "north")
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

        // deletes the traffic if they get out of the boundaries
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

        // collision detection function
        public bool collisionDetection(List<Traffic> traffic, List<TrafficLight> lights)
        {
            // creating new list with all the current traffic 
            List<Traffic> trafficList = traffic;
            List<TrafficLight> lightsList = lights;

            // if the list is empty return false
            if (trafficList.Count == 0)
            {
                return false;
            }

            // These are the collisionboxes infront of the cars for each direction
            Rectangle rectangle = new Rectangle();
            if (direction == "north")
            {
                rectangle = new Rectangle(trafficPB.Left, trafficPB.Top - 15, trafficPB.Width, 15);
            }

            if (direction == "south")
            {
                rectangle = new Rectangle(trafficPB.Left, trafficPB.Top + trafficPB.Height, trafficPB.Width, 15);
            }

            if (direction == "east")
            {
                rectangle = new Rectangle(trafficPB.Left + trafficPB.Width, trafficPB.Top, 15, trafficPB.Height);
            }

            if (direction == "west")
            {
                rectangle = new Rectangle(trafficPB.Left - 15, trafficPB.Top, 15, trafficPB.Height);
            }

            foreach (TrafficLight tl in lightsList)
            {
                if (road.tl != null)
                {
                    if (rectangle.IntersectsWith(tl.trafficLightPB.Bounds) && road.tl.trafficLightStatus == 0)
                    {
                        stop = true;
                    }
                    else
                    {
                        stop = false;
                    }
                }
            }

            // stops the traffic infront of the trafficlights if light is red
            //if (road.tl != null)
            //{
            //    if (rectangle.IntersectsWith(road.tl.trafficLightPB.Bounds) && road.tl.trafficLightStatus == 0)
            //    {
            //        stop = true;
            //    }
            //    else
            //    {
            //        stop = false;
            //    }
            //}

            // if the collisionbox infront of the car intersects with another car it stops
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
