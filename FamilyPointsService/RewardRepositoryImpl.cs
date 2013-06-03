using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPointsDomain;

namespace FamilyPointsService
{
    class RewardRepositoryImpl : IRewardRepository
    {
        private FamilyPointsContext context;

        public RewardRepositoryImpl(FamilyPointsContext context)
        {
            this.context = context;
        }

        public IEnumerable<Reward> GetRewards()
        {
            return context.Rewards.ToList();
        }

        public Reward GetById(int id)
        {
            return context.Rewards.Find(id);
        }

        public void Insert(Reward reward)
        {
            context.Rewards.Add(reward);
        }

        public void Delete(int rewardId)
        {
            Reward reward = context.Rewards.Find(rewardId);
            context.Rewards.Remove(reward);
        }

        public void Delete(Reward reward)
        {
            if (context.Entry(reward).State == EntityState.Detached)
            {
                context.Rewards.Attach(reward);
            }
            context.Rewards.Remove(reward);
        }

        public void Update(Reward reward)
        {
            context.Entry(reward).State = EntityState.Modified;
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
