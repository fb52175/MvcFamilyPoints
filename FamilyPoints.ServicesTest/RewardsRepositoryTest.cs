using FamilyPoints.Domain;
using FamilyPoints.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace FamilyPoints.ServiceTests
{
    
    
    [TestClass]
    public class RewardsRepositoryUnitTests
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
        public void RewardsRepositoryFromFactoryContainsData()
        {

            // arrange 
            // note connection string is in app.config
            Factory factory = Factory.GetInstance();
            IRewardSvc repository =(IRewardSvc)factory.GetService("IRewardSvc");


            // act -- go get the first record
            Reward savedObj = repository.GetById(1);

            // assert
            Assert.AreEqual(savedObj.RewardID, 1);

        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void SaveNewRewardToRepositoryFromFactory()
        {
            // arrange

            // note connection string is in app.config  
            Factory factory = Factory.GetInstance();
            IRewardSvc repository = (IRewardSvc)factory.GetService("IRewardSvc");

            Reward obj = new Reward();
            obj.Description = "New Reward 1";
            obj.Points = 1;
            repository.Insert(obj);

            // act
            repository.Save();

            // Assert -- see if the record retreived from the database matches the one i just added
            Reward savedObj = repository.GetById(obj.RewardID);

            Assert.AreEqual(savedObj.Description, obj.Description);
            Assert.AreEqual(savedObj.Points, obj.Points);

            // cleanup
            repository.Delete(savedObj);
            repository.Save();
        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRewardInRepositoryFromFactory()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            Factory factory = Factory.GetInstance();
            IRewardSvc repository = (IRewardSvc)factory.GetService("IRewardSvc");

            Reward obj = new Reward();
            obj.Description = "New Reward 2";
            obj.Points = 0;
            repository.Insert(obj);
            repository.Save();
           

            // act - retrieve the saved record and update it.
            Reward savedObj = repository.GetById(obj.RewardID);
            savedObj.Description = "An updated Reward 2";
            savedObj.Points = 2;
            repository.Update(savedObj);
            //repository.Save();
           
            // Assert -- see if the record retreived from the database matches the one i just updated
            Reward updatedObj = repository.GetById(obj.RewardID);

            Assert.AreEqual(updatedObj.Description, savedObj.Description);
            Assert.AreEqual(updatedObj.Points, savedObj.Points);

            // cleanup
            repository.Delete(updatedObj);
            repository.Save();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRewardFromRepositoryFromFactory()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            Factory factory = Factory.GetInstance();
            IRewardSvc repository = (IRewardSvc)factory.GetService("IRewardSvc");

            Reward obj = new Reward();
            obj.Description = "Delete this Reward";
            obj.Points = 3;
            repository.Insert(obj);
            repository.Save();

            // act - retrieve the saved record and then remove it.
            Reward savedObj = repository.GetById(obj.RewardID);
            repository.Delete(savedObj);
            repository.Save();

            // Assert -- see if the record deleted from the database exists
            Reward removedObj = repository.GetById(obj.RewardID);
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test Method to List the records in the repository.
        /// </summary>
        [TestMethod]
        public void ListofRewardsInRepositoryFromFactory()
        {
            // arrange - Add a record to be listed.
            // note connection string is in app.config
            Factory factory = Factory.GetInstance();
            IRewardSvc repository = (IRewardSvc)factory.GetService("IRewardSvc");

            Reward obj = new Reward();
            obj.Description = "Reward 1";
            obj.Points = 1;
            repository.Insert(obj);
            repository.Save();

            // act - retrieve the saved records and put them in a list.
            List<Reward> savedObjs = new List<Reward>(repository.GetRewards());

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
