using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;
using Sep3_T2_BusinessLogic.Model;

namespace Sep3_T2_BusinessLogic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private Tier3Connection connection = new Tier3Connection();

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] string[] content)
        {
            Console.WriteLine("Received login data");

            Client client = new Client(content[0], content[1]);

            string clientToSend = JsonConvert.SerializeObject(client);

            Package pack = new Package("Login", clientToSend);

            connection.SendToServer(pack);

            var data = JsonConvert.DeserializeObject<Client>(connection.GetFromServer());

            if (client.username.Equals(data.username) && client.password.Equals(data.password))
                return Ok();

            return BadRequest("Password or username doesn't match");

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Post([FromBody]string[] content)
        {
            Console.WriteLine("Received a Register post request.");
            string username, password, confpas, email;
            username = content[0];
            password = content[1];
            confpas = content[2];
            email = content[3];

            if (username == null || password == null)
                return BadRequest("Username or password cannot be empty");

            foreach (char c in username)
            {
                if (c.Equals(" ") || c.Equals("@") || c.Equals(",") || c.Equals("."))
                    return BadRequest("Forbidden characters are not allowed in username");
            }

            if (password.Equals(confpas) && password.Length > 4)
            {
                SendClient(username, password, email);
                return Ok("Everything is fine");
            }

            if (!password.Equals(confpas) || password.Length < 4)
            {
                return BadRequest("Passwords don't match or the expected length is not met");
            }

            return null;

        }


        [HttpGet("{date}")]
        public async Task<string> GetMovies([FromQuery] string date)
        {
            Console.WriteLine("Received a Schedule GET request");

            SendDateOfMovies(date);

            Console.WriteLine("Date sent");

            string value = connection.GetFromServer();

            return value;

        }

        [HttpPost]
        [Route("booking")]
        public async Task<IActionResult> PostBooking([FromBody]string[] content)
        {
            Console.WriteLine("Received post request for booking");
            string username, movieName, date, hour;
            username = content[0];
            movieName = content[1];
            date = content[2];
            hour = content[3];

            SendBooking(username, movieName, date, hour);

            return Ok("Data sent");
        }

        public void SendClient(string username, string password, string email)
        {
            ClientReg client = new ClientReg();
            client.username = username;
            client.password = password;
            client.email = email;

            ClientReg pack = new ClientReg(client.username, client.password, client.email);
            Console.WriteLine("Sending date!");

            string message = JsonConvert.SerializeObject(pack);

            Package package = new Package("register", message);
            connection.SendToServer(package);
            Console.WriteLine(message);
            Console.WriteLine("Date has been sent!");

        }

        public void SendDateOfMovies(string date)
        {
            Console.WriteLine("Sending date!");

            Package package = new Package("Date", date);
            connection.SendToServer(package);

        }

        public void SendBooking(string username, string MovieName, string Cinema, string date)
        {
            Booking book = new Booking(username, MovieName, Cinema, date);

            Console.WriteLine("Sending data");

            string pack = JsonConvert.SerializeObject(book);

            Package package = new Package("Booking", pack);
            connection.SendToServer(package);
            Console.WriteLine(pack);
            Console.WriteLine("Date has been sent");
        }


    }
}