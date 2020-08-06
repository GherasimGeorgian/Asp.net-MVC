using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSystem.Models;

namespace LoginSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(LoginSystem.Models.User userModel) 
        { 
            using (LoginDataBaseEntities db = new LoginDataBaseEntities()) {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", userModel);

                }
                else
                {
                    Session["UserID"] = userDetails.UserID;
                    Session["UserName"] = userDetails.UserName;
                    return RedirectToAction("Index","Home");   // localhos/Home/Index  !!!! Trebuie sa creeam HomeControler ca sa functioneze!
                }
            }
       
        }
        public ActionResult LogOutFunction()
        {
            int UserId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index","Login");

        }
        [HttpPost]
        public ActionResult NewAccount()
        {
            return RedirectToAction("AddOrEdit", "CreateAcc");
        }
    }
}