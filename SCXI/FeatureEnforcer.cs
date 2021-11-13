using System;
using System.Threading;
using System.Timers;
using Hid.Net;
using Microsoft.Extensions.Logging;
using SCXI.SteamController;
using Timer = System.Timers.Timer;

namespace SCXI
{
    internal class FeatureEnforcer : IDisposable
    {
        private static readonly ILogger<FeatureEnforcer> Logger = LoggerFactory.CreateLogger<FeatureEnforcer>();

        private readonly Timer _timer = new Timer(3000);

        private readonly IHidDevice _device;

        private IntPtr _currentWindow = IntPtr.Zero;

        internal FeatureEnforcer(IHidDevice device)
        {
            _device = device;
        }

        internal void Start()
        {
            _timer.AutoReset = true;
            _timer.Enabled = true;
            _timer.Elapsed += Tick;
            _timer.Start();
            Logger.LogInformation("Started");
        }

        internal void Stop()
        {
            _timer.Stop();
            Logger.LogInformation("Stopped");
        }

        private void Tick(Object source, ElapsedEventArgs e)
        {
            var currentWindow = User32.GetForegroundWindow();
            if (_currentWindow == currentWindow) return;

            _currentWindow = currentWindow;
            Logger.LogDebug("Foreground window changed");

            Thread.Sleep(500);  // Give Steam a second to set features

            foreach (var feature in Features.BigPictureFocusedFeatures)
            {
                _device.WriteFeatureReport(feature);
            }
        }

        public void Dispose()
        {
            Stop();
            _timer.Dispose();
        }
    }
}
