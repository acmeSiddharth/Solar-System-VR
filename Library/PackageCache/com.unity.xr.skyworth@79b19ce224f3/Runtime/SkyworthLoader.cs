using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using UnityEditor;
#if UNITY_INPUT_SYSTEM
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;
using Unity.XR.Skyworth.Input;
#endif

namespace Unity.XR.Skyworth
{
#if UNITY_INPUT_SYSTEM
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    static class InputLayoutLoader
    {
        static InputLayoutLoader()
        {
            RegisterInputLayouts();
        }

        public static void RegisterInputLayouts()
        {
            InputSystem.RegisterLayout<SkyworthHMD>(
                matches: new InputDeviceMatcher()
                    .WithInterface(XRUtilities.InterfaceMatchAnyVersion)
                    .WithProduct("^(Skyworth HMD)"));
            InputSystem.RegisterLayout<SkyworthTouchController>(
                matches: new InputDeviceMatcher()
                    .WithInterface(XRUtilities.InterfaceMatchAnyVersion)
                    .WithManufacturer("^(Skyworth Touch Controller)"));
        }
    }
#endif

    public class SkyworthLoader : XRLoaderHelper
    {
#if UNITY_ANDROID
        private AndroidJavaObject androidActivity;
#endif
        private static List<XRDisplaySubsystemDescriptor> s_DisplaySubsystemDescriptors =
            new List<XRDisplaySubsystemDescriptor>();
        private static List<XRInputSubsystemDescriptor> s_InputSubsystemDescriptors =
            new List<XRInputSubsystemDescriptor>();
        public XRDisplaySubsystem displaySubsystem => GetLoadedSubsystem<XRDisplaySubsystem>();
        public XRDisplaySubsystem inputSubsystem => GetLoadedSubsystem<XRDisplaySubsystem>();
        public override bool Initialize()
        {
#if UNITY_INPUT_SYSTEM
            InputLayoutLoader.RegisterInputLayouts();
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
            try
            {
                using (AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    androidActivity = player.GetStatic<AndroidJavaObject>("currentActivity");
                }
            }
            catch (AndroidJavaException e)
            {
                androidActivity = null;
                Debug.LogError("Exception while connecting to the Activity: " + e);
            }


            SetAndroidActivity(androidActivity.GetRawObject());

            SkyworthSettings settings = GetSettings();
            if (settings != null)
            {
                UserDefinedSettings userDefinedSettings;
                userDefinedSettings.stereoRenderingMode = (ushort)settings.m_StereoRenderingModeAndroid;
                userDefinedSettings.systemsplash = settings.m_SystemSplash;
                SetUserDefinedSettings(userDefinedSettings);
            }

            CreateSubsystem<XRDisplaySubsystemDescriptor, XRDisplaySubsystem>(s_DisplaySubsystemDescriptors, "skyworth display");
            CreateSubsystem<XRInputSubsystemDescriptor, XRInputSubsystem>(s_InputSubsystemDescriptors, "skyworth input");
            if (displaySubsystem == null || inputSubsystem == null)
            {
                Debug.LogError("Unable to start Skyworth XR Plugin.");
            }

            if (displaySubsystem == null)
            {
                Debug.LogError("Failed to load display subsystem.");
            }

            if (inputSubsystem == null)
            {
                Debug.LogError("Failed to load input subsystem.");
            }
#endif
            return displaySubsystem != null && inputSubsystem != null;
        }

        
        public override bool Start()
        {
            StartSubsystem<XRDisplaySubsystem>();
            StartSubsystem<XRInputSubsystem>();

            return true;
        }

        public override bool Stop()
        {
            StopSubsystem<XRDisplaySubsystem>();
            StopSubsystem<XRInputSubsystem>();
            return true;
        }

        public override bool Deinitialize()
        {
            DestroySubsystem<XRDisplaySubsystem>();
            DestroySubsystem<XRInputSubsystem>();
            return true;
        }
		private const string pluginName = "SkyworthXRPlugin";
        [DllImport(pluginName)]
        private static extern void SetAndroidActivity(IntPtr androidActivity);
        struct UserDefinedSettings
        {
            public ushort stereoRenderingMode;
            public bool systemsplash;
        }
        [DllImport(pluginName, CallingConvention = CallingConvention.Cdecl)]
        static extern void SetUserDefinedSettings(UserDefinedSettings settings);
        public SkyworthSettings GetSettings()
        {
            SkyworthSettings settings = null;
#if UNITY_EDITOR
            UnityEditor.EditorBuildSettings.TryGetConfigObject<SkyworthSettings>("Unity.XR.Skyworth.SkyworthSettings", out settings);
#else
            settings = SkyworthSettings.Instance;
#endif
            return settings;
        }
    }
}
