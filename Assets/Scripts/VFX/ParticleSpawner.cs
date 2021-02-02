#pragma warning disable 0649
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject particlePrefab;
    [SerializeField]
    private float lifetime = 1f;
    [SerializeField]
    private Color color = Color.white;
    public void Spawn(Vector3 position)
    {
        ParticleSystem particleSystem = Instantiate(particlePrefab, position, Quaternion.identity).GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            ParticleSystem.MainModule settings = particleSystem.main;
            settings.startColor = color;
            Destroy(particleSystem.gameObject, lifetime);
        }
    }
    public void Spawn()
    {
        Spawn(transform.position);
    }
}