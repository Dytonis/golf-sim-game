using UnityEngine;
using System.Collections;
using Assets.Scripts.Engine;

namespace Assets.Scripts.CameraUtil
{
    public class CameraInputRaycast : BGObject
    {

        RaycastHit hit;
        Ray ray;

        public byte TypeSelected = 2;

        [Space]
        public bool DrawDebugRay = false;

        // Update is called once per frame
        void Update()
        {
            ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            int layer = LayerMask.NameToLayer("Terrain");
            int mask = 1 << layer;
            if (Physics.Raycast(ray, out hit, 10000, mask))
            {
                Engine.Internal.TileData data;
                data = hit.collider.GetComponent<Engine.Terrain.TerrainTile>().GetTileDataFromPosition(hit.point);
                MainTerrain.SelectedTile = data;

                if (DrawDebugRay)
                    Debug.DrawRay(ray.origin, ray.direction * 50, Color.black);

                if(Input.GetMouseButtonDown(0))
                {
                    MainTerrain.EditTileData(MainTerrain.SelectedTile.Position, new Engine.Internal.TileData(this) { Position = MainTerrain.SelectedTile.Position, Type = TypeSelected, HasRaisedVisible = TileGraphicsData.GetHasRaised(TypeSelected) });
                }
            }
            else
            {
                if(MainTerrain.SelectedTile != null)
                    MainTerrain.SelectedTile = null;
            }
        }
    }
}
