using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlacer : MonoBehaviour
{
    private static List<Vector3> bombPositions = new List<Vector3>();
    [SerializeField] private KeyCode placeBombKey = KeyCode.Space;
    [SerializeField] private GameObject bombPrefab;
    private void Update()
    {
        if (Input.GetKeyDown(placeBombKey))
        {
            PlaceBomb();
        }
    }
    private void PlaceBomb()
    {
        Vector3 cellCenterPos = transform.position.FloorToInt() + new Vector3(0.5f, 0.5f, 0);
        if (bombPositions.Contains(cellCenterPos)) return;
        bombPositions.Add(cellCenterPos);
        Bomb b = Instantiate(bombPrefab, cellCenterPos, Quaternion.identity).GetComponent<Bomb>();
        b.OnExploded += RemoveBombPosition;
    }
    private static void RemoveBombPosition(Vector3 pos)
    {
        bombPositions.Remove(pos);
    }
}
