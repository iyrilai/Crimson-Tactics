using UnityEngine;

//Player script is used to move the player in grid using 'Moveable' class functions
public class Player : Moveable, IRayscatEvents
{   
    //detector and callback for raycast events
    readonly RaycastDetector detector = new();

    //Called every frame
    protected virtual void Update()
    {
        //Raycast of mouse pointer in game
        Ray ray = LevelManager.Camera.ScreenPointToRay(Input.mousePosition);
        
        //Call 'DetectRaycast' to get hit of raycast and get the tile to make player to move on it
        detector.DetectRaycast(ray, 200, this);

        //Call 'MouseDown' method when mouse left click
        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        }
    }

    //This functions is called when mouse clikced
    private void MouseDown()
    {
        //if there is new targetTile and player not moving the call 'Moveable' class function to move player towards target tile
        if (targetTile != null && !Moving) 
        {
            if (targetTile.Obstacle != null) return;
            
            //get path to travel
            var paths = FindWay(currentTile, targetTile);
            StartCoroutine(MoveObjectOnGrid(paths)); //trigger travel in grid
        }
    }

    //Called when ray hit on collider
    public void OnRaycastEnter(RaycastHit hit)
    {
        //Get Gameobject of collider
        var gameObj = hit.collider.gameObject;

        //check gameobject tag is tile
        //if tag is tag then targetTile as 'gameObj' tile
        if (gameObj.CompareTag("Tile"))
            targetTile = gameObj.GetComponent<Tile>();
    }

    //Called when ray hit and stay on collider. Called every time based on 'DetectRaycast()' function call 
    //Implemented beacuse of 'IRayscatEvents' generic
    public void OnRaycastStay(RaycastHit hit)
    {
        return;
    }

    //Called when ray exits on collider
    public void OnRaycastExit(RaycastHit hit)
    {
        //Get Gameobject of collider
        var gameObj = hit.collider.gameObject;

        //check gameobject tag is tile
        //if tag is tag then targetTile null
        if (gameObj.CompareTag("Tile"))
            targetTile = null;
    }
}
