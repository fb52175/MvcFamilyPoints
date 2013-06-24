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
    public class ChildController : Controller
    {
        private ChildMgr mgr = new ChildMgr();

        //
        // GET: /Child/

        public ActionResult Index()
        {
            var children = mgr.context.Children.Include(c => c.Family);
            return View(mgr.GetChildren());
        }

        //
        // GET: /Child/Details/5

        public ActionResult Details(int id = 0)
        {
            Child child = mgr.Find(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        //
        // GET: /Child/Create

        public ActionResult Create()
        {
            ViewBag.FamilyId = new SelectList(mgr.context.Families, "FamilyId", "FamilyName");
            return View();
        }

        //
        // POST: /Child/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Child child)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(child);
                return RedirectToAction("Index");
            }

            ViewBag.FamilyId = new SelectList(mgr.context.Families, "FamilyId", "FamilyName", child.FamilyId);
            return View(child);
        }

        //
        // GET: /Child/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Child child = mgr.Find(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyId = new SelectList(mgr.context.Families, "FamilyId", "FamilyName", child.FamilyId);
            return View(child);
        }

        //
        // POST: /Child/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Child child)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(child);
                return RedirectToAction("Index");
            }
            ViewBag.FamilyId = new SelectList(mgr.context.Families, "FamilyId", "FamilyName", child.FamilyId);
            return View(child);
        }

        //
        // GET: /Child/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Child child = mgr.Find(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        //
        // POST: /Child/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Child child = mgr.Find(id);
            mgr.Delete(child);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            mgr.context.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ChildSummary()
        {
            ViewBag.Message = "Child Summary page.";
            var children = mgr.context.Children.Include(c => c.Family);
            return View(children.ToList());
            
        }
    }
}