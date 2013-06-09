using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FamilyPointsDomain;

namespace FamilyPointsService
{
    public interface IRepositoryBase<T> where T :class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(int id);
        void SaveChanges();
    }
}

