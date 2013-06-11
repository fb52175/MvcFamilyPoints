using FamilyPoints.Domain;
using System.Data.Entity;

namespace FamilyPoints.Service
{
    public class FamilyPointsContext : DbContext
    {
        public DbSet<Family> Families { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Behavior> Behaviors { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}