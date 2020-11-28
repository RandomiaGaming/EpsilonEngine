using System.IO;
namespace EpsilonEngine.Modules.AssetCodecs.PNG
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
