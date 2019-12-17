using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sep3_T2_BusinessLogic.Model
{
    public class Tier3Connection
    {

        private TcpClient client;
        private string ip;
        private int port;

        

        public Tier3Connection()
        {
            this.ip = "localhost";
            this.port = 3344;
            client = new TcpClient(ip, port);
        }

        public string GetFromServer(string recv)
        { 
                TcpClient client = new TcpClient("localhost", 3344);

                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];

                int bytes = stream.Read(buffer, 0, buffer.Length);

                byte[] a = new byte[bytes];

                for (int i = 0; i < bytes; i++)
                {
                    a[i] = buffer[i];
                }
                 Console.WriteLine(a.Length);
                recv = Encoding.UTF8.GetString(a);

                Console.WriteLine(recv);

                return recv;

        }
        
    

        public void SendToServer(Package package)
        {
            NetworkStream stream = client.GetStream();
           
            Console.WriteLine(package.action);
            //sending
            Console.WriteLine("Sending date!");
            string message = JsonConvert.SerializeObject(package);
            byte[] sendBytes = new byte[1024];
            sendBytes = Encoding.UTF8.GetBytes(message + "\r\0"); // "\r\0" tells tcp java to stop reading the stream
            stream.Write(sendBytes, 0, sendBytes.Length);
              Console.WriteLine(message);
              Console.WriteLine("Data has been sent!");
                


        }
    }
}


