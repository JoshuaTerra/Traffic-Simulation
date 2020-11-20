using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficRoad
{
    class Path
    {
        public List<Point> points = new List<Point>();

        public void addPoint(int leftX, int topY, TrafficLight tl = null)
        {
            Point point = new Point(leftX, topY, tl);

            points.Add(point);
        
        }
    }
}
