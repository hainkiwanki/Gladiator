﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public WalkState(PlayerController _player) : base(_player) { }

    private float m_walkSpeed = 2.8f;
    private Vector2 m_inputDirection;

    public override void OnEnter(State _prvState)
    {
        m_playerController.SetGoalSpeed(m_walkSpeed);
    }

    public override System.Type OnExecute()
    {
        m_playerController.RotateToMousePos();
        m_inputDirection = InputManager.InputDirection;

        if (InputManager.hasDodged)
            return typeof(DodgeState);
        if (InputManager.isBlocking)
            return typeof(BlockState);
        if (InputManager.hasAttacked)
        {
            m_playerController.m_comboCount = 4;
            return typeof(AttackState);
        }
        if (m_inputDirection == Vector2.zero)
            return typeof(IdleState);
        if (InputManager.isRunning)
            return typeof(RunState);

        var goalDir = (Vector3.right * m_inputDirection.x + Vector3.forward * m_inputDirection.y).normalized;
        m_playerController.SetGoalAnimationDirection(goalDir, 0.5f);
        m_playerController.Move();
        m_playerAnimator.SetDirection("dir", m_playerController.GetAnimationDirection());

        return null;
    }

    public override void OnExit(){}
}
