using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(PlayerController _player) : base(_player) { }

    private bool m_nextCombo = false;

    public override void OnEnter()
    {
        m_playerController.ResetMoveDir();
        m_playerController.SetMoveSpeed(0.0f);
        m_playerAnimator.SetBool("attack1", true);
        m_playerAnimator.SetDirection(Vector3.zero);
    }

    public override void OnExecute()
    {
        if (!m_playerAnimator.GetBool("attack2") && !m_nextCombo && InputManager.HasPressedLMB && InputManager.AmountOfClicks >= 2)
        {
            m_nextCombo = true;
            m_playerAnimator.SetBool("attack2", true);
        }
    }

    public override void OnExit()
    {
        m_nextCombo = false;
    }
}