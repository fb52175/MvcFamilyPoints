using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    public class UnitOfWork : IDisposable
    {
        private FamilyPointsContext context = new FamilyPointsContext();
        private Repository<Reward> rewardRepository;
        private Repository<Behavior> behaviorRepository;
        private Repository<Family> familyRepository;
        private Repository<Parent> parentRepository;
        private Repository<Child> childRepository;
        private Repository<Transaction> transactionRepository;

        public Repository<Reward> RewardRepository
        {
            get { return rewardRepository ?? (rewardRepository = new Repository<Reward>(context)); }
        }

        public Repository<Behavior> BehaviorRepository
        {
            get { return behaviorRepository ?? (behaviorRepository = new Repository<Behavior>(context)); }
        }

        public Repository<Family> FamilyRepository
        {
            get { return familyRepository ?? (familyRepository = new Repository<Family>(context)); }
        }

        public Repository<Parent> ParentRepository
        {
            get { return parentRepository ?? (parentRepository = new Repository<Parent>(context)); }
        }

        public Repository<Child> ChildRepository
        {
            get { return childRepository ?? (childRepository = new Repository<Child>(context)); }
        }

        public Repository<Transaction> TransactionRepository
        {
            get { return transactionRepository ?? (transactionRepository = new Repository<Transaction>(context)); }
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
