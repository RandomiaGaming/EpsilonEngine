using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public sealed class Texture
    {
        public int width { get; private set; } = 0;
        public int height { get; private set; } = 0;
        private Color[] data = new Color[0];

        private Texture() { }
        public static Texture Create()
        {
            Texture Output = new Texture();
            Output.width = 0;
            Output.height = 0;
            Output.data = new Color[0];
            return Output;
        }
        public static Texture Create(int width, int height)
        {
            Texture Output = new Texture();
            Output.width = width;
            Output.height = height;
            Output.data = new Color[width * height];
            return Output;
        }
        public static Texture Create(Color fillColor, int width, int height)
        {
            Texture Output = new Texture();
            Output.width = width;
            Output.height = height;
            Output.data = new Color[width * height];
            for (int i = 0; i < width * height; i++)
            {
                Output.data[i] = fillColor;
            }
            return Output;
        }
        public static Texture Create(Color[] data, int width, int height)
        {
            Texture Output = new Texture();
            Output.width = width;
            Output.height = height;
            Output.data = new List<Color>(data).ToArray();
            return Output;
        }
        public Color GetPixel(int x, int y)
        {
            return data[(y * width) + x];
        }
        public void SetPixel(Color newColor, int x, int y)
        {
            data[(y * width) + x] = newColor;
        }
        public void Blitz(Texture data, int targetX, int targetY)
        {
            for (int x = 0; x < data.width; x++)
            {
                for (int y = 0; y < data.height; y++)
                {
                    if (x + targetX >= 0 && x + targetX < width && y + targetY >= 0 && y + targetY < height)
                    {
                        Color newColor = data.GetPixel(x, y);
                        if (newColor != null)
                        {
                            SetPixel(newColor, x + targetX, y + targetY);
                        }
                    }
                }
            }
        }
        public Color[] GetData()
        {
            return new List<Color>(data).ToArray();
        }
        public Texture Clone()
        {
            Texture Output = new Texture();
            Output.width = width;
            Output.height = height;
            Output.data = new List<Color>(data).ToArray();
            return Output;
        }
    }
}