using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SCXI.Config
{
    internal static class ConfigManager
    {
        private static readonly ILogger Logger = LoggerFactory.CreateLogger("SCXI.AppConfig.ConfigManager");

        private const string LoggingConfigFile = "Config/logging.json";
        private const string AppConfigFile = "Config/app.json";

        internal static IConfiguration LoadLoggingConfig()
        {
            return new ConfigurationBuilder()
                .AddJsonFile(LoggingConfigFile, optional: true, reloadOnChange: true)
                .Build();
        }

        internal static AppConfig LoadAppConfig()
        {
            var config = new AppConfig();

            new ConfigurationBuilder()
                .AddJsonFile(AppConfigFile, optional: true, reloadOnChange: true)
                .Build()
                .Bind(config);

            if (!File.Exists(AppConfigFile))
            {
                Logger.LogInformation($"{AppConfigFile} not found, generating default");
                File.WriteAllText(AppConfigFile, JsonConvert.SerializeObject(config, Formatting.Indented));
            }

            return config;
        }
    }
}

