using AirportInformationSystemWPF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.Model
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int SeatNumber { get; set; }
        public int FlightId { get; set; }
        public int CashierId { get; set; }
        public Flight? Flight { get; set; }
        public Cashier? Cashier { get; set; }
        public List<Passenger> Passengers { get; set; } = new();
    }
}
