using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(20); //Space between button and property

        var gridGenerator = (GridGenerator)target;
        if (GUILayout.Button("Generate tile"))
            gridGenerator.GenerateGrid(); //Button on editor to generate tile
    }
}
