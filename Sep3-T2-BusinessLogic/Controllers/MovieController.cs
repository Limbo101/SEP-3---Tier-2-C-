using System;
using System.Collections.Generic;
using System.Linq;
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
        public /*List<Movie>*/string GetMovies(string stuff)
        {
            return $"value {stuff}";
            //return connection.GetMovie(Date);
            //return new List<Movie> { new Movie { Cinema = "Hello" }};
        } 
    }
}