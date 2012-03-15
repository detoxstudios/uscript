using UnityEditor;
using UnityEngine;

public class PreferenceWindow : EditorWindow
{
   const int _labelWidth = 200;
   const int _valueWidth = 110;

   const int _minGridSize = 8;
   const int _maxGridSize = 100;
   const int _minGridMajorSpacing = 1;
   const int _maxGridMagicSpacing = 10;

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
      _styleWindow = new GUIStyle();
      _styleWindow.margin = _padding;
      _styleWindow.fixedWidth = _labelWidth + _valueWidth;

      _styleCloseButton = new GUIStyle(GUI.skin.button);
      _styleCloseButton.fixedWidth = (_labelWidth + _valueWidth - 4 - _styleCloseButton.margin.left * 4) * 0.5f;
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

//      if (_position != new Rect() && base.position.width != s_WantSize.x || base.position.height != s_WantSize.y)
//      if (_position != new Rect())
//      {
//         Rect position = base.position;
//         position.width = _position.x;
//         position.height = _position.y;
//         base.position = position;
//         base.minSize = new Vector2(_position.width + _padding.left + _padding.right, _position.height + _padding.top + _padding.bottom);
//         base.maxSize = base.minSize;
//      }








      // Get the Preferences
      _preferences = uScript.Preferences;

      EditorGUIUtility.LookLikeControls(_labelWidth, _valueWidth);

      EditorGUILayout.BeginVertical(_styleWindow);
      {
         EditorGUI.indentLevel = 1;

         //
         // Project Settings
         //
         GUILayout.Label("Project File Location", EditorStyles.boldLabel);

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
         GUILayout.Label("CodeGeneration", EditorStyles.boldLabel);

         _preferences.MaximumNodeRecursionCount = (int)EditorGUILayout.IntField("Maximum Node Recursion", _preferences.MaximumNodeRecursionCount);

         EditorGUILayout.Separator();

         //
         // Panel Settings
         //
         GUILayout.Label("Panel Settings", EditorStyles.boldLabel);

         _preferences.DrawPanelsOnUpdate = EditorGUILayout.Toggle("Draw Panels During Update", _preferences.DrawPanelsOnUpdate);

         EditorGUILayout.Separator();

         //
         // Grid Settings
         //
         GUILayout.Label("Grid Settings", EditorStyles.boldLabel);

         _preferences.ShowGrid = EditorGUILayout.Toggle("Show Grid", _preferences.ShowGrid);
         _preferences.GridSizeVertical = Mathf.Min(_maxGridSize, Mathf.Max(_minGridSize, EditorGUILayout.FloatField("Grid Size Vertical", _preferences.GridSizeVertical)));
         _preferences.GridSizeHorizontal = Mathf.Min(_maxGridSize, Mathf.Max(_minGridSize, EditorGUILayout.FloatField("Grid Size Horizontal", _preferences.GridSizeHorizontal)));
         _preferences.GridMajorLineSpacing = Mathf.Min(_maxGridMagicSpacing, Mathf.Max(_minGridMajorSpacing, EditorGUILayout.IntField("Grid Major Line Spacing", _preferences.GridMajorLineSpacing)));
         _preferences.GridColorMajor = EditorGUILayout.ColorField("Grid Color Major", _preferences.GridColorMajor);
         _preferences.GridColorMinor = EditorGUILayout.ColorField("Grid Color Minor", _preferences.GridColorMinor);

         EditorGUILayout.Separator();

         //
         // Misc Settings
         //
         GUILayout.Label("Miscellaneous Settings", EditorStyles.boldLabel);

         _preferences.VariableExpansion = (Preferences.VariableExpansionType)EditorGUILayout.EnumPopup("Variable Expansion Mode", _preferences.VariableExpansion);
         _preferences.ShowAtStartup = EditorGUILayout.Toggle("Show Welcome Window at Startup", _preferences.ShowAtStartup);
         EditorGUILayout.BeginHorizontal();
         {
            _preferences.CheckForUpdate = EditorGUILayout.Toggle("Check for Updates at Startup", _preferences.CheckForUpdate);
            if (GUILayout.Button("Check Now\u00A0", GUILayout.ExpandWidth(false)))
            {
               UpdateNotification.ManualCheck();
            }
         }
         EditorGUILayout.EndHorizontal();

         if ( uScript.Instance.IsDevelopmentBuild )
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


   void Update()
   {
   }
}
