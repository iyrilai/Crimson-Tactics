using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Store obstacle data to enable obstacle on grid
public class ObstacleData : ScriptableObject
{
    [SerializeField] Vector2 gridSize = new(10, 10);
    [SerializeField] List<bool> obstacleEnable = new();

    private const string ObstacleDataFilePath = "Assets/Scriptable Objects/ObstacleData.asset";

    public Vector2 GridSize => gridSize;
    public List<bool> ObstacleEnable => obstacleEnable;

    public static ObstacleData LoadInstance()
    {
        var instance = AssetDatabase.LoadAssetAtPath<ObstacleData>(ObstacleDataFilePath);

        if (instance == null)
        {
            instance = CreateInstance<ObstacleData>();

            AssetDatabase.CreateAsset(instance, ObstacleDataFilePath);
            AssetDatabase.SaveAssets();
        }

        return instance;
    }
}
