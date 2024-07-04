using System;
using UnityEditor;
using UnityEngine;

//Generate Tile based on gridSizes
public class GridGenerator : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] GameObject tileObject;
    [SerializeField] GridData grid;

    [Header("Grid properties")]
    [SerializeField] Vector2 gridSize = new(10, 10);

    //Generate Grid
    public void GenerateGrid()
    {
        if (tileObject == null)      
            Debug.LogError("TileObejct is null");
        

        ClearGrid(); //Clean all child before generating new

        //Generating new tile
        int id = 0; //ID for each tile
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                GenerateTile(new(i, j), id);
                id++;
            }
        }

        grid.ReadGridData();
    }

    //Create a instance of tile with specified position
    void GenerateTile(Vector2 pos, int id)
    {
        var child = Instantiate(tileObject, transform); //Creating tile and setting as child of this gameobject
        child.transform.localPosition = new(pos.x, 0, pos.y); //setting position of tile based on 'pos'
        child.name = $"Tile_{id}"; //Assign name child tile

        //Assign a ID value to tile
        var tile = child.AddComponent<Tile>();
        tile.ID = id;
    }

    //Clean all existing child
    public void ClearGrid()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(0); //Get the 1st child
            Undo.DestroyObjectImmediate(child); //Register removed child
            DestroyImmediate(child); //remove the child
        }
    }
}
