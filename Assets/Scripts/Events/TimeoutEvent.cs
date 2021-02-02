using UnityEngine;
using UnityEngine.Events;

public class TimeoutEvent : MonoBehaviour
{
    [SerializeField] private float cooldown = 1;
    [SerializeField] private UnityEvent onTimeout;
    private float cooldownLeft;
    private void OnEnable()
    {
        cooldownLeft = cooldown;
    }
    private void Update()
    {
        if (cooldownLeft > 0)
        {
            cooldownLeft -= Time.deltaTime;
            return;
        }
        onTimeout?.Invoke();
        Destroy(this);
    }
}
