using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Prefabs", menuName = "Scriptable Objects/PrefabObjects", order = 1)]
public class PrefabObjects : ScriptableObjectSingleton
{
    [SerializeField] GameObject basicTile;
    [SerializeField] GameObject sphere;

    private const string PrefabObjectFilePath = "Assets/Scriptable Objects/Prefabs.asset";

    public GameObject BasicTile => basicTile;
    public GameObject Sphere => sphere;

    [InitializeOnLoadMethod]
    //Load the instance of scriptable object
    public static PrefabObjects LoadInstance()
    {
        return LoadInstance<PrefabObjects>(PrefabObjectFilePath);
    }
}