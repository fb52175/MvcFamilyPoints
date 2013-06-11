using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;

namespace FamilyPoints.Business
{
    public class ChildMgr
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
            Factory factory = Factory.GetInstance();
            IChildSvc childSvc = (IChildSvc)factory.GetService("IChildSvc", context);

            childSvc.Insert(child);
            childSvc.Save();
        }

        public void Update(Child child)
        {
            Factory factory = Factory.GetInstance();
            IChildSvc childSvc = (IChildSvc)factory.GetService("IChildSvc", context);
            childSvc.Update(child);
            childSvc.Save();
        }

        public void Delete(Child child)
        {
            Factory factory = Factory.GetInstance();
            IChildSvc childSvc = (IChildSvc)factory.GetService("IChildSvc", context);

            childSvc.Delete(child);
            childSvc.Save();
        }

        public Child Find(int id)
        {
            Factory factory = Factory.GetInstance();
            IChildSvc childSvc = (IChildSvc)factory.GetService("IChildSvc", context);
            return childSvc.GetById(id);
        }

        public IEnumerable<Child> GetChildren()
        {
            Factory factory = Factory.GetInstance();
            IChildSvc childSvc = (IChildSvc)factory.GetService("IChildSvc", context);
            return childSvc.GetAll();
        }
    }
}
