using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGenerator : MonoBehaviour
{
    public void GenerateNavMesh()
    {
        NavMeshSurface sur = GetComponent<NavMeshSurface>();
        sur.BuildNavMesh();
    }
}
