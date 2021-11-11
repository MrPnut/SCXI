using System;
using System.Runtime.InteropServices;

namespace SCXI
{
    class User32
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();
    }
}

