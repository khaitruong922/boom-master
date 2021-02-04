using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public PoolObjectType Type { get; set; }
    protected PoolManager poolManager;
    protected virtual void Start()
    {
        poolManager = PoolManager.Instance;
    }
    public void ReturnToPool()
    {
        poolManager.ReturnToPool(Type, gameObject);
    }
}