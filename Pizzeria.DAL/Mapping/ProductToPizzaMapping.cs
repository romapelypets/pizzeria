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
    public class ProductToPizzaMapping: EntityTypeConfiguration<ProductToPizza>
    {
        public ProductToPizzaMapping()
        {
            HasKey(item => new { item.PizzaId, item.ProductId });

            ToTable("ProductToPizza");
        }
    }
}
