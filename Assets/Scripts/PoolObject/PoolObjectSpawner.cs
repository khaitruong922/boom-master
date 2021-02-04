using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectSpawner : MonoBehaviour
{
    [SerializeField] private PoolObjectFactory poolObjectFactory;
    public void Spawn()
    {
        poolObjectFactory.Spawn(transform.position);
    }
}
