using System;
using System.Collections.Generic;
using System.Data.Entity;
using FamilyPoints.BusinessTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyPoints.Business;
using FamilyPoints.Domain;
using FamilyPoints.Service;

namespace FamilyPoints.BusinessTest
{
    [TestClass]
    public class FamilyMgrTests
    {
        [ClassInitialize()]
        public static void DataLayerSetup(TestContext testContext)
        {
            Database.SetInitializer<FamilyPointsContext>(new FamilyPointsContextInitializer());
        }

        /// <summary>
        /// Test inserting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrInsertNewFamily()
        {
            // arrange

            FamilyMgr mgr = new FamilyMgr();
            Family obj = new Family();
            obj.Name = "Boland";
            mgr.Create(obj);

            // act
            mgr.Create(obj);

            // Assert -- see if the record retreived from the database matches the one i just added
            Family savedObj = mgr.Find(obj.FamilyID);
            Assert.AreEqual(savedObj.Name, obj.Name);

            // cleanup

            mgr.Delete(mgr.Find(obj.FamilyID));

        }

        /// <summary>
        /// Test updating an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrUpdateFamily()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyMgr mgr = new FamilyMgr();
            Family obj = new Family();
            obj.Name = "Boland";
            mgr.Create(obj);

            // act - retrieve the saved record and update it.
            Family savedObj = mgr.Find(obj.FamilyID);
            mgr.Update(savedObj, "Doe");

            // Assert -- see if the record retreived from the database matches the one i just updated
            Family updatedObj = mgr.Find(savedObj.FamilyID);

            Assert.AreEqual(updatedObj.Name, savedObj.Name);

            // cleanup
            mgr.Delete(updatedObj);
        }

        /// <summary>
        /// Test Adding a Parent an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrAddParentToFamily()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyMgr mgr = new FamilyMgr();
            Family obj = new Family();
            obj.Name = "Boland";
            mgr.Create(obj);

            ParentMgr parentMgr = new ParentMgr();
            Parent pObj = new Parent();
            pObj.Name = "John";
            pObj.Password = "password";

            // act - retrieve the saved record and update it.
            Family savedObj = mgr.Find(obj.FamilyID);

            mgr.AddParent(savedObj,pObj);

            // Assert -- see if the record retreived from the database matches the one i just updated
            Family updatedObj = mgr.Find(savedObj.FamilyID);

            Assert.AreEqual(updatedObj.Name, savedObj.Name);
            Assert.AreEqual(updatedObj.Parents, savedObj.Parents);
            //List<Parent> parentObjs = new List<Parent>(updatedObj);


            // cleanup
            mgr.Delete(updatedObj);
        }

        /// <summary>
        ///  Test deleting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrDeleteFamily()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyMgr mgr = new FamilyMgr();
            Family obj = new Family();
            obj.Name = "Boland";
            mgr.Create(obj);

            // act - retrieve the saved record and then remove it.
            Family savedObj = mgr.Find(obj.FamilyID);
            mgr.Delete(savedObj);

            // Assert -- see if the record deleted from the database exists
            Family removedObj = mgr.Find(savedObj.FamilyID);
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test listing objects with the manager
        /// </summary>
        [TestMethod]
        public void MgrGetFamilys()
        {
            // arrange - Add a record to be listed.
            // note connection string is in app.config
            FamilyMgr mgr = new FamilyMgr();
            Family obj = new Family();
            obj.Name = "Boland";
            mgr.Create(obj);

            Family obj2 = new Family();
            obj2.Name = "Doe";
            mgr.Create(obj2);

            // act - retrieve the saved records and put them in a list.
            List<Family> savedObjs = new List<Family>(mgr.GetFamilies());

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
