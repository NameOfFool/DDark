using UnityEngine;

public  abstract class AbstractGenerator : MonoBehaviour
{
    [SerializeField] protected TilemapVisualiser visualiser = null;

    [SerializeField] protected Vector2Int startPoint;

    public void GenerateDungeon()
    {
        visualiser.Clear();
        RunProceduralGeneration();
    }
    public abstract void RunProceduralGeneration();

}
