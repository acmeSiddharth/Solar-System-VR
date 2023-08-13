#if UNITY_INPUT_SYSTEM
using UnityEngine.Scripting;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

namespace Unity.XR.Skyworth.Input
{
    /// <summary>
    /// An Skyworth VR headset.
    /// </summary>
    [InputControlLayout(displayName = "Skyworth Headset")]
    [Preserve]
    public class SkyworthHMD : XRHMD
    {
        [Preserve]
        [InputControl(aliases = new[] { "devicetrackingstate" })]
        public IntegerControl trackingState { get; private set; }
        [Preserve]
        [InputControl(aliases = new[] { "deviceistracked" })]
        public ButtonControl isTracked { get; private set; }
        [Preserve]
        [InputControl]
        public Vector3Control centerEyePosition { get; private set; }
        [Preserve]
        [InputControl]
        public QuaternionControl centerEyeRotation { get; private set; }
        [Preserve]
        [InputControl(aliases = new[] { "clickButton", "PrimaryButton" })]
        public ButtonControl clickButton { get; private set; }
        [Preserve]
        [InputControl(aliases = new[] { "back" ,"MenuButton" })]
        public ButtonControl backButton { get; private set; }

        [Preserve]
        [InputControl(aliases = new[] { "VolumeUpButton" })]
        public ButtonControl volumUpButton { get; private set; }
        [Preserve]
        [InputControl(aliases = new[] { "VolumeDownButton" })]
        public ButtonControl volumDownButton { get; private set; }
        protected override void FinishSetup()
        {
            base.FinishSetup();

            trackingState = GetChildControl<IntegerControl>("trackingState");
            isTracked = GetChildControl<ButtonControl>("isTracked");
            centerEyePosition = GetChildControl<Vector3Control>("centerEyePosition");
            centerEyeRotation = GetChildControl<QuaternionControl>("centerEyeRotation");

            clickButton = GetChildControl<ButtonControl>("PrimaryButton");
            backButton = GetChildControl<ButtonControl>("MenuButton");
            volumUpButton = GetChildControl<ButtonControl>("VolumeUpButton");
            volumDownButton = GetChildControl<ButtonControl>("VolumeDownButton");
        }
       
    }

    /// <summary>
    /// An Skyworth Touch controller.
    /// </summary>
    [Preserve]
    [InputControlLayout(displayName = "Skyworth Touch Controller", commonUsages = new[] { "LeftHand", "RightHand" })]
    public class SkyworthTouchController : XRControllerWithRumble
    {
        [Preserve]
        [InputControl(aliases = new[] { "Primary2DAxis", "Joystick" })]
        public Vector2Control touchAxis { get; private set; }

        [Preserve]
        [InputControl]
        public AxisControl gripTouched { get; private set; }

        [InputControl]
        public AxisControl battery { get; private set; }
        [Preserve]
        [InputControl]
        public AxisControl trigger { get; private set; }

        [Preserve]
        [InputControl(aliases = new[] { "PrimaryButton" ,"touchpadClick" })]
        public ButtonControl clickButton { get; private set; }
        [Preserve]
        [InputControl(aliases = new[] { "home" })]
        public ButtonControl homeButton { get; private set; }
        [Preserve]
        [InputControl(aliases = new[] { "gripPressed" })]
        public ButtonControl gripButton { get; private set; }
        [Preserve]
        [InputControl(aliases = new[] { "app", "menubutton" , "menu" })]
        public ButtonControl menuButton { get; private set; }
        
        [Preserve]
        [InputControl(aliases = new[] { "primarytouch","touchpadTouch" , "primaryTouched" })]
        public ButtonControl primaryTouched { get; private set; }
      
        [Preserve]
        [InputControl(aliases = new[] { "triggerPressed" , "triggerbutton" })]
        public ButtonControl triggerPressed { get; private set; }

        [Preserve]
        [InputControl(aliases = new[] { "controllerTrackingState" })]
        public IntegerControl trackingState { get; private set; }
        [Preserve]
        [InputControl(aliases = new[] { "ControllerIsTracked" })]
        public ButtonControl isTracked { get; private set; }
        [Preserve]
        [InputControl(aliases = new[] { "controllerPosition" })]
        public Vector3Control devicePosition { get; private set; }
        [Preserve]
        [InputControl(aliases = new[] { "controllerRotation" })]
        public QuaternionControl deviceRotation { get; private set; }
        

        protected override void FinishSetup()
        {
            base.FinishSetup();

            touchAxis = GetChildControl<Vector2Control>("Primary2DAxis");
            trigger = GetChildControl<AxisControl>("trigger");
            gripTouched = GetChildControl<AxisControl>("gripTouched");
            battery = GetChildControl<AxisControl>("BatteryLevel");

            clickButton = GetChildControl<ButtonControl>("PrimaryButton");
            homeButton = GetChildControl<ButtonControl>("HomeButton");
            gripButton = GetChildControl<ButtonControl>("GripButton");
            menuButton = GetChildControl<ButtonControl>("MenuButton");
            primaryTouched = GetChildControl<ButtonControl>("PrimaryTouch");
            triggerPressed = GetChildControl<ButtonControl>("TriggerButton");

            trackingState = GetChildControl<IntegerControl>("trackingState");
            isTracked = GetChildControl<ButtonControl>("isTracked");
            devicePosition = GetChildControl<Vector3Control>("devicePosition");
            deviceRotation = GetChildControl<QuaternionControl>("deviceRotation");

        }

    }

}
#endif