using Microsoft.AspNetCore.Mvc;
using Raflaaja.DAL;
using Raflaaja.DAL.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Raflaaja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        // GET: api/<TablesController>
        [HttpGet]
        public IEnumerable<Table> Get()
        {
            using var db = new DatabaseContext();
            return db.Tables.ToList();
        }

        // GET api/<TablesController>/5
        [HttpGet("{id}")]
        public Table Get(int id)
        {
            using var db = new DatabaseContext();
            return db.Tables.Where(x => x.TableNumber == id).FirstOrDefault();
        }

        // POST api/<TablesController>
        [HttpPost]
        public void Post([FromBody] Table value)
        {
            using var db = new DatabaseContext();
            db.Tables.Add(value);
            db.SaveChanges();
        }

        // PUT api/<TablesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Table value)
        {
            using var db = new DatabaseContext();
            Table t = db.Tables.Where(x => x.TableNumber == id).FirstOrDefault();
            t.TableNumber = value.TableNumber;
            t.Size = value.Size;
        }

        // DELETE api/<TablesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using var db = new DatabaseContext();
            Table t = db.Tables.Where(x => x.TableNumber == id).FirstOrDefault();
            db.Tables.Remove(t);
            db.SaveChanges();
        }
    }
}
