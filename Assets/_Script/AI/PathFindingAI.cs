using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Generate path list for object to travel in grid
public class PathFindingAI : MonoBehaviour
{
    //Find Way with grid position
    public Tile[] FindWay(Vector2 from, Vector2 to)
    {
        var startTile = LevelManager.GridData.GetTile(from); //Get 'from' position tile
        var endTile = LevelManager.GridData.GetTile(to); //Get 'to' position tile
        
        //With Tile call 'FindWay(Tile,Tile)' return the value of it
        return FindWay(startTile, endTile);
    }

    //Find Way with two tile
    public Tile[] FindWay(Tile startTile, Tile endTile)
    {
        return GetConnection(startTile, endTile);
    }

    //get the connection between the tile and generate the path then returns it.
    Tile[] GetConnection(Tile startTile, Tile endTile)
    {
        if(startTile == null || endTile == null)
        {
            Debug.LogError($"{gameObject.name} its starting grid position is not found");
        }

        //Dictionary holds tile to tile path
        var connection = new Dictionary<Tile, Tile>
        {
            { startTile, null } //init with 'startTile'
        };

        //Queue Works with FIFO(First in First Out), so we store temporary values 
        var temp = new Queue<Tile>();
        temp.Enqueue(startTile); //init with 'startTile'

        //Loops unill queue is empty
        while (temp.Count > 0)
        {
            //Get current value from queue
            var current = temp.Dequeue();

            //when we reach the goal it end the loop and Get path
            if (current == endTile)
            {
                //It convert node to node connection and find the path by going in reverse
                var path = GetPathToEnd(endTile, connection);
                var list = path.ToArray(); //Convert to array
                return list; //return array
            }

            //Get neighout tile without obstacle
            var neighbors = current.NeighourTiles();

            //Loop all the neighbours
            foreach (var tile in neighbors)
            {
                //Store the tile in Dictionary if already not exist
                if (!connection.ContainsKey(tile))
                {
                    temp.Enqueue(tile); //add to queue to used as next component
                    connection.Add(tile, current); //add to dictionary to connection between tiles
                }
            }
        }

        //if unable find path throw error on console and return null
        Debug.LogError("Unable to find path");
        return null;
    }

    //It convert node to node connection and find the path by going in reverse
    LinkedList<Tile> GetPathToEnd(Tile end, Dictionary<Tile, Tile> connectedTiles)
    {
        //LinkedList stores path in order
        //Linkedlist used here because we can store path from start and also from end
        //Where in List it is not efficient and increase line of code   
        var path = new LinkedList<Tile>();

        //current loaded with end
        var current = end;

        //previous loaded with dictionary 'current' one of connected tile 
        var previous = connectedTiles[current];

        //loop until previous is null
        //loop going till dictionary initialized value 'null' on line 24 - { startTile, null } //init with 'startTile'
        while (previous != null)
        {
            //Add 'current' to path
            path.AddFirst(current);

            //change current to previous
            current = previous;

            //Get new previous with current value
            previous = connectedTiles[current];
        }

        //Add home tile to path
        path.AddFirst(current);

        return path; // return the path
    }
}


//Old try
/*List<Tile> FindWay(Vector2 from, Vector2 to, GridData data)
    {
        List<Tile> path = new();
        List<Tile> temp = new();

        var startTile = data.FindTile(from);
        Vector2 current = from;

        Vector2 diff = to - current;
        Vector2 simplfy = diff / diff;


        while (diff.x > 0)
        {
            diff = to - current;

            if (CheckAvaible(new(simplfy.x, 0), current, data, temp, out current))
                continue;

            if (CheckAvaible(Vector2.up, current, data, temp, out current))
                continue;

            if (CheckAvaible(Vector2.down, current, data, temp, out current))
                continue;

            temp.Clear();
            current = from;
            break;
        }


        while (diff.y > 0)
        {
            diff = to - current;

            if (CheckAvaible(new(0, simplfy.y), current, data, temp, out current))
                continue;

            if (CheckAvaible(Vector2.left, current, data, temp, out current))
                continue;

            if (CheckAvaible(Vector2.right, current, data, temp, out current))
                continue;

            temp.Clear();
            current = from;
            break;
        }

        while (current == to)
        {
            if (CheckAvaible(Vector2.up, current, data, temp, out current))
                continue;

            if (CheckAvaible(Vector2.left, current, data, temp, out current))
                continue;

            if (CheckAvaible(Vector2.down, current, data, temp, out current))
                continue;

            if (CheckAvaible(Vector2.right, current, data, temp, out current))
                continue;
        }


        return path;
    }

    bool CheckAvaible(Vector2 increment, Vector2 current, GridData data, List<Tile> temp, out Vector2 outCurrent)
    {
        outCurrent = current;
        current += increment;
        var currentTile = data.FindTile(current);

        if (currentTile != null && currentTile.Obstacle == null)
        {
            temp.Add(currentTile);
            outCurrent = current;
            return true;
        }

        return false;
    }*/

/*List<Tile> FindWay(Vector2 from, Vector2 to, GridData data)
  {
      var startTile = data.FindTile(from);
      var endTile = data.FindTile(to);

      List<Tile> OpenList = new();
      List<Tile> CloseList = new();

      OpenList.Add(startTile);

      while(OpenList.Count > 0) 
      {
          var currentTile = OpenList[0];

          if(!CloseList.Contains(currentTile))
              CloseList.Add(currentTile);

          OpenList.InsertRange(0, currentTile.NeighourTiles());
          OpenList.Remove(currentTile);

          if (currentTile == endTile)
          {
              return CloseList;
          }

      }

      return CloseList;
  }*/