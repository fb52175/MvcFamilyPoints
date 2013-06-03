using System.Collections.Generic;
using FamilyPointsDomain;

namespace FamilyPointsService
{
    public interface IRewardRepository
    {
        IEnumerable<Reward> GetRewards();
        Reward GetById(int id);
        void Insert(Reward reward);
        void Delete(int rewardId);
        void Delete(Reward reward);
        void Update(Reward reward);
        void Save();
        void Dispose();
    }
}