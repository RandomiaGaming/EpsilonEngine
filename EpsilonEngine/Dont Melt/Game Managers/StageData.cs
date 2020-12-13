using EpsilonEngine;
using System;
using System.Collections.Generic;

namespace DontMelt
{
    public sealed class TileData
    {
        public readonly string itemName = "Ground";
        public readonly Vector2Int position = Vector2Int.Zero;
        public TileData(string itemName, Vector2Int position)
        {
            if(itemName is null)
            {
                throw new NullReferenceException();
            }
            this.itemName = itemName;
            this.position = position;
        }
    }
    public sealed class StageData
    {
        public List<TileData> data = new List<TileData>();
    }
}
