using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizzeria.DAL.Models;
using Pizzeria.DAL.Data;

namespace Pizzeria.WebUI.Services.Decorator
{
    abstract class PizzaDecorator:AbstractPizza
    {
        protected AbstractPizza pizza;
        public PizzaDecorator(string n, AbstractPizza pizza):base(n)
        {
            this.pizza = pizza;
        }
   
    }
}