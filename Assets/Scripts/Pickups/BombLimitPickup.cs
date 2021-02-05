using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLimitPickup : MonoBehaviour, IPickup
{
    public void GrantEffect(Player player)
    {
        BombSpawner bombSpawner = player.GetComponentInChildren<BombSpawner>();
        if (bombSpawner != null) bombSpawner.BombLimit++;
    }
}
