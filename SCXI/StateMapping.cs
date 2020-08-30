using System;

namespace SCXI
{
    internal readonly struct StateMapping
    {
        public bool A { get; }

        public bool B { get; }

        public bool X { get; }

        public bool Y { get; }

        public bool Back { get; }

        public bool Start { get; }

        public bool Guide { get; }

        public bool LeftShoulder { get; }

        public bool RightShoulder { get; }

        public short LeftThumbX { get; }

        public short LeftThumbY { get; }

        public bool LeftThumb { get; }

        public short RightThumbX { get; }

        public short RightThumbY { get; }

        public bool RightThumb { get; }

        public byte LeftTrigger { get; }

        public byte RightTrigger { get; }

        public bool Up { get; }

        public bool Down { get; }

        public bool Left { get; }

        public bool Right { get; }

        internal StateMapping(bool a, bool b, bool x,
            bool y, bool back, bool start, bool guide,
            bool leftShoulder, bool rightShoulder, short leftThumbX,
            short leftThumbY, bool leftThumb, short rightThumbX,
            short rightThumbY, bool rightThumb, byte leftTrigger, byte rightTrigger,
            bool up, bool down, bool left, bool right)
        {
            this.A = a;
            this.B = b;
            this.X = x;
            this.Y = y;
            this.Back = back;
            this.Start = start;
            this.Guide = guide;
            this.LeftShoulder = leftShoulder;
            this.RightShoulder = rightShoulder;
            this.LeftThumbX = leftThumbX;
            this.LeftThumbY = leftThumbY;
            this.LeftThumb = leftThumb;
            this.RightThumbX = rightThumbX;
            this.RightThumbY = rightThumbY;
            this.RightThumb = rightThumb;
            this.LeftTrigger = leftTrigger;
            this.RightTrigger = rightTrigger;
            this.Up = up;
            this.Down = down;
            this.Left = left;
            this.Right = right;
        }

        internal static StateMapping Initial => new StateMapping();
        
        public bool Equals(StateMapping other)
        {
            return A == other.A && B == other.B && X == other.X && Y == other.Y && Back == other.Back && Start == other.Start && Guide == other.Guide && LeftShoulder == other.LeftShoulder && RightShoulder == other.RightShoulder && LeftThumbX == other.LeftThumbX && LeftThumbY == other.LeftThumbY && LeftThumb == other.LeftThumb && RightThumbX == other.RightThumbX && RightThumbY == other.RightThumbY && RightThumb == other.RightThumb && LeftTrigger == other.LeftTrigger && RightTrigger == other.RightTrigger && Up == other.Up && Down == other.Down && Left == other.Left && Right == other.Right;
        }

        public override bool Equals(object obj)
        {
            return obj is StateMapping other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(A);
            hashCode.Add(B);
            hashCode.Add(X);
            hashCode.Add(Y);
            hashCode.Add(Back);
            hashCode.Add(Start);
            hashCode.Add(Guide);
            hashCode.Add(LeftShoulder);
            hashCode.Add(RightShoulder);
            hashCode.Add(LeftThumbX);
            hashCode.Add(LeftThumbY);
            hashCode.Add(LeftThumb);
            hashCode.Add(RightThumbX);
            hashCode.Add(RightThumbY);
            hashCode.Add(RightThumb);
            hashCode.Add(LeftTrigger);
            hashCode.Add(RightTrigger);
            hashCode.Add(Up);
            hashCode.Add(Down);
            hashCode.Add(Left);
            hashCode.Add(Right);
            return hashCode.ToHashCode();
        }
    }
}
