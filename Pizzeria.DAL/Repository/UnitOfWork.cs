using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzeria.DAL.Models;
using Pizzeria.DAL.Data;


namespace Pizzeria.DAL.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private DataContext context = new DataContext();
        private IRepository<Product> productRepository;
        private IRepository<Pizza> pizzaRepository;
        private IRepository<PizzaMaker> pizzaMakerRepository;

        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }


        public IRepository<Pizza> PizzaRepository
        {
            get { return pizzaRepository ?? (pizzaRepository = new GenericRepository<Pizza>(context)); }
        }
        public IRepository<PizzaMaker> PizzaMakerRepository
        {
            get { return pizzaMakerRepository ?? (pizzaMakerRepository = new GenericRepository<PizzaMaker>(context)); }
        }
        public IRepository<Product> ProductRepository
        {
            get { return productRepository ?? (productRepository = new GenericRepository<Product>(context)); }
        }
       
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

}
