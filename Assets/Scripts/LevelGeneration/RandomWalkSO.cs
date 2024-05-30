using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomWalkParameters_", menuName = "Level Generation/RandomWalkData")]
public class RandomWalkSO : ScriptableObject
{
    public int iteration = 10, walkLength = 10;

    public bool eachIterationIsRandom = true;

}
