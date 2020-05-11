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
    public static Vector2 movement => m_movementInput;

    private static Vector2 m_mouseScreenPos;

    public static Vector3 mouseWP => m_mouseWorldPos;
    private static Vector3 m_mouseWorldPos;
    public static bool IsHoldingLShift => m_isHoldingLShift;
    private static bool m_isHoldingLShift;

    public static int AmountOfClicks => m_amountOfClicks;
    private static int m_amountOfClicks = 0;
    private static float m_lastTimeClicked;
    private static float m_maxComboDelay = 0.4f;

    public static bool HasPressedLMB => m_hasPressedLMB; // Attack
    private static bool m_hasPressedLMB = false;

    public static bool HasPressedSpace => m_hasPressedSpace; // Dodge
    private static bool m_hasPressedSpace = false;

    public static void Awake()
    {
        m_cam = Camera.main;
        m_playerInput = new PlayerInput();
        m_playerInput.Player.Movement.performed += ctx => m_movementInput = ctx.ReadValue<Vector2>();
        m_playerInput.Player.MousePosition.performed += ctx => ReadMousePos(ctx.ReadValue<Vector2>());

        m_playerInput.Player.Run.performed += ctx => m_isHoldingLShift = true;
        m_playerInput.Mouse.LMBPressed.performed += ctx => OnLMBPressed();
        m_playerInput.Mouse.LMBPressed.canceled += ctx => m_hasPressedLMB = false;

        m_playerInput.Player.Dodge.performed += ctx => m_hasPressedSpace = true;
        m_playerInput.Player.Dodge.canceled += ctx => m_hasPressedSpace = false;
    }

    private static void OnLMBPressed()
    {
        m_hasPressedLMB = true;
        m_lastTimeClicked = Time.time;
        m_amountOfClicks++;
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
        if(Time.time - m_lastTimeClicked > m_maxComboDelay)
        {
            m_amountOfClicks = 0;
        }

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
