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
    public class ProductMapping: EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            HasKey(item => item.Id);

            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.Name).IsRequired();
            Property(item => item.Price).IsRequired();
            Property(item => item.Time).IsRequired();
            Property(item => item.Count);

            ToTable("Product");

            HasMany(item => item.Pizzas)
                .WithRequired(item => item.Product)
                .HasForeignKey(item => item.ProductId);

        }
    }
}
