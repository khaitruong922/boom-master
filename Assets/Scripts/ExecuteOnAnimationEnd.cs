using UnityEngine;
using System.Collections;
public class ExecuteOnAnimationEnd : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        IExecuteTimer executeTimer = animator.GetComponent<IExecuteTimer>();
        executeTimer?.ExecuteAfter(stateInfo.length);
    }
}
