using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Pizzeria.DAL.Data;
using Pizzeria.DAL.Models;
using Pizzeria.WebUI.Controllers;

namespace Pizzeria.WebUI.Model
{
    public partial class ShoppingCart
    {
        DataContext db = new DataContext();

        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "cartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Pizza pizza)
        {
            var cartItem = db.Carts.SingleOrDefault(item => item.CartId == ShoppingCartId && item.PizzaId == pizza.Id);

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
                    CartId = ShoppingCartId,
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

        public int RemoveFromCart(int id)
        {
            var cartItem = db.Carts.SingleOrDefault(item => item.CartId == ShoppingCartId && item.PizzaId == id);
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

        public void EmptyCart()
        {
            var cartItems = db.Carts.Where(item => item.CartId == ShoppingCartId);
            foreach(var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }
            db.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(item => item.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            int? count =
                (from cartItems in db.Carts where cartItems.CartId == ShoppingCartId select (int?)cartItems.Count).Sum();
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            decimal? total = (from cartItems in db.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count * cartItems.Pizza.Price).Sum();
            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order)
        {
            
            var cartItems = GetCartItems();
            foreach(var item in cartItems)
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
            EmptyCart();
            return order.Id;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string userName)
        {
            var shoppingCart = db.Carts.Where(item => item.CartId == ShoppingCartId);
            foreach(var item in shoppingCart)
            {
                item.CartId = userName;
            }
            db.SaveChanges();
        }
    }
}