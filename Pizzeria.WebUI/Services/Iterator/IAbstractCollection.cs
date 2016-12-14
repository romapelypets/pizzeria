using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzeria.WebUI.Services.Iterator;

namespace Pizzeria.WebUI.Services.Iterator
{
    interface IAbstractCollection
    {
        Iterator CreateIterator();
    }
}
