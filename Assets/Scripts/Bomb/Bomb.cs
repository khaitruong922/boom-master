using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(lifetime);
        Explode();
    }
    private void Explode()
    {
        Destroy(gameObject);
        // spawn explosions
    }

}
