using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Pizzeria.DAL.Models
{
    public class PizzaToOrder
    {
        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }


        public virtual Pizza Pizza { get; set; }
        public virtual Order Order { get; set; }
    }
}
