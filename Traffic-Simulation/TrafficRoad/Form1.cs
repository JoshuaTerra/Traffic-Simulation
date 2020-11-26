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
using System.Threading;

namespace TrafficRoad
{
    public partial class Form1 : Form
    {
        List<Traffic> traffic = new List<Traffic>();
        List<Path> paths = new List<Path>();
        List<TrafficLight> trafficLights = new List<TrafficLight>();
        List<BusLight> busLights = new List<BusLight>();
        private mySocket aSocket = new mySocket();
        public Random random = new Random();
        jsonTL json = new jsonTL();

        public Form1()
        {
            InitializeComponent();

            // north west traffic lights
            TrafficLight tA61 = addTrafficLight(16, 7, 274, 175, 270, 0, "A61");
            TrafficLight tA62 = addTrafficLight(16, 7, 274, 194, 270, 0, "A62");
            TrafficLight tA63 = addTrafficLight(16, 7, 274, 212, 270, 0, "A63");
            TrafficLight tA64 = addTrafficLight(16, 7, 274, 231, 270, 0, "A64");

            // west traffic lights
            TrafficLight tA51 = addTrafficLight(16, 7, 107, 306, 90, 0, "A51");
            TrafficLight tA52 = addTrafficLight(16, 7, 107, 326, 90, 0, "A52");
            TrafficLight tA53 = addTrafficLight(16, 7, 107, 344, 90, 0, "A53");
            TrafficLight tA54 = addTrafficLight(16, 7, 107, 363, 90, 0, "A54");

            // southern traffic lights
            TrafficLight tA41 = addTrafficLight(7, 16, 231, 416, 0, 1, "A41");
            TrafficLight tA42 = addTrafficLight(7, 16, 250, 416, 0, 1, "A42");
            TrafficLight tA43 = addTrafficLight(7, 16, 269, 416, 0, 1, "A43");
            TrafficLight tA44 = addTrafficLight(7, 16, 288, 416, 0, 1, "A44");

            // south east traffic lights
            TrafficLight tA31 = addTrafficLight(16, 7, 614, 269, 90, 1, "A31");
            TrafficLight tA32 = addTrafficLight(16, 7, 614, 288, 90, 1, "A32");
            TrafficLight tA33 = addTrafficLight(16, 7, 614, 307, 90, 1, "A33");
            TrafficLight tA34 = addTrafficLight(16, 7, 614, 326, 90, 1, "A34");

            // north east traffic lights
            TrafficLight tA21 = addTrafficLight(16, 7, 779, 138, 270, 1, "A21");
            TrafficLight tA22 = addTrafficLight(16, 7, 779, 157, 270, 1, "A22");
            TrafficLight tA23 = addTrafficLight(16, 7, 779, 176, 270, 1, "A23");
            TrafficLight tA24 = addTrafficLight(16, 7, 779, 195, 270, 1, "A24");

            // northern single traffic light
            TrafficLight tA11 = addTrafficLight(7, 16, 607, 75, 180, 1, "A11");
            TrafficLight tA12 = addTrafficLight(7, 16, 626, 75, 180, 1, "A12");
            TrafficLight tA13 = addTrafficLight(7, 16, 645, 75, 180, 1, "A13");

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

            TrafficLight bF11 = addTrafficLight(8, 3, 590, 106, 90, 1, "F11");
            TrafficLight bF12 = addTrafficLight(8, 3, 735, 106, 270, 1, "F12");

            TrafficLight bF21 = addTrafficLight(3, 8, 759, 120, 180, 1, "F21");
            TrafficLight bF22 = addTrafficLight(3, 8, 760, 340, 0, 1, "F22");

            TrafficLight bF41 = addTrafficLight(8, 3, 160, 398, 90, 1, "F41");
            TrafficLight bF44 = addTrafficLight(8, 3, 322, 398, 270, 1, "F42");

            TrafficLight bF51 = addTrafficLight(3, 8, 140, 160, 180, 1, "F51");
            TrafficLight bF52 = addTrafficLight(3, 8, 140, 378, 0, 1, "F52");

            //bus lights
            BusLight bB11 = addBusLight(8, 8, 306, 425, 0, 1, "B11");
            BusLight bB12 = addBusLight(8, 8, 659, 74, 0, 1, "B12");
            BusLight bB41 = addBusLight(8, 8, 667, 74, 0, 1, "B41");

            // adding Paths (path0/4 from north spawn)
            /*Path path0 = new Path();
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
            path4.addPoint(941, 303, "east");
            paths.Add(path4);*/

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
            path19.addPoint(950, 303, "east");
            paths.Add(path19);

            Path path20 = new Path();
            path20.addPoint(-50, 322, "east");
            path20.addPoint(226, 322, "east", tA52);
            path20.addPoint(333, 322, "east", tA34);
            path20.addPoint(950, 322, "east");
            paths.Add(path20);

            Path path21 = new Path();
            path21.addPoint(-50, 341, "east");
            path21.addPoint(191, 341, "south", tA53);
            path21.addPoint(191, 550, "south");
            paths.Add(path21);

            Path path22 = new Path();
            path22.addPoint(-50, 359, "east");
            path22.addPoint(174, 359, "south", tA54);
            path22.addPoint(174, 550, "south");
            paths.Add(path22);


            // addings Paths (path5/10 from east spawn)
            Path path5 = new Path();
            path5.addPoint(921, 133, "west");
            path5.addPoint(715, 133, "west", tA21);
            path5.addPoint(716, -40, "north");
            paths.Add(path5);

            Path path6 = new Path();
            path6.addPoint(921, 152, "west");
            path6.addPoint(695, 152, "west", tA21);
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
            path13.addPoint(938, 302, "east");
            paths.Add(path13);

            Path path14 = new Path();
            path14.addPoint(284, 558, "north");
            path14.addPoint(284, 322, "north", tA44);
            path14.addPoint(888, 322, "east", tA34);
            path14.addPoint(938, 322, "east");
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

            //bus paths

            Path bPath1 = new Path();
            bPath1.addPoint(660, -50, "south", bB11);
            bPath1.addPoint(660, 173, "west");
            bPath1.addPoint(-50, 173, "west", tA61);
            paths.Add(bPath1);

            Path bPath2 = new Path();
            bPath2.addPoint(660, -50, "south", bB12);
            bPath2.addPoint(660, 301, "east");
            bPath2.addPoint(938, 301, "east");
            paths.Add(bPath2);

            Path bPath3 = new Path();
            bPath3.addPoint(305, 555, "north", bB41);
            bPath3.addPoint(305, 395, "north");
            bPath3.addPoint(284, 365, "north");
            bPath3.addPoint(278, 321, "east");
            bPath3.addPoint(938, 321, "east", tA34);
            paths.Add(bPath3);


            Thread t = new Thread(aSocket.Connect);
            t.Start();

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

            foreach (var j in json.GetType().GetProperties())
            {
                foreach (TrafficLight t in trafficLights)
            {
                    if (j.Name == t.nameT)
                    {
                        t.trafficLightStatus = 1; //Convert.ToInt32(j.GetValue(null));
                        //Console.WriteLine(j.Name + "  " + t.nameT);
                    }
                }
            }

            foreach (TrafficLight t in trafficLights)
            {
                t.checkTrafficLightStatus();
            }
        }

        // function to spawn cars into the simulation
        private void spawnCar()
        {
            Random random = new Random();

            int rnd = random.Next(paths.Count());

            Car car = new Car();

            car.spawnTraffic(paths[rnd].points[0].Left, paths[rnd].points[0].Top, paths[rnd]);

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
