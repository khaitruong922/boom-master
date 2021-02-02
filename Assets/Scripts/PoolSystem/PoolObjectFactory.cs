using UnityEngine;

[System.Serializable]
public class PoolObjectFactory : MonoBehaviour
{
    [SerializeField] private PoolObjectType type;
    private PoolManager poolManager;
    private void Start()
    {
        poolManager = PoolManager.Instance;
    }
    public GameObject Get(Vector3 position)
    {
        return poolManager.Get(type, position);
    }
    public GameObject Get(Vector3 position, Quaternion quaternion)
    {
        return poolManager.Get(type, position, quaternion);
    }
    public void Spawn(Vector3 position)
    {
        poolManager.Get(type, position);
    }
}
