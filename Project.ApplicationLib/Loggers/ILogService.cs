using System;

namespace CommonLib.Loggers
{
    interface ILogService
    {
        void Fatal(string message);
        void Error(string message);
        void Error(string message, Exception e);
        void Warn(string message);
        void Info(string message);
        void Debug(string message);
    }
}
