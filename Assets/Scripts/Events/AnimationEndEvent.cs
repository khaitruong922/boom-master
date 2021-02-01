using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AnimationEndEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onAnimationEnd;
    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        onAnimationEnd?.Invoke();
    }
}



