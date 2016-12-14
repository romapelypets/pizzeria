using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizzeria.DAL.Models;
using Pizzeria.DAL.Data;

namespace Pizzeria.WebUI.Services.Decorator
{
    class ProductPizza: PizzaDecorator
    {
        
        public ProductPizza(AbstractPizza p)
            :base(p.Name,p) { }

        public override decimal GetCost()
        {
            return pizza.GetCost();
        }
    }
}