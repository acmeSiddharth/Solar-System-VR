#if XR_MGMT_GTE_320

using System.Collections.Generic;
using UnityEditor;
using UnityEditor.XR.Management.Metadata;
using UnityEngine;

namespace Unity.XR.Skyworth.Editor
{
    internal class SkyworthMetadata : IXRPackage
    {
        private class SkyworthPackageMetadata : IXRPackageMetadata
        {
            public string packageName => "Skyworth XR Plugin";
            public string packageId => "com.unity.xr.skyworth";
            public string settingsType => "Unity.XR.Skyworth.SkyworthSettings";
            public List<IXRLoaderMetadata> loaderMetadata => s_LoaderMetadata;

            private readonly static List<IXRLoaderMetadata> s_LoaderMetadata = new List<IXRLoaderMetadata>() { new SkyworthLoaderMetadata() };
        }

        private class SkyworthLoaderMetadata : IXRLoaderMetadata
        {
            public string loaderName => "Skyworth";
            public string loaderType => "Unity.XR.Skyworth.SkyworthLoader";
            public List<BuildTargetGroup> supportedBuildTargets => s_SupportedBuildTargets;

            private readonly static List<BuildTargetGroup> s_SupportedBuildTargets = new List<BuildTargetGroup>()
            {
                BuildTargetGroup.Standalone,
                BuildTargetGroup.Android
            };
        }

        private static IXRPackageMetadata s_Metadata = new SkyworthPackageMetadata();
        public IXRPackageMetadata metadata => s_Metadata;

        public bool PopulateNewSettingsInstance(ScriptableObject obj)
        {
            var settings = obj as SkyworthSettings;
            if (settings != null)
            {
                settings.m_StereoRenderingModeAndroid = SkyworthSettings.StereoRenderingModeAndroid.SinglePassInstanced;
                settings.m_SystemSplash = true;
                settings.m_IgnoreHome = false;
                return true;
            }
            return false;
        }
    }
}

#endif // XR_MGMT_GTE_320
