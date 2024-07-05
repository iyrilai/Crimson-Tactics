using System.Collections.Generic;

[System.Serializable]
public class ListWrapper<T> where T : class
{
    public List<T> list;

    public List<T> List => list;

    public ListWrapper(List<T> list) 
    { 
        this.list = list;
    }
}