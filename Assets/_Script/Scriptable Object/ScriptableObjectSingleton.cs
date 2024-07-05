using UnityEditor;
using UnityEngine;

public class ScriptableObjectSingleton : ScriptableObject
{
    //Load the instance of scriptable object
    public static T LoadInstance<T>(string path) where T : ScriptableObjectSingleton
    {
        //if scriptable object exist get the instance of it
        T instance = AssetDatabase.LoadAssetAtPath<T>(path);

        //if scriptable object is null then create new one
        if (instance == null)
        {
            //create new scriptable object
            instance = CreateInstance<T>();

            //create asset and store it
            AssetDatabase.CreateAsset(instance, path);
            AssetDatabase.SaveAssets(); //write all assets to disk
        }

        //return instance of scriptable object
        return instance;
    }
}
