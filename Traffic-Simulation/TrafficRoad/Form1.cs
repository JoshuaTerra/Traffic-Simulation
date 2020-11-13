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
        public System.Timers.Timer aTimer = new System.Timers.Timer();
        public Random random = new Random();
        jsonTL json1 = new jsonTL();
        public int testint = 1;

        public Form1()
        {
            InitializeComponent();
            //aSocket.Main1();

            // adding roads north
            addRoad(19, 98, 603, -10, "down"); // index 0
            addRoad(19, 98, 622, -10, "down"); // index 1
            addRoad(19, 98, 641, -10, "down"); // index 2

            // adding roads east
            addRoad(131, 19, 901, 133, "left"); // index 3
            addRoad(131, 19, 901, 152, "left"); // index 4
            addRoad(131, 19, 901, 171, "left"); // index 5
            addRoad(131, 19, 901, 190, "left"); // index 6

            // adding roads south
            addRoad(19, 98, 228, 507, "up");  // index 7
            addRoad(19, 98, 247, 507, "up");  // index 8
            addRoad(19, 98, 265, 507, "up"); // index 9
            addRoad(19, 98, 284, 507, "up"); // index 10

            // adding roads west
            addRoad(132, 19, -10, 302, "right"); // index 11
            addRoad(132, 19, -10, 321, "right"); // index 12
            addRoad(132, 19, -10, 340, "right"); // index 13
            addRoad(132, 19, -10, 359, "right"); // index 14

            // adding alternative roads for turning points
            addRoad(19, 170, 701, 0, "up"); // index 15
            addRoad(19, 170, 720, 0, "up"); // index 16
            addRoad(19, 169, 168, 338, "down"); // index 17
            addRoad(19, 169, 188, 338, "down"); // index 18

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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (Traffic t in traffic)
            {
                bool stop = t.collisionDetection(traffic);
                if (stop)
                {
                    t.movement(0);
                }
                else
                {
                    t.movement(5);
                }
            }

            int rnd = random.Next(10);
            if (rnd == 1)
            {
                spawnCar();
            }

            for (int i = 0; i < 1; i++)
            {
                if (json1.A11 == 1)
                {
                    trafficLights[20].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[20].trafficLightStatus = 0;
                }

                if (json1.A12 == 1)
                {
                    trafficLights[21].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[21].trafficLightStatus = 0;
                }

                if (json1.A13 == 1)
                {
                    trafficLights[22].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[22].trafficLightStatus = 0;
                }

                if (json1.A21 == 1)
                {
                    trafficLights[19].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[19].trafficLightStatus = 0;
                }

                if (json1.A22 == 1)
                {
                    trafficLights[18].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[18].trafficLightStatus = 0;
                }

                if (json1.A23 == 1)
                {
                    trafficLights[17].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[17].trafficLightStatus = 0;
                }

                if (json1.A24 == 1)
                {
                    trafficLights[16].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[16].trafficLightStatus = 0;
                }

                if (json1.A31 == 1)
                {
                    trafficLights[12].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[12].trafficLightStatus = 0;
                }

                if (json1.A32 == 1)
                {
                    trafficLights[13].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[13].trafficLightStatus = 0;
                }

                if (json1.A33 == 1)
                {
                    trafficLights[14].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[14].trafficLightStatus = 0;
                }

                if (json1.A34 == 1)
                {
                    trafficLights[15].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[15].trafficLightStatus = 0;
                }

                if (json1.A41 == 1)
                {
                    trafficLights[8].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[8].trafficLightStatus = 0;
                }

                if (json1.A42 == 1)
                {
                    trafficLights[9].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[9].trafficLightStatus = 0;
                }

                if (json1.A43 == 1)
                {
                    trafficLights[10].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[10].trafficLightStatus = 0;
                }

                if (json1.A44 == 1)
                {
                    trafficLights[11].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[11].trafficLightStatus = 0;
                }

                if (json1.A51 == 1)
                {
                    trafficLights[4].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[4].trafficLightStatus = 0;
                }

                if (json1.A52 == 1)
                {
                    trafficLights[5].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[5].trafficLightStatus = 0;
                }

                if (json1.A53 == 1)
                {
                    trafficLights[6].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[6].trafficLightStatus = 0;
                }

                if (json1.A54 == 1)
                {
                    trafficLights[7].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[7].trafficLightStatus = 0;
                }

                if (json1.A61 == 1)
                {
                    trafficLights[0].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[0].trafficLightStatus = 0;
                }

                if (json1.A62 == 1)
                {
                    trafficLights[1].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[1].trafficLightStatus = 0;
                }

                if (json1.A63 == 1)
                {
                    trafficLights[2].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[2].trafficLightStatus = 0;
                }

                if (json1.A64 == 1)
                {
                    trafficLights[3].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[3].trafficLightStatus = 0;
                }
            }

            foreach (TrafficLights t in trafficLights)
            {
                t.checkTrafficLightStatus();
            }
        }

        private void addRoad(int width, int height, int leftX, int topY, string direction)
        {
            Road road = new Road();

            road.addRoad(width, height, leftX, topY, direction);

            roads.Add(road);
        }

        private void spawnCar()
        {
            Random random = new Random();

            int rnd = random.Next(roads.Count() - 4);

            Car car = new Car();

            int laneNumber = rnd; 

            switch (laneNumber)
            {
                case 0:
                    laneNumber = 5;
                    break;
                case 1:
                    laneNumber = 6;
                    break;
                case 2:
                    laneNumber = 12;
                    break;
                case 3:
                    laneNumber = 16; 
                    break;
                case 4:
                    laneNumber = 15; 
                    break;
                case 5:
                    laneNumber = 5;
                    break;
                case 6:
                    laneNumber = 5;
                    break;
                case 7:
                    laneNumber = 6;
                    break;
                case 8:
                    laneNumber = 5;
                    break;
                case 9:
                    laneNumber = 11;
                    break;
                case 10:
                    laneNumber = 12;
                    break;
                case 11:
                    laneNumber = 11;
                    break;
                case 12:
                    laneNumber = 12;
                    break;
                case 13:
                    laneNumber = 18; 
                    break;
                case 14:
                    laneNumber = 17; 
                    break;
            }

            car.spawnTraffic(roads[rnd].leftX, roads[rnd].topY, roads[rnd].direction, roads[laneNumber]);

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

    }

}
