using System.Collections.Generic;
using UnityEngine; 

[System.Serializable]
//This class used to serialize nested List
public class ListWrapper<T> where T : class
{
    [SerializeField] List<T> list;

    public List<T> List => list;

    //Constructor to init list
    public ListWrapper(List<T> list) 
    { 
        this.list = list;
    }
}