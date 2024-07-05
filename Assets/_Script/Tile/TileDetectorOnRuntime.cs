using UnityEngine;

//Display tile infomation on in-game UI
public class TileDetectorOnRuntime : MonoBehaviour
{
    [SerializeField] float maxDistance; //max distance of mouse pointer raycast

    //tileDetector instances to diaplay infomation
    TileDetector tileDetector;

    private void Start()
    {
        //create new instance of 'tileDetector' and inti with 'UI.DisplayTileInfo' label
        tileDetector = new(LevelManager.UI.DisplayTileInfo);
        tileDetector.OnRaycastEnterCallback += Test;
    }

    // Update is called once per frame
    void Update()
    {
        //Raycast of mouse pointer in game
        Ray ray = LevelManager.Camera.ScreenPointToRay(Input.mousePosition);

        //Call 'DetectRaycast' to get hit of raycast and display the information 
        tileDetector.DetectRaycast(ray, maxDistance);
    } 

    void Test()
    {

    }
}