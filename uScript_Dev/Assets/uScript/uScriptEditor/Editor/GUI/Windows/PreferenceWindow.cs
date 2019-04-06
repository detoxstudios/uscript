// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PreferenceWindow.cs" company="Detox Studios LLC">
//   Copyright 2010-2015 Detox Studios LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI.Windows
{
   using System.Diagnostics.CodeAnalysis;

   using Detox.Editor;
   using Detox.Editor.GUI;

   using UnityEditor;

   using UnityEngine;

   [SuppressMessage("ReSharper", "RedundantNameQualifier")]
   public class PreferenceWindow : MonoBehaviour
   {
      private const int LabelWidth = 225;
      private const int ValueWidth = 100;

      private const int MinGridSize = 8;
      private const int MaxGridSize = 100;
      private const int MinGridSubdivisions = 1;
      private const int MaxGridSubdivisions = 10;

      private const float MinProfileTime = 0.01f;
      private const float MaxProfileTime = 10f;

      private const int MinPropertyPanelNodes = 1;
      private const int MaxPropertyPanelNodes = 20;

      private const int MinRecursion = 100;
      private const int MaxRecursion = 10000;

      private const int MultilineMinHeight = 1;
      private const int MultilineMaxHeight = 10;

      private static Vector2 scrollPos = new Vector2(0.0f, 0.0f);

      [PreferenceItem("uScript")]
      public static void PreferencesGUI()
      {
         // Get the Preferences
         Preferences.LoadDefaultsIfRequired();

         scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, true);
         {
#if !(UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
            EditorGUIUtility.labelWidth = LabelWidth;
            EditorGUIUtility.fieldWidth = ValueWidth;
#else
            EditorGUIUtility.LookLikeControls(LabelWidth, ValueWidth);
#endif

            EditorGUILayout.BeginVertical();//Style.Window);
            {
//               EditorGUI.indentLevel = 1;

               DrawProjectSettings();
               DrawCodeGenerationSettings();
               DrawGridSettings();
               DrawNodeSettings();
               DrawPerformanceSettings();
               DrawMiscellaneousSettings();
               DrawDevDebugSettings();

//               EditorGUI.indentLevel = 0;
            
               EditorGUILayout.Space();

               DrawButtons();
            }

            EditorGUILayout.EndVertical();
         }
         EditorGUILayout.EndScrollView();
      }

      private static void DrawButtons()
      {
         EditorGUILayout.Separator();

         if (GUILayout.Button("Revert All Settings to Default Values"))
         {
            Preferences.Revert();
         }
      }

      private static void DrawCodeGenerationSettings()
      {
         GUILayout.Label("Code Generation Settings", EditorStyles.boldLabel);

         var maxValue = EditorGUILayout.IntField("Maximum Node Recursion", Preferences.MaximumNodeRecursionCount);
         Preferences.MaximumNodeRecursionCount = Mathf.Min(MaxRecursion, Mathf.Max(MinRecursion, maxValue));

         var method = (Detox.Editor.Preferences.SaveMethodType)EditorGUILayout.EnumPopup("Save Method", Preferences.SaveMethod);
         Preferences.SaveMethod = method;

         var fieldWidth = EditorGUIUtility.fieldWidth;
         EditorGUIUtility.fieldWidth = 28;
         var multilineHeight = EditorGUILayout.IntSlider(
            "Inspector MultiLine Height",
            Preferences.MultilineHeight,
            MultilineMinHeight,
            MultilineMaxHeight);
            Preferences.MultilineHeight = Mathf.Min(
            MultilineMaxHeight,
            Mathf.Max(MultilineMinHeight, multilineHeight));
         EditorGUIUtility.fieldWidth = fieldWidth;

         EditorGUILayout.Separator();
      }

      private static void DrawGridSettings()
      {
         GUILayout.Label("Grid Settings", EditorStyles.boldLabel);

         Preferences.ShowGrid = EditorGUILayout.Toggle("Show Grid", Preferences.ShowGrid);

         var intValue = EditorGUILayout.IntField("Grid Size", Preferences.GridSize);
         Preferences.GridSize = Mathf.Min(MaxGridSize, Mathf.Max(MinGridSize, intValue));

         intValue = EditorGUILayout.IntField("Subdivisions", Preferences.GridSubdivisions);
         Preferences.GridSubdivisions = Mathf.Min(MaxGridSubdivisions, Mathf.Max(MinGridSubdivisions, intValue));

         EditorGUILayout.BeginHorizontal();
         {
            Preferences.GridColorMajor = EditorGUILayout.ColorField(
               "Line Color (major, minor)",
               Preferences.GridColorMajor,
               GUILayout.Width(Style.Window.fixedWidth - 45));
            GUILayout.Space(3);

//            EditorGUI.indentLevel--;

#if !(UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
            EditorGUIUtility.fieldWidth = 30;
#else
            EditorGUIUtility.LookLikeControls(0, 30);
#endif

            Preferences.GridColorMinor = EditorGUILayout.ColorField(Preferences.GridColorMinor);

#if !(UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
            EditorGUIUtility.labelWidth = LabelWidth;
            EditorGUIUtility.fieldWidth = ValueWidth;
#else
            EditorGUIUtility.LookLikeControls(LabelWidth, ValueWidth);
#endif
//            EditorGUI.indentLevel++;
         }

         EditorGUILayout.EndHorizontal();

         EditorGUILayout.Separator();
      }

      private static void DrawMiscellaneousSettings()
      {
         GUILayout.Label("Miscellaneous Settings", EditorStyles.boldLabel);

         var location = (Detox.Editor.Preferences.MenuLocationType)EditorGUILayout.EnumPopup("Menu Location", Preferences.MenuLocation);
         Preferences.MenuLocation = location;

         var boolValue = EditorGUILayout.Toggle("Show Welcome Window on Start", Preferences.ShowAtStartup);
         Preferences.ShowAtStartup = boolValue;

         boolValue = EditorGUILayout.Toggle("Show uScript Icon in Hierarchy", Preferences.ShowHierarchyIcon);
         Preferences.ShowHierarchyIcon = boolValue;

         boolValue = EditorGUILayout.Toggle("Enable uScript Scene Warning", Preferences.EnableSceneWarning);
         Preferences.EnableSceneWarning = boolValue;

         boolValue = EditorGUILayout.Toggle("Enable First Save Attach Prompt", Preferences.EnableAttachOnSavePrompt);
         Preferences.EnableAttachOnSavePrompt = boolValue;

         boolValue = EditorGUILayout.Toggle("Search Fields in Contents Search", Preferences.EnableContentsFieldSearch);
         Preferences.EnableContentsFieldSearch = boolValue;

         EditorGUILayout.BeginHorizontal();
         {
            boolValue = EditorGUILayout.Toggle("Check for Updates on Start", Preferences.CheckForUpdate);
            Preferences.CheckForUpdate = boolValue;

            if (GUILayout.Button("Check Now", EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
            {
               UpdateNotification.ManualCheck();
            }
         }

         EditorGUILayout.EndHorizontal();

         EditorGUILayout.Separator();
      }

      private static void DrawDevDebugSettings()
      {
         if (uScript.IsDevelopmentBuild == false)
         {
            return;
         }

         GUILayout.Label("Development Debug Settings", EditorStyles.boldLabel);

         // Add some development fields for debugging and testing
         var promotionLastCheck = EditorGUILayout.IntField("Last Promotion Check", Preferences.LastPromotionCheck);
         Preferences.LastPromotionCheck = promotionLastCheck;

         var promotionIgnoreList = EditorGUILayout.TextField("Promotion Ignore List", Preferences.IgnorePromotions);
         Preferences.IgnorePromotions = promotionIgnoreList;

         var updateLastCheck = EditorGUILayout.IntField("Last Update Check", Preferences.LastUpdateCheck);
         Preferences.LastUpdateCheck = updateLastCheck;

         var updateIgnoreBuild = EditorGUILayout.TextField("Update Check Build Ignore ID", Preferences.IgnoreUpdateBuild);
         Preferences.IgnoreUpdateBuild = updateIgnoreBuild;

         EditorGUILayout.Separator();
      }

      private static void DrawNodeSettings()
      {
         GUILayout.Label("Node Settings", EditorStyles.boldLabel);

         Preferences.DoubleClickBehavior =
            (Detox.Editor.Preferences.DoubleClickBehaviorType)
            EditorGUILayout.EnumPopup("Double-Click Behavior", Preferences.DoubleClickBehavior);
         Preferences.VariableExpansion =
            (Detox.Editor.Preferences.VariableExpansionType)
            EditorGUILayout.EnumPopup("Variable Expansion Mode", Preferences.VariableExpansion);
         Preferences.GridSnap = EditorGUILayout.Toggle("Snap to Grid", Preferences.GridSnap);
         Preferences.LineWidthMultiplier = EditorGUILayout.FloatField("Connector Line Width", Preferences.LineWidthMultiplier);
         Preferences.LineSelectionTolerance = EditorGUILayout.FloatField("Line Selection Tolerance", Preferences.LineSelectionTolerance);

         EditorGUILayout.Separator();
      }

      private static void DrawPerformanceSettings()
      {
         GUILayout.Label("Performance Settings", EditorStyles.boldLabel);

         var boolValue = EditorGUILayout.Toggle("Auto-Expand Toolbox on Search", Preferences.AutoExpandToolbox);
         Preferences.AutoExpandToolbox = boolValue;

         boolValue = EditorGUILayout.Toggle("Draw Panels During Update", Preferences.DrawPanelsOnUpdate);
         Preferences.DrawPanelsOnUpdate = boolValue;

         EditorGUILayout.BeginHorizontal();
         {
            boolValue = Preferences.Profiling;
            boolValue = EditorGUILayout.Toggle("Profiling [time threshold]", boolValue, GUILayout.Width(LabelWidth + 20));
            Preferences.Profiling = boolValue;

//            EditorGUI.indentLevel--;

            UnityEngine.GUI.enabled = Preferences.Profiling;

#if !(UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
            EditorGUIUtility.fieldWidth = 30;
#else
            EditorGUIUtility.LookLikeControls(0, 30);
#endif

            var floatValue = EditorGUILayout.FloatField(Preferences.ProfileMin);
            Preferences.ProfileMin = Mathf.Min(MaxProfileTime, Mathf.Max(MinProfileTime, floatValue));

#if !(UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
            EditorGUIUtility.labelWidth = LabelWidth;
            EditorGUIUtility.fieldWidth = ValueWidth;
#else
            EditorGUIUtility.LookLikeControls(LabelWidth, ValueWidth);
#endif

            UnityEngine.GUI.enabled = true;
//            EditorGUI.indentLevel++;
         }

         EditorGUILayout.EndHorizontal();

         var intValue = EditorGUILayout.IntField("Property Panel Node Limit", Preferences.PropertyPanelNodeLimit);
         Preferences.PropertyPanelNodeLimit = Mathf.Min(
            MaxPropertyPanelNodes,
            Mathf.Max(MinPropertyPanelNodes, intValue));

         boolValue = EditorGUILayout.Toggle("Refresh on Hierarchy/Scene Change", Preferences.RefreshOnHierarchyChange);
         Preferences.RefreshOnHierarchyChange = boolValue;

         EditorGUILayout.Separator();
      }

      private static void DrawProjectSettings()
      {
         GUILayout.Label("Project Graphs Location", EditorStyles.boldLabel);

         EditorGUILayout.BeginHorizontal();
         {
            var path = uScriptConfig.ConstantPaths.RelativePath(Preferences.UserScripts);
            EditorGUILayout.SelectableLabel(path, EditorStyles.textField, GUILayout.Height(16));

            if (GUILayout.Button("Browse", EditorStyles.miniButton, GUILayout.Width(50)))
            {
               path = EditorUtility.OpenFolderPanel("uScript Project Files", Preferences.UserScripts, string.Empty);
               if (string.Empty != path)
               {
                  Preferences.UserScripts = path;
                  Preferences.ProjectFiles = path.Substring(0, path.LastIndexOf("/"));
                  Preferences.UserNodes = Preferences.ProjectFiles + "/Nodes";
                  Preferences.NestedScripts = Preferences.UserScripts + "/_GeneratedCode";
                  Preferences.GeneratedScripts = Preferences.UserScripts + "/_GeneratedCode";
               }
            }
         }

         EditorGUILayout.EndHorizontal();

         EditorGUILayout.Separator();
      }

      private static class Style
      {
         static Style()
         {
            CloseButton = new GUIStyle(UnityEngine.GUI.skin.button);
            CloseButton.fixedWidth = (LabelWidth + ValueWidth - 4 - (CloseButton.margin.left * 4)) * 0.5f;

            Window = new GUIStyle { margin = new RectOffset(16, 16, 8, 16), fixedWidth = LabelWidth + ValueWidth };
         }

         public static GUIStyle CloseButton { get; private set; }

         public static GUIStyle Window { get; private set; }
      }
   }
}
