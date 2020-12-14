using System.IO;
using System;
namespace EpsilonEngine
{
    public abstract class AssetBase
    {
        public readonly Stream stream = null;
        public readonly string name = "";
        public readonly string extension = "";
        public readonly string resourceName = "";
        public AssetBase(Stream stream, string name, string extension, string resourceName)
        {
            if(stream is null)
            {
                throw new NullReferenceException();
            }
            if(stream.Length == 0)
            {
                throw new ArgumentException();
            }
            this.stream = stream;
            if(name is null)
            {
                throw new NullReferenceException();
            }
            if(name == "" || name.Contains("."))
            {
                throw new ArgumentException();
            }
            this.name = name;
            if (extension is null)
            {
                throw new NullReferenceException();
            }
            if (extension == "" || extension.Contains("."))
            {
                throw new ArgumentException();
            }
            this.extension = extension;
            if(resourceName is null)
            {
                throw new NullReferenceException();
            }
            if(resourceName == "")
            {
                throw new ArgumentException();
            }
            this.resourceName = resourceName;
        }
        public sealed override string ToString()
        {
            return $"({name})";
        }
        public sealed override bool Equals(object obj)
        {
            if (obj is null || obj.GetType().IsAssignableFrom(typeof(AssetBase)))
            {
                return false;
            }
            return name == ((AssetBase)obj).name;
        }
        public sealed override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}
