using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;

namespace FamilyPoints.Business
{
    public class BehaviorMgr
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
            Factory factory = Factory.GetInstance();
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)factory.GetService("IBehaviorSvc",context);

            behaviorSvc.Insert(behavior);
            behaviorSvc.Save();
        }

        public void Update(Behavior behavior, string description, int points)
        {
            Factory factory = Factory.GetInstance();
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)factory.GetService("IBehaviorSvc", context);
            behavior.Description = description;
            behavior.Points = points;
            behaviorSvc.Update(behavior);
            behaviorSvc.Save();
        }

        public void Delete(Behavior behavior)
        {
            Factory factory = Factory.GetInstance();
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)factory.GetService("IBehaviorSvc", context);

            behaviorSvc.Delete(behavior);
            behaviorSvc.Save();
        }

        public Behavior Find(int id)
        {
            Factory factory = Factory.GetInstance();
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)factory.GetService("IBehaviorSvc", context);
            return behaviorSvc.GetById(id);
        }

        public IEnumerable<Behavior> GetBehaviors()
        {
            Factory factory = Factory.GetInstance();
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)factory.GetService("IBehaviorSvc", context);
            return behaviorSvc.GetAll();
        }
    }
}
