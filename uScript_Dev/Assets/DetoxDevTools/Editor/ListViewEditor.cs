//using Detox.Drawing;
using Detox.Editor.GUI;
//using Detox.FlowChart;
using Detox.ScriptEditor;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using System.Reflection;

using UnityEngine;
using UnityEditor;

public class ListViewEditor : EditorWindow
{
   private static ListViewEditor _window;

   public static ListViewEditor Instance
   {
      get
      {
         if (_window == null)
         {
            Init();
         }
         return _window;
      }
   }

   [MenuItem ("Detox Tools/Internal/ListView Editor")]
   static void Init()
   {
      // Get existing open window or if none, make a new one:
      _window = EditorWindow.GetWindow(typeof(ListViewEditor), false, "ListView Editor") as ListViewEditor;
      _window.minSize = new Vector2(300, 0);
   }

   void OnGUI()
   {
      // Clear keyboard focus from search panels and other text fields, if necessary
      if (Event.current.type == EventType.MouseUp)
      {
         if (GUIUtility.hotControl != GUIUtility.keyboardControl)
         {
            GUIUtility.keyboardControl = 0;
            _window.Repaint();
         }
      }

      uScriptGUIPanelScriptNew panel = uScriptGUIPanelScriptNew.Instance;
      panel.Draw();

//      int controlID = GUIUtility.GetControlID(FocusType.Keyboard);
//
//      if (Event.current.GetTypeForControl(controlID) == EventType.KeyDown)
//      {
//         switch (Event.current.keyCode)
//         {
//            case KeyCode.KeypadEnter:
//            case KeyCode.UpArrow:
//            case KeyCode.DownArrow:
//            case KeyCode.Return:
//               Debug.Log("BLOCK 1: " + controlID.ToString() + "\n");
//               break;
////               EditorGUILayout.EndHorizontal();
////               return;
//
//            case KeyCode.RightArrow:
//            case KeyCode.LeftArrow:
//               Debug.Log("BLOCK 2: " + controlID.ToString() + "\n");
//               break;
////               if (base.hasSearchFilter)
////               {
////                 break;
////               }
////               EditorGUILayout.EndHorizontal();
////               return;
//         }
//      }

//      if (Event.current.type == EventType.Used)
//      {
//         Event e = Event.current;
//
////         Debug.Log(e.ToString());
////         Debug.Log("EVENT: " + Event.current.type.ToString() + "\n");
//
////         Debug.Log("hotControl: " + GUIUtility.hotControl.ToString() + ", keyboardControl: " + GUIUtility.keyboardControl.ToString() + "\n");
//      }
   }

   void OnProjectChange()
   {
      uScriptGUIPanelScriptNew panel = uScriptGUIPanelScriptNew.Instance;
      panel.OnProjectChange();
   }
}


// Make the Script list a standard selectable ListView
// One item can be selected at a time
// If selected item is a script, allow
//    View Source
//    Rebuild Source
//    Remove Generated Source
//    Load
// ListView contains multiple columns with headers
//    Source Status
//    Script name
//    Scene script is attached to
// Double-clicking the list item will execute the Load action
// Support foldouts
// Support column sort


public sealed class uScriptGUIPanelScriptNew: uScriptGUIPanel
{
   //
   // Singleton pattern
   //
   private static uScriptGUIPanelScriptNew _instance;

   public static uScriptGUIPanelScriptNew Instance
   {
      get
      {
         if (_instance == null)
         {
            _instance = new uScriptGUIPanelScriptNew();
         }
         return _instance;
      }
   }





   private uScriptGUIPanelScriptNew()
   {
      _instance = this;
      
      // TODO: Remove these initializations?
      uScriptGUIContent.Init();
      uScriptGUIStyle.Init();

      Init();
   }

   static uScript _uScriptInstance;

   //
   // Members specific to this panel class
   //
   string _panelFilterText = string.Empty;
   const double _doubleClickTime = 0.5; // default in Windows OS is 500ms
   double _clickTime;
//   string _clickedControl = string.Empty;

   string _currentScriptName = string.Empty;
   string _currentScriptFileName = string.Empty;

//   string _selectedScriptName = string.Empty;
//   string _selectedScriptFileName = string.Empty;



