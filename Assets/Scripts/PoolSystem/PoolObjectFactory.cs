using UnityEngine;

[System.Serializable]
public class PoolObjectFactory
{
    [SerializeField] private PoolObjectType type;
    public GameObject Get(Vector3 position, Quaternion quaternion)
    {
        return PoolManager.Instance.Get(type, position, quaternion);
    }
    public GameObject Get(Vector3 position)
    {
        return Get(position, Quaternion.identity);
    }
    public void Spawn(Vector3 position)
    {
        Get(position, Quaternion.identity);
    }
}
