using FamilyPoints.Domain;
using FamilyPoints.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace FamilyPoints.ServiceTests
{
    
    
    [TestClass]
    public class FamilySvcUnitTests
    {

        /// <summary>
        /// Test Method to Connect to the familySvc and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void FamilySvcRepositoryContainsData()
        {

            // arrange 
            FamilyPointsContext db = new FamilyPointsContext();
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc",db);


            // act -- go get the first record
            Family savedObj = familySvc.GetById(1);

            // assert
            Assert.AreEqual(savedObj.FamilyID, 1);

        }

        /// <summary>
        /// Test Method to Connect to the familySvc and add a record
        /// </summary>
        [TestMethod]
        public void SaveNewFamilySvc()
        {
            // arrange
            FamilyPointsContext db = new FamilyPointsContext();
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc",db);

            Family obj = new Family();
            obj.Name = "New Family 1";
            familySvc.Insert(obj);

            // act
            familySvc.Save();

            // Assert -- see if the record retreived from the database matches the one i just added
            Family savedObj = familySvc.GetById(obj.FamilyID);

            Assert.AreEqual(savedObj.Name, obj.Name);

            // cleanup
            familySvc.Delete(savedObj);
            familySvc.Save();
        }

        /// <summary>
        /// Test Method to Connect to the familySvc and update a record
        /// </summary>
        [TestMethod]
        public void UpdateFamilySvc()
        {
            // arrange - Insert a record so that it can be updated.
            FamilyPointsContext db = new FamilyPointsContext();
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc",db);

            Family obj = new Family();
            obj.Name = "New Family 2";
            familySvc.Insert(obj);
            familySvc.Save();


            // act - retrieve the saved record and update it.
            Family savedObj = familySvc.GetById(obj.FamilyID);
            savedObj.Name = "An updated Family 2";
            familySvc.Update(savedObj);
            //familySvc.Save();

            // Assert -- see if the record retreived from the database matches the one i just updated
            Family updatedObj = familySvc.GetById(obj.FamilyID);

            Assert.AreEqual(updatedObj.Name, savedObj.Name);

            // cleanup
            familySvc.Delete(updatedObj);
            familySvc.Save();
        }

        /// <summary>
        /// Test Method to Connect to the familySvc and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteFamilySvc()
        {
            // arrange - Insert a record so that it can be updated.
            FamilyPointsContext db = new FamilyPointsContext();
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc",db);

            Family obj = new Family();
            obj.Name = "Delete this Family";
            familySvc.Insert(obj);
            familySvc.Save();

            // act - retrieve the saved record and then remove it.
            Family savedObj = familySvc.GetById(obj.FamilyID);
            familySvc.Delete(savedObj);
            familySvc.Save();

            // Assert -- see if the record deleted from the database exists
            Family removedObj = familySvc.GetById(obj.FamilyID);
            Assert.IsNull(removedObj);

        }

        /// <summary>
        /// Test Method to List the records in the family repository.
        /// </summary>
        [TestMethod]
        public void ListofFamilysInRepositoryFromFactory()
        {
            // arrange - Add a record to be listed.
            FamilyPointsContext db = new FamilyPointsContext();
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc",db);

            Family obj = new Family();
            obj.Name = "Family 1";
            familySvc.Insert(obj);
            familySvc.Save();

            // act - retrieve the saved records and put them in a list.
            List<Family> savedObjs = new List<Family>(familySvc.GetAll());

            // Assert -- The list of saved objects should have a count greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }



    }
}
