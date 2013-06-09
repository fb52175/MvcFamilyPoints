using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyPoints.Domain
{
    public class Reward
    {
        public int RewardID { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
    }
}