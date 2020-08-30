using SCXI.SteamController;

namespace SCXI
{
    internal class ControllerStateMapper
    {
        public StateMapping MapState(ControllerState state)
        {
            short leftThumbX = 0, leftThumbY = 0;
            bool up = false, down = false, left = false, right = false;

            if (!state.LeftPadTouched && !state.LeftPadClick)
            {
                leftThumbX = state.LeftStickX;
                leftThumbY = state.LeftStickY;
            }

            if (state.LeftPadClick)
            {
                if (state.LeftStickX <= short.MinValue / 4)
                {
                    left = true;
                }

                if (state.LeftStickX >= short.MaxValue / 4)
                {
                    right = true;
                }

                if (state.LeftStickY <= short.MinValue / 4)
                {
                    down = true;
                }

                if (state.LeftStickY >= short.MaxValue / 4)
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
