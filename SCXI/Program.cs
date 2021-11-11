using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SCXI.Config;

namespace SCXI
{
    internal class Program
    {
        private static Scxi _scxi;

        private static ILogger<Program> _logger;

        internal static async Task Main(string[] args)
        {
            LoggerFactory.Init(ConfigManager.LoadLoggingConfig());
            _logger = LoggerFactory.CreateLogger<Program>();

            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
            
            AppDomain.CurrentDomain.ProcessExit += ProcessExit;
            Console.CancelKeyPress += ProcessExit;

            LogStartup();
            _scxi = await Scxi.Create(ConfigManager.LoadAppConfig());

            using (_scxi)
            {
                _logger.LogInformation($"Created XInput controller with UserIndex {_scxi.UserIndex}");
                _logger.LogInformation("Running.  Cress CTRL+C to exit (and disconnect emulated XInput controller)");

                try
                {
                    await _scxi.Run();
                }
                catch (Exception e)
                {
                    _logger.LogCritical("Fatal exception occurred", e);
                    Environment.Exit(1);
                }
            }
        }

        private static void LogStartup()
        {
            var entryAssembly = Assembly.GetEntryAssembly();

            if (entryAssembly == null) return;

            var info = FileVersionInfo.GetVersionInfo(entryAssembly.Location);

            _logger.LogInformation(info.ProductName);
            _logger.LogInformation($"Version: {info.ProductVersion}");
            _logger.LogInformation(info.CompanyName);
        }

        private static void ProcessExit(object sender, EventArgs e)
        {
            if (e is ConsoleCancelEventArgs)
            {
                Environment.Exit(0);
            }

            _scxi?.Dispose();
        }
    }
}
