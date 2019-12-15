using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sep3_T2_BusinessLogic.Model
{
    public class Tier3Connection
    {
        //public List<Movie> GetMovie(string Date) 
        //{
        //    socket connection to tier 3 to receive details about movies from a specific date according to the movie class
        //    return new List<Movie>(new Movie());
        //}

        private TcpClient client;
        private string ip;
        private int port;

        private static readonly Socket _clientSocket = new Socket
        (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Tier3Connection()
        {
            this.ip = "localhost";
            this.port = 3344;
            client = new TcpClient(ip, port);
        }

        public string GetFromServer(string recv)
        {
            _clientSocket.Connect(ip, port);

            byte[] buffer = new byte[2048];

            int received = _clientSocket.Receive(buffer, SocketFlags.None);

            var data = new byte[received];

            recv = Encoding.UTF8.GetString(data);

            return recv;
        }

        public void SendToServer(Package package)
        {

            Boolean send = true;
            NetworkStream stream = client.GetStream();
            while (true)
            {
                send = true;
                if (send == true)
                {
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
    }
}


