using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        public string Register([FromBody] string[] content)
        {
            Console.WriteLine("Received a Register post request.");
            String username, password, confirmPassword, email;
            username = content[0];
            password = content[1];
            confirmPassword = content[2];
            email = content[3];
            Console.WriteLine(username + " "+ password + " " + confirmPassword + " " + email );
            Console.WriteLine("Printed out");
            return "sup";

        }


    }
}