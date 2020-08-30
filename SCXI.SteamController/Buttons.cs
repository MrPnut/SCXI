using System;

namespace SCXI.SteamController
{
    [Flags]
    internal enum Buttons
    {
        A = 0x80,
        B = 0x20,
        X = 0x40,
        Y = 0x10,
        LeftGrip = 0x80,
        RightGrip = 0x01,
        Select = 0x10,
        Start = 0x40,
        Steam = 0x20,
        LeftBumper = 0x08,
        RightBumper = 0x04,
        LeftStickClick = 0x42,
        RightStickClick = 0x14,
    }

    [Flags]
    internal enum LeftPad
    {
        Touch = 0x08,
        Click = 0x0a
    }
}
