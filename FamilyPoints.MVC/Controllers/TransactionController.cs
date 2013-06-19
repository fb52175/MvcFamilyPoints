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
    public class TransactionController : Controller
    {
        private TransactionMgr mgr = new TransactionMgr();

        //
        // GET: /Transaction/

        public ActionResult Index()
        {
            var transactions = mgr.context.Transactions.Include(t => t.Parent).Include(t => t.Child);
            return View(transactions.ToList());
        }

        //
        // GET: /Transaction/Details/5

        public ActionResult Details(int id = 0)
        {
            Transaction transaction = mgr.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //
        // GET: /Transaction/Create

        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(mgr.context.Parents, "ParentId", "Name");
            ViewBag.ChildId = new SelectList(mgr.context.Children, "ChildId", "Name");
            return View();
        }

        //
        // POST: /Transaction/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(transaction);
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(mgr.context.Parents, "ParentId", "Name", transaction.ParentId);
            ViewBag.ChildId = new SelectList(mgr.context.Children, "ChildId", "Name", transaction.ChildId);
            return View(transaction);
        }

        //
        // GET: /Transaction/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Transaction transaction = mgr.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(mgr.context.Parents, "ParentId", "Name", transaction.ParentId);
            ViewBag.ChildId = new SelectList(mgr.context.Children, "ChildId", "Name", transaction.ChildId);
            return View(transaction);
        }

        //
        // POST: /Transaction/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(transaction);
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(mgr.context.Parents, "ParentId", "Name", transaction.ParentId);
            ViewBag.ChildId = new SelectList(mgr.context.Children, "ChildId", "Name", transaction.ChildId);
            return View(transaction);
        }

        //
        // GET: /Transaction/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Transaction transaction = mgr.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //
        // POST: /Transaction/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = mgr.Find(id);
            mgr.Delete(transaction);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            mgr.context.Dispose();
            base.Dispose(disposing);
        }
    }
}