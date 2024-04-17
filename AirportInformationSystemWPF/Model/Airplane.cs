using AirportInformationSystemWPF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.Model
{
    public class Airplane : IEntity
    {
        public int Id { get; set; }
        public int AirplaneModelId { get; set; }
        public AirplaneModel? AirplaneModel { get; set; }
        public List<Flight> Flights { get; set; } = new();
    }
}
