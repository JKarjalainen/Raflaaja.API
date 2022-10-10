using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raflaaja.DAL;
using Raflaaja.DAL.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Raflaaja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            using var db = new DatabaseContext();
            List<Order> orders = db.Orders.ToList();
            return orders;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public List<Order> Get(int id)
        {
            using var db = new DatabaseContext();
            return db.Orders.Where(x => x.UserId == id).ToList();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] Order value)
        {
            using var db = new DatabaseContext();
            db.Orders.Add(value);
            db.SaveChanges();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order value)
        {
            using var db = new DatabaseContext();
            Order o = db.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            o.TimeOrdered = value.TimeOrdered;
            o.Delivered = value.Delivered;
            o.UserId = value.UserId;

            db.SaveChanges();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using var db = new DatabaseContext();
            Order o = db.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            db.Orders.Remove(o);
            db.SaveChanges();
        }
    }
}
