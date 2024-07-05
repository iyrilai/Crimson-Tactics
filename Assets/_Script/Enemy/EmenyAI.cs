
//This Script detect the player and enemy towards player
public class EmenyAI : Moveable
{
    //Called every frame
    protected virtual void Update()
    {
        FindPlayerNearTile(LevelManager.Player);
    }

    //Find tile near player and move the enemy towards it
    protected virtual void FindPlayerNearTile(Player player)
    {
        var playerTile = player.CurrentTile; //Get player tile
        var playerNearTile = playerTile.NeighourTiles()[0]; //Find player nearest tile

        //when currentTile is not player near tile then it trigger movement towards player near tile
        if (currentTile != playerNearTile && !Moving)
        {
            //get path to travel
            var paths = FindWay(currentTile, playerNearTile);
            StartCoroutine(MoveObjectOnGrid(paths)); //trigger travel in grid
        }
    }
}
