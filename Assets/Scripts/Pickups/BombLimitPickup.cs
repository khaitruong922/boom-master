using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLimitPickup : MonoBehaviour, IPickup
{
    public void GrantEffect(Player player)
    {
        player.GetComponentInChildren<BombSpawner>().BombLimit++;
    }
}
