using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizzeria.DAL.Data;
using Pizzeria.DAL.Models;

namespace Pizzeria.WebUI.Services.Decorator
{
    class ClassicPizza: AbstractPizza
    {
        DataContext context = new DataContext();
        public ClassicPizza(): base("CLassicPizza") { }


        public override decimal GetCost()
        {
            Pizza pizza = context.Pizzas.Where(item => item.Id == 2).Single();
            return pizza.Price;
        }
    }
}