using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyPoints.Business;
using FamilyPoints.Domain;

namespace FamilyPoints.BusinessTest
{
    [TestClass]
    public class ParentMgrTests
    {
        
        /// <summary>
        /// Test inserting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrInsertNewParent()
        {
            // arrange

            // note connection string is in app.config
            ParentMgr mgr = new ParentMgr();

            Parent obj = new Parent();
            obj.Name = "John";
            obj.Password = "password";

            // act
            mgr.Create(obj);

            // Assert -- see if the record retreived from the database matches the one i just added
            Parent savedObj = mgr.Find(obj.ParentID);

            Assert.AreEqual(savedObj.Name, obj.Name);
            Assert.AreEqual(savedObj.Password, obj.Password);

            // cleanup
            mgr.Delete(savedObj);

        }

        /// <summary>
        /// Test updating an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrUpdateParent()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            ParentMgr mgr = new ParentMgr();
            Parent obj = new Parent();
            obj.Name = "John";
            obj.Password = "Password";
            mgr.Create(obj);

            // act - retrieve the saved record and update it.
            Parent savedObj = mgr.Find(obj.ParentID);
            mgr.Update(savedObj, "Joe","Password");

            // Assert -- see if the record retreived from the database matches the one i just updated
            Parent updatedObj = mgr.Find(savedObj.ParentID);

            Assert.AreEqual(updatedObj.Name, savedObj.Name);
            Assert.AreEqual(updatedObj.Password, savedObj.Password);

            // cleanup
            mgr.Delete(updatedObj);
        }

        /// <summary>
        ///  Test deleting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrDeleteParent()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            ParentMgr mgr = new ParentMgr();
            Parent obj = new Parent();
            obj.Name = "Jane";
            obj.Password = "Pasword";
            mgr.Create(obj);

            // act - retrieve the saved record and then remove it.
            Parent savedObj = mgr.Find(obj.ParentID);
            mgr.Delete(savedObj);

            // Assert -- see if the record deleted from the database exists
            Parent removedObj = mgr.Find(savedObj.ParentID);
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test listing objects with the manager
        /// </summary>
        [TestMethod]
        public void MgrGetParents()
        {
            // arrange - Add a record to be listed.
            // note connection string is in app.config
            ParentMgr mgr = new ParentMgr();
            Parent obj = new Parent();
            obj.Name = "John";
            obj.Password = "Password";
            mgr.Create(obj);

            Parent obj2 = new Parent();
            obj2.Name = "Joe";
            obj2.Password = "Password";
            mgr.Create(obj2);

            // act - retrieve the saved records and put them in a list.
            List<Parent> savedObjs = new List<Parent>(mgr.GetParents());

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
