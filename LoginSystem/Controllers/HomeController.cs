using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() // Creeam un View pentru Homecontroller, click stanga pe Index() si  AddView
        {
            return View();
        }
    }
}