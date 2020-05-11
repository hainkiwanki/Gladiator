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

    private void Awake()
    {
        m_moveDir = Vector3.zero;
        m_fsm = new StateMachine(this);
    }

    private void Start()
    {
        m_controller = GetComponent<CharacterController>();
        m_fsm.RequestNewState(EPlayerState.IDLE);
    }
    
    private void Update()
    {
        RotateToMousePos();
        ProcessInput();
        CheckState();

        Debug.Log(m_fsm.CurrentState);

        m_moveDir = Vector3.Lerp(m_moveDir, m_goalDir, Time.deltaTime * m_speedChange);
        m_currentMoveSpeed = Mathf.Lerp(m_currentMoveSpeed, m_goalSpeed, Time.deltaTime * m_speedChange);
        m_inputDir = Vector3.Lerp(m_inputDir, m_goalInputDir, Time.deltaTime * m_speedChange);

        m_fsm.Update();
        m_controller.Move(m_inputDir * m_currentMoveSpeed * Time.deltaTime);
    }

    private void ProcessInput()
    {
        m_goalInputDir = (Vector3.right * InputManager.horizontal + Vector3.forward * InputManager.vertical).normalized;
    }

    private void CheckState()
    {
        switch (m_fsm.CurrentState)
        {
            case EPlayerState.IDLE:
                if (m_inputDir != Vector3.zero)
                    m_fsm.RequestNewState(EPlayerState.WALKING);
                break;
            case EPlayerState.WALKING:
                if (m_inputDir == Vector3.zero)
                    m_fsm.RequestNewState(EPlayerState.IDLE);
                if (InputManager.IsHoldingLShift)
                    m_fsm.RequestNewState(EPlayerState.RUNNING);
                break;
            case EPlayerState.RUNNING:
                if (!InputManager.IsHoldingLShift || m_inputDir == Vector3.zero)
                    m_fsm.RequestNewState(EPlayerState.WALKING);
                break;
            case EPlayerState.ATTACKING:
                break;
            case EPlayerState.NONE:
            default:
                break;
        }
    }

    private void RotateToMousePos()
    {
        m_lookDir = (InputManager.mouseWP - transform.position).normalized;
        if (m_lookDir != Vector3.zero)
        {
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
}
