using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;
    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime > 0) return;
        Explode();
    }
    public void Explode()
    {
        Destroy(gameObject);
        // spawn explosions
    }

}
