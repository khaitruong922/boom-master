using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public PoolObjectType Type { get; set; }
    public void ReturnToPool()
    {
        PoolManager.Instance.ReturnToPool(Type, gameObject);
    }
}
