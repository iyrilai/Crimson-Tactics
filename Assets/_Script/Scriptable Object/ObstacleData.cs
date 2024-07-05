using System.Collections.Generic;
using UnityEngine;

//Store obstacle data to enable obstacle on grid
public class ObstacleData : ScriptableObjectInstance
{
    [SerializeField] List<bool> obstacleEnable = new(); //List of button based on grid size in grid generator

    //Location of scriptable object
    private const string ObstacleDataFilePath = "Assets/Scriptable Objects/ObstacleData.asset";

    //Get the boolean list with this property
    public List<bool> ObstacleEnable => obstacleEnable;

    //Load the instance of scriptable object
    public static ObstacleData LoadInstance()
    {
        return LoadInstance<ObstacleData>(ObstacleDataFilePath);
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
