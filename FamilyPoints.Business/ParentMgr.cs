using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;

namespace FamilyPoints.Business
{
    public class ParentMgr
    {
        public FamilyPointsContext context;

        public ParentMgr()
        {
            this.context=new FamilyPointsContext();
        }

        public ParentMgr(FamilyPointsContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(Parent parent)
        {
            Factory factory = Factory.GetInstance();
            IParentSvc parentSvc = (IParentSvc)factory.GetService("IParentSvc", context);

            parentSvc.Insert(parent);
            parentSvc.Save();
        }

        public void Update(Parent parent)
        {
            Factory factory = Factory.GetInstance();
            IParentSvc parentSvc = (IParentSvc)factory.GetService("IParentSvc", context);
            parentSvc.Update(parent);
            parentSvc.Save();
        }

        public void Delete(Parent parent)
        {
            Factory factory = Factory.GetInstance();
            IParentSvc parentSvc = (IParentSvc)factory.GetService("IParentSvc", context);

            parentSvc.Delete(parent);
            parentSvc.Save();
        }

        public Parent Find(int id)
        {
            Factory factory = Factory.GetInstance();
            IParentSvc parentSvc = (IParentSvc)factory.GetService("IParentSvc", context);
            return parentSvc.GetById(id);
        }

        public IEnumerable<Parent> GetParents()
        {
            Factory factory = Factory.GetInstance();
            IParentSvc parentSvc = (IParentSvc)factory.GetService("IParentSvc", context);
            return parentSvc.GetAll();
        }
    }
}
