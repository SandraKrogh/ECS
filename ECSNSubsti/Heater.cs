using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSNSubsti
{
    public interface IHeater
    {
        void TurnOn();
        void TurnOff();
        bool RunSelfTest();

    }

    public class Heater : IHeater
    {
        private Logger myLog_ = new Logger();

        public void TurnOn()
        {
            myLog_.WriteLogLine("Heater is on");
            //System.Console.WriteLine("Heater is on");
        }

        public void TurnOff()
        {
            myLog_.WriteLogLine("Heater is off");
            //System.Console.WriteLine("Heater is off");
        }

        public bool RunSelfTest()
        {
            return true;
        }

        public int TestResult()
        {
            return test;
        }

        public int test { get; set; }
    }
    public class FakeHeater : IHeater
    {
        //private FakeLogger myFakeLogger_ = new FakeLogger();

        public void TurnOn()
        {
            //myFakeLogger_.WriteLogLine("Heater is on");
            //System.Console.WriteLine("Heater is on");

            test = 1;
        }

        public void TurnOff()
        {
            //myFakeLogger_.WriteLogLine("Heater is off");
            //System.Console.WriteLine("Heater is off");

            test = 0;
        }

        public bool RunSelfTest()
        {
            return true;
        }

        public int test { get; set; }
    }
}
