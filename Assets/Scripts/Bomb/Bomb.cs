using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private int length = 2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Explosion explosion = other.GetComponent<Explosion>();
        if (explosion != null) Explode();
    }
    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime > 0) return;
        Explode();
    }
    public void Explode()
    {
        MapDestroyer.Instance.Explode(transform.position, length);
        Destroy(gameObject);
    }

}
