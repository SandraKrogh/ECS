using System;

namespace ECSNSubsti
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing ECS.Legacy");

            ITempSensor _tempSensor = new TempSensor();
            IHeater _heater = new Heater();
            ILogger _logger = new Logger();

            // Make an ECS with a threshold of 23
            var control = new ECS(23,_heater,_tempSensor, _logger);

            for (int i = 1; i <= 15; i++)
            {
                Console.WriteLine($"Running regulation number {i}");

                control.Regulate();
            }


        }
    }
}
