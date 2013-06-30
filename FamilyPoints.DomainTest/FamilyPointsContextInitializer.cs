using System;
using FamilyPoints.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyPoints.Domain;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;


namespace MvcFamilyPoints.Tests
{
    public class FamilyPointsContextInitializer : DropCreateDatabaseAlways<FamilyPointsContext>
    {
        /// <summary>
        /// Seed the database with records for each domain object.
        /// Some of the unit tests will use these objects
        /// </summary>
        protected override void Seed(FamilyPointsContext context)
        {
            var rewards = new List<Reward> { new Reward()
                                                {
                                                    Description = "30 minutes of TV",
                                                    Points = 2
                                                }
        };

            var behaviors = new List<Behavior> { new Behavior()
                                                {
                                                    Description = "Make Bed",
                                                    Points = 2
                                                }
        };
            behaviors.Add(new Behavior()
                                                 {
                                                     Description = "Brush Teeth",
                                                     Points = 1
                                                 });

            var parents = new List<Parent> { new Parent()
                                                {
                                                    Name = "Mom",
                                                    Password = "Mom",
                                                    EMail = "Mom@familyPoints.net"
                                                }
        };
            var children = new List<Child> { new Child()
                                                {
                                                    Name = "John",
                                                    Password = "John"
                                                }
        };

            var family = new List<Family> { new Family()
                                                {
                                                    FamilyName = "Doe",
                                                    //Parents = parents,
                                                    //Children= children

                                                    
                                                }
        };
            var transaction = new List<Transaction> { new Transaction()
                                                {
                                                    Date=DateTime.Now,
                                                    ParentId = 1,
                                                    ChildId = 1,
                                                    PointType="Behavior",
                                                    Description = "Brush Teeth",
                                                    Points=1
                                                }
        };

            rewards.ForEach(d => context.Rewards.Add(d));
            behaviors.ForEach(d => context.Behaviors.Add(d));
            parents.ForEach(d => context.Parents.Add(d));
            children.ForEach(d => context.Children.Add(d));
            family.ForEach(d => context.Families.Add(d));
            transaction.ForEach(d => context.Transactions.Add(d));
        }
    }

}
