using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootComponent))]
public class AIShooter : MonoBehaviour
{
    [SerializeField] private float cooldown = 1f;
    private ShootComponent shootComponent;
    private Transform targetTransform;
    private float cooldownLeft = 0f;
    private void Awake()
    {
        shootComponent = GetComponent<ShootComponent>();
    }
    private void Start()
    {
        targetTransform = Player.Instance.transform;
    }
    private void Update()
    {
        if (cooldownLeft >= 0)
        {
            cooldownLeft -= Time.deltaTime;
            return;
        }
        cooldownLeft += cooldown;
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        shootComponent.Shoot(direction);
    }

}
