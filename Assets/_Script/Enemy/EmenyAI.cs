

public class EmenyAI : Moveable
{
    private void Update()
    {
        FindPlayerNearTile(LevelManager.Player);
    }

    protected void FindPlayerNearTile(Player player)
    {
        var playerTile = player.CurrentTile;
        var playerNearTile = playerTile.NeighourTiles()[0];

        if (currentTile != playerNearTile && !Moving)
        {
            var paths = FindWay(currentTile, playerNearTile);
            StartCoroutine(MoveObjectOnGrid(paths));
        }
    }
}
