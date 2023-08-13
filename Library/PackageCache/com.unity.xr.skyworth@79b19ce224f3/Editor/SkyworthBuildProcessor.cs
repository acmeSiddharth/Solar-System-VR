using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Android;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using UnityEditor.XR.Management;
using UnityEngine.XR.Management;

namespace Unity.XR.Skyworth.Editor {

    public class SkyworthBuildProcessor : XRBuildHelper<SkyworthSettings>
    {
        public override string BuildSettingsKey => SkyworthSettings.BuildSettingsKey;
    }
    public static class SkyworthBuildTools
    {
        public static bool SkyworthLoaderPresentInSettingsForBuildTarget(BuildTargetGroup btg)
        {
            var generalSettingsForBuildTarget = XRGeneralSettingsPerBuildTarget.XRGeneralSettingsForBuildTarget(btg);
            if (!generalSettingsForBuildTarget)
                return false;
            var settings = generalSettingsForBuildTarget.AssignedSettings;
            if (!settings)
                return false;

            bool loaderFound = false;
#if XR_MGMT_GTE_401
            for (int i = 0; i < settings.activeLoaders.Count; ++i)
            {
                if (settings.activeLoaders[i] as SkyworthLoader != null)
                {
                    loaderFound = true;
                    break;
                }
            }
#else
            loaderFound = true;
#endif
            return loaderFound;
        }

        public static SkyworthSettings GetSettings()
        {
            SkyworthSettings settings = null;
#if UNITY_EDITOR
            UnityEditor.EditorBuildSettings.TryGetConfigObject<SkyworthSettings>("Unity.XR.Skyworth.SkyworthSettings", out settings);
#else
            settings = SkyworthSettings.s_RuntimeInstance;
#endif
            return settings;
        }
    }
    //#if UNITY_ANDROID
    internal class SkyworthManifest : IPostGenerateGradleAndroidProject
    {
        static readonly string k_AndroidURI = "http://schemas.android.com/apk/res/android";
        static readonly string k_AndroidManifestPath = "/src/main/AndroidManifest.xml";
        //static readonly string k_AndroidProGuardPath = "/proguard-unity.txt";

        void UpdateOrCreateAttributeInTag(XmlDocument doc, string parentPath, string tag, string name, string value)
        {
            var xmlNode = doc.SelectSingleNode(parentPath + "/" + tag);

            if (xmlNode != null)
            {
                ((XmlElement)xmlNode).SetAttribute(name, k_AndroidURI, value);
            }
        }

        void UpdateOrCreateNameValueElementsInTag(XmlDocument doc, string parentPath, string tag,
            string firstName, string firstValue, string secondName, string secondValue)
        {
            var xmlNodeList = doc.SelectNodes(parentPath + "/" + tag);

            foreach (XmlNode node in xmlNodeList)
            {
                var attributeList = ((XmlElement)node).Attributes;

                foreach (XmlAttribute attrib in attributeList)
                {
                    if (attrib.Value == firstValue)
                    {
                        XmlAttribute valueAttrib = attributeList[secondName, k_AndroidURI];
                        if (valueAttrib != null)
                        {
                            valueAttrib.Value = secondValue;
                        }
                        else
                        {
                            ((XmlElement)node).SetAttribute(secondName, k_AndroidURI, secondValue);
                        }
                        return;
                    }
                }
            }

            // Didn't find any attributes that matched, create both (or all three)
            XmlElement childElement = doc.CreateElement(tag);
            childElement.SetAttribute(firstName, k_AndroidURI, firstValue);
            childElement.SetAttribute(secondName, k_AndroidURI, secondValue);

            var xmlParentNode = doc.SelectSingleNode(parentPath);

            if (xmlParentNode != null)
            {
                xmlParentNode.AppendChild(childElement);
            }
        }

