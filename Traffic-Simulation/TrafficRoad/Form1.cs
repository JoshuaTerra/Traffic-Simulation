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
        List<TrafficLights> trafficLights = new List<TrafficLights>();
        private mySocket aSocket = new mySocket();
        private jsonTL json = new jsonTL();

        public Form1()
        {
            InitializeComponent();
            //aSocket.Main1();

            // adding roads north
            addRoad(19, 98, 601, 0, "down");
            addRoad(19, 98, 620, 0, "down");
            addRoad(19, 98, 639, 0, "down");

            // adding roads east
            addRoad(131, 19, 771, 131, "left");
            addRoad(131, 19, 771, 150, "left");
            addRoad(131, 19, 771, 169, "left");
            addRoad(131, 19, 771, 188, "left");

            // adding roads south
            addRoad(19, 98, 226, 409, "up");
            addRoad(19, 98, 245, 409, "up");
            addRoad(19, 98, 263, 409, "up");
            addRoad(19, 98, 282, 409, "up");

            // adding roads west
            addRoad(132, 19, 0, 300, "right");
            addRoad(132, 19, 0, 319, "right");
            addRoad(132, 19, 0, 338, "right");
            addRoad(132, 19, 0, 357, "right");

            // spawn car
            spawnCar(643, 20, "down", roads[12]);

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
            addTrafficLight(7, 16, 626, 75, 180, 1);
            addTrafficLight(7, 16, 645, 75, 180, 1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
=======
            CheckTrafficLightstatus();
>>>>>>> Stashed changes
            //CheckTrafficLightstatus();
            Console.WriteLine(trafficLights.Count);
            Console.WriteLine(roads.Count);
            //Console.WriteLine(traffic[0].direction);
            //Console.WriteLine(roads[0].leftX);


            foreach (Traffic t in traffic)
            {
                t.movement(5);
            }

        }

        private void addRoad(int width, int height, int leftX, int topY, string direction)
        {
            Road road = new Road();

            road.addRoad(width, height, leftX, topY, direction);

            roads.Add(road);
        }

        private void spawnCar(int leftX, int topY, string direction, Road road)
        {
            Car car = new Car();

            car.spawnTraffic(leftX, topY, direction, road);

            traffic.Add(car);

            this.Controls.Add(car.trafficPB);
        }
        private void addTrafficLight(int width, int height, int leftX, int topY, int flipped, int trafficLightStatus)
        {
            TrafficLights trafficLight = new TrafficLights();

            trafficLight.InitTrafficLights(width, height, leftX, topY, flipped, trafficLightStatus);

            trafficLights.Add(trafficLight);

            this.Controls.Add(trafficLight.trafficLightsPB);

        }

        private static void CheckTrafficLightstatus()
        {
            var instance = new TrafficLights();
            instance.checkTrafficLightStatus();
        }

    }

}
