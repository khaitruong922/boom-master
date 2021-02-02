using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PoolObjectFactory))]
public class Bomb : PoolObject
{
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private UnityEvent<Vector3> onExploded;
    private float lifetime = 2f;
    private int length = 2;
    public float Damage { get; set; }
    public CharacterType CharacterType { get; set; }
    public BombSpawner BombSpawner { get; set; }
    public int Length { get => length; set => length = value; }
    public float Lifetime { get => lifetime; set => lifetime = value; }
    private PoolObjectFactory explosionFactory;
    private float timeElapsed = 0;
    private bool hasExploded = false;
    private Collider2D bombCollider;
    private void Awake()
    {
        explosionFactory = GetComponent<PoolObjectFactory>();
        bombCollider = GetComponent<Collider2D>();
    }
    private void OnEnable()
    {
        hasExploded = false;
        timeElapsed = 0;
    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > lifetime) Explode();
    }
    public void Explode()
    {
        if (hasExploded) return;
        hasExploded = true;
        SpawnExplosion(transform.position);
        CreateExplosions(Vector2.up);
        CreateExplosions(Vector2.down);
        CreateExplosions(Vector2.left);
        CreateExplosions(Vector2.right);
        onExploded?.Invoke(transform.position);
        BombSpawner.RemoveBombPosition(transform.position);
        DestroyBomb();
    }
    private void CreateExplosions(Vector3 direction)
    {
        for (int i = 1; i <= length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, i, wallLayerMask);
            Collider2D collider = hit.collider;
            Vector3 position = transform.position + (i * direction);
            bool collidedWithDestructible = false;
            if (collider)
            {
                if (collider.GetComponent<DestructibleTilemap>() != null) collidedWithDestructible = true;
                if (!collidedWithDestructible) break;
            }
            SpawnExplosion(position);
            if (collidedWithDestructible) break;
        }
    }
    private void SpawnExplosion(Vector3 position)
    {
        Explosion explosion = explosionFactory.Get(position).GetComponent<Explosion>();
        explosion.CharacterType = CharacterType;
        explosion.Damage = Damage;
    }
    private void DestroyBomb()
    {
        ReturnToPool();
    }
}
