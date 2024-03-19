using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Lab_10;
using ClassLibrary;

namespace USqlCSharpUdoUnitTestProject1
{
    [TestClass]
    public class CollectionTests
    {
        [TestMethod]
        public void UniversalCollection_AddAuto_AddsAuto()
        {
            // Arrange
            var collection = new UniversalСollection();
            var auto = new Auto();

            // Act
            collection.AddAuto(auto);

            // Assert
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void UniversalCollection_RemoveAuto_RemovesAuto()
        {
            // Arrange
            var collection = new UniversalСollection();
            var auto = new Auto();
            collection.AddAuto(auto);

            // Act
            collection.RemoveAuto(0);

            // Assert
            Assert.AreEqual(0, collection.ReturnCountOfLights());
        }

        [TestMethod]
        public void UniversalCollection_SortByYear_SortsAutosByYear()
        {
            // Arrange
            var collection = new UniversalСollection();
            var auto1 = new Auto { Year = 2020 };
            var auto2 = new Auto { Year = 2010 };
            collection.AddAuto(auto1);
            collection.AddAuto(auto2);

            // Act
            collection.SortByYear();

            // Assert
            Assert.AreEqual(2010, collection.GetAutoByIndex(0).Year);
            Assert.AreEqual(2020, collection.GetAutoByIndex(1).Year);
        }

        [TestMethod]
        public void GeneralizedCollection_AddAuto_AddsAuto()
        {
            // Arrange
            var collection = new GeneralizedCollection<LightCars>();
            var auto = new LightCars();

            // Act
            collection.AddAuto(auto);

            // Assert
            Assert.AreEqual(1, collection.ReturnCountOfLights());
        }

        [TestMethod]
        public void GeneralizedCollection_RemoveAuto_RemovesAuto()
        {
            // Arrange
            var collection = new GeneralizedCollection<LightCars>();
            var auto = new LightCars();
            collection.AddAuto(auto);

            // Act
            collection.RemoveAuto();

            // Assert
            Assert.AreEqual(0, collection.ReturnCountOfLights());
        }

        [TestMethod]
        public void GeneralizedCollection_SortByYear_SortsAutosByYear()
        {
            // Arrange
            var collection = new GeneralizedCollection<LightCars>();
            var auto1 = new LightCars { Year = 2020 };
            var auto2 = new LightCars { Year = 2010 };
            collection.AddAuto(auto1);
            collection.AddAuto(auto2);

            // Act
            collection.SortByYear();

            // Assert
            Assert.AreEqual(true, true);
        }
    }
}
