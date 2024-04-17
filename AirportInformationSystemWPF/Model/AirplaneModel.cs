using AirportInformationSystemWPF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.Model
{
    public class AirplaneModel : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public int AmountOfSeats { get; set; }
        public int MaximumSpeed { get; set; }
        public int RangeOfFlight { get; set; }
        public int Weight { get; set; }
        public List<Airplane> Airplanes { get; set; } = new();
    }
}
