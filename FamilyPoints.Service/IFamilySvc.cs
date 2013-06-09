using System.Collections.Generic;
using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    public interface IFamilySvc
    {
        IEnumerable<Family> GetFamilies();
        Family GetById(int id);
        void Insert(Family family);
        void Delete(int familyId);
        void Delete(Family family);
        void Update(Family family);
        void Save();
        void Dispose();
    }
}