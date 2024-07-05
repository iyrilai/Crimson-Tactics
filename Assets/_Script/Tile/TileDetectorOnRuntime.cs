using UnityEngine;

public class TileDetectorOnRuntime : MonoBehaviour
{
    [SerializeField] float maxDistance; //max distance of mouse pointer raycast

    TileDetector tileDetector;

    private void Start()
    {
        tileDetector = new(LevelManager.UI.DisplayTileInfo);
    }

    // Update is called once per frame
    void Update()
    {
        //Raycast of mouse pointer
        Ray ray = LevelManager.Camera.ScreenPointToRay(Input.mousePosition);
        tileDetector.DetectRaycast(ray, maxDistance);
    } 
}