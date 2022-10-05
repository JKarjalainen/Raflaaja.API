using System;
using System.Collections.Generic;
using System.Text;

namespace Raflaaja.DAL.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
