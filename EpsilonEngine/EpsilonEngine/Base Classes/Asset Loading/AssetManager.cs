using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;

namespace EpsilonEngine
{
    public class AssetManager : GameManager
    {
        public List<AssetBase> assets = new List<AssetBase>();
        public List<AssetCodec> codecs = new List<AssetCodec>();
        public AssetManager(Game game) : base(game)
        {

        }
        public override void Initialize()
        {

        }
        public override void Update()
        {

        }
        public virtual void LoadAssets()
        {
            assets = new List<AssetBase>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] assetPaths = assembly.GetManifestResourceNames();
            for (int i = 0; i < assetPaths.Length; i++)
            {
                Stream assetStream = assembly.GetManifestResourceStream(assetPaths[i]);
                string[] splitPath = assetPaths[i].Split('.');
                string assetExtention = splitPath[splitPath.Length - 1].ToLower();
                string assetName = splitPath[splitPath.Length - 2].ToLower();
                foreach (AssetCodec codec in codecs)
                {
                    if (codec.managedExtensions.Contains(assetExtention))
                    {
                        assets.AddRange(codec.DecodeStream(assetStream, assetName));
                    }
                }
            }
        }

        public List<string> GetAssetNames()
        {
            List<string> output = new List<string>();
            foreach (AssetBase asset in assets)
            {
                output.Add(asset.name.ToLower());
            }
            return output;
        }
        public AssetBase GetAsset(string name)
        {
            foreach (AssetBase asset in assets)
            {
                if (asset.name.ToLower() == name.ToLower())
                {
                    return asset;
                }
            }
            return null;
        }
        public static string StringFromStream(Stream sourceStream)
        {
            return Encoding.ASCII.GetString(BytesFromStream(sourceStream));
        }
        public static byte[] BytesFromStream(Stream sourceStream)
        {
            byte[] output = new byte[sourceStream.Length];
            sourceStream.Read(output, 0, (int)sourceStream.Length);
            return output;
        }
    }
}
