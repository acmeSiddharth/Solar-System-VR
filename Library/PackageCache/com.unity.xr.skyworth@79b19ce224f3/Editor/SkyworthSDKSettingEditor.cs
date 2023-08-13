using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using System;
using UnityEditor.XR.Management;

[InitializeOnLoad]
public class SkyworthSDKSettingEditor : EditorWindow
{
    public static SkyworthSDKSettingEditor window;
    const BuildTarget recommended_BuildTarget = BuildTarget.Android;
    const UIOrientation recommended_UIOrientation = UIOrientation.LandscapeLeft;
    const string recommended_loader = "Skyworth";

    const string ignore = "ignore.";
    const string useRecommended = "Use recommended ({0})";
    const string currentValue = " (current = {0})";

    const string buildTarget = "Build Target";
    const string Orientation = "Default Orientation";
    const string graphicApis = "Auto Graphcis API";
    const string internetaccess = "Internet Access";
    const string SDCardPermission = "Write Permission";
    const string xrloader = "Plug-in Providers";
    static SkyworthSDKSettingEditor()
    {
        EditorApplication.update += Update;
    }

    static void Update()
    {
#if UNITY_2019_4_OR_NEWER
        bool forceshow = false;
#else
        bool forceshow = true;
#endif
        bool show = (!EditorPrefs.HasKey(ignore + buildTarget) && EditorUserBuildSettings.activeBuildTarget != recommended_BuildTarget)
            || (!EditorPrefs.HasKey(ignore + Orientation) && PlayerSettings.defaultInterfaceOrientation != recommended_UIOrientation)
            || (!EditorPrefs.HasKey(ignore + graphicApis) && !PlayerSettings.GetUseDefaultGraphicsAPIs(BuildTarget.Android))
            || (!EditorPrefs.HasKey(ignore + internetaccess) && !PlayerSettings.Android.forceInternetPermission)
              || (!EditorPrefs.HasKey(ignore + SDCardPermission) && !PlayerSettings.Android.forceSDCardPermission)
            || forceshow;
        if(show)
            ShowSettingWindow();

        EditorApplication.update -= Update;
    }

