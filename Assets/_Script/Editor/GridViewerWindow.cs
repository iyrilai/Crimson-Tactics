using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

//This Tile infomation on grid in window with mouse raycasting in editor scene
public class GridViewerWindow : EditorWindow
{
    VisualElement root; // window root
    TileDetector tileDetector; //tile detector using raycast 

    //Create menu on editor
    [MenuItem("Toolkit/Grid Viewer")]
    public static void ShowEditor()
    {
        GridViewerWindow wnd = GetWindow<GridViewerWindow>();
        wnd.titleContent = new GUIContent("Grid Viewer");
    }

    //called on window crated
    void CreateGUI()
    {
        //chace window root
        root = rootVisualElement;

        //Add label to window
        var gridPositionDisplay = new Label(UIMessages.DefaulftTileInfo);
        root.Add(gridPositionDisplay);

        //init tile detector
        tileDetector = new TileDetector(gridPositionDisplay);

        //callback, called 10 times a second
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDestroy()
    {
        //remove callback on window destroy
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    void OnSceneGUI(SceneView sceneView)
    {
        //Raycast of mouse pointer in editor scene
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

        //Call 'DetectRaycast' to get hit of raycast and display the information 
        tileDetector.DetectRaycast(ray, 500);
    }
}