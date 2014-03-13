// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PreferenceWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2014 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PreferenceWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   using UnityEditor;

   using UnityEngine;

   public class PreferenceWindow : EditorWindow
   {
      private const int LabelWidth = 200;
      private const int ValueWidth = 110;

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

      private static PreferenceWindow window;

      private readonly RectOffset padding = new RectOffset(16, 16, 8, 16);

      private GUIStyle styleWindow;
      private GUIStyle styleCloseButton;

      private bool firstRun = true;
      private bool saveOnClose;
      private Rect windowPosition;

      private Preferences preferences;

      public static void Init()
      {
         // ReSharper disable once RedundantNameQualifier
         window = EditorWindow.GetWindow<PreferenceWindow>(true, "uScript Preferences", true);
         window.firstRun = true;
      }

      internal void OnEnable()
      {
         // Inform uScript that the Preferences window is open
         uScript.Instance.isPreferenceWindowOpen = true;

         // Setup the custom GUIStyles used to layout the window
         this.styleWindow = null;
         this.styleCloseButton = null;
      }

      internal void OnDisable()
      {
         this.preferences = uScript.Preferences;

         // Inform uScript that the Preferences window has been closed
         uScript.Instance.isPreferenceWindowOpen = false;

         if (this.saveOnClose)
         {
            // Save the changes and close the window
            this.preferences.Save();
         }
         else
         {
            // Revert to the saved version and close the window
            this.preferences.Load();
         }
      }

      internal void OnGUI()
      {
         if (this.firstRun)
         {
            this.firstRun = false;

            // Force the window to a position relative to the uScript window
            this.position = new Rect(uScript.Instance.position.x + 50, uScript.Instance.position.y + 50, 0, 0);
         }

         if (this.windowPosition != new Rect())
         {
            // Set the min and max window dimensions to prevent resizing
            this.minSize = new Vector2(this.windowPosition.width + this.padding.left + this.padding.right, this.windowPosition.height + this.padding.top + this.padding.bottom);
            this.maxSize = this.minSize;
         }

         if (this.styleWindow == null)
         {
            // Setup the custom GUIStyles used to layout the window
            this.styleWindow = new GUIStyle { margin = this.padding, fixedWidth = LabelWidth + ValueWidth };

            this.styleCloseButton = new GUIStyle(UnityEngine.GUI.skin.button);
            this.styleCloseButton.fixedWidth = (LabelWidth + ValueWidth - 4 - (this.styleCloseButton.margin.left * 4)) * 0.5f;
         }

         // Get the Preferences
         this.preferences = uScript.Preferences;

         EditorGUIUtility.LookLikeControls(LabelWidth, ValueWidth);

         EditorGUILayout.BeginVertical(this.styleWindow);
         {
            EditorGUI.indentLevel = 1;

            // Project Settings
            GUILayout.Label("Project Graphs Location", EditorStyles.boldLabel);

            string path = uScriptConfig.ConstantPaths.RelativePath(this.preferences.UserScripts);
            if (path.Length > 64)
            {
               path = path.Substring(0, 64) + "...";
            }

            if (GUILayout.Button(path, uScriptGUIStyle.ContextMenu))
            {
               path = EditorUtility.OpenFolderPanel("uScript Project Files", this.preferences.UserScripts, string.Empty);
               if (string.Empty != path)
               {
                  this.preferences.UserScripts = path;
               }
            }

            EditorGUILayout.Separator();

            // Code Generation Settings
            GUILayout.Label("Code Generation Settings", EditorStyles.boldLabel);

            this.preferences.MaximumNodeRecursionCount = Mathf.Min(MaxRecursion, Mathf.Max(MinRecursion, EditorGUILayout.IntField("Maximum Node Recursion", this.preferences.MaximumNodeRecursionCount)));
            this.preferences.SaveMethod = (Preferences.SaveMethodType)EditorGUILayout.EnumPopup("Save Method", this.preferences.SaveMethod);

            EditorGUILayout.Separator();

            // Grid Settings
            GUILayout.Label("Grid Settings", EditorStyles.boldLabel);

            this.preferences.ShowGrid = EditorGUILayout.Toggle("Show Grid", this.preferences.ShowGrid);
            this.preferences.GridSize = Mathf.Min(MaxGridSize, Mathf.Max(MinGridSize, EditorGUILayout.IntField("Grid Size", this.preferences.GridSize)));
            this.preferences.GridSubdivisions = Mathf.Min(MaxGridSubdivisions, Mathf.Max(MinGridSubdivisions, EditorGUILayout.IntField("Subdivisions", this.preferences.GridSubdivisions)));
            EditorGUILayout.BeginHorizontal();
            {
               this.preferences.GridColorMajor = EditorGUILayout.ColorField("Line Color (major, minor)", this.preferences.GridColorMajor, GUILayout.Width(this.styleWindow.fixedWidth - 67));
               GUILayout.Space(3);
               EditorGUIUtility.LookLikeControls(0, 30);
               this.preferences.GridColorMinor = EditorGUILayout.ColorField(this.preferences.GridColorMinor);
               EditorGUIUtility.LookLikeControls(LabelWidth, ValueWidth);
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Separator();

            // Node Settings
            GUILayout.Label("Node Settings", EditorStyles.boldLabel);

            this.preferences.DoubleClickBehavior = (Preferences.DoubleClickBehaviorType)EditorGUILayout.EnumPopup("Double-Click Behavior", this.preferences.DoubleClickBehavior);
            this.preferences.VariableExpansion = (Preferences.VariableExpansionType)EditorGUILayout.EnumPopup("Variable Expansion Mode", this.preferences.VariableExpansion);
            this.preferences.GridSnap = EditorGUILayout.Toggle("Snap to Grid", this.preferences.GridSnap);

            EditorGUILayout.Separator();

            // Performance and Profiling Settings
            GUILayout.Label("Performance Settings", EditorStyles.boldLabel);

            this.preferences.AutoExpandToolbox = EditorGUILayout.Toggle("Auto-Expand Toolbox on Search", this.preferences.AutoExpandToolbox);

            this.preferences.DrawPanelsOnUpdate = EditorGUILayout.Toggle("Draw Panels During Update", this.preferences.DrawPanelsOnUpdate);

            EditorGUILayout.BeginHorizontal();
            {
               this.preferences.Profiling = EditorGUILayout.Toggle("Profiling [time threshold]", this.preferences.Profiling, GUILayout.Width(220));

               UnityEngine.GUI.enabled = this.preferences.Profiling;
               EditorGUIUtility.LookLikeControls(0, 30);
               this.preferences.ProfileMin = Mathf.Min(MaxProfileTime, Mathf.Max(MinProfileTime, EditorGUILayout.FloatField(this.preferences.ProfileMin)));
               EditorGUIUtility.LookLikeControls(LabelWidth, ValueWidth);
               UnityEngine.GUI.enabled = true;
            }

            EditorGUILayout.EndHorizontal();

            this.preferences.PropertyPanelNodeLimit = Mathf.Min(MaxPropertyPanelNodes, Mathf.Max(MinPropertyPanelNodes, EditorGUILayout.IntField("Property Panel Node Limit", this.preferences.PropertyPanelNodeLimit)));

            EditorGUILayout.Separator();

            // Misc Settings
            GUILayout.Label("Miscellaneous Settings", EditorStyles.boldLabel);

            this.preferences.ShowAtStartup = EditorGUILayout.Toggle("Show Welcome Window on Start", this.preferences.ShowAtStartup);
            EditorGUILayout.BeginHorizontal();
            {
               this.preferences.CheckForUpdate = EditorGUILayout.Toggle("Check for Updates on Start", this.preferences.CheckForUpdate);
               if (GUILayout.Button("Check Now\u00A0", GUILayout.ExpandWidth(false)))
               {
                  UpdateNotification.ManualCheck();
               }
            }

            EditorGUILayout.EndHorizontal();

            // Add some development fields for debugging and testing
            if (uScript.IsDevelopmentBuild)
            {
               this.preferences.LastUpdateCheck = EditorGUILayout.IntField("Last Update Check", this.preferences.LastUpdateCheck);
               this.preferences.IgnoreUpdateBuild = EditorGUILayout.TextField("Ignore Build", this.preferences.IgnoreUpdateBuild);
            }

            EditorGUILayout.Separator();
            EditorGUILayout.Space();
            EditorGUILayout.Separator();

            //revert to default
            if (GUILayout.Button("Revert All Settings to Default Values"))
            {
               this.preferences.Revert();
            }

            EditorGUILayout.Separator();

            //save or cancel
            EditorGUILayout.BeginHorizontal();
            {
               if (GUILayout.Button("Cancel", this.styleCloseButton, GUILayout.ExpandWidth(true)))
               {
                  this.Close();
               }

               GUILayout.FlexibleSpace();

               if (GUILayout.Button("Save", this.styleCloseButton, GUILayout.ExpandWidth(true)))
               {
                  this.saveOnClose = true;
                  this.Close();
               }
            }

            EditorGUILayout.EndHorizontal();

            EditorGUI.indentLevel = 0;
         }

         EditorGUILayout.EndVertical();

         if (Event.current.type == EventType.Repaint)
         {
            this.windowPosition = GUILayoutUtility.GetLastRect();
         }
      }
   }
}
