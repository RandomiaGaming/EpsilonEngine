namespace EpsilonEngine
{
    public class Vector3
    {
        public double x;
        public double y;
        public double z;
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);
        public static readonly Vector3 One = new Vector3(1, 1, 1);
        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Vector3))
            {
                return false;
            }
            else
            {
                return this == (Vector3)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return (a.x == b.x) && (a.y == b.y) && (a.z == b.z);
        }
        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !(a == b);
        }
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        }
        public static Vector3 operator +(Vector3 a, double b)
        {
            return new Vector3(a.x + b, a.y + b, a.z + b);
        }
        public static Vector3 operator -(Vector3 a, double b)
        {
            return new Vector3(a.x - b, a.y - b, a.z - b);
        }
        public static Vector3 operator *(Vector3 a, double b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }
        public static Vector3 operator /(Vector3 a, double b)
        {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }
        public static Vector3 operator +(Vector3 a)
        {
            return a;
        }
        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(a.x * -1, a.y * -1, a.z * -1);
        }
    }
}