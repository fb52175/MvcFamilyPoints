using System;
using System.Collections.Generic;
using System.Linq;
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
            ParentMgr mgr = new ParentMgr();

            Parent obj = new Parent();
            obj.Name = "John";
            obj.Password = "password";
            Family family = mgr.context.Families.FirstOrDefault();
            obj.Family = family;

            // act
            mgr.Create(obj);

            // Assert -- see if the record retreived from the database matches the one i just added
            Parent savedObj = mgr.Find(obj.ParentId);

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
            ParentMgr mgr = new ParentMgr();
            Parent obj = new Parent();
            obj.Name = "John";
            obj.Password = "Password";
            Family family = mgr.context.Families.FirstOrDefault();
            obj.Family = family;
            mgr.Create(obj);

            // act - retrieve the saved record and update it.
            Parent savedObj = mgr.Find(obj.ParentId); 
            savedObj.Name = "Joe";
            savedObj.Password = "Password";
            obj.Family = family;
            mgr.Update(savedObj);

            // Assert -- see if the record retreived from the database matches the one i just updated
            Parent updatedObj = mgr.Find(savedObj.ParentId);

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
            ParentMgr mgr = new ParentMgr();
            Parent obj = new Parent();
            obj.Name = "Jane";
            obj.Password = "Pasword";
            Family family = mgr.context.Families.FirstOrDefault();
            obj.Family = family;
            mgr.Create(obj);

            // act - retrieve the saved record and then remove it.
            Parent savedObj = mgr.Find(obj.ParentId);
            mgr.Delete(savedObj);

            // Assert -- see if the record deleted from the database exists
            Parent removedObj = mgr.Find(savedObj.ParentId);
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
            Family family = mgr.context.Families.FirstOrDefault();
            obj.Family = family;
            mgr.Create(obj);

            Parent obj2 = new Parent();
            obj2.Name = "Joe";
            obj2.Password = "Password";
            obj2.Family = family;
            mgr.Create(obj2);

            // act - retrieve the saved records and put them in a list.
            List<Parent> savedObjs = new List<Parent>(mgr.GetParents());

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
