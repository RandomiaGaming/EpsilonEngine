using System;
namespace EpsilonEngine
{
    public class Texture
    {
        public int width { get; private set; }
        public int height { get; private set; }
        private Color[] data;
        public Texture(int width, int height)
        {
            this.width = width;
            this.height = height;
            data = new Color[width * height];
        }
        public Texture(int width, int height, Color fillColor)
        {
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
            if (data == null || data.Length != width * height)
            {
                throw new ArgumentException();
            }
            this.width = width;
            this.height = height;
            this.data = (Color[])data.Clone();
        }

        public void Blitz(Texture data, int targetX, int targetY)
        {
            for (int x = 0; x < data.width; x++)
            {
                for (int y = 0; y < data.height; y++)
                {
                    if (x + targetX >= 0 && x + targetX < width && y + targetY >= 0 && y + targetY < height)
                    {
                        Color otherColor = data.GetPixelUnsafe(x, y);
                        Color thisColor = GetPixelUnsafe(x + targetX, y + targetY);
                        SetPixelUnsafe(x + targetX, y + targetY, Color.Mix(thisColor, otherColor));
                    }
                }
            }
        }
        public void FillBlitz(Color fillColor, int targetX, int targetY, int sizeX, int sizeY)
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (x + targetX >= 0 && x + targetX < width && y + targetY >= 0 && y + targetY < height)
                    {
                        Color thisColor = GetPixelUnsafe(x + targetX, y + targetY);
                        SetPixelUnsafe(x + targetX, y + targetY, Color.Mix(thisColor, fillColor));
                    }
                }
            }
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