using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrafficRoad
{
    public partial class Form1 : Form
    {
        List<Traffic> traffic = new List<Traffic>();
        List<Path> paths = new List<Path>();
        List<Path> busPaths = new List<Path>();
        List<Path> cyclistPaths = new List<Path>();
        List<Path> pedestrianPaths = new List<Path>();
        List<TrafficLight> trafficLights = new List<TrafficLight>();
        List<BusLight> busLights = new List<BusLight>();
        private mySocket aSocket = new mySocket();
        public Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            // north west traffic lights
            TrafficLight tA61 = addTrafficLight(16, 7, 274, 175, 270, 0, "A6-1");
            TrafficLight tA62 = addTrafficLight(16, 7, 274, 194, 270, 0, "A6-2");
            TrafficLight tA63 = addTrafficLight(16, 7, 274, 212, 270, 0, "A6-3");
            TrafficLight tA64 = addTrafficLight(16, 7, 274, 231, 270, 0, "A6-4");

            // west traffic lights
            TrafficLight tA51 = addTrafficLight(16, 7, 107, 306, 90, 0, "A5-1");
            TrafficLight tA52 = addTrafficLight(16, 7, 107, 326, 90, 0, "A5-2");
            TrafficLight tA53 = addTrafficLight(16, 7, 107, 344, 90, 0, "A5-3");
            TrafficLight tA54 = addTrafficLight(16, 7, 107, 363, 90, 0, "A5-4");

            // southern traffic lights
            TrafficLight tA41 = addTrafficLight(7, 16, 231, 416, 0, 0, "A4-1");
            TrafficLight tA42 = addTrafficLight(7, 16, 250, 416, 0, 0, "A4-2");
            TrafficLight tA43 = addTrafficLight(7, 16, 269, 416, 0, 0, "A4-3");
            TrafficLight tA44 = addTrafficLight(7, 16, 288, 416, 0, 0, "A4-4");

            // south east traffic lights
            TrafficLight tA31 = addTrafficLight(16, 7, 614, 269, 90, 0, "A3-1");
            TrafficLight tA32 = addTrafficLight(16, 7, 614, 288, 90, 0, "A3-2");
            TrafficLight tA33 = addTrafficLight(16, 7, 614, 307, 90, 0, "A3-3");
            TrafficLight tA34 = addTrafficLight(16, 7, 614, 326, 90, 0, "A3-4");

            // north east traffic lights
            TrafficLight tA21 = addTrafficLight(16, 7, 779, 138, 270, 0, "A2-1");
            TrafficLight tA22 = addTrafficLight(16, 7, 779, 157, 270, 0, "A2-2");
            TrafficLight tA23 = addTrafficLight(16, 7, 779, 176, 270, 0, "A2-3");
            TrafficLight tA24 = addTrafficLight(16, 7, 779, 195, 270, 0, "A2-4");

            // northern single traffic light
            TrafficLight tA11 = addTrafficLight(7, 16, 607, 75, 180, 0, "A1-1");
            TrafficLight tA12 = addTrafficLight(7, 16, 626, 75, 180, 0, "A1-2");
            TrafficLight tA13 = addTrafficLight(7, 16, 645, 75, 180, 0, "A1-3");

            //pedestrain lights
            TrafficLight pV51 = addTrafficLight(3, 8, 132, 160, 180, 0, "V5-1");
            TrafficLight pV52 = addTrafficLight(3, 8, 132, 210, 0, 0, "V5-2");
            TrafficLight pV53 = addTrafficLight(3, 8, 132, 290, 180, 0, "V5-3");
            TrafficLight pV54 = addTrafficLight(3, 8, 132, 378, 0, 0, "V5-4");

            TrafficLight pV41 = addTrafficLight(8, 3, 160, 406, 90, 0, "V4-1");
            TrafficLight pV42 = addTrafficLight(8, 3, 208, 406, 270, 0, "V4-2");
            TrafficLight pV43 = addTrafficLight(8, 3, 220, 406, 90, 0, "V4-3");
            TrafficLight pV44 = addTrafficLight(8, 3, 322, 406, 270, 0, "V4-4");

            TrafficLight pV24 = addTrafficLight(3, 8, 767, 340, 0, 0, "V2-4");
            TrafficLight pV23 = addTrafficLight(3, 8, 767, 291, 180, 0, "V2-3");
            TrafficLight pV22 = addTrafficLight(3, 8, 767, 210, 0, 0, "V2-2");
            TrafficLight pV21 = addTrafficLight(3, 8, 767, 120, 180, 0, "V2-1");

            TrafficLight pV14 = addTrafficLight(8, 3, 735, 99, 270, 0, "V1-4");
            TrafficLight pV13 = addTrafficLight(8, 3, 688, 99, 90, 0, "V1-3");
            TrafficLight pV12 = addTrafficLight(8, 3, 676, 99, 270, 0, "V1-2");
            TrafficLight pV11 = addTrafficLight(8, 3, 590, 99, 90, 0, "V1-1");

            //bike lights
            TrafficLight bF11 = addTrafficLight(8, 3, 590, 106, 90, 0, "F1-1");
            TrafficLight bF12 = addTrafficLight(8, 3, 735, 106, 270, 0, "F1-2");

            TrafficLight bF21 = addTrafficLight(3, 8, 759, 120, 180, 0, "F2-1");
            TrafficLight bF22 = addTrafficLight(3, 8, 760, 340, 0, 0, "F2-2");

            TrafficLight bF41 = addTrafficLight(8, 3, 160, 398, 90, 0, "F4-1");
            TrafficLight bF44 = addTrafficLight(8, 3, 322, 398, 270, 0, "F4-2");

            TrafficLight bF51 = addTrafficLight(3, 8, 140, 160, 180, 0, "F5-1");
            TrafficLight bF52 = addTrafficLight(3, 8, 140, 378, 0, 0, "F5-2");

            //bus lights
            BusLight bB41 = addBusLight(8, 8, 306, 425, 0, 0, "B4-1");
            BusLight bB11 = addBusLight(8, 8, 659, 74, 0, 0, "B1-1");
            BusLight bB12 = addBusLight(8, 8, 667, 74, 0, 0, "B1-2");

            // adding Paths (path0/4 from north spawn)
            Path path0 = new Path();
            path0.addPoint(603, -20, "south");
            path0.addPoint(603, 175, "south", tA11);
            path0.addPoint(262, 172, "west", tA61);
            path0.addPoint(-40, 172, "west");
            paths.Add(path0);
            Path path1 = new Path();
            path1.addPoint(622, -20, "south");
            path1.addPoint(622, 193, "south", tA12);
            path1.addPoint(262, 190, "west", tA62);
            path1.addPoint(-40, 190, "west");
            paths.Add(path1);
            Path path2 = new Path();
            path2.addPoint(622, -20, "south");
            path2.addPoint(622, 213, "south", tA12);
            path2.addPoint(262, 209, "west", tA63);
            path2.addPoint(172, 209, "west");
            path2.addPoint(172, 546, "south");
            paths.Add(path2);
            Path path3 = new Path();
            path3.addPoint(622, -20, "south");
            path3.addPoint(622, 231, "south", tA12);
            path3.addPoint(262, 227, "west", tA64);
            path3.addPoint(191, 227, "west");
            path3.addPoint(191, 546, "south");
            paths.Add(path3);
            Path path4 = new Path();
            path4.addPoint(642, -20, "south");
            path4.addPoint(642, 308, "south", tA13);
            path4.addPoint(1100, 303, "east");
            paths.Add(path4);

            // addings Paths (path5/10 from east spawn)
            Path path5 = new Path();
            path5.addPoint(921, 133, "west");
            path5.addPoint(715, 133, "west", tA21);
            path5.addPoint(716, -40, "north");
            paths.Add(path5);
            Path path6 = new Path();
            path6.addPoint(921, 152, "west");
            path6.addPoint(695, 152, "west", tA22);
            path6.addPoint(696, -40, "north");
            paths.Add(path6);
            Path path7 = new Path();
            path7.addPoint(921, 172, "west");
            path7.addPoint(520, 172, "west", tA23);
            path7.addPoint(-40, 172, "west", tA61);
            paths.Add(path7);
            Path path8 = new Path();
            path8.addPoint(921, 190, "west");
            path8.addPoint(520, 190, "west", tA24);
            path8.addPoint(-40, 190, "west", tA62);
            paths.Add(path8);
            Path path9 = new Path();
            path9.addPoint(921, 190, "west");
            path9.addPoint(714, 190, "west", tA24);
            path9.addPoint(520, 210, "west");
            path9.addPoint(262, 209, "west", tA63);
            path9.addPoint(172, 209, "west");
            path9.addPoint(172, 546, "south");
            paths.Add(path9);
            Path path10 = new Path();
            path10.addPoint(921, 190, "west");
            path10.addPoint(714, 190, "west", tA24);
            path10.addPoint(520, 228, "west");
            path10.addPoint(262, 227, "west", tA64);
            path10.addPoint(191, 227, "west");
            path10.addPoint(191, 546, "south");
            paths.Add(path10);

            // addings Paths (path11/16 from south spawn)
            Path path11 = new Path();
            path11.addPoint(228, 558, "north");
            path11.addPoint(228, 189, "north", tA41);
            path11.addPoint(0, 189, "west");
            path11.addPoint(-50, 189, "west");
            paths.Add(path11);
            Path path12 = new Path();
            path12.addPoint(247, 558, "north");
            path12.addPoint(247, 170, "north", tA42);
            path12.addPoint(0, 170, "west");
            path12.addPoint(-50, 170, "west");
            paths.Add(path12);
            Path path13 = new Path();
            path13.addPoint(265, 558, "north");
            path13.addPoint(265, 302, "north", tA43);
            path13.addPoint(888, 302, "east", tA33);
            path13.addPoint(1100, 302, "east");
            paths.Add(path13);
            Path path14 = new Path();
            path14.addPoint(284, 558, "north");
            path14.addPoint(284, 322, "north", tA44);
            path14.addPoint(888, 322, "east", tA34);
            path14.addPoint(1100, 322, "east");
            paths.Add(path14);
            Path path15 = new Path();
            path15.addPoint(265, 558, "north");
            path15.addPoint(265, 285, "north", tA43);
            path15.addPoint(714, 285, "east", tA32);
            path15.addPoint(714, 0, "north");
            path15.addPoint(714, -50, "north");
            paths.Add(path15);
            Path path16 = new Path();
            path16.addPoint(265, 558, "north");
            path16.addPoint(265, 265, "north", tA43);
            path16.addPoint(696, 265, "east", tA31);
            path16.addPoint(696, 0, "north");
            path16.addPoint(696, -50, "north");
            paths.Add(path16);

            Path path17 = new Path();
            path17.addPoint(-50, 303, "east");
            path17.addPoint(206, 303, "east", tA51);
            path17.addPoint(320, 265, "east");
            path17.addPoint(697, 265, "east", tA31);
            path17.addPoint(697, -50, "north");
            paths.Add(path17);
            Path path18 = new Path();
            path18.addPoint(-50, 303, "east");
            path18.addPoint(206, 303, "east", tA51);
            path18.addPoint(332, 284, "east");
            path18.addPoint(716, 284, "north", tA32);
            path18.addPoint(716, -50, "north");
            paths.Add(path18);
            Path path19 = new Path();
            path19.addPoint(-50, 322, "east");
            path19.addPoint(226, 322, "east", tA52);
            path19.addPoint(333, 303, "east", tA33);
            path19.addPoint(1100, 303, "east");
            paths.Add(path19);
            Path path20 = new Path();
            path20.addPoint(-50, 322, "east");
            path20.addPoint(226, 322, "east", tA52);
            path20.addPoint(333, 322, "east", tA34);
            path20.addPoint(1100, 322, "east");
            paths.Add(path20);
            Path path21 = new Path();
            path21.addPoint(-50, 341, "east");
            path21.addPoint(191, 341, "east", tA53);
            path21.addPoint(191, 570, "south");
            paths.Add(path21);
            Path path22 = new Path();
            path22.addPoint(-50, 359, "east");
            path22.addPoint(174, 359, "east", tA54);
            path22.addPoint(174, 570, "south");
            paths.Add(path22);

            //bus paths
            Path bPath1 = new Path();
            bPath1.addPoint(660, -50, "south");
            bPath1.addPoint(660, 175, "south", bB11);
            bPath1.addPoint(660, 172, "west", tA61);
            bPath1.addPoint(-50, 172, "west");
            busPaths.Add(bPath1);
            Path bPath2 = new Path();
            bPath2.addPoint(660, -50, "south");
            bPath2.addPoint(660, 308, "south", bB12);
            bPath2.addPoint(660, 301, "east");
            bPath2.addPoint(1100, 301, "east");
            busPaths.Add(bPath2);
            Path bPath3 = new Path();
            bPath3.addPoint(303, 555, "north");
            bPath3.addPoint(303, 395, "north", bB41);
            bPath3.addPoint(286, 322, "north");
            bPath3.addPoint(391, 322, "east", tA34);
            bPath3.addPoint(1100, 322, "east");
            busPaths.Add(bPath3);

            //cyclist paths
            Path cPath1 = new Path();
            cPath1.addPoint(-40, 139, "east");
            cPath1.addPoint(137, 139, "east");
            cPath1.addPoint(137, 396, "south", bF51);
            cPath1.addPoint(-50, 396, "west");
            cyclistPaths.Add(cPath1);

            Path cPath2 = new Path();
            cPath2.addPoint(-40, 139, "east");
            cPath2.addPoint(577, 139, "east");
            cPath2.addPoint(577, 105, "north");
            cPath2.addPoint(765, 105, "east", bF11);
            cPath2.addPoint(765, -50, "north");
            cyclistPaths.Add(cPath2);

            Path cPath3 = new Path();
            cPath3.addPoint(-40, 397, "east");
            cPath3.addPoint(346, 397, "east", bF41);
            cPath3.addPoint(346, 367, "north");
            cPath3.addPoint(1100, 367, "east");
            cyclistPaths.Add(cPath3);

            Path cPath4 = new Path();
            cPath4.addPoint(920, 366, "west");
            cPath4.addPoint(758, 366, "west");
            cPath4.addPoint(758, 85, "north", bF22);
            cPath4.addPoint(757, -50, "north");
            cyclistPaths.Add(cPath4);

            Path cPath5 = new Path();
            cPath5.addPoint(759, -40, "south");
            cPath5.addPoint(759, 104, "south");
            cPath5.addPoint(571, 104, "west", bF12);
            cPath5.addPoint(567, 137, "south");
            cPath5.addPoint(-50, 137, "west");
            cyclistPaths.Add(cPath5);

            Path cPath6 = new Path();
            cPath6.addPoint(920, 366, "west");
            cPath6.addPoint(348, 366, "west");
            cPath6.addPoint(346, 399, "south");
            cPath6.addPoint(250, 397, "west", bF44);
            cPath6.addPoint(-50, 397, "west");
            cyclistPaths.Add(cPath6);

            Path cPath7 = new Path();
            cPath7.addPoint(759, -40, "south");
            cPath7.addPoint(759, 226, "south", bF21);
            cPath7.addPoint(759, 365, "north");
            cPath7.addPoint(1100, 365, "east");
            cyclistPaths.Add(cPath7);

            Path cPath8 = new Path();
            cPath8.addPoint(920, 105, "west");
            cPath8.addPoint(757, 105, "west");
            cPath8.addPoint(759, 365, "south", bF21);
            cPath8.addPoint(1100, 365, "east");
            cyclistPaths.Add(cPath8);

            //ped peds
            Path pPath1 = new Path();
            pPath1.addPoint(-50, 136, "west");
            pPath1.addPoint(132, 136, "south", pV51);
            pPath1.addPoint(132, 410, "east");
            pPath1.addPoint(-50, 410, "east");
            pedestrianPaths.Add(pPath1);

            Path pPath2 = new Path();
            pPath2.addPoint(-50, 136, "west");
            pPath2.addPoint(565, 136, "north");
            pPath2.addPoint(565, 99, "west");
            pPath2.addPoint(767, 99, "north");
            pPath2.addPoint(767, -50, "north");
            pedestrianPaths.Add(pPath2);

            Path pPath3 = new Path();
            pPath3.addPoint(-50, 408, "west", pV41);
            pPath3.addPoint(221, 408, "west", pV43);
            pPath3.addPoint(337, 408, "west");
            pPath3.addPoint(355, 391, "north");
            pPath3.addPoint(368, 374, "west");
            pPath3.addPoint(1100, 374, "west");
            pedestrianPaths.Add(pPath3);

            Path pPath4 = new Path();
            pPath4.addPoint(950, 375, "east");
            pPath4.addPoint(770, 375, "north", pV24);
            pPath4.addPoint(770, 226, "north", pV23);
            pPath4.addPoint(770, -50, "north");
            pedestrianPaths.Add(pPath4);

            Path pPath5 = new Path();
            pPath5.addPoint(767, -50, "north");
            pPath5.addPoint(767, 99, "north");
            pPath5.addPoint(572, 99, "west", pV14);
            pPath5.addPoint(565, 113, "north");
            pPath5.addPoint(565, 136, "west");
            pPath5.addPoint(-50, 136, "west");
            pedestrianPaths.Add(pPath5);

            Path pPath6 = new Path();
            pPath6.addPoint(950, 374, "west");
            pPath6.addPoint(368, 374, "west");
            pPath6.addPoint(355, 391, "north");
            pPath6.addPoint(337, 408, "west");
            pPath6.addPoint(221, 408, "west", pV44);
            pPath6.addPoint(-50, 408, "west", pV42);
            pedestrianPaths.Add(pPath6);

            Path pPath7 = new Path();
            pPath7.addPoint(770, -50, "north");
            pPath7.addPoint(770, 226, "north", pV21);
            pPath7.addPoint(770, 375, "north", pV22);
            pPath7.addPoint(1100, 375, "east");
            pedestrianPaths.Add(pPath7);

            Path pPath8 = new Path();
            pPath8.addPoint(950, 102, "east");
            pPath8.addPoint(770, 102, "south", pV21);
            pPath8.addPoint(770, 268, "north", pV22);
            pPath8.addPoint(770, 375, "west");
            pPath8.addPoint(1100, 375, "west");
            pedestrianPaths.Add(pPath8);

            Thread t = new Thread(aSocket.Connect);
            t.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            JObject jsonReceived = aSocket.json;

            if(jsonReceived != null)
            {
                foreach(TrafficLight t in trafficLights)
                {
                    int status;
                    status = (int)jsonReceived[t.nameT];
                    t.trafficLightStatus = status;
                    t.checkTrafficLightStatus();
                }

                foreach(BusLight bus in busLights)
                {
                    int status = (int)jsonReceived[bus.nameT];
                    if (bus.nameT == "B4-1")
                        bus.trafficLightStatus = status;
                    if (bus.nameT == "B1-1")
                        bus.trafficLightStatus = status;
                    if (bus.nameT == "B1-2")
                        bus.trafficLightStatus = status;
                    bus.checkTrafficLightStatusBus();
                }
                //jsonReceived = null;
            }

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

            int rnd = random.Next(100);
            if (rnd == 1)
            {
                spawnCar();
                spawnBus();
                spawnCyclist();
                spawnPedestrian();
            }

            foreach (TrafficLight t in trafficLights)
            {
                t.checkTrafficLightStatus();
            }

            foreach (BusLight bus in busLights)
            {
                bus.checkTrafficLightStatusBus();
            }
        }

        // function to spawn cars into the simulation
        private void spawnCar()
        {
            Random random = new Random();
            int rnd = random.Next(paths.Count());
            Car car = new Car();
            car.spawnTraffic(paths[rnd].points[0].Left, paths[rnd].points[0].Top, 15, 30, paths[rnd]);
            traffic.Add(car);
            Controls.Add(car.trafficPB);
        }

        private void spawnBus()
        {
            Random random = new Random();
            int rnd = random.Next(busPaths.Count());
            Bus bus = new Bus();
            bus.spawnTraffic(busPaths[rnd].points[0].Left, busPaths[rnd].points[0].Top, 15, 58, busPaths[rnd]);
            traffic.Add(bus);
            Controls.Add(bus.trafficPB);
        }

        private void spawnCyclist()
        {
            Random random = new Random();
            int rnd = random.Next(cyclistPaths.Count());
            Cyclist cyclist = new Cyclist();
            cyclist.spawnTraffic(cyclistPaths[rnd].points[0].Left, cyclistPaths[rnd].points[0].Top, 6, 15, cyclistPaths[rnd]);
            traffic.Add(cyclist);
            Controls.Add(cyclist.trafficPB);
        }

        private void spawnPedestrian()
        {
            Random random = new Random();
            int rnd = random.Next(pedestrianPaths.Count());
            Pedestrian pedestrian = new Pedestrian();
            pedestrian.spawnTraffic(pedestrianPaths[rnd].points[0].Left, pedestrianPaths[rnd].points[0].Top, 2, 2, pedestrianPaths[rnd]);
            traffic.Add(pedestrian);
            Controls.Add(pedestrian.trafficPB);
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
