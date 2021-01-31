using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BombSpawner))]
public class AIBombPlacer : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    private BombSpawner bombSpawner;
    private void Awake()
    {
        bombSpawner = GetComponent<BombSpawner>();
    }
    public void PlaceBomb()
    {
        float x = Random.Range(-radius, radius);
        float y = Random.Range(-radius, radius);
        bombSpawner.PlaceBomb(new Vector3(x, y) + transform.position);
    }
}
