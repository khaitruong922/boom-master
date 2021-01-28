using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlacer : MonoBehaviour
{
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
        Instantiate(bombPrefab, transform.position.RoundToInt(), Quaternion.identity);
    }
}
