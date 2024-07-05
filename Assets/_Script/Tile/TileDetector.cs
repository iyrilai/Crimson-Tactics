using UnityEngine.UIElements;
using UnityEngine;

//Tile Detector based mouse raycast
public class TileDetector : RaycastDetector, IRayscatEvents
{
    readonly Label displayInfoLabel; //text component to display the tile information

    //constructor to init 'displayInfoLabel'
    public TileDetector(Label displayInfoLabel)
    {
        this.displayInfoLabel = displayInfoLabel; //assign 'displayInfoLabel' value
    }

    //Call 'RaycastDetector.DetectRaycast(Ray, float, IRayscatEvents)' with functional callball in this class
    public void DetectRaycast(Ray ray, float maxDistance)
    {
        DetectRaycast(ray, maxDistance, this);
    }

    //Display the label details with attrached label
    void DisplayTileInfo(GameObject tileObj)
    {
        //Try to get 'Tile' componment to get information about tile.
        if (tileObj.TryGetComponent<Tile>(out var tile))
        {
            //Display the tile info
            displayInfoLabel.text = UIMessages.DisplayTileInfo(tile);
            return;
        }

        //Tile Component not found on tile tagged gameobject then show warning with name 
        Debug.LogWarning($"Tile component missing on {tileObj.name}");
    }

    //Called when ray hit on collider
    public void OnRaycastEnter(RaycastHit hit)
    {
        //Get Gameobject of collider
        var gameObj = hit.collider.gameObject;

        //check gameobject tag is tile if tile call 'DisplayTileInfo()'
        if (gameObj.CompareTag("Tile"))
            DisplayTileInfo(gameObj);
    }

    //Called when ray hit and stay on collider. Called every time based on 'DetectRaycast()' function call 
    //Implemented beacuse of 'IRayscatEvents' generic
    public void OnRaycastStay(RaycastHit hit)
    {

    }

    //Called when ray exits on collider
    public void OnRaycastExit(RaycastHit hit)
    {
        //Get Gameobject of collider
        var gameObj = hit.collider.gameObject;

        //check gameobject tag is tile if tile display tile no found in raycast
        if (gameObj.CompareTag("Tile"))
            displayInfoLabel.text = UIMessages.DefaulftTileInfo;

    }
}