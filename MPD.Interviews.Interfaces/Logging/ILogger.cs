using System;

namespace MPD.Interviews.Interfaces.Logging
{
    public interface ILogger
    {
        void Trace(string message);
        void Error(string message);
        void Error(string message, Exception ex);
    }
}