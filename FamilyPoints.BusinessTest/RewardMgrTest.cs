using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyPoints.Business;
using FamilyPoints.Domain;

namespace FamilyPoints.BusinessTest
{
    [TestClass]
    public class RewardMgrTests
    {
        /// <summary>
        /// Test inserting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrInsertNewReward()
        {
            // arrange
            RewardMgr mgr = new RewardMgr();

            Reward obj = new Reward();
            obj.Description = "New Reward 1";
            obj.Points = 1;

            // act
            mgr.Create(obj);

            // Assert -- see if the record retreived from the database matches the one i just added
            Reward savedObj = mgr.Find(obj.RewardID);

            Assert.AreEqual(savedObj.Description, obj.Description);
            Assert.AreEqual(savedObj.Points, obj.Points);

            // cleanup
            mgr.Delete(savedObj);

        }

        /// <summary>
        /// Test updating an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrUpdateReward()
        {
            // arrange - Insert a record so that it can be updated.
            RewardMgr mgr = new RewardMgr();
            Reward obj = new Reward();
            obj.Description = "New Reward 2";
            obj.Points = 0;
            mgr.Create(obj);

            // act - retrieve the saved record and update it.
            Reward savedObj = mgr.Find(obj.RewardID);
            savedObj.Description = "An updated Reward 2";
            savedObj.Points = 2;
            mgr.Update(savedObj);

            // Assert -- see if the record retreived from the database matches the one i just updated
            Reward updatedObj = mgr.Find(savedObj.RewardID);

            Assert.AreEqual(updatedObj.Description, savedObj.Description);
            Assert.AreEqual(updatedObj.Points, savedObj.Points);

            // cleanup
            mgr.Delete(updatedObj);
        }

        /// <summary>
        ///  Test deleting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrDeleteReward()
        {
            // arrange - Insert a record so that it can be updated.
            RewardMgr mgr = new RewardMgr();
            Reward obj = new Reward();
            obj.Description = "Delete this Reward";
            obj.Points = 3;
            mgr.Create(obj);

            // act - retrieve the saved record and then remove it.
            Reward savedObj = mgr.Find(obj.RewardID);
            mgr.Delete(savedObj);

            // Assert -- see if the record deleted from the database exists
            Reward removedObj = mgr.Find(savedObj.RewardID);
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test listing objects with the manager
        /// </summary>
        [TestMethod]
        public void MgrGetRewards()
        {
            // arrange - Add a record to be listed.
            RewardMgr mgr = new RewardMgr();
            Reward obj = new Reward();
            obj.Description = "Reward 1";
            obj.Points = 1;
            mgr.Create(obj);

            Reward obj2 = new Reward();
            obj2.Description = "Reward 2";
            obj2.Points = 2;
            mgr.Create(obj2);

            // act - retrieve the saved records and put them in a list.
            List<Reward> savedObjs = new List<Reward>(mgr.GetRewards());

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);

            //Cleanup
            mgr.Delete(obj);
            mgr.Delete(obj2);
        }



    }
}
