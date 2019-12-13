using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sep3_T2_BusinessLogic.Model;

namespace Sep3_T2_BusinessLogic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private Tier3Connection connection = new Tier3Connection();

        [HttpGet]
        public /*List<Movie>*/ string GetMovies(string stuff)
        {
            return $"value {stuff}";
            //return connection.GetMovie(Date);
            //return new List<Movie> { new Movie { Cinema = "Hello" }};
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string[] content)
        {
            Console.WriteLine("Received a Register post request.");
            string username, password, confpas, email;
            username = content[0];
            password = content[1];
            confpas = content[2];
            email = content[3];

            if (password.Equals(confpas))
            {
                SendClient(username, password, email);
                return Ok("Everything is fine");
            }
            return BadRequest("Passwords don't match");

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
            connection.RegisterToServer(package);
             Console.WriteLine(message);
             Console.WriteLine("Date has been sent!");

        }
    }
}