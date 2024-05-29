using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgorythms
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPoint, int distance)
    {
        HashSet<Vector2Int> path = new()
        {
            startPoint
        };
        Vector2Int prevPoint = startPoint;
        for(int i = 0; i < distance; i++)
        {
            Vector2Int nextPoint = prevPoint + GetRandomDirection();
            path.Add(nextPoint);
            prevPoint = nextPoint;
        }
        return path;
    }
    public static Vector2Int GetRandomDirection()
    {
        List<Vector2Int> directions = new()
        {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left,
        };
        return directions[Random.Range(0, directions.Count)];
    }
}