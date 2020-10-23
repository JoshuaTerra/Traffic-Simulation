using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficRoad
{
    public partial class TrafficLight : Form
    {
        public int count = 1;
        public int a;
        public Boolean isFlipped = false;
        public int trafficLightStatus;
        public System.Timers.Timer aTimer = new System.Timers.Timer();
        public int orange = 1;
        public TrafficLight()
        {
            InitializeComponent();
            a = 1;
            pictureBox4.Visible = true;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Location.Y == 111) //trafficlight point.
            {
                if (trafficLightStatus == 0)
                {
                    pictureBox3.Top += 0;
                    pictureBox3.Left += 0;
                }

                else if (trafficLightStatus == 1)
                {
                    pictureBox3.Left -= 0;
                    pictureBox3.Top += 1;
                }
            }

            else
            {
                pictureBox3.Top += 1;
            }

            if (pictureBox3.Location.Y > 183) //turning point
            {
                pictureBox3.Width = 39;
                pictureBox3.Height = 23;
                pictureBox3.Left -= 1; //sets left to -1 so it goes left
                pictureBox3.Top -= 1; //sets top back to 0


                if (!isFlipped)
                {
                    Image img = pictureBox3.Image;
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    pictureBox3.Image = img;
                    isFlipped = true;
                }
            }

            if (trafficLightStatus == 0)
            {
                if (orange == 1)
                {

                    pictureBox4.Visible = false;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = false;
                    await Task.Delay(4000);
                    orange = 0;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = false;
                    pictureBox6.Visible = false;
                }

            }
            else if (trafficLightStatus == 1)
            {

                orange = 1;
                pictureBox6.Visible = true;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            count = count - 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TrafficLight_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trafficLightStatus == 0)
            {
                trafficLightStatus = 1;
            }

            else
            {
                trafficLightStatus = 0; 
            }
            
        }
    }
}
