using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSystem.Models;
using System.Data.Entity;
namespace LoginSystem.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/Index
        public ActionResult Index()
        {
            using (ProductDataBaseEntities db = new ProductDataBaseEntities())
            {
                return View(db.Products.ToList());
            }
        }
        [HttpGet]
        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (ProductDataBaseEntities db = new ProductDataBaseEntities())
            {
                return View(db.Products.Where(x => x.IdProduct == id).FirstOrDefault());
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                using (ProductDataBaseEntities db = new ProductDataBaseEntities()) {
                    db.Products.Add(product);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (ProductDataBaseEntities db = new ProductDataBaseEntities())
            {
                return View(db.Products.Where(x => x.IdProduct == id).FirstOrDefault());
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                using (ProductDataBaseEntities db = new ProductDataBaseEntities())
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (ProductDataBaseEntities db = new ProductDataBaseEntities())
            {
                return View(db.Products.Where(x => x.IdProduct == id).FirstOrDefault());
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                 using (ProductDataBaseEntities db = new ProductDataBaseEntities())
                  {
                    Product product = db.Products.Where(x => x.IdProduct == id).FirstOrDefault();
                    db.Products.Remove(product);
                    db.SaveChanges();
                  }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
