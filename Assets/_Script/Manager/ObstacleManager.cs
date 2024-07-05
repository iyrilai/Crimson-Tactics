using UnityEngine;


public class ObstacleManager : MonoBehaviour
{
    [SerializeField] ObstacleData obstacleData;

    public ObstacleData ObstacleData { get =>  obstacleData; set => obstacleData = value; }
}
