using System.IO;
namespace EpsilonEngine
{
    public sealed class AudioAsset : AssetBase
    {
        public readonly AudioClip data = null;

        public AudioAsset(Stream stream, string name, AudioClip data) : base(stream, name)
        {
            this.data = data;
        }
    }
}
