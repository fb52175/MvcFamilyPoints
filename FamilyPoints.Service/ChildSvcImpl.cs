using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    class ChildSvcImpl : IChildSvc
    {
        private FamilyPointsContext context;

        public ChildSvcImpl(FamilyPointsContext dbcontext)
        {
            if (context == null)
                dbcontext = new FamilyPointsContext();
            this.context = dbcontext;
            if (context == null) throw new NullReferenceException("dbContext");
        }

        public IEnumerable<Child> GetChildren()
        {
            return context.Children.ToList();
        }

        public Child GetById(int id)
        {
            return context.Children.Find(id);
        }

        public void Insert(Child child)
        {
            context.Children.Add(child);
        }

        public void Delete(int childId)
        {
            Child child = context.Children.Find(childId);
            context.Children.Remove(child);
        }

        public void Delete(Child child)
        {
            if (context.Entry(child).State == EntityState.Detached)
            {
                context.Children.Attach(child);
            }
            context.Children.Remove(child);
        }

        public void Update(Child child)
        {
            context.Entry(child).State = EntityState.Modified;
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
