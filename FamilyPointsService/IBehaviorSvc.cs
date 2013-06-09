using System.Collections.Generic;
using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    public interface IBehaviorSvc
    {
        IEnumerable<Behavior> GetBehaviors();
        Behavior GetById(int id);
        void Insert(Behavior behavior);
        void Delete(int behaviorId);
        void Delete(Behavior behavior);
        void Update(Behavior behavior);
        void Save();
        void Dispose();
    }
}