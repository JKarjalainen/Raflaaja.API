using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Raflaaja.DAL.Models
{
    public class Table
    {
        [Key]
        public int TableNumber { get; set; }
        public int Size { get; set; }
    }
}
