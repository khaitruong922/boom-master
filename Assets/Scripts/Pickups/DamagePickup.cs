using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickup : MonoBehaviour, IPickup
{
    [SerializeField] private float damage = 5;
    public void GrantEffect(Player player)
    {
        player.GetComponentInChildren<BombSpawner>().Damage += damage;
    }
}
