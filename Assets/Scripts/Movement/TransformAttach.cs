using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAttach : MonoBehaviour
{
    [Header("Optional")]
    [SerializeField] private Transform attachTransform;
    [SerializeField] private float randomOffset = 1f;
    [SerializeField] private Vector2 fixedOffset = new Vector2(0f, 1f);
    public Transform AttachTransform { get => attachTransform; set => attachTransform = value; }
    private Vector3 offset;
    private void OnEnable()
    {
        offset = (Vector3)fixedOffset + new Vector3(RandomOffset, RandomOffset);
    }
    private void LateUpdate()
    {
        if (attachTransform != null) transform.position = attachTransform.position + offset;
    }
    private float RandomOffset => Random.Range(-randomOffset, randomOffset);
}

