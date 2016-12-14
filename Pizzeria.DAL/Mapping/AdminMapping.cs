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
    public class AdminMapping:EntityTypeConfiguration<Admin>
    {
        public AdminMapping()
        {
            HasKey(item => item.Id);

            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.UserName).IsRequired();
            Property(item => item.Password).IsRequired();

            ToTable("Admin");
        }
    }
}
