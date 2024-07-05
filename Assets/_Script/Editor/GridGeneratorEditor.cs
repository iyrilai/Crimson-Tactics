using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorEditor : Editor
{
    //Called on 'GridGenerator' component enable on editor
    private void OnEnable()
    {
        //get 'gridSize' property
        var gridSize = serializedObject.FindProperty("gridSize");
        var size = gridSize.vector2Value; //get 'gridSize' value

        //get 'gridDataObect' scriptable object instance
        var gridDataObject = GridDataObject.LoadInstance();

        //get grid size on scriptable object
        var scriptableGridSize = gridDataObject.GridSize;

        //if component gridSize and scriptable object getSize is not equal then 
        //set scriptable object getSize to component gridSize
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
