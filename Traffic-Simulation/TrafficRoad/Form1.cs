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
        List<Road> roads = new List<Road>();
        private mySocket aSocket = new mySocket();
        private jsonTL json = new jsonTL();

        public Form1()
        {
            InitializeComponent();
            //aSocket.Main1();

            //carlane 1
            //addRoad(20, 170, 600, 0, "down");
            //addCar(603, 20, roads[0]);
            //carlane 2
            //addRoad(20, 170, 620, 0, "down");
            //addCar(623, 20, roads[0]);
            //carlane 3
            addRoad(20, 170, 640, 0, "down"); // index 0
            spawnCar(643, 20, "down", roads[0]);
            addRoad(264, 18, 640, 320, "right"); // index 1

            //north west traffic lights
            addTrafficLight(16, 7, 274, 175, 270, 0);
            addTrafficLight(16, 7, 274, 194, 270, 0);
            addTrafficLight(16, 7, 274, 212, 270, 0);
            addTrafficLight(16, 7, 274, 231, 270, 0);

            //west traffic lights
            addTrafficLight(16, 7, 107, 306, 90, 0);
            addTrafficLight(16, 7, 107, 326, 90, 0);
            addTrafficLight(16, 7, 107, 344, 90, 0);
            addTrafficLight(16, 7, 107, 363, 90, 0);

            //southern traffic lights
            addTrafficLight(7, 16, 231, 416, 0, 1);
            addTrafficLight(7, 16, 250, 416, 0, 1);
            addTrafficLight(7, 16, 269, 416, 0, 1);
            addTrafficLight(7, 16, 288, 416, 0, 1);

            //south east traffic lights
            addTrafficLight(16, 7, 614, 269, 90, 1);
            addTrafficLight(16, 7, 614, 288, 90, 1);
            addTrafficLight(16, 7, 614, 307, 90, 1);
            addTrafficLight(16, 7, 614, 326, 90, 1);

            //north east traffic lights
            addTrafficLight(16, 7, 779, 138, 270, 1);
            addTrafficLight(16, 7, 779, 157, 270, 1);
            addTrafficLight(16, 7, 779, 176, 270, 1);
            addTrafficLight(16, 7, 779, 195, 270, 1);

            //northern single traffic light
            addTrafficLight(7, 16, 607, 75, 180, 1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckTrafficLightstatus();

            //Console.WriteLine(traffic[0].direction);
            //Console.WriteLine(roads[0].leftX);

            foreach (Traffic t in traffic)
            {
                t.movement(5);
                //Console.WriteLine(t.direction);
            }

        }

        private void addRoad(int width, int height, int leftX, int topY, string direction)
        {
            Road road = new Road();

            road.addRoad(width, height, leftX, topY, direction);

            roads.Add(road);

            //this.Controls.Add(road.roadPB);
        }

        private void spawnCar(int leftX, int topY, string direction, Road road)
        {
            Car car = new Car();

            car.spawnTraffic(leftX, topY, direction, road);

            traffic.Add(car);

            this.Controls.Add(car.trafficPB);
        }
        private TrafficLights addTrafficLight(int width, int height, int leftX, int topY, int flipped, int trafficLightStatus)
        {
            TrafficLights trafficLights = new TrafficLights(0, 0, 0, 0, 0, 0);

            trafficLights.InitTrafficLights(width, height, leftX, topY, flipped, trafficLightStatus);

            this.Controls.Add(trafficLights.trafficLightsPB);

            return trafficLights;
        }

        private static void CheckTrafficLightstatus()
        {
            var instance = new TrafficLights(0, 0, 0, 0, 0, 0);
            instance.checkTrafficLightStatus();
        }

    }

}
