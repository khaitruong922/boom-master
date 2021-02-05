using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private PickupFactory pickupFactory;
    public void Spawn()
    {
        GameObject pickup = pickupFactory.GetRandomPickup();
        if (pickup == null) return;
        Instantiate(pickup, transform.position, Quaternion.identity);
    }
}
