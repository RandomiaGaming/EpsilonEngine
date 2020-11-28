using System;
namespace EpsilonEngine
{
    public class RectangleInt
    {
        public readonly Vector2Int min = Vector2Int.Zero;
        public readonly Vector2Int max = Vector2Int.One;
        public RectangleInt(Vector2Int min, Vector2Int max)
        {
            if (min.x > max.x || min.y > max.y)
            {
                throw new ArgumentException();
            }
            this.min = min;
            this.max = max;
        }
        public RectangleInt(int minX, int minY, int maxX, int maxY)
        {
            if (maxX < minX || maxY < minY)
            {
                throw new ArgumentException();
            }
            min = new Vector2Int(minX, minY);
            max = new Vector2Int(maxX, maxY);
        }
        public override string ToString()
        {
            return $"[{min}, {max}]";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(RectangleInt))
            {
                return false;
            }
            else
            {
                return this == (RectangleInt)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(RectangleInt a, RectangleInt b)
        {
            return (a.min == b.min && a.max == b.max);
        }
        public static bool operator !=(RectangleInt a, RectangleInt b)
        {
            return !(a == b);
        }
        public bool Incapsulates(Vector2Int a)
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
        public bool Incapsulates(RectangleInt a)
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
        public bool Overlaps(RectangleInt a)
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