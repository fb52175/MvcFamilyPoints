using FamilyPoints.Business;
using FamilyPoints.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FamilyPoints.BusinessTest
{
    [TestClass]
    public class TransactionMgrTests
    {
        /// <summary>
        /// Test inserting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrInsertNewTransaction()
        {
            // arrange
            TransactionMgr mgr = new TransactionMgr();
            Transaction obj = new Transaction();
            obj.Description = "Item 1";
            obj.Points = 3;
            obj.ChildID = 1;
            obj.ParentID = 1;
            obj.Date = DateTime.Now;
            obj.PointType = "Reward";

            // act
            mgr.Create(obj);

            // Assert -- see if the record retreived from the database matches the one i just added
            Transaction savedObj = mgr.Find(obj.TransactionID);

            Assert.AreEqual(savedObj.Description, obj.Description);
            Assert.AreEqual(savedObj.Points, obj.Points);
            Assert.AreEqual(savedObj.ChildID, obj.ChildID);
            Assert.AreEqual(savedObj.ParentID, obj.ParentID);
            Assert.AreEqual(savedObj.PointType, obj.PointType);
            Assert.AreEqual(savedObj.Date, obj.Date);

            // cleanup
            mgr.Delete(savedObj);

        }

        /// <summary>
        /// Test updating an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrUpdateTransaction()
        {
            // arrange - Insert a record so that it can be updated.
            TransactionMgr mgr = new TransactionMgr();
            Transaction obj = new Transaction();
            obj.Description = "Item 1";
            obj.Points = 3;
            obj.ChildID = 1;
            obj.ParentID = 1;
            obj.Date = DateTime.Now;
            obj.PointType = "Reward";
            mgr.Create(obj);

            // act - retrieve the saved record and update it.
            Transaction savedObj = mgr.Find(obj.TransactionID);
            mgr.Update(savedObj, 1,1,"An updated Transaction",2,"Reward");

            // Assert -- see if the record retreived from the database matches the one i just updated
            Transaction updatedObj = mgr.Find(savedObj.TransactionID);

            Assert.AreEqual(updatedObj.Description, savedObj.Description);
            Assert.AreEqual(updatedObj.Points, savedObj.Points);

            // cleanup
            mgr.Delete(updatedObj);
        }

        /// <summary>
        ///  Test deleting an object with the manager
        /// </summary>
        [TestMethod]
        public void MgrDeleteTransaction()
        {
            // arrange - Insert a record so that it can be deleted.
            TransactionMgr mgr = new TransactionMgr();
            Transaction obj = new Transaction();
            obj.Description = "Delete this Transaction";
            obj.Points = 3;
            obj.Date = DateTime.Now;
            mgr.Create(obj);

            // act - retrieve the saved record and then remove it.
            Transaction savedObj = mgr.Find(obj.TransactionID);
            mgr.Delete(savedObj);

            // Assert -- see if the record deleted from the database exists
            Transaction removedObj = mgr.Find(savedObj.TransactionID);
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test listing objects with the manager
        /// </summary>
        [TestMethod]
        public void MgrGetTransactions()
        {
            // arrange - Add a record to be listed.
            TransactionMgr mgr = new TransactionMgr();

            Transaction obj = new Transaction();
            obj.Description = "Transaction 1";
            obj.Points = 1;
            obj.Date = DateTime.Now;
            mgr.Create(obj);

            Transaction obj2 = new Transaction();
            obj2.Description = "Transaction 2";
            obj2.Points = 2;
            obj2.Date = DateTime.Now;
            mgr.Create(obj2);

            // act - retrieve the saved records and put them in a list.
            List<Transaction> savedObjs = new List<Transaction>(mgr.GetTransactions());

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
