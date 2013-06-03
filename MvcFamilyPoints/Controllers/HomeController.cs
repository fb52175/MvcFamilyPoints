using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyPointsDomain;
using FamilyPointsService;

namespace MvcFamilyPoints.Controllers
{
    public class HomeController : Controller
    {
        //private FamilyPointsContext db = new FamilyPointsContext();
        RepositoryFactory factory = new RepositoryFactory();

        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View(factory.RewardRepository.GetRewards());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Reward reward = factory.RewardRepository.GetById(id);
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
                factory.RewardRepository.Insert(reward);
                factory.RewardRepository.Save();
                return RedirectToAction("Index");
            }

            return View(reward);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reward reward = factory.RewardRepository.GetById(id);
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
                factory.RewardRepository.Update(reward);
                factory.RewardRepository.Save();
                return RedirectToAction("Index");
            }
            return View(reward);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reward reward = factory.RewardRepository.GetById(id);
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
            Reward reward = factory.RewardRepository.GetById(id);
            factory.RewardRepository.Delete(reward);
            factory.RewardRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            factory.RewardRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}