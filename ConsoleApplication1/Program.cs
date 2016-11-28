using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Reflection;
using System.Threading.Tasks;
using Pizzeria.DAL.Data;
using Pizzeria.DAL.Models;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DataContext())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new PizzaMaker { Id = 1, Name = "Name", Surname = "Surname" };
                db.PizzaMakers.Add(blog);
               // db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.PizzaMakers
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
