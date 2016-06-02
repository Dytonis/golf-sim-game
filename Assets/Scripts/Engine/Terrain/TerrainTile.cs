using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

using Assets.Scripts.Engine.Internal;

namespace Assets.Scripts.Engine.Terrain
{
    public class TerrainTile : BGObject
    {
        //handles all data for terrain (tile data)
        //golf ball effects will be handled on the ball script
        //tiles will interweave textures here

        public TileDataSet TerrainData;
        public TileData SelectedTile;

        public new void Start()
        {
            TerrainData = new TileDataSet((int)GridSize.x, (int)GridSize.y, this);
            base.Start();
            UpdateForAllTiles();
        }

        public TileData GetTileDataFromPosition(Vector3 position)
        {
            Vector2 positionNormalized = new Vector2(Truncate(position.x, 4), Truncate(position.z, 4));

            int x = Mathf.FloorToInt(positionNormalized.x);
            int y = Mathf.FloorToInt(positionNormalized.y);
            return TerrainData[x, y];
        }

        public float Truncate(float value, int digits)
        {
            double mult = Mathf.Pow(10.0f, digits);
            double result = Math.Truncate(mult * value) / mult;
            return (float)result;
        }

        public bool CreateBlankTestTexture()
        {
            Texture2D tex = new Texture2D((int)GridSize.x, (int)GridSize.y);
            for (int y = 0; y < TerrainData.GetLength(); y++)
            {
                for (int x = 0; x < TerrainData.GetLengthOfSubArray(y); x++)
                {
                    tex.SetPixel(x, y, TerrainData[x, y].ColorData);
                }
            }

            tex.Apply();
            tex.filterMode = FilterMode.Point;

            GetComponent<MeshRenderer>().material.mainTexture = tex;

            return true;
        }

        public bool CreateTestingTexture()
        {
            Texture2D tex = new Texture2D((int)GridSize.x, (int)GridSize.y);
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    tex.SetPixel(x, y, Color.white);
                }
            }

            tex.Apply();
            tex.filterMode = FilterMode.Point;

            GetComponent<MeshRenderer>().material.mainTexture = tex;

            return true;
        }

        public bool EditTileData(Vector2 Position, TileData newData, bool AutoUpdate = true)
        {
            try
            {
                TerrainData[(int)Position.x, (int)Position.y] = newData;
                if(newData.HasRaisedVisible == false) //if we need to remove the raised terrain
                {
                    MainRaisedTerrain.EditTileData(Position, new TileData(this) { Position = Position, Type = 3 });
                }
                else
                {
                    MainRaisedTerrain.EditTileData(Position, new TileData(this) { Position = Position, Type = 0 });
                }
            }
            catch
            {
                Debug.LogError("Error: Failed EditTileData");
                return false;
            }

            if(AutoUpdate)
            {
                return UpdateForNewTile(Position);
            }
            return true;
        }

        public bool UpdateForNewTile(Vector2 Position)
        {
            Texture2D tex = GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
            tex.SetPixel((int)Position.x, (int)Position.y, TerrainData[(int)Position.x, (int)Position.y].ColorData);
            tex.Apply();
            return true;
        }

        public bool UpdateForAllTiles()
        {
            Texture2D tex = new Texture2D((int)GridSize.x, (int)GridSize.y);
            for (int y = 0; y < TerrainData.GetLength(); y++)
            {
                for (int x = 0; x < TerrainData.GetLengthOfSubArray(y); x++)
                {
                    tex.SetPixel(x, y, TerrainData[x, y].ColorData);
                }
            }

            tex.Apply();
            tex.filterMode = FilterMode.Point;

            GetComponent<MeshRenderer>().material.mainTexture = tex;

            return true;
        }
    }

    [CustomEditor(typeof(TerrainTile))]
    public class TerrainTileEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        }
    }
}
