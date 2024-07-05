using UnityEditor;

[CustomEditor(typeof(ObstacleData))]
public class ObstacleDataEditor : Editor
{
    [MenuItem("Toolkit/Obstacle Editor")]
    public static void ShowEditor()
    {
        Selection.activeObject = ObstacleData.LoadInstance();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        UpdateObstacleOnEnable();
    }

    private void OnEnable()
    {
        UpdateObstacleOnEnable();
    }

    void UpdateObstacleOnEnable()
    {
        var obstacleData = (ObstacleData)target;
        var gridSize = GridDataObject.LoadInstance().GridSize;

        var size = (int)gridSize.x * gridSize.y;

        if (size == obstacleData.ObstacleEnable.Count) return;

        obstacleData.ObstacleEnable.Clear();
        obstacleData.ObstacleEnable.AddRange(new bool[(int)(size)]);
    }
}
