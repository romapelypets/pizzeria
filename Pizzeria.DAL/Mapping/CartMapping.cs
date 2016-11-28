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
    public class CartMapping: EntityTypeConfiguration<Cart>
    {
        public CartMapping()
        {
            HasKey(item => item.Id);

            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.CartId).IsRequired();
            Property(item => item.PizzaId).IsRequired();
            Property(item => item.Count).IsRequired();

            ToTable("Cart");

            HasRequired(item => item.Pizza).WithMany(item => item.Carts)
                .HasForeignKey(item => item.PizzaId).WillCascadeOnDelete(false);
        }
    }
}
