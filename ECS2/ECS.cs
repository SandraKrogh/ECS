using System;

namespace ECS2
{
    public class ECS
    {
        private int _threshold;
        public ITempSensor _tempSensor { private get; set; }
        public IHeater _heater { private get; set; }

        public ECS(int thr)
        {
            SetThreshold(thr);
            _tempSensor = new TempSensor();
            _heater = new Heater();
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            Console.WriteLine($"Temperatur measured was {t}");
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
