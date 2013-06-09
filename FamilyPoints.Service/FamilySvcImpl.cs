using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    class FamilySvcImpl : IFamilySvc
    {
        private FamilyPointsContext context;

        public FamilySvcImpl(FamilyPointsContext dbcontext)
        {
            if (context == null)
                dbcontext = new FamilyPointsContext();
            this.context = dbcontext;
            if (context == null) throw new NullReferenceException("dbContext");
        }

        public IEnumerable<Family> GetFamilies()
        {
            return context.Families.ToList();
        }

        public Family GetById(int id)
        {
            return context.Families.Find(id);
        }

        public void Insert(Family family)
        {
            context.Families.Add(family);
        }

        public void Delete(int familyId)
        {
            Family family = context.Families.Find(familyId);
            context.Families.Remove(family);
        }

        public void Delete(Family family)
        {
            if (context.Entry(family).State == EntityState.Detached)
            {
                context.Families.Attach(family);
            }
            context.Families.Remove(family);
        }

        public void Update(Family family)
        {
            context.Entry(family).State = EntityState.Modified;
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
