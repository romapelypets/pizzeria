using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzeria.DAL.Models;

namespace Pizzeria.DAL.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Pizza> PizzaRepository { get; }
        IRepository<PizzaMaker> PizzaMakerRepository { get; }
        IRepository<Product> ProductRepository { get; }
        void Save();
    }
}
