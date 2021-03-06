﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcFamilyPoints.Domain;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;


namespace MvcFamilyPoints.Tests
{
    public class FamilyPointsContextInitializer : DropCreateDatabaseAlways<FamilyPointsContext>
    {

        protected override void Seed(FamilyPointsContext context)
        {
            var rewards = new List<Reward> { new Reward()
                                                {
                                                    Description = "Seed Reward",
                                                    Points = 1
                                                }
        };

            var behaviors = new List<Behavior> { new Behavior()
                                                {
                                                    Description = "Seed Behavior 1",
                                                    Points = 10
                                                }
        };
            behaviors.Add(new Behavior()
                                                 {
                                                     Description = "Seed Behavior 2",
                                                     Points = 10
                                                 });

            var parents = new List<Parent> { new Parent()
                                                {
                                                    Name = "Mom",
                                                    Password = "Mom"
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
                                                    Name = "Doe",
                                                    Parents = parents,
                                                    Children= children

                                                    
                                                }
        };
            var transaction = new List<Transaction> { new Transaction()
                                                {
                                                    Date=DateTime.Now,
                                                    ParentID = 1,
                                                    ChildID = 1,
                                                    PointType="Behavior",
                                                    Description = "A Behavior",
                                                    Points=1
                                                }
        };

            rewards.ForEach(d => context.Rewards.Add(d));
            behaviors.ForEach(d => context.Behaviors.Add(d));
            parents.ForEach(d => context.Parents.Add(d));
            children.ForEach(d => context.Children.Add(d));
            family.ForEach(d => context.Familys.Add(d));
            transaction.ForEach(d => context.Transactions.Add(d));
        }
    }

}
