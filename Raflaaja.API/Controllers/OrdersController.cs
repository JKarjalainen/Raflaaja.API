using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raflaaja.DAL;
using Raflaaja.DAL.Models;
using System;
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
            List<Order> orders = db.Orders
                .Include(x => x.OrderIncludes)
                .ThenInclude(x => x.Product)
                .ToList();
            return orders;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public List<Order> Get(int id)
        {
            using var db = new DatabaseContext();
            return db.Orders
                .Include(x => x.OrderIncludes)
                .ThenInclude(x => x.Product)
                .Where(x => x.UserId == id).ToList();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] List<ProductWithAmount> values)
        {
            using var db = new DatabaseContext();

            var newOrder = new Order()
            {
                OrderId = db.Orders.Max(x => x.OrderId) + 1,
                TimeOrdered = DateTime.Now,
                UserId = 1,
                Delivered = false,
                OrderIncludes = new List<OrderIncludes>()
            };
            
            foreach(var prod in values)
            {
                newOrder.OrderIncludes.Add(new OrderIncludes() { Amount = prod.Amount, ProductId = prod.ProductId });
            }

            db.Orders.Add(newOrder);
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
    public class NewOrderObject
    {
        public List<ProductWithAmount> IncludedProductIds { get; set; }
    }
    public class ProductWithAmount
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
