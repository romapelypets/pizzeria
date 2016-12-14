using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizzeria.DAL.Data;
using System.Web.Mvc;
using Pizzeria.DAL.Models;
using Pizzeria.DAL.Repository;

namespace Pizzeria.WebUI.Controllers
{
    public class PizzaController : Controller
    {
        private IUnitOfWork unitOfWork;

        private DataContext context;

        public PizzaController(IUnitOfWork unitOfWork, DataContext context)
        {
            this.unitOfWork = unitOfWork;
            this.context = context;
        }
        public ActionResult Index()
        {
            try {
                List<Product> products = new List<Product>();
                Product p1 = new Product { Name = "p1", Price = 666, Count = 666, Time = new TimeSpan() };
                Product p2 = new Product { Name = "p2", Price = 6666, Count = 6666, Time = new TimeSpan() };
                Pizza pizza = new Pizza { Name = "Math", Price = 1000, PizzaMakerId = 2, Time = new TimeSpan() };
                ProductToPizza pp1 = new ProductToPizza { Product = p1, Pizza = pizza };
                ProductToPizza pp2 = new ProductToPizza { Product = p2, Pizza = pizza };
                pizza.Products.Add(pp1);
                pizza.Products.Add(pp2);

                context.ProductsToPizzas.Add(pp1);
                context.ProductsToPizzas.Add(pp2);

                context.SaveChanges();
              
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return View(unitOfWork.PizzaRepository.GetAll().ToList());
        }

        // GET: Pizza
        [HttpPost]
        public ActionResult Create(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PizzaRepository.Create(pizza);
               
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.PizzaRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}