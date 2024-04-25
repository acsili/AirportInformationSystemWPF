using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.DAL.Repositories
{
    internal class AirplaneModelRepository : IAirplaneModelRepository
    {
        ApplicationContext _context;

        public AirplaneModelRepository()
        {
            _context = new ApplicationContext();
        }
        public void Create(AirplaneModel item)
        {
            _context.AirplaneModels.Add(item);
        }

        public void Delete(int id)
        {
            var airplaneModel = _context.AirplaneModels.Find(id);
            if (airplaneModel != null)
                _context.AirplaneModels.Remove(airplaneModel);
        }

        public List<AirplaneModel> GetAll()
        {
            return _context.AirplaneModels.ToList();
        }

        public AirplaneModel GetById(int id)
        {
            return _context.AirplaneModels.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(AirplaneModel item)
        {
            throw new NotImplementedException();
        }
    }
}
