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
                    ""name"": ""QuitApplication"",
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
                    ""id"": ""b7c93395-3124-41bf-afd8-0265c0a4d379"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuitApplication"",
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
        m_DeadManJack_QuitApplication = m_DeadManJack.FindAction("QuitApplication", throwIfNotFound: true);
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
    private readonly InputAction m_DeadManJack_QuitApplication;
    public struct DeadManJackActions
    {
        private @PlayerController m_Wrapper;
        public DeadManJackActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_DeadManJack_Movement;
        public InputAction @Shoot => m_Wrapper.m_DeadManJack_Shoot;
        public InputAction @ChargeAbility => m_Wrapper.m_DeadManJack_ChargeAbility;
        public InputAction @QuitApplication => m_Wrapper.m_DeadManJack_QuitApplication;
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
                @QuitApplication.started -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnQuitApplication;
                @QuitApplication.performed -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnQuitApplication;
                @QuitApplication.canceled -= m_Wrapper.m_DeadManJackActionsCallbackInterface.OnQuitApplication;
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
                @QuitApplication.started += instance.OnQuitApplication;
                @QuitApplication.performed += instance.OnQuitApplication;
                @QuitApplication.canceled += instance.OnQuitApplication;
            }
        }
    }
    public DeadManJackActions @DeadManJack => new DeadManJackActions(this);
    public interface IDeadManJackActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnChargeAbility(InputAction.CallbackContext context);
        void OnQuitApplication(InputAction.CallbackContext context);
    }
}
