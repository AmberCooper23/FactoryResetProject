//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/action maps/sdfsdnfok.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Sdfsdnfok: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Sdfsdnfok()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""sdfsdnfok"",
    ""maps"": [
        {
            ""name"": ""navigating"",
            ""id"": ""4897034d-b84e-4a8d-a397-c1040cfd41c7"",
            ""actions"": [
                {
                    ""name"": ""Arrows"",
                    ""type"": ""Button"",
                    ""id"": ""5bd0383d-70b5-43ad-b169-dadab2b675ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WASD"",
                    ""type"": ""Button"",
                    ""id"": ""04c8cd81-95ac-4506-9718-f4b066ad121b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left Stick [Gamepad]"",
                    ""type"": ""Button"",
                    ""id"": ""da6fccc2-5a18-4d8a-a2ec-025e11ca31cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look Around"",
                    ""type"": ""Value"",
                    ""id"": ""a87850ad-aded-479d-bcde-b421063a86c6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""935c385f-b85b-471a-ba33-d2fb086b2374"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arrows"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b1455aa-3a39-4f10-9a04-39e53a11b338"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arrows"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93111e02-f61a-4802-b0e7-ebd28e5bc925"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arrows"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cac7bcb-55ac-475c-b67d-147c231f62e6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arrows"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cc98282-63f9-4a11-9153-958584f36fde"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a91ec054-a794-4bc7-aaa3-754b1ea82fdd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a522cc5-ffcb-4670-b847-809ce9229f04"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01135960-0ba1-4704-b241-04d6189c4a9c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccd8b286-0b8e-49ce-8270-e67306937f26"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Stick [Gamepad]"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fa58b68-8423-46c1-8d92-fa829f52c395"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Stick [Gamepad]"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f09d413f-4a7e-4d80-8c08-e64f3bc67b91"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Stick [Gamepad]"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d8e9401-69f1-49f3-926a-e0b7ec2ddd1d"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Stick [Gamepad]"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cf87ccd-ebee-4ed4-a86b-13a3c26ebee6"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look Around"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ee60d82-1f3a-494d-bf8d-9fbc94942277"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look Around"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // navigating
        m_navigating = asset.FindActionMap("navigating", throwIfNotFound: true);
        m_navigating_Arrows = m_navigating.FindAction("Arrows", throwIfNotFound: true);
        m_navigating_WASD = m_navigating.FindAction("WASD", throwIfNotFound: true);
        m_navigating_LeftStickGamepad = m_navigating.FindAction("Left Stick [Gamepad]", throwIfNotFound: true);
        m_navigating_LookAround = m_navigating.FindAction("Look Around", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // navigating
    private readonly InputActionMap m_navigating;
    private List<INavigatingActions> m_NavigatingActionsCallbackInterfaces = new List<INavigatingActions>();
    private readonly InputAction m_navigating_Arrows;
    private readonly InputAction m_navigating_WASD;
    private readonly InputAction m_navigating_LeftStickGamepad;
    private readonly InputAction m_navigating_LookAround;
    public struct NavigatingActions
    {
        private @Sdfsdnfok m_Wrapper;
        public NavigatingActions(@Sdfsdnfok wrapper) { m_Wrapper = wrapper; }
        public InputAction @Arrows => m_Wrapper.m_navigating_Arrows;
        public InputAction @WASD => m_Wrapper.m_navigating_WASD;
        public InputAction @LeftStickGamepad => m_Wrapper.m_navigating_LeftStickGamepad;
        public InputAction @LookAround => m_Wrapper.m_navigating_LookAround;
        public InputActionMap Get() { return m_Wrapper.m_navigating; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NavigatingActions set) { return set.Get(); }
        public void AddCallbacks(INavigatingActions instance)
        {
            if (instance == null || m_Wrapper.m_NavigatingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_NavigatingActionsCallbackInterfaces.Add(instance);
            @Arrows.started += instance.OnArrows;
            @Arrows.performed += instance.OnArrows;
            @Arrows.canceled += instance.OnArrows;
            @WASD.started += instance.OnWASD;
            @WASD.performed += instance.OnWASD;
            @WASD.canceled += instance.OnWASD;
            @LeftStickGamepad.started += instance.OnLeftStickGamepad;
            @LeftStickGamepad.performed += instance.OnLeftStickGamepad;
            @LeftStickGamepad.canceled += instance.OnLeftStickGamepad;
            @LookAround.started += instance.OnLookAround;
            @LookAround.performed += instance.OnLookAround;
            @LookAround.canceled += instance.OnLookAround;
        }

        private void UnregisterCallbacks(INavigatingActions instance)
        {
            @Arrows.started -= instance.OnArrows;
            @Arrows.performed -= instance.OnArrows;
            @Arrows.canceled -= instance.OnArrows;
            @WASD.started -= instance.OnWASD;
            @WASD.performed -= instance.OnWASD;
            @WASD.canceled -= instance.OnWASD;
            @LeftStickGamepad.started -= instance.OnLeftStickGamepad;
            @LeftStickGamepad.performed -= instance.OnLeftStickGamepad;
            @LeftStickGamepad.canceled -= instance.OnLeftStickGamepad;
            @LookAround.started -= instance.OnLookAround;
            @LookAround.performed -= instance.OnLookAround;
            @LookAround.canceled -= instance.OnLookAround;
        }

        public void RemoveCallbacks(INavigatingActions instance)
        {
            if (m_Wrapper.m_NavigatingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(INavigatingActions instance)
        {
            foreach (var item in m_Wrapper.m_NavigatingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_NavigatingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public NavigatingActions @navigating => new NavigatingActions(this);
    public interface INavigatingActions
    {
        void OnArrows(InputAction.CallbackContext context);
        void OnWASD(InputAction.CallbackContext context);
        void OnLeftStickGamepad(InputAction.CallbackContext context);
        void OnLookAround(InputAction.CallbackContext context);
    }
}
