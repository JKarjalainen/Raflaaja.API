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
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            using var db = new DatabaseContext();
            return db.Products.ToList();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            using var db = new DatabaseContext();
            return db.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            using var db = new DatabaseContext();
            db.Products.Add(value);
            db.SaveChanges();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            using var db = new DatabaseContext();
            Product p = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            p.Description = value.Description;
            p.Name = value.Name;
            p.Price = value.Price;
            db.SaveChanges();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using var db = new DatabaseContext();
            Product p = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            db.Products.Remove(p);
            db.SaveChanges();
        }
    }
}
