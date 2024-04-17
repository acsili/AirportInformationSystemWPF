using AirportInformationSystemWPF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.Model
{
    public class PassengerPassport : IEntity
    {
        public int Id { get; set; }
        public string? Series { get; set; } = string.Empty;
        public string? Number { get; set; } = string.Empty;
        public Passenger? Passenger { get; set; }
    }
}
