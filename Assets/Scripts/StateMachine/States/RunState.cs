using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    public RunState(PlayerController _player) : base(_player) { }

    private float m_runSpeed = 7.5f;
    private Vector2 m_inputDirection;

    public override void OnEnter()
    {
       m_playerController.SetGoalSpeed(m_runSpeed);
    }

    public override System.Type OnExecute()
    {
        m_inputDirection = InputManager.InputDirection;
        //if (m_playerController.m_isBlocking)
        //    return typeof(BlockState);
        if (InputManager.hasDodged)
            return typeof(DodgeState);
        //if (m_playerController.m_hasAttacked)
        //    return typeof(AttackState);
        if (!InputManager.isRunning || m_inputDirection == Vector2.zero)
            return typeof(WalkState);

        var goalDir = (Vector3.right * m_inputDirection.x + Vector3.forward * m_inputDirection.y).normalized;
        m_playerController.RotateToMousePos();
        m_playerController.SetGoalAnimationDirection(goalDir);
        m_playerController.Move();
        m_playerAnimator.SetDirection("dir", m_playerController.GetAnimationDirection());

        return typeof(RunState);
    }

    public override void OnExit(){}
}
