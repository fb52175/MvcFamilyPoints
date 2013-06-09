using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FamilyPointsDomain;
using System.Data.Entity;
using System.Data;

namespace FamilyPointsService
{
    public class RewardRepository : RepositoryBase<Reward>, IRewardRepository 
    {
        public RewardRepository(FamilyPointsContext context)
            : base(context)
        { }

    } 

}

