using System.Collections.Generic;
using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    public interface IChildSvc :IService
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