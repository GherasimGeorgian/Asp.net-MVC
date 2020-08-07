using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSystem.Models;
using System.Data.Entity;
namespace LoginSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() // Creeam un View pentru Homecontroller, click stanga pe Index() si  AddView
        {

            MainPageModel mainModel = new MainPageModel();
            Stock stockmodel = new Stock();
            User userModel = new User();
            
            
            using (ProductDataBaseEntities db = new ProductDataBaseEntities())
            {
             stockmodel.ProductCollection = db.Products.ToList<Product>();
            }
            mainModel.stock = stockmodel;
            mainModel.user = userModel;

            return View(mainModel);
        }
        [HttpPost]
        public ActionResult AddImage(MainPageModel mainModel, HttpPostedFileBase file)
        {

           //salvam imaginea in baza de date
            Stock stockmodel = new Stock();
            User userModel = new User();

            using (ProductDataBaseEntities db = new ProductDataBaseEntities())
            {
                stockmodel.ProductCollection = db.Products.ToList<Product>();
            }
            mainModel.stock = stockmodel;

            using (LoginDataBaseEntities db = new LoginDataBaseEntities())
            {
                mainModel.user = db.Users.Where(x => x.UserID == mainModel.user.UserID).FirstOrDefault();
            }
            
            mainModel.user.ConfirmPassword = mainModel.user.Password;
                 string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                 string extension = Path.GetExtension(file.FileName);
                 fileName = fileName + DateTime.Now.ToString("yymmssfff")+ mainModel.user.UserName.ToString() + extension;
            mainModel.user.ImagePath = "~/Image/" + fileName;
                 fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                 file.SaveAs(fileName);
            // pana aici se salveaza in fisier, mai trebuie modificat in baza de date
             using (LoginDataBaseEntities db = new LoginDataBaseEntities())
              {
                  db.Entry(mainModel.user).State = EntityState.Modified;
                  db.SaveChanges();       
              }
              ModelState.Clear();
            return View("Index", mainModel);
        }

    }
}