using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace SCXI
{
    internal class Program
    {
        private static Scxi _scxi;

        internal static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += ProcessExit;
            Console.CancelKeyPress += ProcessExit;

            DrawBanner();
            _scxi = await Scxi.Create();

            using (_scxi)
            {
                Console.WriteLine($"Created XInput controller with UserIndex {_scxi.UserIndex}");
                Console.WriteLine("Running.  Cress CTRL+C to exit (and disconnect emulated XInput controller)");
                Console.WriteLine();
                
                await _scxi.Run();
            }
        }

        private static void DrawBanner()
        {
            Console.WriteLine("   _____ _______  __ ____");
            Console.WriteLine("  / ___// ____/ |/ //  _/");
            Console.WriteLine("  \\__ \\/ /    |   / / /  ");
            Console.WriteLine(" ___/ / /___ /   |_/ /   ");
            Console.WriteLine("/____/\\____//_/|_/___/   ");
            Console.WriteLine();

            var entryAssembly = Assembly.GetEntryAssembly();

            if (entryAssembly != null)
            {
                var info = FileVersionInfo.GetVersionInfo(entryAssembly.Location);

                Console.WriteLine(info.ProductName);
                Console.WriteLine($"Version: {info.ProductVersion}");
                Console.WriteLine(info.CompanyName);
            }

            Console.WriteLine();
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
