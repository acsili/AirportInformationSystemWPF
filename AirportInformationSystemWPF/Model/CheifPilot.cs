using AirportInformationSystemWPF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.Model
{
    public class CheifPilot : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty; 
        public string? Surname { get; set; } = string.Empty; 
        public int Experience { get; set; }
        public int Age { get; set; }
        public List<Flight> Flights { get; set; } = new();
    }
}
