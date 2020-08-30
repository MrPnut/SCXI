using System;

namespace SCXI.SteamController
{
    public class ControllerStateFactory
    {
        public static ControllerState FromHidRawData(byte[] data)
        {
            return new ControllerState(
                ((Buttons)data[8] & Buttons.A) == Buttons.A,
                ((Buttons)data[8] & Buttons.B) == Buttons.B,
                ((Buttons)data[8] & Buttons.X) == Buttons.X,
                ((Buttons)data[8] & Buttons.Y) == Buttons.Y,
                ((Buttons)data[9] & Buttons.LeftGrip) == Buttons.LeftGrip,
                ((Buttons)data[10] & Buttons.RightGrip) == Buttons.RightGrip,
                ((Buttons)data[9] & Buttons.Select) == Buttons.Select,
                ((Buttons)data[9] & Buttons.Start) == Buttons.Start,
                ((Buttons)data[9] & Buttons.Steam) == Buttons.Steam,
                ((Buttons)data[8] & Buttons.LeftBumper) == Buttons.LeftBumper,
                ((Buttons)data[8] & Buttons.RightBumper) == Buttons.RightBumper,
                BitConverter.ToInt16(data, 16),
                BitConverter.ToInt16(data, 18),
                ((Buttons)data[10] & Buttons.LeftStickClick) == Buttons.LeftStickClick,
                BitConverter.ToInt16(data, 20),
                BitConverter.ToInt16(data, 22),
                ((Buttons)data[10] & Buttons.RightStickClick) == Buttons.RightStickClick,
                ((LeftPad)data[10] & LeftPad.Click) == LeftPad.Click,
                data[11],
                data[12],
                ((LeftPad)data[10] & LeftPad.Touch) == LeftPad.Touch
            );
        }
    }
}
