using log4net;

namespace Core.CrossCutting.Logging.Log4Net.Loggers
{
    public class EventLogger : LoggerService
    {
        public EventLogger() : base(LogManager.GetLogger(typeof(EventLogger)))
        {
        }
    }
}