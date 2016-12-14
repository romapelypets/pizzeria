using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Pizzeria.DAL.Data;
using Pizzeria.DAL.Models;

namespace Pizzeria.WebUI.Helpers
{
    public class FormAuth:IAuth
    {
        public void Authentificate(string username, bool remember)
        {
            FormsAuthentication.SetAuthCookie(username, remember);
           
        }

        public bool isValid(string username, string password)
        {
            using (var context = new DataContext())
            {
                var admin = context.Admins
                    .Where(item => item.UserName == username)
                    .FirstOrDefault();
                if (admin != null)
                    return (admin.Password == password);
            }
            return false;
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}