using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raflaaja.DAL
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccessLevel { get; set; }
        public List<Order> Orders { get; set; }
    }
}
