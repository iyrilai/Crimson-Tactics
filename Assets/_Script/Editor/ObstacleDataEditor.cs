using UnityEditor;

[InitializeOnLoad]
[CustomEditor(typeof(ObstacleData))]
public class ObstacleDataEditor : Editor
{
    static ObstacleDataEditor()
    {

    }

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
        var size = (int)obstacleData.GridSize.x * obstacleData.GridSize.y;

        if (size == obstacleData.ObstacleEnable.Count) return;

        obstacleData.ObstacleEnable.Clear();
        obstacleData.ObstacleEnable.AddRange(new bool[(int)(size)]);
    }
}
