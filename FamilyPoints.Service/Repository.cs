using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace FamilyPoints.Service
{
    public abstract class Repository<T> : IDisposable, IRepository<T> where T : class 
    { 
        private FamilyPointsContext context;
        private readonly IDbSet<T> dbset;
        
        public Repository(FamilyPointsContext context) 
        { 
            this.context = context;
            dbset = context.Set<T>();
        }

        public IEnumerable<T> GetAll() 
        {
            return dbset.ToList(); 
        }
        
        public T GetById(int id) 
        {
            return dbset.Find(id); 
        }

        public void Insert(T entity) 
        {
            dbset.Add(entity); 
        }

        public void Update(T entity) 
        {
            context.Entry(entity).State = EntityState.Modified; 
        }

        public void Delete(int id) 
        {
            T entity = dbset.Find(id);
            dbset.Remove(entity); 
        }

        public void Delete(T entity) 
        {
            if (context.Entry(entity).State == EntityState.Detached) 
            {
                dbset.Attach(entity); 
            }
            dbset.Remove(entity); 
        }
        public void Save() 
        { 
            context.SaveChanges(); 
        } 
        
        private bool disposed = false; 

        protected virtual void Dispose(bool disposing) 
        { 
            if (!this.disposed) 
            { 
                if (disposing) 
                { 
                    context.Dispose(); 
                } 
            } 
            this.disposed = true; 
        } 
        public void Dispose() 
        { 
            Dispose(true); 
            GC.SuppressFinalize(this); 
        }
    } 

}

