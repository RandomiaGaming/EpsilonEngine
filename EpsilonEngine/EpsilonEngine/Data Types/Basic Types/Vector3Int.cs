namespace EpsilonEngine
{
    public struct Vector3Int
    {
        public int x;
        public int y;
        public int z;
        public static readonly Vector3Int Zero = new Vector3Int(0, 0, 0);
        public static readonly Vector3Int One = new Vector3Int(1, 1, 1);
        public Vector3Int(int x, int y, int z)
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
            if (obj is null || obj.GetType() != typeof(Vector3Int))
            {
                return false;
            }
            else
            {
                return this == (Vector3Int)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Vector3Int a, Vector3Int b)
        {
            return (a.x == b.x) && (a.y == b.y) && (a.z == b.z);
        }
        public static bool operator !=(Vector3Int a, Vector3Int b)
        {
            return !(a == b);
        }
        public static Vector3Int operator +(Vector3Int a, Vector3Int b)
        {
            return new Vector3Int(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector3Int operator -(Vector3Int a, Vector3Int b)
        {
            return new Vector3Int(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector3Int operator *(Vector3Int a, Vector3Int b)
        {
            return new Vector3Int(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        public static Vector3Int operator /(Vector3Int a, Vector3Int b)
        {
            return new Vector3Int(a.x / b.x, a.y / b.y, a.z / b.z);
        }
        public static Vector3Int operator +(Vector3Int a, int b)
        {
            return new Vector3Int(a.x + b, a.y + b, a.z + b);
        }
        public static Vector3Int operator -(Vector3Int a, int b)
        {
            return new Vector3Int(a.x - b, a.y - b, a.z - b);
        }
        public static Vector3Int operator *(Vector3Int a, int b)
        {
            return new Vector3Int(a.x * b, a.y * b, a.z * b);
        }
        public static Vector3Int operator /(Vector3Int a, int b)
        {
            return new Vector3Int(a.x / b, a.y / b, a.z / b);
        }
        public static Vector3Int operator +(Vector3Int a)
        {
            return a;
        }
        public static Vector3Int operator -(Vector3Int a)
        {
            return new Vector3Int(a.x * -1, a.y * -1, a.z * -1);
        }
    }
}