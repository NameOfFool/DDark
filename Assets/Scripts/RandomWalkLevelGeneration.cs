using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.AI;
using NavMeshPlus.Components;

public class RandomWalkLevelGeneration : MonoBehaviour
{
    [SerializeField] protected Vector2Int startPoint;

    [SerializeField] private int iteration = 10;
    [SerializeField] public int walkLength = 10;
    [SerializeField] public bool eachIterationIsRandom = true;

    [SerializeField] private TilemapVisualiser tilemapVisualiser;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject navmesh;
    private bool isGenerationEnded = false;

    public void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPoint = GetFloorPoints();
        tilemapVisualiser.PaintFloorTiles(floorPoint);
        isGenerationEnded = true;
        //Instantiate(player, new Vector3Int(0,0), Quaternion.identity);
    }
    void Awake()
    {
        RunProceduralGeneration();
        Instantiate(enemy, new Vector3Int(-1,-1,0), Quaternion.identity);
    }
    protected HashSet<Vector2Int> GetFloorPoints()
    {
        Vector2Int currentPoint = startPoint;
        HashSet<Vector2Int> floorPoints = new HashSet<Vector2Int>();
        for(int i = 0; i < iteration; i++)
        {
            HashSet<Vector2Int> path = ProceduralGenerationAlgorythms.SimpleRandomWalk(currentPoint, walkLength);
            floorPoints.UnionWith(path);
            if(eachIterationIsRandom)
            {
                currentPoint = floorPoints.ElementAt(Random.Range(0,floorPoints.Count));
            }
        }
        return floorPoints;
    }
}
