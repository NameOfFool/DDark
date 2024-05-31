using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgorythms
{
    ///
    ///<summary>SimpleRandomWalk method generates hash set of point for tilemap rendering</summary>
    ///<param name="distance"></param>
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPoint, int distance)
    {
        HashSet<Vector2Int> path = new()
        {
            startPoint
        };
        Vector2Int prevPoint = startPoint;
        for (int i = 0; i < distance; i++)
        {
            Vector2Int nextPoint = prevPoint + Direction2D.GetRandomDirection();
            path.Add(nextPoint);
            prevPoint = nextPoint;
        }
        return path;
    }
}

public static class Direction2D
{
    public static List<Vector2Int> cardinalDirections = new()
        {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left,
        };
    public static Vector2Int GetRandomDirection()
    {
        return cardinalDirections[Random.Range(0, cardinalDirections.Count)];
    }
}