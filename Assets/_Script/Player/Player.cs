using UnityEngine;

public class Player : Moveable, IRayscatEvents
{   
    readonly RaycastDetector detector = new();

    void Update()
    {
        Ray ray = LevelManager.Camera.ScreenPointToRay(Input.mousePosition);
        detector.DetectRaycast(ray, 200, this);

        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        }
    }

    private void MouseDown()
    {
        if (targetTile != null && !Moving) 
        {
            if (targetTile.Obstacle != null) return;

            var paths = FindWay(currentTile, targetTile);
            StartCoroutine(MoveObjectOnGrid(paths));
        }
    }

    public void OnRaycastEnter(RaycastHit hit)
    {
        var gameObj = hit.collider.gameObject;

        if (gameObj.CompareTag("Tile"))
            targetTile = gameObj.GetComponent<Tile>();
    }

    public void OnRaycastStay(RaycastHit hit)
    {
        return;
    }

    public void OnRaycastExit(RaycastHit hit)
    {
        var gameObj = hit.collider.gameObject;

        if (gameObj.CompareTag("Tile"))
            targetTile = null;
    }
}
