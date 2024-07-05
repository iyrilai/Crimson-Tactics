using System;
using System.Collections.Generic;
using UnityEngine;

//Holds all tile information
public class Tile : MonoBehaviour
{
    [SerializeField] int id; //stores tile id
    List<Tile> neighbourTiles; //store neighbourTiles

    //Get and set ID
    public int ID { get => id; set => id = value; }

    //Holds Obstacle Object
    public GameObject Obstacle { get; set; }

    //Returns grid position on local x and z value
    public Vector2 GridPosition
    {
        get
        {
            return new(transform.localPosition.x, transform.localPosition.z);
        }
    }

    //Get the NeighourTiles and store it in 'neighbourTiles' for futher uses
    public List<Tile> NeighourTiles()
    {
        if (neighbourTiles == null)
        {
            List<Tile> neighbours = new();
            //Left
            var neighbourTile = LevelManager.GridData.FindTile(GridPosition + Vector2.left);
            if (neighbourTile != null && neighbourTile.Obstacle == null)
                neighbours.Add(neighbourTile);

            //Right
            neighbourTile = LevelManager.GridData.FindTile(GridPosition + Vector2.right);
            if (neighbourTile != null && neighbourTile.Obstacle == null)
                neighbours.Add(neighbourTile);

            //Up
            neighbourTile = LevelManager.GridData.FindTile(GridPosition + Vector2.up);
            if (neighbourTile != null && neighbourTile.Obstacle == null)
                neighbours.Add(neighbourTile);

            //Down
            neighbourTile = LevelManager.GridData.FindTile(GridPosition + Vector2.down);
            if (neighbourTile != null && neighbourTile.Obstacle == null)
                neighbours.Add(neighbourTile);


            neighbourTiles = neighbours;
        }

        return neighbourTiles;
    }
}
