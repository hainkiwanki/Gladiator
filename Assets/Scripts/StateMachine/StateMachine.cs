using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public EPlayerState CurrentState => m_state;

    protected State m_currentState;
    protected PlayerController m_player;
    protected EPlayerState m_state;

    public StateMachine(PlayerController _player, EPlayerState _startState = EPlayerState.IDLE)
    {
        m_player = _player;
        m_state = _startState;
        RequestNewState(m_state);
    }

    public void Update()
    {
        if (m_currentState != null)
            m_currentState.OnExecute();
    }

    public void RequestNewState(EPlayerState _newState)
    {
        // if new state is same as old state => return
        if (_newState == m_state) return;

        switch (_newState)
        {
            case EPlayerState.NONE:
                Debug.LogError("Changing state to NONE. WHY?");
                m_state = EPlayerState.NONE;
                ChangeState(null);
                break;
            case EPlayerState.IDLE:
                if (!CheckIfStateIs(new List<EPlayerState>() { EPlayerState.RUNNING }))
                {
                    m_state = EPlayerState.IDLE;
                    ChangeState(new IdleState(m_player));
                }
                break;
            case EPlayerState.WALKING:
                if(CheckIfStateIs(new List<EPlayerState>() { EPlayerState.IDLE, EPlayerState.RUNNING }))
                {
                    m_state = EPlayerState.WALKING;
                    ChangeState(new WalkState(m_player));
                }
                break;
            case EPlayerState.RUNNING:
                if(CheckIfStateIs(new List<EPlayerState>() { EPlayerState.WALKING }))
                {
                    m_state = EPlayerState.RUNNING;
                    ChangeState(new RunState(m_player));
                }
                break;
            case EPlayerState.ATTACKING:
                m_state = EPlayerState.ATTACKING;
                ChangeState(new AttackState(m_player));
                break;
            case EPlayerState.DODGE:
                m_state = EPlayerState.DODGE;
                ChangeState(new DodgeState(m_player));
                break;
            default:
                break;
        }
    }

    private bool CheckIfStateIs(List<EPlayerState> _states)
    {
        foreach (var state in _states)
        {
            if (m_state == state)
                return true;
        }

        return false;
    }

    public void ChangeState(State _newState)
    {
        if (m_currentState != null)
            m_currentState.OnExit();

        m_currentState = _newState;
        if (_newState != null)
            m_currentState.OnEnter();
    }
}
