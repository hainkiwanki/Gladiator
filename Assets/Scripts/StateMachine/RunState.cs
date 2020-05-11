using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    private float m_runSpeed = 7.0f;

    public RunState(PlayerController _player) : base(_player) { }

    public override void OnEnter()
    {
        m_playerController.SetMoveSpeed(m_runSpeed);
    }

    public override void OnExecute()
    {
        m_playerAnimator.SetDirection(m_playerController.MoveDirection);
        m_playerController.SetMoveDirection();
    }

    public override void OnExit()
    {
    }
}
