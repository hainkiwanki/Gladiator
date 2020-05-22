using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackState : State
{
    public AttackState(PlayerController _player) : base(_player) 
    {
        m_playerActions = new List<PlayerAction>();
    }

    ~AttackState()
    {
        EventManager.onAttackComboReady -= AttackEvent;
        EventManager.onIdleAnimationEntered -= DoneAttacking;
    }

    private List<PlayerAction> m_playerActions;
    private float m_maxComboDelay = 0.9f;
    private int m_currentCombo = 0;
    private bool m_doneAttacking = false;
    private bool m_checkForNextCombo = false;

    public override void OnStart()
    {
        base.OnStart();
        InputManager.playerInput.AttackPrimary.performed += _ => Attack(EButtonType.LMB);
        EventManager.onAttackComboReady += AttackEvent;
        EventManager.onIdleAnimationEntered += DoneAttacking;

    }

    public override void OnEnter(State _prvState)
    {
        m_prvState = _prvState;
        m_playerController.SetGoalAnimationDirection(Vector3.zero);
        m_playerController.SetGoalSpeed(0.0f, true);
        m_playerAnimator.SetTrigger("attacklmb");
        m_playerAnimator.SetDirection("dir", Vector3.zero);
        m_playerAnimator.SetAnimationSpeed(m_playerController.m_attackSpeed);
    }

    public override System.Type OnExecute()
    {
        m_playerController.RotateToMousePos();
        m_playerAnimator.SetBool("blocking", InputManager.isBlocking);

        if (InputManager.hasDodged)
            return typeof(DodgeState);
        if (m_doneAttacking)
        {
            if (InputManager.isBlocking && m_prvState is BlockState)
                return typeof(BlockState);
            return typeof(IdleState);
        }

        if (m_checkForNextCombo)
        {
            if (m_playerActions.Count > m_currentCombo)
            {
                var time1 = m_playerActions[m_currentCombo - 1].time;
                var time2 = m_playerActions[m_currentCombo].time;
                if (time2 - time1 < m_maxComboDelay)
                {
                    if(m_currentCombo < m_playerController.m_comboCount)
                        m_playerAnimator.SetTrigger("attacklmb");
                    m_checkForNextCombo = false;
                }
            }
        }

        return null;
    }

    public void Attack(EButtonType _t)
    {
        m_playerActions.Add(new PlayerAction(Time.time, _t));
    }

    public override void OnExit()
    {
        m_playerActions.Clear();
        m_checkForNextCombo = false;
        m_doneAttacking = false;
        m_playerAnimator.SetAnimationSpeed(1.0f);
    }

    private void AttackEvent(int _i)
    {
        m_currentCombo = _i;
        m_checkForNextCombo = true;
    }

    private void DoneAttacking()
    {
        m_doneAttacking = true;
    }
}

public class PlayerAction
{
    public float time;
    public EButtonType type;

    public PlayerAction(float _t, EButtonType _bt)
    {
        time = _t;
        type = _bt;
    }
}