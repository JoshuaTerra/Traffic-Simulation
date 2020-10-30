using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace TrafficRoad {
    public class mySocket
    {
        private jsonTL json = null;

        public jsonTL Json
        {
            get => json; set => json = value;
        }

        public void Main1()
        {
            byte[] bytes = new byte[1024];

            // Connect to a remote device.  
            try
            {
                while (true)
                {
                    // Establish the remote endpoint for the socket.  
                    // This example uses port 11000 on the local computer.  
                    IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, 54000);

                    // Create a TCP/IP  socket.  
                    Socket sender = new Socket(ipAddress.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);

                    // Connect the socket to the remote endpoint. Catch any errors.  
                    try
                    {
                        sender.Connect(remoteEP);

                        Console.WriteLine("Socket connected to {0}",
                            sender.RemoteEndPoint.ToString());

                        // Encode the data string into a byte array.  
                        byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                        // Send the data through the socket.  
                        int bytesSent = sender.Send(msg);

                        // Receive the response from the remote device.  
                        int bytesRec = sender.Receive(bytes);
                        Console.WriteLine("Echoed test = {0}",
                            Encoding.ASCII.GetString(bytes, 0, bytesRec));

                        string test = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                        string data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
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

                            //Console.WriteLine(json.A10);
                        }
                        else
                        {
                            Console.WriteLine("JSON is not complete...");
                        }

                        Console.WriteLine(json.A11);
                        // Release the socket.  
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();

                    }
                    catch (ArgumentNullException ane)
                    {
                        Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    }
                    catch (SocketException se)
                    {
                        Console.WriteLine("SocketException : {0}", se.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
