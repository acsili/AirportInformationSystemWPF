using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.DAL.Repositories
{
    internal class CashierRepository : ICashierRepository
    {
        private ApplicationContext _context;
        public CashierRepository() 
        {
            _context = new ApplicationContext();
        }
        public async Task Create(Cashier item)
        {
            await _context.Cashiers.AddAsync(item);
        }

        public void Delete(int id)
        {
            var cashier = _context.Cashiers.Find(id);
            if (cashier != null)
                _context.Cashiers.Remove(cashier);
        }

        public IEnumerable<Cashier> GetAll()
        {
            return _context.Cashiers;
        }

        public Task<Cashier> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cashier> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task Load()
        {
            await _context.Cashiers.LoadAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public ObservableCollection<Cashier> ToObservableCollection()
        {
            return _context.Cashiers.Local.ToObservableCollection();
        }

        public Task Update(Cashier item)
        {
            throw new NotImplementedException();
        }
    }
}
