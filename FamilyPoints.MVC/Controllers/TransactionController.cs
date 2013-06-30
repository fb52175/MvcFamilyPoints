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
        private RewardMgr rewardMgr = new RewardMgr();
        private BehaviorMgr behaviorMgr = new BehaviorMgr();
        private ChildMgr childMgr = new ChildMgr();

        private void SetViewBagDescription(string pointType)
        {  
            SelectList selectItems = null;
            if (pointType == "Reward")
            {
                List<Reward> rewards = rewardMgr.GetRewards().ToList();
                selectItems = new SelectList(rewards, "Description", "Description");
               
            }
            else if (pointType == "Behavior")
            {
                List<Behavior> behaviors = behaviorMgr.GetBehaviors().ToList();
                selectItems = new SelectList(behaviors, "Description", "Description");
            
            }
            
            ViewBag.Description = selectItems;
        }

        //
        // GET: /Transaction/

        public ActionResult Index()
        {
            var transactions = mgr.context.Transactions.Include(t => t.Parent).Include(t => t.Child);
            return View(transactions.ToList());
        }

        public ActionResult ListTransactionsForChild(int childId)
        {
            Child child = childMgr.Find(childId);
            var transactions=mgr.GetTransactionsForChild(child);
            ViewData["ChildName"]=child.Name;
            childMgr.CalculateCurrentPoints(child);
            ViewData["CurrentPoints"] = child.CurrentPoints;
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
                return RedirectToAction("Index","Home");
            }

            ViewBag.ParentId = new SelectList(mgr.context.Parents, "ParentId", "Name", transaction.ParentId);
            ViewBag.ChildId = new SelectList(mgr.context.Children, "ChildId", "Name", transaction.ChildId);
            return View(transaction);
        }

      

        public ActionResult AddBehavior(int childId)
        {
            ViewBag.ParentId = new SelectList(mgr.context.Parents, "ParentId", "Name");
            Child child = childMgr.Find(childId);
            ViewData["ChildId"] = childId;
            ViewData["ChildName"] = child.Name;
            ViewData["PointType"] = "Behavior";
            SetViewBagDescription("Behavior");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBehavior(Transaction transaction)
        {
            //Get the behavior description and points.
            Behavior behavior = behaviorMgr.FindByDescription(transaction.Description);
            transaction.Points = behavior.Points;
            if (ModelState.IsValid)
            {
                mgr.Create(transaction);
                return RedirectToAction("ListTransactionsForChild", "Transaction", new { ChildId = transaction.ChildId });
            }

            ViewBag.ParentId = new SelectList(mgr.context.Parents, "ParentId", "Name", transaction.ParentId);
            return View(transaction);
        }

        public ActionResult AddReward(int childId)
        {
            ViewBag.ParentId = new SelectList(mgr.context.Parents, "ParentId", "Name");
            Child child = childMgr.Find(childId);
            ViewData["ChildId"] = childId;
            ViewData["ChildName"] = child.Name;
            ViewData["PointType"] = "Reward";
            SetViewBagDescription("Reward");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReward(Transaction transaction)
        {
            //Get the reward description and points.
            Reward reward = rewardMgr.FindByDescription(transaction.Description);
            transaction.Points = reward.Points;
            if (ModelState.IsValid)
            {
                mgr.Create(transaction);
                return RedirectToAction("ListTransactionsForChild", "Transaction", new { ChildId = transaction.ChildId });
            }

            ViewBag.ParentId = new SelectList(mgr.context.Parents, "ParentId", "Name", transaction.ParentId);
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