using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common
{
    public interface ILoggerHost : IPluginHost<ILoggerPlugin>
    {
        void Write(string message, LogLevel level = LogLevel.DEBUG);

        void Write(Exception e, LogLevel level = LogLevel.DEBUG);

        void Trace(LogLevel level = LogLevel.DEBUG);
        
        void Trace(string append, LogLevel level = LogLevel.DEBUG);

        void Dump(string message, object obj, LogLevel level = LogLevel.DEBUG);
    }

    public enum LogLevel
    {
        ERROR = 0,
        WARNING = 1,
        INFO = 2,
        DEBUG = 3,
        FINEST = 4,
        TRACE = 5
    }
}
