#pragma warning disable 0649
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject particlePrefab;
    [SerializeField]
    private float lifetime = 1f;
    [SerializeField]
    private Color color = Color.white;
    public void Spawn(Collider2D other)
    {
        ParticleSystem particleSystem = Instantiate(particlePrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            ParticleSystem.MainModule settings = particleSystem.main;
            settings.startColor = color;
            Destroy(particleSystem.gameObject, lifetime);
        }

    }
}