using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GridViewerWindow : EditorWindow
{
    VisualElement root;
    TileDetector tileDetector;


    [MenuItem("Toolkit/Grid Viewer")]
    public static void ShowEditor()
    {
        GridViewerWindow wnd = GetWindow<GridViewerWindow>();
        wnd.titleContent = new GUIContent("Grid Viewer");
    }

    void CreateGUI()
    {
        root = rootVisualElement;

        var gridPositionDisplay = new Label(UIMessages.DefaulftTileInfo);
        root.Add(gridPositionDisplay);
        tileDetector = new TileDetector(gridPositionDisplay);

        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDestroy()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    void OnInspectorUpdate()
    {
        //Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        //tileDetector.DetectRaycast(ray, 1000);
    }

    void OnSceneGUI(SceneView sceneView)
    {
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        tileDetector.DetectRaycast(ray, 1000);
    }
}