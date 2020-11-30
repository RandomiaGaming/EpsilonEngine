using System.IO;
namespace EpsilonEngine
{
    public abstract class AssetBase
    {
        public readonly Stream stream = null;
        public readonly string name = "";
        public AssetBase(Stream stream, string name)
        {
            this.stream = stream;
            this.name = name;
        }
        public sealed override string ToString()
        {
            return $"{{{name}}}";
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
