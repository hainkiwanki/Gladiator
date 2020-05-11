// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""76227135-8664-4c94-99de-60d3bf20b1af"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d53cbb31-50eb-45b6-8bdf-daa462802281"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8546c7c2-2e41-4e4a-bda5-c7d25d03bef7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""915f50c0-8510-4694-b4ea-9175d7d5f026"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""73e81b75-5386-4e63-aa6c-84d168fe925a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""34e6615d-65b2-4a0c-ac7b-f09214a46e16"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""26ead562-e045-4831-9b23-4260af809210"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""335da131-2a3d-49f2-930c-5e182deeba9a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""08527e21-253d-42ac-9e40-1d88569d0fc7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""773accb2-508e-47b7-8810-747c539bc6f2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f0f3a529-9809-4be6-9c8c-4e393d53903d"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""193fd757-3e4e-4b88-ad6b-c92a3ca60fc1"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3dd567e-253b-49fa-91bf-d68fb817e84d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""5caf9d65-591c-4f4d-adfc-0fe478c52f60"",
            ""actions"": [
                {
                    ""name"": ""LMBPressed"",
                    ""type"": ""Button"",
                    ""id"": ""7fe5ff11-e005-44d9-a49f-93947ae11814"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LMBReleased"",
                    ""type"": ""Button"",
                    ""id"": ""290d44fb-6c40-47d0-b64e-bde1ca84b64c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LMBHold"",
                    ""type"": ""Button"",
                    ""id"": ""9070474a-1f93-4388-8714-4e8205aecaa8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dfe27e10-31b0-4bf1-9adc-34b5ec140266"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LMBPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bd98803-5dc3-4dcb-91db-592be90b243b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LMBReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad3c7ac2-3e9c-496f-a74f-74d49a84e23e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LMBHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_MousePosition = m_Player.FindAction("MousePosition", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Dodge = m_Player.FindAction("Dodge", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_LMBPressed = m_Mouse.FindAction("LMBPressed", throwIfNotFound: true);
        m_Mouse_LMBReleased = m_Mouse.FindAction("LMBReleased", throwIfNotFound: true);
        m_Mouse_LMBHold = m_Mouse.FindAction("LMBHold", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_MousePosition;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Dodge;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @MousePosition => m_Wrapper.m_Player_MousePosition;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Dodge => m_Wrapper.m_Player_Dodge;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @MousePosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Dodge.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_LMBPressed;
    private readonly InputAction m_Mouse_LMBReleased;
    private readonly InputAction m_Mouse_LMBHold;
    public struct MouseActions
    {
        private @PlayerInput m_Wrapper;
        public MouseActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LMBPressed => m_Wrapper.m_Mouse_LMBPressed;
        public InputAction @LMBReleased => m_Wrapper.m_Mouse_LMBReleased;
        public InputAction @LMBHold => m_Wrapper.m_Mouse_LMBHold;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @LMBPressed.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnLMBPressed;
                @LMBPressed.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnLMBPressed;
                @LMBPressed.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnLMBPressed;
                @LMBReleased.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnLMBReleased;
                @LMBReleased.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnLMBReleased;
                @LMBReleased.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnLMBReleased;
                @LMBHold.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnLMBHold;
                @LMBHold.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnLMBHold;
                @LMBHold.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnLMBHold;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LMBPressed.started += instance.OnLMBPressed;
                @LMBPressed.performed += instance.OnLMBPressed;
                @LMBPressed.canceled += instance.OnLMBPressed;
                @LMBReleased.started += instance.OnLMBReleased;
                @LMBReleased.performed += instance.OnLMBReleased;
                @LMBReleased.canceled += instance.OnLMBReleased;
                @LMBHold.started += instance.OnLMBHold;
                @LMBHold.performed += instance.OnLMBHold;
                @LMBHold.canceled += instance.OnLMBHold;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnLMBPressed(InputAction.CallbackContext context);
        void OnLMBReleased(InputAction.CallbackContext context);
        void OnLMBHold(InputAction.CallbackContext context);
    }
}
