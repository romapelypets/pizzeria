using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Pizzeria.DAL.Models;

namespace Pizzeria.DAL.Mapping
{
    class PizzaToOrderMapping: EntityTypeConfiguration<PizzaToOrder>
    {
        public PizzaToOrderMapping()
        {
            HasKey(item => new { item.PizzaId, item.OrderId });

            Property(item => item.Quantity).IsRequired();
            Property(item => item.UnitPrice).IsRequired();

            ToTable("PizzaToOrder");
        }
    }
}
