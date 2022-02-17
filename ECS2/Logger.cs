using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS2
{
    public interface ILogger
    {
        void WriteLogLine(string message);
    }

    public class Logger : ILogger
    {
        public void WriteLogLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }

    public class FakeLogger : ILogger
    {

        public void WriteLogLine(string message)
        {
            LogResult = message;
        }

        public string LogResult { get; set; } = "";

    }
}
