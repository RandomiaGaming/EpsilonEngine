namespace EpsilonEngine
{
    public struct Point
    {
        public int x;
        public int y;

        public static readonly Point Zero = new Point(0, 0);
        public static readonly Point One = new Point(1, 1);
        public static readonly Point NegativeOne = new Point(-1, -1);

        public static readonly Point Up = new Point(0, 1);
        public static readonly Point Down = new Point(0, -1);
        public static readonly Point Right = new Point(1, 0);
        public static readonly Point Left = new Point(-1, 0);
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"EpsilonEngine.Point({x}, {y})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Point))
            {
                return false;
            }
            else
            {
                return this == (Point)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Point a, Point b)
        {
            return (a.x == b.x) && (a.y == b.y);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }
        public static Point operator *(Point a, Point b)
        {
            return new Point(a.x * b.x, a.y * b.y);
        }
        public static Point operator /(Point a, Point b)
        {
            return new Point(a.x / b.x, a.y / b.y);
        }

        public static Vector operator +(Point a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }
        public static Vector operator -(Point a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }
        public static Vector operator *(Point a, Vector b)
        {
            return new Vector(a.x * b.x, a.y * b.y);
        }
        public static Vector operator /(Point a, Vector b)
        {
            return new Vector(a.x / b.x, a.y / b.y);
        }

        public static Vector operator +(Point a, double b)
        {
            return new Vector(a.x + b, a.y + b);
        }
        public static Vector operator -(Point a, double b)
        {
            return new Vector(a.x - b, a.y - b);
        }
        public static Vector operator *(Point a, double b)
        {
            return new Vector(a.x * b, a.y * b);
        }
        public static Vector operator /(Point a, double b)
        {
            return new Vector(a.x / b, a.y / b);
        }

        public static Point operator +(Point a, int b)
        {
            return new Point(a.x + b, a.y + b);
        }
        public static Point operator -(Point a, int b)
        {
            return new Point(a.x - b, a.y - b);
        }
        public static Point operator *(Point a, int b)
        {
            return new Point(a.x * b, a.y * b);
        }
        public static Point operator /(Point a, int b)
        {
            return new Point(a.x / b, a.y / b);
        }

        public static Point operator +(Point a)
        {
            return a;
        }
        public static Point operator -(Point a)
        {
            return new Point(a.x * -1, a.y * -1);
        }

        public static implicit operator Point(Vector a)
        {
            return new Point((int)a.x, (int)a.y);
        }
    }
}