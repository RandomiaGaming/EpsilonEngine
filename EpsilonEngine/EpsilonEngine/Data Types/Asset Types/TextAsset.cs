﻿using System.IO;
namespace EpsilonEngine
{
    public sealed class TextAsset : AssetBase
    {
        public readonly string data = null;

        public TextAsset(Stream stream, string name, string data) : base(stream, name)
        {
            this.data = data;
        }
    }
}
