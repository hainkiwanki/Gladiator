using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateMachineBehaviour : StateMachineBehaviour
{
    public string m_animationName;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(m_animationName, false);
        if (!animator.GetBool("attack1") && !animator.GetBool("attack2"))
        {
            EventManager.onAttackingFinished?.Invoke();
        }
    }
}
