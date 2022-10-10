using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Raflaaja.DAL.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NumberOfPeople { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [NotMapped]
        public List<Table> Tables { get; set; }
    }
}
