using System;
namespace EpsilonEngine
{
    public class Texture
    {
        public readonly int width = 0;
        public readonly int height = 0;
        private Color[] data = new Color[0];
        public Texture(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.width = width;
            this.height = height;
            data = new Color[width * height];
        }
        public Texture(int width, int height, Color fillColor)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.width = width;
            this.height = height;
            data = new Color[width * height];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = fillColor;
            }
        }
        public Texture(int width, int height, Color[] data)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.width = width;
            this.height = height;
            if (data is null)
            {
                throw new NullReferenceException();
            }
            if (data.Length != width * height)
            {
                throw new ArgumentException();
            }
            this.data = (Color[])data.Clone();
        }

        public static void Blitz(Texture source, Texture destination, Vector2Int position)
        {
            for (int x = 0; x < source.width; x++)
            {
                for (int y = 0; y < source.height; y++)
                {
                    if (x + position.x >= 0 && x + position.x < destination.width && y + position.y >= 0 && y + position.y < destination.height)
                    {
                        Color otherColor = source.GetPixelUnsafe(x, y);
                        Color thisColor = destination.GetPixelUnsafe(x + position.x, y + position.y);
                        destination.SetPixelUnsafe(x + position.x, y + position.y, ColorHelper.Mix(thisColor, otherColor));
                    }
                }
            }
        }
        public Texture SubTexture(RectangleInt sourceRectangle)
        {
            if (sourceRectangle.min.x < 0 || sourceRectangle.min.y < 0 || sourceRectangle.max.x >= width || sourceRectangle.max.y >= height)
            {
                throw new ArgumentException();
            }

            Texture output = new Texture(sourceRectangle.max.x - sourceRectangle.min.x, sourceRectangle.max.y - sourceRectangle.min.y);

            for (int x = 0; x < output.width; x++)
            {
                for (int y = 0; y < output.height; y++)
                {
                    output.SetPixelUnsafe(x, y, GetPixelUnsafe(sourceRectangle.min.x + x, sourceRectangle.min.y + y));
                }
            }

            return output;
        }

        public void SetPixelUnsafe(int x, int y, Color newColor)
        {
            data[(y * width) + x] = newColor;
        }
        public Color GetPixelUnsafe(int x, int y)
        {
            return data[(y * width) + x];
        }

        public void SetPixel(int x, int y, Color newColor)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                throw new ArgumentOutOfRangeException();
            }
            data[(y * width) + x] = newColor;
        }
        public Color GetPixel(int x, int y)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                throw new ArgumentOutOfRangeException();
            }
            return data[(y * width) + x];
        }

        public void SetData(Color[] newData)
        {
            if (newData.Length != width * height)
            {
                throw new ArgumentException();
            }
            data = (Color[])newData.Clone();
        }
        public Color[] GetData()
        {
            return (Color[])data.Clone();
        }
    }
}