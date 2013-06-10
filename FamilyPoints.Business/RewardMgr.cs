using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Domain;
using FamilyPoints.Service;

namespace FamilyPoints.Business
{
    public class RewardMgr
    {
        public void Create(Reward reward)
        {
            Factory factory = Factory.GetInstance();
            IRewardSvc rewardSvc = (IRewardSvc)factory.GetService("IRewardSvc");

            rewardSvc.Insert(reward);
            rewardSvc.Save();
        }

        public void Update(Reward reward, string description, int points)
        {
            Factory factory = Factory.GetInstance();
            IRewardSvc rewardSvc = (IRewardSvc)factory.GetService("IRewardSvc");
            reward.Description = description;
            reward.Points = points;
            rewardSvc.Update(reward);
            rewardSvc.Save();
        }

        public void Delete(Reward reward)
        {
            Factory factory = Factory.GetInstance();
            IRewardSvc rewardSvc = (IRewardSvc)factory.GetService("IRewardSvc");

            rewardSvc.Delete(reward);
            rewardSvc.Save();
        }

        public Reward Find(int id)
        {
            Factory factory = Factory.GetInstance();
            IRewardSvc rewardSvc = (IRewardSvc)factory.GetService("IRewardSvc");
            return rewardSvc.GetById(id);
        }

        public IEnumerable<Reward> GetRewards()
        {
            Factory factory = Factory.GetInstance();
            IRewardSvc rewardSvc = (IRewardSvc)factory.GetService("IRewardSvc");
            return rewardSvc.GetRewards();
        }
    }
}
