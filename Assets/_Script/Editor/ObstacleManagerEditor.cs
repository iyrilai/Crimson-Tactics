using UnityEditor;
using UnityEditor.SceneManagement;

//It automatically refers 'ObstacleData' scriptable object in 'ObstacleManager' component
[CustomEditor(typeof(ObstacleManager))]
public class ObstacleManagerEditor : Editor
{
    //called when 'ObstacleManager' is enabled in editor
    private void OnEnable()
    {
        //Get existing obstacleData reference in 'ObstacleManager'
        var obstacleManager = (ObstacleManager)target;
        var obstacleData = obstacleManager.ObstacleData;

        //obstacleData reference is null then get the reference and assign to it
        if (obstacleData == null)
        {
            obstacleManager.ObstacleData = ObstacleData.LoadInstance();
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene()); //To make scene to save
        }
    }
}
