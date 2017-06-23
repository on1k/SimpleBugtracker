using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetOne(int? id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void Save();
    }
}
