using System;
using FamilyPointsService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyPointsDomain;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;


namespace MvcFamilyPoints.Tests
{
    
    [TestClass]
    public class BehaviorsUnitTests
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
        public void BehaviorsRepositoryContainsData()
        {

            // arrange 
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();

            // act -- go get the first record
            Behavior savedObj = (from d in db.Behaviors where d.BehaviorID == 1 select d).Single();

            // assert
            Assert.AreEqual(savedObj.BehaviorID, 1);

        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void SaveNewBehaviorToRepository()
        {
            // arrange

            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Behavior obj = new Behavior();
            obj.Description = "New Behavior 1";
            obj.Points = 1;
            db.Behaviors.Add(obj);

            // act
            db.SaveChanges();

            // Assert -- see if the record retreived from the database matches the one i just added
            Behavior savedObj = (from d in db.Behaviors where d.BehaviorID == obj.BehaviorID select d).Single();

            Assert.AreEqual(savedObj.Description, obj.Description);
            Assert.AreEqual(savedObj.Points, obj.Points);

            // cleanup
            db.Behaviors.Remove(savedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateBehaviorInRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Behavior obj = new Behavior();
            obj.Description = "New Behavior 2";
            obj.Points = 0;
            db.Behaviors.Add(obj);
            db.SaveChanges();
           

            // act - retrieve the saved record and update it.
            Behavior savedObj = (from d in db.Behaviors where d.BehaviorID == obj.BehaviorID select d).Single();
            savedObj.Description = "An updated Behavior 2";
            savedObj.Points = 2;
            db.SaveChanges();
           
            // Assert -- see if the record retreived from the database matches the one i just updated
            Behavior updatedObj = (from d in db.Behaviors where d.BehaviorID == obj.BehaviorID select d).Single();

            Assert.AreEqual(updatedObj.Description, savedObj.Description);
            Assert.AreEqual(updatedObj.Points, savedObj.Points);

            // cleanup
            db.Behaviors.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteBehaviorFromRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Behavior obj = new Behavior();
            obj.Description = "Delete this Behavior";
            obj.Points = 3;
            db.Behaviors.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved record and then remove it.
            Behavior savedObj = (from d in db.Behaviors where d.BehaviorID == obj.BehaviorID select d).Single();
            db.Behaviors.Remove(savedObj);
            db.SaveChanges();

            // Assert -- see if the record deleted from the database exists
            Behavior removedObj = (from d in db.Behaviors where d.BehaviorID == savedObj.BehaviorID select d).FirstOrDefault();
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test Method to List the records in the repository.
        /// </summary>
        [TestMethod]
        public void ListofBehaviorsInRepository()
        {
            // arrange - Add a record to be listed.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Behavior obj = new Behavior();
            obj.Description = "Behavior 1";
            obj.Points = 1;
            db.Behaviors.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved records and put them in a list.
            List<Behavior> savedObjs = (from d in db.Behaviors select d).ToList();

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
