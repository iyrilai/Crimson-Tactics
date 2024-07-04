using UnityEngine;
using UnityEngine.UIElements;

public class UIElements : MonoBehaviour
{
    [SerializeField] UIDocument document;

    public Label DisplayTileInfo { get; private set; }


    private void OnEnable()
    {
        var root = document.rootVisualElement;

        DisplayTileInfo = root.Q<Label>("DisplayTileInfo");
        DisplayTileInfo.text = "No tile Selected";
    }
}
