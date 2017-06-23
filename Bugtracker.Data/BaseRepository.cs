using Bugtracker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private MyDbContext db = new MyDbContext();

        public void Add(T entity)
        {
            DbEntityEntry dbEntry = db.Entry<T>(entity);
            db.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntry = db.Entry<T>(entity);
            dbEntry.State = EntityState.Deleted;
        }

        public void Edit(T entity)
        {
            DbEntityEntry dbEntry = db.Entry<T>(entity);
            dbEntry.State = EntityState.Modified;
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T GetOne(int? id)
        {
            return db.Set<T>().Find(id);
        }

        public void Save()
        {
            db.SaveChangesAsync();
        }
    }
}
