using System;
using FamilyPoints.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyPoints.Domain;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;


namespace MvcFamilyPoints.Tests
{
    
    [TestClass]
    public class TransactionsUnitTests
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
        public void TransactionsRepositoryContainsData()
        {

            // arrange 
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();

            // act -- go get the first record
            Transaction savedObj = (from d in db.Transactions where d.TransactionID == 1 select d).Single();

            // assert
            Assert.AreEqual(savedObj.TransactionID, 1);

        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void SaveNewTransactionToRepository()
        {
            // arrange

            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Behavior be = (from d in db.Behaviors select d).First();
            Parent pa = (from d in db.Parents select d).First();
            Child ch = (from d in db.Children select d).First();
            Transaction obj = new Transaction();
            obj.Date = DateTime.Now;
            obj.ParentId = pa.ParentId;
            obj.ChildId = ch.ChildId;
            obj.PointType = "Behavior";
            obj.Description = be.Description;
            obj.Points = be.Points;
            db.Transactions.Add(obj);

            // act
            db.SaveChanges();

            // Assert -- see if the record retreived from the database matches the one i just added
            Transaction savedObj = (from d in db.Transactions where d.TransactionID == obj.TransactionID select d).Single();

            Assert.AreEqual(savedObj.Description, obj.Description);
            Assert.AreEqual(savedObj.Points, obj.Points);
            Assert.AreEqual(savedObj.ParentId, obj.ParentId);
            Assert.AreEqual(savedObj.ChildId, obj.ChildId);
            Assert.AreEqual(savedObj.PointType, obj.PointType);
            Assert.AreEqual(savedObj.Date, obj.Date);

            // cleanup
            db.Transactions.Remove(savedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateTransactionInRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Behavior be = (from d in db.Behaviors select d).First();
            Parent pa = (from d in db.Parents select d).First();
            Child ch = (from d in db.Children select d).First();
            Transaction obj = new Transaction();
            obj.Date = DateTime.Now;
            obj.ParentId = pa.ParentId;
            obj.ChildId = ch.ChildId;
            obj.PointType = "Behavior";
            obj.Description = be.Description;
            obj.Points = be.Points;
            db.Transactions.Add(obj);
            db.SaveChanges();
           

            // act - retrieve the saved record and update it.
            Transaction savedObj = (from d in db.Transactions where d.TransactionID == obj.TransactionID select d).Single();
            savedObj.Description = "Behvior Updated";
            savedObj.Points = 2;
            db.SaveChanges();
           
            // Assert -- see if the record retreived from the database matches the one i just updated
            Transaction updatedObj = (from d in db.Transactions where d.TransactionID == obj.TransactionID select d).Single();

            Assert.AreEqual(updatedObj.Description, savedObj.Description);
            Assert.AreEqual(updatedObj.Points, savedObj.Points);
            Assert.AreEqual(updatedObj.ParentId, savedObj.ParentId);
            Assert.AreEqual(updatedObj.ChildId, savedObj.ChildId);
            Assert.AreEqual(updatedObj.PointType, savedObj.PointType);
            Assert.AreEqual(updatedObj.Date, savedObj.Date);

            // cleanup
            db.Transactions.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteTransactionFromRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Behavior be = (from d in db.Behaviors select d).First();
            Parent pa = (from d in db.Parents select d).First();
            Child ch = (from d in db.Children select d).First();
            Transaction obj = new Transaction();
            obj.Date = DateTime.Now;
            obj.ParentId = pa.ParentId;
            obj.ChildId = ch.ChildId;
            obj.PointType = "Behavior";
            obj.Description = be.Description;
            obj.Points = be.Points;
            db.Transactions.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved record and then remove it.
            Transaction savedObj = (from d in db.Transactions where d.TransactionID == obj.TransactionID select d).Single();
            db.Transactions.Remove(savedObj);
            db.SaveChanges();

            // Assert -- see if the record deleted from the database exists
            Transaction removedObj = (from d in db.Transactions where d.TransactionID == savedObj.TransactionID select d).FirstOrDefault();
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test Method to List the records in the repository.
        /// </summary>
        [TestMethod]
        public void ListofTransactionsInRepository()
        {
            // arrange - Add a record to be listed.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Behavior be = (from d in db.Behaviors select d).First();
            Parent pa = (from d in db.Parents select d).First();
            Child ch = (from d in db.Children select d).First();
            Transaction obj = new Transaction();
            obj.Date = DateTime.Now;
            obj.ParentId = pa.ParentId;
            obj.ChildId = ch.ChildId;
            obj.PointType = "Behavior";
            obj.Description = be.Description;
            obj.Points = be.Points;
            db.Transactions.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved records and put them in a list.
            List<Transaction> savedObjs = (from d in db.Transactions select d).ToList();

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
