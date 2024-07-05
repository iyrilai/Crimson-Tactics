using System.Collections.Generic;
using UnityEngine;

//Holds Tile Data on Generated
public class GridData : MonoBehaviour
{
    [SerializeField] List<GameObject> tiles = new(); //Holds all the tile as gameobject

    public List<GameObject> Tiles => tiles;

    //Get Tile based on ID
    public GameObject GetTile(int id)
    {
        return Tiles[id];
    }

    //Referencing all the child tile in 'tiles' list
    public void ReadGridData()
    {
        tiles.Clear(); //cleaning old references in list

        // Getting all child by using loop
        for (int i = 0; i < transform.childCount; i++)
        {
            tiles.Add(transform.GetChild(i).gameObject); //Adding child in 'tiles' list
        }
    }
}
