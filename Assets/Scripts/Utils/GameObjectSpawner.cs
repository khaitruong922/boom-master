using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public GameObject Get()
    {
        return Instantiate(prefab, transform.position, Quaternion.identity);
    }
    public void Spawn()
    {
        Get();
    }
}
