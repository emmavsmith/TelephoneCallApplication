using System;
using System.Threading.Tasks;
using NLog;
using ILogger = MPD.Interviews.Interfaces.Logging.ILogger;

namespace MPD.Interviews.Common.Logging
{
    public class Logger : ILogger
    {
        private readonly NLog.Logger _logger;

        public Logger()
        {
            const string APP_NAME = "MPD.Interviews.Application";
            _logger = LogManager.GetLogger(APP_NAME);
        }

        public void Trace(string message)
        {
            if (_logger.IsTraceEnabled)
            {
                Log(LogLevel.Trace, message);
            }
        }

        public void Error(string message)
        {
            if (_logger.IsErrorEnabled)
            {
                Log(LogLevel.Error, message);
            }
        }

        public void Error(string message, Exception ex)
        {
            if (_logger.IsErrorEnabled)
            {
                Log(LogLevel.Error, ex, message);
            }
        }

        private void Log(LogLevel level, string format)
        {
            Task.Run(() =>
            {
                var eventInfo = new LogEventInfo(level, _logger.Name, null, format, null);
                _logger.Log(typeof(Logger), eventInfo);
            });
        }

        private void Log(LogLevel level, Exception exception, string format)
        {
            Task.Run(() =>
            {
                var eventInfo = new LogEventInfo(level, _logger.Name, null, format, null, exception);
                _logger.Log(typeof(Logger), eventInfo);
            });
        }
    }
}