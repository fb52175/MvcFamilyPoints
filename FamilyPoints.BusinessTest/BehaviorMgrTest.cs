using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyPoints.Business;
using FamilyPoints.Domain;

namespace FamilyPoints.BusinessTest
{
    [TestClass]
    public class BehaviorMgrTests
    {
        /// <summary>
        /// Test inserting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrInsertNewBehavior()
        {
            // arrange
            BehaviorMgr mgr = new BehaviorMgr();
            Behavior obj = new Behavior();
            obj.Description = "New Behavior 1";
            obj.Points = 1;

            // act
            mgr.Create(obj);

            // Assert -- see if the record retreived from the database matches the one i just added
            Behavior savedObj = mgr.Find(obj.BehaviorID);

            Assert.AreEqual(savedObj.Description, obj.Description);
            Assert.AreEqual(savedObj.Points, obj.Points);

            // cleanup
            mgr.Delete(savedObj);

        }

        /// <summary>
        /// Test updating an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrUpdateBehavior()
        {
            // arrange - Insert a record so that it can be updated.
            BehaviorMgr mgr = new BehaviorMgr();
            Behavior obj = new Behavior();
            obj.Description = "New Behavior 2";
            obj.Points = 0;
            mgr.Create(obj);

            // act - retrieve the saved record and update it.
            Behavior savedObj = mgr.Find(obj.BehaviorID);
            mgr.Update(savedObj, "An updated Behavior 2",2);

            // Assert -- see if the record retreived from the database matches the one i just updated
            Behavior updatedObj = mgr.Find(savedObj.BehaviorID);

            Assert.AreEqual(updatedObj.Description, savedObj.Description);
            Assert.AreEqual(updatedObj.Points, savedObj.Points);

            // cleanup
            mgr.Delete(updatedObj);
        }

        /// <summary>
        ///  Test deleting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrDeleteBehavior()
        {
            // arrange - Insert a record so that it can be updated.
            BehaviorMgr mgr = new BehaviorMgr();
            Behavior obj = new Behavior();
            obj.Description = "Delete this Behavior";
            obj.Points = 3;
            mgr.Create(obj);

            // act - retrieve the saved record and then remove it.
            Behavior savedObj = mgr.Find(obj.BehaviorID);
            mgr.Delete(savedObj);

            // Assert -- see if the record deleted from the database exists
            Behavior removedObj = mgr.Find(savedObj.BehaviorID);
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test listing objects with the manager
        /// </summary>
        [TestMethod]
        public void MgrGetBehaviors()
        {
            // arrange - Add a record to be listed.
            BehaviorMgr mgr = new BehaviorMgr();
            Behavior obj = new Behavior();
            obj.Description = "Behavior 1";
            obj.Points = 1;
            mgr.Create(obj);

            Behavior obj2 = new Behavior();
            obj2.Description = "Behavior 2";
            obj2.Points = 2;
            mgr.Create(obj2);

            // act - retrieve the saved records and put them in a list.
            List<Behavior> savedObjs = new List<Behavior>(mgr.GetBehaviors());

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
