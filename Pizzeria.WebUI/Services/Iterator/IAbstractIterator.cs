using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzeria.DAL.Data;
using Pizzeria.DAL.Models;

namespace Pizzeria.WebUI.Services.Iterator
{
    interface IAbstractIterator
    {
        Cart First();
        Cart Next();
        bool isDone { get; }
        Cart CurrentCart { get; }
    }
}
