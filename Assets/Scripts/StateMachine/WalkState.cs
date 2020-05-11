using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    private float m_walkSpeed = 3.5f;
    public WalkState(PlayerController _player) : base(_player) { }


    public override void OnEnter()
    {
        m_playerController.SetMoveSpeed(m_walkSpeed);
    }

    public override void OnExecute()
    {
        m_playerAnimator.SetDirection(m_playerController.MoveDirection);
    }

    public override void OnExit()
    {
    }
}
