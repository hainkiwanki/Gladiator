using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(PlayerController _player) : base(_player) { }

    public override void OnEnter()
    {
        m_playerController.SetMoveSpeed(0.0f);
        m_playerController.ResetMoveDir();
        m_playerAnimator.SetDirection(Vector3.zero);
    }

    public override void OnExecute(){}

    public override void OnExit(){}
}
