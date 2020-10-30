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
    public partial class TrafficLight : Form
    {
        List<Traffic> traffic = new List<Traffic>();

        private mySocket aSocket = new mySocket();
        private jsonTL json = new jsonTL();

        public TrafficLight()
        {
            InitializeComponent();
            //aSocket.Main1();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
