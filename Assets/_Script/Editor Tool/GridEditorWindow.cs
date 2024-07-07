using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

//This Tile infomation on grid in window with mouse raycasting in editor scene
public class GridEditorWindow : EditorWindow
{
    VisualElement root; // window root
    TileDetector tileDetector; //tile detector using raycast 

    //GUI attributes
    Vector2Int gridSize;

    //temp data holder to find change in grid size
    Vector2 gridSizeTemp;

    //To find ID
    GridData gridData;

    //Create menu on editor
    [MenuItem("Toolkit/Grid Editor")]
    public static void ShowEditor()
    {
        GridEditorWindow wnd = GetWindow<GridEditorWindow>();
        wnd.titleContent = new GUIContent("Grid Editor");
    }

    //called on window crated
    void CreateGUI()
    {
        //cache window root
        root = rootVisualElement;

        //Add label to window
        var gridPositionDisplay = new Label(UIMessages.DefaulftTileInfo);
        root.Add(gridPositionDisplay);

        //init tile detector
        tileDetector = new TileDetector(gridPositionDisplay);

        //callback, called 10 times a second
        SceneView.duringSceneGui += OnSceneGUI;
    }

    //init on start of window
    private void Awake()
    {
        //Init value
        gridSize = GridDataObject.LoadInstance().GridSize;
        gridSizeTemp = gridSize;
    }

    //Create custom editor
    void OnGUI()
    {
        EditorGUILayout.Space(30); //space on editor for tile info message

        //Load input field for grid size
        gridSize = EditorGUILayout.Vector2IntField("Grid Size:", gridSize);

        EditorGUILayout.Space(5); //Space for good view

        //Backup button to reset grid
        if (GUILayout.Button("Generate Grid"))
        {
            UpdateGrid();
        }

        var gridData = ComponentFinder.FindComponent<GridData>("Grid");
        if (gridData == null)
            return;

        if (gridData.GridSize != gridSize)
            return;

        EditorGUILayout.Space(20); //Space for good view
        EditorGUILayout.LabelField("Obstacle Editor"); //Text message on editor
        EditorGUILayout.Space(5); //Space for good view

        GenerateObstacleToggle(); //load scriptable object values and toggle button
    }

    //Called evey 10 seconds and update the GUI
    void OnInspectorUpdate()
    {
        if (gridSize != gridSizeTemp) UpdateGrid();
        Repaint();
    }

    //Generate List of toggle button on editor
    void GenerateObstacleToggle()
    {
        //Load scriptableObject
        var obstacleButtons = ObstacleData.LoadInstance();
        obstacleButtons.UpdateObstacleData(gridSize);

        //Loop to set toggle button Vertical and Horizontal
        for (int i = obstacleButtons.GridSize.y - 1; i >= 0; i--)
        {
            //Start Horizontal toggle
            EditorGUILayout.BeginHorizontal();
            {
                for (var j = 0; j < obstacleButtons.GridSize.x; j++)
                {
                    //start Vertical toggle
                    EditorGUILayout.BeginVertical();
                    {
                        //Get id of tile.
                        int id = GetID(new(j, i));

                        //Generate button
                        obstacleButtons.ObstacleEnable[id] = EditorGUILayout.Toggle(obstacleButtons.ObstacleEnable[id]);
                        SetObstacleDataScriptableObjectDirty(); //Called to save scriptableObject
                    }
                    EditorGUILayout.EndVertical(); //End Vertical
                }

                GUILayout.FlexibleSpace(); //used to flexible button on editor
            }

            EditorGUILayout.EndHorizontal(); //End Horizontal
        }
    }

    //Get ID from gridData
    int GetID(Vector2 pos)
    {
        //Get Data if null
        if (gridData == null)
            gridData = ComponentFinder.FindComponent<GridData>("Grid");

        //if Get Data not found then generate one and get again
        if (gridData == null)
        {
            UpdateGrid();
            gridData = ComponentFinder.FindComponent<GridData>("Grid");
        }

        //get tile and return the id value
        var tile = gridData.GetTile(pos);
        return tile.ID;
    }

    //Set 'ObstacleData' scriptable object dirty to save 'ObstacleData' scriptable object on disk
    void SetObstacleDataScriptableObjectDirty()
    {
        EditorUtility.SetDirty(ObstacleData.LoadInstance());
    }

    //Update Grid if 'gridSize' is changed
    void UpdateGrid()
    {
        //Find gridGenerator component
        var gridGen = ComponentFinder.FindComponent<GridGenerator>("Grid");

        //If gridGenerator found the generator grid
        if (gridGen != null)
        {
            gridGen.GenerateGrid(gridSize);
            gridSizeTemp = gridSize;
            return;
        }

        //Create new Grid if no grid avaible
        GameObject gridObject = new("Grid", typeof(GridGenerator), typeof(GridData));
        Undo.RegisterCreatedObjectUndo(gridObject, "Created new grid"); //Register undo for created gameobject
    }

    //Scene GUI callback
    void OnSceneGUI(SceneView sceneView)
    {
        //Raycast of mouse pointer in editor scene
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

        //Call 'DetectRaycast' to get hit of raycast and display the information 
        tileDetector.DetectRaycast(ray, 500);
    }
}