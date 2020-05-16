using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBoolReset : StateMachineBehaviour
{
    [SerializeField]
    private EBehaviourState m_state = EBehaviourState.EXIT;
    [SerializeField]
    private string[] m_boolName;
    [SerializeField]
    private bool m_valueToSet = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_state == EBehaviourState.ENTER)
            foreach(string b in m_boolName)
                animator.SetBool(b, m_valueToSet);
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_state == EBehaviourState.EXIT)
            foreach (string b in m_boolName)
                animator.SetBool(b, m_valueToSet);
        base.OnStateExit(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_state == EBehaviourState.EXECUTE)
            foreach (string b in m_boolName)
                animator.SetBool(b, m_valueToSet);
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }
}
