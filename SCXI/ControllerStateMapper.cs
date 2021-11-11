using SCXI.Config;
using SCXI.SteamController;

namespace SCXI
{
    internal class ControllerStateMapper
    {
        private readonly InputOptions _inputOptions;
        
        internal ControllerStateMapper(InputOptions inputOptions)
        {
            _inputOptions = inputOptions;
        }

        public StateMapping MapState(ControllerState state)
        {
            short leftThumbX = 0, leftThumbY = 0;
            bool up = false, down = false, left = false, right = false;

            if (!state.LeftPadTouched && !state.LeftPadClick)
            {
                leftThumbX = state.LeftStickX;
                leftThumbY = state.LeftStickY;
            }

            if (state.LeftPadClick && _inputOptions.DPadMode == DPadMode.Click || 
                state.LeftPadTouched && _inputOptions.DPadMode == DPadMode.Touch)
            {
                if (state.LeftStickX <= short.MinValue * .30)
                {
                    left = true;
                }

                if (state.LeftStickX >= short.MaxValue * .30)
                {
                    right = true;
                }

                if (state.LeftStickY <= short.MinValue * .30)
                {
                    down = true;
                }

                if (state.LeftStickY >= short.MaxValue * .30)
                {
                    up = true;
                }
            }

            return new StateMapping
            (
                state.A, state.B, state.X,
                state.Y, state.Select, state.Start,
                state.Steam, state.LeftBumper, state.RightBumper,
                leftThumbX, leftThumbY, state.LeftPadClick,
                state.RightPadX, state.RightPadY, state.RightPadClick,
                state.LeftTrigger, state.RightTrigger,
                up, down, left, right
            );
        }
    }
}
