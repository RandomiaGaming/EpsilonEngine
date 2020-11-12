using System;
namespace EpsilonEngine
{
    public class Rectangle
    {
        private Vector2Int _min;
        private Vector2Int _max;
        public Vector2Int min
        {
            get
            {
                return _min;
            }
            set
            {
                if (value.x > _max.x || value.y > _max.y)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _min = value;
                }
            }
        }
        public Vector2Int max
        {
            get
            {
                return _max;
            }
            set
            {
                if (value.x < _min.x || value.y < _min.y)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _max = value;
                }
            }
        }
        public Rectangle(Vector2Int size)
        {
            if (size.x < 0 || size.y < 0)
            {
                throw new ArgumentException();
            }
            _min = Vector2Int.Zero;
            _max = size;
        }
        public Rectangle(int width, int height)
        {
            if (width < 0 || height < 0)
            {
                throw new ArgumentException();
            }
            _min = Vector2Int.Zero;
            _max = new Vector2Int(width, height);
        }
        public Rectangle(Vector2Int min, Vector2Int max)
        {
            if (min.x > max.x || min.y > max.y)
            {
                throw new ArgumentException();
            }
            _min = min;
            _max = max;
        }
        public Rectangle(int xPosition, int yPosition, int width, int height)
        {
            if (width < 0 || height < 0)
            {
                throw new ArgumentException();
            }
            _min = new Vector2Int(xPosition, yPosition);
            _max = new Vector2Int(xPosition + width, yPosition + height);
        }
        public override string ToString()
        {
            return $"[{_min}, {_max}]";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Rectangle))
            {
                return false;
            }
            else
            {
                return this == (Rectangle)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Rectangle a, Rectangle b)
        {
            return (a._min == b._min && a._max == b._max);
        }
        public static bool operator !=(Rectangle a, Rectangle b)
        {
            return !(a == b);
        }
        public void Incapsulate(Vector2Int a)
        {
            if (a.x < _min.x)
            {
                _min.x = a.x;
            }
            else if (a.x > _max.x)
            {
                _max.x = a.x;
            }
            if (a.y < _min.y)
            {
                _min.y = a.y;
            }
            else if (a.y > _max.y)
            {
                _max.y = a.y;
            }
        }
        public bool Incapsulates(Vector2Int a)
        {
            if (a.x >= _min.x && a.x <= _max.x && a.y >= _min.y && a.y <= _max.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Overlaps(Rectangle a)
        {
            if (_max.x < a._min.x || _min.x > a._max.x || _max.y < a._min.y || _min.y > a._max.y)
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