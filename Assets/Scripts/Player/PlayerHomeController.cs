using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomeController : MonoBehaviour
{
    private Transform m_cam;
    private Animator m_animator;
    private PlayerInput m_playerInput;
    private CharacterController m_controller;

    private float m_speed = 7.0f;

    private Vector2 m_inputDirection = Vector2.zero;

    private void Awake()
    {
        m_playerInput = new PlayerInput();
        m_playerInput.Player.Movement.performed += _ => m_inputDirection = _.ReadValue<Vector2>();
        // m_playerInput.Player.Movement.canceled += _ => m_inputDirection = Vector2.zero;
    }

    public void OnEnable()
    {
        m_playerInput.Enable();
    }

    public void OnDisable()
    {
        m_playerInput.Disable();
    }

    private void Start()
    {
        m_cam = Camera.main.transform;
        m_animator = GetComponent<Animator>();
        m_controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var rotationDir = m_inputDirection.x * m_cam.right + m_inputDirection.y * m_cam.forward;
        if (rotationDir != Vector3.zero)
        {
            var lookDir = Quaternion.LookRotation(rotationDir.NewY(0.0f));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDir, 10.0f * Time.deltaTime); 
        }
        if(m_inputDirection != Vector2.zero)
            m_controller.Move(m_speed * transform.forward * Time.deltaTime);

        m_animator.SetBool("moving", (m_inputDirection != Vector2.zero));
    }
}
