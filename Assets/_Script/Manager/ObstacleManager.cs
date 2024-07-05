using UnityEngine;


public class ObstacleManager : MonoBehaviour
{
    [SerializeField] ObstacleData obstacleData;
    [SerializeField] Vector3 obstacleOffset = new(0, 0.5f, 0);

    public ObstacleData ObstacleData { get =>  obstacleData; set => obstacleData = value; }

    private void Start()
    {
        GenerateSphere();
    }

    void GenerateSphere()
    {
        for (int i = 0; i < obstacleData.ObstacleEnable.Count; i++) 
        {
            if (obstacleData.ObstacleEnable[i])
                GenerateSphere(i);
        }
    }

    void GenerateSphere(int id)
    {
        var tile = LevelManager.GridData.Tiles[id];
        var sphere = Instantiate(LevelManager.Prefabs.Sphere, tile.transform);
        sphere.transform.localPosition = obstacleOffset;
    }
}
