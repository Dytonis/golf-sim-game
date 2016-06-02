using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Engine.Internal
{
    public class TileData
    {
        public byte Type;
        public Vector2 Position;
        public bool HasRaisedVisible = true;
        public Color32 ColorData
        {
            get
            {
                return bgr.TileGraphicsData.GetTileColors()[Type];
            }
        }
        private BGObject bgr;

        public TileData(BGObject b)
        {
            bgr = b;
        }

        public static implicit operator string(TileData data)
        {
            return "Position: { x: " + data.Position.x + ", y: " + data.Position.y + " }, Type: " + data.Type;
        }

        internal int GetLength(int v)
        {
            throw new NotImplementedException();
        }
    }
}
