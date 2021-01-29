using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class DestructibleTilemap : MonoBehaviour
{
    private Tilemap tilemap;
    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }
    public void DestroyTile(Vector2 position)
    {
        Vector3Int pos = tilemap.WorldToCell(position);
        tilemap.SetTile(pos, null);
    }

}
