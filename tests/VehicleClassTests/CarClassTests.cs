using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyVehicle;

namespace VehicleClassTests
{
    [TestClass]
    public class CarClassTests
    {
        Car car;
        [TestInitialize]
        public void Init() => car = new Car("testBrand", "testModel", 'A', "testBody", 1, 1, 1, 1);

        [TestMethod]
        public void CarConstructPropSetEqualsTests()
        {
            Car expected = new Car("Mazda", "5", 'B', "sedan", 2, 2, 2, 2);
            Car actual = car;
            actual.Brand = "Mazda";
            actual.Model = "5";
            actual.Type = 'B';
            actual.BodyWork = "sedan";
            actual.EngineCapacity = 2;
            actual.Year = 2;
            actual.Weight = 2;
            actual.Seats = 2;
            Assert.AreEqual(true, actual.Equals(expected));
            actual = new Car();
            Assert.AreEqual(false, expected.Equals(actual));
        }
        [TestMethod]
        public void CarImpossiblePropertySetTests() 
        {
            Car expected = new Car(car.Name, car.Brand, car.Type, car.BodyWork, 0.5, 1, 0, 1);
            Car actual = expected;
            actual.EngineCapacity = -1;
            actual.Year = -1;
            actual.Weight = -1;
            actual.Seats = -1;
            Assert.AreEqual(true, expected.Equals(actual));
        }
        [TestMethod]
        public void CarCloneTests()
        {
            Car expected = car;
            Car actual = new Car(car);

            Assert.AreEqual(expected, actual);

            expected = new Car(car)
            {
                Brand = $"клон{car.Brand}"
            };
            actual = (Car)car.Clone();
            Assert.AreEqual(expected, actual);
        }
    }
}
