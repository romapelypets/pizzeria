using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizzeria.DAL.Models;
using Pizzeria.WebUI.Model;
using Pizzeria.DAL.Data;

namespace Pizzeria.WebUI.Services.ServiceImpl
{
    public class OrderProcessingService : IOrderProcessingService
    {
        DataContext db = new DataContext();

        public void AddToCart(Pizza pizza, ShoppingCart shopingCart)
        {
            var cartItem = db.Carts.SingleOrDefault(item => item.CartId == shopingCart.ShoppingCartId && item.PizzaId == pizza.Id);

            var product = db.Products.Where(item => item.Pizzas.Any(r => r.PizzaId == pizza.Id)).ToList();

            foreach (var p in product)
            {
                p.Count--;
            }

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    PizzaId = pizza.Id,
                    CartId = shopingCart.ShoppingCartId,
                    Count = 1
                };
                db.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
            db.SaveChanges();
        }

        public void EmptyCart(ShoppingCart shopingCart)
        {
            var cartItems = db.Carts.Where(item => item.CartId == shopingCart.ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }
            db.SaveChanges();
        }

        public int RemoveFromCart(int id, ShoppingCart shopingCart)
        {
            var cartItem = db.Carts.SingleOrDefault(item => item.CartId == shopingCart.ShoppingCartId && item.PizzaId == id);
            int itemCount = 0;

            var product = db.Products.Where(item => item.Pizzas.Any(r => r.PizzaId == id)).ToList();

            foreach (var p in product)
            {
                p.Count++;
            }

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }
            }

            db.SaveChanges();
            return itemCount;
        }
    }
}