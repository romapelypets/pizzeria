using Pizzeria.DAL.Models;
using Pizzeria.WebUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pizzeria.WebUI.Services
{
    public interface IOrderProcessingService
    {
        void AddToCart(Pizza pizza, ShoppingCart shopingCart);

        int RemoveFromCart(int id, ShoppingCart shopingCart);

        void EmptyCart(ShoppingCart shopingCart);
    }
}
