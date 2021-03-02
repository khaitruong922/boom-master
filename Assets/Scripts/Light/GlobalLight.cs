using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class GlobalLight : MonoBehaviourSingleton<GlobalLight>
{
    public Light2D Light2D { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        Light2D = GetComponent<Light2D>();
    }
    public void TurnOff(float duration)
    {
        StartCoroutine(TurningOff(duration));
    }
    private IEnumerator TurningOff(float duration)
    {
        Light2D.enabled = false;
        yield return new WaitForSeconds(duration);
        Light2D.enabled = true;
    }
}
