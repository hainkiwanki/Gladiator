using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    private static PlayerInput m_playerInput;
    private static Camera m_cam;

    private static Vector2 m_movementInput;
    public static float horizontal => m_movementInput.x;
    public static float vertical => m_movementInput.y;

    private static Vector2 m_mouseScreenPos;

    public static Vector3 mouseWP => m_mouseWorldPos;
    private static Vector3 m_mouseWorldPos;

    public static void Awake()
    {
        m_cam = Camera.main;
        m_playerInput = new PlayerInput();
        m_playerInput.Player.Movement.performed += ctx => m_movementInput = ctx.ReadValue<Vector2>();
        m_playerInput.Player.Mouse.performed += ctx => ReadMousePos(ctx.ReadValue<Vector2>());
    }

    public static void OnEnable()
    {
        m_playerInput.Enable();
    }

    public static void OnDisable()
    {
        m_playerInput.Disable();
    }

    public static void Update()
    {
        if(GetMouseWorldPosition(out Vector3 worldPos))
        {
            m_mouseWorldPos = worldPos;
        }
    }

    private static void ReadMousePos(Vector2 _screenPos)
    {
        m_mouseScreenPos = _screenPos;
    }

    public static bool GetMouseWorldPosition(out Vector3 _worldPos)
    {
        _worldPos = Vector3.zero;

        Ray ray = m_cam.ScreenPointToRay(m_mouseScreenPos);
        RaycastHit hit;
        int layer = 1 << LayerMask.NameToLayer("Ground");
        if(Physics.Raycast(ray, out hit, 100.0f, layer))
        {
            _worldPos = hit.point;
            return true;
        }

        return false;
    }
}
