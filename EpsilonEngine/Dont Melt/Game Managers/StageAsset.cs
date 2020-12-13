using EpsilonEngine;
using System;
using System.IO;

namespace DontMelt
{
    public sealed class StageAsset : AssetBase
    {
        public readonly StageData data = null;
        public StageAsset(StageData data, Stream stream, string name) : base(stream, name)
        {
            if(data is null)
            {
                throw new NullReferenceException();
            }
            this.data = data;
        }
    }
}
