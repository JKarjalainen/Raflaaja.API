using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raflaaja.API.Models;
using Raflaaja.DAL;
using Raflaaja.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public void Post([FromBody] NewReservationObject value)
        {
            using var db = new DatabaseContext();
            Reservation newReservation = new Reservation()
            {
                ReservationId = value.ReservationId,
                StartTime = value.StartTime,
                EndTime = value.StartTime.AddHours(1),
                NumberOfPeople = value.NumberOfPeople,
                UserId = value.UserId,

            };
            db.Reservations.Add(newReservation);
            foreach(var table in value.TableNumbers)
            {
                db.Reserved.Add(new Reserved() { ReservationId = value.ReservationId, TableNumber = table });
            }
            
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
    public class NewReservationObject
    {
        public int ReservationId { get; set; }
        public DateTime StartTime { get; set; }
        public int NumberOfPeople { get; set; }
        public int UserId { get; set; }
        public List<int> TableNumbers { get; set; }
    }
}
