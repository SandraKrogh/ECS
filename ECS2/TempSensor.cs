using System;

namespace ECS2
{
    public interface ITempSensor
    {
        int GetTemp();
        bool RunSelfTest();
    }
    public class TempSensor : ITempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }

    public class FakeTempSensor : ITempSensor
    {
        public int GetTemp()
        {
            return 5;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}