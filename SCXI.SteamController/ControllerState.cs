namespace SCXI.SteamController
{
    public readonly struct ControllerState
    { 
        public bool A { get; }

        public bool B { get; }

        public bool X { get; }

        public bool Y { get; }

        public bool LeftGrip { get; }

        public bool RightGrip { get; }

        public bool Select { get; }

        public bool Start { get; }

        public bool Steam { get; }

        public bool LeftBumper { get; }

        public bool RightBumper { get; }

        public short LeftStickX { get; }

        public short LeftStickY { get; }

        public bool LeftStickClick { get; }

        public short RightPadX { get; }

        public short RightPadY { get; }

        public bool RightPadClick { get; }

        public bool LeftPadClick { get; }

        public byte LeftTrigger { get; }

        public byte RightTrigger { get; }

        public bool LeftPadTouched { get; }

        internal ControllerState(bool a, bool b, bool x,
            bool y, bool leftGrip, bool rightGrip,
            bool select, bool start, bool steam,
            bool leftBumper, bool rightBumper, short leftStickX,
            short leftStickY, bool leftStickClick, short rightPadX,
            short rightPadY, bool rightPadClick, bool leftPadClick,
            byte leftTrigger, byte rightTrigger, bool leftPadTouched)
        {
            this.A = a;
            this.B = b;
            this.X = x;
            this.Y = y;
            this.LeftGrip = leftGrip;
            this.RightGrip = rightGrip;
            this.Select = select;
            this.Start = start;
            this.Steam = steam;
            this.LeftBumper = leftBumper;
            this.RightBumper = rightBumper;
            this.LeftStickX = leftStickX;
            this.LeftStickY = leftStickY;
            this.LeftStickClick = leftStickClick;
            this.RightPadX = rightPadX;
            this.RightPadY = rightPadY;
            this.RightPadClick = rightPadClick;
            this.LeftPadClick = leftPadClick;
            this.LeftTrigger = leftTrigger;
            this.RightTrigger = rightTrigger;
            this.LeftPadTouched = leftPadTouched;
        }

        public override string ToString()
        {
            return $"A: {(A ? "on" : "off")}, " +
                   $"B: {(B ? "on" : "off")}, " +
                   $"X: {(X ? "on" : "off")}, " +
                   $"Y: {(Y ? "on" : "off")}, " +
                   $"LeftGrip: {(LeftGrip ? "on" : "off")}, " +
                   $"RightGrip: {(RightGrip ? "on" : "off")}, " +
                   $"Select: {(Select ? "on" : "off")}, " +
                   $"Start: {(Start ? "on" : "off")}, " +
                   $"Steam: {(Steam ? "on" : "off")}, " +
                   $"LeftBumper: {(LeftBumper ? "on" : "off")}, " +
                   $"RightBumper: {(RightBumper ? "on" : "off")}, " +
                   $"LeftStickX: {LeftStickX}, " +
                   $"LeftStickY: {LeftStickY}, " +
                   $"LeftStickClick: {(LeftStickClick ? "on" : "off")}, " +
                   $"RightPadX: {RightPadX}, " +
                   $"RightPadY: {RightPadY}, " +
                   $"RightPadClick: {(RightPadClick ? "on" : "off")}, " +
                   $"LeftPadClick: {(LeftPadClick ? "on" : "off")}, " +
                   $"LeftTrigger: {RightTrigger}, " +
                   $"RightTrigger: {RightTrigger}";
        }

        public static ControllerState Initial => new ControllerState();
        
        public bool Equals(ControllerState other)
        {
            return A == other.A && B == other.B && X == other.X && Y == other.Y && LeftGrip == other.LeftGrip && RightGrip == other.RightGrip && Select == other.Select && Start == other.Start && Steam == other.Steam && LeftBumper == other.LeftBumper && RightBumper == other.RightBumper && LeftStickX == other.LeftStickX && LeftStickY == other.LeftStickY && LeftStickClick == other.LeftStickClick && RightPadX == other.RightPadX && RightPadY == other.RightPadY && RightPadClick == other.RightPadClick && LeftPadClick == other.LeftPadClick && LeftTrigger == other.LeftTrigger && RightTrigger == other.RightTrigger && LeftPadTouched == other.LeftPadTouched;
        }

        public override bool Equals(object obj)
        {
            return obj is ControllerState other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = A.GetHashCode();
                hashCode = (hashCode * 397) ^ B.GetHashCode();
                hashCode = (hashCode * 397) ^ X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ LeftGrip.GetHashCode();
                hashCode = (hashCode * 397) ^ RightGrip.GetHashCode();
                hashCode = (hashCode * 397) ^ Select.GetHashCode();
                hashCode = (hashCode * 397) ^ Start.GetHashCode();
                hashCode = (hashCode * 397) ^ Steam.GetHashCode();
                hashCode = (hashCode * 397) ^ LeftBumper.GetHashCode();
                hashCode = (hashCode * 397) ^ RightBumper.GetHashCode();
                hashCode = (hashCode * 397) ^ LeftStickX.GetHashCode();
                hashCode = (hashCode * 397) ^ LeftStickY.GetHashCode();
                hashCode = (hashCode * 397) ^ LeftStickClick.GetHashCode();
                hashCode = (hashCode * 397) ^ RightPadX.GetHashCode();
                hashCode = (hashCode * 397) ^ RightPadY.GetHashCode();
                hashCode = (hashCode * 397) ^ RightPadClick.GetHashCode();
                hashCode = (hashCode * 397) ^ LeftPadClick.GetHashCode();
                hashCode = (hashCode * 397) ^ LeftTrigger.GetHashCode();
                hashCode = (hashCode * 397) ^ RightTrigger.GetHashCode();
                hashCode = (hashCode * 397) ^ LeftPadTouched.GetHashCode();
                return hashCode;
            }
        }
    }
}
