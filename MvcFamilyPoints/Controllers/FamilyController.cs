using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyPoints.Domain;
using FamilyPoints.Business;

namespace MvcFamilyPoints.Controllers
{
    public class FamilyController : Controller
    {
        //private FamilyPointsContext db = new FamilyPointsContext();
        FamilyMgr mgr = new FamilyMgr();

        //
        // GET: /Family/

        public ActionResult Index()
        {
            return View(mgr.GetFamilies());
        }

        //
        // GET: /Family/Details/5

        public ActionResult Details(int id = 0)
        {
            Family family = mgr.Find(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        //
        // GET: /Family/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Family/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Family family)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(family);
                return RedirectToAction("Index");
            }

            return View(family);
        }

        //
        // GET: /Family/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Family family = mgr.Find(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        //
        // POST: /Family/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Family family)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(family);
                return RedirectToAction("Index");
            }
            return View(family);
        }

        //
        // GET: /Family/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Family family = mgr.Find(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        //
        // POST: /Family/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Family family = mgr.Find(id);
            mgr.Delete(family);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //mgr.Dispose();
            base.Dispose(disposing);
        }
    }
}