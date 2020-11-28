using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;

namespace EpsilonEngine
{
    public class AssetManager
    {
        public readonly GameInterface gameInterface = null;
        public readonly Game game = null;

        protected List<AssetBase> assets = new List<AssetBase>();
        protected List<AssetCodec> codecs = new List<AssetCodec>();
        public AssetManager(Game game)
        {
            if (game is null)
            {
                throw new NullReferenceException();
            }
            this.game = game;
            if (game.gameInterface is null)
            {
                throw new NullReferenceException();
            }
            gameInterface = game.gameInterface;
        }

        public virtual void RegisterCodec(AssetCodec newAssetCodec)
        {
            if (codecs is null)
            {
                codecs = new List<AssetCodec>();
            }

            if (newAssetCodec is null)
            {
                throw new NullReferenceException();
            }

            foreach (AssetCodec codec in codecs)
            {
                if (codec.managedExtension == newAssetCodec.managedExtension)
                {
                    Console.WriteLine($"Codec could not be registered because there was already a codec which managed assets with the \"{newAssetCodec.managedExtension}\" extension.");
                }
            }

            codecs.Add(newAssetCodec);
        }
        public virtual void UnregisterCodec(string managedExtension)
        {
            if (managedExtension is null)
            {
                throw new NullReferenceException();
            }

            if (codecs is null)
            {
                codecs = new List<AssetCodec>();
                Console.WriteLine($"Codec with managed extension \"{managedExtension}\" was already unregistered or does not exist.");
                return;
            }

            for (int i = 0; i < codecs.Count; i++)
            {
                if (codecs[i].managedExtension.ToLower() == managedExtension.ToLower())
                {
                    codecs.RemoveAt(i);
                    return;
                }
            }

            Console.WriteLine($"Codec with managed extension \"{managedExtension}\" was already unregistered or does not exist.");
        }
        public virtual void SetCodecs(List<AssetCodec> codecs)
        {
            if (codecs is null)
            {
                throw new NullReferenceException();
            }

            this.codecs = new List<AssetCodec>(codecs);
        }
        public virtual List<string> GetManagedExtensions()
        {
            if(codecs is null)
            {
                codecs = new List<AssetCodec>();
                return new List<string>();
            }

            List<string> output = new List<string>();
            for (int i = 0; i < codecs.Count; i++)
            {
                output.Add(codecs[i].managedExtension);
            }
            return output;
        }
        public virtual List<AssetCodec> GetCodecs()
        {
            return new List<AssetCodec>(codecs);
        }
        public virtual AssetCodec GetCodec(string managedExtension)
        {
            if (codecs is null)
            {
                codecs = new List<AssetCodec>();
                return null;
            }

            for (int i = 0; i < codecs.Count; i++)
            {
                if (codecs[i].managedExtension.ToLower() == managedExtension)
                {
                    return codecs[i];
                }
            }

            return null;
        }


        public virtual void LoadAssets()
        {
            assets = new List<AssetBase>();
            foreach (string assetResourceName in Assembly.GetCallingAssembly().GetManifestResourceNames())
            {
                LoadAsset(assetResourceName);
            }
        }
        public virtual void LoadAsset(string assetResourceName)
        {
            if (assets is null)
            {
                assets = new List<AssetBase>();
            }

            string[] splitPath = assetResourceName.Split('.');
            string assetExtention = splitPath[splitPath.Length - 1];
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

                foreach (AssetCodec codec in codecs)
                {
                    if (codec.managedExtension.ToLower() == assetExtention.ToLower())
                    {
                        assets.Add(codec.DecodeStream(assetStream, assetName));
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
        public virtual void UnloadAsset(string name)
        {
            if (name is null)
            {
                throw new NullReferenceException();
            }

            if (assets is null)
            {
                assets = new List<AssetBase>();
                Console.WriteLine($"Asset with name \"{name}\" was already unloaded or does not exist.");
                return;
            }

            for (int i = 0; i < assets.Count; i++)
            {
                if (assets[i].name.ToLower() == name.ToLower())
                {
                    assets.RemoveAt(i);
                    return;
                }
            }

            Console.WriteLine($"Asset with name \"{name}\" was already unloaded or does not exist.");
        }
        public virtual List<string> GetAssetNames()
        {
            List<string> output = new List<string>();
            foreach (AssetBase asset in assets)
            {
                output.Add(asset.name);
            }
            return output;
        }
        public virtual List<AssetBase> GetAssets()
        {
            return new List<AssetBase>(assets);
        }
        public virtual AssetBase GetAsset(string name)
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
    }
}