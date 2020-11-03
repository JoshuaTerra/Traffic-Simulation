using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficRoad
{
    

    class TrafficLights : Traffic
    {
 
        public void InitTrafficLights(int xposition, int yposition)
        {
            tl = new PictureBox();

            tl.Image = Properties.Resources.light_stop;

            tl.Location = new Point(xposition, yposition);

            tl.Size = new Size(7, 16);

            tl.BackColor = Color.Transparent;

            tl.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
