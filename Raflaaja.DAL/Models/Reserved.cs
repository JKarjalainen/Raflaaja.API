using System;
using System.Collections.Generic;
using System.Text;

namespace Raflaaja.DAL.Models
{
    public class Reserved
    {
        public int ReservedId { get; set; }
        public int ReservationId { get; set; }
        public int TableNumber { get; set; }
    }
}
