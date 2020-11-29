using System.IO;
namespace EpsilonEngine.Modules.PNGCodec
{
    public sealed class PNGAsset : AssetBase
    {
        public readonly Texture data = null;
        public PNGAsset(Stream stream, string name, Texture data) : base(stream, name)
        {
            this.data = data;
        }
    }
}
