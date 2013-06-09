using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    class ParentSvcImpl : IParentSvc
    {
        private FamilyPointsContext context;

        public ParentSvcImpl(FamilyPointsContext dbcontext)
        {
            if (context == null)
                dbcontext = new FamilyPointsContext();
            this.context = dbcontext;
            if (context == null) throw new NullReferenceException("dbContext");
        }

        public IEnumerable<Parent> GetParents()
        {
            return context.Parents.ToList();
        }

        public Parent GetById(int id)
        {
            return context.Parents.Find(id);
        }

        public void Insert(Parent parent)
        {
            context.Parents.Add(parent);
        }

        public void Delete(int parentId)
        {
            Parent parent = context.Parents.Find(parentId);
            context.Parents.Remove(parent);
        }

        public void Delete(Parent parent)
        {
            if (context.Entry(parent).State == EntityState.Detached)
            {
                context.Parents.Attach(parent);
            }
            context.Parents.Remove(parent);
        }

        public void Update(Parent parent)
        {
            context.Entry(parent).State = EntityState.Modified;
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
