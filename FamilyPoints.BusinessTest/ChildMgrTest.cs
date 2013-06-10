using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyPoints.Business;
using FamilyPoints.Domain;

namespace FamilyPoints.BusinessTest
{
    [TestClass]
    public class ChildMgrTests
    {
        
        /// <summary>
        /// Test inserting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrInsertNewChild()
        {
            // arrange

            // note connection string is in app.config
            ChildMgr mgr = new ChildMgr();

            Child obj = new Child();
            obj.Name = "Johnny";
            obj.Password = "password";

            // act
            mgr.Create(obj);

            // Assert -- see if the record retreived from the database matches the one i just added
            Child savedObj = mgr.Find(obj.ChildID);

            Assert.AreEqual(savedObj.Name, obj.Name);
            Assert.AreEqual(savedObj.Password, obj.Password);

            // cleanup
            mgr.Delete(savedObj);

        }

        /// <summary>
        /// Test updating an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrUpdateChild()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            ChildMgr mgr = new ChildMgr();
            Child obj = new Child();
            obj.Name = "Johnny";
            obj.Password = "Password";
            mgr.Create(obj);

            // act - retrieve the saved record and update it.
            Child savedObj = mgr.Find(obj.ChildID);
            mgr.Update(savedObj, "Joey","Password");

            // Assert -- see if the record retreived from the database matches the one i just updated
            Child updatedObj = mgr.Find(savedObj.ChildID);

            Assert.AreEqual(updatedObj.Name, savedObj.Name);
            Assert.AreEqual(updatedObj.Password, savedObj.Password);

            // cleanup
            mgr.Delete(updatedObj);
        }

        /// <summary>
        ///  Test deleting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrDeleteChild()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            ChildMgr mgr = new ChildMgr();
            Child obj = new Child();
            obj.Name = "Jane";
            obj.Password = "Pasword";
            mgr.Create(obj);

            // act - retrieve the saved record and then remove it.
            Child savedObj = mgr.Find(obj.ChildID);
            mgr.Delete(savedObj);

            // Assert -- see if the record deleted from the database exists
            Child removedObj = mgr.Find(savedObj.ChildID);
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test listing objects with the manager
        /// </summary>
        [TestMethod]
        public void MgrGetChilds()
        {
            // arrange - Add a record to be listed.
            // note connection string is in app.config
            ChildMgr mgr = new ChildMgr();
            Child obj = new Child();
            obj.Name = "Johnny";
            obj.Password = "Password";
            mgr.Create(obj);

            Child obj2 = new Child();
            obj2.Name = "Joey";
            obj2.Password = "Password";
            mgr.Create(obj2);

            // act - retrieve the saved records and put them in a list.
            List<Child> savedObjs = new List<Child>(mgr.GetChildren());

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
