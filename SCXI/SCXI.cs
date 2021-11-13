using System;
using System.Linq;
using System.Threading.Tasks;
using Device.Net;
using Hid.Net;
using Hid.Net.Windows;
using SCXI.SteamController;
using SCXI.Config;

namespace SCXI
{
    public class Scxi : IDisposable
    {
        private readonly IDevice _device;

        private readonly XboxControllerAdapter _controllerAdapter;

        private readonly FeatureEnforcer _featureEnforcer;

        private readonly ControllerStateMapper _mapper;

        private ControllerState _previousState = ControllerState.Initial;

        private StateMapping _previousMapping = StateMapping.Initial;

        public int UserIndex => _controllerAdapter.UserIndex;

        private Scxi(IHidDevice device, XboxControllerAdapter controllerAdapter, AppConfig config)
        {
            _device = device;
            _controllerAdapter = controllerAdapter;
            _featureEnforcer = new FeatureEnforcer(device);
            _mapper = new ControllerStateMapper(config.Input);
        }

        internal static async Task<Scxi> Create(AppConfig config)
        {
            var hidFactory = new FilterDeviceDefinition(vendorId: 10462, productId: 4418, label: "Steam Controller")
                .CreateWindowsHidDeviceFactory();

            var deviceDefinitions =
                await hidFactory.GetConnectedDeviceDefinitionsAsync();

            var device = await hidFactory.GetDeviceAsync(deviceDefinitions.Single(d => d.DeviceId.Contains("mi_01")));

            await device.InitializeAsync();
            
            return new Scxi((IHidDevice)device, XboxControllerAdapter.Create(), config);
        }

        internal async Task Run()
        {
            _featureEnforcer.Start();

            while (true)
            {
                var report = await _device.ReadAsync();
                
                var controllerState = ControllerStateFactory.FromHidRawData(report.Data);
                if (controllerState.Equals(_previousState)) continue;

                var mapping = _mapper.MapState(controllerState);
                if (mapping.Equals(_previousMapping)) continue;

                _previousState = controllerState;
                _previousMapping = mapping;
                
                _controllerAdapter.UpdateState(mapping);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            _featureEnforcer?.Dispose();
            _device?.Dispose();
            _controllerAdapter?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Scxi()
        {
            Dispose(false);
        }
    }
}
