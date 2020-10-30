using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TrafficRoad
{
    public partial class Form1 : Form
    {
        List<Traffic> traffic = new List<Traffic>();
        private mySocket aSocket = new mySocket();
        private jsonTL json = new jsonTL();

        public Form1()
        {
            InitializeComponent();
            //aSocket.Main1();

            //carlane 1
            //addRoad(20, 170, 600, 0, "down");
            //carlane 2
            addRoad(20, 170, 620, 0, "down");
            //carlane 3
            addRoad(20, 170, 640, 0, "down");

            addCar(603, 20);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private Road addRoad(int width, int height, int leftX, int topY, string direction)
        {
            Road road = new Road(0, 0, 0, 0, "");

            road.addRoad(width, height, leftX, topY, direction);

            this.Controls.Add(road.roadPB);

            return road;
        }

        private Car addCar(int leftX, int topY)
        {
            Car car = new Car();

            car.addCar(leftX, topY);
            
            this.Controls.Add(car.trafficPB);

            return car;
        }

    }

}
