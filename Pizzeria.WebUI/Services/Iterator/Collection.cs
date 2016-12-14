using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizzeria.DAL.Data;
using Pizzeria.DAL.Models;

namespace Pizzeria.WebUI.Services.Iterator
{
    public class Collection : IAbstractCollection
    {
        private DataContext context = new DataContext();
        
       
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
        public int Count
        {
            get { return context.Carts.ToList().Count; }
        }

        public object this[int index]
        {
            get { return context.Carts.ToList()[index-1]; }

        }
    }
}