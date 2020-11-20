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
        //protected Road road = null;
        protected string direction;
        private bool isFlipped = false;
        public int prevRotation = 0;
        public bool stop = false;

        protected Path path = null;

        public void spawnTraffic(int leftX, int topY, Path path)
        {
            trafficPB = new PictureBox();
            trafficPB.Image = null;
            trafficPB.BackColor = Color.Transparent;
            trafficPB.Size = new Size(15, 30);
            trafficPB.Left = leftX;
            trafficPB.Top = topY;
            this.path = path;
        }

        public void movement(int speed)
        {
            flip();
            deleteTraffic();

            trafficPB.Left += 0 * speed;
            trafficPB.Top += 1 * speed;
            trafficPB.Size = new Size(15, 30);

            // if statement to set the right direction of the car when getting onto another lane (road)
            //if (road.name == "A11" && trafficPB.Top >= 170)
            //{
            //    direction = "west";
            //}
            //else if (road.name == "A12" && trafficPB.Top >= 189)
            //{
            //    direction = "west";
            //}
            //else if (road.name == "A13" && trafficPB.Top >= 319)
            //{
            //    direction = "east";
            //}
            //else if (road.name == "A21" && trafficPB.Left <= 716)
            //{
            //    direction = "north";
            //}
            //else if (road.name == "A22" && trafficPB.Left <= 696)
            //{
            //    direction = "north";
            //}
            //else if (road.name == "A41" && trafficPB.Top <= 192)
            //{
            //    direction = "west";
            //}
            //else if (road.name == "A42" && trafficPB.Top <= 173)
            //{
            //    direction = "west";
            //}
            //else if (road.name == "A43" && trafficPB.Top <= 302)
            //{
            //    direction = "east";
            //}
            //else if (road.name == "A44" && trafficPB.Top <= 323)
            //{
            //    direction = "east";
            //}
            //else if (road.name == "A53" && trafficPB.Left >= 190)
            //{
            //    direction = "south";
            //}
            //else if (road.name == "A54" && trafficPB.Left >= 170)
            //{
            //    direction = "south";
            //}

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
        public bool collisionDetection(List<Traffic> traffic)
        {
            // creating new list with all the current traffic 
            List<Traffic> trafficList = traffic;

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

            //stops the traffic infront of the trafficlights if light is red
            //if (path.points[0].Tl != null)
            //{
            //    if (rectangle.IntersectsWith(path.points[0].trafficLightPB.Bounds) && path.points[0].trafficLightStatus == 0)
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
