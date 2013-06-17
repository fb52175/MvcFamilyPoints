using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyPoints.Business;
using FamilyPoints.Domain;
using FamilyPoints.Service;

namespace FamilyPoints.MVC.Controllers
{
    public class ParentController : Controller
    {
        private ParentMgr mgr = new ParentMgr();

        //
        // GET: /Parent/

        public ActionResult Index()
        {
            var parents = mgr.context.Parents.Include(p => p.Family);
            return View(mgr.GetParents());
        }

        //
        // GET: /Parent/Details/5

        public ActionResult Details(int id = 0)
        {
            Parent parent = mgr.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        //
        // GET: /Parent/Create

        public ActionResult Create()
        {
            ViewBag.FamilyId = new SelectList(mgr.context.Families, "FamilyId", "FamilyName");
            return View();
        }

        //
        // POST: /Parent/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Parent parent)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(parent);
                return RedirectToAction("Index");
            }

            ViewBag.FamilyId = new SelectList(mgr.context.Families, "FamilyId", "FamilyName", parent.FamilyId);
            return View(parent);
        }

        //
        // GET: /Parent/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Parent parent = mgr.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyId = new SelectList(mgr.context.Families, "FamilyId", "FamilyName", parent.FamilyId);
            return View(parent);
        }

        //
        // POST: /Parent/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Parent parent)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(parent);
                return RedirectToAction("Index");
            }
            ViewBag.FamilyId = new SelectList(mgr.context.Families, "FamilyId", "FamilyName", parent.FamilyId);
            return View(parent);
        }

        //
        // GET: /Parent/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Parent parent = mgr.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        //
        // POST: /Parent/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parent parent = mgr.Find(id);
            mgr.Delete(parent);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            mgr.context.Dispose();
            base.Dispose(disposing);
        }
    }
}