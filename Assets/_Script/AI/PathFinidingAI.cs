using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Generate path list for object to travel in grid
public class PathFinidingAI : MonoBehaviour
{
    //Find Way with tile in grid position
    public Tile[] FindWay(Vector2 from, Vector2 to)
    {
        var startTile = LevelManager.GridData.FindTile(from);
        var endTile = LevelManager.GridData.FindTile(to);
        return FindWay(startTile, endTile);
    }

    //Find Way with two tile
    public Tile[] FindWay(Tile startTile, Tile endTile)
    {
        var visited = new Dictionary<Tile, Tile>
        {
            { startTile, null }
        };

        var frontier = new Queue<Tile>();
        frontier.Enqueue(startTile);

        while (frontier.Count > 0)
        {
            var current = frontier.Dequeue();

            if (current == endTile)
            {
                var path = GetPathToEnd(endTile, visited);
                var list = path.ToArray();
                return list;
            }

            var neighbors = current.NeighourTiles();
            foreach (var tile in neighbors)
            {
                if (!visited.ContainsKey(tile))
                {
                    frontier.Enqueue(tile);
                    visited.Add(tile, current);
                }
            }
        }

        Debug.LogError("Unable to find path");
        return null;
    }

    LinkedList<Tile> GetPathToEnd(Tile end, IDictionary<Tile, Tile> visitedTiles)
    {
        var path = new LinkedList<Tile>();

        var current = end;
        var previous = visitedTiles[current];

        while (previous != null)
        {
            path.AddFirst(current);

            current = previous;
            previous = visitedTiles[current];
        }

        path.AddFirst(current);

        return path;
    }
}


//Old attends
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