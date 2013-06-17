using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;

namespace FamilyPoints.Business
{
    public class BehaviorMgr : Manager
    {
        public FamilyPointsContext context;

        public BehaviorMgr()
        {
            this.context=new FamilyPointsContext();
        }

        public BehaviorMgr(FamilyPointsContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(Behavior behavior)
        {
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)GetService(typeof(IBehaviorSvc).Name, context);

            behaviorSvc.Insert(behavior);
            behaviorSvc.Save();
        }

        public void Update(Behavior behavior)
        {
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)GetService(typeof(IBehaviorSvc).Name, context);
            behaviorSvc.Update(behavior);
            behaviorSvc.Save();
        }

        public void Delete(Behavior behavior)
        {
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)GetService(typeof(IBehaviorSvc).Name, context);

            behaviorSvc.Delete(behavior);
            behaviorSvc.Save();
        }

        public Behavior Find(int id)
        {
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)GetService(typeof(IBehaviorSvc).Name, context);
            return behaviorSvc.GetById(id);
        }

        public IEnumerable<Behavior> GetBehaviors()
        {
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)GetService(typeof(IBehaviorSvc).Name, context);
            return behaviorSvc.GetAll();
        }
    }
}
