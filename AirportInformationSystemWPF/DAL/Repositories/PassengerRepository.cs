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
    internal class PassengerRepository : IPassengerRepository
    {
        ApplicationContext _context;

        public PassengerRepository()
        {
            _context = new ApplicationContext();
        }

        public void Create(Passenger item)
        {
            _context.PassengerPassports.Add(item.PassengerPassport);
            _context.Passengers.Add(item);
        }

        public void Delete(int id)
        {
            var passenger = _context.Passengers.Find(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
            }
        }

        public List<Passenger> GetAll()
        {
            return _context.Passengers.Include(x => x.PassengerPassport).ToList();
        }

        public Passenger GetById(int id)
        {
            return _context.Passengers.Find(id);
        }

        public PassengerPassport GetPassengerPassport(int id)
        {
            return _context.PassengerPassports.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Passenger item)
        {
            throw new NotImplementedException();
        }
    }
}
