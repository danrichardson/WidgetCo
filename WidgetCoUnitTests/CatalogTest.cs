using WidgetCo.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WidgetCoUnitTests
{
    
    
    /// <summary>
    ///This is a test class for CatalogTest and is intended
    ///to contain all CatalogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CatalogTest
    {

        private ICatalog _target;
        public ICatalog target
        {
            get
            {
                if (_target == null)
                {
                    Random rnd = new Random();
                    _target = new MockCatalog();
                    List<String> mockCategories = new List<String> { "Q", "W", "E", "R", "T", "Y" };
                    for (int i = 1; i < 1000; i++)
                    {
                        string randomItem = Path.GetRandomFileName();
                        int r = rnd.Next(mockCategories.Count);
                        string randomCategory = mockCategories[r];
                        target.IDTable.Add(i.ToString(), randomItem);
                        target.CategoryTable.Add(i.ToString(), randomCategory);
                    }
                }
                return _target;
            }
            set
            {
                _target = value;
            }
        }


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        /// <summary>
        ///A test for FetchIDs
        ///</summary>
        [TestMethod()]
        public void FetchIDsTest()
        {
            String randomCategory = target.CategoryTable.Values.ElementAt(500);
            List<String> relatedIDs = target.FetchIDs(randomCategory);
            Assert.IsTrue(relatedIDs.Count() > 0);
       } 

        /// <summary>
        ///A test for FetchRandom
        ///</summary>
        [TestMethod()]
        public void FetchRandomTest()
        {
            String[] randomItem = target.FetchRandom();
            Assert.IsNotNull(randomItem[0]);
            Assert.IsNotNull(randomItem[1]);
        }

        /// <summary>
        ///A test for FetchRelated
        ///</summary>
        [TestMethod()]
        public void FetchRelatedTest()
        {
            String randomID = target.IDTable.Keys.ElementAt(500);
            List<String> allRelated = target.FetchRelated(randomID);
            Assert.IsTrue(allRelated.Count() > 0);
        }

        /// <summary>
        ///A test for ReadCatalog
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WidgetCo.exe")]
        public void ReadCatalogTest()
        {
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Read
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WidgetCo.exe")]
        public void ReadTest()
        {
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FetchCategory
        ///</summary>
        [TestMethod()]
        public void FetchCategoryTest()
        {
            String randomID = target.IDTable.Keys.ElementAt(500); 
            String Category = target.FetchCategory(randomID);
            Assert.AreEqual(Category, target.CategoryTable.ElementAt(500).Value);
        }
    }
}
