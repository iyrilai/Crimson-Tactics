using UnityEngine;

//Holds all tile information
public class Tile : MonoBehaviour
{
    [SerializeField] int id; //stores tile id

    //Get and set ID
    public int ID { get => id; set => id = value; }

    //Returns grid position on local x and z value
    public Vector2 GridPosition
    {
        get
        {
            return new(transform.localPosition.x, transform.localPosition.z);
        }
    }
}
