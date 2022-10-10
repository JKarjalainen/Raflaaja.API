using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raflaaja.DAL;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Raflaaja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using var db = new DatabaseContext();
            return db.Users.Include(x => x.Orders).ToList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            using var db = new DatabaseContext();
            return db.Users.Where(x => x.UserId == id).FirstOrDefault();
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            using var db = new DatabaseContext();
            db.Users.Add(value);
            db.SaveChanges();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
