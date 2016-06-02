using Assets.Scripts.Engine.Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Engine
{
    public class BGObject : MonoBehaviour
    {
        [HideInInspector]
        public Terrain.TerrainTile MainTerrain;
        [HideInInspector]
        public Terrain.RaisedTerrainTile MainRaisedTerrain;
        [HideInInspector]
        public TerrainGraphicsData TileGraphicsData;

        public Vector2 GridSize;

        public void Start()
        {
            try
            {
                MainTerrain = GameObject.FindGameObjectWithTag("MainTerrain").GetComponent<TerrainTile>();
                MainRaisedTerrain = GameObject.FindGameObjectWithTag("RaisedTerrain").GetComponent<RaisedTerrainTile>();
                TileGraphicsData = GameObject.FindGameObjectWithTag("GameController").GetComponent<TerrainGraphicsData>();
            }
            catch
            {
                Debug.LogError("FATAL: Could not find object to bind in BGObject.");
            }
        }
    }
}
