using UnityEngine;

//Hold Componment and Datas of current level
public class LevelManager : MonoBehaviour
{
    [SerializeField] PrefabObjects prefabs;

    [Header("Components")]
    //References of important components
    [SerializeField] Camera _camera;
    [SerializeField] UIElements ui;
    [SerializeField] GridData gridData;

    //Component instances
    public static Camera Camera => Instance._camera;
    public static UIElements UI => Instance.ui;
    public static GridData GridData => Instance.gridData;
    public static PrefabObjects Prefabs => Instance.prefabs;
    
    //Instance of level manager
    public static LevelManager Instance { get; private set; }

    //Called on script initialization
    private void Awake()
    {
        //Assign instance of this script on initialization
        Instance = this;
    }
}
