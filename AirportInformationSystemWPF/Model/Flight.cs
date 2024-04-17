using AirportInformationSystemWPF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.Model
{
    public class Flight : IEntity
    {
        public int Id { get; set; }
        public string? Destination { get; set; } = string.Empty;
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int AirplaneId { get; set; }
        public int CheifPilotId { get; set; }
        public Airplane? Airplane { get; set; }
        public CheifPilot? CheifPilot { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
    }
}
