using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyPoints.Domain;
using FamilyPoints.Service;

namespace FamilyPoints.MVC.Controllers
{
    public class ChildController : Controller
    {
        private FamilyPointsContext db = new FamilyPointsContext();

        //
        // GET: /Child/

        public ActionResult Index()
        {
            var children = db.Children.Include(c => c.Family);
            return View(children.ToList());
        }

        //
        // GET: /Child/Details/5

        public ActionResult Details(int id = 0)
        {
            Child child = db.Children.Find(id);
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
            ViewBag.FamilyId = new SelectList(db.Families, "FamilyId", "FamilyName");
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
                db.Children.Add(child);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FamilyId = new SelectList(db.Families, "FamilyId", "FamilyName", child.FamilyId);
            return View(child);
        }

        //
        // GET: /Child/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Child child = db.Children.Find(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyId = new SelectList(db.Families, "FamilyId", "FamilyName", child.FamilyId);
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
                db.Entry(child).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FamilyId = new SelectList(db.Families, "FamilyId", "FamilyName", child.FamilyId);
            return View(child);
        }

        //
        // GET: /Child/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Child child = db.Children.Find(id);
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
            Child child = db.Children.Find(id);
            db.Children.Remove(child);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}