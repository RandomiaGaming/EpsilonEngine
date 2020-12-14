using System.IO;
namespace EpsilonEngine
{
    public sealed class ImageAssetDecoder : AssetDecoder
    {
        public ImageAssetDecoder() : base(new string[] { "PNG", "JPG", "JPGE" })
        {

        }
        public override AssetBase DecodeAsset(Stream stream, string name, string extension, string resourceName)
        {
            System.Drawing.Image loadedImage = System.Drawing.Image.FromStream(stream);
            System.Drawing.Bitmap loadedBitMap = new System.Drawing.Bitmap(loadedImage);
            Texture output = new Texture(loadedBitMap.Width, loadedBitMap.Height);
            for (int x = 0; x < loadedBitMap.Width; x++)
            {
                for (int y = 0; y < loadedBitMap.Height; y++)
                {
                    System.Drawing.Color systemColor = loadedBitMap.GetPixel(x, loadedBitMap.Height - y - 1);
                    output.SetPixel(x, y, new Color(systemColor.R, systemColor.G, systemColor.B, systemColor.A));
                }
            }
            return new TextureAsset(stream, name, extension, resourceName, output);
        }
    }
}