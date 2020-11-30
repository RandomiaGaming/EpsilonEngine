using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;

namespace EpsilonEngine
{
    public static class AssetManager
    {
        private static List<AssetBase> assets = new List<AssetBase>();
        private static List<CodecInfo> codecs = new List<CodecInfo>();
        private static bool loadedCodecs = false;
        public static void LoadCodecs()
        {
            codecs = new List<CodecInfo>();

            Assembly assembly = Assembly.GetCallingAssembly();
            foreach(TypeInfo type in assembly.GetTypes())
            {
                if(type != null)
                {
                    foreach(MethodInfo method in type.GetMethods())
                    {
                        if(method.GetCustomAttribute<RegisterCodecAttribute>() != null)
                        {
                            codecs.Add(new CodecInfo(method));
                        }
                    }
                }
            }

            loadedCodecs = true;
        }
        public static void LoadAssets()
        {
            if(loadedCodecs == false)
            {
                LoadCodecs();
            }

            assets = new List<AssetBase>();
            foreach (string assetResourceName in Assembly.GetCallingAssembly().GetManifestResourceNames())
            {
                string[] splitPath = assetResourceName.Split('.');
                string assetExtention = splitPath[splitPath.Length - 1].ToUpper();
                string assetName = splitPath[splitPath.Length - 2] + "." + assetExtention;

                bool duplicate = false;
                foreach (string usedAssetName in GetAssetNames())
                {
                    if (assetName.ToLower() == usedAssetName.ToLower())
                    {
                        duplicate = true;
                        break;
                    }
                }

                if (duplicate)
                {
                    Console.WriteLine($"Asset with resource name \"{assetResourceName}\" was not loaded because it would cause ambiguity with an existing asset which has the same name.");
                }
                else
                {
                    Stream assetStream = Assembly.GetCallingAssembly().GetManifestResourceStream(assetResourceName);
                    bool foundCodec = false;

                    foreach (CodecInfo codec in codecs)
                    {
                        if (codec.managedExtension == assetExtention)
                        {
                            assets.Add(codec.DecodeAsset(assetStream, assetName));
                            foundCodec = true;
                            break;
                        }
                    }

                    if (!foundCodec)
                    {
                        Console.WriteLine($"Asset with resource name \"{assetResourceName}\" could not be loaded because there is no asset codec which supports that file extension.");
                    }
                }
            }
        }
        public static List<string> GetAssetNames()
        {
            List<string> output = new List<string>();
            foreach (AssetBase asset in assets)
            {
                output.Add(asset.name);
            }
            return output;
        }
        public static List<AssetBase> GetAssets()
        {
            return new List<AssetBase>(assets);
        }
        public static AssetBase GetAsset(string name)
        {
            foreach (AssetBase asset in assets)
            {
                if (asset.name.ToUpper() == name.ToUpper())
                {
                    return asset;
                }
            }
            return null;
        }
    }
}