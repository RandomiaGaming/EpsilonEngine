using System;
namespace EpsilonEngine
{
    public struct PointRect
    {
        public readonly Point min;
        public readonly Point max;
        public PointRect(Point min, Point max)
        {
            if (min.x > max.x || min.y > max.y)
            {
                throw new ArgumentException();
            }
            this.min = min;
            this.max = max;
        }
        public PointRect(int minX, int minY, int maxX, int maxY)
        {
            if (maxX < minX || maxY < minY)
            {
                throw new ArgumentException();
            }
            min = new Point(minX, minY);
            max = new Point(maxX, maxY);
        }
        public override string ToString()
        {
            return $"EpsilonEngine.PointRect({min}, {max})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(PointRect))
            {
                return false;
            }
            else
            {
                return this == (PointRect)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(PointRect a, PointRect b)
        {
            return (a.min == b.min && a.max == b.max);
        }
        public static bool operator !=(PointRect a, PointRect b)
        {
            return !(a == b);
        }
        public bool Incapsulates(Point a)
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
        public bool Incapsulates(PointRect a)
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
        public bool Overlaps(PointRect a)
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