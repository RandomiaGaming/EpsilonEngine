using System.IO;

namespace EpsilonEngine
{
    public abstract class AssetCodec
    {
        public readonly string[] managedExtensions = new string[0];
        public AssetCodec(string[] managedExtensions)
        {
            this.managedExtensions = managedExtensions;
        }
        public abstract AssetBase[] DecodeStream(Stream stream, string name);
    }
}