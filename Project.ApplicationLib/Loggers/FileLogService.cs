using System;
using System.IO;
using log4net;
using System.Reflection;
using System.Xml;
using log4net.Config;

namespace CommonLib.Loggers
{
    public sealed class FileLogService : ILogService
    {
        readonly ILog _logger;

        static FileLogService()
        {
            // Gets directory path of the calling application
            // RelativeSearchPath is null if the executing assembly i.e. calling assembly is a
            // stand alone exe file (Console, WinForm, etc). 
            // RelativeSearchPath is not null if the calling assembly is a web hosted application i.e. a web site
            var log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            var log4NetConfigFilePath = Path.Combine(log4NetConfigDirectory, "loggers\\log4net.config");
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(log4NetConfigFilePath));
            //log4net.Util.LogLog.InternalDebugging = true;
        }

        public FileLogService(Type logClass)
        {
            _logger = LogManager.GetLogger(logClass);
        }

        //public FileLogService(string name)
        //{
        //    _logger = LogManager.GetLogger(name);
        //}

        public void Fatal(string errorMessage)
        {
            if (_logger.IsFatalEnabled)
                _logger.Fatal(errorMessage);
        }

        public void Error(string errorMessage)
        {
            if (_logger.IsErrorEnabled)
                _logger.Error(errorMessage);
        }

        public void Error(string errorMessage, Exception e)
        {
            if (_logger.IsErrorEnabled)
                _logger.Error(errorMessage, e);
        }

        public void Warn(string message)
        {
            if (_logger.IsWarnEnabled)
            {
                //GlobalContext.Properties["UserId"] = UserId;
                _logger.Warn(message);
            }
        }

        public void Info(string message)
        {
            if (_logger.IsInfoEnabled)
                _logger.Info(message);
        }

        public void Debug(string message)
        {
            if (_logger.IsDebugEnabled)
                _logger.Debug(message);
        }
    }
}
