using Pizzeria.DAL.Data;
using Pizzeria.DAL.Models;
using Pizzeria.WebUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzeria.WebUI.Services.Impl
{
    public class CartProcessingService:ICartProcessingService
    {
        DataContext db = new DataContext();

        public ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = GetCartId(context);
            return cart;
        }

        public List<Cart> GetCartItems(ShoppingCart shopingCart)
        {
            return db.Carts.Where(item => item.CartId == shopingCart.ShoppingCartId).ToList();
        }

        public void MigrateCart(string userName, ShoppingCart shopingCart)
        {
            var shoppingCart = db.Carts.Where(item => item.CartId == shopingCart.ShoppingCartId);
            foreach (var item in shoppingCart)
            {
                item.CartId = userName;
            }
            db.SaveChanges();
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[ShoppingCart.CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[ShoppingCart.CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[ShoppingCart.CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[ShoppingCart.CartSessionKey].ToString();
        }

    }
}