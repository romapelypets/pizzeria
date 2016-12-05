using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzeria.DAL.Models;
using Pizzeria.DAL.Data;
using System.Data.Entity;
namespace Pizzeria.DAL.Repository
{
    public class GenericRepository<T>: IRepository<T> where T:class
    {
        private DataContext context;
        private DbSet<T> dbSet;
        
        public GenericRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public T Get(int id)
        {
            return this.dbSet.Find(id);
        }
        public void Create(T item)
        {
            this.dbSet.Add(item);
            this.context.SaveChanges();
        }
        public void Update(T item)
        {

            

            this.context.SaveChanges();
           
        }

        public void Delete(int id)
        { 
            var toRemove = this.dbSet.Find(id);
            if (toRemove != null)
                this.dbSet.Remove(toRemove);
            this.context.SaveChanges();
        }
        public IEnumerable<T> GetAll()
        {
            return this.dbSet;
        }
    }
}
