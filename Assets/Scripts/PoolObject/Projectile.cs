#pragma warning disable 0649

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : PoolObject
{
    [SerializeField] private float lifetime = 1;
    [SerializeField] private UnityEvent<Collider2D> onTargetHit;
    [SerializeField] private UnityEvent<Vector3> onCollision;
    public float Damage { get; set; }
    public CharacterType CharacterType { get; set; }
    public ObjectPool ExplosionVFXPool { get; set; }
    private Rigidbody2D rb;
    private float timeElapsed = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        timeElapsed = 0;
    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > lifetime) DestroyProjectile();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool hasCollided = false;
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            ICharacter hitCharacter = other.GetComponent<ICharacter>();
            if (hitCharacter.CharacterType != CharacterType)
            {
                health.TakeDamage(Damage);
                hasCollided = true;
                onTargetHit?.Invoke(other);
                DestroyProjectile();
            }
        }
        DestructibleTilemap destructibleTilemap = other.GetComponent<DestructibleTilemap>();
        if (destructibleTilemap != null)
        {
            hasCollided = true;
            destructibleTilemap.DestroyTile(transform.position);
        }
        if (other.GetComponent<IDestroyProjectile>() != null)
        {
            hasCollided = true;
            DestroyProjectile();
        }
        if (hasCollided) onCollision?.Invoke(transform.position);
    }
    private void DestroyProjectile()
    {
        ExplosionVFXPool?.Spawn(transform.position);
        ReturnToPool();
    }
    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
