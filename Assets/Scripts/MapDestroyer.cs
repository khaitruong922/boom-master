using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
public class MapDestroyer : MonoBehaviourSingleton<MapDestroyer>
{
    private Grid grid;
    [SerializeField] private ExplosionPool explosionPool;
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap wallTilemap;
    [SerializeField] private Tilemap colliderDecoratorTilemap;
    [SerializeField] private Tilemap destructibleTilemap;
    protected override void Awake()
    {
        base.Awake();
        grid = GetComponent<Grid>();
    }
    public void Explode(Vector2 worldPos, int length = 0)
    {
        Vector3Int cell = grid.WorldToCell(worldPos);
        ExplodeCell(cell);
        for (int i = 1; i <= length; i++)
        {
            if (!ExplodeCell(cell + new Vector3Int(i, 0, 0))) break;
        }
        for (int i = 1; i <= length; i++)
        {
            if (!ExplodeCell(cell + new Vector3Int(-i, 0, 0))) break;
        }
        for (int i = 1; i <= length; i++)
        {
            if (!ExplodeCell(cell + new Vector3Int(0, i, 0))) break;
        }
        for (int i = 1; i <= length; i++)
        {
            if (!ExplodeCell(cell + new Vector3Int(0, -i, 0))) break;
        }
    }
    private bool ExplodeCell(Vector3Int cell)
    {
        Tile wallTile = wallTilemap.GetTile<Tile>(cell);
        if (wallTile != null)
        {
            return false;
        }
        Tile colliderDecoratorTile = colliderDecoratorTilemap.GetTile<Tile>(cell);
        if (colliderDecoratorTile != null)
        {
            return false;
        }
        Tile destructibleTile = destructibleTilemap.GetTile<Tile>(cell);
        if (destructibleTile != null)
        {
            destructibleTilemap.SetTile(cell, null);
            return false;
        }
        Tile groundTile = groundTilemap.GetTile<Tile>(cell);
        Vector3 cellCenterPos = groundTilemap.GetCellCenterWorld(cell);
        Explosion explosion = explosionPool.Get();
        explosion.transform.position = cellCenterPos;
        explosion.gameObject.SetActive(true);
        return true;
    }

}
