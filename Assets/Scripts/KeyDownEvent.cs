using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyDownEvent : MonoBehaviour
{
    [SerializeField] private KeyCode activeKey;
    [SerializeField] private UnityEvent onKeyDown;
    private void Update()
    {
        if (Input.GetKeyDown(activeKey)) onKeyDown?.Invoke();
    }
}
