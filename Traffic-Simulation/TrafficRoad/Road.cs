using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TrafficRoad
{
    public class Road
    {
        public int width;
        public int height;
        public int leftX;
        public int topY;
        public string direction;
        public string name;
        public TrafficLight tl;

        public void addRoad(int width, int height, int leftX, int topY, string direction, string name,TrafficLight tl)
        {
            this.direction = direction;
            this.width = width;
            this.height = height;
            this.leftX = leftX;
            this.topY = topY;
            this.name = name;
            this.tl = tl;
        }
    }
}
