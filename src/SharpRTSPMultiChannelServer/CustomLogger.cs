using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace SharpRTSPMultiChannelServer
{
    public class CustomLogger : ILogger
    {
        class CustomLoggerScope<TState> : IDisposable
        {
            public CustomLoggerScope(TState state)
            {
                State = state;
            }
            public TState State { get; }
            public void Dispose()
            { }
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return new CustomLoggerScope<TState>(state);
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    {
                        if (SharpRTSPMultiChannelServer.Log.TraceEnabled)
                        {
                            SharpRTSPMultiChannelServer.Log.Trace(formatter.Invoke(state, exception));
                        }
                    }
                    break;

                case LogLevel.Debug:
                    {
                        if (SharpRTSPMultiChannelServer.Log.DebugEnabled)
                        {
                            SharpRTSPMultiChannelServer.Log.Debug(formatter.Invoke(state, exception));
                        }
                    }
                    break;

                case LogLevel.Information:
                    {
                        if (SharpRTSPMultiChannelServer.Log.InfoEnabled)
                        {
                            SharpRTSPMultiChannelServer.Log.Info(formatter.Invoke(state, exception));
                        }
                    }
                    break;

                case LogLevel.Warning:
                    {
                        if (SharpRTSPMultiChannelServer.Log.WarnEnabled)
                        {
                            SharpRTSPMultiChannelServer.Log.Warn(formatter.Invoke(state, exception));
                        }
                    }
                    break;

                case LogLevel.Error:
                case LogLevel.Critical:
                    {
                        if (SharpRTSPMultiChannelServer.Log.ErrorEnabled)
                        {
                            SharpRTSPMultiChannelServer.Log.Error(formatter.Invoke(state, exception));
                        }
                    }
                    break;

                default:
                    {
                        Debug.WriteLine($"Unknown trace level: {logLevel}");
                    }
                    break;
            }
        }
    }
}
