using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficRoad
{
    class Point
    {
        private int leftX;
        private int topY;
        private string direction;
        private TrafficLight tl = null;

        public Point(int leftX, int topY, string direction, TrafficLight tl = null)
        {
            this.leftX = leftX;
            this.topY = topY;
            this.direction = direction;
            this.tl = tl;
        }

        public int Left { get => leftX; set => leftX = value; }
        public int Top { get => topY; set => topY = value; }
        public string Direction { get => direction; set => direction = value; }
        public TrafficLight Tl { get => tl; set => tl = value; }
    }
}