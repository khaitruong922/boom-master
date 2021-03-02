using UnityEngine;
using Vector2Extensions;
using Vector3Extensions;


[RequireComponent(typeof(BombSpawner))]
public class AIBombThrower : MonoBehaviour
{
    [SerializeField] private float throwSpeed = 20f;
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
    public void PlaceBomb(float randomOffset)
    {
        float x = Random.Range(-randomOffset, randomOffset);
        float y = Random.Range(-randomOffset, randomOffset);
        bombSpawner.PlaceBomb(new Vector3(x, y) + transform.position);
    }
    public void PlaceBomb()
    {
        PlaceBomb(0);
    }
    public void ThrowBombToTarget()
    {
        ThrowBombTo(targetTransform.position);
    }
    public void ThrowBombAroundTarget(float randomOffset)
    {
        float x = Random.Range(-randomOffset, randomOffset);
        float y = Random.Range(-randomOffset, randomOffset);
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
}
