using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSystem.Models;

namespace LoginSystem.Controllers
{
    public class CreateAccController : Controller
    {
        // GET: CreateAcc
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {
            using (LoginDataBaseEntities db = new LoginDataBaseEntities())
            {
                userModel.ImagePath = "~/Image/logindefault.jpg";
                if (db.Users.Any(x => x.UserName == userModel.UserName))
                {
                    ViewBag.DublicateMessage = "Username already exist!";
                    return View("AddOrEdit", userModel);
                }
                db.Users.Add(userModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("AddOrEdit", new User());
        }
    }
}