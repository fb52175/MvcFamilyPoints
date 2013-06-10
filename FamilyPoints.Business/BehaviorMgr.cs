using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Domain;
using FamilyPoints.Service;

namespace FamilyPoints.Business
{
    public class BehaviorMgr
    {
        public void Create(Behavior behavior)
        {
            Factory factory = Factory.GetInstance();
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)factory.GetService("IBehaviorSvc");

            behaviorSvc.Insert(behavior);
            behaviorSvc.Save();
        }

        public void Update(Behavior behavior, string description, int points)
        {
            Factory factory = Factory.GetInstance();
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)factory.GetService("IBehaviorSvc");
            behavior.Description = description;
            behavior.Points = points;
            behaviorSvc.Update(behavior);
            behaviorSvc.Save();
        }

        public void Delete(Behavior behavior)
        {
            Factory factory = Factory.GetInstance();
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)factory.GetService("IBehaviorSvc");

            behaviorSvc.Delete(behavior);
            behaviorSvc.Save();
        }

        public Behavior Find(int id)
        {
            Factory factory = Factory.GetInstance();
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)factory.GetService("IBehaviorSvc");
            return behaviorSvc.GetById(id);
        }

        public IEnumerable<Behavior> GetBehaviors()
        {
            Factory factory = Factory.GetInstance();
            IBehaviorSvc behaviorSvc = (IBehaviorSvc)factory.GetService("IBehaviorSvc");
            return behaviorSvc.GetBehaviors();
        }
    }
}
