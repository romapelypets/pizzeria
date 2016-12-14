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
    public interface ICartProcessingService
    {
        ShoppingCart GetCart(HttpContextBase context);

        string GetCartId(HttpContextBase context);

        List<Cart> GetCartItems(ShoppingCart shopingCart);

        void MigrateCart(string userName, ShoppingCart shopingCart);
    }
}
