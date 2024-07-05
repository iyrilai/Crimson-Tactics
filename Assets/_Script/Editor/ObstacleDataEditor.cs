using UnityEditor;

//It unity toolkit obstacle editor for grid
[CustomEditor(typeof(ObstacleData))]
public class ObstacleDataEditor : Editor
{
    //Create menu on editor
    [MenuItem("Toolkit/Obstacle Editor")]
    public static void ShowEditor()
    {
        //Display scriptable object on inspector
        Selection.activeObject = ObstacleData.LoadInstance();
    }

    //used to create custom inspector
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        UpdateObstacleOnEnable(); //Get gridSize and update boolean button based on grid size
    }

    //called on 'ObstacleData' component enable on editor
    private void OnEnable()
    {
        UpdateObstacleOnEnable(); //Get gridSize and update boolean button based on grid size
    }

    //Get gridSize and update boolean button based on grid size
    void UpdateObstacleOnEnable()
    {
        var obstacleData = (ObstacleData)target; // Get scriptable object
        var gridSize = GridDataObject.LoadInstance().GridSize; // get grid size on 'GridDataObject' scriptable object

        //Get total size of grid
        var size = (int)gridSize.x * gridSize.y;

        //if size and boolen button size is same then return
        //else generate ne boolean buttons
        if (size == obstacleData.ObstacleEnable.Count) return;

        obstacleData.ObstacleEnable.Clear();
        obstacleData.ObstacleEnable.AddRange(new bool[(int)(size)]);
    }
}
