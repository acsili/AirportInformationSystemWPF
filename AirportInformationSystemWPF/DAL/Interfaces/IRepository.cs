using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInformationSystemWPF.DAL.Interfaces
{
    internal interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
        Task Save();
        Task Load();
        ObservableCollection<T> ToObservableCollection();

    }
}
