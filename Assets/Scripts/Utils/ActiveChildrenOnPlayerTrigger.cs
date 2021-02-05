using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChildrenOnPlayerTrigger : MonoBehaviour
{
    [SerializeField] private bool inactiveOnAwake = true;
    private void Awake()
    {
        if (inactiveOnAwake)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null) return;
        Destroy(GetComponent<Collider2D>());
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
