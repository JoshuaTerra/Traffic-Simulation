﻿using System;
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
        List<BusLight> busLights = new List<BusLight>();
        //private mySocket aSocket = new mySocket();
        public Random random = new Random();
        jsonTL json = new jsonTL();
        public int testint = 1;

        public Form1()
        {
            InitializeComponent();
            //aSocket.Main1();

            // north west traffic lights
            TrafficLight tA61 = addTrafficLight(16, 7, 274, 175, 270, 0, "tA61");
            TrafficLight tA62 = addTrafficLight(16, 7, 274, 194, 270, 0, "tA62");
            TrafficLight tA63 = addTrafficLight(16, 7, 274, 212, 270, 0, "tA63");
            TrafficLight tA64 = addTrafficLight(16, 7, 274, 231, 270, 0, "tA64");

            // west traffic lights
            TrafficLight tA51 = addTrafficLight(16, 7, 107, 306, 90, 0, "tA51");
            TrafficLight tA52 = addTrafficLight(16, 7, 107, 326, 90, 0, "tA52");
            TrafficLight tA53 = addTrafficLight(16, 7, 107, 344, 90, 0, "tA53");
            TrafficLight tA54 = addTrafficLight(16, 7, 107, 363, 90, 0, "tA54");

            // southern traffic lights
            TrafficLight tA41 = addTrafficLight(7, 16, 231, 416, 0, 1, "tA41");
            TrafficLight tA42 = addTrafficLight(7, 16, 250, 416, 0, 1, "tA42");
            TrafficLight tA43 = addTrafficLight(7, 16, 269, 416, 0, 1, "tA43");
            TrafficLight tA44 = addTrafficLight(7, 16, 288, 416, 0, 1, "tA44");

            // south east traffic lights
            TrafficLight tA31 = addTrafficLight(16, 7, 614, 269, 90, 1, "tA31");
            TrafficLight tA32 = addTrafficLight(16, 7, 614, 288, 90, 1, "tA32");
            TrafficLight tA33 = addTrafficLight(16, 7, 614, 307, 90, 1, "tA33");
            TrafficLight tA34 = addTrafficLight(16, 7, 614, 326, 90, 1, "tA34");

            // north east traffic lights
            TrafficLight tA21 = addTrafficLight(16, 7, 779, 138, 270, 1, "tA21");
            TrafficLight tA22 = addTrafficLight(16, 7, 779, 157, 270, 1, "tA22");
            TrafficLight tA23 = addTrafficLight(16, 7, 779, 176, 270, 1, "tA23");
            TrafficLight tA24 = addTrafficLight(16, 7, 779, 195, 270, 1, "tA24");

            // northern single traffic light
            TrafficLight tA11 = addTrafficLight(7, 16, 607, 75, 180, 1, "tA11");
            TrafficLight tA12 = addTrafficLight(7, 16, 626, 75, 180, 1, "tA12");
            TrafficLight tA13 = addTrafficLight(7, 16, 645, 75, 180, 1, "tA13");

            //pedestrain lights
            TrafficLight pV51 = addTrafficLight(3, 8, 132, 160, 180, 1, "pV51");
            TrafficLight pV52 = addTrafficLight(3, 8, 132, 210, 0, 1, "pV52");
            TrafficLight pV53 = addTrafficLight(3, 8, 132, 290, 180, 1, "pV53");
            TrafficLight pV54 = addTrafficLight(3, 8, 132, 378, 0, 1, "pV54");

            TrafficLight pV41 = addTrafficLight(8, 3, 160, 406, 90, 1, "pV41");
            TrafficLight pV42 = addTrafficLight(8, 3, 208, 406, 270, 1, "pV42");
            TrafficLight pV43 = addTrafficLight(8, 3, 220, 406, 90, 1, "pV43");
            TrafficLight pV44 = addTrafficLight(8, 3, 322, 406, 270, 1, "pV44");

            TrafficLight pV24 = addTrafficLight(3, 8, 767, 340, 0, 1, "pV24");
            TrafficLight pV23 = addTrafficLight(3, 8, 767, 291, 180, 1, "pV23");
            TrafficLight pV22 = addTrafficLight(3, 8, 767, 210, 0, 1, "pV22");
            TrafficLight pV21 = addTrafficLight(3, 8, 767, 120, 180, 1, "pV21");

            TrafficLight pV14 = addTrafficLight(8, 3, 735, 99, 270, 1, "pV14");
            TrafficLight pV13 = addTrafficLight(8, 3, 688, 99, 90, 1, "pV13");
            TrafficLight pV12 = addTrafficLight(8, 3, 676, 99, 270, 1, "pV12");
            TrafficLight pV11 = addTrafficLight(8, 3, 590, 99, 90, 1, "pV11");

            //bike lights

            TrafficLight bF11 = addTrafficLight(8, 3, 590, 106, 90, 1, "bF11");
            TrafficLight bF12 = addTrafficLight(8, 3, 735, 106, 270, 1, "bF12");

            TrafficLight bF21 = addTrafficLight(3, 8, 759, 120, 180, 1, "bF21");
            TrafficLight bF22 = addTrafficLight(3, 8, 760, 340, 0, 1, "bF22");

            TrafficLight bF41 = addTrafficLight(8, 3, 160, 398, 90, 1, "bF41");
            TrafficLight bF44 = addTrafficLight(8, 3, 322, 398, 270, 1, "bF42");

            TrafficLight bF51 = addTrafficLight(3, 8, 140, 160, 180, 1, "bF51");
            TrafficLight bF52 = addTrafficLight(3, 8, 140, 378, 0, 1, "bF52");

            //bus lights
            BusLight bB11 = addBusLight(8, 8, 306, 425, 0, 1, "bB11");
            BusLight bB12 = addBusLight(8, 8, 659, 74, 0, 1, "bB12");
            BusLight bB41 = addBusLight(8, 8, 667, 74, 0, 1, "bB41");


            // adding roads north
            addRoad(19, 98, 603, -20, "south", "A11", tA11); // index 0
            addRoad(19, 98, 622, -20, "south", "A12", tA12); // index 1
            addRoad(19, 98, 641, -20, "south", "A13", tA13); // index 2

            // adding roads east
            addRoad(131, 19, 911, 133, "west", "A21", tA21); // index 3
            addRoad(131, 19, 911, 152, "west", "A22", tA22); // index 4
            addRoad(131, 19, 911, 171, "west", "A23", tA23); // index 5
            addRoad(131, 19, 911, 190, "west", "A24", tA24); // index 6

            // adding roads south
            addRoad(19, 98, 228, 517, "north", "A41", tA41); // index 7
            addRoad(19, 98, 247, 517, "north", "A42", tA42); // index 8
            addRoad(19, 98, 265, 517, "north", "A43", tA43); // index 9
            addRoad(19, 98, 284, 517, "north", "A44", tA44); // index 10

            // adding roads west
            addRoad(132, 19, -20, 302, "east", "A51", tA51); // index 11
            addRoad(132, 19, -20, 321, "east", "A52", tA52); // index 12
            addRoad(132, 19, -20, 340, "east", "A53", tA53); // index 13
            addRoad(132, 19, -20, 359, "east", "A54", tA54); // index 14

            // adding roads south-east
            addRoad(308, 19, 331, 264, "east", "A31", tA31); // index 15
            addRoad(308, 19, 331, 383, "east", "A32", tA32); // index 16
            addRoad(308, 19, 331, 302, "east", "A33", tA33); // index 17
            addRoad(308, 19, 331, 321, "east", "A34", tA34); // index 18

            // adding roads north-west
            addRoad(308, 19, 262, 171, "west", "A61", tA61); // index 19
            addRoad(308, 19, 262, 190, "west", "A62", tA62); // index 20
            addRoad(308, 19, 262, 209, "west", "A63", tA63); // index 21
            addRoad(308, 19, 262, 228, "west", "A64", tA64); // index 22
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
                if (testint == 1)
                {
                    busLights[1].trafficLightStatus = 1;
                }

                else
                {
                    busLights[1].trafficLightStatus = 0;
                }

                if (json.A12 == 1)
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

                if (json.A21 == 1)
                {
                    trafficLights[19].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[19].trafficLightStatus = 0;
                }

                if (json.A22 == 1)
                {
                    trafficLights[18].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[18].trafficLightStatus = 0;
                }

                if (json.A23 == 1)
                {
                    trafficLights[17].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[17].trafficLightStatus = 0;
                }

                if (json.A24 == 1)
                {
                    trafficLights[16].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[16].trafficLightStatus = 0;
                }               

                if (json.A31 == 1)
                {
                    trafficLights[12].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[12].trafficLightStatus = 0;
                }

                if (json.A32 == 1)
                {
                    trafficLights[13].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[13].trafficLightStatus = 0;
                }

                if (json.A33 == 1)
                {
                    trafficLights[14].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[14].trafficLightStatus = 0;
                }

                if (json.A34 == 1)
                {
                    trafficLights[15].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[15].trafficLightStatus = 0;
                }

                if (json.A41 == 1)
                {
                    trafficLights[8].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[8].trafficLightStatus = 0;
                }

                if (json.A42 == 1)
                {
                    trafficLights[9].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[9].trafficLightStatus = 0;
                }

                if (json.A43 == 1)
                {
                    trafficLights[10].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[10].trafficLightStatus = 0;
                }

                if (json.A44 == 1)
                {
                    trafficLights[11].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[11].trafficLightStatus = 0;
                }

                if (testint == 1)
                {
                    trafficLights[4].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[4].trafficLightStatus = 0;
                }

                if (testint == 1)
                {
                    trafficLights[5].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[5].trafficLightStatus = 0;
                }

                if (json.A53 == 1)
                {
                    trafficLights[6].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[6].trafficLightStatus = 0;
                }

                if (json.A54 == 1)
                {
                    trafficLights[7].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[7].trafficLightStatus = 0;
                }

                if (json.A61 == 1)
                {
                    trafficLights[0].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[0].trafficLightStatus = 0;
                }

                if (json.A62 == 1)
                {
                    trafficLights[1].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[1].trafficLightStatus = 0;
                }

                if (json.A63 == 1)
                {
                    trafficLights[2].trafficLightStatus = 1;
                }

                else
                {
                    trafficLights[2].trafficLightStatus = 0;
                }

                if (json.A64 == 1)
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
        private void addRoad(int width, int height, int leftX, int topY, string direction, string name, TrafficLight tl)
        {
            Road road = new Road();

            road.addRoad(width, height, leftX, topY, direction, name, tl);

            roads.Add(road);
        }

        // function to spawn cars into the simulation
        private void spawnCar()
        {
            Random random = new Random();

            int rnd = random.Next(roads.Count() - 8);

            Car car = new Car();

            car.spawnTraffic(roads[rnd].leftX, roads[rnd].topY, roads[rnd].direction, roads[rnd]);

            traffic.Add(car);

            Controls.Add(car.trafficPB);
        }

        // function to add the trafficlights into the simulation
        private TrafficLight addTrafficLight(int width, int height, int leftX, int topY, int flipped, int trafficLightStatus, string nameT)
        {
            TrafficLight trafficLight = new TrafficLight();

            trafficLight.addTrafficLight(width, height, leftX, topY, flipped, trafficLightStatus, nameT);

            trafficLights.Add(trafficLight);

            Controls.Add(trafficLight.trafficLightPB);

            return trafficLight;
        }

        private BusLight addBusLight(int width, int height, int leftX, int topY, int flipped, int trafficLightStatus, string nameT)
        {
            BusLight busLight = new BusLight();

            busLight.addTrafficLight(width, height, leftX, topY, flipped, trafficLightStatus, nameT);

            busLights.Add(busLight);

            Controls.Add(busLight.trafficLightPB);

            return busLight;
        }

    }

}
