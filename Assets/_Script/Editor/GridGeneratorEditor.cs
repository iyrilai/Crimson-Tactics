using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorEditor : Editor
{
    //This function used create a custom control in inspector 
    public override void OnInspectorGUI()
    {
        //Button on editor to generate tile
        if (GUILayout.Button("Edit Grid"))
            EditorWindow.GetWindow<GridEditorWindow>().Show();

    }
}
