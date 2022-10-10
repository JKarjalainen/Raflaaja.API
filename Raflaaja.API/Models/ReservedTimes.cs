using Raflaaja.DAL.Models;
using System.Collections.Generic;

namespace Raflaaja.API.Models
{
    public class ReservedTimes
    {
        public int ReservedHour{ get; set; }
        public List<Table> ReservedTables { get; set; }
    }
}
