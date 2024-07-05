using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Generate Tile based on gridSizes on editor
public class GridGenerator : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] GridData grid;

    [Header("Grid properties")]
    [SerializeField] Vector2 gridSize = new(10, 10);

    //Generate Grid
    public void GenerateGrid()
    {
        //Clean all child before generating new
        ClearGrid();

        //New nested lists of tile representing grid position 
        List<ListWrapper<Tile>> tiles = new();

        //Generating new tile
        int id = 0; //ID for each tile
        for (int x = 0; x < gridSize.x; x++)
        {
            //new List to add in nested tile list
            List<Tile> tilesX = new();
            tiles.Add(new(tilesX));

            //Create a tile 
            for (int y = 0; y < gridSize.y; y++)
            {
                var tile = GenerateTile(new(x, y), id);
                tilesX.Add(tile);
                
                //id increment for next tile
                id++;
            }
        }

        grid.ReadGridData(gridSize, tiles); //Sent grid data to 'GridData' class

        //Store grid size in scriptable object for editor uses
#if UNITY_EDITOR
        var gridDataObject = GridDataObject.LoadInstance();
        gridDataObject.GridSize = gridSize;
#endif
    }

    //Create a instance of tile with specified position and return it
    Tile GenerateTile(Vector2 pos, int id)
    {
        var child = Instantiate(PrefabObjects.LoadInstance().BasicTile, transform); //Creating tile and setting as child of this gameobject
        child.transform.localPosition = new(pos.x, 0, pos.y); //setting position of tile based on 'pos'
        child.name = $"Tile_{id}"; //Assign name child tile

        //Assign a ID value to tile
        var tile = child.AddComponent<Tile>();
        tile.ID = id;

        //return tile
        return tile;
    }

    //Clean all existing child
    public void ClearGrid()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            var child = transform.GetChild(0); //Get the 1st child
            Undo.DestroyObjectImmediate(child.gameObject); //Destroy child gameObject and register for undo
        }
    }
}
