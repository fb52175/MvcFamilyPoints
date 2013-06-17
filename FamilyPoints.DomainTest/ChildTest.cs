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
    public class ChildrenUnitTests
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
        public void ChildrenRepositoryContainsData()
        {

            // arrange 
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();

            // act -- go get the first record
            Child savedObj = (from d in db.Children where d.ChildId == 1 select d).Single();

            // assert
            Assert.AreEqual(savedObj.ChildId, 1);

        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void SaveNewChildToRepository()
        {
            // arrange

            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Child obj = new Child();
            obj.Name = "New Child 1";
            obj.Password = "pasword";
            Family family = db.Families.FirstOrDefault();
            obj.Family = family;
            db.Children.Add(obj);

            // act
            db.SaveChanges();

            // Assert -- see if the record retreived from the database matches the one i just added
            Child savedObj = (from d in db.Children where d.ChildId == obj.ChildId select d).Single();

            Assert.AreEqual(savedObj.Name, obj.Name);
            Assert.AreEqual(savedObj.Password, obj.Password);

            // cleanup
            db.Children.Remove(savedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateChildInRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Child obj = new Child();
            obj.Name = "New Child 2";
            obj.Password = "pasword";
            Family family = db.Families.FirstOrDefault();
            obj.Family = family;
            db.Children.Add(obj);
            db.SaveChanges();
           

            // act - retrieve the saved record and update it.
            Child savedObj = (from d in db.Children where d.ChildId == obj.ChildId select d).Single();
            savedObj.Name = "An updated Child 2";
            savedObj.Password = "pasword";
            db.SaveChanges();
           
            // Assert -- see if the record retreived from the database matches the one i just updated
            Child updatedObj = (from d in db.Children where d.ChildId == obj.ChildId select d).Single();

            Assert.AreEqual(updatedObj.Name, savedObj.Name);
            Assert.AreEqual(updatedObj.Password, savedObj.Password);

            // cleanup
            db.Children.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteChildFromRepository()
        {
            // arrange - Insert a record so that it can be updated.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Child obj = new Child();
            obj.Name = "Delete this Child";
            obj.Password = "pasword";
            Family family = db.Families.FirstOrDefault();
            obj.Family = family;
            db.Children.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved record and then remove it.
            Child savedObj = (from d in db.Children where d.ChildId == obj.ChildId select d).Single();
            db.Children.Remove(savedObj);
            db.SaveChanges();

            // Assert -- see if the record deleted from the database exists
            Child removedObj = (from d in db.Children where d.ChildId == savedObj.ChildId select d).FirstOrDefault();
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test Method to List the records in the repository.
        /// </summary>
        [TestMethod]
        public void ListofChildrenInRepository()
        {
            // arrange - Add a record to be listed.
            // note connection string is in app.config
            FamilyPointsContext db = new FamilyPointsContext();
            Child obj = new Child();
            obj.Name = "Child 1";
            obj.Password = "pasword";
            Family family = db.Families.FirstOrDefault();
            obj.Family = family;
            db.Children.Add(obj);
            db.SaveChanges();

            // act - retrieve the saved records and put them in a list.
            List<Child> savedObjs = (from d in db.Children select d).ToList();

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
