using System;

using UnityEngine;
using UnityEngine.XR.Management;

namespace Unity.XR.Skyworth
{
    [XRConfigurationData("Skyworth", SkyworthSettings.BuildSettingsKey)]
    public class SkyworthSettings : ScriptableObject
    {
        public const string BuildSettingsKey = "Unity.XR.Skyworth.SkyworthSettings";

        public enum StereoRenderingModeAndroid
        {
            /// <summary>
            /// Submit one draw call for both eyes.
            /// </summary>
            SinglePassInstanced,
            /// <summary>
            /// Submit separate draw calls for each eye.
            /// </summary>
            MultiPass
            
        }

        

        /// <summary>
        /// Stereo rendering mode.
        /// </summary>
        [SerializeField, Tooltip("Set the Stereo Rendering Method")]
        public StereoRenderingModeAndroid m_StereoRenderingModeAndroid;
        /// <summary>
        /// Whether to use the startup animation of the system
        /// </summary>
        [SerializeField, Tooltip("Whether to use the startup animation of the system")]
        public bool m_SystemSplash;
        /// <summary>
        /// Set true can ignore home key,otherwise press home key button will back to home
        /// </summary>
        [SerializeField, Tooltip("Set true can ignore home key,otherwise press home key button will back to home")]
        public bool m_IgnoreHome;

        public static SkyworthSettings Instance
        {
            get
            {
                SkyworthSettings settings = null;
#if UNITY_EDITOR
                UnityEngine.Object obj = null;
                UnityEditor.EditorBuildSettings.TryGetConfigObject(BuildSettingsKey, out obj);
                if (obj == null || !(obj is SkyworthSettings))
                    return null;
                settings = (SkyworthSettings) obj;
#else
                settings = s_RuntimeInstance;
                if (settings == null)
                    settings = ScriptableObject.CreateInstance<SkyworthSettings>();
#endif
                return settings;
            }
        }

#if !UNITY_EDITOR
        /// <summary>Static instance that will hold the runtime asset instance we created in our build process.</summary>
        public static SkyworthSettings s_RuntimeInstance = null;

        void Awake()
        {
            //Debug.Log("SkyworthSettings.Awake");
            s_RuntimeInstance = this;
        }
        void OnEnable()
        {
            //Debug.Log("SkyworthSettings.OnEnable");
        }
#endif

    }
}
