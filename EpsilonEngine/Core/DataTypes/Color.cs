
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
        public Color(int packedValue)
        {
            R = (byte)packedValue;
            G = (byte)(packedValue >> 8);
            B = (byte)(packedValue >> 16);
            A = (byte)(packedValue >> 24);
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
        public override int GetHashCode()
        {
            return R | (G << 8) | (B << 16) | (A << 24);
        }
        #endregion
        #region Public Operators
        //Inverts a color.
        public static Color operator !(Color a)
        {
            a.R = (byte)(~a.R);
            a.G = (byte)(~a.G);
            a.B = (byte)(~a.B);
            return a;
        }

        //Decreases a color's intensity by scaling RGB to between 0 and b.
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
        //Increases a color's intensity by scaling RGB to between b and 255.
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

        //Increases a color's brightness by b.
        public static Color operator +(Color a, byte b)
        {
            a.R += b;
            a.G += b;
            a.B += b;
            return a;
        }
        //Decreases a color's brightness by b.
        public static Color operator -(Color a, byte b)
        {
            a.R -= b;
            a.G -= b;
            a.B -= b;
            return a;
        }

        //Additively mixes two colors.

        public static bool operator ==(Color a, Color b)
        {
            return a.R == b.R && a.G == b.G && a.B == b.B && a.A == b.A;
        }
        public static bool operator !=(Color a, Color b)
        {
            return a.R != b.R || a.G != b.G || a.B != b.B || a.A != b.A;
        }

        public static explicit operator Color(int source)
        {
            Color output;
            output.R = (byte)source;
            output.G = (byte)(source >> 8);
            output.B = (byte)(source >> 16);
            output.A = (byte)(source >> 24);
            return output;
        }
        public static explicit operator int(Color source)
        {
            return source.R | (source.G << 8) | (source.B << 16) | (source.A << 24);
        }
        #endregion
        #region Public Methods
        public uint Pack()
        {
            return R | ((uint)G << 8) | ((uint)B << 16) | ((uint)A << 24);
        }
        public Color Invert()
        {
            Color output = this;
            output.R = (byte)(R ^ byte.MaxValue);
            output.G = (byte)(G ^ byte.MaxValue);
            output.B = (byte)(B ^ byte.MaxValue);
            return output;
        }
        #endregion
        #region Public Static Methods
        //Mixes two colors with respect to alpha.
        public static Color Mix(Color front, Color back)
        {
            int tempA = front.A ^ byte.MaxValue;
            int temp0 = (255 * front.A) + (255 * back.A) - (front.A * back.A);
            int temp1 = 255 * front.A;
            int tempHue = back.R * back.A;
            front.R = (byte)((temp1 * front.R / temp0) + (((255 * tempHue) - (front.A * tempHue)) / temp0));
            tempHue = back.G * back.A;
            front.G = (byte)((temp1 * front.G / temp0) + (((255 * tempHue) - (front.A * tempHue)) / temp0));
            tempHue = back.B * back.A;
            front.B = (byte)((temp1 * front.B / temp0) + (((255 * tempHue) - (front.A * tempHue)) / temp0));
            front.A = (byte)((tempA - (back.A * tempA / 255)) ^ 255);
            return front;
        }
        //Mixes two colors by averaging their R, G, B, and A values.
        public static Color Average(Color a, Color b)
        {
            a.R = (byte)((a.R + b.R) >> 1);
            a.G = (byte)((a.G + b.G) >> 1);
            a.B = (byte)((a.B + b.B) >> 1);
            a.A = (byte)((a.A + b.A) >> 1);
            return a;
        }
        //Mixes two colors by averaging their R, G, and B values. The alpha of the output is always 255.
        public static Color AverageRGB(Color a, Color b)
        {
            a.R = (byte)((a.R + b.R) >> 1);
            a.G = (byte)((a.G + b.G) >> 1);
            a.B = (byte)((a.B + b.B) >> 1);
            a.A = byte.MaxValue;
            return a;
        }
        #endregion
    }
}