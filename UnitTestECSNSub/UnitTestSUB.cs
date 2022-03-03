using NUnit.Framework;
using ECSNSubsti;
using NSubstitute;

namespace UnitTestECSNSub
{
    public class ECSTests
    {
        private ECS uut;
        private IHeater _heater;
        private ITempSensor _tempsensor;
        private ILogger _logger;

        [SetUp]
        public void Setup()
        {
            _heater = Substitute.For<IHeater>();
            _tempsensor = Substitute.For<ITempSensor>();
            _logger = Substitute.For<ILogger>();

            uut = new ECS(1,_heater,_tempsensor,_logger);
        
        }


        [TestCase(7, 1)]
        [TestCase(1, 0)]
        public void TestRegulateIfStatement(int threshold, int result)
        {
            uut.SetThreshold(threshold);
            uut.Regulate();
            _heater.Received(1).TurnOn();
        }

        [Test]
        public void TestRegulateConsoleOutput()
        {
            uut.Regulate();
            _tempsensor.GetTemp().Returns(5);
            _logger.WriteLogLine("Temperatur measured was 5");
            
        }
    }
}