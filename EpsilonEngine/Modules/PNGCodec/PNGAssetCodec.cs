using System.IO;

namespace EpsilonEngine.Modules.PNGCodec
{
    public static class PNGAssetCodec
    {
        [RegisterCodec("PNG")]
        public static AssetBase DecodePNG(Stream stream, string name)
        {
            System.Drawing.Image loadedImage = System.Drawing.Image.FromStream(stream);
            System.Drawing.Bitmap loadedBitMap = new System.Drawing.Bitmap(loadedImage);
            Texture output = new Texture((ushort)loadedBitMap.Width, (ushort)loadedBitMap.Height);
            for (int x = 0; x < loadedBitMap.Width; x++)
            {
                for (int y = 0; y < loadedBitMap.Height; y++)
                {
                    System.Drawing.Color systemColor = loadedBitMap.GetPixel(x, loadedBitMap.Height - y - 1);
                    output.SetPixel(x, y, new Color(systemColor.R, systemColor.G, systemColor.B, systemColor.A));
                }
            }
            return new PNGAsset(stream, name, output);
        }
    }
}