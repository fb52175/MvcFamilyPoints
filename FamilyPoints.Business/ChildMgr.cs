using System.Linq;
using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;

namespace FamilyPoints.Business
{
    public class ChildMgr :Manager
    {
        public FamilyPointsContext context;

        public ChildMgr()
        {
            this.context=new FamilyPointsContext();
        }

        public ChildMgr(FamilyPointsContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(Child child)
        {
            IChildSvc childSvc = (IChildSvc)GetService(typeof(IChildSvc).Name, context);
            childSvc.Insert(child);
            childSvc.Save();
        }

        public void Update(Child child)
        {
            IChildSvc childSvc = (IChildSvc)GetService(typeof(IChildSvc).Name, context);
            childSvc.Update(child);
            childSvc.Save();
        }

        public void Delete(Child child)
        {
            IChildSvc childSvc = (IChildSvc)GetService(typeof(IChildSvc).Name, context);
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService(typeof(ITransactionSvc).Name, context);
            List<Transaction> TransactionsForChild =
                new List<Transaction>(transactionSvc.Find(c => c.ChildId.Equals(child.ChildId)));
            foreach (Transaction transaction in TransactionsForChild.ToList())
            {
                transactionSvc.Delete(transaction);
            }

            childSvc.Delete(child);
            childSvc.Save();
        }

        public Child Find(int id)
        {
            IChildSvc childSvc = (IChildSvc)GetService(typeof(IChildSvc).Name, context);
            return childSvc.GetById(id);
        }

        public IEnumerable<Child> GetChildren()
        {
            IChildSvc childSvc = (IChildSvc)GetService(typeof(IChildSvc).Name, context);
            foreach (var child in childSvc.GetAll())
            {
                CalculateCurrentPoints(child);
            }
            return childSvc.GetAll();
        }

        public void CalculateCurrentPoints(Child child)
        {
            IChildSvc childSvc = (IChildSvc)GetService(typeof(IChildSvc).Name, context);
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService(typeof(ITransactionSvc).Name, context);
            List<Transaction> transactionsForChild = 
                new List<Transaction>(transactionSvc.Find(c => c.ChildId.Equals(child.ChildId)));
           
            int totalRewards = 0;
            int totalBehaviors = 0;
            foreach (Transaction transaction in transactionsForChild)
            {        
                if (transaction.PointType == "Behavior")
                {
                    totalBehaviors = totalBehaviors + transaction.Points;
                }
                else if (transaction.PointType == "Reward")
                {
                    totalRewards = totalRewards + transaction.Points;
                }
            }

            child.CurrentPoints= totalBehaviors - totalRewards;
        }

    }
}
