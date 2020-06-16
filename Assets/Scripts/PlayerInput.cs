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
                },
                {
                    ""name"": ""Kick"",
                    ""type"": ""Button"",
                    ""id"": ""35904bd1-011f-473a-a2c0-6d7a88cd06ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackSecondary"",
                    ""type"": ""Button"",
                    ""id"": ""415a705f-34c8-4b78-a363-02b98532d2ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""AttackPrimary"",
                    ""type"": ""Button"",
                    ""id"": ""c58257c8-d477-4af4-96d6-0db3bbf060e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""DodgeW"",
                    ""type"": ""Button"",
                    ""id"": ""7ab778f8-feda-420c-8a58-39d71bbe3cfa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DodgeS"",
                    ""type"": ""Button"",
                    ""id"": ""b3467d75-7697-4d52-9fa7-aa705ccb0f11"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DodgeA"",
                    ""type"": ""Button"",
                    ""id"": ""55595d55-223a-4de0-8b00-ac3236c60205"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DodgeD"",
                    ""type"": ""Button"",
                    ""id"": ""bf413516-4764-49c0-a76e-30b1d5dc74bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""a6e90306-514c-4144-8a53-7d0d8e622803"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7d235749-4d3d-40f0-82b7-c38eee95dfc8"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""231ad918-c4f1-4974-92c9-da55e66a8e95"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2367a402-7c5d-4ad7-ae48-816100985076"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackPrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""664e786a-beca-48b1-8d65-93cb924c0bb9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DodgeW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2580b644-0840-433c-ad4a-49f391a4739c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DodgeS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e64f555-591a-4ca2-ae71-1714487a318c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DodgeA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""400dd2b7-89dd-41bf-92b6-d8ef2965bf09"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DodgeD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5784864-4677-49ca-a048-b1401a910b36"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bc52619-01eb-4d0e-ac0a-65a6f022c3f0"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackSecondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e955c383-fbd7-47b6-bbb3-d62422a13aa9"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
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
        },
        {
            ""name"": ""Test"",
            ""id"": ""ef3ae5be-2539-4fa8-9479-bd64707b9b26"",
            ""actions"": [
                {
                    ""name"": ""TestButton"",
                    ""type"": ""Button"",
                    ""id"": ""b7a0986e-4d47-4d2c-b29d-06ab3ad10b41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""60cdef3e-1bb6-47f5-91df-31ecb9ed5637"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TestButton"",
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
        m_Player_Kick = m_Player.FindAction("Kick", throwIfNotFound: true);
        m_Player_AttackSecondary = m_Player.FindAction("AttackSecondary", throwIfNotFound: true);
        m_Player_AttackPrimary = m_Player.FindAction("AttackPrimary", throwIfNotFound: true);
        m_Player_DodgeW = m_Player.FindAction("DodgeW", throwIfNotFound: true);
        m_Player_DodgeS = m_Player.FindAction("DodgeS", throwIfNotFound: true);
        m_Player_DodgeA = m_Player.FindAction("DodgeA", throwIfNotFound: true);
        m_Player_DodgeD = m_Player.FindAction("DodgeD", throwIfNotFound: true);
        m_Player_Block = m_Player.FindAction("Block", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_LMBPressed = m_Mouse.FindAction("LMBPressed", throwIfNotFound: true);
        m_Mouse_LMBReleased = m_Mouse.FindAction("LMBReleased", throwIfNotFound: true);
        m_Mouse_LMBHold = m_Mouse.FindAction("LMBHold", throwIfNotFound: true);
        // Test
        m_Test = asset.FindActionMap("Test", throwIfNotFound: true);
        m_Test_TestButton = m_Test.FindAction("TestButton", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Kick;
    private readonly InputAction m_Player_AttackSecondary;
    private readonly InputAction m_Player_AttackPrimary;
    private readonly InputAction m_Player_DodgeW;
    private readonly InputAction m_Player_DodgeS;
    private readonly InputAction m_Player_DodgeA;
    private readonly InputAction m_Player_DodgeD;
    private readonly InputAction m_Player_Block;
    private readonly InputAction m_Player_Interact;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @MousePosition => m_Wrapper.m_Player_MousePosition;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Dodge => m_Wrapper.m_Player_Dodge;
        public InputAction @Kick => m_Wrapper.m_Player_Kick;
        public InputAction @AttackSecondary => m_Wrapper.m_Player_AttackSecondary;
        public InputAction @AttackPrimary => m_Wrapper.m_Player_AttackPrimary;
        public InputAction @DodgeW => m_Wrapper.m_Player_DodgeW;
        public InputAction @DodgeS => m_Wrapper.m_Player_DodgeS;
        public InputAction @DodgeA => m_Wrapper.m_Player_DodgeA;
        public InputAction @DodgeD => m_Wrapper.m_Player_DodgeD;
        public InputAction @Block => m_Wrapper.m_Player_Block;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
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
                @Kick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Kick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Kick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @AttackSecondary.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackSecondary;
                @AttackSecondary.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackSecondary;
                @AttackSecondary.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackSecondary;
                @AttackPrimary.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackPrimary;
                @AttackPrimary.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackPrimary;
                @AttackPrimary.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackPrimary;
                @DodgeW.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeW;
                @DodgeW.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeW;
                @DodgeW.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeW;
                @DodgeS.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeS;
                @DodgeS.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeS;
                @DodgeS.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeS;
                @DodgeA.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeA;
                @DodgeA.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeA;
                @DodgeA.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeA;
                @DodgeD.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeD;
                @DodgeD.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeD;
                @DodgeD.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodgeD;
                @Block.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
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
                @Kick.started += instance.OnKick;
                @Kick.performed += instance.OnKick;
                @Kick.canceled += instance.OnKick;
                @AttackSecondary.started += instance.OnAttackSecondary;
                @AttackSecondary.performed += instance.OnAttackSecondary;
                @AttackSecondary.canceled += instance.OnAttackSecondary;
                @AttackPrimary.started += instance.OnAttackPrimary;
                @AttackPrimary.performed += instance.OnAttackPrimary;
                @AttackPrimary.canceled += instance.OnAttackPrimary;
                @DodgeW.started += instance.OnDodgeW;
                @DodgeW.performed += instance.OnDodgeW;
                @DodgeW.canceled += instance.OnDodgeW;
                @DodgeS.started += instance.OnDodgeS;
                @DodgeS.performed += instance.OnDodgeS;
                @DodgeS.canceled += instance.OnDodgeS;
                @DodgeA.started += instance.OnDodgeA;
                @DodgeA.performed += instance.OnDodgeA;
                @DodgeA.canceled += instance.OnDodgeA;
                @DodgeD.started += instance.OnDodgeD;
                @DodgeD.performed += instance.OnDodgeD;
                @DodgeD.canceled += instance.OnDodgeD;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
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

    // Test
    private readonly InputActionMap m_Test;
    private ITestActions m_TestActionsCallbackInterface;
    private readonly InputAction m_Test_TestButton;
    public struct TestActions
    {
        private @PlayerInput m_Wrapper;
        public TestActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @TestButton => m_Wrapper.m_Test_TestButton;
        public InputActionMap Get() { return m_Wrapper.m_Test; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestActions set) { return set.Get(); }
        public void SetCallbacks(ITestActions instance)
        {
            if (m_Wrapper.m_TestActionsCallbackInterface != null)
            {
                @TestButton.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTestButton;
                @TestButton.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTestButton;
                @TestButton.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTestButton;
            }
            m_Wrapper.m_TestActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TestButton.started += instance.OnTestButton;
                @TestButton.performed += instance.OnTestButton;
                @TestButton.canceled += instance.OnTestButton;
            }
        }
    }
    public TestActions @Test => new TestActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
        void OnAttackSecondary(InputAction.CallbackContext context);
        void OnAttackPrimary(InputAction.CallbackContext context);
        void OnDodgeW(InputAction.CallbackContext context);
        void OnDodgeS(InputAction.CallbackContext context);
        void OnDodgeA(InputAction.CallbackContext context);
        void OnDodgeD(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnLMBPressed(InputAction.CallbackContext context);
        void OnLMBReleased(InputAction.CallbackContext context);
        void OnLMBHold(InputAction.CallbackContext context);
    }
    public interface ITestActions
    {
        void OnTestButton(InputAction.CallbackContext context);
    }
}
