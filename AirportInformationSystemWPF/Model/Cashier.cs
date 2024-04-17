using AirportInformationSystemWPF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.Model
{
    public class Cashier : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public List<Ticket> Tickets { get; set; } = new();
    }
}
