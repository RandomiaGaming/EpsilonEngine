namespace Epsilon_Engine
{
    public sealed class RG_Point
    {
        public int x = 0;
        public int y = 0;

        private RG_Point() { }
        public static RG_Point Create()
        {
            RG_Point Output = new RG_Point();
            Output.x = 0;
            Output.y = 0;
            return Output;
        }
        public static RG_Point Create(int x, int y)
        {
            RG_Point Output = new RG_Point();
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
            if (obj.GetType() == typeof(RG_Point))
            {
                return this == (RG_Point)obj;
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

        public static bool operator ==(RG_Point A, RG_Point B)
        {
            return (A.x == B.x) && (A.y == B.y);
        }
        public static bool operator !=(RG_Point A, RG_Point B)
        {
            return !(A == B);
        }

        public static RG_Point operator +(RG_Point A, RG_Point B)
        {
            return Create(A.x + B.x, A.y + B.y);
        }
        public static RG_Point operator -(RG_Point A, RG_Point B)
        {
            return Create(A.x - B.x, A.y - B.y);
        }

        public static RG_Point operator *(RG_Point A, RG_Point B)
        {
            return Create(A.x * B.x, A.y * B.y);
        }
        public static RG_Point operator /(RG_Point A, RG_Point B)
        {
            return Create(A.x / B.x, A.y / B.y);
        }

        public static RG_Point operator +(RG_Point A)
        {
            return A.Clone();
        }
        public static RG_Point operator -(RG_Point A)
        {
            return Create(A.x * -1, A.y * -1);
        }

        public RG_Point Clone()
        {
            return Create(x, y);
        }
    }
}