using System;
using System.Collections.Generic;
using UnityEngine;

//Holds all tile information
public class Tile : MonoBehaviour
{
    [SerializeField] int id; //stores tile id
    [SerializeField] Vector2Int gridPosition; //store gridPosition
    List<Tile> neighbourTiles; //store neighbourTiles

    //Get and set ID
    public int ID { get => id; set => id = value; }

    //Holds Obstacle Object
    public GameObject Obstacle { get; set; }

    //Returns grid position
    public Vector2Int GridPosition { get => gridPosition; set => gridPosition = value; }


    //Get the NeighourTiles and store it in 'neighbourTiles' for futher uses
    public List<Tile> NeighourTiles()
    {
        //if 'neighbourTiles' is null then get neighbours 
        if (neighbourTiles == null)
        {
            List<Tile> neighbours = new();
            //Left
            var neighbourTile = LevelManager.GridData.GetTile(GridPosition + Vector2.left);
            if (neighbourTile != null && neighbourTile.Obstacle == null)
                neighbours.Add(neighbourTile);

            //Right
            neighbourTile = LevelManager.GridData.GetTile(GridPosition + Vector2.right);
            if (neighbourTile != null && neighbourTile.Obstacle == null)
                neighbours.Add(neighbourTile);

            //Up
            neighbourTile = LevelManager.GridData.GetTile(GridPosition + Vector2.up);
            if (neighbourTile != null && neighbourTile.Obstacle == null)
                neighbours.Add(neighbourTile);

            //Down
            neighbourTile = LevelManager.GridData.GetTile(GridPosition + Vector2.down);
            if (neighbourTile != null && neighbourTile.Obstacle == null)
                neighbours.Add(neighbourTile);


            neighbourTiles = neighbours;
        }

        //return neighbours
        return neighbourTiles;
    }

    //Static function to get tile count in based on 'gridSize' 
    public static int GetTileCount(Vector2Int gridSize)
    {
        return gridSize.x * gridSize.y;
    }
}
