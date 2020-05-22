using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickState : State
{
    public KickState(PlayerController _player) : base(_player) { }

    public override void OnEnter(State _prvState)
    {
        m_playerAnimator.SetTrigger("kicked");
        m_playerAnimator.SetAnimationVariable("kickdone", false);
    }

    public override Type OnExecute()
    {
        if (m_playerAnimator.GetAnimationVariable("kickdone"))
            return typeof(IdleState);
        return typeof(KickState);
    }

    public override void OnExit()
    {
        
    }
}
