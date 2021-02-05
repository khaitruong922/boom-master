using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPickup
{
    void GrantEffect(Player player);
}
public class Pickup : MonoBehaviour
{
    [SerializeField] private UnityEvent<Player> onPickup;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            onPickup?.Invoke(player);
            Destroy(gameObject);
        }
    }
}
