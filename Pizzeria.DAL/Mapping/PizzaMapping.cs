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
    public class PizzaMapping: EntityTypeConfiguration<Pizza>
    {
        public PizzaMapping()
        {
            HasKey(item => item.Id);

            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.Name).IsRequired();
            Property(item => item.Time).IsRequired();
            Property(item => item.Price).IsRequired();
            Property(item => item.PizzaMakerId).IsRequired();

            ToTable("Pizza");

            HasRequired(item => item.PizzaMaker).WithMany(item => item.Pizzas)
                .HasForeignKey(item => item.PizzaMakerId).WillCascadeOnDelete(false);

            HasMany(item => item.Products)
                .WithRequired(item => item.Pizza)
                .HasForeignKey(item => item.PizzaId);

            HasMany(item => item.Orders)
                .WithRequired(item => item.Pizza)
                .HasForeignKey(item => item.PizzaId);
        }
    }
}
