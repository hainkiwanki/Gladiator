using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManager
{
    private static PlayerInput m_playerInput;
    private static Camera m_cam;

    private static Vector2 m_mouseScreenPos;

    public static Vector3 mouseWP => m_mouseWorldPos;
    private static Vector3 m_mouseWorldPos;

    public static Vector2 InputDirection;

    // Combo clicking
    public static int AmountOfClicks => m_amountOfClicks;
    private static int m_amountOfClicks = 0;
    private static float m_lastTimeClicked;
    private static float m_maxComboDelay = 0.4f;
    public static PlayerInput.PlayerActions playerInput;
    public static PlayerInput.TestActions Test;

    // Double tapping
    public static Vector2 DodgeDirection;
    private static Dictionary<char, float> m_firstTapPerKey;
    public static bool hasDodged, isRunning, hasAttacked, hasKicked, isBlocking;

    public static void Awake()
    {
        m_cam = Camera.main;
        m_playerInput = new PlayerInput();
        playerInput = m_playerInput.Player;
        Test = m_playerInput.Test;

        m_playerInput.Player.MousePosition.performed += ctx => ReadMousePos(ctx.ReadValue<Vector2>());
        m_playerInput.Player.Attack.performed += ctx => OnLMBPressed();

        m_playerInput.Player.Movement.performed += ctx => InputDirection = ctx.ReadValue<Vector2>();

        m_playerInput.Player.DodgeW.performed += ctx => OnDodgeTap('w');
        m_playerInput.Player.DodgeA.performed += ctx => OnDodgeTap('a');
        m_playerInput.Player.DodgeS.performed += ctx => OnDodgeTap('s');
        m_playerInput.Player.DodgeD.performed += ctx => OnDodgeTap('d');
        m_playerInput.Player.Dodge.performed += ctx => OnDodge(true);
        m_playerInput.Player.Dodge.canceled += ctx => OnDodge(false);
        m_playerInput.Player.Run.performed += _ => isRunning = true;
        m_playerInput.Player.Run.canceled += _ => isRunning = false;
        m_playerInput.Player.Attack.performed += _ => hasAttacked = true;
        m_playerInput.Player.Attack.canceled += _ => hasAttacked = false;
        m_playerInput.Player.Kick.performed += _ => hasKicked = true;
        m_playerInput.Player.Kick.canceled += _ => hasKicked = false;
        m_playerInput.Player.Block.performed += _ => isBlocking = true;
        m_playerInput.Player.Block.canceled += _ => isBlocking = false;

        var offset = 10.0f; // to prevent double tap when player first starts moving
        m_firstTapPerKey = new Dictionary<char, float>() {
            {'w', Time.time - offset }, {'s', Time.time - offset }, 
            {'d', Time.time - offset }, {'a', Time.time - offset } };

    }

    private static void OnDodge(bool _b)
    {
        hasDodged = (_b && InputDirection != Vector2.zero);
        DodgeDirection = (hasDodged) ? InputDirection : Vector2.zero;
    }

    private static void OnDodgeTap(char _c)
    {
        DodgeDirection = Vector3.zero;
        if (!hasDodged)
        {
            var currentTime = Time.time;
            var dodgeTime = 0.5f;
            if (currentTime - m_firstTapPerKey[_c] < dodgeTime)
            {
                if (_c == 'w')
                    DodgeDirection.y = 1.0f;
                else if (_c == 's')
                    DodgeDirection.y = -1.0f;
                else if (_c == 'a')
                    DodgeDirection.x = -1.0f;
                else if (_c == 'd')
                    DodgeDirection.x = 1.0f;
                hasDodged = true;
            }
            else
            {
                m_firstTapPerKey[_c] = Time.time;
            }
        }
    }

    public static void SetDodged(bool _B)
    {
        hasDodged = _B;
    }

    private static void OnLMBPressed()
    {
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

        if (GetMouseWorldPosition(out Vector3 worldPos))
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
