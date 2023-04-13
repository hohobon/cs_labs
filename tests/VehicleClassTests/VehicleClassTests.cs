using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyVehicle;

namespace VehicleClassTests
{
    [TestClass]
    public class VehicleClassTests
    {
        Vehicle veh;
        [TestInitialize]
        public void Init() => veh = new Vehicle("test vehicle", 1, 1);

        [TestMethod]
        public void NamePropGetSet()
        {
            veh.Name = "A";
            string testname = veh.Name;
            Assert.AreEqual("A", veh.Name);
            Assert.AreEqual("A", testname);
        }
        [TestMethod]
        public void WeightPropGetSet()
        {
            double expectedWeight = 3.456;
            veh.Weight = 3.456;
            Assert.AreEqual(expectedWeight, veh.Weight);
            expectedWeight = 0;
            veh.Weight = -1;
            Assert.AreEqual(expectedWeight, veh.Weight);
        }
        [TestMethod]
        public void SeatsPropGetSet()
        {
            int expectedSeats = 30;
            veh.Seats = expectedSeats;
            Assert.AreEqual(expectedSeats, veh.Seats);
            expectedSeats = 1;
            veh.Seats = -1;
            Assert.AreEqual(expectedSeats, veh.Seats);
        }
        [TestMethod]
        public void CloneAndEqualsTest()
        {
            var clone = veh.Clone();
            bool expected = true;
            Assert.AreEqual(expected, clone.Equals(veh));
            veh = new Vehicle();
            expected = false;
            Assert.AreEqual(expected, clone.Equals(veh));
            clone = null;
            expected = false;
            Assert.AreEqual (expected, veh.Equals(clone));
        }
    }
}
