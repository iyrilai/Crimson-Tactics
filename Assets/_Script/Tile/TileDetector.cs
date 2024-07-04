using UnityEngine;

//This Script detect the tile and display the info on UI label
public class TileDetector : MonoBehaviour
{
    [SerializeField] float maxDistance; //max distance of mouse raycast

    // Update is called once per frame
    void Update()
    {
        //Raycast of mouse
        Ray ray = LevelManager.Camera.ScreenPointToRay(Input.mousePosition);
        
        //Call 'OnRaycastStay()' Function raycast hit
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            OnRaycastStay(hit);
        }
    }

    //Called when raycast hit the object
    void OnRaycastStay(RaycastHit hit)
    {
        //Get the raycast hit, Gameobject 
        var gameObj = hit.collider.gameObject;

        //If Gameobject is tile then call function 'DisplayTileInfo'
        if (gameObj.CompareTag("Tile"))      
            DisplayTileInfo(gameObj);     
    }

    //This Function Display tile information on UI
    void DisplayTileInfo(GameObject tileObj)
    {
        //Get the Tile Component if avaliable
        if(tileObj.TryGetComponent<Tile>(out var tile))
        {
            LevelManager.UI.DisplayTileInfo.text = $"Grid Position: {tile.GridPosition.x}, {tile.GridPosition.y}\nID: {tile.ID}";
            return;
        }

        Debug.LogWarning($"Tile component missing on {tileObj.name}");
    }
}
