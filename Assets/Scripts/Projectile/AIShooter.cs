using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooter : MonoBehaviour
{
    [SerializeField] private ShootComponent shootComponent;
    [SerializeField] private float cooldown = 1f;
    private Transform playerTransform;
    private float cooldownLeft = 0f;
    private void Start()
    {
        playerTransform = Player.Instance.transform;
    }
    private void Update()
    {
        if (cooldownLeft >= 0)
        {
            cooldownLeft -= Time.deltaTime;
            return;
        }
        cooldownLeft += cooldown;
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        shootComponent.Shoot(direction);
    }
   
}
