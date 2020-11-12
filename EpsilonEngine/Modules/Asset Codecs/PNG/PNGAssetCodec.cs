using System.IO;

namespace EpsilonEngine.Modules.AssetCodecs.PNG
{
    public class PNGAssetCodec : AssetCodec
    {
        public PNGAssetCodec() : base(new string[] { "png" })
        {

        }

        public override AssetBase[] DecodeStream(Stream stream, string name)
        {
            System.Drawing.Image loadedImage = System.Drawing.Image.FromStream(stream);
            System.Drawing.Bitmap loadedBitMap = new System.Drawing.Bitmap(loadedImage);
            Texture output = new Texture((ushort)loadedBitMap.Width, (ushort)loadedBitMap.Height);
            for (int x = 0; x < loadedBitMap.Width; x++)
            {
                for (int y = 0; y < loadedBitMap.Height; y++)
                {
                    System.Drawing.Color systemColor = loadedBitMap.GetPixel(x, loadedBitMap.Height - y - 1);
                    output.SetPixel((ushort)x, (ushort)y, new Color(systemColor.R, systemColor.G, systemColor.B, systemColor.A));
                }
            }
            return new AssetBase[] { new TextureAsset(stream, name, output) };
        }
    }
}
