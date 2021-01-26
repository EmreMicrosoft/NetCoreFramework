using log4net;

namespace Core.CrossCutting.Logging.Log4Net.Loggers
{
    public class DatabaseLogger : LoggerService
    {
        public DatabaseLogger() : base(LogManager.GetLogger(typeof(DatabaseLogger)))
        {
        }
    }
}