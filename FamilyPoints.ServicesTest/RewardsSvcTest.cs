using FamilyPoints.Domain;
using FamilyPoints.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace FamilyPoints.ServiceTests
{
    
    
    [TestClass]
    public class RewardSvcUnitTests
    {

        /// <summary>
        /// Test Method to Connect to the svc and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void RewardSvcRepositoryContainsData()
        {

            // arrange 
            FamilyPointsContext db = new FamilyPointsContext();
            Factory factory = Factory.GetInstance();
            IRewardSvc svc =(IRewardSvc)factory.GetService("IRewardSvc",db);


            // act -- go get the first record
            Reward savedObj = svc.GetById(1);

            // assert
            Assert.AreEqual(savedObj.RewardID, 1);

        }

        /// <summary>
        /// Test Method to Connect to the svc and add a record
        /// </summary>
        [TestMethod]
        public void SaveNewRewardSvc()
        {
            // arrange
            FamilyPointsContext db = new FamilyPointsContext();
            Factory factory = Factory.GetInstance();
            IRewardSvc svc = (IRewardSvc)factory.GetService("IRewardSvc",db);

            Reward obj = new Reward();
            obj.Description = "New Reward 1";
            obj.Points = 1;
            svc.Insert(obj);

            // act
            svc.Save();

            // Assert -- see if the record retreived from the database matches the one i just added
            Reward savedObj = svc.GetById(obj.RewardID);

            Assert.AreEqual(savedObj.Description, obj.Description);
            Assert.AreEqual(savedObj.Points, obj.Points);

            // cleanup
            svc.Delete(savedObj);
            svc.Save();
        }

        /// <summary>
        /// Test Method to Connect to the svc and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRewardSvc()
        {
            // arrange - Insert a record so that it can be updated.
            FamilyPointsContext db = new FamilyPointsContext();
            Factory factory = Factory.GetInstance();
            IRewardSvc svc = (IRewardSvc)factory.GetService("IRewardSvc",db);

            Reward obj = new Reward();
            obj.Description = "New Reward 2";
            obj.Points = 0;
            svc.Insert(obj);
            svc.Save();
           

            // act - retrieve the saved record and update it.
            Reward savedObj = svc.GetById(obj.RewardID);
            savedObj.Description = "An updated Reward 2";
            savedObj.Points = 2;
            svc.Update(savedObj);
            //svc.Save();
           
            // Assert -- see if the record retreived from the database matches the one i just updated
            Reward updatedObj = svc.GetById(obj.RewardID);

            Assert.AreEqual(updatedObj.Description, savedObj.Description);
            Assert.AreEqual(updatedObj.Points, savedObj.Points);

            // cleanup
            svc.Delete(updatedObj);
            svc.Save();
        }

        /// <summary>
        /// Test Method to Connect to the svc and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRewardSvc()
        {
            // arrange - Insert a record so that it can be updated.
            FamilyPointsContext db = new FamilyPointsContext();
            Factory factory = Factory.GetInstance();
            IRewardSvc svc = (IRewardSvc)factory.GetService("IRewardSvc",db);

            Reward obj = new Reward();
            obj.Description = "Delete this Reward";
            obj.Points = 3;
            svc.Insert(obj);
            svc.Save();

            // act - retrieve the saved record and then remove it.
            Reward savedObj = svc.GetById(obj.RewardID);
            svc.Delete(savedObj);
            svc.Save();

            // Assert -- see if the record deleted from the database exists
            Reward removedObj = svc.GetById(obj.RewardID);
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test Method to List the records in the svc.
        /// </summary>
        [TestMethod]
        public void ListofRewardsSvc()
        {
            // arrange - Add a record to be listed.
            FamilyPointsContext db = new FamilyPointsContext();
            Factory factory = Factory.GetInstance();
            IRewardSvc svc = (IRewardSvc)factory.GetService("IRewardSvc",db);

            Reward obj = new Reward();
            obj.Description = "Reward 1";
            obj.Points = 1;
            svc.Insert(obj);
            svc.Save();

            // act - retrieve the saved records and put them in a list.
            List<Reward> savedObjs = new List<Reward>(svc.GetAll());

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
