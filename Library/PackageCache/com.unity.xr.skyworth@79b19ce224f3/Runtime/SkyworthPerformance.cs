using System;
using System.Runtime.InteropServices;

namespace Unity.XR.SDK
{
    public static class SkyworthPerformance
    {
        private const string pluginName = "SkyworthXRPlugin";
        [DllImport(pluginName)]
        public static extern void RecentXYZ();
    }
}
