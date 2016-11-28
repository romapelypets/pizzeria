using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria.DAL.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Time { get; set; }

        public int PizzaMakerId { get; set; }

        public virtual PizzaMaker PizzaMaker { get; set; }
        public virtual ICollection<ProductToPizza>  Products { get; set; }
        public virtual ICollection<PizzaToOrder> Orders { get; set; }
   
        public virtual ICollection<Cart> Carts { get; set; }



    }
}
