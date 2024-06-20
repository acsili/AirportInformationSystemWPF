using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.Model;

namespace AirportInformationSystemWPF.DAL.Repositories
{
    internal class CashierRepository : ICashierRepository
    {
        private ApplicationContext _context;
        public CashierRepository() 
        {
            _context = new ApplicationContext();
        }
        public void Create(Cashier item)
        {
            _context.Cashiers.Add(item);
        }

        public void Delete(int id)
        {
            var cashier = _context.Cashiers.Find(id);
            if (cashier != null)
                _context.Cashiers.Remove(cashier);
        }

        public List<Cashier> GetAll()
        {
            return _context.Cashiers.ToList();
        }

        public Cashier GetById(int id)
        {
            return _context.Cashiers.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Cashier item)
        {
            throw new NotImplementedException();
        }
    }
}
