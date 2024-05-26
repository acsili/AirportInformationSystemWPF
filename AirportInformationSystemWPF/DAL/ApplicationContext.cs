using AirportInformationSystemWPF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.DAL
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; } = null!;
        public DbSet<Airplane> Airplanes { get; set; } = null!;
        public DbSet<AirplaneModel> AirplaneModels { get; set; } = null!;
        public DbSet<Cashier> Cashiers { get; set; } = null!;
        public DbSet<ChiefPilot> ChiefPilots { get; set; } = null!;
        public DbSet<Flight> Flights { get; set; } = null!;
        public DbSet<PassengerPassport> PassengerPassports { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AirportDB;Username=postgres;Password=54321");
        }
    }
}
