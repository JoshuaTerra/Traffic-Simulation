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

            //north west traffic lights
            addTrafficLight(16, 7, 274, 175, 270);
            addTrafficLight(16, 7, 274, 194, 270);
            addTrafficLight(16, 7, 274, 212, 270);
            addTrafficLight(16, 7, 274, 231, 270);

            //west traffic lights
            addTrafficLight(16, 7, 107, 306, 90);
            addTrafficLight(16, 7, 107, 326, 90);
            addTrafficLight(16, 7, 107, 344, 90);
            addTrafficLight(16, 7, 107, 363, 90);

            //southern traffic lights
            addTrafficLight(7, 16, 231, 416, 0);
            addTrafficLight(7, 16, 250, 416, 0);
            addTrafficLight(7, 16, 269, 416, 0);
            addTrafficLight(7, 16, 288, 416, 0);

            //south east traffic lights
            addTrafficLight(16, 7, 614, 269, 90);
            addTrafficLight(16, 7, 614, 288, 90);
            addTrafficLight(16, 7, 614, 307, 90);
            addTrafficLight(16, 7, 614, 326, 90);

            //north east traffic lights
            addTrafficLight(16, 7, 779, 138, 270);
            addTrafficLight(16, 7, 779, 157, 270);
            addTrafficLight(16, 7, 779, 176, 270);
            addTrafficLight(16, 7, 779, 195, 270);

            //northern single traffic light
            addTrafficLight(7, 16, 607, 75, 180);
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
        private TrafficLights addTrafficLight(int width, int height, int leftX, int topY, int flipped)
        {
            TrafficLights trafficLights = new TrafficLights(0, 0, 0, 0, 0);

            trafficLights.InitTrafficLights(width, height, leftX, topY, flipped);

            this.Controls.Add(trafficLights.trafficLightsPB);

            return trafficLights;
        }

    }

}
