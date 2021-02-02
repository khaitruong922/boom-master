using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootComponent))]
public class AIShooter : MonoBehaviour
{
    private ShootComponent shootComponent;
    private Transform targetTransform;

    private void Awake()
    {
        shootComponent = GetComponent<ShootComponent>();
    }
    private void Start()
    {
        targetTransform = Player.Instance.transform;
    }
    public void Shoot()
    {
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        shootComponent.Shoot(direction);
    }
}
