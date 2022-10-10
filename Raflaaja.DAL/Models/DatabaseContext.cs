using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Raflaaja.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raflaaja.DAL
{
    public class DatabaseContext : DbContext
    {
        //private string connectionString = @"Server=(localdb)\mssqllocaldb;Database=ProjectDB;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProjectDB;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<User>().ToTable("User").HasMany(x => x.Orders).WithOne();
            modelBuilder.Entity<Order>().Property(e => e.Delivered).HasConversion<int>();
            modelBuilder.Entity<Table>().ToTable("Table");
            modelBuilder.Entity<Reservation>().ToTable("Reservation").HasOne(x => x.User).WithMany();
            modelBuilder.Entity<Reserved>().ToTable("Reserved");
        }


       
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Reserved> Reserved { get; set; }

    }
}
