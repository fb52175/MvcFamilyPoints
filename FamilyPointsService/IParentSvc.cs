using System.Collections.Generic;
using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    public interface IParentSvc
    {
        IEnumerable<Parent> GetParents();
        Parent GetById(int id);
        void Insert(Parent parent);
        void Delete(int parentId);
        void Delete(Parent parent);
        void Update(Parent parent);
        void Save();
        void Dispose();
    }
}