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
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            using var db = new DatabaseContext();
            return db.Orders.ToList();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            using var db = new DatabaseContext();
            return db.Orders.Where(x => x.OrderId == id).FirstOrDefault();
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
            o.TimeDelivered = value.TimeDelivered;
            o.OrderUser = value.OrderUser;
            o.Delivered = value.Delivered;
            
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
