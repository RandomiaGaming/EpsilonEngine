// Approved 2.0
// Ignore warnings for not overriding GetHashCode.
#pragma warning disable CS0659
#pragma warning disable CS0661
namespace EpsilonEngine
{
    public struct Color
    {
        #region Public Constants
        public static readonly Color White = new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
        public static readonly Color Black = new Color(byte.MinValue, byte.MinValue, byte.MinValue, byte.MaxValue);
        public static readonly Color Grey = new Color(150, 150, 150, byte.MaxValue);
        public static readonly Color DarkGrey = new Color(100, 100, 100, byte.MaxValue);
        public static readonly Color LightGrey = new Color(200, 200, 200, byte.MaxValue);

        public static readonly Color Transparent;
        public static readonly Color TransparentWhite = new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MinValue);
        public static readonly Color TransparentBlack;

        public static readonly Color Red = new Color(byte.MaxValue, byte.MinValue, byte.MinValue, byte.MaxValue);
        public static readonly Color Yellow = new Color(byte.MaxValue, byte.MaxValue, byte.MinValue, byte.MaxValue);
        public static readonly Color Green = new Color(byte.MinValue, byte.MaxValue, byte.MinValue, byte.MaxValue);
        public static readonly Color Aqua = new Color(byte.MinValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
        public static readonly Color Blue = new Color(byte.MinValue, byte.MinValue, byte.MaxValue, byte.MaxValue);
        public static readonly Color Pink = new Color(byte.MaxValue, byte.MinValue, byte.MaxValue, byte.MaxValue);

        public static readonly Color SoftRed = new Color(byte.MaxValue, 150, 150, byte.MaxValue);
        public static readonly Color SoftYellow = new Color(byte.MaxValue, byte.MaxValue, 150, byte.MaxValue);
        public static readonly Color SoftGreen = new Color(150, byte.MaxValue, 150, byte.MaxValue);
        public static readonly Color SoftAqua = new Color(150, byte.MaxValue, byte.MaxValue, byte.MaxValue);
        public static readonly Color SoftBlue = new Color(150, 150, byte.MaxValue, byte.MaxValue);
        public static readonly Color SoftPink = new Color(byte.MaxValue, 150, byte.MaxValue, byte.MaxValue);
        #endregion
        #region Public Variables
        public byte R;
        public byte G;
        public byte B;
        public byte A;
        #endregion
        #region Public Constructors
        public Color(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
            A = byte.MaxValue;
        }
        public Color(uint packedValue)
        {
#if UNSAFE
            unsafe
            {
                R = *(byte*)&packedValue;
                G = *(((byte*)&packedValue) + 1);
                B = *(((byte*)&packedValue) + 2);
                A = *(((byte*)&packedValue) + 3);
            }
#else
            R = (byte)packedValue;
            G = (byte)(packedValue >> 8);
            B = (byte)(packedValue >> 16);
            A = (byte)(packedValue >> 24);
#endif
        }
        public Color(Color source, byte a)
        {
            R = source.R;
            G = source.G;
            B = source.B;
            A = a;
        }
        #endregion
        #region Public Overrides
        public override string ToString()
        {
            return $"EpsilonEngine.Color({R}, {G}, {B}, {A})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Color))
            {
                return false;
            }
            else
            {
                Color a = (Color)obj;
                return R == a.R && G == a.G && B == a.B && A == a.A;
            }
        }
        #endregion
        #region Public Operators
        // Inverts a color.
        public static Color operator -(Color a)
        {
            a.R = (byte)~a.R;
            a.G = (byte)~a.G;
            a.B = (byte)~a.B;
            return a;
        }
        // Decreases a color's intensity by scaling RGB to between 0 and b.
        public static Color operator /(Color a, byte b)
        {
            if (b is 0)
            {
                a.R = 0;
                a.G = 0;
                a.B = 0;
            }
            else
            {
                a.R = (byte)((a.R * b) / byte.MaxValue);
                a.G = (byte)((a.G * b) / byte.MaxValue);
                a.B = (byte)((a.B * b) / byte.MaxValue);
            }
            return a;
        }
        // Increases a color's intensity by scaling RGB to between b and 255.
        public static Color operator *(Color a, byte b)
        {
            if (b is byte.MaxValue)
            {
                a.R = byte.MaxValue;
                a.G = byte.MaxValue;
                a.B = byte.MaxValue;
            }
            else
            {
                int scale = byte.MaxValue - b;
                a.R = (byte)(b + ((a.R * scale) / byte.MaxValue));
                a.G = (byte)(b + ((a.G * scale) / byte.MaxValue));
                a.B = (byte)(b + ((a.B * scale) / byte.MaxValue));
            }
            return a;
        }
        // Increases a color's brightness by b.
        public static Color operator +(Color a, byte b)
        {
            int intR = a.R + b;
            int intG = a.G + b;
            int intB = a.B + b;
            a.R = intR > byte.MaxValue ? byte.MaxValue : (byte)intR;
            a.G = intG > byte.MaxValue ? byte.MaxValue : (byte)intG;
            a.B = intB > byte.MaxValue ? byte.MaxValue : (byte)intB;
            return a;
        }
        // Decreases a color's brightness by b.
        public static Color operator -(Color a, byte b)
        {
            int intR = a.R - b;
            int intG = a.G - b;
            int intB = a.B - b;
            a.R = (byte)(intR < 0 ? 0 : intR);
            a.G = (byte)(intG < 0 ? 0 : intG);
            a.B = (byte)(intB < 0 ? 0 : intB);
            return a;
        }
        // Mixes two colors with respect to their alpha.
        public static Color operator +(Color a, Color b)
        {
            int tempA = a.A ^ byte.MaxValue;
            int temp0 = (byte.MaxValue * a.A) + (byte.MaxValue * b.A) - (a.A * b.A);
            int temp1 = byte.MaxValue * a.A;
            int tempHue = b.R * b.A;
            a.R = (byte)((temp1 * a.R / temp0) + (((byte.MaxValue * tempHue) - (a.A * tempHue)) / temp0));
            tempHue = b.G * b.A;
            a.G = (byte)((temp1 * a.G / temp0) + (((byte.MaxValue * tempHue) - (a.A * tempHue)) / temp0));
            tempHue = b.B * b.A;
            a.B = (byte)((temp1 * a.B / temp0) + (((byte.MaxValue * tempHue) - (a.A * tempHue)) / temp0));
            a.A = (byte)((tempA - (b.A * tempA / byte.MaxValue)) ^ byte.MaxValue);
            return a;
        }
        // Returns the average of two colors.
        public static Color operator *(Color a, Color b)
        {
            a.R = (byte)((a.R + b.R) >> 1);
            a.G = (byte)((a.G + b.G) >> 1);
            a.B = (byte)((a.B + b.B) >> 1);
            a.A = (byte)((a.A + b.A) >> 1);
            return a;
        }
        // Returns the average RGB of two colors with full opacity.
        public static Color operator /(Color a, Color b)
        {
            a.R = (byte)((a.R + b.R) >> 1);
            a.G = (byte)((a.G + b.G) >> 1);
            a.B = (byte)((a.B + b.B) >> 1);
            a.A = byte.MaxValue;
            return a;
        }
        // Packs the R, G, B, and A values of a color into a single uint.
        public static explicit operator uint(Color a)
        {
#if UNSAFE
            unsafe
            {
                byte* packedArray = stackalloc byte[4] { a.R, a.G, a.B, a.A };
                return *(uint*)packedArray;
            }
#else
            return R | ((uint)G << 8) | ((uint)B << 16) | ((uint)A << 24);
#endif
        }
        public static bool operator ==(Color a, Color b)
        {
            return a.R == b.R && a.G == b.G && a.B == b.B && a.A == b.A;
        }
        public static bool operator !=(Color a, Color b)
        {
            return a.R != b.R || a.G != b.G || a.B != b.B || a.A != b.A;
        }
        #endregion
    }
}