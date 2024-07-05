using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(ObstacleManager))]
public class ObstacleManagerEditor : Editor
{
    SerializedProperty obstacleData;


    private void OnEnable()
    {
        var obstacleManager = (ObstacleManager)target;
        var obstacleData = obstacleManager.ObstacleData;

        if(obstacleData == null )
        {
            obstacleManager.ObstacleData = ObstacleData.LoadInstance();
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
