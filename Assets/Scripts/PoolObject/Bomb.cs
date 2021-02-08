using UnityEngine;
using UnityEngine.Events;

public class Bomb : PoolObject
{
    private enum BombType
    {
        _4D,
        _8D
    }
    [SerializeField] private BombType bombType = BombType._4D;
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private UnityEvent<Vector3> onExploded;
    private float lifetime = 2f;
    private int length = 2;
    public float Damage { get; set; }
    public CharacterType CharacterType { get; set; }
    public BombSpawner BombSpawner { get; set; }
    public int Length { get => length; set => length = value; }
    public float Lifetime { get => lifetime; set => lifetime = value; }
    public PoolObjectFactory ExplosionFactory { get; set; }
    private float timeElapsed = 0;
    private bool hasExploded = false;
    private static Vector2 upLeft = new Vector2(-1, 1);
    private static Vector2 upRight = new Vector2(1, 1);
    private static Vector2 downLeft = new Vector2(-1, -1);
    private static Vector2 downRight = new Vector2(1, -1);
    private Collider2D bombCollider;
    private void Awake()
    {
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
        if (bombType == BombType._8D)
        {
            CreateExplosions(upLeft);
            CreateExplosions(upRight);
            CreateExplosions(downLeft);
            CreateExplosions(downRight);
        }
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
        Explosion explosion = ExplosionFactory.Get(position).GetComponent<Explosion>();
        explosion.CharacterType = CharacterType;
        explosion.Damage = Damage;
    }
    private void DestroyBomb()
    {
        ReturnToPool();
    }
}
