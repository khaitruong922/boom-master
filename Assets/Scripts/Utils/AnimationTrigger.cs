using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationTrigger : MonoBehaviour
{
    private Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    public void SetTrigger(string param)
    {
        animator.SetTrigger(param);
    }
}
