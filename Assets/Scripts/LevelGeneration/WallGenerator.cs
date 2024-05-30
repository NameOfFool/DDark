using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPoints, TilemapVisualiser visualiser)
    {
        HashSet<Vector2Int> wallPoints = FindWallsInDirection(floorPoints, Direction2D.cardinalDirections);
        visualiser.PaintWallTiles(wallPoints);
    }
    private static HashSet<Vector2Int> FindWallsInDirection(HashSet<Vector2Int> floorPoints, List<Vector2Int> directions)
    {
        HashSet<Vector2Int> wallPoints = new HashSet<Vector2Int>();
        foreach(Vector2Int position in floorPoints)
        {
            foreach(Vector2Int direction in directions)
            {
                Vector2Int neighbourPoint = position + direction;
                if(!floorPoints.Contains(neighbourPoint))
                {
                    wallPoints.Add(neighbourPoint);
                }
            }
        }
        return wallPoints;
    }
}
