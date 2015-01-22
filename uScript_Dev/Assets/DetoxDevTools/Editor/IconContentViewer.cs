// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IconContentViewer.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Based on a free editor script by Zack Aikman called "EditorIconViewer".
//      https://github.com/zaikman/UnityPublic/blob/master/EditorIconViewer.cs
//
//   Like all code under the DetoxDevTools folder, this script is not distributed to the public.
//   It's included in the project for development use only.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Detox.Editor;

using UnityEditor;

using UnityEngine;

public sealed class IconContentViewer : EditorWindow
{
   private const float SidePanelMinWidth = 150;

   private const float SidePanelMaxWidth = 250;

   private const float ScrollbarWidth = 15;

   private const float SelectionGridPadding = 10;

   private const string UsageString =
      "All of the icons presented in this collection are easily accessible when writing a custom editor script, for both Inspectors and Editor Windows. "
      + "In the OnEnable method of your editor, obtain a copy of the editor's skin with the following:\n\n"
      + "GUISkin _editorSkin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);\n\n"
      + "Textures shown in this tool can be retrieved by using their style names, shown at the top of the left-hand panel when you select an icon from the grid. For example:\n\n"
      + "GUILayout.Button(_editorSkin.GetStyle(\"MeTransPlayhead\").normal.background);\n\n"
      + "Or you can simply use the style itself when rendering a control:\n\n"
      + "GUILayout.Button(\"\", _editorSkin.GetStyle(\"MeTransPlayhead\"));\n\n"
      + "If additional style states are available (such as Focused, Hover, or Active), they will appear in the panel when selected.";

   // Icons are categorized by their height, into buckets defined by
   // the two arrays below. The number of thresholds should always exceed
   // the number of group names by one.
   private static readonly float[] IconThresholds = { 0, 9, 25, 35, 100, 99999 };

   private static readonly string[] IconGroupNames = { "Mini", "Small", "Medium", "Large", "X-Large" };

   private List<IconGroup> iconGroups;

   private GUISkin editorSkin;
   private GUIStyle selectedIcon;
   private Vector2 scrollPos;
   private float drawScale;

   private Texture2D blackTexture;
   private Texture2D whiteTexture;
   private string grabName;
   private Rect grabRect;
   private bool shouldGrab;
   private Rect viewportRect;

   [MenuItem("uScript/Internal/Content Icon Viewer")]
   internal static void Init()
   {
      var window = GetWindow<IconContentViewer>(true, "Content Icons");
      window.position = new Rect(150, 150, 700, 400);
   }

   internal void OnEnable()
   {
      var iconContent = GetIconNames();

      this.editorSkin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);
      this.scrollPos = Vector2.zero;
      SetSelectedIcon(null);

      iconGroups = new List<IconGroup>();

      for (var i = 0; i < IconGroupNames.Length; ++i)
      {
         var group = new IconGroup();
         group.Name = IconGroupNames[i];

         var minHeight = IconThresholds[i];
         var maxHeight = IconThresholds[i + 1];

         var styles = new List<GUIStyle>();

         foreach (var key in iconContent)
         {
            var icon = GetTexture(key);
            if (icon == null)
            {
               continue;
            }

            if (icon.height > minHeight && icon.height <= maxHeight)
            {
               var st = new GUIStyle { normal = { background = icon }, name = key };
               styles.Add(st);
            }
         }
         group.IconData = styles.OrderBy(style => style.normal.background.height).ToArray();

         var maxWidth = @group.IconData.Aggregate<GUIStyle, float>(0, (current, style) => (style.normal.background.width > current) ? style.normal.background.width : current);
         group.MaxWidth = maxWidth;

         iconGroups.Add(group);
      }

      blackTexture = new Texture2D(1, 1);
      blackTexture.SetPixel(0, 0, Color.black);
      blackTexture.Apply();

