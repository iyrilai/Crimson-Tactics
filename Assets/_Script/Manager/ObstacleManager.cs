using System.Collections.Generic;
using UnityEngine;

//Generate obstacle based on obstacleData
public class ObstacleManager : MonoBehaviour
{
    //scriptableObject holds Obstacle Enable data
    [SerializeField] ObstacleData obstacleData;

    //Obstacle Position Offset
    [SerializeField] Vector3 obstaclePosOffset = new(0, 0.5f, 0);

    List<GameObject> obstacles = new();

    //Obstacle Data references for auto assign 'ObstacleData' Scriptable object
    public ObstacleData ObstacleData { get =>  obstacleData; set => obstacleData = value; }

    //Called At start of frame
    private void OnEnable()
    {
        //generate obstacle sphere
        GenerateSphere();
    }

    //Generate obstacle sphere
    public void GenerateSphere()
    {
        //Generate obstacle sphere for each tile
        for (int i = 0; i < obstacleData.ObstacleEnable.Count; i++) 
        {
            //If Obstacle is enable in 'obstacleData' then Generate sphere
            if (obstacleData.ObstacleEnable[i])
                GenerateSphere(i);
        }
    }

    //Generate obstacle sphere with tile ID
    void GenerateSphere(int id)
    {
        var tile = LevelManager.GridData.Tiles[id]; //Getting tile with ID

        //Create instance of obstacle sphere with tile position and rotation
        var obstacle = Instantiate(LevelManager.Prefabs.Sphere, tile.transform.position + obstaclePosOffset, tile.transform.rotation);
        tile.Obstacle = obstacle;
        obstacles.Add(obstacle);
    }

    //Destroy all obstacles
    public void DestroyObstacles()
    {
        //get each obstacle gameobject and destroy it
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle);
        }

        //Clear the list
        obstacles.Clear();
    }
}
