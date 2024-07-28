// Approved 2.0
// Ignore warnings for not overriding GetHashCode.
#pragma warning disable CS0659
#pragma warning disable CS0661
namespace EpsilonEngine
{
    public struct Point
    {
        #region Public Constants
        public static readonly Point Zero = new Point(0, 0);
        public static readonly Point One = new Point(1, 1);
        public static readonly Point MaxValue = new Point(int.MaxValue, int.MaxValue);
        public static readonly Point MinValue = new Point(int.MinValue, int.MinValue);
        public static readonly Point PositiveOne = new Point(1, 1);
        public static readonly Point NegativeOne = new Point(-1, -1);

        public static readonly Point Up = new Point(0, 1);
        public static readonly Point Down = new Point(0, -1);
        public static readonly Point Right = new Point(1, 0);
        public static readonly Point Left = new Point(-1, 0);

        public static readonly Point UpRight = new Point(1, 1);
        public static readonly Point UpLeft = new Point(-1, 1);
        public static readonly Point DownRight = new Point(1, -1);
        public static readonly Point DownLeft = new Point(-1, -1);
        #endregion
        #region Public Varialbes
        public int X;
        public int Y;
        #endregion
        #region Public Constructors
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point(Vector source)
        {
            X = (int)source.X;
            Y = (int)source.Y;
        }
        #endregion
        #region Public Overrides
        public override string ToString()
        {
            return $"EpsilonEngine.Point({X}, {Y})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Point))
            {
                return false;
            }
            else
            {
                Point a = (Point)obj;
                return X == a.X && Y == a.Y;
            }
        }
        #endregion
        #region Public Operators
        public static Point operator +(Point a)
        {
            return a;
        }
        public static Point operator -(Point a)
        {
            a.X = -a.X;
            a.Y = -a.Y;
            return a;
        }
        public static Point operator ++(Point a)
        {
            a.X++;
            a.Y++;
            return a;
        }
        public static Point operator --(Point a)
        {
            a.X--;
            a.Y--;
            return a;
        }

        public static Point operator +(Point a, Point b)
        {
            a.X += b.X;
            a.Y += b.Y;
            return a;
        }
        public static Point operator -(Point a, Point b)
        {
            a.X -= b.X;
            a.Y -= b.Y;
            return a;
        }
        public static Point operator *(Point a, Point b)
        {
            a.X *= b.X;
            a.Y *= b.Y;
            return a;
        }
        public static Point operator /(Point a, Point b)
        {
            a.X /= b.X;
            a.Y /= b.Y;
            return a;
        }
        public static Point operator %(Point a, Point b)
        {
            a.X %= b.X;
            a.Y %= b.Y;
            return a;
        }

        public static Point operator +(Point a, int b)
        {
            a.X += b;
            a.Y += b;
            return a;
        }
        public static Point operator -(Point a, int b)
        {
            a.X -= b;
            a.Y -= b;
            return a;
        }
        public static Point operator *(Point a, int b)
        {
            a.X *= b;
            a.Y *= b;
            return a;
        }
        public static Point operator /(Point a, int b)
        {
            a.X /= b;
            a.Y /= b;
            return a;
        }
        public static Point operator %(Point a, int b)
        {
            a.X %= b;
            a.Y %= b;
            return a;
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(Point a, Point b)
        {
            return a.X != b.X || a.Y != b.Y;
        }
        public static bool operator <(Point a, Point b)
        {
            return a.X < b.X && a.Y < b.Y;
        }
        public static bool operator >(Point a, Point b)
        {
            return a.X > b.X || a.Y > b.Y;
        }
        public static bool operator <=(Point a, Point b)
        {
            return a.X <= b.X && a.Y <= b.Y;
        }
        public static bool operator >=(Point a, Point b)
        {
            return a.X >= b.X || a.Y >= b.Y;
        }

        public static explicit operator Point(Vector source)
        {
            Point output;
            output.X = (int)source.X;
            output.Y = (int)source.Y;
            return output;
        }
        #endregion
    }
}