using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockActivator : MonoBehaviour
{
    private void Start()
    {
        Block.Instance?.gameObject?.SetActive(true);
    }
    public void DeactiveBlock()
    {
        Block.Instance?.gameObject?.SetActive(false);
    }
}
