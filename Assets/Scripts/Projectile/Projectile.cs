#pragma warning disable 0649

using UnityEngine;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 1;
    [SerializeField] private bool canPassThroughObject = false;
    [SerializeField] private UnityEvent<Collider2D> onTargetHit;
    [SerializeField] private UnityEvent<Vector3> onCollision;
    public float Damage { get; set; }
    public CharacterType CharacterType { get; set; }
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool toBeDestroyed = false;
        bool isCollided = false;
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            ICharacter hitCharacter = other.GetComponent<ICharacter>();
            if (hitCharacter.CharacterType != CharacterType)
            {
                health.TakeDamage(Damage);
                onTargetHit?.Invoke(other);
                isCollided = true;
                toBeDestroyed = true;
            }
        }
        if (other.GetComponent<IDestroyProjectile>() != null)
        {
            isCollided = true;
            toBeDestroyed = true;
        }
        DestructibleTilemap destructibleTilemap = other.GetComponent<DestructibleTilemap>();
        if (destructibleTilemap != null)
        {
            destructibleTilemap.DestroyTile(transform.position);
            isCollided = true;
        }
        if (isCollided) onCollision?.Invoke(transform.position);
        if (toBeDestroyed) HandleDestroy();
    }
    private void HandleDestroy()
    {
        if (canPassThroughObject) return;
        Destroy(gameObject);
    }
    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
