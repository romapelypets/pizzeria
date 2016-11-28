using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pizzeria.DAL.Models;
using Pizzeria.DAL.Data;
using Pizzeria.WebUI.Model;
using Pizzeria.WebUI.ViewModels;

namespace Pizzeria.WebUI.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout

        private readonly DataContext context;

        public CheckoutController(DataContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection value)
        {
            var order = new Order();
            TryUpdateModel(order);

            order.OrderTime = DateTime.Now;
            context.Orders.Add(order);
            context.SaveChanges();

            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.CreateOrder(order);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}