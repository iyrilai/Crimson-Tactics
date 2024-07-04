using UnityEngine;

public class Tile : MonoBehaviour
{
    public int ID { get; set; }

    public Vector2 GridPosition 
    { 
        get
        {
            return new(transform.localPosition.x, transform.localPosition.z);
        }
    }
}
