// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputSystem/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""PlayerMovements"",
            ""id"": ""64ba3968-b31e-46c8-a9f4-29dce75221eb"",
            ""actions"": [
                {
                    ""name"": ""Movements"",
                    ""type"": ""Value"",
                    ""id"": ""1c8828fb-d0b0-4fe4-a92f-eb54527e2249"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""034085a9-2f53-4fa5-89e2-d7ec4d13eaa4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""f3fbb2db-a483-4d79-896b-01ea2e8fd741"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Gliding"",
                    ""type"": ""Button"",
                    ""id"": ""cb652c86-058a-4a6b-ab04-95a0a82e3cc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""46585693-ec3f-41bb-9e24-503f32101d7d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8801a2ff-4c7d-47ce-b03b-033e50d644d3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""24ed1d09-2cc9-458d-9445-b7d664a719a2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2cefa732-3ffd-4dc2-86fe-fdf60987a69d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddc0ff45-fbe0-4d88-8548-2241dfe95446"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b78a6488-c264-4fe8-8d4a-0920a783c4db"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4297c3c3-7b7d-4fcb-aa5e-6ed07ad3ee49"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a847cd4f-283b-4377-b595-7a59e3874a9f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""860c2c38-bc63-406d-ae18-4afacede7282"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gliding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ThrowNut"",
            ""id"": ""e8668a76-f611-4741-80d7-1b62b07fbe0c"",
            ""actions"": [
                {
                    ""name"": ""Throw"",
                    ""type"": ""Value"",
                    ""id"": ""7c7984cd-5506-4a5b-a2c9-ad440dc6d2c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Direction"",
                    ""type"": ""Button"",
                    ""id"": ""461c7dd4-cb00-4236-aad1-6e2b1b382591"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""efdcfb7e-00f0-47bc-a545-cc7355405437"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a9320b1a-22ba-4894-bf44-331f2ef9513a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""10e26008-86d6-417b-837c-cdeb791c3f48"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a9b5fb2b-a6b9-4673-b847-07e57c2086a8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovements
        m_PlayerMovements = asset.FindActionMap("PlayerMovements", throwIfNotFound: true);
        m_PlayerMovements_Movements = m_PlayerMovements.FindAction("Movements", throwIfNotFound: true);
        m_PlayerMovements_Jump = m_PlayerMovements.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovements_Dash = m_PlayerMovements.FindAction("Dash", throwIfNotFound: true);
        m_PlayerMovements_Gliding = m_PlayerMovements.FindAction("Gliding", throwIfNotFound: true);
        // ThrowNut
        m_ThrowNut = asset.FindActionMap("ThrowNut", throwIfNotFound: true);
        m_ThrowNut_Throw = m_ThrowNut.FindAction("Throw", throwIfNotFound: true);
        m_ThrowNut_Direction = m_ThrowNut.FindAction("Direction", throwIfNotFound: true);
        
        
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

    // PlayerMovements
    private readonly InputActionMap m_PlayerMovements;
    private IPlayerMovementsActions m_PlayerMovementsActionsCallbackInterface;
    private readonly InputAction m_PlayerMovements_Movements;
    private readonly InputAction m_PlayerMovements_Jump;
    private readonly InputAction m_PlayerMovements_Dash;
    private readonly InputAction m_PlayerMovements_Gliding;
    public struct PlayerMovementsActions
    {
        private @InputSystem m_Wrapper;
        public PlayerMovementsActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movements => m_Wrapper.m_PlayerMovements_Movements;
        public InputAction @Jump => m_Wrapper.m_PlayerMovements_Jump;
        public InputAction @Dash => m_Wrapper.m_PlayerMovements_Dash;
        public InputAction @Gliding => m_Wrapper.m_PlayerMovements_Gliding;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovements; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementsActions instance)
        {
            if (m_Wrapper.m_PlayerMovementsActionsCallbackInterface != null)
            {
                @Movements.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnMovements;
                @Movements.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnMovements;
                @Movements.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnMovements;
                @Jump.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnDash;
                @Gliding.started -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnGliding;
                @Gliding.performed -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnGliding;
                @Gliding.canceled -= m_Wrapper.m_PlayerMovementsActionsCallbackInterface.OnGliding;
            }
            m_Wrapper.m_PlayerMovementsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movements.started += instance.OnMovements;
                @Movements.performed += instance.OnMovements;
                @Movements.canceled += instance.OnMovements;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Gliding.started += instance.OnGliding;
                @Gliding.performed += instance.OnGliding;
                @Gliding.canceled += instance.OnGliding;
            }
        }
    }
    public PlayerMovementsActions @PlayerMovements => new PlayerMovementsActions(this);

    // ThrowNut
    private readonly InputActionMap m_ThrowNut;
    private IThrowNutActions m_ThrowNutActionsCallbackInterface;
    private readonly InputAction m_ThrowNut_Throw;
    private readonly InputAction m_ThrowNut_Direction;
    public struct ThrowNutActions
    {
        private @InputSystem m_Wrapper;
        public ThrowNutActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throw => m_Wrapper.m_ThrowNut_Throw;
        public InputAction @Direction => m_Wrapper.m_ThrowNut_Direction;
        public InputActionMap Get() { return m_Wrapper.m_ThrowNut; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ThrowNutActions set) { return set.Get(); }
        public void SetCallbacks(IThrowNutActions instance)
        {
            if (m_Wrapper.m_ThrowNutActionsCallbackInterface != null)
            {
                @Throw.started -= m_Wrapper.m_ThrowNutActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_ThrowNutActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_ThrowNutActionsCallbackInterface.OnThrow;
                @Direction.started -= m_Wrapper.m_ThrowNutActionsCallbackInterface.OnDirection;
                @Direction.performed -= m_Wrapper.m_ThrowNutActionsCallbackInterface.OnDirection;
                @Direction.canceled -= m_Wrapper.m_ThrowNutActionsCallbackInterface.OnDirection;
            }
            m_Wrapper.m_ThrowNutActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @Direction.started += instance.OnDirection;
                @Direction.performed += instance.OnDirection;
                @Direction.canceled += instance.OnDirection;
            }
        }
    }
    public ThrowNutActions @ThrowNut => new ThrowNutActions(this);
    public interface IPlayerMovementsActions
    {
        void OnMovements(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnGliding(InputAction.CallbackContext context);
    }
    public interface IThrowNutActions
    {
        void OnThrow(InputAction.CallbackContext context);
        void OnDirection(InputAction.CallbackContext context);
    }
}
