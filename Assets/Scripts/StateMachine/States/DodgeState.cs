using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{
    public DodgeState(PlayerController _player) : base(_player) { }
    
    private Vector3 m_direction;

    public override void OnEnter()
    {
        m_direction = new Vector3(InputManager.DodgeDirection.x, 0.0f, InputManager.DodgeDirection.y);
        m_playerAnimator.SetDirection("dodge", m_playerController.TransformVector3ToLocal(m_direction));
        m_playerAnimator.SetDirection("dir", Vector3.zero);
        m_playerAnimator.SetBool("dodged", true);
        m_playerController.SetMoveDir(m_direction.normalized);
        m_playerController.SetGoalSpeed(2.8f);
        m_playerController.StartACoroutine(SpawnClones());
    }

    public override System.Type OnExecute()
    {
        m_playerController.Move();
        if (!m_playerAnimator.GetBool("dodged"))
        {
            return typeof(IdleState);
        }
        return typeof(DodgeState);
    }

    public override void OnExit()
    {
        InputManager.SetDodged(false);
        m_playerAnimator.SetDirection("dodge", Vector3.zero);
        m_playerAnimator.SetDirection("dir", Vector3.zero);
        m_playerController.SetGoalAnimationDirection(Vector3.zero, 1.0f, true);
    }

    IEnumerator SpawnClones()
    {
        int frame = 0;
        while(m_playerAnimator.GetBool("dodged"))
        {
            bool spawnClone = (frame % m_playerController.m_cloneFrameDelay) == 0;
            if(spawnClone)
            {
                Cloner.ClonePlayer(m_playerController.gameObject, m_playerController.m_cloneDissolveMulti); ;
            }
            frame++;
            yield return null;
        }
    }
}
