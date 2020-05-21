using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(PlayerController _player) : base(_player) { }

    public override void OnEnter()
    {
        m_playerController.SetGoalAnimationDirection(Vector3.zero);
        m_playerController.SetGoalSpeed(0.0f, true);
        m_playerAnimator.SetBool("attack1", true);
        m_playerAnimator.SetDirection("dir", Vector3.zero);
    }

    public override System.Type OnExecute()
    {
        bool attack1 = m_playerAnimator.GetBool("attack1");
        if(m_playerController.m_hasAttacked && attack1 && InputManager.AmountOfClicks >= 2)
        {
            m_playerAnimator.SetBool("attack2", true);
        }
        bool attack2 = m_playerAnimator.GetBool("attack2");
        if (InputManager.HasDodged)
            return typeof(DodgeState);
        if (!attack1 && !attack2)
            return typeof(IdleState);

        return typeof(AttackState);
    }

    public override void OnExit()
    {
    
    }
}