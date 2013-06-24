using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyPoints.Domain;
using FamilyPoints.Service;
using FamilyPoints.Business;

namespace FamilyPoints.MVC.Controllers
{
    public class HomeController : Controller
    {
        private ChildMgr mgr = new ChildMgr();

        public ActionResult Index()
        {
            ViewBag.Message = "A behavior/reward tracking application";

            return View(mgr.GetChildren());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

     

    }
}
