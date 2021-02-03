using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSelfDestroy : MonoBehaviour
{
    [SerializeField] private float lifetime = 5f;
    private void Start() {
        Destroy(gameObject,lifetime);
    }
}
