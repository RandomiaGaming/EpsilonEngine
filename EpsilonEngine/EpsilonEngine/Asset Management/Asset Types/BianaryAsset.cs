using System.IO;
using System;
namespace EpsilonEngine
{
    public sealed class BianaryAsset : AssetBase
    {
        public readonly byte[] data = null;
        public BianaryAsset(Stream stream, string name, string extension, string resourceName, byte[] data) : base(stream, name, extension, resourceName)
        {
            if(data is null)
            {
                throw new NullReferenceException();
            }
            this.data = data;
        }
    }
}
