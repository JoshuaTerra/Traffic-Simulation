using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading;

namespace TrafficRoad {
    public class mySocket
    {
        private Int32 port = 54000;

        private IPAddress localAddr = IPAddress.Parse("127.0.0.1");

        Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public JObject json = null;

        public void Listen()
        {
            byte[] bytes = new byte[1024];

            // Connect the socket to the remote endpoint. Catch any errors.  
            while(sender.Available > 0)
            {
                int receivedDataLength = sender.Receive(bytes);

                string data = Encoding.ASCII.GetString(bytes, 0, receivedDataLength);

                String header = "0";
                if (!String.IsNullOrWhiteSpace(data))
                {
                    int charLocation = data.IndexOf(":", StringComparison.Ordinal);

                    if (charLocation > 0)
                    {
                        header = data.Substring(0, charLocation);
                    }
                }

                if (header == data.Substring(4).Length.ToString())
                {
                    data = data.Substring(4);

                    json = JsonConvert.DeserializeObject<JObject>(data);

                    Console.WriteLine(data);
                }
                else
                {
                    Console.WriteLine("JSON is not complete...");
                }
            }
        }
        public void Connect()
        {
            IPEndPoint localEndpoint = new IPEndPoint(localAddr, port);

            while (!sender.Connected)
            {
                try
                {
                    sender.Connect(localEndpoint);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Unable to connect to server.");
                }
            }

            while (sender.Connected)
            {
                Listen();
            }
        }

    }
}

