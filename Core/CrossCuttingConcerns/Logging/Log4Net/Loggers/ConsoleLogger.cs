﻿using log4net;

namespace Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class ConsoleLogger : LoggerService
    {
        public ConsoleLogger() : base(LogManager.GetLogger(typeof(ConsoleLogger)))
        {
        }
    }
}