using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyPointsDomain;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;


namespace MvcFamilyPoints.Tests
{
    
    
    [TestClass]
    public class ParentsUnitTests
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
        public void ParentsRepositoryContainsData()
        {

            // arrange 
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();

            // act -- go get the first record
            Parent savedObj = (from d in db.Parents where d.ParentID == 1 select d).Single();

            // assert
            Assert.AreEqual(savedObj.ParentID, 1);

        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void SaveNewParentToRepository()
        {
            // arrange

            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Parent obj = new Parent();
            obj.Name = "New Parent 1";
            obj.Password = "pasword";
            db.Parents.Add(obj);

            // act
            db.SaveChanges();

            // Assert -- see if the record retreived from the database matches the one i just added
            Parent savedObj = (from d in db.Parents where d.ParentID == obj.ParentID select d).Single();

            Assert.AreEqual(savedObj.Name, obj.Name);
            Assert.AreEqual(savedObj.Password, obj.Password);

            // cleanup
            db.Parents.Remove(savedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateParentInRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Parent obj = new Parent();
            obj.Name = "New Parent 2";
            obj.Password = "pasword";
            db.Parents.Add(obj);
            db.SaveChanges();
           

            // act - retrieve the saved record and update it.
            Parent savedObj = (from d in db.Parents where d.ParentID == obj.ParentID select d).Single();
            savedObj.Name = "An updated Parent 2";
            savedObj.Password = "pasword";
            db.SaveChanges();
           
            // Assert -- see if the record retreived from the database matches the one i just updated
            Parent updatedObj = (from d in db.Parents where d.ParentID == obj.ParentID select d).Single();

            Assert.AreEqual(updatedObj.Name, savedObj.Name);
            Assert.AreEqual(updatedObj.Password, savedObj.Password);

            // cleanup
            db.Parents.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteParentFromRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Parent obj = new Parent();
            obj.Name = "Delete this Parent";
            obj.Password = "pasword";
            db.Parents.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved record and then remove it.
            Parent savedObj = (from d in db.Parents where d.ParentID == obj.ParentID select d).Single();
            db.Parents.Remove(savedObj);
            db.SaveChanges();

            // Assert -- see if the record deleted from the database exists
            Parent removedObj = (from d in db.Parents where d.ParentID == savedObj.ParentID select d).FirstOrDefault();
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test Method to List the records in the repository.
        /// </summary>
        [TestMethod]
        public void ListofParentsInRepository()
        {
            // arrange - Add a record to be listed.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Parent obj = new Parent();
            obj.Name = "Parent 1";
            obj.Password = "pasword";
            db.Parents.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved records and put them in a list.
            List<Parent> savedObjs = (from d in db.Parents select d).ToList();

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
