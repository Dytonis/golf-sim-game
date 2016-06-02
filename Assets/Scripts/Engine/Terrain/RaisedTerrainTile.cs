using UnityEngine;
using System.Collections;
using Assets.Scripts.Engine.Internal;
using UnityEditor;

namespace Assets.Scripts.Engine.Terrain
{
    public class RaisedTerrainTile : BGObject
    {
        public TileDataSet RaisedTerrainData;
        public TileData SelectedRaisedTile;

        public new void Start()
        {
            RaisedTerrainData = new TileDataSet((int)GridSize.x, (int)GridSize.y, this);
            base.Start();
            UpdateForAllTiles();
        }

        public bool CreateBlankTestTexture()
        {
            Texture2D tex = new Texture2D((int)GridSize.x, (int)GridSize.y);
            for (int y = 0; y < RaisedTerrainData.GetLength(); y++)
            {
                for (int x = 0; x < RaisedTerrainData.GetLengthOfSubArray(y); x++)
                {
                    tex.SetPixel(x, y, RaisedTerrainData[x, y].ColorData);
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
                RaisedTerrainData[(int)Position.x, (int)Position.y] = newData;
            }
            catch
            {
                return false;
            }

            if (AutoUpdate)
            {
                return UpdateForNewTile(Position);
            }
            return true;
        }

        public bool UpdateForNewTile(Vector2 Position)
        {
            Texture2D tex = GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
            tex.SetPixel((int)Position.x, (int)Position.y, RaisedTerrainData[(int)Position.x, (int)Position.y].ColorData);
            tex.Apply();
            return true;
        }

        public bool UpdateForAllTiles()
        {
            Texture2D tex = new Texture2D((int)GridSize.x, (int)GridSize.y);
            for (int y = 0; y < RaisedTerrainData.GetLength(); y++)
            {
                for (int x = 0; x < RaisedTerrainData.GetLengthOfSubArray(y); x++)
                {
                    tex.SetPixel(x, y, RaisedTerrainData[x, y].ColorData);
                }
            }

            tex.Apply();
            tex.filterMode = FilterMode.Point;

            GetComponent<MeshRenderer>().material.mainTexture = tex;

            return true;
        }
    }

    [CustomEditor(typeof(RaisedTerrainTile))]
    public class RaisedTerrainTileEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        }
    }
}