   static Rect _scrollviewRect = new Rect();
   static float _previousRowWidth = 0;
   int _widthButtonSource;
   int _widthButtonLoad;
   const int ROW_HEIGHT = 17;
   const int BUTTON_HEIGHT = 15;
   const int BUTTON_PADDING = 4;
   ListView _listView;

   private CustomContent _content;
   private CustomStyle _style;

   public Dictionary<string, Texture2D> Textures { get; private set; }

   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      _name = "uScripts";
//      _size = 150;
//      _region = uScriptGUI.Region.Script;

         Textures = new Dictionary<string, Texture2D>(5);

      if (_content == null)
      {
         _content = new CustomContent();

         // Create a table of icons for use outside of this class
         Textures = new Dictionary<string, Texture2D>(5);
         Textures.Add("iconScript", _content.iconScript);
         Textures.Add("iconScriptNested", _content.iconScriptNested);
         Textures.Add("iconSourceDebug", _content.iconSourceDebug);
         Textures.Add("iconSourceMissing", _content.iconSourceMissing);
         Textures.Add("iconSourceRelease", _content.iconSourceRelease);
      }

      if (_style == null)
      {
         _style = new CustomStyle();
      }

//      _listView = new ListView(ListViewEditor.Instance, ScriptItemDraw);
      _listView = new ListView(ListViewEditor.Instance, null);

      _listView.Init();
      _listView.MultiSelectEnabled = false;

      _listView.AddColumn("graph", new GUIContent("Graph"), 150, 100, 250, true);
      _listView.AddColumn("scene", new GUIContent("Scene"), 150, 50, 250, false);
      _listView.AddColumn("state", GUIContent.none, 20, 20, 20, false);

      _listView.ShowColumnHeaders = true;
      _listView.SortByColumn = true;

//      _listView



      if (uScriptGUIContent.buttonNodeSource == null)
      {
         Debug.Log("CONTENT IS NULL\n");
      }

      // Get the width of the buttons, since the content
      // under Windows has a different size then under Mac
      _widthButtonSource = (int)_style.styleMiniButtonLeft.CalcSize(uScriptGUIContent.buttonNodeSource).x;
      _widthButtonLoad = (int)_style.styleMiniButtonRight.CalcSize(uScriptGUIContent.buttonScriptLoad).x;

      if (_widthButtonSource == -1 || _widthButtonLoad == -1 || _previousRowWidth == -1 || _scrollviewRect == new Rect())
      {
      }

