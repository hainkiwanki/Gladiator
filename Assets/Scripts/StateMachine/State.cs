using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter();
    System.Type OnExecute();
    void OnExit();
}

public abstract class State : IState
{
    protected PlayerController m_playerController;
    protected PlayerAnimator m_playerAnimator;

    public State(PlayerController _player)
    {
        m_playerController = _player;
        m_playerAnimator = _player.GetComponent<PlayerAnimator>();
    }

    public abstract void OnEnter();

    public abstract System.Type OnExecute();

    public abstract void OnExit();
}
