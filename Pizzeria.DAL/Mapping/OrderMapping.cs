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
    public class OrderMapping: EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            HasKey(item => item.Id);

            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.FirstName).IsRequired();
            Property(item => item.LastName).IsRequired();
            Property(item => item.Phone).IsRequired();
            Property(item => item.Email).IsRequired();
            Property(item => item.OrderTime).IsRequired();

            ToTable("Order");

            HasMany(item => item.Pizzas)
                .WithRequired(item => item.Order)
                .HasForeignKey(item => item.OrderId);
        }
    }
}
