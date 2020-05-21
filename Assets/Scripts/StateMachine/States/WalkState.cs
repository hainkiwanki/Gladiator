using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public WalkState(PlayerController _player) : base(_player) { }

    private float m_walkSpeed = 2.8f;
    private Vector2 m_inputDirection;

    private Vector3 prevPos = Vector3.zero;

    public override void OnEnter()
    {
        m_playerController.SetGoalSpeed(m_walkSpeed);
    }

    public override System.Type OnExecute()
    {
        m_playerController.RotateToMousePos();
        m_inputDirection = InputManager.InputDirection;

        //var currPos = m_playerController.transform.position;
        //Debug.Log((currPos - prevPos).ToString("F4"));
        //prevPos = currPos;

        if (InputManager.HasDodged)
            return typeof(DodgeState);
        if (m_playerController.m_isBlocking)
            return typeof(BlockState);
        if (m_playerController.m_hasAttacked)
            return typeof(AttackState);
        if (m_inputDirection == Vector2.zero)
            return typeof(IdleState);
        if (m_playerController.m_isRunning)
            return typeof(RunState);

        var goalDir = (Vector3.right * m_inputDirection.x + Vector3.forward * m_inputDirection.y).normalized;
        m_playerController.SetGoalAnimationDirection(goalDir, 0.5f);
        m_playerController.Move();
        m_playerAnimator.SetDirection("dir", m_playerController.GetAnimationDirection());

        return typeof(WalkState);
    }

    public override void OnExit(){}
}
