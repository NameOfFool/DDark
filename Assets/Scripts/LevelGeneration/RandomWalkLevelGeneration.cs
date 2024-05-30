using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.AI;
using NavMeshPlus.Components;

public class RandomWalkLevelGeneration : AbstractGenerator
{

    [SerializeField] private RandomWalkSO randomWalkParams;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject navmesh;
    private bool isGenerationEnded = false;

    public  override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPoints = GetFloorPoints();
        visualiser.PaintFloorTiles(floorPoints);
        WallGenerator.CreateWalls(floorPoints, visualiser);
        isGenerationEnded = true;
        //Instantiate(player, new Vector3Int(0,0), Quaternion.identity);
    }
    void Awake()
    {
        RunProceduralGeneration();
        Instantiate(enemy, new Vector3Int(-1,-1,0), Quaternion.identity);
    }
    private void FixedUpdate()
    {
        if(isGenerationEnded)
        {
            navmesh.GetComponent<NavMeshGenerator>().GenerateNavMesh();
            isGenerationEnded = false;
        }
    }
    protected HashSet<Vector2Int> GetFloorPoints()
    {
        Vector2Int currentPoint = startPoint;
        HashSet<Vector2Int> floorPoints = new HashSet<Vector2Int>();
        for(int i = 0; i < randomWalkParams.iteration; i++)
        {
            HashSet<Vector2Int> path = ProceduralGenerationAlgorythms.SimpleRandomWalk(currentPoint, randomWalkParams.walkLength);
            floorPoints.UnionWith(path);
            if(randomWalkParams.eachIterationIsRandom)
            {
                currentPoint = floorPoints.ElementAt(Random.Range(0,floorPoints.Count));
            }
        }
        return floorPoints;
    }

}
