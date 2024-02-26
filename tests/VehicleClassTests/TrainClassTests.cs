using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyVehicle;

namespace VehicleClassTests
{
    [TestClass]
    public class TrainClassTests
    {
        Train train;
        [TestInitialize]
        public void Init()
        {
            train = new Train(1, 1, 1, "testType", 1, 1, 1);
        }
        [TestMethod]
        public void TrainConstructPropSetEqualsTests()
        {
            Train expected = new Train(1, 1, 1, "testType", 1, 1, 1);
            Train actual = new Train
            {
                NumOfWagons = 1,
                NumOfLocomotives = 1,
                NumOfSeatsPerWagon = 1,
                Type = "testType",
                WghtOfLocomotive = 1,
                WghtOfWagon = 1,
                RouteNum = 1
            };

            Assert.AreEqual(expected, actual);

            expected = new Train(train);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TrainImpossiblePropSetTests()
        {
            Train expected = new Train(0, 3, 0, "test", 250, 150, 0);
            Train actual = new Train(-1, -1, -1, "test", -1, -1, -1);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TrainCloneTests()
        {
            Train expected = train;
            Train actual = new Train(train);

            Assert.AreEqual(expected, actual);

            expected = new Train(train)
            {
                Type = "клон" + train.Type
            };
            actual = (Train)train.Clone();

            Assert.AreEqual(expected, actual);
        }
    }
}
