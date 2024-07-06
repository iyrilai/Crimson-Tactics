using UnityEngine;
using System.Collections;

//Basic movement for gameobject base on pathfining algorithm
public class Moveable : PathFindingAI
{
    //Object moving speed
    [SerializeField] float moveSpeed;

    //Starting position on grid
    [SerializeField] Vector2 startPositionOnGrid;

    protected Tile targetTile; //targetTile used if needed by child class
    protected Tile currentTile; //stores current tile where this object on it

    public Tile CurrentTile => currentTile;

    //boolean value to find object is moving
    public bool Moving { get; private set; }

    //Called on start of frame
    protected virtual void Start()
    {
        //Setting object position on tile
        currentTile = SetPositionOnGrid(startPositionOnGrid);
    }

    //Moving based on path found tiles using path finding algorithm
    protected virtual IEnumerator MoveObjectOnGrid(Tile[] tiles)
    {
        //Set movement on
        Moving = true;

        //Loops used to get each tile 
        foreach(var tile in tiles)
        {
            //Step to move on every call and 'Time.deltaTime' is used for frame independent
            float step = moveSpeed * Time.deltaTime;
            
            //Set target for position 
            Vector3 targetPosition = new(tile.transform.position.x, transform.position.y, tile.transform.position.z);

            //Calucate distance
            float sqrRemainingDistance = (transform.position - targetPosition).sqrMagnitude;

            //Loop until it reach minimun distance
            while (sqrRemainingDistance > float.Epsilon)
            {
                //MoveTowards used to move gameobject near to target
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
                //Calucate new distance
                sqrRemainingDistance = (transform.position - targetPosition).sqrMagnitude;
                yield return null;
            }

            //refer new tile
            currentTile = tile;
        }

        //Set movement off
        Moving = false;
    }

    //Set object position on grid by using grid position
    protected Tile SetPositionOnGrid(Vector2 gridPos)
    {
        //Get tile on that position
        var tile = LevelManager.GridData.GetTile(gridPos);

        //Set new position based on tile position
        transform.position = new(tile.transform.position.x, transform.position.y, tile.transform.position.z);
        return tile; //return tile for usage like setting 'currentTile'
    }
}
