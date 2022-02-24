using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSNSubsti
{
    public class ECS
    {
        private int _threshold;
        public ITempSensor _tempSensor { get; set; }
        public IHeater _heater { get; set; }

        public ILogger _logger;

        public ECS(int thr, IHeater heater, ITempSensor tempSensor, ILogger logger)
        {
            SetThreshold(thr);
            _tempSensor = tempSensor;
            _heater = heater;
            _logger = logger;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            _logger.WriteLogLine($"Temperatur measured was {t}");
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
