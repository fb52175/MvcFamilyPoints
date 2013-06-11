using System.Collections.Generic;

namespace FamilyPoints.Service
{
    public interface IRepository<T> where T :class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int Id);
        void Save();
        void Dispose();
    }
}

