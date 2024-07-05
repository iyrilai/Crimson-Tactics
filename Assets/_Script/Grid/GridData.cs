using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

//Holds Tile Data on Generated
public class GridData : MonoBehaviour
{
    [SerializeField] Vector2 gridSize = new(10, 10);

    //It is used to find tile easier
    [SerializeField] List<Tile> tiles = new(); //Holds all the tile

    //It help to optimize 'FindTile(Vector2)' function,
    //Improve pathfininding AI faster but uses extra memeory
    [SerializeField] List<ListWrapper<Tile>> gridTiles; //Holds all the tile as position

    public Vector2 GridSize => gridSize;
    public List<Tile> Tiles => tiles;

    //Get Tile based on Gird Position
    public Tile FindTile(Vector2 position)
    {      
        try
        {
            return gridTiles[(int)position.x].List[(int)position.y]; ;
        }
        catch 
        { 
            return null; 
        }
    }

    //Get Tile based on ID
    public Tile FindTile(int id)
    {
        foreach(var tile in Tiles) 
        {
            //tile ID and given 'id' is same then return tile
            if (tile.ID == id)
                return tile;
        }

        //thorw error in log the tile is not found and return null object
        Debug.LogError($"Tile was not found!, ID: {id}");
        return null;
    }

    //Referencing all the child tile in 'tiles' list
    public void ReadGridData(Vector2 size, List<ListWrapper<Tile>> gridTiles)
    {
        gridSize = size;
        this.gridTiles = gridTiles;

        tiles.Clear(); //cleaning old references in list

        // Getting all child by using loop
        for (int i = 0; i < transform.childCount; i++)
        {
            tiles.Add(transform.GetChild(i).GetComponent<Tile>()); //Adding child in 'tiles' list
        }

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}
