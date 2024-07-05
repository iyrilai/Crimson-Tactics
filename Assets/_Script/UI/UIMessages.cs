
//class contains collection of ui messages
public class UIMessages 
{
    const string defaulftTileInfo = "No tile Selected"; //default tile info

    public static string DefaulftTileInfo => defaulftTileInfo;

    //To Display tile info
    public static string DisplayTileInfo(Tile tile)
    {
        return $"Grid Position: {tile.GridPosition.x}, {tile.GridPosition.y}\nID: {tile.ID}";
    }
}
