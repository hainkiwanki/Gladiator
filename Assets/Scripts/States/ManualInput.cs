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
        private Vector2 m_mouseScreenPos;


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
            m_playerInput.Player.MousePosition.performed += ctx => ReadMousePos(ctx.ReadValue<Vector2>());
        }

        private void ReadMousePos(Vector2 _screenPos)
        {
            m_mouseScreenPos = _screenPos;
        }

        public bool GetMouseWorldPosition(out Vector3 _worldPos)
        {
            _worldPos = Vector3.zero;
            if (m_cam == null) return false;

            Ray ray = m_cam.ScreenPointToRay(m_mouseScreenPos);
            RaycastHit hit;
            int layer = 1 << LayerMask.NameToLayer("Ground");
            if (Physics.Raycast(ray, out hit, 100.0f, layer))
            {
                _worldPos = hit.point;
                return true;
            }

            return false;
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

            if (GetMouseWorldPosition(out Vector3 worldPos))
            {
                m_control.mousePosition = worldPos;
            }
        }

        private void LateUpdate()
        {
            if (m_control.isPrimaryAttack)
                m_control.isPrimaryAttack = false;
        }
    }
}