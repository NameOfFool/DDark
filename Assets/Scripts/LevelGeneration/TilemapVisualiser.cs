using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualiser : MonoBehaviour
{
    [SerializeField] private Tilemap floorTilemap;
    [SerializeField] private TileBase floorTile;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPoints)
    {
        PaintTiles(floorPoints, floorTilemap, floorTile);
    }
    public void PaintTiles(IEnumerable<Vector2Int> floorPoints, Tilemap tilemap, TileBase tile)
    {
        foreach(var point in floorPoints)
        {
            PaintSingleTile(tilemap, tile, point);
        }
    }
    public void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int point)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)point);
        tilemap.SetTile(tilePosition, tile);
    }
}
