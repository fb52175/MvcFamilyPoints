using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;

namespace FamilyPoints.Business
{
    public class ParentMgr :Manager
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
            IParentSvc parentSvc = (IParentSvc)GetService(typeof(IParentSvc).Name, context);
            parentSvc.Insert(parent);
            parentSvc.Save();
        }

        public void Update(Parent parent)
        {
            IParentSvc parentSvc = (IParentSvc)GetService(typeof(IParentSvc).Name, context);
            parentSvc.Update(parent);
            parentSvc.Save();
        }

        public void Delete(Parent parent)
        {
            IParentSvc parentSvc = (IParentSvc)GetService(typeof(IParentSvc).Name, context);
            parentSvc.Delete(parent);
            parentSvc.Save();
        }

        public Parent Find(int id)
        {
            IParentSvc parentSvc = (IParentSvc)GetService(typeof(IParentSvc).Name, context);
            return parentSvc.GetById(id);
        }

        public IEnumerable<Parent> GetParents()
        {
            IParentSvc parentSvc = (IParentSvc)GetService(typeof(IParentSvc).Name, context);
            return parentSvc.GetAll();
        }
    }
}
