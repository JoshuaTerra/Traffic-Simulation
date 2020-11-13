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
        List<TrafficLight> trafficLights = new List<TrafficLight>();
        //private mySocket aSocket = new mySocket();
        //private jsonTL json = new jsonTL();
        public System.Timers.Timer aTimer = new System.Timers.Timer();
        public Random random = new Random();
        jsonTL json1 = new jsonTL();
        public int testint = 1;

        public Form1()
        {
            InitializeComponent();
            //aSocket.Main1();

            // north west traffic lights
            TrafficLight tA61 = addTrafficLight(16, 7, 274, 175, 270, 0);
            TrafficLight tA62 = addTrafficLight(16, 7, 274, 194, 270, 0);
            TrafficLight tA63 = addTrafficLight(16, 7, 274, 212, 270, 0);
            TrafficLight tA64 = addTrafficLight(16, 7, 274, 231, 270, 0);

            // west traffic lights
            TrafficLight tA51 = addTrafficLight(16, 7, 107, 306, 90, 0);
            TrafficLight tA52 = addTrafficLight(16, 7, 107, 326, 90, 0);
            TrafficLight tA53 = addTrafficLight(16, 7, 107, 344, 90, 0);
            TrafficLight tA54 = addTrafficLight(16, 7, 107, 363, 90, 0);

            // southern traffic lights
            TrafficLight tA41 = addTrafficLight(7, 16, 231, 416, 0, 1);
            TrafficLight tA42 = addTrafficLight(7, 16, 250, 416, 0, 1);
            TrafficLight tA43 = addTrafficLight(7, 16, 269, 416, 0, 1);
            TrafficLight tA44 = addTrafficLight(7, 16, 288, 416, 0, 1);

            // south east traffic lights
            TrafficLight tA31 = addTrafficLight(16, 7, 614, 269, 90, 1);
            TrafficLight tA32 = addTrafficLight(16, 7, 614, 288, 90, 1);
            TrafficLight tA33 = addTrafficLight(16, 7, 614, 307, 90, 1);
            TrafficLight tA34 = addTrafficLight(16, 7, 614, 326, 90, 1);

            // north east traffic lights
            TrafficLight tA21 = addTrafficLight(16, 7, 779, 138, 270, 1);
            TrafficLight tA22 = addTrafficLight(16, 7, 779, 157, 270, 1);
            TrafficLight tA23 = addTrafficLight(16, 7, 779, 176, 270, 1);
            TrafficLight tA24 = addTrafficLight(16, 7, 779, 195, 270, 1);

            // northern single traffic light
            TrafficLight tA11 = addTrafficLight(7, 16, 607, 75, 180, 1);
            TrafficLight tA12 = addTrafficLight(7, 16, 626, 75, 180, 1);
            TrafficLight tA13 = addTrafficLight(7, 16, 645, 75, 180, 1);

            // adding roads north
            addRoad(19, 98, 603, -20, "south", tA11); // index 0
            addRoad(19, 98, 622, -20, "south", tA12); // index 1
            addRoad(19, 98, 641, -20, "south", tA13); // index 2

            // adding roads east
            addRoad(131, 19, 911, 133, "west", tA21); // index 3
            addRoad(131, 19, 911, 152, "west", tA22); // index 4
            addRoad(131, 19, 911, 171, "west", tA23); // index 5
            addRoad(131, 19, 911, 190, "west", tA24); // index 6

            // adding roads south
            addRoad(19, 98, 228, 517, "north", tA41);  // index 7
            addRoad(19, 98, 247, 517, "north", tA42);  // index 8
            addRoad(19, 98, 265, 517, "north", tA43); // index 9
            addRoad(19, 98, 284, 517, "north", tA44); // index 10

            // adding roads west
            addRoad(132, 19, -20, 302, "east", tA51); // index 11
            addRoad(132, 19, -20, 321, "east", tA52); // index 12
            addRoad(132, 19, -20, 340, "east", tA53); // index 13
            addRoad(132, 19, -20, 359, "east", tA54); // index 14

            // adding alternative roads for turning points
            addRoad(19, 170, 699, 0, "north", null); // index 15
            addRoad(19, 170, 721, 0, "north", null); // index 16
            addRoad(19, 169, 170, 338, "south", null); // index 17
            addRoad(19, 169, 188, 338, "south", null); // index 18

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
                bool stop = t.collisionDetection(traffic, trafficLights);
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
                if (testint == 1)
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

                if (testint == 1)
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

            foreach (TrafficLight t in trafficLights)
            {
                t.checkTrafficLightStatus();
            }
        }

        // function to add the roads into the simulation
        private void addRoad(int width, int height, int leftX, int topY, string direction, TrafficLight tl)
        {
            Road road = new Road();

            road.addRoad(width, height, leftX, topY, direction, tl);

            roads.Add(road);
        }

        // function to spawn cars into the simulation
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

            Controls.Add(car.trafficPB);
        }

        // function to add the trafficlights into the simulation
        private TrafficLight addTrafficLight(int width, int height, int leftX, int topY, int flipped, int trafficLightStatus)
        {
            TrafficLight trafficLight = new TrafficLight();

            trafficLight.addTrafficLight(width, height, leftX, topY, flipped, trafficLightStatus);

            trafficLights.Add(trafficLight);

            Controls.Add(trafficLight.trafficLightPB);

            return trafficLight;
        }

    }

}
