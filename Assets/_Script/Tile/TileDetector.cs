using UnityEngine.UIElements;
using UnityEngine;

public class TileDetector : RaycastDetector, IRayscatEvents
{
    readonly Label displayInfoLabel;

    public TileDetector(Label displayInfoLabel)
    {
        this.displayInfoLabel = displayInfoLabel;
    }

    public void DetectRaycast(Ray ray, float maxDistance)
    {
        DetectRaycast(ray, maxDistance, this);
    }

    void DisplayTileInfo(GameObject tileObj)
    {
        if (tileObj.TryGetComponent<Tile>(out var tile))
        {
            displayInfoLabel.text = UIMessages.DisplayTileInfo(tile);
            return;
        }

        Debug.LogWarning($"Tile component missing on {tileObj.name}");
    }

    public void OnRaycastEnter(RaycastHit hit)
    {
        var gameObj = hit.collider.gameObject;

        if (gameObj.CompareTag("Tile"))
            DisplayTileInfo(gameObj);
    }

    public void OnRaycastStay(RaycastHit hit)
    {

    }

    public void OnRaycastExit(RaycastHit hit)
    {
        var gameObj = hit.collider.gameObject;

        if (gameObj.CompareTag("Tile"))
            displayInfoLabel.text = UIMessages.DefaulftTileInfo;

    }
}