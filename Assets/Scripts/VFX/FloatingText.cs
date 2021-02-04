using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : PoolObject
{
    private MeshRenderer meshRenderer;
    [SerializeField] private float randomOffset = 1f;
    private Vector2 fixedOffset = new Vector2(0f, 1f);
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingOrder = 100;
    }
    private void OnEnable()
    {
        Vector3 offset = (Vector3)fixedOffset + new Vector3(RandomOffset, RandomOffset);
        transform.position += offset;
    }
    private float RandomOffset => Random.Range(-randomOffset, randomOffset);
}
