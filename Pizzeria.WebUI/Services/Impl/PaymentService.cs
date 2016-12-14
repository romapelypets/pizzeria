using Pizzeria.DAL.Data;
using Pizzeria.DAL.Models;
using Pizzeria.WebUI.Model;
using Pizzeria.WebUI.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzeria.WebUI.Services.ServiceImpl
{
    public class PaymentService : IPaymentService
    {
        DataContext db = new DataContext();

        IOrderProcessingService orderProcessingService = new OrderProcessingService();

        ICartProcessingService cartProcessingService = new CartProcessingService();

        public int GetCount(ShoppingCart shopingCart)
        {
            int? count =
                (from cartItems in db.Carts where cartItems.CartId == shopingCart.ShoppingCartId select (int?)cartItems.Count).Sum();
            return count ?? 0;
        }
        public decimal GetTotal(ShoppingCart shopingCart)
        {
            decimal? total = (from cartItems in db.Carts
                              where cartItems.CartId == shopingCart.ShoppingCartId
                              select (int?)cartItems.Count * cartItems.Pizza.Price).Sum();
            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order, ShoppingCart shopingCart)
        {

            var cartItems = cartProcessingService.GetCartItems(shopingCart);
            foreach (var item in cartItems)
            {
                var pizzaToOrder = new PizzaToOrder
                {
                    PizzaId = item.PizzaId,
                    OrderId = order.Id,
                    Quantity = item.Count,
                    UnitPrice = (item.Count * item.Pizza.Price)
                };
                db.PizzasToOrder.Add(pizzaToOrder);
            }

            db.SaveChanges();
            orderProcessingService.EmptyCart(shopingCart);
            return order.Id;
        }

    }
}