using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pizzeria.DAL.Models;
using Pizzeria.DAL.Data;
using Pizzeria.WebUI.Helpers;
using Pizzeria.WebUI.Services.Iterator;

namespace Pizzeria.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuth authenticator;
        private readonly DataContext context;
        // GET: Account

        public AccountController(IAuth authenticator, DataContext context)
        {
            this.authenticator = authenticator;
            this.context = context;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login(string value)
        {
            TempData["returnUrl"] = value;
            TempData.Keep("returnUrl");
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (authenticator.isValid(admin.UserName,admin.Password))
                {
                    authenticator.Authentificate(admin.UserName, true);
                    string returnURL = null;
                    if (Request != null && Request.QueryString.HasKeys())
                    {

                        returnURL = (Request.QueryString["ReturnUrl"] == null) ? TempData["returnURL"].ToString() : Request.QueryString["ReturnUrl"];
                    }
                    TempData.Remove("returnUrl");
                    if (returnURL != null) Response.Redirect(returnURL);
                    else return RedirectToAction("Index","Account");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(admin);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            authenticator.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Popular()
        {
            var h = new Dictionary<string, int>();
            
            Collection collection = new Collection();

            Iterator iterator = collection.CreateIterator();
            for (var item = iterator.First(); !iterator.isDone; item = iterator.Next())
            {
                int res;
                if (h.TryGetValue(item.Pizza.Name, out res))
                    h[item.Pizza.Name] += 1 * item.Count;
                else
                    h.Add(item.Pizza.Name, 1*item.Count);            
            }

            ViewBag.Popular = h;
            return View();
        }
    }
}