      whiteTexture = new Texture2D(1, 1);
      whiteTexture.SetPixel(0, 0, Color.white);
      whiteTexture.Apply();
   }

   internal void OnDisable()
   {
      DestroyImmediate(blackTexture);
      DestroyImmediate(whiteTexture);
   }

   internal void OnGUI()
   {
      var sidePanelWidth = CalculateSidePanelWidth();
      GUILayout.BeginArea(new Rect(0, 0, sidePanelWidth, position.height), GUI.skin.box);
      DrawIconDisplay(this.selectedIcon);
      GUILayout.EndArea();

      GUI.BeginGroup(new Rect(sidePanelWidth, 0, position.width - sidePanelWidth, position.height));
      this.scrollPos = GUILayout.BeginScrollView(this.scrollPos, true, true, GUILayout.MaxWidth(position.width - sidePanelWidth));

      for (var i = 0; i < iconGroups.Count; ++i)
      {
         var group = iconGroups[i];
         EditorGUILayout.LabelField(group.Name);
         DrawIconSelectionGrid(group.IconData, group.MaxWidth);

         GUILayout.Space(15);
      }

      GUILayout.EndScrollView();
      GUI.EndGroup();
   }

   private static Texture2D GetTexture(string name)
   {
#if UNITY_3_5
      var mi = typeof(EditorGUIUtility).GetMethod(
         "IconContent",
         BindingFlags.NonPublic | BindingFlags.Static,
         null,
         new[] { typeof(string) },
         null);
      if (mi != null)
      {
         return ((GUIContent)mi.Invoke(null, new object[] { name })).image as Texture2D;
      }

      uScriptDebug.Log("Could not reflect EditorGUIUtility.IconContent()");
      return null;
#else
      // NOTE: Unity 5 borks, because is somehow includes a string with 3 tabs in its internal content list.
      if (name == "\t\t\t")
      {
         return null;
      }

      return EditorGUIUtility.IconContent(name).image as Texture2D;
#endif
   }

   private static string GeneratePath(string name)
   {
      var path = uScriptConfig.ConstantPaths.Screenshots;
      Directory.CreateDirectory(path);

      var filePath = string.Format("{0}/{1}", path, string.IsNullOrEmpty(name) ? "ICON" : name);
      var testPath = string.Format("{0}.png", filePath);

      var i = 0;
      while (File.Exists(testPath))
      {
         testPath = string.Format("{0} ({1}).png", filePath, ++i);
      }

      return testPath;
   }
   
   private static List<string> GetIconNames()
   {
      var names = new List<string>
                     {
                        "AboutWindow.MainHeader",
                        "AgeiaLogo",
                        "Animation.AddEvent",
                        "Animation.AddKeyframe",
                        "Animation.EventMarker",
                        "Animation.NextKey",
                        "Animation.Play",
                        "Animation.PrevKey",
                        "Animation.Record",
                        "animationanimated",
                        "animationkeyframe",
                        "animationvisibilitytoggleoff",
                        "animationvisibilitytoggleon",
                        "AnimatorController Icon",
                        "AS Badge Delete",
                        "AS Badge Move",
                        "AS Badge New",
                        "Avatar Icon",
                        "AvatarInspector/BodyPartPicker",
                        "AvatarInspector/BodySIlhouette",
                        "AvatarInspector/BodySilhouette",
                        "AvatarInspector/DotFill",
                        "AvatarInspector/DotFrame",
                        "AvatarInspector/DotFrameDotted",
                        "AvatarInspector/DotSelection",
                        "AvatarInspector/Head",
                        "AvatarInspector/HeadZoom",
                        "AvatarInspector/HeadZoomSilhouette",
                        "AvatarInspector/LeftArm",
                        "AvatarInspector/LeftFeetIk",
                        "AvatarInspector/LeftFingers",
                        "AvatarInspector/LeftFingersIk",
                        "AvatarInspector/LeftHandZoom",
                        "AvatarInspector/LeftHandZoomSilhouette",
                        "AvatarInspector/LeftLeg",
                        "AvatarInspector/MaskEditor_Root",
                        "AvatarInspector/RightArm",
                        "AvatarInspector/RightFeetIk",
                        "AvatarInspector/RightFingers",
                        "AvatarInspector/RightFingersIk",
                        "AvatarInspector/RightHandZoom",
                        "AvatarInspector/RightHandZoomSilhouette",
                        "AvatarInspector/RightLeg",
                        "AvatarInspector/Torso",
                        "AvatarPivot",
                        "blendKey",
                        "blendKeyOverlay",
                        "blendKeySelected",
                        "blendSampler",
                        "boo Script Icon",
                        "BuildSettings.Android.Small",
                        "BuildSettings.BlackBerry.Small",
                        "BuildSettings.FlashPlayer.Small",
                        "BuildSettings.iPhone.Small",
                        "BuildSettings.Metro.Small",
                        "BuildSettings.NaCl.Small",
                        "BuildSettings.PS3.Small",
                        "BuildSettings.PS4.Small",
                        "BuildSettings.PSM.Small",
                        "BuildSettings.PSP2.Small",
                        "BuildSettings.SamsungTV.Small",
                        "BuildSettings.SelectedIcon",
                        "BuildSettings.Standalone.Small",
                        "BuildSettings.StandaloneGLESEmu.Small",
                        "BuildSettings.Tizen.Small",
                        "BuildSettings.Web.Small",
                        "BuildSettings.WP8.Small",
                        "BuildSettings.XBox360.Small",
                        "BuildSettings.XboxOne.Small",
                        "Camera Icon",
                        "Clipboard",
                        "ClothInspector.PaintTool",
                        "ClothInspector.PaintValue",
                        "ClothInspector.SelectTool",
                        "ClothInspector.SettingsTool",
                        "ClothInspector.ViewValue",
                        "ColorPicker.CycleColor",
                        "ColorPicker.CycleSlider",
                        "console.erroricon",
                        "console.erroricon.inactive.sml",
                        "console.erroricon.sml",
                        "console.infoicon",
                        "console.infoicon.sml",
                        "console.warnicon",
                        "console.warnicon.inactive.sml",
                        "console.warnicon.sml",
                        "cs Script Icon",
                        "curvekeyframe",
                        "curvekeyframeselected",
                        "curvekeyframeselectedoverlay",
                        "curvekeyframesemiselectedoverlay",
                        "EditCollider",
                        "editicon.sml",
                        "EyeDropper.Large",
                        "GameObject Icon",
                        "HorizontalSplit",
                        "Icon Dropdown",
                        "js Script Icon",
                        "lightMeter/greenLight",
                        "lightMeter/lightRim",
                        "lightMeter/orangeLight",
                        "lightMeter/redLight",
                        "MeshRenderer Icon",
                        "Mirror",
                        "MonoLogo",
                        "MoveTool On",
                        "MoveTool",
                        "PauseButton Anim",
                        "PauseButton On",
                        "PauseButton",
                        "PlayButton Anim",
                        "PlayButton On",
                        "PlayButton",
                        "PlayButtonProfile Anim",
                        "PlayButtonProfile On",
                        "PlayButtonProfile",
                        "preAudioAutoPlayOff",
                        "preAudioAutoPlayOn",
                        "preAudioLoopOff",
                        "preAudioLoopOn",
                        "preAudioPlayOff",
                        "preAudioPlayOn",
                        "Prefab Icon",
                        "PrefabModel Icon",
                        "PrefabNormal Icon",
                        "PreMatCube",
                        "PreMatCylinder",
                        "PreMatLight0",
                        "PreMatLight1",
                        "PreMatSphere",
                        "PreMatTorus",
                        "PreTextureAlpha",
                        "PreTextureMipMapHigh",
                        "PreTextureMipMapLow",
                        "PreTextureRGB",
                        "Profiler.Audio",
                        "Profiler.NextFrame",
                        "Profiler.PrevFrame",
                        "RectTool On",
                        "RectTool",
                        "RectTransformBlueprint",
                        "RectTransformRaw",
                        "Refresh",
                        "RotateTool On",
                        "RotateTool",
                        "ScaleTool On",
                        "ScaleTool",
                        "SceneviewAudio",
                        "SceneviewLighting",
                        "ScriptableObject Icon",
                        "SettingsIcon",
                        "Shader Icon",
                        "SocialNetworks.FacebookShare",
                        "SocialNetworks.LinkedInShare",
                        "SocialNetworks.Tweet",
                        "SocialNetworks.UDNLogo",
                        "SocialNetworks.UDNOpen",
                        "SpeedScale",
                        "StepButton Anim",
                        "StepButton On",
                        "StepButton",
                        "sv_icon_dot0_pix16_gizmo",
                        "sv_icon_dot1_pix16_gizmo",
                        "sv_icon_dot2_pix16_gizmo",
                        "sv_icon_dot3_pix16_gizmo",
                        "sv_icon_dot4_pix16_gizmo",
                        "sv_icon_dot5_pix16_gizmo",
                        "sv_icon_dot6_pix16_gizmo",
                        "sv_icon_dot7_pix16_gizmo",
                        "sv_icon_dot8_pix16_gizmo",
                        "sv_icon_dot9_pix16_gizmo",
                        "sv_icon_dot10_pix16_gizmo",
                        "sv_icon_dot11_pix16_gizmo",
                        "sv_icon_dot12_pix16_gizmo",
                        "sv_icon_dot13_pix16_gizmo",
                        "sv_icon_dot14_pix16_gizmo",
                        "sv_icon_dot15_pix16_gizmo",
                        "sv_icon_dot0_sml",
                        "sv_icon_dot1_sml",
                        "sv_icon_dot2_sml",
                        "sv_icon_dot3_sml",
                        "sv_icon_dot4_sml",
                        "sv_icon_dot5_sml",
                        "sv_icon_dot6_sml",
                        "sv_icon_dot7_sml",
                        "sv_icon_dot8_sml",
                        "sv_icon_dot9_sml",
                        "sv_icon_dot10_sml",
                        "sv_icon_dot11_sml",
                        "sv_icon_dot12_sml",
                        "sv_icon_dot13_sml",
                        "sv_icon_dot14_sml",
                        "sv_icon_dot15_sml",
                        "sv_icon_name0",
                        "sv_icon_name1",
                        "sv_icon_name2",
                        "sv_icon_name3",
                        "sv_icon_name4",
                        "sv_icon_name5",
                        "sv_icon_name6",
                        "sv_icon_name7",
                        "sv_icon_none",
                        "sv_label_0",
                        "sv_label_1",
                        "sv_label_2",
                        "sv_label_3",
                        "sv_label_4",
                        "sv_label_5",
                        "sv_label_6",
                        "sv_label_7",
                        "Terrain Icon",
                        "TerrainInspector.TerrainToolPlants",
                        "TerrainInspector.TerrainToolRaise",
                        "TerrainInspector.TerrainToolSetHeight",
                        "TerrainInspector.TerrainToolSettings",
                        "TerrainInspector.TerrainToolSmoothHeight",
                        "TerrainInspector.TerrainToolSplat",
                        "TerrainInspector.TerrainToolTrees",
                        "TextAsset Icon",
                        "Toolbar Minus",
                        "Toolbar Plus More",
                        "Toolbar Plus",
                        "TreeEditor.AddBranches",
                        "TreeEditor.AddLeaves",
                        "TreeEditor.BranchFreeHand On",
                        "TreeEditor.BranchFreeHand",
                        "TreeEditor.BranchRotate On",
                        "TreeEditor.BranchRotate",
                        "TreeEditor.BranchTranslate On",
                        "TreeEditor.BranchTranslate",
                        "TreeEditor.Duplicate",
                        "TreeEditor.LeafRotate On",
                        "TreeEditor.LeafRotate",
                        "TreeEditor.LeafTranslate On",
                        "TreeEditor.LeafTranslate",
                        "TreeEditor.Refresh",
                        "TreeEditor.Trash",
                        "tree_icon",
                        "tree_icon_branch",
                        "tree_icon_branch_frond",
                        "tree_icon_frond",
                        "tree_icon_leaf",
                        "UnityLogo",
                        "vcs_change",
                        "vcs_document",
                        "vcs_sync",
                        "VerticalSplit",
                        "ViewToolMove On",
                        "ViewToolMove",
                        "ViewToolOrbit On",
                        "ViewToolOrbit",
                        "ViewToolZoom On",
                        "ViewToolZoom",
                        "VUMeterTextureHorizontal",
                        "VUMeterTextureVertical",
                        "WaitSpin00",
                        "WaitSpin01",
                        "WaitSpin02",
                        "WaitSpin03",
                        "WaitSpin04",
                        "WaitSpin05",
                        "WaitSpin06",
                        "WaitSpin07",
                        "WaitSpin08",
                        "WaitSpin09",
                        "WaitSpin10",
                        "WaitSpin11",
                        "WelcomeScreen.AssetStoreLogo",
                        "WelcomeScreen.MainHeader",
                        "WelcomeScreen.UnityAnswersLogo",
                        "WelcomeScreen.UnityBasicsLogo",
                        "WelcomeScreen.UnityForumLogo",
                        "WelcomeScreen.VideoTutLogo",
                        "_Help",
                        "_Popup"
                     };

      names.AddRange(ReflectHashtable("s_IconGUIContents").Where(x => !names.Contains(x)).ToList());
      names.AddRange(ReflectHashtable("s_ScriptInfos").Where(x => !names.Contains(x)).ToList());
      return names;
   }

   private static List<string> GetKnownBadNames()
   {
      return new List<string>
                {
                   "AndroidKeystore.Alias",
                   "AndroidKeystore.City",
                   "AndroidKeystore.Country",
                   "AndroidKeystore.CreateKey",
                   "AndroidKeystore.CreateNewKey",
                   "AndroidKeystore.EnterKeyalias",
                   "AndroidKeystore.EnterPassword",
                   "AndroidKeystore.EnterValidityTime",
                   "AndroidKeystore.KeyCreation",
                   "AndroidKeystore.KeyliasExists",
                   "AndroidKeystore.MaxValidityTime",
                   "AndroidKeystore.Name",
                   "AndroidKeystore.NoCertData",
                   "AndroidKeystore.Organization",
                   "AndroidKeystore.OrgUnit",
                   "AndroidKeystore.PassConfirm",
                   "AndroidKeystore.Password",
                   "AndroidKeystore.PasswordsDontMatch",
                   "AndroidKeystore.PasswordTooShort",
                   "AndroidKeystore.RecommendedValidityTime",
                   "AndroidKeystore.State",
                   "AndroidKeystore.Validity",
                   "AnimatableMaterialUtility.Title",
                   "Animation.ShowAllPropertiesOff",
                   "Animation.ShowAllPropertiesOn",
                   "Animation.ShowEvents",
                   "AnimationClipEditor.BakeIntoPoseOrientation",
                   "AnimationClipEditor.BakeIntoPosePositionXZ",
                   "AnimationClipEditor.BakeIntoPosePositionY",
                   "AnimationClipEditor.BasedUponOrientation",
                   "AnimationClipEditor.BasedUponPosition.RootNodePosition",
                   "AnimationClipEditor.BasedUponPositionHuman.CenterOfMass",
                   "AnimationClipEditor.BasedUponPositionXZ",
                   "AnimationClipEditor.BasedUponPositionXZ.Original",
                   "AnimationClipEditor.BasedUponPositionY",
                   "AnimationClipEditor.BasedUponPositionY.Original",
                   "AnimationClipEditor.BasedUponPositionYHuman.Feet",
                   "AnimationClipEditor.BasedUponRotation.Original",
                   "AnimationClipEditor.BasedUponRotation.RootNodeRotation",
                   "AnimationClipEditor.BasedUponRotationHuman.BodyOrientation",
                   "AnimationClipEditor.BasedUponStartOrientation",
                   "AnimationClipEditor.BasedUponStartPositionXZ",
                   "AnimationClipEditor.BasedUponStartPositionY",
                   "AnimationClipEditor.Curves",
                   "AnimationClipEditor.EndFrame",
                   "AnimationClipEditor.LoopCycleOffset",
                   "AnimationClipEditor.LoopPose",
                   "AnimationClipEditor.LoopTime",
                   "AnimationClipEditor.Mask",
                   "AnimationClipEditor.Mirror",
                   "AnimationClipEditor.MotionCurves",
                   "AnimationClipEditor.OrientationOffsetY",
                   "AnimationClipEditor.PositionOffsetY",
                   "AnimationClipEditor.StartFrame",
                   "AtlasEditor.Toolbar.Create",
                   "AtlasEditor.Toolbar.Default",
                   "AtlasEditor.Toolbar.Merge",
                   "AtlasEditor.Toolbar.Trim",
                   "AvatarMaskEditor.BodyMask",
                   "AvatarMaskEditor.CopyFromOther",
                   "AvatarMaskEditor.CreateFromThisModel",
                   "AvatarMaskEditor.MaskDefinition",
                   "AvatarMaskEditor.TransformMask",
                   "BuildSettings.AddCurrent",
                   "BuildSettings.AddScene",
                   "BuildSettings.AllowDebugging",
                   "BuildSettings.AndroidBuildSubtarget",
                   "BuildSettings.AndroidBuildSubtargetASTC",
                   "BuildSettings.AndroidBuildSubtargetATC",
                   "BuildSettings.AndroidBuildSubtargetDXT",
                   "BuildSettings.AndroidBuildSubtargetETC",
                   "BuildSettings.AndroidBuildSubtargetETC2",
                   "BuildSettings.AndroidBuildSubtargetGeneric",
                   "BuildSettings.AndroidBuildSubtargetPVRTC",
                   "BuildSettings.AndroidNotInstalled",
                   "BuildSettings.Architecture",
                   "BuildSettings.BlackBerryBuildSubtarget",
                   "BuildSettings.BlackBerryBuildSubtargetATC",
                   "BuildSettings.BlackBerryBuildSubtargetETC",
                   "BuildSettings.BlackBerryBuildSubtargetGeneric",
                   "BuildSettings.BlackBerryBuildSubtargetPVRTC",
                   "BuildSettings.BlackBerryBuildType",
                   "BuildSettings.BlackBerryBuildTypeDebug",
                   "BuildSettings.BlackBerryBuildTypeSubmission",
                   "BuildSettings.BlackBerryNotInstalled",
                   "BuildSettings.BlackBerryValidationFailed",
                   "BuildSettings.Build",
                   "BuildSettings.BuildAndRun",
                   "BuildSettings.ConnectProfiler",
                   "BuildSettings.DashboardWidget",
                   "BuildSettings.DebugBuild",
                   "BuildSettings.DeployTargetBoth",
                   "BuildSettings.DeployTargetLocalMachine",
                   "BuildSettings.DeployTargetWindowsPhone",
                   "BuildSettings.DownloadButton",
                   "BuildSettings.EnableHeadlessMode",
                   "BuildSettings.ExplicitNullChecks",
                   "BuildSettings.Export",
                   "BuildSettings.ExportAndroidProject",
                   "BuildSettings.FlashBuildSubtarget",
                   "BuildSettings.FlashNotInstalled",
                   "BuildSettings.FlashSubtarget11dot2",
                   "BuildSettings.FlashSubtarget11dot3",
                   "BuildSettings.FlashSubtarget11dot4",
                   "BuildSettings.FlashSubtarget11dot5",
                   "BuildSettings.FlashSubtarget11dot6",
                   "BuildSettings.FlashSubtarget11dot7",
                   "BuildSettings.FlashSubtarget11dot8",
                   "BuildSettings.iPhoneNotAllowedWindows",
                   "BuildSettings.iPhoneNotInstalled",
                   "BuildSettings.MetroBuildAndRunDeployTarget",
                   "BuildSettings.MetroBuildType",
                   "BuildSettings.MetroBuildTypeAppX",
                   "BuildSettings.MetroBuildTypeVisualStudioCpp",
                   "BuildSettings.MetroBuildTypeVisualStudioCppDX",
                   "BuildSettings.MetroBuildTypeVisualStudioCSharp",
                   "BuildSettings.MetroBuildTypeVisualStudioCSharpDX",
                   "BuildSettings.MetroDebugging",
                   "BuildSettings.MetroGenerateReferenceProjects",
                   "BuildSettings.MetroNotInstalled",
                   "BuildSettings.MetroPhoneSDK81",
                   "BuildSettings.MetroPlayerARM",
                   "BuildSettings.MetroPlayerX64",
                   "BuildSettings.MetroPlayerX86",
                   "BuildSettings.MetroSDK",
                   "BuildSettings.MetroSDK80",
                   "BuildSettings.MetroSDK81",
                   "BuildSettings.MetroUniversalSDK81",
                   "BuildSettings.NoAndroid",
                   "BuildSettings.NoAndroidButton",
                   "BuildSettings.NoAndroidURL",
                   "BuildSettings.NoBB10",
                   "BuildSettings.NoBB10Button",
                   "BuildSettings.NoBB10URL",
                   "BuildSettings.NoFlash",
                   "BuildSettings.NoFlashButton",
                   "BuildSettings.NoiPhone",
                   "BuildSettings.NoiPhoneButton",
                   "BuildSettings.NoiPhoneURL",
                   "BuildSettings.NoMetro",
                   "BuildSettings.NoMetroButton",
                   "BuildSettings.NoNaClButton",
                   "BuildSettings.NoPS3",
                   "BuildSettings.NoPS3Button",
                   "BuildSettings.NoPS3URL",
                   "BuildSettings.NoPS4",
                   "BuildSettings.NoPS42URL",
                   "BuildSettings.NoPS4Button",
                   "BuildSettings.NoPSP2",
                   "BuildSettings.NoPSP2Button",
                   "BuildSettings.NoPSP2URL",
                   "BuildSettings.NoStandalone",
                   "BuildSettings.NoStandaloneButton",
                   "BuildSettings.NoStandaloneURL",
                   "BuildSettings.NoTizen",
                   "BuildSettings.NoTizenButton",
                   "BuildSettings.NoTizenURL",
                   "BuildSettings.NoVS2012U3",
                   "BuildSettings.NoWeb",
                   "BuildSettings.NoWebButton",
                   "BuildSettings.NoWindows8",
                   "BuildSettings.NoWP8",
                   "BuildSettings.NoWP8Button",
                   "BuildSettings.NoXBox360",
                   "BuildSettings.NoXBox360Button",
                   "BuildSettings.NoXBox360URL",
                   "BuildSettings.NoXboxOne",
                   "BuildSettings.NoXboxOneButton",
                   "BuildSettings.NoXboxOneURL",
                   "BuildSettings.PlatformTitle",
                   "BuildSettings.PS3NotInstalled",
                   "BuildSettings.PS4NotInstalled",
                   "BuildSettings.PSP2BuildSubtarget",
                   "BuildSettings.PSP2BuildSubtargetPackage",
                   "BuildSettings.PSP2BuildSubtargetPCHosted",
                   "BuildSettings.PSP2NotInstalled",
                   "BuildSettings.SCEBuildSubtarget",
                   "BuildSettings.SCEBuildSubtargetBluRayTitle",
                   "BuildSettings.SCEBuildSubtargetHddTitle",
                   "BuildSettings.SCEBuildSubtargetPCHosted",
                   "BuildSettings.ScenesInBuild",
                   "BuildSettings.StandaloneGLES20Emu",
                   "BuildSettings.StandaloneGLESEmu",
                   "BuildSettings.StandaloneLinux",
                   "BuildSettings.StandaloneLinux64",
                   "BuildSettings.StandaloneNotInstalled",
                   "BuildSettings.StandaloneOSXIntel",
                   "BuildSettings.StandaloneTarget",
                   "BuildSettings.StandaloneWindows",
                   "BuildSettings.StandaloneWindows64",
                   "BuildSettings.SwitchPlatform",
                   "BuildSettings.SymlinkiOSLibraries",
                   "BuildSettings.TizenBuildSubtarget",
                   "BuildSettings.TizenBuildSubtargetATC",
                   "BuildSettings.TizenBuildSubtargetETC",
                   "BuildSettings.TizenBuildSubtargetGeneric",
                   "BuildSettings.TizenNotInstalled",
                   "BuildSettings.WebNotInstalled",
                   "BuildSettings.WebPlayerOfflineDeployment",
                   "BuildSettings.WebPlayerStreamed",
                   "BuildSettings.WP8NotInstalled",
                   "BuildSettings.XBOX360NotInstalled",
                   "BuildSettings.XboxBuildSubtarget",
                   "BuildSettings.XboxBuildSubtargetDebug",
                   "BuildSettings.XboxBuildSubtargetDevelopment",
                   "BuildSettings.XboxBuildSubtargetMaster",
                   "BuildSettings.XboxOneNotInstalled",
                   "BuildSettings.XboxRunMethod",
                   "BuildSettings.XboxRunMethodDiscEmuAccurate",
                   "BuildSettings.XboxRunMethodDiscEmuFast",
                   "BuildSettings.XboxRunMethodHDD",
                   "BuildUploadCompletedWindow.CancelButton",
                   "BuildUploadCompletedWindow.CloseButton",
                   "BuildUploadCompletedWindow.CopyToClipboardMessage",
                   "BuildUploadCompletedWindow.DidCopyToClipboardMessage",
                   "BuildUploadCompletedWindow.FailurePostLinkAssistText",
                   "BuildUploadCompletedWindow.FailurePreLinkAssistText",
                   "BuildUploadCompletedWindow.FixButton",
                   "BuildUploadCompletedWindow.MainTextFailureCritical",
                   "BuildUploadCompletedWindow.MainTextFailureRecoverable",
                   "BuildUploadCompletedWindow.MainTextSuccess",
                   "BuildUploadCompletedWindow.ShareMessage",
                   "BuildUploadCompletedWindow.TextHeaderFailure",
                   "BuildUploadCompletedWindow.TextHeaderSuccess",
                   "BuildUploadCompletedWindow.UDNStatusLinkText",
                   "BuildUploadCompletedWindow.WindowTitleFailure",
                   "BuildUploadCompletedWindow.WindowTitleSuccess",
                   "BumpMapSettingsFixingWindow.overviewText",
                   "CameraEditor.DeferredProOnly",
                   "ColorPicker.ColorFoldout",
                   "ColorPicker.SliderFoldout",
                   "CurveKeyPopupAuto",
                   "CurveKeyPopupBothTangents/Constant",
                   "CurveKeyPopupBothTangents/Free",
                   "CurveKeyPopupBothTangents/Linear",
                   "CurveKeyPopupBroken",
                   "CurveKeyPopupFlat",
                   "CurveKeyPopupFreeSmooth",
                   "CurveKeyPopupLeftTangent/Constant",
                   "CurveKeyPopupLeftTangent/Free",
                   "CurveKeyPopupLeftTangent/Linear",
                   "CurveKeyPopupRightTangent/Constant",
                   "CurveKeyPopupRightTangent/Free",
                   "CurveKeyPopupRightTangent/Linear",
                   "DockAreaAddTab",
                   "DockAreaCloseTab",
                   "DockAreaMaximize",
                   "EditorUpdateWindow.CheckForNewUpdatesText",
                   "EditorUpdateWindow.TextHasUpdate",
                   "EditorUpdateWindow.TextUpToDate",
                   "EditorUpdateWindow.Title",
                   "GameObjectTypeDisconnectedModel",
                   "GameObjectTypeDisconnectedPrefab",
                   "GameObjectTypeMissing",
                   "GameObjectTypeModel",
                   "GameObjectTypePrefab",
                   "GenericInspector.ScriptIsInvalid",
                   "GenericInspector.ScriptIsMissing",
                   "HierarchyPopupCopy",
                   "HierarchyPopupDelete",
                   "HierarchyPopupDuplicate",
                   "HierarchyPopupPaste",
                   "HierarchyPopupRename",
                   "HierarchyPopupSelectPrefab",
                   "InspectorLabelTitle",
                   "InspectorPreviewTitle",
                   "LightEditor.AreaLightsProOnly",
                   "LightEditor.ForwardRenderingShadowsWarning",
                   "LightEditor.NoShadowsWarning",
                   "LightEditor.WrongColorSpaceWarning",
                   "LightmapEditor.AO",
                   "LightmapEditor.AOContrast",
                   "LightmapEditor.AOMaxDistance",
                   "LightmapEditor.Atlas",
                   "LightmapEditor.AtlasIndex",
                   "LightmapEditor.AtlasOffsetX",
                   "LightmapEditor.AtlasOffsetY",
                   "LightmapEditor.AtlasTilingX",
                   "LightmapEditor.AtlasTilingY",
                   "LightmapEditor.BakeSettings",
                   "LightmapEditor.BounceBoost",
                   "LightmapEditor.BounceIntensity",
                   "LightmapEditor.Bounces",
                   "LightmapEditor.ClampedSize",
                   "LightmapEditor.DirectionalLightmapsProOnly",
                   "LightmapEditor.DisplayControls",
                   "LightmapEditor.DisplayControls.DynamicUpdateProbes",
                   "LightmapEditor.DisplayControls.EditProbes",
                   "LightmapEditor.DisplayControls.ShowCells",
                   "LightmapEditor.DisplayControls.ShowProbes",
                   "LightmapEditor.DisplayControls.VisualiseResolution",
                   "LightmapEditor.EmptySelection",
                   "LightmapEditor.FinalGather.ContrastThreshold",
                   "LightmapEditor.FinalGather.GradientThreshold",
                   "LightmapEditor.FinalGather.InterpolationPoints",
                   "LightmapEditor.FinalGather.Rays",
                   "LightmapEditor.IncorrectLightProbePositions",
                   "LightmapEditor.Light.IndirectIntensity",
                   "LightmapEditor.Light.ShadowAngle",
                   "LightmapEditor.Light.ShadowRadius",
                   "LightmapEditor.Light.Shadows",
                   "LightmapEditor.Light.ShadowSamples",
                   "LightmapEditor.LightProbes",
                   "LightmapEditor.LockAtlas",
                   "LightmapEditor.LODSurfaceDistance",
                   "LightmapEditor.Maps",
                   "LightmapEditor.MapsArraySize",
                   "LightmapEditor.MaxTextureSize",
                   "LightmapEditor.Mode",
                   "LightmapEditor.NoNormalsNoLightmapping",
                   "LightmapEditor.ObjectSettings",
                   "LightmapEditor.Padding",
                   "LightmapEditor.Probes",
                   "LightmapEditor.Quality",
                   "LightmapEditor.Resolution",
                   "LightmapEditor.ScaleInLightmap",
                   "LightmapEditor.ShadowDistance",
                   "LightmapEditor.SkyLightColor",
                   "LightmapEditor.SkyLightIntensity",
                   "LightmapEditor.Static",
                   "LightmapEditor.Terrain.LightmapSize",
                   "LightmapEditor.TextureCompression",
                   "LightmapEditor.UseDualInForward",
                   "LightmapEditor.UseLightmaps",
                   "LightmapEditor.WindowTitle",
                   "LightProbeGroup.ProOnly",
                   "MaterialInspector.BumpMapFixingButton",
                   "MaterialInspector.BumpMapFixingWarning",
                   "MemoryInfoGCReason.AssetMarkedDirtyInEditor",
                   "MemoryInfoGCReason.AssetReferenced",
                   "MemoryInfoGCReason.AssetReferencedByManagedCodeOnly",
                   "MemoryInfoGCReason.AssetReferencedByNativeCodeOnly",
                   "MemoryInfoGCReason.BuiltinResource",
                   "MemoryInfoGCReason.MarkedDontSave",
                   "MemoryInfoGCReason.NotApplicable",
                   "MemoryInfoGCReason.SceneAssetReferenced",
                   "MemoryInfoGCReason.SceneAssetReferencedByManagedCodeOnly",
                   "MemoryInfoGCReason.SceneAssetReferencedByNativeCodeOnly",
                   "MemoryInfoGCReason.SceneObject",
                   "ModelImporter.GenerateColliders",
                   "ModelImporter.ImportBlendShapes",
                   "ModelImporter.Meshes",
                   "ModelImporter.ScaleFactor",
                   "ModelImporter.SwapUVChannels",
                   "ModelImporter.TangentSpace.Normals",
                   "ModelImporter.TangentSpace.NormalSmoothingAngle",
                   "ModelImporter.TangentSpace.Options.Calculate",
                   "ModelImporter.TangentSpace.Options.Import",
                   "ModelImporter.TangentSpace.Options.None",
                   "ModelImporter.TangentSpace.SplitTangents",
                   "ModelImporter.TangentSpace.Tangents",
                   "ModelImporter.TangentSpace.Title",
                   "ModelImporter.UseFileUnits",
                   "ModelImporterAnimationType",
                   "ModelImporterAnimationTypeGeneric",
                   "ModelImporterAnimationTypeHumanoid",
                   "ModelImporterAnimationTypeLegacy",
                   "ModelImporterAnimationTypeNone",
                   "ModelImporterAnimBakeIK",
                   "ModelImporterAnimComprHelp",
                   "ModelImporterAnimComprPositionError",
                   "ModelImporterAnimComprRotationError",
                   "ModelImporterAnimComprScaleError",
                   "ModelImporterAnimComprSetting",
                   "ModelImporterAnimComprSettingOff",
                   "ModelImporterAnimComprSettingOptimal",
                   "ModelImporterAnimComprSettingReduction",
                   "ModelImporterAnimComprSettingReductionAndCompression",
                   "ModelImporterAnimLabel",
                   "ModelImporterAnimNode",
                   "ModelImporterAnimNone",
                   "ModelImporterAnimOrigRoot",
                   "ModelImporterAnimRoot",
                   "ModelImporterAnimRootNew",
                   "ModelImporterAnimWrapMode",
                   "ModelImporterAnimWrapModeClampForever",
                   "ModelImporterAnimWrapModeDefault",
                   "ModelImporterAnimWrapModeLoop",
                   "ModelImporterAnimWrapModeOnce",
                   "ModelImporterAnimWrapModePingPong",
                   "ModelImporterGenerateSecondaryUV",
                   "ModelImporterGenerateSecondaryUVAdvanced",
                   "ModelImporterImportAnimations",
                   "ModelImporterIsReadable",
                   "ModelImporterMatDefaultHelp",
                   "ModelImporterMaterials",
                   "ModelImporterMatHelpEnd",
                   "ModelImporterMatHelpStart",
                   "ModelImporterMatImportMaterials",
                   "ModelImporterMatMaterialName",
                   "ModelImporterMatMaterialNameMat",
                   "ModelImporterMatMaterialNameMatHelp",
                   "ModelImporterMatMaterialNameModelMat",
                   "ModelImporterMatMaterialNameModelMatHelp",
                   "ModelImporterMatMaterialNameTex",
                   "ModelImporterMatMaterialNameTexHelp",
                   "ModelImporterMatMaterialNameTex_ModelMat",
                   "ModelImporterMatMaterialNameTex_ModelMatHelp",
                   "ModelImporterMatMaterialSearch",
                   "ModelImporterMatMaterialSearchEverywhere",
                   "ModelImporterMatMaterialSearchEverywhereHelp",
                   "ModelImporterMatMaterialSearchLocal",
                   "ModelImporterMatMaterialSearchLocalHelp",
                   "ModelImporterMatMaterialSearchRecursiveUp",
                   "ModelImporterMatMaterialSearchRecursiveUpHelp",
                   "ModelImporterMotionNode",
                   "ModelImporterMotionSetting",
                   "ModelImporterOptimizeMesh",
                   "ModelImporterRigAdditionalBone",
                   "ModelImporterRigAvatarDefinition",
                   "ModelImporterRigCopyFromOtherAvatar",
                   "ModelImporterRigCreateFromThisModel",
                   "ModelImporterRigRootNode",
                   "ModelImporterRigUpdateMuscleDefinitionFromSource",
                   "ModelImporterRigUpdateReferenceClips",
                   "ModelImporterSecondaryUVAngleDistortion",
                   "ModelImporterSecondaryUVAreaDistortion",
                   "ModelImporterSecondaryUVDefaults",
                   "ModelImporterSecondaryUVHardAngle",
                   "ModelImporterSecondaryUVPackMargin",
                   "NavmeshEditor.BakeSettings",
                   "NavmeshEditor.LayerSettings",
                   "NavmeshEditor.ObjectSettings",
                   "NavmeshEditor.WindowTitle",
                   "NavMeshEditorWindow.DropHeight",
                   "NavMeshEditorWindow.Height",
                   "NavMeshEditorWindow.HeightInaccuracy",
                   "NavMeshEditorWindow.HeightMesh",
                   "NavMeshEditorWindow.JumpDistance",
                   "NavMeshEditorWindow.MaxSlope",
                   "NavMeshEditorWindow.MinRegionArea",
                   "NavMeshEditorWindow.Radius",
                   "NavMeshEditorWindow.ShowAgentNeighbours",
                   "NavMeshEditorWindow.ShowAgentPath",
                   "NavMeshEditorWindow.ShowAgentPathInfo",
                   "NavMeshEditorWindow.ShowAgentWalls",
                   "NavMeshEditorWindow.ShowHeightMesh",
                   "NavMeshEditorWindow.ShowNavMesh",
                   "NavMeshEditorWindow.StepHeight",
                   "NavMeshEditorWindow.WidthInaccuracy",
                   "OcclusionCullingWindow.BackfaceThreshold",
                   "OcclusionCullingWindow.BakeQuality",
                   "OcclusionCullingWindow.DefaultParameters",
                   "OcclusionCullingWindow.FarClipPlane",
                   "OcclusionCullingWindow.MemoryLimit",
                   "OcclusionCullingWindow.OcclusionCullingMode",
                   "OcclusionCullingWindow.SafeOccluderDistance",
                   "OcclusionCullingWindow.SmallestHole",
                   "OcclusionCullingWindow.SmallestOccluder",
                   "OcclusionCullingWindow.UnitScale",
                   "OcclusionCullingWindow.WindowTitle",
                   "PerformanceChecks.ShaderExpensive",
                   "PerformanceChecks.ShaderHasMobileVariant",
                   "PerformanceChecks.ShaderMobileSkybox",
                   "PerformanceChecks.ShaderNoNormalMap",
                   "PerformanceChecks.ShaderUsesWhiteColor",
                   "PerformanceChecks.ShaderUseUnlit",
                   "PlayerSettings.AccelerometerFrequency",
                   "PlayerSettings.ActiveColorSpace",
                   "PlayerSettings.ActiveColorSpaceWarning",
                   "PlayerSettings.AlwaysDisplayWatermark",
                   "PlayerSettings.AndroidBundleVersionCode",
                   "PlayerSettings.AndroidLicensePublicKey",
                   "PlayerSettings.AndroidMinSdkVersion",
                   "PlayerSettings.AndroidPreferredInstallLocation",
                   "PlayerSettings.AndroidProfiler",
                   "PlayerSettings.androidShowActivityIndicatorOnLoading",
                   "PlayerSettings.AndroidSplashScreenScale",
                   "PlayerSettings.AndroidTargetDevice",
                   "PlayerSettings.aotOptions",
                   "PlayerSettings.APKExpansionFiles",
                   "PlayerSettings.AutoRotationAllowedOrientation",
                   "PlayerSettings.BlackBerryAuthor",
                   "PlayerSettings.BlackBerryAuthorId",
                   "PlayerSettings.BlackBerryAuthoritySubHeader",
                   "PlayerSettings.BlackBerryBackup",
                   "PlayerSettings.BlackBerryBuildId",
                   "PlayerSettings.BlackBerryCameraPermissions",
                   "PlayerSettings.BlackBerryCannotUploadLocalhostError",
                   "PlayerSettings.BlackBerryCertificateSelect",
                   "PlayerSettings.BlackBerryCertificateSubHeader",
                   "PlayerSettings.BlackBerryCheckConsoleError",
                   "PlayerSettings.BlackBerryCreateApplicationPackage",
                   "PlayerSettings.BlackBerryCreateStagingArea",
                   "PlayerSettings.BlackBerryCSJPin",
                   "PlayerSettings.BlackBerryCSKConfirmPassword",
                   "PlayerSettings.BlackBerryCSKFileInvalidError",
                   "PlayerSettings.BlackBerryCSKPassword",
                   "PlayerSettings.BlackBerryCSKPasswordError",
                   "PlayerSettings.BlackBerryCSKPasswordsDoNotMatchError",
                   "PlayerSettings.BlackBerryDebugCreateSuccess",
                   "PlayerSettings.BlackBerryDebuggingSubheader",
                   "PlayerSettings.BlackBerryDebugTokenPathError",
                   "PlayerSettings.BlackBerryDebugUploadSuccess",
                   "PlayerSettings.BlackBerryDestination",
                   "PlayerSettings.BlackBerryDeviceAddress",
                   "PlayerSettings.BlackBerryDeviceIDPermissions",
                   "PlayerSettings.BlackBerryDevicePassword",
                   "PlayerSettings.BlackBerryDevicePins",
                   "PlayerSettings.BlackBerryDevicePinsError",
                   "PlayerSettings.BlackBerryDevicePWError",
                   "PlayerSettings.BlackBerryDeviceSubheader",
                   "PlayerSettings.BlackBerryGamepadSupport",
                   "PlayerSettings.BlackBerryGenerateToken",
                   "PlayerSettings.BlackBerryGetLog",
                   "PlayerSettings.BlackBerryGPSPermissions",
                   "PlayerSettings.BlackBerryInheritAuthorId",
                   "PlayerSettings.BlackBerryInstallingApplication",
                   "PlayerSettings.BlackBerryInvalidIPAddressError",
                   "PlayerSettings.BlackBerryIsRegistered",
                   "PlayerSettings.BlackBerryLandscapeSplash",
                   "PlayerSettings.BlackBerryLaunchingApplication",
                   "PlayerSettings.BlackBerryManifestCreateError",
                   "PlayerSettings.BlackBerryMicrophonePermissions",
                   "PlayerSettings.BlackBerryNeedMoreDevicesError",
                   "PlayerSettings.BlackBerryNeeds32bitJavaError",
                   "PlayerSettings.BlackBerryNeedsJavaError",
                   "PlayerSettings.BlackBerryNullArgumentError",
                   "PlayerSettings.BlackBerryPath",
                   "PlayerSettings.BlackBerryPBDTCSJPath",
                   "PlayerSettings.BlackBerryPBDTDoesNotExistError",
                   "PlayerSettings.BlackBerryPopulateFieldsError",
                   "PlayerSettings.BlackBerryPortraitSplash",
                   "PlayerSettings.BlackBerryRDKCSJPath",
                   "PlayerSettings.BlackBerryRDKDoesNotExistError",
                   "PlayerSettings.BlackBerryRegister",
                   "PlayerSettings.BlackBerryRegistrationSuccess",
                   "PlayerSettings.BlackBerryRestore",
                   "PlayerSettings.BlackBerrySelectBackupDestination",
                   "PlayerSettings.BlackBerrySelectBackupFile",
                   "PlayerSettings.BlackBerrySharedPermissions",
                   "PlayerSettings.BlackBerrySigningApplication",
                   "PlayerSettings.BlackBerrySigningWindowMessage",
                   "PlayerSettings.BlackBerrySigningWindowTitle",
                   "PlayerSettings.BlackBerrySquareSplash",
                   "PlayerSettings.BlackBerryTokenCreate",
                   "PlayerSettings.BlackBerryTokenEdit",
                   "PlayerSettings.BlackBerryTokenExpires",
                   "PlayerSettings.BlackBerryTokenImport",
                   "PlayerSettings.BlackBerryTokenInvalidError",
                   "PlayerSettings.BlackBerryTokenRenew",
                   "PlayerSettings.BlackBerryTokensSubheader",
                   "PlayerSettings.BlackBerryTokenUpload",
                   "PlayerSettings.BlackBerryTokenUploadInvalidArgsError",
                   "PlayerSettings.BlackBerryTokenWindowMessage",
                   "PlayerSettings.BlackBerryTokenWindowTitle",
                   "PlayerSettings.BlackBerryUnRegister",
                   "PlayerSettings.BlackBerryUnRegisterWarning",
                   "PlayerSettings.BlackBerryUnRegisterWindowTitle",
                   "PlayerSettings.BrowseGeneric",
                   "PlayerSettings.BrowseKeystore",
                   "PlayerSettings.BrowseToSelectKeystoreName",
                   "PlayerSettings.ConfigurationSubHeader",
                   "PlayerSettings.ConfirmPassword",
                   "PlayerSettings.CreateKeystoreDialog",
                   "PlayerSettings.CreateNewKey",
                   "PlayerSettings.CreateNewKeystore",
                   "PlayerSettings.CreateWallpaper",
                   "PlayerSettings.CrossPlatformHeader",
                   "PlayerSettings.CursorHotspot",
                   "PlayerSettings.DashboardWidgetSubHeader",
                   "PlayerSettings.DefaultCursor",
                   "PlayerSettings.DefaultIcon",
                   "PlayerSettings.DefaultScreenHeight",
                   "PlayerSettings.DefaultScreenHeightWeb",
                   "PlayerSettings.DefaultScreenOrientation",
                   "PlayerSettings.DefaultScreenWidth",
                   "PlayerSettings.DefaultScreenWidthWeb",
                   "PlayerSettings.DX11NotSupported",
                   "PlayerSettings.DX11Warning",
                   "PlayerSettings.DynamicBatching",
                   "PlayerSettings.enableHWStatistics",
                   "PlayerSettings.EnterPassword",
                   "PlayerSettings.FirstStreamedLevelWithResources",
                   "PlayerSettings.flashStrippingLevel",
                   "PlayerSettings.ForceInternetPermission",
                   "PlayerSettings.ForceSDCardPermission",
                   "PlayerSettings.GPUSkinning",
                   "PlayerSettings.IconHeader",
                   "PlayerSettings.IdentificationSubHeader",
                   "PlayerSettings.IOSLocationUsageDescription",
                   "PlayerSettings.iosShowActivityIndicatorOnLoading",
                   "PlayerSettings.IPadHighResLandscapeSplashScreen",
                   "PlayerSettings.IPadHighResPortraitSplashScreen",
                   "PlayerSettings.IPadLandscapeSplashScreen",
                   "PlayerSettings.IPadPortraitSplashScreen",
                   "PlayerSettings.IPhone47inSplashScreen",
                   "PlayerSettings.IPhone55inLandscapeSplashScreen",
                   "PlayerSettings.IPhone55inPortraitSplashScreen",
                   "PlayerSettings.IPhoneApplicationDisplayName",
                   "PlayerSettings.IPhoneBundleIdentifier",
                   "PlayerSettings.IPhoneBundleVersion",
                   "PlayerSettings.IPhoneHighResSplashScreen",
                   "PlayerSettings.IPhoneScriptCallOptimization",
                   "PlayerSettings.IPhoneSdkVersion",
                   "PlayerSettings.IPhoneSplashScreen",
                   "PlayerSettings.IPhoneStrippingLevel",
                   "PlayerSettings.IPhoneTallHighResSplashScreen",
                   "PlayerSettings.IPhoneTargetOSVersion",
                   "PlayerSettings.Keyalias",
                   "PlayerSettings.KeyaliasSubHeader",
                   "PlayerSettings.KeyaliasUnsigned",
                   "PlayerSettings.KeyPass",
                   "PlayerSettings.KeystoreSubHeader",
                   "PlayerSettings.LandscapeLeftOrientation",
                   "PlayerSettings.LandscapeRightOrientation",
                   "PlayerSettings.LicenseSubHeader",
                   "PlayerSettings.MetroAppIcon",
                   "PlayerSettings.MetroApplication",
                   "PlayerSettings.MetroApplicationDescription",
                   "PlayerSettings.MetroApplicationDisplayName",
                   "PlayerSettings.MetroCertificate",
                   "PlayerSettings.MetroCertificateCreate",
                   "PlayerSettings.MetroCertificateCreateButton",
                   "PlayerSettings.MetroCertificateCreateConfirmPassword",
                   "PlayerSettings.MetroCertificateCreateConfirmPasswordConfirm",
                   "PlayerSettings.MetroCertificateCreateOverwrite",
                   "PlayerSettings.MetroCertificateCreatePassword",
                   "PlayerSettings.MetroCertificateCreatePasswordInvalid",
                   "PlayerSettings.MetroCertificateCreatePasswordMismatch",
                   "PlayerSettings.MetroCertificateCreatePublisher",
                   "PlayerSettings.MetroCertificateCreatePublisherInvalid",
                   "PlayerSettings.MetroCertificateCreatePublisherMissing",
                   "PlayerSettings.MetroCertificateCreateTitle",
                   "PlayerSettings.MetroCertificateIssuer",
                   "PlayerSettings.MetroCertificateNotAfter",
                   "PlayerSettings.MetroCertificatePasswordButton",
                   "PlayerSettings.MetroCertificatePasswordPassword",
                   "PlayerSettings.MetroCertificatePasswordPasswordInvalid",
                   "PlayerSettings.MetroCertificatePasswordTitle",
                   "PlayerSettings.MetroCertificatePublisher",
                   "PlayerSettings.MetroCertificateSelect",
                   "PlayerSettings.MetroCompilationOverrides",
                   "PlayerSettings.MetroDefaultTileSize",
                   "PlayerSettings.MetroEnableIndependentInputSource",
                   "PlayerSettings.MetroEnableLowLatencyPresentationAPI",
                   "PlayerSettings.MetroImageSelect",
                   "PlayerSettings.MetroLargeTile",
                   "PlayerSettings.MetroMediumTile",
                   "PlayerSettings.MetroPackageDisplayName",
                   "PlayerSettings.MetroPackageLogo",
                   "PlayerSettings.MetroPackageLogoScale100",
                   "PlayerSettings.MetroPackageLogoScale140",
                   "PlayerSettings.MetroPackageLogoScale180",
                   "PlayerSettings.MetroPackageLogoScale240",
                   "PlayerSettings.MetroPackageName",
                   "PlayerSettings.MetroPackagePublisherDisplayName",
                   "PlayerSettings.MetroPackageVersion",
                   "PlayerSettings.MetroPackaging",
                   "PlayerSettings.MetroPhoneAppIcon",
                   "PlayerSettings.MetroPhoneAppIcon140",
                   "PlayerSettings.MetroPhoneAppIcon240",
                   "PlayerSettings.MetroPhoneMediumTile",
                   "PlayerSettings.MetroPhoneMediumTile140",
                   "PlayerSettings.MetroPhoneMediumTile240",
                   "PlayerSettings.MetroPhoneSmallTile",
                   "PlayerSettings.MetroPhoneSmallTile140",
                   "PlayerSettings.MetroPhoneSmallTile240",
                   "PlayerSettings.MetroPhoneSplashScreenImage",
                   "PlayerSettings.MetroPhoneSplashScreenImage140",
                   "PlayerSettings.MetroPhoneSplashScreenImage240",
                   "PlayerSettings.MetroPhoneWideTile",
                   "PlayerSettings.MetroPhoneWideTile140",
                   "PlayerSettings.MetroPhoneWideTile240",
                   "PlayerSettings.MetroPublishingHeader",
                   "PlayerSettings.MetroSmallLogo",
                   "PlayerSettings.MetroSmallTile",
                   "PlayerSettings.MetroSplashScreen",
                   "PlayerSettings.MetroSplashScreenBackgroundColor",
                   "PlayerSettings.MetroSplashScreenOverwriteBackgroundColor",
                   "PlayerSettings.MetroStoreLargeTile100",
                   "PlayerSettings.MetroStoreLargeTile140",
                   "PlayerSettings.MetroStoreLargeTile180",
                   "PlayerSettings.MetroStoreLargeTile80",
                   "PlayerSettings.MetroStoreSmallLogoScale100",
                   "PlayerSettings.MetroStoreSmallLogoScale140",
                   "PlayerSettings.MetroStoreSmallLogoScale180",
                   "PlayerSettings.MetroStoreSmallLogoScale80",
                   "PlayerSettings.MetroStoreSmallTile100",
                   "PlayerSettings.MetroStoreSmallTile140",
                   "PlayerSettings.MetroStoreSmallTile180",
                   "PlayerSettings.MetroStoreSmallTile80",
                   "PlayerSettings.MetroStoreSplashScreenImage",
                   "PlayerSettings.MetroStoreSplashScreenImage140",
                   "PlayerSettings.MetroStoreSplashScreenImage180",
                   "PlayerSettings.MetroStoreTileLogo",
                   "PlayerSettings.MetroStoreTileLogo140",
                   "PlayerSettings.MetroStoreTileLogo180",
                   "PlayerSettings.MetroStoreTileLogo80",
                   "PlayerSettings.MetroStoreTileWideLogo",
                   "PlayerSettings.MetroStoreTileWideLogo140",
                   "PlayerSettings.MetroStoreTileWideLogo180",
                   "PlayerSettings.MetroStoreTileWideLogo80",
                   "PlayerSettings.MetroTile",
                   "PlayerSettings.MetroTileBackgroundColor",
                   "PlayerSettings.MetroTileForegroundText",
                   "PlayerSettings.MetroTileShortName",
                   "PlayerSettings.MetroTileShowName",
                   "PlayerSettings.MetroUnprocessedPlugins",
                   "PlayerSettings.MetroWideTile",
                   "PlayerSettings.MetroWindows",
                   "PlayerSettings.MetroWindowsPhone",
                   "PlayerSettings.MultithreadedRendering",
                   "PlayerSettings.NotApplicableForPlatform",
                   "PlayerSettings.NoTemplatesFound",
                   "PlayerSettings.OpenKeystoreDialog",
                   "PlayerSettings.OptimizationSubHeader",
                   "PlayerSettings.OtherHeader",
                   "PlayerSettings.PasswordsDoNotMatch",
                   "PlayerSettings.PasswordTooShort",
                   "PlayerSettings.PerPlatformHeader",
                   "PlayerSettings.PortraitOrientation",
                   "PlayerSettings.PortraitUpsideDownOrientation",
                   "PlayerSettings.ps3BackgroundPath",
                   "PlayerSettings.ps3BootCheckMaxSaveGameSizeKB",
                   "PlayerSettings.ps3DLCConfigPath",
                   "PlayerSettings.ps3NpCommunicationPassphrase",
                   "PlayerSettings.ps3SaveGameSlots",
                   "PlayerSettings.ps3SoundPath",
                   "PlayerSettings.ps3ThumbnailPath",
                   "PlayerSettings.ps3TitleConfigPath",
                   "PlayerSettings.ps3TitleSettings",
                   "PlayerSettings.ps3TrialMode",
                   "PlayerSettings.ps3TrophyCommId",
                   "PlayerSettings.ps3TrophyCommSig",
                   "PlayerSettings.ps3TrophyPackagePath",
                   "PlayerSettings.psp2BackgroundPath",
                   "PlayerSettings.psp2DLCConfigPath",
                   "PlayerSettings.psp2LiveArea",
                   "PlayerSettings.psp2LiveAreaBackround",
                   "PlayerSettings.psp2LiveAreaGate",
                   "PlayerSettings.psp2NP",
                   "PlayerSettings.psp2NPCommsID",
                   "PlayerSettings.psp2NPCommsPassphrase",
                   "PlayerSettings.psp2NPCommsSig",
                   "PlayerSettings.psp2NPTrophyPath",
                   "PlayerSettings.psp2PackageParams",
                   "PlayerSettings.psp2PackagePassword",
                   "PlayerSettings.psp2ParamSfxPath",
                   "PlayerSettings.psp2PasswordBadLength",
                   "PlayerSettings.psp2SoundPath",
                   "PlayerSettings.psp2SplashScreen",
                   "PlayerSettings.psp2ThumbnailPath",
                   "PlayerSettings.psp2TrophyCommId",
                   "PlayerSettings.psp2TrophyPackagePath",
                   "PlayerSettings.PublishingHeader",
                   "PlayerSettings.RenderingPath",
                   "PlayerSettings.RenderingSubHeader",
                   "PlayerSettings.ResolutionDialogBanner",
                   "PlayerSettings.ResolutionHeader",
                   "PlayerSettings.ResolutionSubHeader",
                   "PlayerSettings.RunInBackground",
                   "PlayerSettings.SamsungTVDeviceAddress",
                   "PlayerSettings.ScreenOrientationSubHeader",
                   "PlayerSettings.scriptingDefineSymbols",
                   "PlayerSettings.SharedSettingsFootnote",
                   "PlayerSettings.SplashHeader",
                   "PlayerSettings.StandalonePlayerSubHeader",
                   "PlayerSettings.StaticBatching",
                   "PlayerSettings.StatusBarSubHeader",
                   "PlayerSettings.Stereo3D",
                   "PlayerSettings.StoreConfirm",
                   "PlayerSettings.StorePass",
                   "PlayerSettings.StreamingSubHeader",
                   "PlayerSettings.StripPhysics",
                   "PlayerSettings.StripUnusedMeshComponents",
                   "PlayerSettings.SubmissionSubHeader",
                   "PlayerSettings.SupportedAspectRatios",
                   "PlayerSettings.TargetGlesGraphics",
                   "PlayerSettings.TargetPlatform",
                   "PlayerSettings.TargetResolution",
                   "PlayerSettings.TizenAuthoritySubHeader",
                   "PlayerSettings.TizenCertificateAlias",
                   "PlayerSettings.TizenCertificateCity",
                   "PlayerSettings.TizenCertificateConfirmPassword",
                   "PlayerSettings.TizenCertificateCountry",
                   "PlayerSettings.TizenCertificateDept",
                   "PlayerSettings.TizenCertificateDeveloper",
                   "PlayerSettings.TizenCertificateEmail",
                   "PlayerSettings.TizenCertificateFilePath",
                   "PlayerSettings.TizenCertificateOrganization",
                   "PlayerSettings.TizenCertificatePassword",
                   "PlayerSettings.TizenCertificatePath",
                   "PlayerSettings.TizenCertificateState",
                   "PlayerSettings.TizenChooseCertificate",
                   "PlayerSettings.TizenCreateApplicationPackage",
                   "PlayerSettings.TizenCreateCertificate",
                   "PlayerSettings.TizenCreateStagingArea",
                   "PlayerSettings.TizenCurrentCertificatePassword",
                   "PlayerSettings.TizenDebuggingSubheader",
                   "PlayerSettings.TizenGPSPermissions",
                   "PlayerSettings.TizenInstallingApplication",
                   "PlayerSettings.TizenInvalidCertPathError",
                   "PlayerSettings.TizenLaunchingApplication",
                   "PlayerSettings.TizenMicrophonePermissions",
                   "PlayerSettings.TizenNeeds32bitJavaError",
                   "PlayerSettings.TizenNeedsJavaError",
                   "PlayerSettings.TizenNoCertificateChosen",
                   "PlayerSettings.TizenPopulateFieldsError",
                   "PlayerSettings.TizenProductDescription",
                   "PlayerSettings.TizenProductURL",
                   "PlayerSettings.TizenSigningApplication",
                   "PlayerSettings.TizenSigningRequiredError",
                   "PlayerSettings.TizenSigningWindowMessage",
                   "PlayerSettings.TizenSigningWindowTitle",
                   "PlayerSettings.UIExitOnSuspend",
                   "PlayerSettings.UIPrerenderedIcon",
                   "PlayerSettings.UIRequiresPersistentWiFi",
                   "PlayerSettings.UIStatusBarHidden",
                   "PlayerSettings.UIStatusBarStyle",
                   "PlayerSettings.Use24BitDepthBuffer",
                   "PlayerSettings.Use32BitDisplayBuffer",
                   "PlayerSettings.UseDX11",
                   "PlayerSettings.UseExistingKeystore",
                   "PlayerSettings.UseOSAutorotation",
                   "PlayerSettings.VideoMemoryForVertexBuffers",
                   "PlayerSettings.WatermarkSubHeader",
                   "PlayerSettings.WebPlayerTemplateSubHeader",
                   "PlayerSettings.WindowsPhoneTiles",
                   "PlayerSettings.WindowsTiles",
                   "PlayerSettings.XboxAdditionalTitleMemorySize",
                   "PlayerSettings.XboxAdditionalTitleMemoryWarning",
                   "PlayerSettings.XboxAvatarEnable",
                   "PlayerSettings.XboxEnableGuest",
                   "PlayerSettings.XboxEnableKinect",
                   "PlayerSettings.XboxGenerateSPAConfig",
                   "PlayerSettings.XboxImageConversion",
                   "PlayerSettings.XboxImageXEXFile",
                   "PlayerSettings.XboxKinect",
                   "PlayerSettings.XboxKinectAutoTracking",
                   "PlayerSettings.XboxKinectDeployBase",
                   "PlayerSettings.XboxKinectDeployResources",
                   "PlayerSettings.XboxKinectFitness",
                   "PlayerSettings.XboxKinectHeadOrientation",
                   "PlayerSettings.XboxKinectHeadPosition",
                   "PlayerSettings.XboxKinectSpeech",
                   "PlayerSettings.XboxLive",
                   "PlayerSettings.XboxServices",
                   "PlayerSettings.XboxSpaFile",
                   "PlayerSettings.XboxSplashScreen",
                   "PlayerSettings.XboxTitleId",
                   "Profiler.AddArea",
                   "Profiler.CPU.Other",
                   "Profiler.CPU.Physics",
                   "Profiler.CPU.Rendering",
                   "Profiler.CPU.Scripts",
                   "Profiler.CurrentFrame",
                   "Profiler.CurrentProfiler",
                   "Profiler.DeepProfile",
                   "Profiler.FrameOverview",
                   "Profiler.FrameTime",
                   "Profiler.NoFrameDataAvailable",
                   "Profiler.NoLicense",
                   "Profiler.ProfileEditor",
                   "Profiler.SyncTimeProfiling",
                   "ProfilerColumn.Calls",
                   "ProfilerColumn.DetailViewObject",
                   "ProfilerColumn.DrawCalls",
                   "ProfilerColumn.FunctionName",
                   "ProfilerColumn.GCMemory",
                   "ProfilerColumn.ObjectName",
                   "ProfilerColumn.SelfGPUPercent",
                   "ProfilerColumn.SelfGPUTime",
                   "ProfilerColumn.SelfPercent",
                   "ProfilerColumn.SelfTime",
                   "ProfilerColumn.TotalGPUPercent",
                   "ProfilerColumn.TotalGPUTime",
                   "ProfilerColumn.TotalPercent",
                   "ProfilerColumn.TotalTime",
                   "QualitySettings.SoftParticlesHint",
                   "SaveAssetDialog.Close",
                   "SaveAssetDialog.DontSave",
                   "SaveAssetDialog.SaveAll",
                   "SaveAssetDialog.SaveSelected",
                   "SaveAssetDialog.Title",
                   "ScriptExecutionOrderInspector.DefaultTime",
                   "ScriptExecutionOrderInspector.HelpText",
                   "ShaderInspector.ShowAll",
                   "ShaderInspector.ShowCurrent",
                   "ShaderInspector.ShowSurface",
                   "Snap.MoveX",
                   "Snap.MoveY",
                   "Snap.MoveZ",
                   "Snap.Rotation",
                   "Snap.Scale",
                   "Snap.SnapAllAxes",
                   "Snap.SnapX",
                   "Snap.SnapY",
                   "Snap.SnapZ",
                   "SpriteEditor.NoTextureOrSpriteSelected",
                   "SpriteEditor.Slicing.DeleteAll",
                   "SpriteEditor.Slicing.Safe",
                   "SpriteEditor.Slicing.Smart",
                   "SpriteEditor.TextureIsScaledWarning",
                   "SpriteEditorWindow.WindowTitle",
                   "SpriteInspector.Pivot",
                   "SpriteInspector.Pivot.Bottom",
                   "SpriteInspector.Pivot.BottomLeft",
                   "SpriteInspector.Pivot.BottomRight",
                   "SpriteInspector.Pivot.Center",
                   "SpriteInspector.Pivot.Custom",
                   "SpriteInspector.Pivot.Left",
                   "SpriteInspector.Pivot.Right",
                   "SpriteInspector.Pivot.Top",
                   "SpriteInspector.Pivot.TopLeft",
                   "SpriteInspector.Pivot.TopRight",
                   "SpritePackerWindow.WindowTitle",
                   "SpriteRenderer.Material",
                   "SpriteRenderer.SortingLayer",
                   "SpriteRenderer.SortingOrder",
                   "StaticOcclusionCullingMode.AutomaticPortals",
                   "StaticOcclusionCullingMode.ManuallyPlacedPortalsOnly",
                   "StaticOcclusionCullingMode.PortalsAndPVS",
                   "StaticOcclusionCullingMode.PVSAndDynamicObjects",
                   "StaticOcclusionCullingMode.PVSOnly",
                   "TerrainInspector.Brushes",
                   "TerrainInspector.BrushOpacity",
                   "TerrainInspector.BrushSize",
                   "TerrainInspector.Details.Details",
                   "TerrainInspector.Details.Edit",
                   "TerrainInspector.Details.TargetStrength",
                   "TerrainInspector.Heightmaps.ExportRaw",
                   "TerrainInspector.Heightmaps.Flatten",
                   "TerrainInspector.Heightmaps.Heightmap",
                   "TerrainInspector.Heightmaps.ImportRaw",
                   "TerrainInspector.MassPlaceTrees",
                   "TerrainInspector.PaintDetailsTip",
                   "TerrainInspector.PaintHeightTip",
                   "TerrainInspector.PaintTextureTip",
                   "TerrainInspector.PlaceTreesTip",
                   "TerrainInspector.RaiseHeightTip",
                   "TerrainInspector.Refresh",
                   "TerrainInspector.Resolution",
                   "TerrainInspector.Settings",
                   "TerrainInspector.ShaderWarning",
                   "TerrainInspector.SmoothHeightTip",
                   "TerrainInspector.TerrainSettingsTip",
                   "TerrainInspector.Textures.Edit",
                   "TerrainInspector.Textures.Textures",
                   "TerrainInspector.Trees.ColorVar",
                   "TerrainInspector.Trees.EditTrees",
                   "TerrainInspector.Trees.NoTrees",
                   "TerrainInspector.Trees.TreeDensity",
                   "TerrainInspector.Trees.TreeHeight",
                   "TerrainInspector.Trees.TreeHeightVar",
                   "TerrainInspector.Trees.Trees",
                   "TerrainInspector.Trees.TreeWidth",
                   "TerrainInspector.Trees.TreeWidthVar",
                   "TextEditorPopup.Copy",
                   "TextEditorPopup.Cut",
                   "TextEditorPopup.Delete",
                   "TextEditorPopup.Paste",
                   "TextureImporter.Alpha",
                   "TextureImporter.Alpha.Specular",
                   "TextureImporter.Alpha.Transparent",
                   "TextureImporter.AlphaIsTransparency",
                   "TextureImporter.BorderMipMaps",
                   "TextureImporter.BumpFiltering",
                   "TextureImporter.BumpFiltering.Sharp",
                   "TextureImporter.BumpFiltering.Smooth",
                   "TextureImporter.Bumpiness",
                   "TextureImporter.CompressionQuality",
                   "TextureImporter.CompressionQualityOptions.Best",
                   "TextureImporter.CompressionQualityOptions.Fast",
                   "TextureImporter.CompressionQualityOptions.Normal",
                   "TextureImporter.Cookie",
                   "TextureImporter.Cookie.Directional",
                   "TextureImporter.Cookie.Point",
                   "TextureImporter.Cookie.Spot",
                   "TextureImporter.GenerateAlphaFromGrayscale",
                   "TextureImporter.GenerateCubemap",
                   "TextureImporter.GenerateFromBump",
                   "TextureImporter.GenerateMipMaps",
                   "TextureImporter.GenerateSpritePolygon",
                   "TextureImporter.Lightmap",
                   "TextureImporter.LinearTexture",
                   "TextureImporter.MaxSize",
                   "TextureImporter.MipmapFade",
                   "TextureImporter.MipmapFadeToggle",
                   "TextureImporter.MipMapFilter",
                   "TextureImporter.MipMapFilterOptions.Box",
                   "TextureImporter.MipMapFilterOptions.Kaiser",
                   "TextureImporter.MipMapsInLinearSpace",
                   "TextureImporter.NormalMap",
                   "TextureImporter.Npot",
                   "TextureImporter.Platforms.Default",
                   "TextureImporter.ReadWrite",
                   "TextureImporter.RefMap",
                   "TextureImporter.RefMap.Cylindrical",
                   "TextureImporter.RefMap.FullCubemap",
                   "TextureImporter.RefMap.NiceSphere",
                   "TextureImporter.RefMap.SimpleSphere",
                   "TextureImporter.RefMap.Sphere",
                   "TextureImporter.SeamlessCubemap",
                   "TextureImporter.SpriteColliderAlphaCutoff",
                   "TextureImporter.SpriteColliderDetail",
                   "TextureImporter.SpriteExtrude",
                   "TextureImporter.SpriteMeshType",
                   "TextureImporter.SpriteMeshTypeOptions.FullRect",
                   "TextureImporter.SpriteMeshTypeOptions.Tight",
                   "TextureImporter.SpriteMode",
                   "TextureImporter.SpriteModeOptions.Multiple",
                   "TextureImporter.SpriteModeOptions.None",
                   "TextureImporter.SpriteModeOptions.SingleSprite",
                   "TextureImporter.SpritePackingTag",
                   "TextureImporter.SpritePixelsPerUnit",
                   "TextureImporter.SpritePolygonAlphaCutoff",
                   "TextureImporter.SpritePolygonDetail",
                   "TextureImporter.SpritePolygonHoles",
                   "TextureImporter.TextureFormat",
                   "TextureImporter.TextureFormat.16 bit",
                   "TextureImporter.TextureFormat.2bit",
                   "TextureImporter.TextureFormat.4bit",
                   "TextureImporter.TextureFormat.Compressed",
                   "TextureImporter.TextureFormat.Truecolor",
                   "TextureImporter.TextureType",
                   "TextureImporter.TextureType.Advanced",
                   "TextureImporter.TextureType.Cookie",
                   "TextureImporter.TextureType.Cursor",
                   "TextureImporter.TextureType.GUI",
                   "TextureImporter.TextureType.Image",
                   "TextureImporter.TextureType.Lightmap",
                   "TextureImporter.TextureType.Normalmap",
                   "TextureImporter.TextureType.Reflection",
                   "TextureImporter.TextureType.Sprite",
                   "TextureImporter.WrapWarning",
                   "ToolbarLayers",
                   "ToolbarLayout",
                   "UnityEditor.AnimationCleanupPopup",
                   "UnityEditor.AnimationEventPopup",
                   "UnityEditor.AssetStoreWindow",
                   "UnityEditor.DeleteWindowLayout",
                   "UnityEditor.ProjectBrowser",
                   "UnityEditor.ProjectWindow",
                   "UnityEditor.SaveWindowLayout",
                   "UploadingBuildsMonitor.NoSessionDialogButtonOK",
                   "UploadingBuildsMonitor.NoSessionDialogHeader",
                   "UploadingBuildsMonitor.NoSessionDialogText",
                   "UploadingBuildsMonitor.OverwriteDialogButtonCancel",
                   "UploadingBuildsMonitor.OverwriteDialogButtonOK",
                   "UploadingBuildsMonitor.OverwriteDialogButtonVersion",
                   "UploadingBuildsMonitor.OverwriteDialogHeader",
                   "UploadingBuildsMonitor.OverwriteDialogText",
                   "UploadingBuildsMonitor.ProgressBarText",
                   "WelcomeScreen.AssetStoreHeader",
                   "WelcomeScreen.AssetStoreText",
                   "WelcomeScreen.MainText",
                   "WelcomeScreen.ShowAtStartup",
                   "WelcomeScreen.UnityAnswersHeader",
                   "WelcomeScreen.UnityAnswersText",
                   "WelcomeScreen.UnityBasicsHeader",
                   "WelcomeScreen.UnityBasicsText",
                   "WelcomeScreen.UnityForumHeader",
                   "WelcomeScreen.UnityForumText",
                   "WelcomeScreen.VideoTutHeader",
                   "WelcomeScreen.VideoTutText"
                };
   }

   private static IEnumerable<string> ReflectHashtable(string field)
   {
      var list = new List<string>();

      var fi = typeof(EditorGUIUtility).GetField("s_ScriptInfos", BindingFlags.NonPublic | BindingFlags.Static);
      if (fi == null)
      {
         uScriptDebug.Log(string.Format("Reflection failed for EditorGUIUtility.{0}.", field), uScriptDebug.Type.Error);
         return list;
      }

      var hashtable = fi.GetValue(null) as Hashtable;
      if (hashtable == null)
      {
         uScriptDebug.Log(string.Format("EditorGUIUtility.{0} is not a Hashtable.", field), uScriptDebug.Type.Error);
         return list;
      }

      list = (from object item in hashtable.Keys select item.ToString()).ToList();

      var badNames = GetKnownBadNames();
      return list.Where(x => !badNames.Contains(x));
   }

   private float CalculateSidePanelWidth()
   {
      return Mathf.Clamp(position.width * 0.21f, SidePanelMinWidth, SidePanelMaxWidth);
   }

   private void DrawIconDisplay(GUIStyle style)
   {
      if (style == null)
      {
         DrawCenteredMessage("No icon selected");
         GUILayout.FlexibleSpace();
         DrawHelpIcon();
         return;
      }

      var iconTexture = style.normal.background;

      viewportRect = EditorGUILayout.BeginVertical();

      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.Label(style.name, EditorStyles.boldLabel);
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndHorizontal();

      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.Label("Normal");
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndHorizontal();

      const int IconOffset = 45;
      var iconWidth = iconTexture.width * this.drawScale;
      var iconHeight = iconTexture.height * this.drawScale;
      var sidePanelWidth = CalculateSidePanelWidth();
      GUI.DrawTexture(new Rect((sidePanelWidth - iconWidth) * 0.5f, IconOffset, iconWidth, iconHeight), iconTexture, ScaleMode.StretchToFill);
      GUILayout.Space(iconHeight + 10);

      EditorGUILayout.BeginHorizontal();
      if (GUILayout.Toggle(Math.Abs(this.drawScale - 1.0f) < 0.0001f, "1x", EditorStyles.miniButtonLeft))
      {
         this.drawScale = 1.0f;
      }
      if (GUILayout.Toggle(Math.Abs(this.drawScale - 1.5f) < 0.0001f, "1.5x", EditorStyles.miniButtonMid))
      {
         this.drawScale = 1.5f;
      }
      if (GUILayout.Toggle(Math.Abs(this.drawScale - 2.0f) < 0.0001f, "2x", EditorStyles.miniButtonRight))
      {
         this.drawScale = 2.0f;
      }
      EditorGUILayout.EndHorizontal();

      GUILayout.Space(10);

      DrawIconStyleState(style.active, "Active");
      DrawIconStyleState(style.hover, "Hover");
      DrawIconStyleState(style.focused, "Focused");

      GUILayout.Space(10);

      var rightAligned = new GUIStyle(EditorStyles.label) { alignment = TextAnchor.UpperRight };

#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
      EditorGUIUtility.LookLikeControls(50);
#else
      EditorGUIUtility.labelWidth = 50;
#endif
      EditorGUILayout.LabelField("Width:", string.Format("{0}px", iconTexture.width), rightAligned, GUILayout.Width(100));
      EditorGUILayout.LabelField("Height:", string.Format("{0}px", iconTexture.height), rightAligned, GUILayout.Width(100));

      this.ExportIconSection(style.name, iconTexture);

      GUILayout.FlexibleSpace();

      DrawHelpIcon();

      EditorGUILayout.EndVertical();
   }

   private void ExportIconSection(string textureName, Texture texture)
   {
      GUILayout.Space(20);

      // Export the image with 8-bit alpha
      var pad1 = 0;
      var pad2 = pad1 * 2;

      if (Event.current.type == EventType.Repaint)
      {
         var panelWidth = viewportRect.width - 7;

         var rect = GUILayoutUtility.GetLastRect();
         rect = new Rect((int)((panelWidth - texture.width) * 0.5f), rect.yMax + pad2, texture.width, texture.height);
         var backgroundRect = new Rect(rect.x - pad1, rect.y - pad1, rect.width + pad2, rect.height + pad2);

         GUI.DrawTexture(backgroundRect, this.blackTexture, ScaleMode.StretchToFill);
         GUI.DrawTexture(rect, texture, ScaleMode.StretchToFill);
         if (pad1 > 0)
         {
            uScriptGUI.DebugBox(backgroundRect);
         }

         rect = new Rect((int)((panelWidth - texture.width) * 0.5f), rect.yMax + pad2, texture.width, texture.height);
         backgroundRect = new Rect(rect.x - pad1, rect.y - pad1, rect.width + pad2, rect.height + pad2);

         GUI.DrawTexture(backgroundRect, this.whiteTexture, ScaleMode.StretchToFill);
         GUI.DrawTexture(rect, texture, ScaleMode.StretchToFill);
         if (pad1 > 0)
         {
            uScriptGUI.DebugBox(backgroundRect);
         }

         backgroundRect.yMin -= rect.height + pad2;
         this.grabRect = backgroundRect;
      }

      GUILayout.Space((texture.height * 2) + (pad2 * 2) + 20);

      if (GUILayout.Button("Save"))
      {
         this.grabName = textureName;
         this.shouldGrab = true;
      }

      if (this.shouldGrab && Event.current.type == EventType.Repaint)
      {
         this.shouldGrab = false;

         var exportTexture = new Texture2D((int)this.grabRect.width, (int)this.grabRect.height, TextureFormat.RGB24, false);
         exportTexture.ReadPixels(
            new Rect((int)this.grabRect.xMin, this.viewportRect.height - (int)this.grabRect.yMax + 16, exportTexture.width, exportTexture.height),
            0,
            0);
         exportTexture.Apply();

         //var path = GeneratePath(grabName);
         //exportTexture.SaveAs(path);

         var pixels = exportTexture.GetPixels32();
         var white = 0;
         var black = pixels.Length / 2;

         var export = new Color32[black];

         for (var i = 0; i < export.Length; i++)
         {
            if (pixels[white].Equals(pixels[black]))
            {
               export[white] = pixels[white];
            }
            else
            {
               var alpha = 1 - ((pixels[white].r - pixels[black].r) / 255f);
               uScriptDebug.Assert(alpha >= 0 && alpha <= 1);

               export[white].r = (byte)(pixels[black].r / alpha);
               export[white].g = (byte)(pixels[black].g / alpha);
               export[white].b = (byte)(pixels[black].b / alpha);
               export[white].a = (byte)(alpha * 255);
            }

            white++;
            black++;
         }

         exportTexture = new Texture2D((int)this.grabRect.width, (int)this.grabRect.height / 2);
         exportTexture.SetPixels32(export);
         exportTexture.Apply();

         var path = GeneratePath(this.grabName);
         exportTexture.SaveAs(path);

         Debug.Log("Exported '" + this.grabName + "' as a 32-bit PNG\n        at '" + path.RelativeProjectPath() + "'.\n");
      }
   }

   private void DrawIconStyleState(GUIStyleState state, string label)
   {
      if (state == null || state.background == null)
      {
         return;
      }

      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.Label(label);
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndHorizontal();

      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.Box(state.background);
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndHorizontal();
   }

   private void SetSelectedIcon(GUIStyle icon)
   {
      this.selectedIcon = icon;
      this.drawScale = 1.0f;
   }

   private void DrawIconSelectionGrid(GUIStyle[] icons, float maxIconWidth)
   {
      var sidePanelWidth = CalculateSidePanelWidth();
      var count = Mathf.FloorToInt((position.width - sidePanelWidth - ScrollbarWidth) / (maxIconWidth + SelectionGridPadding));
      var selected = GUILayout.SelectionGrid(-1, icons.Select(style => style.normal.background).ToArray(), count, GUI.skin.box);

      if (selected > -1)
      {
         SetSelectedIcon(icons[selected]);
      }
   }

   private void DrawCenteredMessage(string msg)
   {
      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      EditorGUILayout.BeginVertical();
      GUILayout.FlexibleSpace();
      GUILayout.Label(msg);
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndVertical();
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndHorizontal();
   }

   private void DrawHelpIcon()
   {
      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      if (GUILayout.Button(string.Empty, this.editorSkin.GetStyle("CN EntryInfo")))
      {
         EditorUtility.DisplayDialog("Editor Icon Viewer", UsageString, "Ok");
      }
      EditorGUILayout.EndHorizontal();
   }

   public class IconGroup
   {
      public string Name { get; set; }

      public GUIStyle[] IconData { get; set; }

      public float IconWidthThreshold { get; set; }

      public float MaxWidth { get; set; }
   }
}
