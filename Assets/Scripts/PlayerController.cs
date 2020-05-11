using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_runSpeed = 7.0f;
    private float m_currentMoveSpeed = 0.0f;
    private float m_goalSpeed = 0.0f;
    private float m_speedChange = 5.0f;

    public Vector3 MoveDirection => m_moveDir;
    private Vector3 m_moveDir, m_lookDir;
    private Vector3 m_goalDir;
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
        m_fsm.Update();
        RotateToMousePos();

        var inputDir = Vector3.right * InputManager.horizontal + Vector3.forward * InputManager.vertical;
        if (inputDir == Vector3.zero)
            m_fsm.RequestNewState(EPlayerState.IDLE);
        else
            m_fsm.RequestNewState(EPlayerState.WALKING);

        /* var inputDir = Vector3.right * InputManager.horizontal + Vector3.forward * InputManager.vertical;
        if (inputDir == Vector3.zero)
            m_goalSpeed = 0.0f;

        m_goalDir.z = Vector3.Dot(inputDir.normalized, lookDir.normalized);
        if (InputManager.vertical == 0.0f && InputManager.horizontal == 0.0f)
            m_goalDir.z = 0.0f;

        var perpen = Vector3.Cross(Vector3.up, inputDir.normalized);
        var dot = Vector3.Dot(lookDir.normalized, perpen);
        m_goalDir.x = -dot;

        m_goalSpeed = m_walkSpeed;
        if (InputManager.IsHoldingLShift)
        {
            m_goalSpeed = m_runSpeed;
        }
        else
        {
            m_goalDir *= (m_walkSpeed / m_runSpeed);
        }

        m_moveDir = Vector3.Lerp(m_moveDir, m_goalDir, Time.deltaTime * m_speedChange);*/

        m_currentMoveSpeed = Mathf.Lerp(m_currentMoveSpeed, m_goalSpeed, Time.deltaTime * m_speedChange);
        m_controller.Move(inputDir * m_currentMoveSpeed * Time.deltaTime);
    }

    private void RotateToMousePos()
    {
        m_lookDir = InputManager.mouseWP - transform.position;
        if (m_lookDir != Vector3.zero)
        {
            var targetRot = Quaternion.LookRotation(m_lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, m_rotSpeed * Time.deltaTime);
        }
    }

    public void SetMoveSpeed(float _speed)
    {
        m_goalSpeed = _speed;
    }
}
