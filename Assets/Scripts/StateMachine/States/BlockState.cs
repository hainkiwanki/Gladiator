using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : State
{
    public BlockState(PlayerController _player) : base(_player) { }

    private float m_guardWalkSpeed = 2.3f;
    private Vector2 m_inputDirection;

    public override void OnEnter(State _prvState)
    {
        m_playerController.SetGoalSpeed(m_guardWalkSpeed);
        m_playerAnimator.SetBool("blocking", true);
    }

    public override Type OnExecute()
    {
        m_playerController.RotateToMousePos();
        m_inputDirection = InputManager.InputDirection;

        if (InputManager.hasKicked)
            return typeof(KickState);
        if (!InputManager.isBlocking)
            return typeof(IdleState);
        if (InputManager.hasAttacked)
        {
            m_playerController.m_comboCount = 3;
            return typeof(AttackState);
        }
        if (InputManager.hasDodged)
            return typeof(DodgeState);

        var goalDir = (Vector3.right * m_inputDirection.x + Vector3.forward * m_inputDirection.y).normalized;
        m_playerController.SetGoalAnimationDirection(goalDir);
        m_playerController.Move();
        m_playerAnimator.SetDirection("dir", m_playerController.GetAnimationDirection());

        return null;
    }

    public override void OnExit()
    {
    }
}
