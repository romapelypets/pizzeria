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
using Pizzeria.WebUI.Services.Impl;
using Pizzeria.WebUI.Services.ServiceImpl;

namespace Pizzeria.WebUI.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout

        private readonly DataContext context;

        private Facade facade;

        public CheckoutController(DataContext context)
        {
            this.context = context;

            this.facade = new Facade(new OrderProcessingService(), new PaymentService(), new CartProcessingService());
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

            facade.createOrder(context, this.HttpContext, order);

            return RedirectToAction("Index", "Home");
        }
    }
}