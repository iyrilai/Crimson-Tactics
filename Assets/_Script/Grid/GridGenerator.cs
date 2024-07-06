using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Generate Tile based on gridSizes on editor
public class GridGenerator : MonoBehaviour
{
    //Store gridSize Temp
    Vector2Int gridSize = new(10, 10);

    //Holds gridData
    GridData grid;

    //Get GridData 'component'
    public GridData GridData 
    { 
        get
        {
            //if null then get component
            if (grid == null)
                grid = GetComponent<GridData>();

            return grid;
        }

        set => grid = value; 
    }

    //Generate Grid with size
    public void GenerateGrid(Vector2Int size)
    {
        gridSize = size;
        GenerateGrid();
    }

    //Generate Grid
    public void GenerateGrid()
    {
        //Clean all child before generating new
        ClearGrid();

        //Generating new tile
        int id = 0; //ID for each tile
        for (int x = 0; x < gridSize.y; x++)
        {
            //Create a tile 
            for (int y = 0; y < gridSize.x; y++)
            {
                //Generate Tile
                var tile = GenerateTile(new(y, x), id);
                
                //id increment for next tile
                id++;
            }
        }

        GridData.ReadGridData(gridSize); //Sent grid data to 'GridData' class
        ObstacleData.LoadInstance().UpdateObstacleData(gridSize);

        //Store grid size in scriptable object for editor uses
#if UNITY_EDITOR
        var gridDataObject = GridDataObject.LoadInstance();
        gridDataObject.GridSize = gridSize;
#endif
    }

    //Create a instance of tile with specified position and return it
    Tile GenerateTile(Vector2Int pos, int id)
    {
        var child = Instantiate(PrefabObjects.LoadInstance().BasicTile, transform); //Creating tile and setting as child of this gameobject
        child.transform.localPosition = new(pos.x, 0, pos.y); //setting position of tile based on 'pos'
        child.name = $"Tile_{id}"; //Assign name child tile

        //Assign a ID value to tile
        var tile = child.AddComponent<Tile>();
        tile.ID = id;
        tile.GridPosition = pos;

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
