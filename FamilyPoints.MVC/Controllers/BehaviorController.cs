using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyPoints.Domain;
using FamilyPoints.Service;
using FamilyPoints.Business;

namespace FamilyPoints.MVC.Controllers
{
    public class BehaviorController : Controller
    {
        private BehaviorMgr mgr = new BehaviorMgr();

        //
        // GET: /Behavior/

        public ActionResult Index()
        {
            return View(mgr.GetBehaviors());
        }

        //
        // GET: /Behavior/Details/5

        public ActionResult Details(int id = 0)
        {
            Behavior behavior = mgr.Find(id);
            if (behavior == null)
            {
                return HttpNotFound();
            }
            return View(behavior);
        }

        //
        // GET: /Behavior/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Behavior/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Behavior behavior)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(behavior);
                return RedirectToAction("Index");
            }

            return View(behavior);
        }

        //
        // GET: /Behavior/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Behavior behavior = mgr.Find(id);
            if (behavior == null)
            {
                return HttpNotFound();
            }
            return View(behavior);
        }

        //
        // POST: /Behavior/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Behavior behavior)
        {
            if (ModelState.IsValid)
            {
               mgr.Update(behavior);
                return RedirectToAction("Index");
            }
            return View(behavior);
        }

        //
        // GET: /Behavior/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Behavior behavior = mgr.Find(id);
            if (behavior == null)
            {
                return HttpNotFound();
            }
            return View(behavior);
        }

        //
        // POST: /Behavior/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Behavior behavior = mgr.Find(id);
            mgr.Delete(behavior);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            mgr.context.Dispose();
            base.Dispose(disposing);
        }
    }
}