using System.IO;
namespace EpsilonEngine.Modules.AssetCodecs.Unsafe
{
    public sealed class BianaryAsset : AssetBase
    {
        public readonly byte[] data = null;

        public BianaryAsset(Stream stream, string name, byte[] data) : base(stream, name)
        {
            this.data = data;
        }
    }
}
