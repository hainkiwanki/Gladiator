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
        if (InputManager.hasKicked)
            return typeof(KickState);
        if (!InputManager.isBlocking)
            return typeof(IdleState);
        if (InputManager.hasDodged)
            return typeof(DodgeState);
        return null;
    }

    public override void OnExit()
    {
    }
}
