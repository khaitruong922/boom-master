using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : PoolObject
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingOrder = 100;
    }
}
