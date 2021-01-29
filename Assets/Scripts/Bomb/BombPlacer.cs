using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlacer : MonoBehaviour
{
    private List<Vector3> bombPositions = new List<Vector3>();
    [SerializeField] private GameObject bombPrefab;

    public void PlaceBomb(Vector3 position)
    {
        Vector3 cellCenterPos = WorldToBombPosition(position);
        if (bombPositions.Contains(cellCenterPos)) return;
        bombPositions.Add(cellCenterPos);
        Bomb b = Instantiate(bombPrefab, cellCenterPos, Quaternion.identity).GetComponent<Bomb>();
        b.OnExploded += RemoveBombPosition;
    }
    public void PlaceBomb()
    {
        PlaceBomb(transform.position);
    }
    private void RemoveBombPosition(Vector3 pos)
    {
        bombPositions.Remove(pos);
    }
    public static Vector3 WorldToBombPosition(Vector3 origin)
    {
        return origin.FloorToInt() + new Vector3(0.5f, 0.5f, 0);
    }
}
