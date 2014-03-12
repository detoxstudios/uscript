using UnityEditor;
using UnityEngine;

public class PreferenceWindow : EditorWindow
{
   const int _labelWidth = 200;
   const int _valueWidth = 110;

   const int _minGridSize = 8;
   const int _maxGridSize = 100;
   const int _minGridSubdivisions = 1;
   const int _maxGridSubdivisions = 10;

   const float _minProfileTime = 0.01f;
   const float _maxProfileTime = 10f;

   const int _minPropertyPanelNodes = 1;
   const int _maxPropertyPanelNodes = 20;

   const int _minRecursion = 100;
   const int _maxRecursion = 10000;

   RectOffset _padding = new RectOffset(16, 16, 8, 16);

   GUIStyle _styleWindow;
   GUIStyle _styleCloseButton;

   bool _firstRun = true;
   bool _saveOnClose = false;
   Rect _position;

   Preferences _preferences = null;
   static PreferenceWindow window = null;




   // Create the window
   public static void Init()
   {
      // Get existing open window or if none, make a new one:
      window = EditorWindow.GetWindow<PreferenceWindow>(true, "uScript Preferences", true) as PreferenceWindow;
      window._firstRun = true;   // unnecessary, but we'll get a warning that 'window' is unused, otherwise
   }


   void OnEnable()
   {
      // Inform uScript that the Preferences window is open
      uScript.Instance.isPreferenceWindowOpen = true;

      // Setup the custom GUIStyles used to layout the window
      _styleWindow = null;
      _styleCloseButton = null;
   }


   void OnDisable()
   {
      _preferences = uScript.Preferences;

      // Inform uScript that the Preferences window has been closed
      uScript.Instance.isPreferenceWindowOpen = false;

      if (_saveOnClose)
      {
         // Save the changes and close the window
         _preferences.Save();
      }
      else
      {
         // Revert to the saved version and close the window
         _preferences.Load();
      }
   }


   void OnFocus()
   {
   }


   void OnLostFocus()
   {
   }


