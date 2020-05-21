using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(PlayerController _player) : base(_player) { }

    public override void OnEnter()
    {
        m_playerController.SetGoalSpeed(0.0f);
        m_playerController.SetGoalAnimationDirection(Vector3.zero);
        m_playerAnimator.SetBool("blocking", false);
    }

    public override Type OnExecute()
    {
        if (InputManager.HasDodged)
            return typeof(DodgeState);
        if (m_playerController.m_isBlocking)
            return typeof(BlockState);
        if (m_playerController.m_hasAttacked)
            return typeof(AttackState);
        if (InputManager.InputDirection != Vector2.zero)
            return typeof(WalkState);
        if (m_playerController.m_hasKicked)
            return typeof(KickState);
        m_playerController.RotateToMousePos();
        m_playerAnimator.SetDirection("dir", m_playerController.GetAnimationDirection());
        return typeof(IdleState);
    }

    public override void OnExit(){}
}
