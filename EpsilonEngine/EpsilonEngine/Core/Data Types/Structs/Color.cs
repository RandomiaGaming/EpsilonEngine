using System;
namespace EpsilonEngine
{
    public struct Color
    {
        public static readonly Color White = new Color(255, 255, 255, 255);
        public static readonly Color Grey = new Color(150, 150, 150, 255);
        public static readonly Color Black = new Color(0, 0, 0, 255);

        public static readonly Color Clear = new Color(255, 255, 255, 0);

        public static readonly Color Red = new Color(255, 0, 0, 255);
        public static readonly Color Yellow = new Color(255, 255, 0, 255);
        public static readonly Color Green = new Color(0, 255, 0, 255);
        public static readonly Color Aqua = new Color(0, 255, 255, 255);
        public static readonly Color Blue = new Color(0, 0, 255, 255);
        public static readonly Color Pink = new Color(255, 0, 255, 255);

        public static readonly Color SoftRed = new Color(255, 150, 150, 255);
        public static readonly Color SoftYellow = new Color(255, 255, 150, 255);
        public static readonly Color SoftGreen = new Color(150, 255, 150, 255);
        public static readonly Color SoftAqua = new Color(150, 255, 255, 255);
        public static readonly Color SoftBlue = new Color(150, 150, 255, 255);
        public static readonly Color SoftPink = new Color(255, 150, 255, 255);

        private byte _r;
        public byte r { get { return _r; } }
        private byte _g;
        public byte g { get { return _g; } }
        private byte _b;
        public byte b { get { return _b; } }
        private byte _a;
        public byte a { get { return _a; } }
        public Color(byte r, byte g, byte b)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = 255;
        }
        public Color(byte r, byte g, byte b, byte a)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }
        public override string ToString()
        {
            return $"EpsilonEngine.Color({r}, {g}, {b}, {a})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Color))
            {
                return false;
            }
            else
            {
                return this == (Color)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Color a, Color b)
        {
            return a.r == b.r && a.g == b.g && a.b == b.b && a.a == b.a;
        }
        public static bool operator !=(Color a, Color b)
        {
            return !(a == b);
        }
    }
}