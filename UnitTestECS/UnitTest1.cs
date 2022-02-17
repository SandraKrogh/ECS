using NUnit.Framework;
using ECS2;

namespace UnitTestECS
{
    public class ECSTests 
    {
        private ECS uut;
        private FakeHeater uutFH;
        private FakeTempSensor uutTS;
        private FakeLogger uutFL;

        [SetUp]
        public void Setup()
        {
            uut = new ECS(1);

            uutFH = new FakeHeater();
            uut._heater = uutFH;

            uutTS = new FakeTempSensor();
            uut._tempSensor = uutTS;

            uutFL = new FakeLogger();
            uut._logger = uutFL;
        }

        
        [TestCase(7, 1)]
        [TestCase(1, 0)]
        public void TestRegulateIfStatement(int threshold, int result)
        {
            uut.SetThreshold(threshold);
            uut.Regulate();
            Assert.That(uutFH.test, Is.EqualTo(result));
        }

        [Test]
        public void TestRegulateConsoleOutput()
        {
            uut.Regulate();
            Assert.That(uutFL.LogResult, Is.EqualTo("Temperatur measured was 5"));
        }
    }
}