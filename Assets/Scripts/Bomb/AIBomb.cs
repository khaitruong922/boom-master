using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BombPlacer))]
public class AIBomb : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    private BombPlacer bombPlacer;
    private void Awake()
    {
        bombPlacer = GetComponent<BombPlacer>();
    }
    public void PlaceBomb()
    {
        float x = Random.Range(-radius, radius);
        float y = Random.Range(-radius, radius);
        bombPlacer.PlaceBomb(new Vector3(x, y) + transform.position);
    }
}
