using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3Extensions;

public class BombPlacer : MonoBehaviour
{
    private List<Vector3> bombPositions = new List<Vector3>();
    [SerializeField] private GameObject bombPrefab;

    public void PlaceBomb(Vector3 position)
    {
        Vector3 cellCenterPos = position.ToCellCenter();
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
}
