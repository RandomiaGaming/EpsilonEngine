using System;
using System.IO;
namespace EpsilonEngine
{
    public abstract class AssetDecoder
    {
        public readonly string[] managedExtensions = new string[0];
        public AssetDecoder(string managedExtension)
        {
            if (managedExtension is null)
            {
                throw new NullReferenceException();
            }
            if (managedExtension == "")
            {
                throw new ArgumentException();
            }
            managedExtensions = new string[] { managedExtension };
        }
        public AssetDecoder(string[] managedExtensions)
        {
            if (managedExtensions is null)
            {
                throw new NullReferenceException();
            }
            if (managedExtensions.Length <= 0)
            {
                throw new ArgumentException();
            }
            this.managedExtensions = managedExtensions;
        }
        public abstract AssetBase DecodeAsset(Stream stream, string name, string extension, string resourceName);
    }
}
