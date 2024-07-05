using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorEditor : Editor
{

    private void OnEnable()
    {
        var gridSize = serializedObject.FindProperty("gridSize");
        var size = gridSize.vector2Value;

        var gridDataObject = GridDataObject.LoadInstance();
        var scriptableGridSize = gridDataObject.GridSize;

        if (size != scriptableGridSize)
            gridDataObject.GridSize = size;
    }

    //This function used create a custom control in inspector 
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(20); //Space between button and property

        var gridGenerator = (GridGenerator)target;

        //Button on editor to generate tile
        if (GUILayout.Button("Generate tile"))
            gridGenerator.GenerateGrid(); 
     
    }
}
