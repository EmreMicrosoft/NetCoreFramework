﻿using log4net.Core;

namespace Core.CrossCutting.Logging.Log4Net
{
    public class SerializableLogEvent
    {
        private readonly LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }


        // Pass external values (session ids etc.) into log.
        public string UserName => _loggingEvent.UserName;
        public object MessageObject => _loggingEvent.MessageObject;

    }
}