using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyVehicle;

namespace VehicleClassTests
{
    [TestClass]
    public class ExpressClassTests
    {
        Express express;
        [TestInitialize] 
        public void Init() { express = new Express(1, 1, 10, 1, 10, 10, 10); }
        [TestMethod]
        public void ExpressConstructPropSetEqualsTests()
        {
            Express expected = new Express(express);
            Express actual = new Express();
            actual.RouteNum = 1;
            actual.NumOfBusinessWagons = 1;
            actual.NumOfSeatsPerBusinessW = 10;
            actual.NumOfDefaultWagons = 1;
            actual.NumOfSeatsPerDefaultW = 10;
            actual.WghtOfWagon = 10;
            actual.WghtOfLocomotive = 10;

            Assert.AreEqual(true, actual.Equals(expected));

            actual = new Express();

            Assert.AreEqual(false, expected.Equals(actual));
        }
        [TestMethod]
        public void ExpressImpossiblePropertySetTests()
        {
            Express expected = new Express(700, 4, 48, 4, 64, 150, 250);
            Express actual = new Express();
            actual.RouteNum = -1;
            actual.NumOfBusinessWagons = -1;
            actual.NumOfSeatsPerBusinessW = -1;
            actual.NumOfDefaultWagons= -1;
            actual.NumOfSeatsPerDefaultW= -1;
            actual.WghtOfWagon= -1;
            actual.WghtOfLocomotive= -1;

            Assert.AreEqual(true, expected.Equals(actual));
        }
        [TestMethod]
        public void ExpressCloneTests()
        {
            Express expected = express;
            Express actual = new Express(express);

            Assert.AreEqual(true, expected.Equals(actual));

            expected = new Express();
            actual = (Express)expected.Clone();

            Assert.AreNotEqual(expected, actual);
        }
    }
}
