using System.Collections.Generic;
using FamilyPointsDomain;

namespace FamilyPointsService
{
    public interface IBehaviorRepository
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