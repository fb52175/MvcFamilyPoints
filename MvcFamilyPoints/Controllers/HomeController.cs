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
    public class HomeController : Controller
    {
        //private FamilyPointsContext db = new FamilyPointsContext();
        RewardMgr mgr = new RewardMgr();

        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View(mgr.GetRewards());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Reward reward = mgr.Find(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            return View(reward);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reward reward)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(reward);
                return RedirectToAction("Index");
            }

            return View(reward);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reward reward = mgr.Find(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            return View(reward);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reward reward)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(reward);
                return RedirectToAction("Index");
            }
            return View(reward);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reward reward = mgr.Find(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            return View(reward);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reward reward = mgr.Find(id);
            mgr.Delete(reward);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            mgr.context.Dispose();
            base.Dispose(disposing);
        }
    }
}