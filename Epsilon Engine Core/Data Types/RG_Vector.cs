using System;

namespace Epsilon_Engine
{
    public sealed class RG_Vector
    {
        public double x = 0;
        public double y = 0;

        private RG_Vector() { }
        public static RG_Vector Create()
        {
            RG_Vector Output = new RG_Vector();
            Output.x = 0;
            Output.y = 0;
            return Output;
        }
        public static RG_Vector Create(double x, double y)
        {
            RG_Vector Output = new RG_Vector();
            Output.x = x;
            Output.y = y;
            return Output;
        }
        public override string ToString()
        {
            return $"({x},{y})";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(RG_Vector))
            {
                return this == (RG_Vector)obj;
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

        public static bool operator ==(RG_Vector A, RG_Vector B)
        {
            return (A.x == B.x) && (A.y == B.y);
        }
        public static bool operator !=(RG_Vector A, RG_Vector B)
        {
            return !(A == B);
        }

        public static RG_Vector operator +(RG_Vector A, RG_Vector B)
        {
            return Create(A.x + B.x, A.y + B.y);
        }
        public static RG_Vector operator -(RG_Vector A, RG_Vector B)
        {
            return Create(A.x - B.x, A.y - B.y);
        }

        public static RG_Vector operator *(RG_Vector A, RG_Vector B)
        {
            return Create(A.x * B.x, A.y * B.y);
        }
        public static RG_Vector operator /(RG_Vector A, RG_Vector B)
        {
            return Create(A.x / B.x, A.y / B.y);
        }

        public static RG_Vector operator +(RG_Vector A)
        {
            return A;
        }
        public static RG_Vector operator -(RG_Vector A)
        {
            return Create(A.x * -1, A.y * -1);
        }

        public double Magnitude()
        {
            return Math.Sqrt((x * x) + (y * y));
        }
        public static double Magnitude(RG_Point A)
        {
            return Math.Sqrt((A.x * A.x) + (A.y * A.y));
        }

        public RG_Vector Clone()
        {
            return Create(x, y);
        }
    }
}