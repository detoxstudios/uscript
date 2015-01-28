// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PreferenceWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PreferenceWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if !UNITY_3_5
namespace Detox.Editor.GUI.Windows
{
#endif
   using Detox.Editor.GUI;

   using UnityEditor;

   using UnityEngine;

   public class PreferenceWindow : EditorWindow
   {
      private const int LabelWidth = 230;
      private const int ValueWidth = 120;

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

      private readonly RectOffset padding = new RectOffset(16, 16, 8, 16);

      private bool saveOnClose;
      private Rect windowPosition;

      private Preferences.MenuLocationType originalLocation;

      private Preferences preferences;

      public static void Open()
      {
         GetWindow<PreferenceWindow>(true, "uScript Preferences", true);
      }

      internal void OnEnable()
      {
         uScript.PreferenceWindow = this;

         // Get the Preferences
         this.preferences = uScript.Preferences;
         uScript.LoadSettings();

         this.originalLocation = this.preferences.MenuLocation;
      }

      internal void OnDisable()
      {
         uScript.PreferenceWindow = null;

         if (this.saveOnClose)
         {
            // Save the changes and close the window
            this.preferences.Save();

            if (this.originalLocation != this.preferences.MenuLocation)
            {
               MenuLocation.Change(this.preferences.MenuLocation);
            }
         }
         else
         {
            // Revert to the saved version and close the window
            this.preferences.Load();
         }
      }

      internal void OnGUI()
      {
         if (this.windowPosition != new Rect())
         {
            // Set the min and max window dimensions to prevent resizing
            this.minSize = new Vector2(this.windowPosition.width + this.padding.left + this.padding.right, this.windowPosition.height + this.padding.top + this.padding.bottom);
            this.maxSize = this.minSize;
         }

         EditorGUIUtility.LookLikeControls(LabelWidth, ValueWidth);

         EditorGUILayout.BeginVertical(Style.Window);
         {
            EditorGUI.indentLevel = 1;

            this.DrawProjectSettings();
            this.DrawCodeGenerationSettings();
            this.DrawGridSettings();
            this.DrawNodeSettings();
            this.DrawPerformanceSettings();
            this.DrawMiscellaneousSettings();

            EditorGUI.indentLevel = 0;
            
            EditorGUILayout.Space();

            this.DrawButtons();
         }

         EditorGUILayout.EndVertical();

         if (Event.current.type == EventType.Repaint)
         {
            this.windowPosition = GUILayoutUtility.GetLastRect();
         }
      }

      private void DrawButtons()
      {
         EditorGUILayout.Separator();

         if (GUILayout.Button("Revert All Settings to Default Values"))
         {
            this.preferences.Revert();
         }

         EditorGUILayout.Separator();

         EditorGUILayout.BeginHorizontal();
         {
            if (GUILayout.Button("Cancel", Style.CloseButton, GUILayout.ExpandWidth(true)))
            {
               this.Close();
            }

            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Save", Style.CloseButton, GUILayout.ExpandWidth(true)))
            {
               this.saveOnClose = true;
               this.Close();
            }
         }

         EditorGUILayout.EndHorizontal();
      }

      private void DrawCodeGenerationSettings()
      {
         GUILayout.Label("Code Generation Settings", EditorStyles.boldLabel);

         var maxValue = EditorGUILayout.IntField("Maximum Node Recursion", this.preferences.MaximumNodeRecursionCount);
         this.preferences.MaximumNodeRecursionCount = Mathf.Min(MaxRecursion, Mathf.Max(MinRecursion, maxValue));

         var method = (Preferences.SaveMethodType)EditorGUILayout.EnumPopup("Save Method", this.preferences.SaveMethod);
         this.preferences.SaveMethod = method;

         EditorGUILayout.Separator();
      }

      private void DrawGridSettings()
      {
         GUILayout.Label("Grid Settings", EditorStyles.boldLabel);

         this.preferences.ShowGrid = EditorGUILayout.Toggle("Show Grid", this.preferences.ShowGrid);

         var intValue = EditorGUILayout.IntField("Grid Size", this.preferences.GridSize);
         this.preferences.GridSize = Mathf.Min(MaxGridSize, Mathf.Max(MinGridSize, intValue));

         intValue = EditorGUILayout.IntField("Subdivisions", this.preferences.GridSubdivisions);
         this.preferences.GridSubdivisions = Mathf.Min(MaxGridSubdivisions, Mathf.Max(MinGridSubdivisions, intValue));

         EditorGUILayout.BeginHorizontal();
         {
            this.preferences.GridColorMajor = EditorGUILayout.ColorField(
               "Line Color (major, minor)",
               this.preferences.GridColorMajor,
               GUILayout.Width(Style.Window.fixedWidth - 67));
            GUILayout.Space(3);

            EditorGUI.indentLevel--;

            EditorGUIUtility.LookLikeControls(0, 30);
            this.preferences.GridColorMinor = EditorGUILayout.ColorField(this.preferences.GridColorMinor);
            EditorGUIUtility.LookLikeControls(LabelWidth, ValueWidth);

            EditorGUI.indentLevel++;
         }

         EditorGUILayout.EndHorizontal();

         EditorGUILayout.Separator();
      }

