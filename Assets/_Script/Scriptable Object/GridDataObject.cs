using UnityEditor;
using UnityEngine;

public class GridDataObject : ScriptableObjectSingleton
{
    [SerializeField] Vector2Int gridSize;

    //Location of scriptable object
    private const string GridDataFilePath = "Assets/Scriptable Objects/GridData.asset";

    //Get the gridSize with this property
    public Vector2Int GridSize 
    { 
        get => gridSize; 
        set
        {
            gridSize = value;
            EditorUtility.SetDirty(this);
        }
    }

    //Load the instance of scriptable object
    public static GridDataObject LoadInstance()
    {
        return LoadInstance<GridDataObject>(GridDataFilePath);
    }
}