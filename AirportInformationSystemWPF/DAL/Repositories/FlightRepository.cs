using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.DAL.Repositories
{
    internal class FlightRepository : IFlightRepository
    {
        ApplicationContext _context;

        public FlightRepository()
        {
            _context = new ApplicationContext();
        }
        public void Create(Flight item)
        {
            _context.Flights.Add(item);
        }

        public void Delete(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight != null)
                _context.Flights.Remove(flight);
        }

        public List<Flight> GetAll()
        {
            return _context.Flights.Include(x => x.Airplane!.AirplaneModel).Include(x => x.ChiefPilot).ToList();
        }

        public Flight GetById(int id)
        {
            return _context.Flights.Include(x => x.Tickets).ThenInclude(x => x.Passengers).ThenInclude(x => x.PassengerPassport).FirstOrDefault(x => x.Id == id)!;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Flight item)
        {
            throw new NotImplementedException();
        }
    }
}
