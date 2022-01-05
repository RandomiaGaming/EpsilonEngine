using System;
namespace EpsilonEngine
{
    public struct Rect
    {
        public readonly Vector min;
        public readonly Vector max;
        public Rect(Vector min, Vector max)
        {
            if (min.x > max.x || min.y > max.y)
            {
                throw new ArgumentException();
            }
            this.min = min;
            this.max = max;
        }
        public Rect(double minX, double minY, double maxX, double maxY)
        {
            if (maxX < minX || maxY < minY)
            {
                throw new ArgumentException();
            }
            min = new Vector(minX, minY);
            max = new Vector(maxX, maxY);
        }
        public override string ToString()
        {
            return $"EpsilonEngine.Rect({min}, {max})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Rect))
            {
                return false;
            }
            else
            {
                return this == (Rect)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Rect a, Rect b)
        {
            return (a.min == b.min && a.max == b.max);
        }
        public static bool operator !=(Rect a, Rect b)
        {
            return !(a == b);
        }
        public bool Incapsulates(Vector a)
        {
            if (a.x >= min.x && a.x <= max.x && a.y >= min.y && a.y <= max.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Incapsulates(Rect a)
        {
            if (a.max.y <= max.y && a.min.y >= min.y && a.max.x <= max.x && a.min.x >= min.x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Overlaps(Rect a)
        {
            if (max.x < a.min.x || min.x > a.max.x || max.y < a.min.y || min.y > a.max.y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}