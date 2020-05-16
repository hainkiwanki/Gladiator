using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : State
{
    public BlockState(PlayerController _player) : base(_player) { }

    public override void OnEnter()
    {
        m_playerAnimator.SetBool("blocking", true);
    }

    public override Type OnExecute()
    {
        m_playerController.RotateToMousePos();
        if (m_playerController.HasKicked)
            return typeof(KickState);
        if (!m_playerController.IsBlocking)
            return typeof(IdleState);
        if (InputManager.HasDodged)
            return typeof(DodgeState);
        return null;
    }

    public override void OnExit()
    {
    }
}
