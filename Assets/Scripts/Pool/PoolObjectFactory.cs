using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolObjectFactory : MonoBehaviour
{
    [SerializeField] private PoolObjectType type;
    public GameObject Get(Vector3 position)
    {
        return PoolManager.Instance.Get(type, position);
    }
    public GameObject Get(Vector3 position, Quaternion quaternion)
    {
        return PoolManager.Instance.Get(type, position, quaternion);
    }
    public void Spawn(Vector3 position)
    {
        PoolManager.Instance.Get(type, position);
    }
}
