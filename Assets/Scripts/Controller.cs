// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""17c1a083-38df-40f0-8386-50b79b33bb39"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""efaa2911-e6f2-4c67-9b31-9800fb30bad8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""94f7f0dd-2666-4ab4-b83b-ce6304b12870"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7c480904-948b-4ba1-ac29-f332f4e0a718"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PcMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""55d6ff68-5c7f-4182-8d3f-f71df2d594ef"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6e9f3ecc-65de-4ad1-b3a9-588ab4129bf8"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""cf0267b6-2779-48d5-84f3-eaccccac3ae7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PcMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c66c94ff-4ce5-40a0-986f-57158928a332"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PcMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8b95ea7d-2849-4c58-8821-b429a2ce91dc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PcMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""45290c04-98cb-42c7-9094-7f7b3f7109b5"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8642ce8-5b4f-40b9-b83c-458c742e6460"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_Tap = m_Controls.FindAction("Tap", throwIfNotFound: true);
        m_Controls_TouchPress = m_Controls.FindAction("TouchPress", throwIfNotFound: true);
        m_Controls_TouchPosition = m_Controls.FindAction("TouchPosition", throwIfNotFound: true);
        m_Controls_PcMovement = m_Controls.FindAction("PcMovement", throwIfNotFound: true);
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

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_Tap;
    private readonly InputAction m_Controls_TouchPress;
    private readonly InputAction m_Controls_TouchPosition;
    private readonly InputAction m_Controls_PcMovement;
    public struct ControlsActions
    {
        private @Controller m_Wrapper;
        public ControlsActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Controls_Tap;
        public InputAction @TouchPress => m_Wrapper.m_Controls_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_Controls_TouchPosition;
        public InputAction @PcMovement => m_Wrapper.m_Controls_PcMovement;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @Tap.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTap;
                @Tap.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTap;
                @Tap.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTap;
                @TouchPress.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTouchPress;
                @TouchPosition.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTouchPosition;
                @PcMovement.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPcMovement;
                @PcMovement.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPcMovement;
                @PcMovement.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPcMovement;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @PcMovement.started += instance.OnPcMovement;
                @PcMovement.performed += instance.OnPcMovement;
                @PcMovement.canceled += instance.OnPcMovement;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    public interface IControlsActions
    {
        void OnTap(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnPcMovement(InputAction.CallbackContext context);
    }
}
