using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPointsDomain;

namespace FamilyPointsService
{
    class BehaviorRepositoryImpl : IBehaviorRepository
    {
        private FamilyPointsContext context;

        public BehaviorRepositoryImpl(FamilyPointsContext context)
        {
            this.context = context;
        }

        public IEnumerable<Behavior> GetBehaviors()
        {
            return context.Behaviors.ToList();
        }

        public Behavior GetById(int id)
        {
            return context.Behaviors.Find(id);
        }

        public void Insert(Behavior behavior)
        {
            context.Behaviors.Add(behavior);
        }

        public void Delete(int behaviorId)
        {
            Behavior behavior = context.Behaviors.Find(behaviorId);
            context.Behaviors.Remove(behavior);
        }

        public void Delete(Behavior behavior)
        {
            if (context.Entry(behavior).State == EntityState.Detached)
            {
                context.Behaviors.Attach(behavior);
            }
            context.Behaviors.Remove(behavior);
        }

        public void Update(Behavior behavior)
        {
            context.Entry(behavior).State = EntityState.Modified;
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
