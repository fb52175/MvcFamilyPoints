using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;

namespace FamilyPoints.Business
{
    public class RewardMgr : Manager
    {
        public FamilyPointsContext context;

        public RewardMgr()
        {
            this.context=new FamilyPointsContext();
        }

        public RewardMgr(FamilyPointsContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(Reward reward)
        {
            IRewardSvc rewardSvc = (IRewardSvc)GetService(typeof(IRewardSvc).Name, context);
            rewardSvc.Insert(reward);
            rewardSvc.Save();
        }

        public void Update(Reward reward)
        {
            IRewardSvc rewardSvc = (IRewardSvc)GetService(typeof(IRewardSvc).Name, context);
            rewardSvc.Update(reward);
            rewardSvc.Save();
        }

        public void Delete(Reward reward)
        {
            IRewardSvc rewardSvc = (IRewardSvc)GetService(typeof(IRewardSvc).Name, context);
            rewardSvc.Delete(reward);
            rewardSvc.Save();
        }

        public Reward Find(int id)
        {
            IRewardSvc rewardSvc = (IRewardSvc)GetService(typeof(IRewardSvc).Name, context);
            return rewardSvc.GetById(id);
        }

        public IEnumerable<Reward> GetRewards()
        {
            IRewardSvc rewardSvc = (IRewardSvc)GetService(typeof(IRewardSvc).Name, context);
            return rewardSvc.GetAll();
        }
    }
}
