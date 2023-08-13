using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Unity.XR.Skyworth.Editor
{
    [CustomEditor(typeof(SkyworthSettings))]
    public class SkyworthSettingsEditor : UnityEditor.Editor
    {
        private const string kStereoRenderingModeAndroid = "m_StereoRenderingModeAndroid";
        private const string kSystemSplash = "m_SystemSplash";
        private const string kIgnoreHome = "m_IgnoreHome";

        static GUIContent s_StereoRenderingMode = EditorGUIUtility.TrTextContent("Stereo Rendering Mode");
        static GUIContent s_DeviceTypeMode = EditorGUIUtility.TrTextContent("System Splash");
        static GUIContent s_IgnoreHome = EditorGUIUtility.TrTextContent("Ignore Home");


        private SerializedProperty m_StereoRenderingModeAndroid;
        private SerializedProperty m_SystemSplash;
        private SerializedProperty m_IgnoreHome;
        public override void OnInspectorGUI()
        {
            if (serializedObject == null || serializedObject.targetObject == null)
                return;


            if (m_StereoRenderingModeAndroid == null) m_StereoRenderingModeAndroid = serializedObject.FindProperty(kStereoRenderingModeAndroid);
            if (m_SystemSplash == null) m_SystemSplash = serializedObject.FindProperty(kSystemSplash);
            if (m_IgnoreHome == null) m_IgnoreHome = serializedObject.FindProperty(kIgnoreHome);

            serializedObject.Update();

            BuildTargetGroup selectedBuildTargetGroup = EditorGUILayout.BeginBuildTargetSelectionGrouping();
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                EditorGUILayout.HelpBox("Skyworth settings cannnot be changed when the editor is in play mode.", MessageType.Info);
                EditorGUILayout.Space();
            }
            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            if (selectedBuildTargetGroup == BuildTargetGroup.Android)
            {
                EditorGUILayout.PropertyField(m_StereoRenderingModeAndroid, s_StereoRenderingMode);
                EditorGUILayout.PropertyField(m_SystemSplash, s_DeviceTypeMode);
                EditorGUILayout.PropertyField(m_IgnoreHome, s_IgnoreHome);
            }
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndBuildTargetSelectionGrouping();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
