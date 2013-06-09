using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FamilyPointsDomain;
using System.Data.Entity;
using System.Data;

namespace FamilyPointsService
{
    public abstract class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class 
    { 
        private FamilyPointsContext context;
        private readonly IDbSet<T> dbset;
        
        public RepositoryBase(FamilyPointsContext context) 
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

        public void Add(T entity) 
        {
            dbset.Add(entity); 
        }

        public void Update(T entity) 
        {
            context.Entry(entity).State = EntityState.Modified; 
        }

        public void Remove(int id) 
        {
            T entity = dbset.Find(id);
            dbset.Remove(entity); 
        }

        public void Remove(T entity) 
        {
            if (context.Entry(entity).State == EntityState.Detached) 
            {
                dbset.Attach(entity); 
            }
            dbset.Remove(entity); 
        }
        public void SaveChanges() 
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

