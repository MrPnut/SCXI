using System;

namespace SCXI.SteamController
{
    public class ControllerStateFactory
    {
        public static ControllerState FromHidRawData(byte[] data)
        {
            return new ControllerState(
                ((Buttons)data[9] & Buttons.A) == Buttons.A,
                ((Buttons)data[9] & Buttons.B) == Buttons.B,
                ((Buttons)data[9] & Buttons.X) == Buttons.X,
                ((Buttons)data[9] & Buttons.Y) == Buttons.Y,
                ((Buttons)data[10] & Buttons.LeftGrip) == Buttons.LeftGrip,
                ((Buttons)data[11] & Buttons.RightGrip) == Buttons.RightGrip,
                ((Buttons)data[10] & Buttons.Select) == Buttons.Select,
                ((Buttons)data[10] & Buttons.Start) == Buttons.Start,
                ((Buttons)data[10] & Buttons.Steam) == Buttons.Steam,
                ((Buttons)data[9] & Buttons.LeftBumper) == Buttons.LeftBumper,
                ((Buttons)data[9] & Buttons.RightBumper) == Buttons.RightBumper,
                BitConverter.ToInt16(data, 17),
                BitConverter.ToInt16(data, 19),
                ((Buttons)data[11] & Buttons.LeftStickClick) == Buttons.LeftStickClick,
                BitConverter.ToInt16(data, 21),
                BitConverter.ToInt16(data, 23),
                ((Buttons)data[11] & Buttons.RightStickClick) == Buttons.RightStickClick,
                ((LeftPad)data[11] & LeftPad.Click) == LeftPad.Click,
                data[12],
                data[13],
                ((LeftPad)data[11] & LeftPad.Touch) == LeftPad.Touch
            );
        }
    }
}
