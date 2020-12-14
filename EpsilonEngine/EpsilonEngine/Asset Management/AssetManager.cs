using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;
using System.Linq;

namespace EpsilonEngine
{
    public class AssetManager
    {
        public readonly GameInterface gameInterface = null;
        public readonly Game game = null;

        protected List<AssetBase> assets = new List<AssetBase>();
        protected List<AssetDecoder> decoders = new List<AssetDecoder>();
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
        public virtual void RegisterDecoder(AssetDecoder newDecoder)
        {
            if (decoders is null)
            {
                decoders = new List<AssetDecoder>();
            }
            if (newDecoder is null)
            {
                throw new NullReferenceException();
            }
            if (newDecoder.managedExtensions is null || newDecoder.managedExtensions.Length == 0)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < newDecoder.managedExtensions.Length; i++)
            {
                if (newDecoder.managedExtensions[i] is null)
                {
                    throw new NullReferenceException();
                }
                if (newDecoder.managedExtensions[i] == "")
                {
                    throw new ArgumentException();
                }
                foreach (AssetDecoder codec in decoders)
                {
                    foreach (string managedExtension in codec.managedExtensions)
                    {
                        if (managedExtension == newDecoder.managedExtensions[i])
                        {
                            throw new ArgumentException();
                        }
                    }
                }
            }
            decoders.Add(newDecoder);
        }
        public virtual void LoadAllAssets()
        {
            assets = new List<AssetBase>();
            foreach (string assetResourceName in Assembly.GetCallingAssembly().GetManifestResourceNames())
            {
                string[] splitPath = assetResourceName.Split('.');
                string assetExtention = splitPath[splitPath.Length - 1];
                string assetName = splitPath[splitPath.Length - 2];

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
                    foreach (AssetDecoder decoder in decoders)
                    {
                        if (decoder.managedExtensions.Contains(assetExtention.ToUpper()))
                        {
                            assets.Add(decoder.DecodeAsset(assetStream, assetName, assetExtention.ToUpper(), assetResourceName));
                            break;
                        }
                    }
                }
            }
        }
        #region Asset Management
        public virtual List<string> GetAssetNames()
        {
            List<string> output = new List<string>();
            foreach (AssetBase asset in assets)
            {
                output.Add(asset.name);
            }
            return output;
        }
        public virtual List<string> GetAssetNamesWithExtensions()
        {
            List<string> output = new List<string>();
            foreach (AssetBase asset in assets)
            {
                output.Add(asset.name + "." + asset.extension);
            }
            return output;
        }
        public virtual List<string> GetAssetResourceNames()
        {
            List<string> output = new List<string>();
            foreach (AssetBase asset in assets)
            {
                output.Add(asset.resourceName);
            }
            return output;
        }
        public virtual List<AssetBase> GetAssets()
        {
            return new List<AssetBase>(assets);
        }
        public virtual AssetBase GetAssetByName(string name)
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
        public virtual AssetBase GetAssetByResourceName(string resourceName)
        {
            foreach (AssetBase asset in assets)
            {
                if (asset.resourceName.ToUpper() == resourceName.ToUpper())
                {
                    return asset;
                }
            }
            return null;
        }
        #endregion
    }
}