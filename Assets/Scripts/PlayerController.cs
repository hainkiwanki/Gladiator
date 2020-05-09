using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_moveSpeed;
    private float m_currentMoveSpeed;
    public float MoveX => m_moveDir.x;
    public float MoveZ => m_moveDir.z;
    private Vector3 m_moveDir;
    private CharacterController m_controller;
    private float m_rotSpeed = 10.0f;

    private void Awake()
    {
        m_moveDir = Vector3.zero;
    }

    private void Start()
    {
        m_controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 lookDir = InputManager.mouseWP - transform.position;
        if(lookDir != Vector3.zero)
        {
            var targetRot = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, m_rotSpeed * Time.deltaTime);
        }

        Vector3 moveDir = Vector3.right * InputManager.horizontal + Vector3.forward * InputManager.vertical;
        m_currentMoveSpeed = m_moveSpeed;
        if (moveDir == Vector3.zero)
            m_currentMoveSpeed = 0.0f;

        m_moveDir.z = Vector3.Dot(moveDir.normalized, lookDir.normalized);
        if (InputManager.vertical == 0.0f && InputManager.horizontal == 0.0f)
            m_moveDir.z = 0.0f;

        var perpen = Vector3.Cross(Vector3.up, moveDir.normalized);
        var dot = Vector3.Dot(lookDir.normalized, perpen);
        m_moveDir.x = -dot;

        m_controller.Move(moveDir * m_currentMoveSpeed * Time.deltaTime);
    }
}
