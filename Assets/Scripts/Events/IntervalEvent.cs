using UnityEngine;
using UnityEngine.Events;

public class IntervalEvent : MonoBehaviour
{
    [SerializeField] private float cooldown = 1;
    [SerializeField] private float initialCooldown = 0;
    [SerializeField] private UnityEvent onInterval;
    private float cooldownLeft;
    private void OnEnable()
    {
        cooldownLeft = initialCooldown;
    }
    private void Update()
    {
        if (cooldownLeft > 0)
        {
            cooldownLeft -= Time.deltaTime;
            return;
        }
        cooldownLeft += cooldown;
        onInterval?.Invoke();
    }
}
