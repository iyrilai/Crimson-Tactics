using UnityEngine;

public class UIMessages 
{
    const string defaulftTileInfo = "No tile Selected";

    public static string DefaulftTileInfo => defaulftTileInfo;

    public static string DisplayTileInfo(Tile tile)
    {
        return $"Grid Position: {tile.GridPosition.x}, {tile.GridPosition.y}\nID: {tile.ID}";
    }
}
