using FamilyPoints.Domain;
using FamilyPoints.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace MvcFamilyPoints.Tests
{
    
    
    [TestClass]
    public class RewardsUnitTests
    {
        [ClassInitialize()]
        public static void DataLayerSetup(TestContext testContext)
        {
            Database.SetInitializer<FamilyPointsContext>(new FamilyPointsContextInitializer());
        }

        /// <summary>
        /// Test Method to Connect to the repository and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void RewardsRepositoryContainsData()
        {

            // arrange 
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();

            // act -- go get the first record
            Reward savedObj = (from d in db.Rewards where d.RewardID == 1 select d).Single();

            // assert
            Assert.AreEqual(savedObj.RewardID, 1);

        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void SaveNewRewardToRepository()
        {
            // arrange

            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();


            Reward obj = new Reward();
            obj.Description = "New Reward 1";
            obj.Points = 1;
            db.Rewards.Add(obj);

            // act
            db.SaveChanges();

            // Assert -- see if the record retreived from the database matches the one i just added
            Reward savedObj = (from d in db.Rewards where d.RewardID == obj.RewardID select d).Single();

            Assert.AreEqual(savedObj.Description, obj.Description);
            Assert.AreEqual(savedObj.Points, obj.Points);

            // cleanup
            db.Rewards.Remove(savedObj);
            db.SaveChanges();
            
        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRewardInRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Reward obj = new Reward();
            obj.Description = "New Reward 2";
            obj.Points = 0;
            db.Rewards.Add(obj);
            db.SaveChanges();
           

            // act - retrieve the saved record and update it.
            Reward savedObj = (from d in db.Rewards where d.RewardID == obj.RewardID select d).Single();
            savedObj.Description = "An updated Reward 2";
            savedObj.Points = 2;
            db.SaveChanges();
           
            // Assert -- see if the record retreived from the database matches the one i just updated
            Reward updatedObj = (from d in db.Rewards where d.RewardID == obj.RewardID select d).Single();

            Assert.AreEqual(updatedObj.Description, savedObj.Description);
            Assert.AreEqual(updatedObj.Points, savedObj.Points);

            // cleanup
            db.Rewards.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRewardFromRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Reward obj = new Reward();
            obj.Description = "Delete this Reward";
            obj.Points = 3;
            db.Rewards.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved record and then remove it.
            Reward savedObj = (from d in db.Rewards where d.RewardID == obj.RewardID select d).Single();
            db.Rewards.Remove(savedObj);
            db.SaveChanges();

            // Assert -- see if the record deleted from the database exists
            Reward removedObj = (from d in db.Rewards where d.RewardID == savedObj.RewardID select d).FirstOrDefault();
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test Method to List the records in the repository.
        /// </summary>
        [TestMethod]
        public void ListofRewardsInRepository()
        {
            // arrange - Add a record to be listed.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Reward obj = new Reward();
            obj.Description = "Reward 1";
            obj.Points = 1;
            db.Rewards.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved records and put them in a list.
            List<Reward> savedObjs = (from d in db.Rewards select d).ToList();

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);

            // Cleanup
            db.Rewards.Remove(obj);
            db.SaveChanges();
        }



    }
}
