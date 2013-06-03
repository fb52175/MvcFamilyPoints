using System.Collections.Generic;
using FamilyPointsDomain;

namespace FamilyPointsService
{
    public interface IChildRepository
    {
        IEnumerable<Child> GetChildren();
        Child GetById(int id);
        void Insert(Child child);
        void Delete(int childId);
        void Delete(Child child);
        void Update(Child child);
        void Save();
        void Dispose();
    }
}