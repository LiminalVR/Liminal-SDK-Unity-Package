﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IssuesUtility
{
    public static Dictionary<string, string> IncompatiblePackagesTable = new Dictionary<string, string>()
    {
        {"Unity.Postprocessing.Runtime","Post Processing"},
        {"FluffyUnderware.Curvy","Curvy"},
        {"DOTween","DOTween"}
    };

    //key is the function call in IL code, value is what the IL code translates into
    public static Dictionary<string, string> ForbiddenFunctionCalls = new Dictionary<string, string>()
    {
        { "4040010","Application.Quit()"},
        { "01124","SceneManager.LoadScene()"},
        { "060010z","DontDestroyOnLoad();"}
    };



    public static List<string> AssembliesToIgnore = new List<string>()
    {
        "mscorlib",
        "UnityEngine",
        "UnityEngine.AIModule",
        "UnityEngine.ARModule",
        "UnityEngine.AccessibilityModule",
        "UnityEngine.AnimationModule",
        "UnityEngine.AssetBundleModule",
        "UnityEngine.AudioModule",
        "UnityEngine.ClothModule",
        "UnityEngine.ClusterInputModule",
        "UnityEngine.ClusterRendererModule",
        "UnityEngine.CoreModule",
        "UnityEngine.CrashReportingModule",
        "UnityEngine.DirectorModule",
        "UnityEngine.FileSystemHttpModule",
        "UnityEngine.GameCenterModule",
        "UnityEngine.GridModule",
        "UnityEngine.HotReloadModule",
        "UnityEngine.IMGUIModule",
        "UnityEngine.ImageConversionModule",
        "UnityEngine.InputModule",
        "UnityEngine.JSONSerializeModule",
        "UnityEngine.LocalizationModule",
        "UnityEngine.ParticleSystemModule",
        "UnityEngine.PerformanceReportingModule",
        "UnityEngine.PhysicsModule",
        "UnityEngine.Physics2DModule",
        "UnityEngine.ProfilerModule",
        "UnityEngine.ScreenCaptureModule",
        "UnityEngine.SharedInternalsModule",
        "UnityEngine.SpriteMaskModule",
        "UnityEngine.SpriteShapeModule",
        "UnityEngine.StreamingModule",
        "UnityEngine.StyleSheetsModule",
        "UnityEngine.SubstanceModule",
        "UnityEngine.TLSModule",
        "UnityEngine.TerrainModule",
        "UnityEngine.TerrainPhysicsModule",
        "UnityEngine.TextCoreModule",
        "UnityEngine.TextRenderingModule",
        "UnityEngine.TilemapModule",
        "UnityEngine.UIModule",
        "UnityEngine.UIElementsModule",
        "UnityEngine.UNETModule",
        "UnityEngine.UmbraModule",
        "UnityEngine.UnityAnalyticsModule",
        "UnityEngine.UnityConnectModule",
        "UnityEngine.UnityTestProtocolModule",
        "UnityEngine.UnityWebRequestModule",
        "UnityEngine.UnityWebRequestAssetBundleModule",
        "UnityEngine.UnityWebRequestAudioModule",
        "UnityEngine.UnityWebRequestTextureModule",
        "UnityEngine.UnityWebRequestWWWModule",
        "UnityEngine.VFXModule",
        "UnityEngine.VRModule",
        "UnityEngine.VehiclesModule",
        "UnityEngine.VideoModule",
        "UnityEngine.WindModule",
        "UnityEngine.XRModule",
        "UnityEditor",
        "Unity.Locator",
        "System.Core","System",
        "Mono.Security",
        "System.Configuration",
        "System.Xml",
        "Unity.Cecil","Unity.DataContract",
        "Unity.PackageManager",
        "UnityEngine.UI",
        "UnityEditor.UI",
        "UnityEditor.TestRunner",
        "UnityEngine.TestRunner",
        "nunit.framework",
        "UnityEditor.VR",
        "UnityEditor.Graphs",
        "UnityEditor.WindowsStandalone.Extensions",
        "UnityEditor.Android.Extensions",
        "SyntaxTree.VisualStudio.Unity.Bridge",
        "Unity.Timeline.Editor",
        "Editor",
        "SteamVR_Actions",
        "Platform",
        "Unity.TextMeshPro.Editor",
        "Unity.Timeline",
        "Tests",
        "Unity.CollabProxy.Editor",
        "UnityEngine.XR.LegacyInputHelpers",
        "Oculus.VR.Editor",
        "Oculus.VR.Scripts.Editor",
        "External",
        "Examples",
        "LiminalSdk","Oculus.VR",
        "UnityEditor.SpatialTracking",
        "UnityEngine.SpatialTracking",
        "SteamVR_Input_Editor",
        "SteamVR_Editor","SteamVR","Unity.TextMeshPro",
        "Unity.Analytics.DataPrivacy",
        "UnityEditor.XR.LegacyInputHelpers",
        "SteamVR_Windows_EditorHelper",
        "Google.ProtocolBuffers",
        "Liminal.Cecil",
        "Newtonsoft.Json",
        "SevenZip",
        "GVR","Liminal.SDK",
        "Liminal.SDK.VR.Daydream",
        "GVR.Editor",
        "Valve.Newtonsoft.Json",
        "Unity.Analytics.Editor",
        "Unity.Analytics.StandardEvents",
        "Unity.Analytics.Tracker",
        "UnityEditor.Purchasing",
        "netstandard",
        "System.Runtime.Serialization",
        "System.Xml.Linq",
        "SyntaxTree.VisualStudio.Unity.Messaging",
        "Unity.IvyParser",
        "Unity.SerializationLogic",
        "Unity.Legacy.NRefactory",
        "ExCSS.Unity","Microsoft.GeneratedCode",
        "Microsoft.GeneratedCode",
        "Microsoft.GeneratedCode",
        "Microsoft.GeneratedCode",
        "Microsoft.GeneratedCode",
        "System.ServiceModel.Internals"
    };
}
