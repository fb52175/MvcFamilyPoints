using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcFamilyPoints.Domain
{
    public class FamilyPointsContext : DbContext
    {
        public DbSet<Family> Familys { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Behavior> Behaviors { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}