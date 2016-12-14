using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizzeria.DAL.Data;
using Pizzeria.DAL.Models;
namespace Pizzeria.WebUI.Services.Iterator
{
    public class Iterator:IAbstractIterator
    {
        private Collection collection;
        private int current = 1;
        public Iterator(Collection collection)
        {
            this.collection = collection;
        }
        public Cart First()
        {
            current = 1;
            return collection[current] as Cart;
        }
        public Cart Next()
        {
            current += 1;
            if (!isDone)
                return collection[current] as Cart;
            else
                return null;
        }
        
        public Cart CurrentCart {  get { return collection[current] as Cart; } }

        public bool isDone { get { return current > collection.Count; } }
    }
}