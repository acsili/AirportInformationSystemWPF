using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.DAL.Repositories
{
    internal class ChiefPilotRepository : IChiefPilotRepository
    {
        ApplicationContext _context;

        public ChiefPilotRepository()
        {
            _context = new ApplicationContext();
        }

        public void Create(ChiefPilot item)
        {
            _context.ChiefPilots.Add(item);
        }

        public void Delete(int id)
        {
            var chiefPilot = _context.ChiefPilots.Find(id);
            if (chiefPilot != null) 
            {
                _context.ChiefPilots.Remove(chiefPilot);
            }
        }

        public List<ChiefPilot> GetAll()
        {
            return _context.ChiefPilots.ToList();
        }

        public ChiefPilot GetById(int id)
        {
            return _context.ChiefPilots.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ChiefPilot item)
        {
            throw new NotImplementedException();
        }
    }
}
