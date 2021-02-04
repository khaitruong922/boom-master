using UnityEngine;
using Vector2Extensions;
using Vector3Extensions;


[RequireComponent(typeof(BombSpawner))]
public class AIBombThrower : MonoBehaviour
{
    [SerializeField] private float throwSpeed = 20f;
    [SerializeField] private float radiusAroundTarget = 2f;
    private Transform targetTransform;
    private BombSpawner bombSpawner;
    private void Awake()
    {
        bombSpawner = GetComponent<BombSpawner>();
    }
    private void Start()
    {
        targetTransform = Player.Instance.transform;
    }
    public void ThrowBombTo(Vector3 position)
    {
        bombSpawner.ThrowBomb(position, throwSpeed);
    }
    public void ThrowBombToTarget()
    {
        ThrowBombTo(targetTransform.position);
    }
    public void ThrowBombAroundTarget()
    {
        float x = RandomOffset;
        float y = RandomOffset;
        ThrowBombTo(targetTransform.position + new Vector3(x, y));
    }
    public void ThrowBombsInArc(int bombCountPerSide)
    {
        Vector2 diff = targetTransform.position - transform.position;
        Vector2 diffRight = diff.Rotate(90).normalized;
        for (int i = -bombCountPerSide; i <= bombCountPerSide; i++)
        {
            ThrowBombTo(((Vector2)targetTransform.position + diffRight * i).Extend(2));
        }
    }
    private float RandomOffset => Random.Range(-radiusAroundTarget, radiusAroundTarget);
}
