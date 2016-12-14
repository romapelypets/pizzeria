using Pizzeria.DAL.Models;
using Pizzeria.WebUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.WebUI.Services
{
    public interface IPaymentService
    {
        int GetCount(ShoppingCart shopingCart);

        decimal GetTotal(ShoppingCart shopingCart);

        int CreateOrder(Order order, ShoppingCart shopingCart);
    }
}
