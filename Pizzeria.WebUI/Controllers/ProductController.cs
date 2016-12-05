using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pizzeria.DAL.Models;
using Pizzeria.DAL.Repository;

namespace Pizzeria.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IUnitOfWork unitOfWork;
        // GET: Product

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View(unitOfWork.ProductRepository.GetAll().ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ProductRepository.Create(product);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = unitOfWork.ProductRepository.Get(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var toUpdate = unitOfWork.ProductRepository.Get(product.Id);
                toUpdate.Name = product.Name;
                toUpdate.Price = product.Price;
                toUpdate.Time = product.Time;
                toUpdate.Count = product.Count;

                unitOfWork.ProductRepository.Update(toUpdate);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.ProductRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}