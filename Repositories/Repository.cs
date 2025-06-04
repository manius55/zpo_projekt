using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Alcohols;

namespace zpo_projekt.Repositories
{
    internal class Repository <T> where T: class
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }


        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public void Add(T item)
        {
            DbSet.Add(item);
            DbContext.SaveChanges();
        }

        public void Update(T item)
        {
            DbSet.Update(item);
            DbContext.SaveChanges();
        }

        public void Remove(T item)
        {
            DbSet.Remove(item);
            DbContext.SaveChanges();
        }


        public T getById(int id)
        {
            return DbSet.Find(id);
        }

        public List<T> getAll()
        {
            return DbSet.ToList();
        }
    }
}
