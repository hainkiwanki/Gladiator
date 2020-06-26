using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class ManualInput : MonoBehaviour
    {
        private Camera m_cam;
        private CharacterControl m_control;
        private PlayerInput m_playerInput;
        private Vector2 m_inputDirection;


        int frames = 0;

        private void Awake()
        {
            m_control = GetComponent<CharacterControl>();
            m_cam = Camera.main;
            BindPlayerInput();
        }

        private void BindPlayerInput()
        {
            m_playerInput = new PlayerInput();
            m_playerInput.Player.Movement.performed += ctx => m_inputDirection = ctx.ReadValue<Vector2>();
            m_playerInput.Player.AttackPrimary.started += _ => m_control.isPrimaryAttack = true;
        }

        private void OnEnable()
        {
            m_playerInput.Enable();
        }

        private void Update()
        {
            m_control.direction = m_inputDirection.x * m_cam.transform.right + m_inputDirection.y * m_cam.transform.forward;
            m_control.direction.y = 0.0f;
            m_control.direction.Normalize();
        }

        private void LateUpdate()
        {
            if (m_control.isPrimaryAttack)
                m_control.isPrimaryAttack = false;
        }
    }
}