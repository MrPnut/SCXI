using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SCXI
{
    internal static class LoggerFactory
    {
        private static ILoggerFactory _loggerFactory;

        internal static void Init(IConfiguration loggingConfiguration)
        {
            _loggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
            {
                builder.AddConfiguration(loggingConfiguration);

                builder.AddSimpleConsole(options =>
                {
                    options.IncludeScopes = false;
                    options.SingleLine = true;
                    options.TimestampFormat = "hh:mm:ss ";
                });
            });
        }

        internal static ILogger<T> CreateLogger<T>() => _loggerFactory.CreateLogger<T>();

        internal static ILogger CreateLogger(string category) => _loggerFactory.CreateLogger(category);
    }
}
