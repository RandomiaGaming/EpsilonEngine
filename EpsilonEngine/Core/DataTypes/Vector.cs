// Approved 2.0
// Note: Vectors can contain values such as NaN and PositiveInfinity so make sure to account for extrenuous cases in your code.
// Ignore warnings for not overriding GetHashCode.
#pragma warning disable CS0659
#pragma warning disable CS0661
namespace EpsilonEngine
{
    public struct Vector
    {
        #region Public Constants
        public static readonly Vector Zero;
        public static readonly Vector Infinity = PositiveInfinity;
        public static readonly Vector PositiveInfinity = new Vector(double.PositiveInfinity, double.PositiveInfinity);
        public static readonly Vector NegativeInfinity = new Vector(double.NegativeInfinity, double.NegativeInfinity);
        public static readonly Vector NaN = new Vector(double.NaN, double.NaN);
        public static readonly Vector MaxValue = new Vector(double.MaxValue, double.MaxValue);
        public static readonly Vector MinValue = new Vector(double.MinValue, double.MinValue);
        public static readonly Vector Epsilon = new Vector(double.Epsilon, double.Epsilon);
        public static readonly Vector One = PositiveOne;
        public static readonly Vector PositiveOne = new Vector(1.0, 1.0);
        public static readonly Vector NegativeOne = new Vector(-1.0, -1.0);

        public static readonly Vector Up = new Vector(0.0, 1.0);
        public static readonly Vector Down = new Vector(0.0, -1.0);
        public static readonly Vector Right = new Vector(1.0, 0.0);
        public static readonly Vector Left = new Vector(-1.0, 0.0);

        public static readonly Vector UpRight = PositiveOne;
        public static readonly Vector UpLeft = new Vector(-1.0, 1.0);
        public static readonly Vector DownRight = new Vector(1.0, -1.0);
        public static readonly Vector DownLeft = NegativeOne;
        #endregion
        #region Public Varialbes
        public double X;
        public double Y;
        #endregion
        #region Public Constructors
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Vector(Point source)
        {
            X = source.X;
            Y = source.Y;
        }
        #endregion
        #region Public Overrides
        public override string ToString()
        {
            return $"EpsilonEngine.Vector({X}, {Y})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Vector))
            {
                return false;
            }
            Vector a = (Vector)obj;
            return X == a.X && Y == a.Y;
        }
        #endregion
        #region Public Operators
        public static Vector operator +(Vector a)
        {
            return a;
        }
        public static Vector operator -(Vector a)
        {
            a.X = -a.X;
            a.Y = -a.Y;
            return a;
        }
        public static Vector operator ++(Vector a)
        {
            a.X++;
            a.Y++;
            return a;
        }
        public static Vector operator --(Vector a)
        {
            a.X--;
            a.Y--;
            return a;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            a.X += b.X;
            a.Y += b.Y;
            return a;
        }
        public static Vector operator -(Vector a, Vector b)
        {
            a.X -= b.X;
            a.Y -= b.Y;
            return a;
        }
        public static Vector operator *(Vector a, Vector b)
        {
            a.X *= b.X;
            a.Y *= b.Y;
            return a;
        }
        public static Vector operator /(Vector a, Vector b)
        {
            a.X /= b.X;
            a.Y /= b.Y;
            return a;
        }
        public static Vector operator %(Vector a, Vector b)
        {
            a.X %= b.X;
            a.Y %= b.Y;
            return a;
        }

        public static Vector operator +(Vector a, double b)
        {
            a.X += b;
            a.Y += b;
            return a;
        }
        public static Vector operator -(Vector a, double b)
        {
            a.X -= b;
            a.Y -= b;
            return a;
        }
        public static Vector operator *(Vector a, double b)
        {
            a.X *= b;
            a.Y *= b;
            return a;
        }
        public static Vector operator /(Vector a, double b)
        {
            a.X /= b;
            a.Y /= b;
            return a;
        }
        public static Vector operator %(Vector a, double b)
        {
            a.X %= b;
            a.Y %= b;
            return a;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return a.X != b.X || a.Y != b.Y;
        }
        public static bool operator <(Vector a, Vector b)
        {
            return a.X < b.X && a.Y < b.Y;
        }
        public static bool operator >(Vector a, Vector b)
        {
            return a.X > b.X || a.Y > b.Y;
        }
        public static bool operator <=(Vector a, Vector b)
        {
            return a.X <= b.X && a.Y <= b.Y;
        }
        public static bool operator >=(Vector a, Vector b)
        {
            return a.X >= b.X || a.Y >= b.Y;
        }

        public static explicit operator Vector(Point source)
        {
            Vector output;
            output.X = source.X;
            output.Y = source.Y;
            return output;
        }
        #endregion
        #region Public Methods
        public bool IsReal()
        {
            return !(X is double.NaN || Y is double.NaN || X is double.PositiveInfinity || Y is double.PositiveInfinity || X is double.NegativeInfinity || Y is double.NegativeInfinity);
        }
        public bool IsNaN()
        {
            return X is double.NaN || Y is double.NaN;
        }
        #endregion
    }
}