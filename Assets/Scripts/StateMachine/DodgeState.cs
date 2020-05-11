using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{
    public DodgeState(PlayerController _player) : base(_player) { }

    public override void OnEnter()
    {
        m_playerAnimator.SetDirection(Vector3.zero);
        m_playerAnimator.SetTrigger("dodged");
    }

    public override void OnExecute()
    {
    }

    public override void OnExit()
    {
    }
}