      OnProjectChange();
   }

   public void Update()
   {
      //
      // Called whenever member data should be updated
      //
   }

   /// <summary>
   /// Draw this panel.  This method should only be called during OnGUI.
   /// </summary>
   public override void Draw()
   {
      // Local references to uScript
      _uScriptInstance = uScript.Instance;
//      ScriptEditorCtrl m_ScriptEditorCtrl = _uScriptInstance.ScriptEditorCtrl;

      if (_listView.PendingExecution != null)
      {
         Debug.Log("EXECUTE LOAD of \"" + _listView.PendingExecution.path + "\"\n");
         _listView.PendingExecution = null;
      }

      Rect rect = EditorGUILayout.BeginVertical(/*uScriptGUIStyle.panelBox, GUILayout.Width(uScriptGUI.panelScriptsWidth) */);
      if (rect.width != 0.0f && rect.width != (float)uScriptGUI.panelScriptsWidth)
      {
         // if we didn't get the width we requested, we must have hit a limit, stop dragging and reset the width
         uScriptGUI.panelScriptsWidth = (int)rect.width;
         uScript.Instance.MouseDownRegion = uScript.MouseRegion.Canvas;
         uScript.Instance.ForceReleaseMouse();
      }
      else if (rect.x + rect.width > uScript.Instance.position.width)
      {
         // panel is growing off the edge of the window, bring it back in and stop dragging
         uScriptGUI.panelScriptsWidth = (int)(uScript.Instance.position.width - rect.x);
         uScript.Instance.MouseDownRegion = uScript.MouseRegion.Canvas;
         uScript.Instance.ForceReleaseMouse();
      }
      {
         DrawCurrentScriptPanel();

         GUILayout.Space(uScriptGUI.panelDividerThickness);

         DrawDirectoryPanel();
      }
      EditorGUILayout.EndVertical();

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Script);
      _uScriptInstance.SetMouseRegion(uScript.MouseRegion.Scripts);
   }

   private void DrawDirectoryPanel()
   {
      Rect rectPanel = EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, GUILayout.ExpandHeight(true));
      {
//         Event e = Event.current;
//
//         if (e.type == EventType.MouseDown || e.type == EventType.Used)
//         {
//
////               Focused = EditorWindow.focusedWindow && rectPanel.Contains(e.mousePosition);
//            bool newFocus = ((GUIUtility.keyboardControl == 0) && rectPanel.Contains(e.mousePosition));
//            if (newFocus == false && newFocus != _listView.hasFocus)
//            {
//               // check hotcontrol too
//               Debug.Log("REPAINT\n");
//               ListViewEditor.Instance.Repaint();
//            }
//
////            Debug.Log("FOCUS: " + _listView.hasFocus.ToString() + ", KEYBOARD CONTROL: " + GUIUtility.keyboardControl.ToString() + ", EVENT: " + e.ToString() + "\n");
//            Debug.Log("FOCUS: " + _listView.hasFocus.ToString() + ",\t\t" + "keyboardControl: " + GUIUtility.keyboardControl.ToString() + "\t\tEventType: " + e.type.ToString()
//               + "\n" + "\t\t\t\t\t\t" + "hotControl: " + GUIUtility.hotControl.ToString() + "\t\t\t\t\t" + "FocusChanged: " + (newFocus != _listView.hasFocus).ToString());
//
//            _listView.hasFocus = newFocus;
//         }



         DrawDirectoryPanelToolbar();

         if (_uScriptInstance.wasCanvasDragged && uScript.Preferences.DrawPanelsOnUpdate == false)
         {
            DrawHiddenNotification();
         }
         else
         {
            _listView.Draw(rectPanel);
//            ListViewItem[] selectedItems = _listView.selectedItems;
//            if (selectedItems.Length != 1)
//            {
//               GUI.enabled = false;
//            }
//            else
//            {
//               _selectedScriptName = "SCRIPT_" + selectedItems[0].text;
//               _selectedScriptFileName = "FILE_NAME";
//            }
//
//            DrawFileAccessButtons(_selectedScriptName, _selectedScriptFileName);
//
//            GUI.enabled = true;
         }

//         // Update the listview focus
//         if (e.type == EventType.MouseDown || e.type == EventType.Used)
//         {
//            bool newFocus = ((GUIUtility.keyboardControl == 0) && rectPanel.Contains(e.mousePosition));
//            if (newFocus != _listView.hasFocus)
//            {
//               ListViewEditor.Instance.Repaint();
//            }
//            _listView.hasFocus = newFocus;
//         }
      }
      EditorGUILayout.EndVertical();
   }

   private void DrawDirectoryPanelToolbar()
   {
      EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
      {
         GUILayout.Label("uScript Directory", uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));

         GUILayout.FlexibleSpace();

         GUI.SetNextControlName("ScriptFilterSearch");
         string filterText = uScriptGUI.ToolbarSearchField(_panelFilterText, GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
         if (_panelFilterText != filterText)
         {
            _panelFilterText = filterText.TrimStart();

            // Drop focus if the user inserted a newline (hit enter)
            if (filterText.Contains("\n"))
            {
               GUIUtility.keyboardControl = 0;
            }
         }
      }
      EditorGUILayout.EndHorizontal();
   }

   private void DrawFileAccessButtons(string scriptName, string scriptFileName)
   {
      GUILayout.BeginHorizontal();
      {
         GUILayout.BeginHorizontal(_style.styleButtonGroup);
         {
            bool isScriptNew = String.IsNullOrEmpty(_currentScriptFileName);
         
            if (isScriptNew == false)
            {
               GUIContent contentSourceButton;

               // Source button
               if (_uScriptInstance.IsStale(scriptName))
               {
                  contentSourceButton = uScriptGUIContent.buttonScriptSourceStale;
                  GUI.backgroundColor = UnityEngine.Color.red;
               }
               else if (_uScriptInstance.HasDebugCode(scriptName))
               {
                  contentSourceButton = uScriptGUIContent.buttonScriptSourceDebug;
                  GUI.backgroundColor = UnityEngine.Color.yellow;
               }
               else
               {
                  contentSourceButton = uScriptGUIContent.buttonScriptSource;
               }

               if (GUILayout.Button(contentSourceButton, EditorStyles.miniButtonLeft))
               {
                  uScriptGUI.PingGeneratedScript(scriptName);
               }
               GUI.backgroundColor = UnityEngine.Color.white;

               // Reload button
               if (GUILayout.Button(uScriptGUIContent.buttonScriptReload, EditorStyles.miniButtonMid))
               {
                  string path = _uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFileName);

                  if (path != string.Empty)
                  {
                     _uScriptInstance.OpenScript(path);
                  }
               }

               // Remove Generated Script

            }

            // Save button
            if (GUILayout.Button((uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick
                                 ? uScriptGUIContent.buttonScriptSaveQuick
                                 : (uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug
                                    ? uScriptGUIContent.buttonScriptSaveDebug
                                    : uScriptGUIContent.buttonScriptSaveRelease)),
                              isScriptNew ? EditorStyles.miniButton : EditorStyles.miniButtonRight))
            {
               _uScriptInstance.RequestSave(uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
                                        uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug, false);
            }
         }
         GUILayout.EndHorizontal();
      }
      GUILayout.EndHorizontal();
   }

   private void DrawFileAccessToolbarButtons(string scriptName, string scriptFileName)
   {
      bool isScriptNew = String.IsNullOrEmpty(_currentScriptFileName);

      if (isScriptNew == false)
      {
         GUIContent contentSourceButton;

         // Source button
         if (_uScriptInstance.IsStale(scriptName))
         {
            contentSourceButton = uScriptGUIContent.buttonScriptSourceStale;
            GUI.backgroundColor = UnityEngine.Color.red;
         }
         else if (_uScriptInstance.HasDebugCode(scriptName))
         {
            contentSourceButton = uScriptGUIContent.buttonScriptSourceDebug;
            GUI.backgroundColor = UnityEngine.Color.yellow;
         }
         else
         {
            contentSourceButton = uScriptGUIContent.buttonScriptSource;
         }

         if (GUILayout.Button(contentSourceButton, EditorStyles.toolbarButton))
         {
            uScriptGUI.PingGeneratedScript(scriptName);
         }
         GUI.backgroundColor = UnityEngine.Color.white;

         // Reload button
         if (GUILayout.Button(uScriptGUIContent.buttonScriptReload, EditorStyles.toolbarButton))
         {
            string path = _uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFileName);

            if (path != string.Empty)
            {
               _uScriptInstance.OpenScript(path);
            }
         }

         // Remove Generated Script

      }

      // Save button
      GUIContent saveButtonContent = (uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick
                                       ? uScriptGUIContent.buttonScriptSaveQuick
                                       : (uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug
                                          ? uScriptGUIContent.buttonScriptSaveDebug
                                          : uScriptGUIContent.buttonScriptSaveRelease));

      if (GUILayout.Button(saveButtonContent, EditorStyles.toolbarButton))
      {
         _uScriptInstance.RequestSave(uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
                                  uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug, false);
      }
   }


   /// <summary>
   /// Draws the script panel section that contains details on the current loaded script.
   /// </summary>
   private void DrawCurrentScriptPanel()
   {
      ScriptEditorCtrl m_ScriptEditorCtrl = _uScriptInstance.ScriptEditorCtrl;
   
      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox);
      {
         // Update the panel in the following manner:
         //
         //    Display the current active script first
         //    List the scene the script is associated with
         //    List error messages
         //
         //    Display some type of separator
         //
         //    Display all other scripts in the project (except the active script)
         //    Filter the list
         //    Support foldout containers eventually

         string currentSceneName = System.IO.Path.GetFileNameWithoutExtension(UnityEditor.EditorApplication.currentScene);
         string scriptSceneName = string.Empty;

         //
         // Current script
         //
         if (_currentScriptFileName != m_ScriptEditorCtrl.ScriptName)
         {
            _currentScriptFileName = m_ScriptEditorCtrl.ScriptName;
            _currentScriptName = System.IO.Path.GetFileNameWithoutExtension(_currentScriptFileName);
         }

         if (null == _currentScriptFileName)
         {
            _currentScriptFileName = string.Empty;
         }

         // uScript Label
         scriptSceneName = string.Empty;
         if (uScriptBackgroundProcess.s_uScriptInfo.ContainsKey(_currentScriptFileName))
         {
            if (string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[_currentScriptFileName].m_SceneName) == false)
            {
               scriptSceneName = uScriptBackgroundProcess.s_uScriptInfo[_currentScriptFileName].m_SceneName;
            }
         }

         bool isScriptAttachToScene = (scriptSceneName == currentSceneName);
         bool isScriptDirty = m_ScriptEditorCtrl.IsDirty;

         // Toolbar
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label("Current Graph", uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));

            GUILayout.FlexibleSpace();

            // TODO: Move the file access buttons to the toolbar
            DrawFileAccessToolbarButtons(_currentScriptName, _currentScriptFileName);
         }
         EditorGUILayout.EndHorizontal();

         Rect rect;
         string label;

         // Current uScript
         GUILayout.Label(GUIContent.none, GUILayout.Height(_content.iconScriptNested.height));
         if (Event.current.type != EventType.Layout)
         {
            rect = GUILayoutUtility.GetLastRect();

            label = (String.IsNullOrEmpty(_currentScriptFileName) ? "(new)" : _currentScriptName)
                     + (isScriptDirty ? " *" : string.Empty);

            GUI.Label(rect, _content.iconScriptNested, GUIStyle.none);
            rect.xMin += _content.iconScriptNested.width + 4;
            GUI.Label(rect, Ellipsis.Compact(label, GUI.skin.label, rect, Ellipsis.Format.Middle),
               _style.ScriptName);
         }

         // Associated Unity Scene
         GUILayout.Label(GUIContent.none, GUILayout.Height(_content.iconScriptNested.height));
         if (Event.current.type != EventType.Layout)
         {
            rect = GUILayoutUtility.GetLastRect();

            label = (scriptSceneName == string.Empty ? "(none)" : scriptSceneName);

            GUI.Label(rect, _content.iconUnityScene, GUIStyle.none);
            rect.xMin += _content.iconUnityScene.width + 4;
            GUI.Label(rect, Ellipsis.Compact(label, GUI.skin.label, rect, Ellipsis.Format.Middle),
               (isScriptAttachToScene || scriptSceneName == string.Empty ? _style.SceneName : _style.SceneNameError));
         }

         if (scriptSceneName == string.Empty)
         {
            GUILayout.Label(_content.NoScene, _style.ScriptMessage);
         }
         else if (scriptSceneName != currentSceneName)
         {
            GUILayout.Label(_content.WrongScene, _style.ScriptMessage);
         }
         else
         {
            GUILayout.Space(2);
         }
      }
      EditorGUILayout.EndVertical();
   }


   private static List<string> GetFileList(string baseDir, string searchPattern)
   {
      List<string> directories = new List<string>();
      List<string> files = new List<string>();

      directories.Add(baseDir);

      while (directories.Count > 0)
      {
         string directory = directories[0];
         directories.RemoveAt(0);

         try
            {
            foreach (string fileName in Directory.GetFiles(directory, searchPattern))
            {
               files.Add(fileName);
            }
         }
         catch (Exception e)
         {
            uScriptDebug.Log("Unable to access directory: \"" + directory + "\"\n" + e.ToString(), uScriptDebug.Type.Error);
            return files;
         }

         foreach (string directoryName in Directory.GetDirectories(directory))
         {
            directories.Add(directoryName);
         }
      }

      return files;
   }

   public void OnProjectChange()
   {
      // Read graph files from subfolders
      List<string> fileNames = GetFileList(uScript.Preferences.UserScripts, "*.uscript");

      // Build the flat list of scripts

      if (_listView == null)
      {
         uScriptDebug.Log("The ListView must be initialized before items can be added.", uScriptDebug.Type.Error);
      }

      _listView.Init();

      foreach (string filename in fileNames)
      {
         ScriptData data = new ScriptData();
         _listView.AddItem(filename.Replace(uScript.Preferences.UserScripts + "/", string.Empty), data);
      }

      // Mark the hierarchy dirty so that the hierarchy can be rebuilt and filtering and sorting can be applied
      _listView.RebuildHierarchy();
   }

   private class ScriptData : ListViewItemData
   {
      public string friendlyName = string.Empty;
      public string sceneName = string.Empty;
      public int sourceState = 0;
   }

   private void ScriptFoldoutDraw(ListViewItem item)
   {
      // draw the foldout
   }

   private void ScriptItemDraw(ListViewItem item)
   {
      Debug.Log("DRAWING: \"" + item.path + "\"\n");
   }

   private class CustomContent
   {
      public Texture2D iconScript { get; private set; }

      public Texture2D iconScriptNested { get; private set; }

      public Texture2D iconSourceDebug { get; private set; }

      public Texture2D iconSourceMissing { get; private set; }

      public Texture2D iconSourceRelease { get; private set; }

      public Texture2D iconUnityScene { get; private set; }

      public GUIContent NoScene { get; private set; }

      public GUIContent WrongScene { get; private set; }

      public CustomContent()
      {
         NoScene = new GUIContent("This script is not attached to any scene.  It may be used with Prefabs or as a Nested Script.");

         WrongScene = new GUIContent("This uScript file was previously attached to a different Unity Scene.  "
            + "It may not be compatible with the current Unity Scene, and may not run correctly, if edited while this scene is open.");

         string skinPath = "Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/";

         iconScript = AssetDatabase.LoadAssetAtPath(skinPath + "iconScriptFile01.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         iconScriptNested = AssetDatabase.LoadAssetAtPath(skinPath + "iconScriptFile02.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;

         iconSourceDebug = null;
         iconSourceMissing = null;
         iconSourceRelease = null;

         skinPath += (uScriptGUI.isProSkin ? "DarkSkin" : "LightSkin") + "_";
         iconUnityScene = AssetDatabase.LoadAssetAtPath(skinPath + "UnityScene.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
      }
   }

   private class CustomStyle
   {
      public GUIStyle SceneName { get; private set; }

      public GUIStyle SceneNameError { get; private set; }

      public GUIStyle ScriptName { get; private set; }

      public GUIStyle ScriptMessage { get; private set; }

      public GUIStyle styleButtonGroup { get; private set; }

      public GUIStyle styleScriptListNormal { get; private set; }

      public GUIStyle styleScriptListBold { get; private set; }

      public GUIStyle styleMiniButtonLeft { get; private set; }

      public GUIStyle styleMiniButtonRight { get; private set; }

      public CustomStyle()
      {
         SceneName = new GUIStyle(EditorStyles.label);

         SceneNameError = new GUIStyle(SceneName);
         SceneNameError.normal.textColor = Color.red;

         ScriptName = new GUIStyle(EditorStyles.boldLabel);

         ScriptMessage = new GUIStyle(EditorStyles.miniLabel);
         ScriptMessage.margin.left = 24;
         ScriptMessage.wordWrap = true;

         styleButtonGroup = new GUIStyle();
         styleButtonGroup.margin.top = 2;

         styleScriptListNormal = new GUIStyle(EditorStyles.label);
         styleScriptListNormal.margin = new RectOffset(4, 4, 1, 1);
         styleScriptListNormal.padding = new RectOffset(2, 2, 0, 0);

         styleScriptListBold = new GUIStyle(styleScriptListNormal);
         styleScriptListBold.fontStyle = FontStyle.Bold;

         styleMiniButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft);
         styleMiniButtonLeft.margin = new RectOffset(4, 0, 1, 1);

         styleMiniButtonRight = new GUIStyle(EditorStyles.miniButtonRight);
         styleMiniButtonRight.margin = new RectOffset(0, 4, 1, 1);
      }
   }
}
