using System.IO;
using System;
namespace EpsilonEngine
{
    public sealed class TextureAsset : AssetBase
    {
        public readonly Texture data = null;
        public TextureAsset(Stream stream, string name, string extension, string resourceName, Texture data) : base(stream, name, extension, resourceName)
        {
            if(data is null)
            {
                throw new NullReferenceException();
            }
            if(data.width <= 0 || data.height <= 0)
            {
                throw new ArgumentException();
            }
            this.data = data;
        }
    }
}
