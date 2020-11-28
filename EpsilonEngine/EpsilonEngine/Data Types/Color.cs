using System;
namespace EpsilonEngine
{
    public struct Color
    {
        public static readonly Color White = new Color(255, 255, 255, 255);
        public static readonly Color Black = new Color(0, 0, 0, 255);
        public static readonly Color Clear = new Color(255, 255, 255, 0);
        public static readonly Color Red = new Color(255, 0, 0, 255);
        public static readonly Color Green = new Color(0, 255, 0, 255);
        public static readonly Color Blue = new Color(0, 0, 255, 255);
        public static readonly Color Pink = new Color(255, 0, 255, 255);

        public byte r;
        public byte g;
        public byte b;
        public byte a;
        public Color(byte r, byte g, byte b)
        {
            if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.r = r;
            this.g = g;
            this.b = b;
            a = 255;
        }
        public Color(byte r, byte g, byte b, byte a)
        {
            if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255 || a < 0 || a > 255)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
        public override string ToString()
        {
            return $"(r: {r}, g: {g}, b: {b})";
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
            return (a.r == b.r) && (a.g == b.g) && (a.b == b.b) && (a.a == b.a);
        }
        public static bool operator !=(Color a, Color b)
        {
            return !(a == b);
        }
        public static Color EvenMix(Color a, Color b)
        {
            return new Color((byte)((a.r + b.r) / 2), (byte)((a.g + b.g) / 2), (byte)((a.b + b.b) / 2), 255);
        }
        public static Color Mix(Color back, Color front)
        {
            if (front.a == 0)
            {
                return back;
            }
            else if (front.a == 255)
            {
                return front;
            }
            else
            {
                return new Color((byte)((back.r + front.r) / 2), (byte)((back.g + front.g) / 2), (byte)((back.b + front.b) / 2), 255);
            }
        }
    }
}