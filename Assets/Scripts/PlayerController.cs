using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_currentMoveSpeed = 0.0f;
    private float m_goalSpeed = 0.0f;
    private float m_speedChange = 5.0f;

    public Vector3 MoveDirection => m_moveDir;
    private Vector3 m_moveDir, m_lookDir, m_inputDir;
    private Vector3 m_goalDir, m_goalInputDir;
    private CharacterController m_controller;
    private float m_rotSpeed = 10.0f;

    private StateMachine m_fsm;
    private bool m_hasAttacked = false;

    private bool m_hasDodged = false;
    private float m_timeDodged;
    private float m_dodgeCooldown = 2.0f;

    [SerializeField]
    private EPlayerState state;

    private Vector3 m_dodgeLeft, m_dodgeRight, m_dodgeBack, m_dodgeBackLeft, m_dodgeBackRight
;
    private void Awake()
    {
        m_moveDir = Vector3.zero;
        m_fsm = new StateMachine(this);
        m_timeDodged = Time.deltaTime - m_dodgeCooldown;
    }

    private void Start()
    {
        m_controller = GetComponent<CharacterController>();
        m_fsm.RequestNewState(EPlayerState.IDLE);
        EventManager.onAttackingFinished += OnAttackingFinished;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_dodgeBack, 0.1f);
        //Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    private void Update()
    {
        m_dodgeBack = transform.position - transform.forward * 2.0f;

        RotateToMousePos();
        ProcessInput();
        CheckState();

        m_moveDir = Vector3.Lerp(m_moveDir, m_goalDir, Time.deltaTime * m_speedChange);
        m_currentMoveSpeed = Mathf.Lerp(m_currentMoveSpeed, m_goalSpeed, Time.deltaTime * m_speedChange);
        m_inputDir = Vector3.Lerp(m_inputDir, m_goalInputDir, Time.deltaTime * m_speedChange);

        m_fsm.Update();
        if(m_controller.enabled)
            m_controller.Move(m_inputDir * m_currentMoveSpeed * Time.deltaTime);

        state = m_fsm.CurrentState;
    }

    private void ProcessInput()
    {
        m_goalInputDir = (Vector3.right * InputManager.horizontal + Vector3.forward * InputManager.vertical).normalized;
        m_hasAttacked = InputManager.HasPressedLMB;

    }

    private void CheckState()
    {
        if (InputManager.HasPressedSpace && Time.time - m_timeDodged > m_dodgeCooldown)
            m_fsm.RequestNewState(EPlayerState.DODGE);

        switch (m_fsm.CurrentState)
        {
            case EPlayerState.IDLE:
                if (m_inputDir != Vector3.zero)
                    m_fsm.RequestNewState(EPlayerState.WALKING);
                if (m_hasAttacked)
                    m_fsm.RequestNewState(EPlayerState.ATTACKING);
                break;
            case EPlayerState.WALKING:
                if (m_inputDir == Vector3.zero)
                    m_fsm.RequestNewState(EPlayerState.IDLE);
                if (InputManager.IsHoldingLShift)
                    m_fsm.RequestNewState(EPlayerState.RUNNING);
                if (m_hasAttacked)
                    m_fsm.RequestNewState(EPlayerState.ATTACKING);
                break;
            case EPlayerState.RUNNING:
                if (!InputManager.IsHoldingLShift || m_inputDir == Vector3.zero)
                    m_fsm.RequestNewState(EPlayerState.WALKING);
                if (m_hasAttacked)
                    m_fsm.RequestNewState(EPlayerState.ATTACKING);
                break;
            case EPlayerState.ATTACKING:
                break;
            case EPlayerState.DODGE:
                break;
            case EPlayerState.NONE:
            default:
                break;
        }
    }

    private void RotateToMousePos()
    {
        m_lookDir = (InputManager.mouseWP - transform.position).normalized;
        var distance = Vector3.Distance(transform.position, InputManager.mouseWP);
        if(distance < 0.5f)
        {
            return;
        }
        if (m_lookDir != Vector3.zero)
        {
            m_lookDir.y = 0.0f;
            var targetRot = Quaternion.LookRotation(m_lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, m_rotSpeed * Time.deltaTime);
        }
    }

    public void ResetMoveDir()
    {
        m_goalDir.z = 0.0f;
        m_goalDir.x = 0.0f;
    }

    public void SetMoveDirection(float _multiplier = 1.0f)
    {
        m_goalDir.z = Vector3.Dot(m_inputDir, m_lookDir);
        var perpen = Vector3.Cross(Vector3.up, m_inputDir);
        var dot = Vector3.Dot(m_lookDir, perpen);
        m_goalDir.x = -dot;

        m_goalDir *= _multiplier;
    }

    public void SetMoveSpeed(float _speed)
    {
        m_goalSpeed = _speed;
    }

    private void OnAttackingFinished()
    {
        if (m_fsm.CurrentState == EPlayerState.ATTACKING)
        {
            m_fsm.RequestNewState(EPlayerState.IDLE);
        }
    }
}
