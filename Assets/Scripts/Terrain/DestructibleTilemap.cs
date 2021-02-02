using UnityEngine;
using UnityEngine.Tilemaps;
using System;

[RequireComponent(typeof(Tilemap))]
public class DestructibleTilemap : MonoBehaviour
{
    public static Action<Vector2> OnMapChanged { get; set; }
    private Tilemap tilemap;
    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }
    public void DestroyTile(Vector2 position)
    {
        Vector3Int pos = tilemap.WorldToCell(position);
        tilemap.SetTile(pos, null);
        OnMapChanged?.Invoke(position);
    }

}
