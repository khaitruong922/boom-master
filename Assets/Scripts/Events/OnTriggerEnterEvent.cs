using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onTriggerEnter;
    private void OnTriggerEnter2D(Collider2D other) {
        onTriggerEnter?.Invoke();
    }
}
