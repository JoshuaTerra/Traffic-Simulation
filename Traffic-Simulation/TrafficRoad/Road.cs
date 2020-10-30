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
        public List<Road> roads = new List<Road>();
        public int width = 0;
        public int height = 0;
        public int leftX = 0;
        public int topY = 0;
        public string direction = "";
        public PictureBox roadPB;

        public Road(int width, int height, int leftX, int topY, string direction)
        {
            this.width = width;
            this.height = height;
            this.leftX = leftX;
            this.topY = topY;
            this.direction = direction;

            roadPB = new PictureBox();
        }

        public void addRoad(int width, int height, int leftX, int topY, string direction)
        {
            roadPB.BackColor = Color.Red;
            roadPB.Width = width;
            roadPB.Height = height;
            roadPB.Left = leftX;
            roadPB.Top = topY;
        }
    }
}
