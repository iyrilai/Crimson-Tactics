using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

//Holds Tile Data on Generated
public class GridData : MonoBehaviour
{
    //Store grid size
    [SerializeField] Vector2Int gridSize = new(10, 10);

    //It is used to find tile easier
    [SerializeField] List<Tile> tiles = new(); //Holds all the tile

    //It help to optimize 'FindTile(Vector2)' function,
    //Improve pathfininding AI faster but uses extra memeory
    [SerializeField] List<ListWrapper<Tile>> gridTiles; //Holds all the tile as position

    //Local grid size
    public Vector2Int GridSize => gridSize;
    public List<Tile> Tiles => tiles;

    //Get Tile based on Gird Position
    public Tile GetTile(Vector2 position)
    {
        //avoid index expection
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
        foreach (var tile in Tiles)
        {
            //tile ID and given 'id' is same then return tile
            if (tile.ID == id)
                return tile;
        }

        //thorw error in log the tile is not found and return null object
        Debug.LogError($"Tile was not found!, ID: {id}");
        return null;
    }

    public Tile FindTile(Vector2 position)
    {
        foreach (var tile in Tiles)
        {
            //tile ID and given 'id' is same then return tile
            if (tile.GridPosition == position)
                return tile;
        }

        Debug.LogError($"Tile not found position: {position}");
        return null;
    }

    //Referencing all the child tile in 'tiles' list
    public void ReadGridData(Vector2Int size)
    {
        //Init values
        gridSize = size;
        tiles.Clear(); //cleaning old references in list

        // Getting all child by using loop
        for (int i = 0; i < transform.childCount; i++)
        {
            tiles.Add(transform.GetChild(i).GetComponent<Tile>()); //Adding child in 'tiles' list
        }

        //New nested lists of tile representing grid position 
        List<ListWrapper<Tile>> gridTiles = new();
        for (int x = 0; x < gridSize.x; x++)
        {
            //new List to add in nested tile list
            List<Tile> tilesX = new();
            gridTiles.Add(new(tilesX));

            for (int y = 0; y < gridSize.y; y++)
            {
                var tile = FindTile(new Vector2(x, y));
                tilesX.Add(tile);
            }
        }

        //Allocate to gridTiles to store
        this.gridTiles = gridTiles;

        //Called to save the scene
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}
