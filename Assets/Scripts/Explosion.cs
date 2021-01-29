using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, IExecuteTimer
{
    public void ExecuteAfter(float duration = 0)
    {
        StartCoroutine(ReturnToPool(duration));
    }
    private IEnumerator ReturnToPool(float duration)
    {
        yield return new WaitForSeconds(duration);
        ExplosionPool.Instance.ReturnToPool(this);
    }
}

