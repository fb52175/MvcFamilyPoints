using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;

namespace FamilyPoints.Business
{
    public class RewardMgr
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
            Factory factory = Factory.GetInstance();
            IRewardSvc rewardSvc = (IRewardSvc)factory.GetService("IRewardSvc", context);

            rewardSvc.Insert(reward);
            rewardSvc.Save();
        }

        public void Update(Reward reward, string description, int points)
        {
            Factory factory = Factory.GetInstance();
            IRewardSvc rewardSvc = (IRewardSvc)factory.GetService("IRewardSvc", context);
            reward.Description = description;
            reward.Points = points;
            rewardSvc.Update(reward);
            rewardSvc.Save();
        }

        public void Delete(Reward reward)
        {
            Factory factory = Factory.GetInstance();
            IRewardSvc rewardSvc = (IRewardSvc)factory.GetService("IRewardSvc", context);

            rewardSvc.Delete(reward);
            rewardSvc.Save();
        }

        public Reward Find(int id)
        {
            Factory factory = Factory.GetInstance();
            IRewardSvc rewardSvc = (IRewardSvc)factory.GetService("IRewardSvc", context);
            return rewardSvc.GetById(id);
        }

        public IEnumerable<Reward> GetRewards()
        {
            Factory factory = Factory.GetInstance();
            IRewardSvc rewardSvc = (IRewardSvc)factory.GetService("IRewardSvc", context);
            return rewardSvc.GetAll();
        }
    }
}