        // same as above, but don't create if the node already exists
        void CreateNameValueElementsInTag(XmlDocument doc, string parentPath, string tag,
            string firstName, string firstValue, string secondName = null, string secondValue = null, string thirdName = null, string thirdValue = null)
        {
            var xmlNodeList = doc.SelectNodes(parentPath + "/" + tag);

            // don't create if the firstValue matches
            foreach (XmlNode node in xmlNodeList)
            {
                foreach (XmlAttribute attrib in node.Attributes)
                {
                    if (attrib.Value == firstValue)
                    {
                        return;
                    }
                }
            }

            XmlElement childElement = doc.CreateElement(tag);
            childElement.SetAttribute(firstName, k_AndroidURI, firstValue);

            if (secondValue != null)
            {
                childElement.SetAttribute(secondName, k_AndroidURI, secondValue);
            }

            if (thirdValue != null)
            {
                childElement.SetAttribute(thirdName, k_AndroidURI, thirdValue);
            }

            var xmlParentNode = doc.SelectSingleNode(parentPath);

            if (xmlParentNode != null)
            {
                xmlParentNode.AppendChild(childElement);
            }
        }

        void RemoveNameValueElementInTag(XmlDocument doc, string parentPath, string tag, string name, string value)
        {
            var xmlNodeList = doc.SelectNodes(parentPath + "/" + tag);

            foreach (XmlNode node in xmlNodeList)
            {
                var attributeList = ((XmlElement)node).Attributes;

                foreach (XmlAttribute attrib in attributeList)
                {
                    if (attrib.Name == name && attrib.Value == value)
                    {
                        node.ParentNode?.RemoveChild(node);
                    }
                }
            }
        }

       

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            if (!SkyworthBuildTools.SkyworthLoaderPresentInSettingsForBuildTarget(BuildTargetGroup.Android))
                return;

            var manifestPath = path + k_AndroidManifestPath;
            var manifestDoc = new XmlDocument();
            manifestDoc.Load(manifestPath);

            var sdkVersion = (int)PlayerSettings.Android.minSdkVersion;

            UpdateOrCreateAttributeInTag(manifestDoc, "/", "manifest", "installLocation", "auto");

            var nodePath = "/manifest/application";
            UpdateOrCreateNameValueElementsInTag(manifestDoc, nodePath, "meta-data", "name", "com.softwinner.vr.mode", "value", "vr");


            nodePath = "/manifest/application";
            UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "activity", "screenOrientation", "landscape");
            UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "activity", "theme", "@android:style/Theme.Black.NoTitleBar.Fullscreen");

            var configChangesValue = "keyboard|keyboardHidden|navigation|orientation|screenLayout|screenSize|uiMode|mcc|mnc|locale|touchscreen|smallestScreenSize|layoutDirection|fontScale";
            configChangesValue = ((sdkVersion >= 24) ? configChangesValue + "|density" : configChangesValue);
            UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "activity", "configChanges", configChangesValue);

            if (sdkVersion >= 24)
            {
                UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "activity", "resizeableActivity", "false");
            }

            UpdateOrCreateAttributeInTag(manifestDoc, nodePath, "activity", "launchMode", "singleTask");

            nodePath = "/manifest";
            CreateNameValueElementsInTag(manifestDoc, nodePath, "uses-feature", "name", "android.software.vr.mode");

            CreateNameValueElementsInTag(manifestDoc, nodePath, "uses-feature", "name", "android.software.vr.ignore.home", "required", SkyworthBuildTools.GetSettings().m_IgnoreHome ? "true" : "false");
            nodePath = "/manifest";
            CreateNameValueElementsInTag(manifestDoc, nodePath, "uses-permission", "name", "android.permission.QUERY_ALL_PACKAGES");
            manifestDoc.Save(manifestPath);
        }

        public int callbackOrder { get { return 10000; } }

        void DebugPrint(XmlDocument doc)
        {
            var sw = new System.IO.StringWriter();
            var xw = XmlWriter.Create(sw);
            doc.Save(xw);
            Debug.Log(sw);
        }
    }
//#endif
}

