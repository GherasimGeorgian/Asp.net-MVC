using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSystem.Models;
namespace LoginSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() // Creeam un View pentru Homecontroller, click stanga pe Index() si  AddView
        {
            Stock stockmodel = new Stock();
            
            using (ProductDataBaseEntities db = new ProductDataBaseEntities())
            {
             stockmodel.ProductCollection = db.Products.ToList<Product>();
            }
            return View(stockmodel);
        }
      

    }
}