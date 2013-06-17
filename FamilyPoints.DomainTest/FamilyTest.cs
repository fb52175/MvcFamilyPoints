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
    public class FamilysUnitTests
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
        public void FamilysRepositoryContainsData()
        {

            // arrange 
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();

            // act -- go get the first record
            Family savedObj = (from d in db.Families where d.FamilyId == 1 select d).Single();

            // assert
            Assert.AreEqual(savedObj.FamilyId, 1);

        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void SaveNewFamilyToRepository()
        {
            // arrange
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Family obj = new Family();
            obj.FamilyName = "New Family 1";
            db.Families.Add(obj);

            // act
            db.SaveChanges();

            // Assert -- see if the record retreived from the database matches the one i just added
            Family savedObj = (from d in db.Families where d.FamilyId == obj.FamilyId select d).Single();

            Assert.AreEqual(savedObj.FamilyName, obj.FamilyName);

            // cleanup
            db.Families.Remove(savedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateFamilyInRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Family obj = new Family();
            obj.FamilyName = "New Family 1";
            db.Families.Add(obj);
            db.SaveChanges();
           

            // act - retrieve the saved record and update it.
            Family savedObj = (from d in db.Families where d.FamilyId == obj.FamilyId select d).Single();
            savedObj.FamilyName = "An updated Family 2";
            db.SaveChanges();
           
            // Assert -- see if the record retreived from the database matches the one i just updated
            Family updatedObj = (from d in db.Families where d.FamilyId == obj.FamilyId select d).Single();

            Assert.AreEqual(updatedObj.FamilyName, savedObj.FamilyName);

            // cleanup
            db.Families.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteFamilyFromRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Family obj = new Family();
            obj.FamilyName = "Delete this Family";
            //obj.Children = (from d in db.Children select d).ToList();
            //obj.Parents = (from d in db.Parents select d).ToList();
            db.Families.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved record and then remove it.
            Family savedObj = (from d in db.Families where d.FamilyId == obj.FamilyId select d).Single();
            db.Families.Remove(savedObj);
            db.SaveChanges();

            // Assert -- see if the record deleted from the database exists
            Family removedObj = (from d in db.Families where d.FamilyId == savedObj.FamilyId select d).FirstOrDefault();
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test Method to List the records in the repository.
        /// </summary>
        [TestMethod]
        public void ListofFamilysInRepository()
        {
            // arrange - Add a record to be listed.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Family obj = new Family();
            obj.FamilyName = "Family 1";
            //obj.Children = (from d in db.Children select d).ToList();
            //obj.Parents = (from d in db.Parents select d).ToList();
            db.Families.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved records and put them in a list.
            List<Family> savedObjs = (from d in db.Families select d).ToList();

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
