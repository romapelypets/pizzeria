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
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        private readonly DataContext context;
        public ShoppingCartController(DataContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
        
            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var addedPizza = context.Pizzas.Single(item => item.Id == id);

            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedPizza);
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
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);

            decimal price = 0;
            TimeSpan time = TimeSpan.Zero ;
            foreach(var p in listProducts)
            {
                price += p.Price;
                time += p.Time;
            }

            TempData["Price"] = price ;
            TempData["Time"] = time ;
           
            //TempData["Products"] = listProducts;
         

            context.SaveChanges();

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);


        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            string pizzaName = context.Carts.FirstOrDefault(item => item.PizzaId == id).Pizza.Name;
            int itemCount = cart.RemoveFromCart(id);
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(pizzaName) + " has been removed from your shopping cart",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}