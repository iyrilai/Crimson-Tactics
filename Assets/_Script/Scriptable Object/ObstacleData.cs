using System.Collections.Generic;
using UnityEngine;

//Store obstacle data to enable obstacle on grid
public class ObstacleData : ScriptableObjectSingleton
{
    [SerializeField] List<bool> obstacleEnable = new(); //List of button based on grid size in grid generator

    //Location of scriptable object
    private const string ObstacleDataFilePath = "Assets/Scriptable Objects/ObstacleData.asset";

    //Get the boolean list with this property
    public List<bool> ObstacleEnable => obstacleEnable;

    //Store grid size
    public Vector2Int GridSize { get; private set; }

    //Load the instance of scriptable object
    public static ObstacleData LoadInstance()
    {
        return LoadInstance<ObstacleData>(ObstacleDataFilePath);
    }

    //Update Obstacle Data
    public void UpdateObstacleData(Vector2Int gridSize)
    {
        GridSize = gridSize;
        
        //Get total size of grid
        var size = Tile.GetTileCount(gridSize);

        //if size and boolen button size is same then return
        //else generate ne boolean buttons
        if (size == ObstacleEnable.Count) return;

        ObstacleEnable.Clear();
        ObstacleEnable.AddRange(new bool[size]);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        //Restart Obstacle Manager in Runtime
        if (LevelManager.Instance == null) return;
        LevelManager.ObstacleManager.DestroyObstacles();
        LevelManager.ObstacleManager.GenerateSphere();
    }
#endif
}
