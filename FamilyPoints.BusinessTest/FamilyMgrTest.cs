using FamilyPoints.Business;
using FamilyPoints.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FamilyPoints.BusinessTest
{
    [TestClass]
    public class FamilyMgrTests
    {
     
        /// <summary>
        /// Test inserting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrInsertNewFamily()
        {
            // arrange
            FamilyMgr mgr = new FamilyMgr();
            Family obj = new Family();
            obj.FamilyName = "Boland";

            // act
            mgr.Create(obj);

            // Assert -- see if the record retreived from the database matches the one i just added
            Family savedObj = mgr.Find(obj.FamilyId);
            Assert.AreEqual(savedObj.FamilyName, obj.FamilyName);

            // cleanup

            mgr.Delete(mgr.Find(obj.FamilyId));
      

        }

        /// <summary>
        /// Test updating an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrUpdateFamily()
        {
            // arrange - Insert a record so that it can be updated.

            FamilyMgr mgr = new FamilyMgr();
            Family obj = new Family();
            obj.FamilyName = "Boland";
            mgr.Create(obj);

            // act - retrieve the saved record and update it.
            Family savedObj = mgr.Find(obj.FamilyId);
            savedObj.FamilyName = "Doe";
            mgr.Update(savedObj);

            // Assert -- see if the record retreived from the database matches the one i just updated
            Family updatedObj = mgr.Find(savedObj.FamilyId);

            Assert.AreEqual(updatedObj.FamilyName, savedObj.FamilyName);

            // cleanup
            mgr.Delete(updatedObj);
        }

        /// <summary>
        /// Test Adding Parents to an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrAddParentToFamily()
        {
            // arrange - Insert a record so that it can be updated.
            FamilyMgr mgr = new FamilyMgr();
            Family obj = new Family();
            obj.FamilyName = "Boland";
            mgr.Create(obj);

            ParentMgr parentMgr = new ParentMgr(mgr.context);
            Parent pObj = new Parent();
            pObj.Name = "John";
            pObj.Password = "password";
            pObj.Family = obj;
            parentMgr.Create(pObj);

            Parent pObj2 = new Parent();
            pObj2.Name = "Jane";
            pObj2.Password = "password";
            pObj2.Family = obj;
            parentMgr.Create(pObj2);

            // act - retrieve the saved record and update it.
            Family savedObj = mgr.Find(obj.FamilyId);

            mgr.AddParent(savedObj,pObj);
            mgr.AddParent(savedObj, pObj2);

            // Assert -- see if the record retreived from the database matches the one i just updated
            Family updatedObj = mgr.Find(savedObj.FamilyId);

            Assert.AreEqual(updatedObj.FamilyName, savedObj.FamilyName);
            //Assert.AreEqual(updatedObj.Parents, savedObj.Parents);

            // cleanup
            mgr.Delete(updatedObj);
        }

        /// <summary>
        /// Test Adding Children to an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrAddChildrenToFamily()
        {
            // arrange - Insert a record so that it can be updated.
            FamilyMgr mgr = new FamilyMgr();
            Family obj = new Family();
            obj.FamilyName = "Boland";
            mgr.Create(obj);

            ChildMgr childMgr = new ChildMgr(mgr.context);
            Child pObj = new Child();
            pObj.Name = "Johnny";
            pObj.Password = "password";
            pObj.Family = obj;
            childMgr.Create(pObj);

            Child pObj2 = new Child();
            pObj2.Name = "Janis";
            pObj2.Password = "password";
            pObj2.Family = obj;
            childMgr.Create(pObj2);

            // act - retrieve the saved record and update it.
            Family savedObj = mgr.Find(obj.FamilyId);

            mgr.AddChild(savedObj, pObj);
            mgr.AddChild(savedObj, pObj2);


            // Assert -- see if the record retreived from the database matches the one i just updated
            Family updatedObj = mgr.Find(savedObj.FamilyId);

            Assert.AreEqual(updatedObj.FamilyName, savedObj.FamilyName);
            //Assert.AreEqual(updatedObj.Children, savedObj.Children);


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
            FamilyMgr mgr = new FamilyMgr();
            Family obj = new Family();
            obj.FamilyName = "Boland";
            mgr.Create(obj);

            // act - retrieve the saved record and then remove it.
            Family savedObj = mgr.Find(obj.FamilyId);
            mgr.Delete(savedObj);

            // Assert -- see if the record deleted from the database exists
            Family removedObj = mgr.Find(savedObj.FamilyId);
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test listing objects with the manager
        /// </summary>
        [TestMethod]
        public void MgrGetFamilys()
        {
            // arrange - Add a record to be listed.
            FamilyMgr mgr = new FamilyMgr();
            Family obj = new Family();
            obj.FamilyName = "Boland";
            mgr.Create(obj);

            Family obj2 = new Family();
            obj2.FamilyName = "Doe";
            mgr.Create(obj2);

            // act - retrieve the saved records and put them in a list.
            List<Family> savedObjs = new List<Family>(mgr.GetFamilies());

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
