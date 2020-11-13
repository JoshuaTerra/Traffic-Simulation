using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace TrafficRoad {
    public class mySocket
    {
        private Int32 port = 54000;

        private IPAddress localAddr = IPAddress.Parse("127.0.0.1");

        Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private jsonTL json = null;

        public jsonTL Json
        {
            get => json; set => json = value;
        }

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

                    json = JsonConvert.DeserializeObject<jsonTL>(data);

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

