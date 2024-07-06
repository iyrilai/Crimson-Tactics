using UnityEngine;

public class ComponentFinder
{
    public static T FindComponent<T>(string gameObjectName) where T : Component
    {
        var gameObject = GameObject.Find(gameObjectName);

        if (gameObject != null)
        {
            if (gameObject.TryGetComponent<T>(out var component))
            {
                return component;
            }

            var component2 = Object.FindObjectOfType<T>();
            if (component2 != null)
            {
                return component2;
            }
        }

        return null;
    }
}