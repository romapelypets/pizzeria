using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pizzeria.DAL.Models;
using Pizzeria.DAL.Repository;

namespace Pizzeria.WebUI.Controllers
{
    public class PizzaMakerController : Controller
    {
        private IUnitOfWork unitOfWork;
        public PizzaMakerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: PizzaMaker
        public ActionResult Index()
        {
            return View(unitOfWork.PizzaMakerRepository.GetAll().ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PizzaMaker pizzaMaker)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PizzaMakerRepository.Create(pizzaMaker);
                unitOfWork.Save();
                return RedirectToAction("Index","PizzaMaker");
            }
            return View(pizzaMaker);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            PizzaMaker pizzaMaker = unitOfWork.PizzaMakerRepository.Get(id);
            if (pizzaMaker == null)
                return HttpNotFound();
            return View(pizzaMaker);
        }
        
        [HttpPost]
        public ActionResult Edit(PizzaMaker pizzaMaker)
        {
            if (ModelState.IsValid)
            {
                var toUpdate = unitOfWork.PizzaMakerRepository.Get(pizzaMaker.Id);
                toUpdate.Name = pizzaMaker.Name;
                toUpdate.Surname = pizzaMaker.Surname;

                unitOfWork.PizzaMakerRepository.Update(toUpdate);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(pizzaMaker);
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.PizzaMakerRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        
    }
}