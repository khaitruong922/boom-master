using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAttach : MonoBehaviour
{
    [Header("Optional")]
    [SerializeField] private Transform attachTransform;
    public Transform AttachTransform { get => attachTransform; set => attachTransform = value; }    
    private void LateUpdate() {
        if (attachTransform!=null) transform.position = attachTransform.position;
    }
}

