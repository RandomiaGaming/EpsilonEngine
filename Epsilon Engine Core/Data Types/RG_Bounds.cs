using System;

namespace RG_Engine
{
    public sealed class RG_Bounds
    {
        private RG_Point Min = RG_Point.Create(0, 0);
        private RG_Point Max = RG_Point.Create(1, 1);

        private RG_Bounds() { }
        public static RG_Bounds Create()
        {
            RG_Bounds Output = new RG_Bounds();
            Output.Min = RG_Point.Create(0, 0);
            Output.Max = RG_Point.Create(0, 0);
            return Output;
        }
        public static RG_Bounds Create(RG_Point Size)
        {
            RG_Bounds Output = new RG_Bounds();
            Output.Min = RG_Point.Create(0, 0);
            Output.Max = RG_Point.Create(Math.Abs(Size.x), Math.Abs(Size.y));
            return Output;
        }
        public static RG_Bounds Create(RG_Point Min, RG_Point Max)
        {
            RG_Bounds Output = new RG_Bounds();
            Output.Min = RG_Point.Create(Math.Min(Min.x, Max.x), Math.Min(Min.y, Max.y));
            Output.Max = RG_Point.Create(Math.Max(Min.x, Max.x), Math.Max(Min.y, Max.y));
            return Output;
        }
        public override string ToString()
        {
            return $"[{Min},{Max}]";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(RG_Bounds))
            {
                return this == (RG_Bounds)obj;
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
        public static bool operator ==(RG_Bounds A, RG_Bounds B)
        {
            return (A.Get_Min() == B.Get_Min() && A.Get_Max() == B.Get_Max());
        }
        public static bool operator !=(RG_Bounds A, RG_Bounds B)
        {
            return !(A == B);
        }

        public RG_Point Get_Min()
        {
            return Min.Clone();
        }
        public RG_Point Get_Max()
        {
            return Max.Clone();
        }
        public bool Incapsulates(RG_Point A)
        {
            if (A.x >= Min.x && A.x <= Max.x && A.y >= Min.y && A.y <= Max.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Incapsulate(RG_Point A)
        {
            if (A.x < Min.x)
            {
                Min.x = A.x;
            }
            else if (A.x > Max.x)
            {
                Max.x = A.x;
            }
            if (A.y < Min.y)
            {
                Min.y = A.y;
            }
            else if (A.y > Max.y)
            {
                Max.y = A.y;
            }
        }

        public RG_Bounds Clone()
        {
            return Create(Min.Clone(), Max.Clone());
        }
    }
}