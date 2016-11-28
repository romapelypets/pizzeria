using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.DAL.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public int PizzaId { get; set; }
        public int Count { get; set; }

        public virtual Pizza Pizza { get; set;  }
    }
}
