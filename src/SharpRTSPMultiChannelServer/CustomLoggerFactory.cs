using Microsoft.Extensions.Logging;

namespace SharpRTSPMultiChannelServer
{
    public class CustomLoggerFactory : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        { }

        public ILogger CreateLogger(string categoryName)
        {
            return new CustomLogger();
        }

        public void Dispose()
        { }
    }
}
