using System;

namespace RG_Engine
{
    public sealed class RG_Color
    {
        public int r = 255;
        public int g = 255;
        public int b = 255;

        private RG_Color() { }
        public static RG_Color Create()
        {
            RG_Color Output = new RG_Color();
            Output.r = 255;
            Output.g = 255;
            Output.b = 255;
            return Output;
        }
        public static RG_Color Create(int r, int g, int b)
        {
            RG_Color Output = new RG_Color();
            Output.r = r;
            Output.g = g;
            Output.b = b;
            return Output;
        }

        public override string ToString()
        {
            return $"(r:{r}, g:{g}, b:{b})";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(RG_Color))
            {
                return this == (RG_Color)obj;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(RG_Color A, RG_Color B)
        {
            return (A.r == B.r) && (A.g == B.g) && (A.b == B.b);
        }
        public static bool operator !=(RG_Color A, RG_Color B)
        {
            return !(A == B);
        }

        public static RG_Color operator +(RG_Color A, RG_Color B)
        {
            return Create(Math_Helper.Clamp(A.r + B.r, 0, 255), Math_Helper.Clamp(A.g + B.g, 0, 255), Math_Helper.Clamp(A.b + B.b, 0, 255));
        }
        public static RG_Color operator -(RG_Color A, RG_Color B)
        {
            return Create(Math_Helper.Clamp(A.r - B.r, 0, 255), Math_Helper.Clamp(A.g - B.g, 0, 255), Math_Helper.Clamp(A.b - B.b, 0, 255));
        }
        public static RG_Color operator +(RG_Color A, int B)
        {
            return Create(Math_Helper.Clamp(A.r + B, 0, 255), Math_Helper.Clamp(A.g + B, 0, 255), Math_Helper.Clamp(A.b + B, 0, 255));
        }
        public static RG_Color operator -(RG_Color A, int B)
        {
            return Create(Math_Helper.Clamp(A.r - B, 0, 255), Math_Helper.Clamp(A.g - B, 0, 255), Math_Helper.Clamp(A.b - B, 0, 255));
        }

        public static RG_Color operator *(RG_Color A, RG_Color B)
        {
            return Create(Math_Helper.Clamp(A.r * B.r, 0, 255), Math_Helper.Clamp(A.g * B.g, 0, 255), Math_Helper.Clamp(A.b * B.b, 0, 255));
        }
        public static RG_Color operator /(RG_Color A, RG_Color B)
        {
            return Create(Math_Helper.Clamp(A.r / B.r, 0, 255), Math_Helper.Clamp(A.g / B.g, 0, 255), Math_Helper.Clamp(A.b / B.b, 0, 255));
        }
        public static RG_Color operator *(RG_Color A, int B)
        {
            return Create(Math_Helper.Clamp(A.r * B, 0, 255), Math_Helper.Clamp(A.g * B, 0, 255), Math_Helper.Clamp(A.b * B, 0, 255));
        }
        public static RG_Color operator /(RG_Color A, int B)
        {
            return Create(Math_Helper.Clamp(A.r / B, 0, 255), Math_Helper.Clamp(A.g / B, 0, 255), Math_Helper.Clamp(A.b / B, 0, 255));
        }

        public static RG_Color operator +(RG_Color A)
        {
            return A.Clone();
        }
        public static RG_Color operator -(RG_Color A)
        {
            return Create(255 - A.r, 255 - A.g, 255 - A.b);
        }

        public static RG_Color operator %(RG_Color A, RG_Color B)
        {
            return ((A + B) / 2).Clone();
        }

        public RG_Color Clone()
        {
            return Create(r, g, b);
        }
    }
}