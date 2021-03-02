using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleAbility : MonoBehaviour
{
    [SerializeField] private float duration = 4f;
    [SerializeField] private GameObject[] invisibleObjects;
    public void Invisible()
    {
        StartCoroutine(GoInvisible());
    }

    private IEnumerator GoInvisible()
    {
        foreach (var g in invisibleObjects)
        {
            g.SetActive(false);
        }
        yield return new WaitForSeconds(duration);
        foreach (var g in invisibleObjects)
        {
            g.SetActive(true);
        }
    }
}
