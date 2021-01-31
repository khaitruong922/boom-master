using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour
{
    [SerializeField] private float cooldown = 1;
    [SerializeField] private UnityEvent onTimer;
    private float cooldownLeft;
    private void Update()
    {
        if (cooldownLeft > 0)
        {
            cooldownLeft -= Time.deltaTime;
            return;
        }
        cooldownLeft += cooldown;
        onTimer?.Invoke();
    }
}
