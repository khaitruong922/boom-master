using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    [SerializeField] private float duration = 4f;
    [SerializeField] private GameObject[] visibleObjects;
    public void Active()
    {
        StartCoroutine(GoInvisible());
    }

    private IEnumerator GoInvisible()
    {
        foreach (var v in visibleObjects)
        {
            v.SetActive(false);
        }
        yield return new WaitForSeconds(duration);
        foreach (var v in visibleObjects)
        {
            v.SetActive(true);
        }
    }
}