    private static void ShowSettingWindow()
    {
        if (window != null)
            return;
        window  = GetWindowWithRect<SkyworthSDKSettingEditor>(new Rect { width = 320, height = 440 }, true, "Skyworth SDK Setting");
    }
    void OnGUI() 
    {
        EditorGUILayout.HelpBox("Recommended project settings for SkyworthVR:", MessageType.Warning);
        GUIVersion();
        GUIPlatform();
        GUIOrientation();
        GUIGraphicAPI();
        GUIInternect();
        GUISDCardPermission();
        //GUISkyworthLoader();

        GUICleanAll();
        GUIAcceptAll();
    }
    private void GUIVersion() 
    {
        GUILayout.Label("Support Unity Version: Unity2019.4 and above");
#if UNITY_2019_4_OR_NEWER
#else
        EditorGUILayout.HelpBox("The current version is not supported", MessageType.Error);
#endif
    }
    private void GUIPlatform()
    {
        GUILayout.Label(buildTarget + string.Format(currentValue, EditorUserBuildSettings.activeBuildTarget));
        if (EditorUserBuildSettings.activeBuildTarget == recommended_BuildTarget) return;
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(string.Format(useRecommended, recommended_BuildTarget)))
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, recommended_BuildTarget);
        }

        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Ignore"))
        {
            EditorPrefs.SetBool(ignore + buildTarget, true);
        }

        GUILayout.EndHorizontal();
    }
    private void GUIOrientation()
    {
        GUILayout.Label(Orientation + string.Format(currentValue, PlayerSettings.defaultInterfaceOrientation));
        if (PlayerSettings.defaultInterfaceOrientation == recommended_UIOrientation) return;
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(string.Format(useRecommended, recommended_UIOrientation)))
        {
            PlayerSettings.defaultInterfaceOrientation = recommended_UIOrientation;
        }

        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Ignore"))
        {
            EditorPrefs.SetBool(ignore + Orientation, true);
        }

        GUILayout.EndHorizontal();
    }
    private void GUIGraphicAPI()
    {
        bool isAuto = PlayerSettings.GetUseDefaultGraphicsAPIs(BuildTarget.Android);
        GUILayout.Label(graphicApis + string.Format(currentValue, isAuto ? "True" : "False"));
        
        if (isAuto) return;
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(string.Format(useRecommended, "True")))
        {
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.Android,true);
        }

        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Ignore"))
        {
            EditorPrefs.SetBool(ignore + graphicApis, true);
        }

        GUILayout.EndHorizontal();

    }
    private void GUIInternect()
    {
        bool isAuto = PlayerSettings.Android.forceInternetPermission;
        GUILayout.Label(internetaccess + string.Format(currentValue, isAuto ? "Require" : "Auto"));

        if (isAuto) return;
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(string.Format(useRecommended, "Require")))
        {
            PlayerSettings.Android.forceInternetPermission = true;
        }

        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Ignore"))
        {
            EditorPrefs.SetBool(ignore + internetaccess, true);
        }

        GUILayout.EndHorizontal();

    }
    private void GUISDCardPermission()
    {
        bool isAuto = PlayerSettings.Android.forceSDCardPermission;
        GUILayout.Label(SDCardPermission + string.Format(currentValue, isAuto ? "External(SDCard)" : "Internal"));

        if (isAuto) return;
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(string.Format(useRecommended, "External(SDCard)")))
        {
            PlayerSettings.Android.forceSDCardPermission = true;
        }

        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Ignore"))
        {
            EditorPrefs.SetBool(ignore + SDCardPermission, true);
        }

        GUILayout.EndHorizontal();

    }
    private void GUISkyworthLoader()
    {
        //var generalSettingsForBuildTarget = XRGeneralSettingsPerBuildTarget.XRGeneralSettingsForBuildTarget(BuildTargetGroup.Android);
        //if (!generalSettingsForBuildTarget)
        //    return;
        //var settings = generalSettingsForBuildTarget.AssignedSettings;
        //string current_loader = "null";
        //bool loaderFound = false;
        //for (int i = 0; i < settings.activeLoaders.Count; ++i)
        //{
        //    current_loader = settings.activeLoaders[i].name;
        //    if (settings.activeLoaders[i] as Unity.XR.Skyworth.SkyworthLoader != null)
        //    {
        //        current_loader = settings.activeLoaders[i].name;
        //        loaderFound = true;
        //        break;
        //    }
        //}

        //GUILayout.Label(xrloader + string.Format(currentValue, current_loader));
        
        ////settings.ActiveLoaderAs<Unity.XR.Skyworth.SkyworthLoader>();
        
        //if (loaderFound) return;
        //GUILayout.BeginHorizontal();
        //if (GUILayout.Button(string.Format(useRecommended, recommended_loader)))
        //{
        //    //settings.ActiveLoaderAs<Unity.XR.Skyworth.SkyworthLoader>();
        //    UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager.ActiveLoaderAs<Unity.XR.Skyworth.SkyworthLoader>();
        //}

        //GUILayout.FlexibleSpace();

        //if (GUILayout.Button("Ignore"))
        //{
        //    EditorPrefs.SetBool(ignore + xrloader, true);
        //}

        //GUILayout.EndHorizontal();
    }
    private void GUICleanAll()
    {
        GUILayout.BeginHorizontal();

        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Clear All Ignores"))
        {
            EditorPrefs.DeleteKey(ignore + buildTarget);
            EditorPrefs.DeleteKey(ignore + Orientation);
            EditorPrefs.DeleteKey(ignore + graphicApis);
            EditorPrefs.DeleteKey(ignore + internetaccess);
            EditorPrefs.DeleteKey(ignore + SDCardPermission);
        }

        GUILayout.EndHorizontal();
    }

    private void GUIAcceptAll()
    {
        GUILayout.FlexibleSpace();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Accept All")) 
        {
            if (!EditorPrefs.HasKey(ignore + buildTarget)) 
            {
                EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, recommended_BuildTarget);
            }
            if (!EditorPrefs.HasKey(ignore + Orientation)) 
            {
                PlayerSettings.defaultInterfaceOrientation = recommended_UIOrientation;
            }
            if (!EditorPrefs.HasKey(ignore + graphicApis))
            {
                PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.Android, true);
            }
            if (!EditorPrefs.HasKey(ignore + internetaccess))
            {
                PlayerSettings.Android.forceInternetPermission = true;
            }
            if (!EditorPrefs.HasKey(ignore + SDCardPermission))
            {
                PlayerSettings.Android.forceSDCardPermission = true;
            }

            EditorUtility.DisplayDialog("Accept All", "You made the right choice!", "Ok");
            Close();
        }
        if (GUILayout.Button("Ignore All"))
        {
            if (EditorUtility.DisplayDialog("Ignore All", "Are you sure?", "Yes, Ignore All", "Cancel"))
            {
                if (EditorUserBuildSettings.activeBuildTarget != recommended_BuildTarget)
                {
                    EditorPrefs.SetBool(ignore + buildTarget, true);
                }
                if (PlayerSettings.defaultInterfaceOrientation != recommended_UIOrientation)
                {
                    EditorPrefs.SetBool(ignore + Orientation, true);
                }
                if (!PlayerSettings.GetUseDefaultGraphicsAPIs(BuildTarget.Android))
                {
                    EditorPrefs.SetBool(ignore + graphicApis, true);
                }
                if (!PlayerSettings.Android.forceInternetPermission) 
                {
                    EditorPrefs.SetBool(ignore + internetaccess, true);
                }
                if (!PlayerSettings.Android.forceSDCardPermission)
                {
                    EditorPrefs.SetBool(ignore + SDCardPermission, true);
                }
                Close();
            }
        }
        GUILayout.EndHorizontal();
    }
}
