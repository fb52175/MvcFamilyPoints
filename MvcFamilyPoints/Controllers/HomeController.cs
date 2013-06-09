using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyPoints.Domain;
using FamilyPoints.Service;

namespace MvcFamilyPoints.Controllers
{
    public class HomeController : Controller
    {
        //private FamilyPointsContext db = new FamilyPointsContext();
        static Factory factory = Factory.GetInstance();
        IRewardSvc rewardRepository = (IRewardSvc)factory.GetService("IRewardSvc");

        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View(rewardRepository.GetRewards());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Reward reward = rewardRepository.GetById(id);
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
                rewardRepository.Insert(reward);
                rewardRepository.Save();
                return RedirectToAction("Index");
            }

            return View(reward);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reward reward = rewardRepository.GetById(id);
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
                rewardRepository.Update(reward);
                rewardRepository.Save();
                return RedirectToAction("Index");
            }
            return View(reward);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reward reward = rewardRepository.GetById(id);
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
            Reward reward = rewardRepository.GetById(id);
            rewardRepository.Delete(reward);
            rewardRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            rewardRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}