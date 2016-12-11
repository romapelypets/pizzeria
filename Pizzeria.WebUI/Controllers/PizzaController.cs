using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pizzeria.DAL.Models;
using Pizzeria.DAL.Repository;

namespace Pizzeria.WebUI.Controllers
{
    public class PizzaController : Controller
    {
        private IUnitOfWork unitOfWork;
        // GET: Pizza
        public PizzaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View(unitOfWork.PizzaRepository.GetAll().ToList());
        }
       
        public ActionResult Delete(int id)
        {
            unitOfWork.PizzaRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}