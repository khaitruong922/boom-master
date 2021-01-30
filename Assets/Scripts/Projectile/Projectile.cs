#pragma warning disable 0649

using UnityEngine;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage = 1;
    [SerializeField] private float lifetime = 1f;
    [SerializeField] private bool canPassThroughObject = false;
    [SerializeField] private UnityEvent onHit;
    private Rigidbody2D rb;
    private CharacterType ownerType;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    public void Init(Vector2 velocity, CharacterType characterType)
    {
        this.ownerType = characterType;
        SetVelocity(velocity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool toBeDestroyed = false;

        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            ICharacter hitCharacter = other.GetComponent<ICharacter>();
            if (hitCharacter.CharacterType != ownerType)
            {
                health.TakeDamage(damage);
                onHit?.Invoke();
                toBeDestroyed = true;
            }
        }
        if (other.GetComponent<IDestroyProjectile>() != null)
        {
            onHit?.Invoke();
            toBeDestroyed = true;
        }
        if (toBeDestroyed)
        {
            HandleCollision();
        }
    }
    private void HandleCollision()
    {
        if (!canPassThroughObject)
        {
            Destroy(gameObject);
        }
    }
    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