   void OnGUI()
   {
      if (_firstRun)
      {
         _firstRun = false;

         // Force the window to a position relative to the uScript window
         base.position = new Rect(uScript.Instance.position.x + 50, uScript.Instance.position.y + 50, 0, 0);
      }

      if (_position != new Rect())
      {
         // Set the min and max window dimensions to prevent resizing
         base.minSize = new Vector2(_position.width + _padding.left + _padding.right, _position.height + _padding.top + _padding.bottom);
         base.maxSize = base.minSize;
      }

      if (this._styleWindow == null)
      {
         // Setup the custom GUIStyles used to layout the window
         this._styleWindow = new GUIStyle { margin = this._padding, fixedWidth = _labelWidth + _valueWidth };

         this._styleCloseButton = new GUIStyle(GUI.skin.button);
         this._styleCloseButton.fixedWidth = (_labelWidth + _valueWidth - 4 - (this._styleCloseButton.margin.left * 4)) * 0.5f;

      }

      // Get the Preferences
      _preferences = uScript.Preferences;

      EditorGUIUtility.LookLikeControls(_labelWidth, _valueWidth);

      EditorGUILayout.BeginVertical(_styleWindow);
      {
         EditorGUI.indentLevel = 1;

         //
         // Project Settings
         //
         GUILayout.Label("Project Graphs Location", EditorStyles.boldLabel);

         string path = uScriptConfig.ConstantPaths.RelativePath(_preferences.UserScripts);
         if (path.Length > 64) path = path.Substring(0, 64) + "...";

         if (GUILayout.Button(path, uScriptGUIStyle.ContextMenu))
         {
            path = EditorUtility.OpenFolderPanel("uScript Project Files", _preferences.UserScripts, "");
            if ("" != path) _preferences.UserScripts = path;
         }

         EditorGUILayout.Separator();

         //
         // Code Generation Settings
         //
         GUILayout.Label("Code Generation Settings", EditorStyles.boldLabel);

         _preferences.MaximumNodeRecursionCount = Mathf.Min(_maxRecursion, Mathf.Max(_minRecursion, EditorGUILayout.IntField("Maximum Node Recursion", _preferences.MaximumNodeRecursionCount)));
         _preferences.SaveMethod = (Preferences.SaveMethodType)EditorGUILayout.EnumPopup("Save Method", _preferences.SaveMethod);

         EditorGUILayout.Separator();

         //
         // Grid Settings
         //
         GUILayout.Label("Grid Settings", EditorStyles.boldLabel);

         _preferences.ShowGrid = EditorGUILayout.Toggle("Show Grid", _preferences.ShowGrid);
         _preferences.GridSize = Mathf.Min(_maxGridSize, Mathf.Max(_minGridSize, EditorGUILayout.IntField("Grid Size", _preferences.GridSize)));
         _preferences.GridSubdivisions = Mathf.Min(_maxGridSubdivisions, Mathf.Max(_minGridSubdivisions, EditorGUILayout.IntField("Subdivisions", _preferences.GridSubdivisions)));
         EditorGUILayout.BeginHorizontal();
         {
            _preferences.GridColorMajor = EditorGUILayout.ColorField("Line Color (major, minor)", _preferences.GridColorMajor, GUILayout.Width(_styleWindow.fixedWidth - 67));
            GUILayout.Space(3);
            EditorGUIUtility.LookLikeControls(0, 30);
            _preferences.GridColorMinor = EditorGUILayout.ColorField(_preferences.GridColorMinor);
            EditorGUIUtility.LookLikeControls(_labelWidth, _valueWidth);
         }
         EditorGUILayout.EndHorizontal();

         EditorGUILayout.Separator();

         //
         // Node Settings
         //
         GUILayout.Label("Node Settings", EditorStyles.boldLabel);

         _preferences.DoubleClickBehavior = (Preferences.DoubleClickBehaviorType)EditorGUILayout.EnumPopup("Double-Click Behavior", _preferences.DoubleClickBehavior);
         _preferences.VariableExpansion = (Preferences.VariableExpansionType)EditorGUILayout.EnumPopup("Variable Expansion Mode", _preferences.VariableExpansion);
         _preferences.GridSnap = EditorGUILayout.Toggle("Snap to Grid", _preferences.GridSnap);

         EditorGUILayout.Separator();

         //
         // Performance and Profiling Settings
         //
         GUILayout.Label("Performance Settings", EditorStyles.boldLabel);

         _preferences.AutoExpandToolbox = EditorGUILayout.Toggle("Auto-Expand Toolbox on Search", _preferences.AutoExpandToolbox);

         _preferences.DrawPanelsOnUpdate = EditorGUILayout.Toggle("Draw Panels During Update", _preferences.DrawPanelsOnUpdate);

         EditorGUILayout.BeginHorizontal();
         {
            _preferences.Profiling = EditorGUILayout.Toggle("Profiling [time threshold]", _preferences.Profiling, GUILayout.Width(220));

            GUI.enabled = _preferences.Profiling;
            EditorGUIUtility.LookLikeControls(0, 30);
            _preferences.ProfileMin = Mathf.Min(_maxProfileTime, Mathf.Max(_minProfileTime, EditorGUILayout.FloatField(_preferences.ProfileMin)));
            EditorGUIUtility.LookLikeControls(_labelWidth, _valueWidth);
            GUI.enabled = true;
         }
         EditorGUILayout.EndHorizontal();

         _preferences.PropertyPanelNodeLimit = Mathf.Min(_maxPropertyPanelNodes, Mathf.Max(_minPropertyPanelNodes, EditorGUILayout.IntField("Property Panel Node Limit", _preferences.PropertyPanelNodeLimit)));

         EditorGUILayout.Separator();

         //
         // Misc Settings
         //
         GUILayout.Label("Miscellaneous Settings", EditorStyles.boldLabel);

         _preferences.ShowAtStartup = EditorGUILayout.Toggle("Show Welcome Window on Start", _preferences.ShowAtStartup);
         EditorGUILayout.BeginHorizontal();
         {
            _preferences.CheckForUpdate = EditorGUILayout.Toggle("Check for Updates on Start", _preferences.CheckForUpdate);
            if (GUILayout.Button("Check Now\u00A0", GUILayout.ExpandWidth(false)))
            {
               UpdateNotification.ManualCheck();
            }
         }
         EditorGUILayout.EndHorizontal();

         // Add some development fields for debugging and testing
         if (uScript.IsDevelopmentBuild)
         {
            _preferences.LastUpdateCheck = EditorGUILayout.IntField("Last Update Check", _preferences.LastUpdateCheck);
            _preferences.IgnoreUpdateBuild = EditorGUILayout.TextField("Ignore Build", _preferences.IgnoreUpdateBuild);
         }

         EditorGUILayout.Separator();
         EditorGUILayout.Space();
         EditorGUILayout.Separator();


         //revert to default
         if (GUILayout.Button("Revert All Settings to Default Values"))
         {
            _preferences.Revert();
         }

         EditorGUILayout.Separator();


         //save or cancel
         EditorGUILayout.BeginHorizontal();
         {
            if (GUILayout.Button("Cancel", _styleCloseButton, GUILayout.ExpandWidth(true)))
            {
               this.Close();
            }

            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Save", _styleCloseButton, GUILayout.ExpandWidth(true)))
            {
               _saveOnClose = true;
               this.Close();
            }
         }
         EditorGUILayout.EndHorizontal();

         EditorGUI.indentLevel = 0;
      }
      EditorGUILayout.EndVertical();

      if (Event.current.type == EventType.Repaint)
      {
         _position = GUILayoutUtility.GetLastRect();
      }
   }
}
