﻿using log4net;

namespace Core.CrossCutting.Logging.Log4Net.Loggers
{
    public class FileLogger : LoggerService
    {
        public FileLogger() : base(LogManager.GetLogger(typeof(FileLogger)))
        {
        }
    }
}