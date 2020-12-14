using System.IO;
namespace EpsilonEngine
{
    public sealed class TextAsset : AssetBase
    {
        public readonly string data = null;
        public TextAsset(Stream stream, string name, string extension, string resourceName, string data) : base(stream, name, extension, resourceName)
        {
            this.data = data;
        }
    }
}
