using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameObjectExtensions;
public enum PoolObjectType
{
    Bomb,
    BombThrow,
    Explosion,
    ExplosionVFX,
    FlameBullet
}
[System.Serializable]
public class Pool
{
    [SerializeField]
    private PoolObjectType type;

    public PoolObjectType Type => type;
    [SerializeField]
    private GameObject prefab;
    public GameObject Prefab => prefab;
    [SerializeField]
    private int initialCount;
    public int InitialCount => initialCount;
    public Queue<GameObject> Queue { get; set; }
}
public class PoolManager : MonoBehaviourSingleton<PoolManager>
{
    [SerializeField] private Pool[] pools;
    private Dictionary<PoolObjectType, Pool> poolDictionary;
    protected override void Awake()
    {
        base.Awake();
        poolDictionary = new Dictionary<PoolObjectType, Pool>();
        foreach (var pool in pools)
        {
            pool.Queue = new Queue<GameObject>();
            PoolObject poolObject = pool.Prefab.GetComponent<PoolObject>();
            if (poolObject == null)
            {
                poolObject = pool.Prefab.AddComponent<PoolObject>();
                Debug.Log("Adding PoolObject component to " + pool.Type);
            }
            poolObject.Type = pool.Type;
            poolDictionary[pool.Type] = pool;
            AddToPool(pool.Type, pool.InitialCount);
        }
    }
    public GameObject Get(PoolObjectType type, Vector3 position, Quaternion quaternion)
    {
        if (!poolDictionary.ContainsKey(type))
        {
            Debug.Log("Pool of type " + type + " does not exist");
            return null;
        }
        Queue<GameObject> queue = poolDictionary[type].Queue;
        if (queue.Count == 0)
        {
            AddToPool(type);
        }
        GameObject g = queue.Dequeue();
        g.transform.position = position;
        g.transform.rotation = quaternion;
        return g.Active();
    }
    public GameObject Get(PoolObjectType type, Vector3 position)
    {
        return Get(type, position, Quaternion.identity);
    }
    private void AddToPool(PoolObjectType type, int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject g = Instantiate(poolDictionary[type].Prefab, transform);
            g.SetActive(false);
            poolDictionary[type].Queue.Enqueue(g);
        }
    }
    public void ReturnToPool(PoolObjectType p, GameObject g)
    {
        g.SetActive(false);
        poolDictionary[p].Queue.Enqueue(g);
    }
}
