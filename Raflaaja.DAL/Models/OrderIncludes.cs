using System;
using System.Collections.Generic;
using System.Text;

namespace Raflaaja.DAL.Models
{
    public class OrderIncludes
    {

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
