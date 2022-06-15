// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""DeadManJack"",
            ""id"": ""212b7528-9ce1-4d37-88e1-50ed03b2d8b9"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""8b438d69-fb91-4850-ac12-be37f6c42a37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""c026db93-0dcb-4dda-aa07-6e35af0cd701"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChargeAbility"",
                    ""type"": ""Button"",
                    ""id"": ""93d2dd82-8136-402f-ad16-7c1d7325c2ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""4a790979-f317-46cb-b671-408d05646d09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD Movement"",
                    ""id"": ""1095977c-0504-48e7-b788-1702c63b132b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-5,max=5)"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e6072d59-ed79-4752-87c7-e1fea5e18b97"",
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
                    ""id"": ""9f77372e-e0be-42cc-b59b-8cc9e97e325f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStickMovement"",
                    ""id"": ""5646e0d1-d3b3-473b-a402-1a6ee2dac2bd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""43e05ccb-3350-4b82-b29a-f5447cf07986"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8fe1e1be-08be-49ea-bb62-e52d66a00a61"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeysMovement"",
                    ""id"": ""030ca2af-9ad0-4c5b-8bd6-70f1638b325c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2dca0acc-6e41-415a-8c4d-6a45a8a6475d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5b68b930-8dc4-4729-8e5c-3fb7aa9e385b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""106af624-a710-4344-b7f8-4f5bf877cf56"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16f35c52-3a24-44f3-a7c7-edfd30495ad4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cdf0b97-9fc3-4f45-9abf-bbffc00373c9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e159d3f5-d73f-4111-9c59-63366575396b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dbbb084-423f-4a00-87e0-03e690c64f71"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargeAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7f77a1e-4baf-4243-9956-0985ce7a5035"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargeAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdbcf42f-5c23-44d4-acb8-10bc5fb3bfef"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargeAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7726ac0-f9f6-4521-b49a-c4e335c1df71"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargeAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7c93395-3124-41bf-afd8-0265c0a4d379"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84df627b-a78c-4a99-81d4-1b1bc4051ad4"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // DeadManJack
        m_DeadManJack = asset.FindActionMap("DeadManJack", throwIfNotFound: true);
        m_DeadManJack_Movement = m_DeadManJack.FindAction("Movement", throwIfNotFound: true);
        m_DeadManJack_Shoot = m_DeadManJack.FindAction("Shoot", throwIfNotFound: true);
        m_DeadManJack_ChargeAbility = m_DeadManJack.FindAction("ChargeAbility", throwIfNotFound: true);
        m_DeadManJack_Pause = m_DeadManJack.FindAction("Pause", throwIfNotFound: true);
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

    // DeadManJack
    private readonly InputActionMap m_DeadManJack;
    private IDeadManJackActions m_DeadManJackActionsCallbackInterface;
    private readonly InputAction m_DeadManJack_Movement;
    private readonly InputAction m_DeadManJack_Shoot;
    private readonly InputAction m_DeadManJack_ChargeAbility;
    private readonly InputAction m_DeadManJack_Pause;
    public struct DeadManJackActions
    {
        private @PlayerController m_Wrapper;
        public DeadManJackActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_DeadManJack_Movement;
        public InputAction @Shoot => m_Wrapper.m_DeadManJack_Shoot;
        public InputAction @ChargeAbility => m_Wrapper.m_DeadManJack_ChargeAbility;
        public InputAction @Pause => m_Wrapper.m_DeadManJack_Pause;
        public InputActionMap Get() { return m_Wrapper.m_DeadManJack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DeadManJackActions set) { return set.Get(); }
        public void SetCallbacks(IDeadManJackActions instance)
        {
            if (m_Wrapper.m_DeadManJackActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnMovement;
                @Shoot.started -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnShoot;
                @ChargeAbility.started -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnChargeAbility;
                @ChargeAbility.performed -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnChargeAbility;
                @ChargeAbility.canceled -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnChargeAbility;
                @Pause.started -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_DeadManJackActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @ChargeAbility.started += instance.OnChargeAbility;
                @ChargeAbility.performed += instance.OnChargeAbility;
                @ChargeAbility.canceled += instance.OnChargeAbility;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public DeadManJackActions @DeadManJack => new DeadManJackActions(this);
    public interface IDeadManJackActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnChargeAbility(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
