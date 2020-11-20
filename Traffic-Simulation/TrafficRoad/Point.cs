﻿using System;
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
        private TrafficLight tl = null;

        public Point(int leftX, int topY, TrafficLight tl = null)
        {
            this.leftX = leftX;
            this.topY = topY;
            this.tl = tl;
        }
    }
}
