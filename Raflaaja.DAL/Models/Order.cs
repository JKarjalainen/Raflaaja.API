using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raflaaja.DAL
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime TimeOrdered { get; set; }
        public bool Delivered { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
