using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour, IPickup
{
    [SerializeField] private float healAmount = 20;
    public void GrantEffect(Player player)
    {
        player.GetComponent<Health>().Heal(healAmount);
    }
}
