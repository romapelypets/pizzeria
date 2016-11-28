using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria.DAL.Models
{
    public class ProductToPizza
    {
        public int PizzaId { get; set; }
        public int ProductId { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual Product Product { get; set; }

    }
}
