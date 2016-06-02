using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;

namespace Assets.Scripts.Engine.Terrain
{
    public class TerrainGraphicsData : MonoBehaviour
    {
        public List<Color32> _TileColor = new List<Color32>()
        {
            new Color32(80, 159, 34, 255),  //0 rough
            new Color32(117, 242, 37, 255), //1 fairway
            new Color32(114, 255, 0, 255),  //2 green
            new Color32(0, 0, 0, 0),        //3 invisible
            new Color32(1, 1, 1, 255)
        };

        public List<bool> _TileHasRaised = new List<bool>()
        {
            true,                           //0 rough
            false,                          //1 fairway
            false,                          //2 green
            true,                           //3 invisible
            false                           //
        };

        public List<Color32> GetTileColors()
        {
            return _TileColor;
        }

        public bool GetHasRaised(int type)
        {
            return _TileHasRaised[type];
        }
    }
}
