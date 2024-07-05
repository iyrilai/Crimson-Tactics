using UnityEngine;
using UnityEngine.UIElements;

//This class stores UI components like lable and buttons
public class UIElements : MonoBehaviour
{
    //UI Document store ui elements
    [SerializeField] UIDocument document;

    //Label used to show tile infomation
    public Label DisplayTileInfo { get; private set; }

    //Calls when component enables
    private void OnEnable()
    {
        var root = document.rootVisualElement; //Get the root of ui document

        //Get Label (Text component) assign to 'DisplayTileInfo' for other script uses
        DisplayTileInfo = root.Q<Label>("DisplayTileInfo");
        DisplayTileInfo.text = UIMessages.DefaulftTileInfo; //Default text
    }
}
