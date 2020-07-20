using System;
using System.Collections.Generic;

namespace Epsilon_Engine
{
    public sealed class RG_Texture
    {
        private int Width = 1;
        private int Height = 1;
        private List<RG_Pixel_Data> Current_Pixel_Data = new List<RG_Pixel_Data>();

        private RG_Texture() { }
        public static RG_Texture Create()
        {
            RG_Texture Output = new RG_Texture();
            Output.Width = 1;
            Output.Height = 1;
            Output.Current_Pixel_Data = new List<RG_Pixel_Data>();
            Output.Current_Pixel_Data.Add(RG_Pixel_Data.Create(RG_Point.Create(0, 0), RG_Color.Create(255, 255, 255)));
            return Output;
        }
        public static RG_Texture Create(int Width, int Height)
        {
            RG_Texture Output = new RG_Texture();
            Output.Width = Width;
            Output.Height = Height;
            Output.Current_Pixel_Data = new List<RG_Pixel_Data>();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Output.Current_Pixel_Data.Add(RG_Pixel_Data.Create(RG_Point.Create(x, y), RG_Color.Create(255, 255, 255)));
                }
            }
            return Output;
        }
        public static RG_Texture Create(int Width, int Height, RG_Color Fill_Color)
        {
            RG_Texture Output = new RG_Texture();
            Output.Width = Width;
            Output.Height = Height;
            Output.Current_Pixel_Data = new List<RG_Pixel_Data>();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Output.Current_Pixel_Data.Add(RG_Pixel_Data.Create(RG_Point.Create(x, y), Fill_Color.Clone()));
                }
            }
            return Output;
        }
        public RG_Color Get_Pixel(RG_Point Position)
        {
            if (Position.x < 0 || Position.y < 0 || Position.x >= Width || Position.y >= Height)
            {
                return null;
            }
            for (int i = 0; i < Current_Pixel_Data.Count; i++)
            {
                if (Position == Current_Pixel_Data[i].Position)
                {
                    return Current_Pixel_Data[i].Color.Clone();
                }
            }
            return null;
        }
        public void Set_Pixel(RG_Point Position, RG_Color New_Color)
        {
            if (Position.x >= 0 && Position.y < 0 || Position.x >= Width || Position.y >= Height)
            {
                return;
            }
            for (int i = 0; i < Current_Pixel_Data.Count; i++)
            {
                if (Position == Current_Pixel_Data[i].Position)
                {
                    Current_Pixel_Data.RemoveAt(i);
                    i--;
                }
            }
            if (New_Color != null)
            {
                Current_Pixel_Data.Add(RG_Pixel_Data.Create(Position, New_Color));
            }
        }
        public void Resize(int New_Width, int New_Height)
        {
            Width = Math_Helper.Clamp(New_Width, 0, 1024);
            Height = Math_Helper.Clamp(New_Height, 0, 1024);
            for (int i = 0; i < Current_Pixel_Data.Count; i++)
            {
                if (Current_Pixel_Data[i].Position.x >= Width || Current_Pixel_Data[i].Position.y >= Height)
                {
                    Current_Pixel_Data.RemoveAt(i);
                    i--;
                }
            }
        }
        public int Get_Width()
        {
            return Width;
        }
        public int Get_Height()
        {
            return Height;
        }
        public RG_Point Get_Dementions()
        {
            return RG_Point.Create(Width, Height);
        }

        public RG_Texture Clone()
        {
            RG_Texture Output = new RG_Texture();
            Output.Width = Width;
            Output.Height = Height;
            Output.Current_Pixel_Data = new List<RG_Pixel_Data>(Current_Pixel_Data);
            return Output;
        }
    }
}