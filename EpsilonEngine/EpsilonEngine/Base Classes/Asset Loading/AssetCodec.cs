using System.IO;
using System;

namespace EpsilonEngine
{
    public abstract class AssetCodec
    {
        public readonly GameInterface gameInterface = null;
        public readonly Game game = null;
        public readonly AssetManager assetManager = null;

        public readonly string managedExtension = null;
        public AssetCodec(AssetManager assetManager, string managedExtension)
        {
            if(assetManager is null)
            {
                throw new NullReferenceException();
            }
            this.assetManager = assetManager;
            if(assetManager.game is null)
            {
                throw new NullReferenceException();
            }
            game = assetManager.game;
            if(assetManager.gameInterface is null)
            {
                throw new NullReferenceException();
            }
            gameInterface = assetManager.gameInterface;
            if(managedExtension is null)
            {
                throw new NullReferenceException();
            }
            if(managedExtension.Contains(".") || managedExtension == "")
            {
                throw new ArgumentException();
            }
            this.managedExtension = managedExtension;
        }
        public abstract AssetBase DecodeStream(Stream stream, string name);
    }
}