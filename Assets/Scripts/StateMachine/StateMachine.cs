using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine
{
    protected State m_currentState;
    protected PlayerController m_player;

    private Dictionary<Type, State> m_possibleStates;

    public StateMachine(){}

    public void SetStates(Dictionary<Type, State> _states)
    {
        m_possibleStates = _states;
    }

    public void Update()
    {
        if (m_currentState == null)
        {
            m_currentState = m_possibleStates.Values.First();
        }

        var nextState = m_currentState?.OnExecute();

        if(nextState != null && nextState != m_currentState?.GetType())
        {
            ChangeState(nextState);
        }

        Debug.Log(m_currentState);
    }

    public void ChangeState(Type _newState)
    {
        m_currentState?.OnExit();

        m_currentState = m_possibleStates[_newState];

        m_currentState?.OnEnter();
    }
}
