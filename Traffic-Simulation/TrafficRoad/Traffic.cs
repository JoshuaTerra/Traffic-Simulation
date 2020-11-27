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
        public int prevRotation = 0;
        public int index = 0;
        public string direction;
        public bool stop;
        public Path path;

        public int height;
        public int width;

        public void spawnTraffic(int leftX, int topY, int width, int height, Path path)
        {
            trafficPB = new PictureBox();
            trafficPB.Image = null;
            trafficPB.BackColor = Color.Transparent;
            trafficPB.Size = new Size(height, width);
            trafficPB.Left = leftX;
            trafficPB.Top = topY;
            this.path = path;
            this.width = width;
            this.height = height;
        }

        public void movement(int speed)
        {
            float x1 = trafficPB.Left;
            float y1 = trafficPB.Top;
            float x2 = path.points[index].Left;
            float y2 = path.points[index].Top;

            float moveX = path.points[index].Left - trafficPB.Left;
            float moveY = path.points[index].Top - trafficPB.Top;

            double distance = Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));

            if (distance > speed && !stop)
            {
                flip(trafficPB.Left, trafficPB.Top);
                trafficPB.Left = (int)(trafficPB.Left + moveX / distance * speed);
                trafficPB.Top = (int)(trafficPB.Top + moveY / distance * speed);
            }
            else if (index < (path.points.Count - 1))
            {
                index++;
            }

            deleteTraffic();
        }

        // this function takes care of flipping all the traffic images
        public void flip(int leftX, int topY)
        {
            if (leftX > path.points[index].Left)
            {
                direction = "west";
                trafficPB.Size = new Size(height, width);
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
            else if (topY < path.points[index].Top)
            {
                direction = "south";
                trafficPB.Size = new Size(width, height);
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
            else if (leftX < path.points[index].Left)
            {
                direction = "east";
                trafficPB.Size = new Size(height, width);
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
            else if (topY > path.points[index].Top)
            {
                direction = "north";
                trafficPB.Size = new Size(width, height);
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
                trafficPB.Size = new Size(0, 0);
            }
            else if (trafficPB.Location.Y < -20 || trafficPB.Location.Y > 527)
            {
                trafficPB.Size = new Size(0, 0);
            }
        }

        // collision detection function
        public bool collisionDetection(List<Traffic> traffic)
        {
            string direction = path.points[index].Direction;

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
            if (path.points[index].Tl != null)
            {
                if (rectangle.IntersectsWith(path.points[index].Tl.trafficLightPB.Bounds) && path.points[index].Tl.trafficLightStatus == 0)
                {
                    stop = true;
                }
            }

            // if the collisionbox infront of the car intersects with another car it stops
            foreach (Traffic t in trafficList)
            {
                try
                {
                    if (rectangle.IntersectsWith(t.trafficPB.Bounds) && t.path.points[index].Direction == direction)
                    {
                        return true;
                    }
                }
                catch 
                {
                    
                }

            }
            return false;
        }
    }
}
