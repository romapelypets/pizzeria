using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.WebUI.Helpers
{
    public interface IAuth
    {
        void Authentificate(string username, bool remember);

        bool isValid(string username, string password);
        void SignOut();
    }
}
