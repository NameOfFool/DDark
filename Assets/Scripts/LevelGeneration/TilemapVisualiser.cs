using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualiser : MonoBehaviour
{
    [SerializeField] private Tilemap floorTilemap;
    [SerializeField] private Tilemap wallTilemap;
    [SerializeField] private TileBase floorTile;
    [SerializeField] private TileBase wallTile;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPoints)
    {
        PaintTiles(floorPoints, floorTilemap, floorTile);
    }
    public void PaintWallTiles(IEnumerable<Vector2Int> wallPoints)
    {
        PaintTiles(wallPoints, wallTilemap, wallTile);
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
    public void Clear()
    {
        floorTilemap.ClearAllTiles();
    }
}
