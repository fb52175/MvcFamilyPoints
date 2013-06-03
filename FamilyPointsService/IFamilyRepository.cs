using System.Collections.Generic;
using FamilyPointsDomain;

namespace FamilyPointsService
{
    public interface IFamilyRepository
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