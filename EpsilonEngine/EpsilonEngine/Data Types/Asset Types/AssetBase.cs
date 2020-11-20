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
            return $"Asset: {name}";
        }
        public sealed override bool Equals(object obj)
        {
            if (obj is AssetBase @base && @base.name == name)
            {
                return true;
            }
            return false;
        }
        public sealed override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}
