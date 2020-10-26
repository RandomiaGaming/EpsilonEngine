using System.IO;
namespace EpsilonEngine
{
    public sealed class TextAsset : AssetBase
    {
        public string data = null;
        private TextAsset()
        {
            stream = null;
            path = null;
            data = null;
        }
        public TextAsset(string path, Stream stream)
        {
            this.path = path;
            this.stream = stream;
            data = AssetLoader.StringFromStream(stream);
        }
    }
}
