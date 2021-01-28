using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlacer : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private KeyCode placeBombKey = KeyCode.Space;
    [SerializeField] private GameObject bombPrefab;
    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(placeBombKey))
        {
            PlaceBomb();
        }
    }
    private void PlaceBomb()
    {
        Vector3Int cellPos = grid.WorldToCell(transform.position);
        Vector3 cellCenterPos = grid.GetCellCenterWorld(cellPos);
        Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
    }
}
