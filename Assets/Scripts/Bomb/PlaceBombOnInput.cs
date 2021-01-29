using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BombPlacer))]
public class PlaceBombOnInput : MonoBehaviour
{
    [SerializeField] private KeyCode placeBombKey = KeyCode.Space;
    private BombPlacer bombPlacer;
    private void Awake()
    {
        bombPlacer = GetComponent<BombPlacer>();
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(placeBombKey))
        {
            bombPlacer.PlaceBomb();
        }
    }
}
