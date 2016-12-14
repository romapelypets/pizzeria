using Pizzeria.DAL.Data;
using Pizzeria.DAL.Models;
using Pizzeria.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzeria.WebUI.Services
{
    public class Facade
    {
        private IOrderProcessingService orderProcessingService;

        private IPaymentService paymentService;

        private ICartProcessingService cartProcessingService;

        public Facade(IOrderProcessingService orderProcessingService, IPaymentService paymentService, ICartProcessingService cartProcessingService)
        {
            this.orderProcessingService = orderProcessingService;
            this.paymentService = paymentService;
            this.cartProcessingService = cartProcessingService;
        }

        public void addPizzaToCart(DataContext context, HttpContextBase httpContext, int id)
        {
            var addedPizza = context.Pizzas.Single(item => item.Id == id);
            var cart = cartProcessingService.GetCart(httpContext);
            orderProcessingService.AddToCart(addedPizza, cart);
        }

        public ShoppingCartRemoveViewModel removePizzaFromCart(DataContext context, HttpContextBase httpContext, HttpServerUtilityBase server, int id)
        {
            var cart = cartProcessingService.GetCart(httpContext);
            string pizzaName = context.Carts.FirstOrDefault(item => item.PizzaId == id).Pizza.Name;
         
            int itemCount = orderProcessingService.RemoveFromCart(id, cart);

            return new ShoppingCartRemoveViewModel
            {
                Message = server.HtmlEncode(pizzaName) + " has been removed from your shopping cart",
                CartTotal = getTotalPrice(httpContext),
                CartCount = getCartCount(httpContext),
                ItemCount = itemCount,
                DeleteId = id
            };
        }

        public int getCartCount(HttpContextBase httpContext)
        {
            var cart = cartProcessingService.GetCart(httpContext);

            return paymentService.GetCount(cart);
        }

        public List<Cart> getCartItems(HttpContextBase httpContext)
        {
            var cart = cartProcessingService.GetCart(httpContext);

           return cartProcessingService.GetCartItems(cart);
        }

        public decimal getTotalPrice(HttpContextBase httpContext)
        {
            var cart = cartProcessingService.GetCart(httpContext);

            return paymentService.GetTotal(cart);
        }

        public void createOrder(DataContext context, HttpContextBase httpContext, Order order)
        {
            order.OrderTime = DateTime.Now;
            context.Orders.Add(order);
            context.SaveChanges();

            var cart = cartProcessingService.GetCart(httpContext);
            paymentService.CreateOrder(order, cart);

            context.SaveChanges();
        }

        public ShoppingCartViewModel createShoppingCartViewModel(HttpContextBase httpContext)
        {
            return new ShoppingCartViewModel
            {
                CartItems = getCartItems(httpContext),
                CartTotal = getTotalPrice(httpContext)
            };
        }

    }
}