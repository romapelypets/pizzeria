using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzeria.WebUI.Services.Decorator
{
    abstract class AbstractPizza
    {
        public string Name { get; set; }
        public AbstractPizza(string name)
        {
            this.Name = name;
        }

        public abstract decimal GetCost();
    }
}