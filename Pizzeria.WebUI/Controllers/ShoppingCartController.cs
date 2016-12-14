using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pizzeria.DAL.Models;
using Pizzeria.DAL.Data;
using Pizzeria.WebUI.Model;
using Pizzeria.WebUI.ViewModels;
using Pizzeria.WebUI.Services;
using Pizzeria.WebUI.Services.ServiceImpl;
using Pizzeria.WebUI.Services.Impl;

namespace Pizzeria.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly DataContext context;

        private Facade facade;

        public ShoppingCartController(DataContext context)
        {
            this.context = context;

            this.facade = new Facade(new OrderProcessingService(), new PaymentService(), new CartProcessingService());
        }

        public ActionResult Index()
        {      
            return View(facade.createShoppingCartViewModel(this.HttpContext));
        }

        public ActionResult AddToCart(int id)
        {
            facade.addPizzaToCart(context, this.HttpContext, id);
 
            return RedirectToAction("Index");
        }

        public ActionResult Toppings()
        {
            var toppings = context.Products.OrderByDescending(item => item.Id).ToList();

            return View(toppings); 
        }


        public ActionResult AddCustomToppping(int productId)
        {
            Pizza pizza = context.Pizzas.Where(item => item.Id == 2).FirstOrDefault();

            Product product = context.Products.Where(item => item.Id == productId).FirstOrDefault();
            pizza.Price += product.Price ;

            TempData["Price"] = pizza.Price;
            
            context.SaveChanges();
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            return Json(facade.removePizzaFromCart(context, this.HttpContext, Server, id));
        }

        public ActionResult CartSummary()
        {
            ViewData["CartCount"] = facade.getCartCount(this.HttpContext);
            return PartialView("CartSummary");
        }
    }
}