      private void DrawMiscellaneousSettings()
      {
         GUILayout.Label("Miscellaneous Settings", EditorStyles.boldLabel);

         var location = (Preferences.MenuLocationType)EditorGUILayout.EnumPopup("Menu Location", this.preferences.MenuLocation);
         this.preferences.MenuLocation = location;

         var boolValue = EditorGUILayout.Toggle("Show Welcome Window on Start", this.preferences.ShowAtStartup);
         this.preferences.ShowAtStartup = boolValue;

         boolValue = EditorGUILayout.Toggle("Show uScript Icon in Hierarchy", this.preferences.ShowHierarchyIcon);
         this.preferences.ShowHierarchyIcon = boolValue;
         
         EditorGUILayout.BeginHorizontal();
         {
            boolValue = EditorGUILayout.Toggle("Check for Updates on Start", this.preferences.CheckForUpdate);
            this.preferences.CheckForUpdate = boolValue;

            if (GUILayout.Button("Check Now", EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
            {
               UpdateNotification.ManualCheck();
            }
         }

         EditorGUILayout.EndHorizontal();

         // Add some development fields for debugging and testing
         if (uScript.IsDevelopmentBuild)
         {
            var intValue = EditorGUILayout.IntField("Last Update Check", this.preferences.LastUpdateCheck);
            this.preferences.LastUpdateCheck = intValue;

            var textValue = EditorGUILayout.TextField("Ignore Build", this.preferences.IgnoreUpdateBuild);
            this.preferences.IgnoreUpdateBuild = textValue;
         }

         EditorGUILayout.Separator();
      }

      private void DrawNodeSettings()
      {
         GUILayout.Label("Node Settings", EditorStyles.boldLabel);

         this.preferences.DoubleClickBehavior =
            (Preferences.DoubleClickBehaviorType)
            EditorGUILayout.EnumPopup("Double-Click Behavior", this.preferences.DoubleClickBehavior);
         this.preferences.VariableExpansion =
            (Preferences.VariableExpansionType)
            EditorGUILayout.EnumPopup("Variable Expansion Mode", this.preferences.VariableExpansion);
         this.preferences.GridSnap = EditorGUILayout.Toggle("Snap to Grid", this.preferences.GridSnap);

         EditorGUILayout.Separator();
      }

      private void DrawPerformanceSettings()
      {
         GUILayout.Label("Performance Settings", EditorStyles.boldLabel);

         var boolValue = EditorGUILayout.Toggle("Auto-Expand Toolbox on Search", this.preferences.AutoExpandToolbox);
         this.preferences.AutoExpandToolbox = boolValue;

         boolValue = EditorGUILayout.Toggle("Draw Panels During Update", this.preferences.DrawPanelsOnUpdate);
         this.preferences.DrawPanelsOnUpdate = boolValue;

         EditorGUILayout.BeginHorizontal();
         {
            boolValue = this.preferences.Profiling;
            boolValue = EditorGUILayout.Toggle("Profiling [time threshold]", boolValue, GUILayout.Width(250));
            this.preferences.Profiling = boolValue;

            EditorGUI.indentLevel--;

            UnityEngine.GUI.enabled = this.preferences.Profiling;
            EditorGUIUtility.LookLikeControls(0, 30);

            var floatValue = EditorGUILayout.FloatField(this.preferences.ProfileMin);
            this.preferences.ProfileMin = Mathf.Min(MaxProfileTime, Mathf.Max(MinProfileTime, floatValue));

            EditorGUIUtility.LookLikeControls(LabelWidth, ValueWidth);
            UnityEngine.GUI.enabled = true;
            EditorGUI.indentLevel++;
         }

         EditorGUILayout.EndHorizontal();

         var intValue = EditorGUILayout.IntField("Property Panel Node Limit", this.preferences.PropertyPanelNodeLimit);
         this.preferences.PropertyPanelNodeLimit = Mathf.Min(
            MaxPropertyPanelNodes,
            Mathf.Max(MinPropertyPanelNodes, intValue));

         EditorGUILayout.Separator();
      }

      private void DrawProjectSettings()
      {
         GUILayout.Label("Project Graphs Location", EditorStyles.boldLabel);

         EditorGUILayout.BeginHorizontal();
         {
            var path = uScriptConfig.ConstantPaths.RelativePath(this.preferences.UserScripts);
            EditorGUILayout.SelectableLabel(path, EditorStyles.textField, GUILayout.Height(16));

            if (GUILayout.Button("Browse", EditorStyles.miniButton, GUILayout.Width(50)))
            {
               path = EditorUtility.OpenFolderPanel("uScript Project Files", this.preferences.UserScripts, string.Empty);
               if (string.Empty != path)
               {
                  this.preferences.UserScripts = path;
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
#if !UNITY_3_5
}
#endif
