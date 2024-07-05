using UnityEngine;
using System.Collections;


public class Moveable : PathFinidingAI
{
    [SerializeField] float moveSpeed;

    protected Tile targetTile;
    protected Tile currentTile;

    public bool Moving { get; private set; }

    protected virtual IEnumerator MoveObjectOnGrid(Tile[] tiles)
    {
        Moving = true;

        for (int i = 0; i < tiles.Length; i++)
        {
            Debug.Log("moving?");
            float step = moveSpeed * Time.deltaTime;
            Vector3 targetPosition = new(tiles[i].GridPosition.x, transform.position.y, tiles[i].GridPosition.y);

            float sqrRemainingDistance = (transform.position - targetPosition).sqrMagnitude;

            while (sqrRemainingDistance > float.Epsilon)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
                sqrRemainingDistance = (transform.position - targetPosition).sqrMagnitude;
                yield return null;
            }

            currentTile = tiles[i];
        }

        Moving = false;
    }

    protected Tile SetPositionOnGrid(Vector2 pos)
    {
        var tile = LevelManager.GridData.FindTile(pos);
        transform.position = new(tile.GridPosition.x, transform.position.y, tile.GridPosition.y);
        return tile;
    }
}
