using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.Model;
using Microsoft.EntityFrameworkCore;

namespace AirportInformationSystemWPF.DAL.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        ApplicationContext _context;

        public TicketRepository()
        {
            _context = new ApplicationContext();
        }

        public void Create(Ticket item)
        {
            _context.Tickets.Add(item);
        }

        public void Delete(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }
        }

        public List<Ticket> GetAll()
        {
            return _context.Tickets.Include(x => x.Cashier).Include(x => x.Flight).ToList();
        }

        public Ticket GetById(int id)
        {
            return _context.Tickets.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
