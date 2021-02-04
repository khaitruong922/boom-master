using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AnimationEndEvent : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private UnityEvent onAnimationEnd;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        StartCoroutine(InvokeAfterAnimationEnds());
    }
    private IEnumerator InvokeAfterAnimationEnds()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length - Time.deltaTime);
        onAnimationEnd?.Invoke();
    }
}



