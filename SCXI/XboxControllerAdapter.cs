using System;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;
using Nefarius.ViGEm.Client.Targets.Xbox360.Exceptions;

namespace SCXI
{
    internal class XboxControllerAdapter : IDisposable
    {
        private readonly ViGEmClient _client;

        private readonly IXbox360Controller _controller;

        public int UserIndex => _controller.UserIndex;

        private XboxControllerAdapter(ViGEmClient client, IXbox360Controller controller)
        {
            _client = client;
            _controller = controller;
        }
        internal static XboxControllerAdapter Create()
        {
            var client= new ViGEmClient();
            var controller = client.CreateXbox360Controller();
            controller.Connect();
            TryWaitUntilConnected(controller);
            controller.AutoSubmitReport = false;
            
            return new XboxControllerAdapter(client, controller);
        }

        internal void UpdateState(StateMapping mapping)
        {
            _controller.ResetReport();
            _controller.SetButtonState(Xbox360Button.A, mapping.A);
            _controller.SetButtonState(Xbox360Button.B, mapping.B);
            _controller.SetButtonState(Xbox360Button.X, mapping.X);
            _controller.SetButtonState(Xbox360Button.Y, mapping.Y);
            _controller.SetButtonState(Xbox360Button.Back, mapping.Back);
            _controller.SetButtonState(Xbox360Button.Start, mapping.Start);
            _controller.SetButtonState(Xbox360Button.Guide, mapping.Guide);
            _controller.SetButtonState(Xbox360Button.LeftShoulder, mapping.LeftShoulder);
            _controller.SetButtonState(Xbox360Button.RightShoulder, mapping.RightShoulder);
            _controller.SetButtonState(Xbox360Button.LeftThumb, mapping.LeftThumb);
            _controller.SetButtonState(Xbox360Button.RightThumb, mapping.RightThumb);
            _controller.SetAxisValue(Xbox360Axis.LeftThumbX, mapping.LeftThumbX);
            _controller.SetAxisValue(Xbox360Axis.LeftThumbY, mapping.LeftThumbY);
            _controller.SetAxisValue(Xbox360Axis.RightThumbX, mapping.RightThumbX);
            _controller.SetAxisValue(Xbox360Axis.RightThumbY, mapping.RightThumbY);
            _controller.SetSliderValue(Xbox360Slider.LeftTrigger, mapping.LeftTrigger);
            _controller.SetSliderValue(Xbox360Slider.RightTrigger, mapping.RightTrigger);
            _controller.SetButtonState(Xbox360Button.Up, mapping.Up);
            _controller.SetButtonState(Xbox360Button.Down, mapping.Down);
            _controller.SetButtonState(Xbox360Button.Left, mapping.Left);
            _controller.SetButtonState(Xbox360Button.Right, mapping.Right);
            _controller.SubmitReport();
        }

        private static void TryWaitUntilConnected(IXbox360Controller controller)
        {
            for (var i = 0; i < 5; i++)
            {
                try
                {
                    var _ = controller.UserIndex;
                    break;
                }
                catch (Xbox360UserIndexNotReportedException)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            try
            {
                _controller.Disconnect();
                _client.Dispose();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~XboxControllerAdapter()
        {
            Dispose(false);
        }
    }
}
