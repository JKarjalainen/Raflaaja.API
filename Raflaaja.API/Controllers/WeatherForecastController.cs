using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raflaaja.DAL;
using Raflaaja.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raflaaja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController()
        {
        }

        [HttpGet]
        public List<User> Get()
        {
            var db = new DatabaseContext();
            return db.Users.ToList();
        }
    }
}
