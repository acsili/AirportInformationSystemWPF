using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.Model;
using Microsoft.EntityFrameworkCore;
namespace AirportInformationSystemWPF.DAL.Repositories
{
    internal class AirplaneRepository : IAirplaneRepository
    {
        ApplicationContext _context;

        public AirplaneRepository()
        {
            _context = new ApplicationContext();
        }

        public void Create(Airplane item)
        {
            _context.Airplanes.Add(item);

        }

        public void Delete(int id)
        {
            var airplane = _context.Airplanes.Find(id);
            if (airplane != null) 
            {
                _context.Airplanes.Remove(airplane);
            }
        }

        public List<Airplane> GetAll()
        {
            return _context.Airplanes.Include(x => x.AirplaneModel).ToList();
        }

        public Airplane GetById(int id)
        {
            return _context.Airplanes.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Airplane item)
        {
            throw new NotImplementedException();
        }
    }
}
