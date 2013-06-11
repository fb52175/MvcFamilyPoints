using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FamilyPoints.Domain;
using System.Data.Entity;
using System.Data;

namespace FamilyPoints.Service
{
    public class RewardSvcImpl: Repository<Reward>, IRewardSvc
    {
        public RewardSvcImpl(FamilyPointsContext context)
            : base(context)
        { }

    } 

}

