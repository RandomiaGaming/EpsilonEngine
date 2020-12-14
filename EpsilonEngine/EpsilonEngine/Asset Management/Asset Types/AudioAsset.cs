using System.IO;
using System;
namespace EpsilonEngine
{
    public sealed class AudioAsset : AssetBase
    {
        public readonly AudioClip data;
        public AudioAsset(Stream stream, string name, string extension, string resourceName, AudioClip data) : base(stream, name, extension, resourceName)
        {
            if(data.sampleRate <= 0)
            {
                throw new ArgumentException();
            }
            this.data = data;
        }
    }
}
