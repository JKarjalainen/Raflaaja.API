using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raflaaja.DAL
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime TimeDelivered{ get; set; }
        public bool Delivered { get; set; }
        public User OrderUser { get; set; }
    }
}
