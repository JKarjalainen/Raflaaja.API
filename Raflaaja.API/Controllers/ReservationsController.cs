using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raflaaja.API.Models;
using Raflaaja.DAL;
using Raflaaja.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Raflaaja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        // GET: api/<ReservationsController>
        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            using var db = new DatabaseContext();
            var reservations = db.Reservations.Include(x => x.User).ToList();
            foreach (var reservation in reservations)
            {
                var reserved = db.Reserved.Where(x => x.ReservationId == reservation.ReservationId);
                var reservedTableIds = reserved.Select(x => x.TableNumber).ToList();
                var tables = db.Tables.Where(x => reservedTableIds.Contains(x.TableNumber)).ToList();
                reservation.Tables = tables;

            }


            return reservations;
        }

        // GET api/<ReservationsController>/5
        [HttpGet("{date}")]
        public List<ReservedTimes> Get(DateTime date)
        {
            using var db = new DatabaseContext();
            var resevationsOnDay = db.Reservations.Where(x => x.StartTime.Day == date.Day).ToList();
            var hoursReserved = resevationsOnDay.Select(x => new ReservedTimes
            {
                ReservedHour = x.StartTime.Hour,
                ReservedTables = x.Tables
            }).ToList();

            return hoursReserved;
        }

        // POST api/<ReservationsController>
        [HttpPost]
        public void Post([FromBody] Reservation value)
        {
            using var db = new DatabaseContext();
            db.Reservations.Add(value);
            db.SaveChanges();
        }

        // PUT api/<ReservationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReservationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
