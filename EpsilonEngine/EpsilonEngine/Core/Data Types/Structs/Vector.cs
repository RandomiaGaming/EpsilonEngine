using System;

namespace EpsilonEngine
{
    public struct Vector
    {
        public double x;
        public double y;

        public static readonly Point Zero = new Point(0, 0);
        public static readonly Point One = new Point(1, 1);
        public static readonly Point NegativeOne = new Point(-1, -1);

        public static readonly Point Up = new Point(0, 1);
        public static readonly Point Down = new Point(0, -1);
        public static readonly Point Right = new Point(1, 0);
        public static readonly Point Left = new Point(-1, 0);
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"({x}, {y})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Vector))
            {
                return false;
            }
            else
            {
                return this == (Vector)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Vector a, Vector b)
        {
            return (a.x == b.x) && (a.y == b.y);
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }
        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.x * b.x, a.y * b.y);
        }
        public static Vector operator /(Vector a, Vector b)
        {
            return new Vector(a.x / b.x, a.y / b.y);
        }

        public static Vector operator +(Vector a, Point b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }
        public static Vector operator -(Vector a, Point b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }
        public static Vector operator *(Vector a, Point b)
        {
            return new Vector(a.x * b.x, a.y * b.y);
        }
        public static Vector operator /(Vector a, Point b)
        {
            return new Vector(a.x / b.x, a.y / b.y);
        }

        public static Vector operator +(Vector a, double b)
        {
            return new Vector(a.x + b, a.y + b);
        }
        public static Vector operator -(Vector a, double b)
        {
            return new Vector(a.x - b, a.y - b);
        }
        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.x * b, a.y * b);
        }
        public static Vector operator /(Vector a, double b)
        {
            return new Vector(a.x / b, a.y / b);
        }

        public static Vector operator +(Vector a, int b)
        {
            return new Vector(a.x + b, a.y + b);
        }
        public static Vector operator -(Vector a, int b)
        {
            return new Vector(a.x - b, a.y - b);
        }
        public static Vector operator *(Vector a, int b)
        {
            return new Vector(a.x * b, a.y * b);
        }
        public static Vector operator /(Vector a, int b)
        {
            return new Vector(a.x / b, a.y / b);
        }

        public static Vector operator +(Vector a)
        {
            return a;
        }
        public static Vector operator -(Vector a)
        {
            return new Vector(a.x * -1, a.y * -1);
        }

        public static implicit operator Vector(Point a)
        {
            return new Vector(a.x, a.y);
        }
    }
}