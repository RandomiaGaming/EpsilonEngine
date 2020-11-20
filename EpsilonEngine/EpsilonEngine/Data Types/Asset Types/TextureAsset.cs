using System.IO;
namespace EpsilonEngine
{
    public sealed class TextureAsset : AssetBase
    {
        public readonly Texture data = null;

        public TextureAsset(Stream stream, string name, Texture data) : base(stream, name)
        {
            this.data = data;
        }
    }
}
