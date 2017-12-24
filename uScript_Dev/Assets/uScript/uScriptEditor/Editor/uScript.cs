// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios LLC" file="uScript.cs">
//   Copyright 2010-2015 Detox Studios LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#if !RELEASE
#define UNITY_STORE_PRO
#define DEVELOPMENT_BUILD // Allows us to wrap features in progress. Used along with other BUILD settings.
#endif

//#define CLOSED_BETA
//#define ENABLE_ANALYTICS

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;

using Detox.Data.Tools;
using Detox.Drawing;
using Detox.Editor;
using Detox.Editor.Extensions;
using Detox.Editor.GUI;
using Detox.Editor.GUI.Windows;
using Detox.FlowChart;
using Detox.ScriptEditor;
using Detox.Windows.Forms;

using UnityEditor;

#if !(UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
using UnityEditor.SceneManagement;
#endif

using UnityEngine;

using Control = Detox.Windows.Forms.Control;

[SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1502:ElementMustNotBeOnSingleLine", Justification = "Reviewed. Suppression is OK here.")]
[SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed. Suppression is OK here.")]
public sealed partial class uScript : EditorWindow
{
   public static EditorApplication.CallbackFunction GraphSaved;

   public static int _paletteMode;  // TEMP variable for testing the new property grid methods

   public Rect paletteRect;
   public bool m_SelectAllNodes;

   public bool wasCanvasDragged;

   public string[] m_UndoPatches = new string[0];

   public Vector2 _guiContentScrollPos;

   public Rect _canvasRect;

   private static readonly AppFrameworkData AppData = new AppFrameworkData();
   private static readonly Hashtable NodeParameterFields = new Hashtable();
   private static readonly Hashtable NodeParameterDescFields = new Hashtable();
   private static readonly Hashtable RequiresLink = new Hashtable();

   private static Hashtable m_RawDescription = new Hashtable();

   private static uScript instance;

   private static bool shouldTestCompatibility;

   private static bool shouldPerformUpdateCheck;

   private static int lastMouseX;
   private static int lastMouseY;

   private static int pendingRepaintRequests;
   private static float unityVersion;

   // This allows you to set the ifdef here but use this info in other classes by calling - uScript.IsDevelopmentBuild
#if DEVELOPMENT_BUILD
   private static bool _isDevelopmentBuild = true;
#else
   private static bool _isDevelopmentBuild;
#endif

   private Dictionary<MouseRegion, Rect> mouseRegionRect = new Dictionary<MouseRegion, Rect>();

   private Dictionary<string, bool> _debugScriptCache = new Dictionary<string, bool>();

   private Dictionary<string, bool> _staleScriptCache = new Dictionary<string, bool>();

   private Hashtable m_Types = new Hashtable();

   // So we know if the current script we've cached is dirty or has been saved to a file
   private bool currentScriptDirty;
   private string currentScript;
   private string currentScriptName = string.Empty;
   private string[] patches = new string[0];

   private bool launched;

   // Complex class which Unity will not serialize, so if it goes null I know the app domain has been rebuilt
   private ComplexData complexData;

   private MouseRegion mouseRegion = MouseRegion.Outside;

   private MouseRegion mouseRegionUpdate = MouseRegion.Outside;
   
   private MouseRegion mouseDownRegion = MouseRegion.Outside;

   private bool firstRun = true;

   private ScriptEditorCtrl m_ScriptEditorCtrl;

   private bool mouseDown;
   private bool mouseDownOverCanvas; 

   private bool wantsCopy;
   private bool wantsCut;
   private bool wantsPaste;

   private bool rebuildWhenReady;
   private bool rebuildSilently;

   private float mapScale = 1.0f;
   private Vector2 zoomPoint;

   private string pendingNodeSignature = string.Empty;
   private bool pendingNodeUsesMousePosition;
   private KeyCode pressedKey = KeyCode.None;

   private string fullPath = string.Empty;
   private string currentCanvasPosition = string.Empty;
   private bool forceCodeValidation;

   private Node focusedNode;

   private bool hasFocus;

   private bool hierarchyRefreshCallbackAdded = false;

   private Rect helpButtonRect;
   private Rect fileButtonRect;
   private Rect viewButtonRect;
   private uScript_UndoObject undoObject;

   private Hashtable m_EntityTypeHash;
   private EntityDesc[] m_EntityTypes;
   private string[] m_SzEntityTypes;

   private LogicNode[] m_LogicTypes;
   private string[] m_SzLogicTypes;

   private bool _wasMoving;         // TEMP variable for testing the new property grid methods

   private string m_CurrentBreakpoint = string.Empty;

   private bool m_IsDebuggingValues;

   private GenericMenu _canvasContextMenu;

   private MouseEventArgs m_MouseDownArgs;
   private MouseEventArgs m_MouseUpArgs;
   private MouseEventArgs m_MouseMoveArgs = new MouseEventArgs();

   private bool m_CanvasDragging;

   private bool _isContextMenuOpen;

   private int m_UndoNumber;

   private int m_ContextX;
   private int m_ContextY;
   private ToolStripItem m_CurrentMenu;

   private Rect m_NodeWindowRect;
   private Rect m_NodeToolbarRect;

   private Rect rectContextMenuWindow = new Rect(10, 10, 10, 10);

   private bool shouldCloseEditorWindowOnNextUpdate;

   public enum MouseRegion
   {
      Outside,
      Canvas,
      Palette,
      Properties,
      Reference,
      Scripts,
      HandleCanvas,
      HandlePalette,
      HandleProperties,
      HandleReference
   }

   public static uScript Instance
   {
      get
      {
         if (instance == null)
         {
            Open();
         }

         return instance;
      }
   }

#if !UNITY_3_5
   public static Detox.Editor.GUI.Windows.HotkeyWindow HotkeyWindow { get; set; }
#else
   public static HotkeyWindow HotkeyWindow { get; set; }
#endif

   public static bool IsOpen
   {
      get
      {
         return instance != null;
      }
   }

   public bool HasFocus
   {
      get
      {
         return this.hasFocus && EditorWindow.focusedWindow == this;
      }
   }

   public bool IsLicenseAccepted { get; private set; }

   public float MapScale
   {
      get
      {
         return this.mapScale;
      }

      set
      {
         this.mapScale = value;
      }
   }

   public MouseRegion MouseDownRegion
   {
      get { return this.mouseDownRegion; }
      set { this.mouseDownRegion = value; }
   }

   public Node NodeClicked { get; set; }

   public static bool IsDevelopmentBuild { get { return _isDevelopmentBuild; } }

   public bool GenerateDebugInfo { get { return Preferences.SaveMethod != Preferences.SaveMethodType.Release; } }

   public bool isContextMenuOpen
   {
      get
      {
         return _isContextMenuOpen;
      }

      set
      {
         if (_isContextMenuOpen != value)
         {
            _isContextMenuOpen = value;
            if (value == false)
            {
               m_ContextX = 0;
               m_ContextY = 0;
               m_CurrentMenu = null;
               rectContextMenuWindow = new Rect(m_ContextX, m_ContextY, 10, 10);
               //Event.current.Use();
            }
         }
      }
   }

   public Rect NodeWindowRect { get { return m_NodeWindowRect; } }

   public Rect NodeToolbarRect { get { return m_NodeToolbarRect; } }

   // IMPORTANT - THIS CANNOT BE CACHED
   // BECAUSE WE END UP WITH STALE VERSIONS
   public static GameObject MasterObject
   {
      get
      {
         return uScript_MasterComponent.LatestMaster;
         //return GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
      }
   }

   // IMPORTANT - THIS CANNOT BE CACHED
   // BECAUSE WE END UP WITH STALE VERSIONS
   public static uScript_MasterComponent MasterComponent
   {
      get
      {
         var uScriptMaster = GetMasterGameObject();
         return uScriptMaster.GetComponent<uScript_MasterComponent>();
      }
   }

   public static float UnityVersion
   {
      get
      {
         if (unityVersion < 1)
         {
            var t = Instance.GetType("uScriptUnityVersion");
            if (null != t)
            {
               var v = Activator.CreateInstance(t) as uScriptIUnityVersion;
               if (null != v)
               {
                  unityVersion = v.Version;
               }
            }

            if (unityVersion > 1)
            {
               uScriptDebug.Log("Unity Version: " + unityVersion, uScriptDebug.Type.Debug);
            }
         }

         return unityVersion;
      }
   }

   public static GuiState GuiState { get; private set; }

   /// <summary>
   /// Delegate class used by GuiState for checking whether the GUI should be enabled.
   /// </summary>
   /// <returns>Returns True if it can be enabled, otherwise False.</returns>
   private static bool GuiStateEnableCondition()
   {
      return Instance.IsLicenseAccepted && Instance.isContextMenuOpen == false;
   }

   public Type GetType(string typeName)
   {
      var type = this.m_Types[typeName] as Type ?? uScript.GetAssemblyQualifiedType(typeName);
      return type;
   }

   public void AddType(Type type)
   {
      m_Types[type.ToString()] = type;
   }

   public static string[] UserTypes
   {
      get
      {
         Type t = uScript.Instance.GetType("uScriptUserTypes");
         if (null != t)
         {
            FieldInfo p = t.GetField("Types");
            if (null != p)
            {
               object instance = Activator.CreateInstance(t);

               object v = p.GetValue(instance);
               if (v is string) return ((string)v).Split(',');
            }
         }

         return new string[0];
      }
   }

   private static GameObject CreateMasterGameObject()
   {
      uScriptDebug.Log(
         string.Format("Adding default uScript master GameObject: {0}", uScriptRuntimeConfig.MasterObjectName),
         uScriptDebug.Type.Debug);

      var uScriptMaster = GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
      if (null != uScriptMaster)
      {
         return uScriptMaster;
      }

      uScriptMaster = new GameObject(uScriptRuntimeConfig.MasterObjectName);
      uScriptMaster.transform.position = Vector3.zero;

#if !(UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
      EditorSceneManager.MarkSceneDirty(uScriptMaster.scene);
#elif !(UNITY_3_5 || UNITY_4_6 || UNITY_4_7)
      EditorApplication.MarkSceneDirty();
#endif

      return uScriptMaster;
   }

   private static GameObject GetMasterGameObject()
   {
      var uScriptMaster = MasterObject;
      if (uScriptMaster == null)
      {
         uScriptMaster = CreateMasterGameObject();
      }

      EnsureMasterComponentExists(uScriptMaster);
      return uScriptMaster;
   }

   private static void EnsureMasterComponentExists(GameObject uScriptMaster)
   {
      if (uScriptMaster.GetComponent<uScript_MasterComponent>() == null)
      {
         uScriptDebug.Log(
            string.Format("Master Component added to master GameObject ({0})", uScriptRuntimeConfig.MasterObjectName),
            uScriptDebug.Type.Debug);
         uScriptMaster.AddComponent<uScript_MasterComponent>();
      }

      if (uScriptMaster.GetComponent<uScript_MasterComponent>().undoObjectReference != uScript.Instance.undoObject)
      {
         if (uScriptMaster.GetComponent<uScript_MasterComponent>().undoObjectReference != null)
            ScriptableObject.DestroyImmediate(uScriptMaster.GetComponent<uScript_MasterComponent>().undoObjectReference);
         
         uScriptMaster.GetComponent<uScript_MasterComponent>().undoObjectReference = uScript.Instance.undoObject;
      }
   }

   public static MouseRegion OverMouseRegion
   {
      get
      {
         return Instance.mouseRegion;
      }
   }

   public bool AllowKeyInput()
   {
      return ((UnityVersion <= 3.5f || UnityVersion >= 2017.0f) && "MainView" == GUI.GetNameOfFocusedControl()) || FocusedControl.ID == 0;
   }

   public ScriptEditorCtrl ScriptEditorCtrl
   {
      get { return m_ScriptEditorCtrl; }
   }

   public bool IsAttachedToMaster
   {
      get
      {
         if (MasterObject != null && !String.IsNullOrEmpty(this.fullPath))
         {
            FileInfo fileInfo = new FileInfo(this.fullPath);
            bool isSafe = false;
            string safePath = UnityCSharpGenerator.MakeSyntaxSafe(fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".")), out isSafe);
            return MasterObject.GetComponent(safePath + uScriptConfig.Files.GeneratedComponentExtension) != null;
         }
         return false;
      }
   }

   public bool IsAttached
   {
      get
      {
         if (!String.IsNullOrEmpty(this.fullPath))
         {
            FileInfo fileInfo = new FileInfo(this.fullPath);
            bool isSafe = false;
            string safePath = UnityCSharpGenerator.MakeSyntaxSafe(fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".")), out isSafe);
            string componentPath = safePath + uScriptConfig.Files.GeneratedComponentExtension;

            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
               if (go.GetComponent(componentPath) != null) return true;
            }

            return false;
         }
         return false;
      }
   }

#if (UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
   private static string GetFilePathWithLabel(string label, string fileName)
   {
      var guids = AssetDatabase.FindAssets("l:" + label, null);
      foreach (var guid in guids)
      {
         var path = AssetDatabase.GUIDToAssetPath(guid);
         if (path.Substring(path.LastIndexOf("/") + 1) == fileName) return path;
      }

      return string.Empty;
   }

   private static List<string> GetFilePathsWithLabel(string label)
   {
      List<string> files = new List<string>();
      var guids = AssetDatabase.FindAssets("l:" + label, null);
      foreach (var guid in guids)
      {
         files.Add(AssetDatabase.GUIDToAssetPath(guid));
      }
      return files;
   }
#endif

   public static List<string> GetGraphPaths(string label = "uScriptSource")
   {
#if (UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
      return GetFilePathsWithLabel(label);
#else
      return Directory.GetFiles(Preferences.UserScripts, "*.uscript", SearchOption.AllDirectories).Select(s => s.Replace("\\", "/")).ToList();
#endif
   }

   public static string GetGraphPath(string fileName, string label = "uScriptSource")
   {
#if (UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
      return GetFilePathWithLabel(label, fileName);
#else
      return FindFile(Preferences.UserScripts, string.Format("{0}.uscript", fileName));
#endif
   }

   // this function is expensive - it gets all *.uscript files starting from Assets/ down
   // written specifically for label fixup (i.e. "Fix Missing uScripts" button)
   public static List<string> GetAllUScriptPaths()
   {
      return Directory.GetFiles(Application.dataPath, "*.uscript", SearchOption.AllDirectories).Select(s => s.Replace("\\", "/")).ToList();
   }

   public bool IsStale(string graphName)
   {
      if (_staleScriptCache.ContainsKey(graphName))
      {
         return _staleScriptCache[graphName];
      }

      var path = GetGraphPath(string.Format("{0}.uscript", graphName));
      if (string.Empty != path)
      {
         var s = new ScriptEditor(string.Empty, null, null);
         if (s.Open(path))
         {
            var stale = s.GeneratedCodeIsStale;
            if (stale == false)
            {
               var wrapperPath = this.GetGeneratedScriptPath(path);
               var logicPath = this.GetNestedScriptPath(path);

               if (File.Exists(wrapperPath) == false || File.Exists(logicPath) == false)
               {
                  stale = true;
               }
            }

            this.SetStaleState(graphName, stale);
         }
      }

      //if we failed to find it, mark it as always stale
      if (this._staleScriptCache.ContainsKey(graphName) == false)
      {
         this.SetStaleState(graphName, true);
      }

      return this._staleScriptCache[graphName];
   }

   // The stale script state cache should be updated whenever a script's stale state changes, and when uScript first launches.
   public void SetStaleState(string scriptName, bool isStale)
   {
      _staleScriptCache[scriptName] = isStale;
   }

   public bool HasDebugCode(string graphName)
   {
      if (_debugScriptCache.ContainsKey(graphName))
      {
         return _debugScriptCache[graphName];
      }

      var path = GetGraphPath(string.Format("{0}.uscript", graphName));
      if (path != string.Empty)
      {
         var s = new ScriptEditor(string.Empty, null, null);
         if (s.Open(path))
         {
            var debugCode = s.SavedForDebugging;
            this.SetDebugState(graphName, debugCode);
         }
      }

      // if we failed to find it, mark it as note containing debug info
      if (this._debugScriptCache.ContainsKey(graphName) == false)
      {
         this.SetDebugState(graphName, false);
      }

      return this._debugScriptCache[graphName];
   }

   // The debug script state cache should be updated whenever a script's debug state changes, and when uScript first launches.
   public void SetDebugState(string scriptName, bool hasDebugCode)
   {
      _debugScriptCache[scriptName] = hasDebugCode;
   }

   public static void Open()
   {
      instance = (uScript)EditorWindow.GetWindow(typeof(uScript), false, "uScript");
      instance.Launching();

      GuiState = new GuiState(GuiStateEnableCondition);
   }

   // Call to force release the mouse and stop a drag operation
   public void ForceReleaseMouse()
   {
      this.mouseDown = false;
      this.mouseDownOverCanvas = false;
   }

   private static void RequestVersionCompatiblyTest()
   {
      shouldTestCompatibility = true;
   }

   private static void RequestUpdateCheck()
   {
      shouldPerformUpdateCheck = true;
   }

   private static void VerifyBuildCompatibility()
   {
      if (shouldTestCompatibility == false || UnityVersion > 1)
      {
         return;
      }

      // NOTE: This will never trigger on a DLL build, as the UnityVersion is hard coded in the DLLs.
      // If this functionality is desired, we need to check the user's actual Unity version against
      // some range of valid version numbers (i.e. 3.5.7, 4.6.6, and 5.0+).
      
      shouldTestCompatibility = false;

      var msg =
         string.Format(
            "This uScript build does not support the version of Unity ({0}) you are running, and it may not function as intended.",
            Application.unityVersion);

      uScriptDebug.Log(msg, uScriptDebug.Type.Warning);
      EditorUtility.DisplayDialog("Incompatibility Warning", msg, "Okay");
   }

   private static void PerformUpdateCheck()
   {
      if (shouldPerformUpdateCheck == false)
      {
         return;
      }

      shouldPerformUpdateCheck = false;

      UpdateNotification.StartupCheck();
   }

   private static void PerformPromotionCheck()
   {
#if DETOX_STORE_PLE || UNITY_STORE_PLE || DETOX_STORE_BASIC || UNITY_STORE_BASIC
      PromotionWindow.StartupCheck();
#endif
   }

   private void Launching()
   {
      if (null != this.complexData)
      {
         return;
      }

      if (false == this.launched)
      {
         LaunchingFromUnity();
         this.launched = true;
      }
      else
      {
         RelaunchingFromRebuiltAppDomain();
      }
   }

   private void LaunchingFromUnity()
   {
      uScriptDebug.Log("Launching From Unity", uScriptDebug.Type.Debug);

      LoadSettings();

      this.wantsMouseMove = true;

      Directory.CreateDirectory(uScriptConfig.ConstantPaths.Editor);
      Directory.CreateDirectory(uScriptConfig.ConstantPaths.RuntimeNodes);

      Directory.CreateDirectory(Preferences.ProjectFiles);
      Directory.CreateDirectory(Preferences.UserScripts);
      Directory.CreateDirectory(Preferences.UserNodes);
      Directory.CreateDirectory(Preferences.GeneratedScripts);
      Directory.CreateDirectory(Preferences.NestedScripts);

      undoObject = (uScript_UndoObject) ScriptableObject.CreateInstance("uScript_UndoObject");

      // Move the uScriptUserTypes.cs.template file into the uScriptProjectFiles folder if one doesn't already exist.
      string userTypesFileTemplate = uScriptConfig.ConstantPaths.Templates + "/uScriptUserTypes.cs.template";
      string userTypesFile = Preferences.ProjectFiles + "/uScriptUserTypes.cs";
      if (File.Exists(userTypesFileTemplate) && !File.Exists(userTypesFile))
      {
         File.Copy(userTypesFileTemplate, userTypesFile, false);
         AssetDatabase.Refresh();
      }

      // Create the Gizmos folder if it doesn't already exist in the project.
      string gizmos = UnityEngine.Application.dataPath + "/Gizmos";
      if (!Directory.Exists(gizmos))
      {
         Directory.CreateDirectory(gizmos);
      }

      if (Directory.Exists(uScriptConfig.ConstantPaths.Gizmos))
      {
         //copy gizmos into root
         DirectoryInfo directory = new DirectoryInfo(uScriptConfig.ConstantPaths.Gizmos);

         foreach (FileInfo file in directory.GetFiles())
         {
            if (!file.Name.Contains(".meta"))
            {
               // Remove the leading underscore from the backup file's name.
               string finalName = file.Name.Substring(1);

               if (!File.Exists(gizmos + "/" + finalName))
               {
                  File.Copy(file.FullName, gizmos + "/" + finalName, false);
               }
            }
         }
      }

      //save all the types from unity so we can use them for quick lookup, we can't use Type.GetType because
      //we don't save the fully qualified type name which is required to return types of assemblies not loaded
      List<UnityEngine.Object> allObjects = new List<UnityEngine.Object>(GameObject.FindObjectsOfType(typeof(UnityEngine.Object)));

      foreach (UnityEngine.Object o in allObjects)
      {
         uScript.Instance.AddType(o.GetType());
      }

      foreach (uScriptConfigBlock b in uScriptConfig.Variables)
      {
         uScript.Instance.AddType(b.Type);
      }

      String lastOpened = Preferences.GetString("uScript\\LastOpened", string.Empty);
      //Debug.Log("last = " + lastOpened + ");
      if (!String.IsNullOrEmpty(lastOpened))
      {
         this.fullPath = UnityEngine.Application.dataPath + lastOpened;
         //Debug.Log("fp loaded from settings" );
      }

      //Debug.Log("fp = " + fullPath );

      //clear any old script undo data laying around
      ClearChangeStack();

      if (this.fullPath != string.Empty)
      {
         if (this.OpenGraph(this.fullPath, true) == false)
         {
            this.fullPath = string.Empty;
         }
      }

      if (this.fullPath == string.Empty)
      {
         OpenFromCache();
      }

      this.complexData = new ComplexData();

      Detox.Utility.Status.StatusUpdate += new Detox.Utility.Status.StatusUpdateEventHandler(Status_StatusUpdate);

      // make sure the master game object exists
      GetMasterGameObject();

      uScriptBackgroundProcess.ForceFileRefresh();
   }

   private void RelaunchingFromRebuiltAppDomain()
   {
      uScriptDebug.Log("Relaunching from Rebuilt AppDomain", uScriptDebug.Type.Debug);

      LoadSettings();

      this.complexData = new ComplexData();

      OpenFromCache();

      uScriptBackgroundProcess.ForceFileRefresh();
   }

   private void ClearChangeStack()
   {
      m_UndoNumber = 0;
      this.undoObject.UndoNumber = m_UndoNumber;
      UnityEditor.Undo.ClearUndo(this.undoObject);

      m_UndoPatches = new string[0];
      this.patches = new string[0];
   }

   private void OpenFromCache()
   {
      Profile p = new Profile("OpenFromCache");

      m_ScriptEditorCtrl = null;

#if CLOSED_BETA // See if expiration date and build cap should be used. Not needed for commercial version.
       {
            //if ( Application.unityVersion == RequiredUnityBuild || Application.unityVersion == RequiredUnityBetaBuild || Application.unityVersion == RequiredUnityBetaBuildPrevious )
            if (Application.unityVersion.Contains(LastUnityBuild) || Application.unityVersion.Contains(CurrentUnityBuild))
            {
            }
            else
            {
               uScriptDebug.Log(ProductName + " (" + BuildNumber + ") " + "will not work with Unity version " + Application.unityVersion + ".", uScriptDebug.Type.Error);
               return;
            }
         
            if (DateTime.Now > ExpireDate)
            {
               uScriptDebug.Log(ProductName + " (" + BuildNumber + ") " + "has expired. Please use the free Personal Learning Edition (PLE) to continue to evaluate uScript.\n", uScriptDebug.Type.Error);
               return;
            }
            else
            {
               uScriptDebug.Log(ProductName + " (" + BuildNumber + ") " + "will expire in " + (ExpireDate - DateTime.Now).Days + " days.", uScriptDebug.Type.Message);
            }
       }
#endif

      ScriptEditor scriptEditor = null;

      if (!String.IsNullOrEmpty(this.currentScript))
      {
         //Debug.Log("Opening from valid script");
         scriptEditor = new ScriptEditor(string.Empty, PopulateEntityTypes(null), PopulateLogicTypes());
         scriptEditor.OpenFromBase64(null, this.currentScriptName, this.currentScript);
      }

      if (null == scriptEditor)
      {
         scriptEditor = new ScriptEditor(string.Empty, PopulateEntityTypes(null), PopulateLogicTypes());
         //Debug.Log("no valid script");
      }

      Point loc = Point.Empty;
      if (String.IsNullOrEmpty(this.currentCanvasPosition) == false)
      {
         loc = new Point(Int32.Parse(this.currentCanvasPosition.Substring(0, this.currentCanvasPosition.IndexOf(","))),
                         Int32.Parse(this.currentCanvasPosition.Substring(this.currentCanvasPosition.IndexOf(",") + 1)));
      }

      foreach (string patch in this.patches)
      {
         if (false == String.IsNullOrEmpty(patch))
         {
            ApplyPatch(null, scriptEditor, patch);
         }
      }

      m_ScriptEditorCtrl = new ScriptEditorCtrl(scriptEditor, loc);
      m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);

      m_ScriptEditorCtrl.BuildContextMenu();
      uScriptGUIPanelToolbox.Instance.BuildPaletteMenu();

      m_ScriptEditorCtrl.IsDirty = this.currentScriptDirty || this.patches.Length > 0;

      //clear out all patches and cache new copy of the script
      CacheScript();

      p.End();
   }

   public void ApplyPatch(ScriptEditorCtrl ctrl, ScriptEditor scriptEditor, string patch)
   {
      object data;
      Detox.Data.ObjectSerializer o = new Detox.Data.ObjectSerializer();

      byte[] binary = Convert.FromBase64String(patch);

      MemoryStream stream = new MemoryStream(binary);

      if (true == o.Load(new BinaryReader(stream), out data))
      {
         Detox.Patch.PatchData p = data as Detox.Patch.PatchData;

         //Debug.Log( "Applying Patch: " + p.GetType( ) + ", " + p.Name );
         p.Apply(scriptEditor);

         if (null != ctrl)
         {
            ctrl.PatchDisplay(p);
         }
      }

      stream.Close();
   }

   public void RemovePatch(ScriptEditorCtrl ctrl, ScriptEditor scriptEditor, string patch)
   {
      object data;
      Detox.Data.ObjectSerializer o = new Detox.Data.ObjectSerializer();

      byte[] binary = Convert.FromBase64String(patch);

      MemoryStream stream = new MemoryStream(binary);

      if (true == o.Load(new BinaryReader(stream), out data))
      {
         Detox.Patch.PatchData p = data as Detox.Patch.PatchData;

         //Debug.Log( "Removing Patch: " + p.GetType( ) + ", " + p.Name );
         p.Remove(scriptEditor);

         if (null != ctrl)
         {
            ctrl.UnpatchDisplay(p);
         }
      }

      stream.Close();
   }

   public void CacheScript()
   {
      this.patches = new string[0];
      this.currentScript = m_ScriptEditorCtrl.ScriptEditor.ToBase64(null);
      this.currentScriptDirty = m_ScriptEditorCtrl.IsDirty;
      this.currentScriptName = m_ScriptEditorCtrl.Name;
   }

   public static void SetSetting(string key, object value)
   {
      Preferences.SavePreference(key, value);
   }

   public static void LoadSettings()
   {
      if (File.Exists(uScriptConfig.ConstantPaths.Settings + "/" + uScriptConfig.Files.SettingsFile))
      {
         AppData.Load(uScriptConfig.ConstantPaths.Settings + "/" + uScriptConfig.Files.SettingsFile);

         // user is upgrading from .settings file to EditorPrefs, transfer everything over
         ICollection keys = AppData.GetAllKeys();
         foreach(string key in keys)
         {
            object obj = AppData.Get(key);
            if (key == "Preferences")
            {
               var hashtable = obj as Hashtable ?? new Hashtable();
               foreach (string htKey in hashtable.Keys)
               {
                  object htObj = hashtable[htKey];
                  if (htKey.Contains ("SaveMethod")) 
                  {
                     htObj = ((Preferences.SaveMethodType)htObj).ToString ();
                  }
                  else if (htKey.Contains ("MenuLocation")) 
                  {
                     htObj = ((Preferences.MenuLocationType)htObj).ToString ();
                  }
                  Preferences.SavePreference(htKey, htObj);
               }
            }
            else
            {
               Preferences.SavePreference(key, obj);
            }
         }
   
         // delete settings and meta file
         File.Delete(uScriptConfig.ConstantPaths.Settings + "/" + uScriptConfig.Files.SettingsFile);
         File.Delete(uScriptConfig.ConstantPaths.Settings + "/" + uScriptConfig.Files.SettingsFile + ".meta");
      }
      else
      {
         Preferences.LoadDefaultsIfRequired();
      }
   }

   private static void Status_StatusUpdate(Detox.Utility.StatusUpdateEventArgs e)
   {
      var uScriptType = uScriptDebug.Type.Message;

      if (e.LogType == Detox.Utility.LogType.Error)
      {
         uScriptType = uScriptDebug.Type.Error;
      }

      if (e.LogType == Detox.Utility.LogType.Warning)
      {
         uScriptType = uScriptDebug.Type.Warning;
      }

      uScriptDebug.Log(e.Message, uScriptType);
   }

   public void RegisterUndo(Detox.Patch.PatchData p)
   {
      if (null != this.undoObject)
      {
         string base64 = p.ToBase64();

         this.undoObject.UndoNumber = m_UndoNumber;

         Array.Resize(ref this.patches, this.patches.Length + 1);
         this.patches[this.patches.Length - 1] = base64;

         if (m_UndoPatches.Length <= m_UndoNumber)
         {
            Array.Resize(ref m_UndoPatches, m_UndoNumber + 1);
         }

         m_UndoPatches[m_UndoNumber] = base64;

#if UNITY_3_5
         UnityEditor.Undo.RegisterUndo(this.undoObject, p.Name + " (uScript)");
#else
         UnityEditor.Undo.RecordObject(this.undoObject, p.Name + " (uScript)");
#endif

         //now increment and if the old one is restored
         //the numbers won't match
         ++m_UndoNumber;
         this.undoObject.UndoNumber = m_UndoNumber;
      }
   }

   internal void Awake()
   {
      EditorApplication.playmodeStateChanged = OnPlaymodeStateChanged;
      this.forceCodeValidation = true;
   }

   public static bool IsUnityPro
   {
      // Test for Unity Pro - Unity 3.1 Indie does not support RenderTextures
      get
      {
#if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7)
         return SystemInfo.supportsRenderTextures;
#else
         return Application.HasProLicense();
#endif
      }
   }

   internal void Update()
   {
      if (this.shouldCloseEditorWindowOnNextUpdate)
      {
         this.Close();
         return;
      }

      VerifyBuildCompatibility();

      PerformUpdateCheck();

      PerformPromotionCheck();

      //Debug.Log("Update()\n" + EditorWindow.focusedWindow + " has focus, the mouse is over " + EditorWindow.mouseOverWindow);

      if (null == this.complexData)
      {
         RelaunchingFromRebuiltAppDomain();
         return;
      }

      if (null == m_ScriptEditorCtrl) return;

#if !(UNITY_STORE_PRO || UNITY_STORE_BASIC || UNITY_STORE_PLE)
      // Initialize the LicenseWindow here if needed. Doing it during OnGUI may
      // cause issues, such as null exception errors and reports that OnGUI calls
      // are being made outside of OnGUI.
      //
      if (IsLicenseAccepted == false)
      {
          IsLicenseAccepted = LicenseWindow.HasUserAcceptedLicense();
          if (IsLicenseAccepted == false && LicenseWindow.isOpen == false)
         {
            LicenseWindow.Init();
         }
      }
#else
      // Force the license acceptance
      this.IsLicenseAccepted = true;
#endif

      if (EditorApplication.isPlaying)
      {
         //if the current breakpoint has changed we need to repaint
         //so the node visuals are properly reflected
         if (uScript.MasterComponent.CurrentBreakpoint != m_CurrentBreakpoint)
         {
            m_CurrentBreakpoint = uScript.MasterComponent.CurrentBreakpoint;
            uScript.RequestRepaint();
         }

         m_ScriptEditorCtrl.UpdateRemoteValues();
         m_IsDebuggingValues = true;
      }
      else if (true == m_IsDebuggingValues)
      {
         //no longer playing then reset
         //our script to the previous state
         m_IsDebuggingValues = false;
         OpenFromCache();

         //keep our undo stack at the value it was
         //when they last undid
         this.undoObject.UndoNumber = m_UndoNumber;
      }

      // Update the reference panel with the node palette's hot selection.
      uScriptGUIPanelReference.Instance.HotSelection = uScriptGUIPanelToolbox.Instance.HotSelection;

      // Because Unity has an awesome GUI system, the mouse dragging is detected
      // after EventType.Layout has occurred. If any GUILayout calls are made in
      // a conditional block that references m_CanvasDragging, there may be
      // Exceptions generated in Unity.  The only way to get around that is to
      // have the expression reference a variable that is modified outside of
      // OnGUI(), such as in Update().
      //
      // In general, it is a bad idea to have any conditional expressions exist
      // inside OnGUI that references variables that are set in OnGUI, especially
      // if GUILayout calls are made in the conditional block. They work in most
      // cases, such as the test for GUILayout Button clicks, but strange issues
      // can occur with some combinations of statements, conditional expressions,
      // and user input behaviors.
      //
      wasCanvasDragged = m_CanvasDragging;

      // Initializing the AssetBrowserWindow during OnGUI was causing strange
      // errors, such as null exception errors and reports that OnGUI calls were
      // being made outside of OnGUI, which clearly wasn't the case.
      //
      // Moving the window Init() to Update() avoid these issues.
      //
      if (AssetBrowserWindow.shouldOpen && AssetBrowserWindow.isOpen == false)
      {
         AssetBrowserWindow.Init();
      }

      // Additional variable changes that should occur after OnGUI has completed
      this.mouseRegion = this.mouseRegionUpdate;

      if (CodeValidator.RequireRebuild(this.forceCodeValidation, this.rebuildSilently))
      {
         RebuildAllScripts();
      }

      //rebuild was requested but we have to wait until the editor
      //is done compiling so it properly reflects everything
      if (this.rebuildWhenReady && EditorApplication.isCompiling == false)
      {
         //now build any scripts which are used as nested nodes
         //when these are done we will then build any scripts which references these
         //see the m_DoRebuildScripts below
         AssetDatabase.StartAssetEditing();
         {
            RebuildScripts(Preferences.UserScripts, false);
         }
         AssetDatabase.StopAssetEditing();
         AssetDatabase.Refresh();

         this.rebuildWhenReady = false;
      }

      if (true == m_SelectAllNodes)
      {
         m_ScriptEditorCtrl.SelectAllNodes();
         m_ScriptEditorCtrl.SelectAllLinks();

         m_SelectAllNodes = false;
      }

      if (EditorApplication.playmodeStateChanged == null)
      {
         EditorApplication.playmodeStateChanged = OnPlaymodeStateChanged;
      }

      if (this.undoObject != null )
      {
         if ( this.undoObject.UndoNumber != m_UndoNumber) UndoRedoPerformed();
      }
      else
      {
         this.undoObject = (uScript_UndoObject) ScriptableObject.CreateInstance("uScript_UndoObject");
         this.undoObject.UndoNumber = m_UndoNumber;
      }

      if (this.wantsCopy)
      {
         m_ScriptEditorCtrl.CopyToClipboard(true);
         this.wantsCopy = false;
      }
      if (this.wantsCut)
      {
         m_ScriptEditorCtrl.CopyToClipboard(true);
         m_ScriptEditorCtrl.DeleteSelectedNodes();
         this.wantsCut = false;
      }
      if (this.wantsPaste)
      {
         m_ScriptEditorCtrl.PasteFromClipboard(Point.Empty);
         this.wantsPaste = false;
      }

      // Process any pending node creation request
      if (m_ScriptEditorCtrl != null && !String.IsNullOrEmpty(this.pendingNodeSignature))
      {
         m_ScriptEditorCtrl.DeselectAll();

         Point canvasPosition = (this.pendingNodeUsesMousePosition
            ? Detox.Windows.Forms.Cursor.ScaledPosition
            : new Point((int)(NodeWindowRect.width * 0.5f), (int)(NodeWindowRect.height * 0.5f))); // viewport center

         EntityNode entityNode = uScriptGUIPanelToolbox.Instance.GetToolboxNode(this.pendingNodeSignature);
         if (entityNode == null)
         {
            uScriptDebug.Log("Attempt to create node type failed. Signature not recognized: \"" + this.pendingNodeSignature + "\"", uScriptDebug.Type.Error);
         }
         else
         {
            // Apply an offset appropriate for the node type
            if (entityNode is LocalNode
               || entityNode is ExternalConnection
               || entityNode is OwnerConnection)
            {
               m_ScriptEditorCtrl.ContextCursor = new Point(canvasPosition.X - 28, canvasPosition.Y - 28);
            }
            else if (entityNode is LogicNode
               || entityNode is EntityEvent
               || entityNode is EntityMethod
               || entityNode is EntityProperty)
            {
               m_ScriptEditorCtrl.ContextCursor = new Point(canvasPosition.X - 10, canvasPosition.Y - 10);
            }
            else
            {
               m_ScriptEditorCtrl.ContextCursor = canvasPosition;
            }

            m_ScriptEditorCtrl.AddVariableNode(entityNode);
         }

         this.pendingNodeSignature = string.Empty;
      }

      //we can't ignore if the context menu is up
      //because we need to send the mouse up
      //after it has been activated
      //
      // is this still the case?
      if (false == isContextMenuOpen)
      {
         if (null != m_MouseDownArgs)
         {
            OnMouseDown();
            m_MouseDownArgs = null;
         }
         else if (null != m_MouseUpArgs)
         {
            OnMouseUp();
            m_MouseUpArgs = null;
         }
         else
         {
            OnMouseMove();
         }
      }

      // Repaint if a request was previously made180
      if (pendingRepaintRequests > 0)
      {
         pendingRepaintRequests--;
         this.Repaint();
      }
   }

   private void UndoRedoPerformed()
   {
      //if their number is greater then it was a redo
      //so apply the patch
      
      if (this.undoObject.UndoNumber > m_UndoNumber)
      {
         //for some reason we're going out of range when starting Unity with uScript open
         //so make sure it's clamped here until i figure out the cause
         if (m_UndoPatches.Length <= this.undoObject.UndoNumber - 1)
         {
            this.undoObject.UndoNumber = m_UndoPatches.Length;
         }

         ApplyPatch(m_ScriptEditorCtrl, m_ScriptEditorCtrl.ScriptEditor, m_UndoPatches[this.undoObject.UndoNumber - 1]);
      }
      else
      {
         //if their number was less then it was an undo
         //so remove the previous change

         //for some reason we're going out of range when starting Unity with uScript open
         //so make sure it's clamped here until i figure out the cause
         if (m_UndoPatches.Length <= this.undoObject.UndoNumber)
         {
            this.undoObject.UndoNumber = m_UndoPatches.Length - 1;
         }

         RemovePatch(m_ScriptEditorCtrl, m_ScriptEditorCtrl.ScriptEditor, m_UndoPatches[this.undoObject.UndoNumber]);
      }

      //recache the script since we're out of date with the patches
      CacheScript();

      m_UndoNumber = this.undoObject.UndoNumber;

      //Debug.Log("applied undo " + m_UndoNumber );
   }

   // Canvas Context Menu
   private void BuildCanvasContextMenu(ToolStripItem toolStripItem, string path)
   {
      GUIContent content;

      if (toolStripItem == null || string.IsNullOrEmpty(path))
      {
         // Create a new context menu, destroying the old one
         this._canvasContextMenu = new GenericMenu();

         ContextMenuStrip contextMenu = (Control.ModifierKeys.Pressed & Keys.Shift) != 0 ?
            m_ScriptEditorCtrl.ContextMenuWithReflection :
            m_ScriptEditorCtrl.ContextMenuSansReflection;

         foreach (var item in contextMenu.Items)
         {
            var toolStripMenuItem = item as ToolStripMenuItem;
            if (toolStripMenuItem != null)
            {
               if (toolStripMenuItem.DropDownItems.Count > 0)
               {
                  // This is the parent of a submenu
                  var itemPath = string.Format("{0}/", toolStripMenuItem.Text.Replace("...", string.Empty));

                  foreach (var itemChild in toolStripMenuItem.DropDownItems)
                  {
                     this.BuildCanvasContextMenu(itemChild, itemPath);
                  }
               }
               else if (toolStripMenuItem.Text == "No Debug Info")
               {
                  this._canvasContextMenu.AddDisabledItem(new GUIContent(toolStripMenuItem.Text));
               }
               else
               {
                  // This is a menu item
                  content = new GUIContent(toolStripMenuItem.Text.Replace("&", string.Empty));
                  //content = new GUIContent(
                  //   toolStripMenuItem.Text.Replace("&", string.Empty),
                  //   FindNodeToolTip(ScriptEditor.FindNodeType(toolStripMenuItem.Tag as EntityNode)));

                  this._canvasContextMenu.AddItem(content, false, ContextMenuCallback, toolStripMenuItem);
               }
            }
            else
            {
               if (item.Text == "<hr>")
               {
                  // This is a separator
                  this._canvasContextMenu.AddSeparator(string.Empty);
               }
            }
         }
      }
      else if (!(toolStripItem is ToolStripSeparator))
      {
         var toolStripMenuItem = toolStripItem as ToolStripMenuItem;
         if (toolStripMenuItem != null && toolStripMenuItem.DropDownItems.Count > 0)
         {
            // There are sub items
            var itemPath = path + toolStripMenuItem.Text.Replace("...", string.Empty) + "/";

            foreach (var itemChild in toolStripMenuItem.DropDownItems)
            {
               this.BuildCanvasContextMenu(itemChild, itemPath);
            }
         }
         else
         {
            //content = new GUIContent(
            //   path + toolStripItem.Text.Replace("&", string.Empty),
            //   FindNodeToolTip(ScriptEditor.FindNodeType(toolStripItem.Tag as EntityNode)));
            content = new GUIContent(path + toolStripItem.Text.Replace("&", string.Empty));

            this._canvasContextMenu.AddItem(content, false, ContextMenuCallback, toolStripItem);
         }
      }
      else
      {
         uScriptDebug.Log(string.Format("The toolStripItem ({0}) is a {1} and is unhandled!\n", toolStripItem.Text, toolStripItem.GetType()), uScriptDebug.Type.Warning);
      }
   }

   private static void ContextMenuCallback(object obj)
   {
      var toolStripItem = obj as ToolStripItem;

      if (toolStripItem == null)
      {
         Debug.LogError("The context menu callback received an invalid data\n");
      }
      else
      {
         if (toolStripItem.Click != null)
         {
            toolStripItem.Click(toolStripItem, new EventArgs());
         }
         else
         {
            Debug.Log("Context menu selection had no event handler.\n");
         }
      }
   }

   private void RefreshOnHierarchyChange()
   {
      // Unity calls OnHierarchyChanged all the time while the app is playing.
      // We need to delay those calls so uScript isn't constantly being reopened.
      if (Application.isPlaying)
      {
         EditorApplication.delayCall += this.RefreshOnHierarchyChange;
         this.hierarchyRefreshCallbackAdded = true;
      }
      else
      {
         if (this.hierarchyRefreshCallbackAdded)
         {
            uScriptGUIPanelToolbox.Instance.ClearSearchFilter();

#if !(DETOX_STORE_BASIC || UNITY_STORE_BASIC)
            if (Preferences.AutoUpdateReflection)
            {
               this.UpdateReflectedTypes();
            }
#endif
            this.OpenFromCache();
         }

         this.hierarchyRefreshCallbackAdded = false;
      }
   }

   internal void OnHierarchyChange()
   {
      if (Preferences.RefreshOnHierarchyChange)
      {
         EditorApplication.delayCall += this.RefreshOnHierarchyChange;
         this.hierarchyRefreshCallbackAdded = true;
      }
   }

   internal void OnProjectChange()
   {
      uScriptGUI.GetScenePaths();
      Detox.Editor.GUI.PanelScript.Instance.OnProjectChange();
   }

   internal void OnInspectorUpdate()
   {
      //Debug.Log("OnInspectorUpdate()\n" + EditorWindow.focusedWindow + " has focus, the mouse is over " + EditorWindow.mouseOverWindow);
      //Debug.Log(
      //   "OnInspectorUpdate()\n" + (HasFocus
      //      ? "The uScript EditorWindow HAS focus."
      //      : "The uScript EditorWindow DOES NOT HAVE focus."));
   }

   internal void OnFocus()
   {
      //Debug.Log("OnFocus()\n");
      this.hasFocus = true;
      this.Repaint();
   }

   internal void OnLostFocus()
   {
      //Debug.Log("OnLostFocus()\n");
      this.hasFocus = false;
      this.Repaint();
   }

   internal void OnGUI()
   {
      SendEventToHotkeyWindow();

      uScriptGUI.OverrideTextEditorTabBehavior();

      this.OnGUIFirstRun();

      // Handle GUI.Window support operations early, so that they have priority over later GUI calls
      this.OnGUIHandleWindowOverrides();

      // Store the current event locally since it is reference so frequently
      var e = Event.current;

      if (this.m_ScriptEditorCtrl == null)
      {
         return;
      }

      this.DropKeyboardFocusWhenNewControlClicked();

      // Must be done in OnGUI rather than on demand
      this.m_ScriptEditorCtrl.ParseClipboardData();

      GuiState.Enable();

      // Set the default mouse region
      if (Event.current.type == EventType.Repaint)
      {
         this.mouseRegionUpdate = MouseRegion.Outside;
      }

      // As little logic as possible should be performed here.  It is better
      // to use Update() to perform tasks once per tick.

      var lastMouseDown = this.mouseDown;

      this.isContextMenuOpen = 0 != this.m_ContextX || 0 != this.m_ContextY;
      if (this.isContextMenuOpen)
      {
         this.OnGUIHandleContextMenuInput();
      }
      else
      {
         this.OnGUIHandleCanvasInput();
      }

      // All the GUI drawing code
      this.DrawMainGUI();

      // where is the mouse?
      this.CalculateMouseRegion();

      ExportPNG.ContinueExport();

      if (Event.current.type == EventType.Repaint)
      {
         Property.MonitorGUIControlFocusChanges();
      }

      if (this.mouseDown == false)
      {
         // turn panel rendering back on
         this.m_CanvasDragging = false;
      }

      // The following code must be here, because it needs to happen after we've figured out what region the mouse is in
      //
      // Only look for mouse move events when the mouse is over our window.
      // NOTE: This fixes an exception when trying to close a dirty uScript graph.
      this.wantsMouseMove = this.mouseRegion != MouseRegion.Outside;

      // mark mouse down region for dragging resize handles
      if (lastMouseDown == false && this.mouseDown)
      {
         // mouse was pressed down this event, set the current region
         this.mouseDownRegion = this.mouseRegion;
      }

      // Do this after the event processing has taken place so that we 
      // know we don't have a duplicate mouse up event
      if (this.mouseDown && this.mouseRegion == MouseRegion.Outside && m_MouseUpArgs == null)
      {
         m_MouseUpArgs = new MouseEventArgs();

         int button = 0;

         if (e.button == 0) button = MouseButtons.Left;
         else if (e.button == 1) button = MouseButtons.Right;
         else if (e.button == 2) button = MouseButtons.Middle;

         m_MouseUpArgs.Button = button;
         m_MouseUpArgs.X = (int)(e.mousePosition.x);
         if (!uScriptGUI.PanelsHidden) m_MouseUpArgs.X -= uScriptGUI.PanelLeftWidth;
         m_MouseUpArgs.Y = (int)(e.mousePosition.y - _canvasRect.yMin);

         this.mouseDownRegion = MouseRegion.Outside;
         this.mouseDown = false;
      }

      if (e.type == EventType.DragPerform || e.type == EventType.DragUpdated)
      {
         if (this.mouseRegion == MouseRegion.Canvas)
         {
            CheckDragDropCanvas();
            e.Use();
         }
      }

      // Draw GUI.Windows last, so that they appear on top of all other controls
      this.OnGUIDrawWindows();
   }

   private void OnGUIDrawWindows()
   {
      GuiState.Enable();

      this.BeginWindows();
      {
         if (this.isContextMenuOpen)
         {
            const int PaddingAroundContextMenu = 4;

            // Try to put the window where the user clicked
            this.rectContextMenuWindow.x = this.m_ContextX;
            this.rectContextMenuWindow.y = this.m_ContextY;

            // Update the x, y, width, and height to ensure the context menu appears within the _canvasRect bounds.
            // They should be handled in the xMax, xMin and then yMax and yMin order.
            if (this._canvasRect.xMax - PaddingAroundContextMenu < this.rectContextMenuWindow.xMax)
            {
               this.rectContextMenuWindow.x -= this.rectContextMenuWindow.xMax
                                               - (this._canvasRect.xMax - PaddingAroundContextMenu);
            }

            if (this._canvasRect.xMin + PaddingAroundContextMenu > this.rectContextMenuWindow.xMin)
            {
               this.rectContextMenuWindow.x = this._canvasRect.xMin + PaddingAroundContextMenu;
            }

            if (this.position.height - PaddingAroundContextMenu < this.rectContextMenuWindow.yMax)
            {
               this.rectContextMenuWindow.y -= this.rectContextMenuWindow.yMax
                                               - (this.position.height - PaddingAroundContextMenu);
            }

            if (this._canvasRect.yMin + PaddingAroundContextMenu > this.rectContextMenuWindow.yMin)
            {
               this.rectContextMenuWindow.y = this._canvasRect.yMin + PaddingAroundContextMenu;
            }

            var tmpRect = GUILayout.Window(
               "ContextMenu".GetHashCode(),
               this.rectContextMenuWindow,
               this.DrawContextMenuWindow,
               string.Empty,
               uScriptGUIStyle.MenuContextWindow);
            if (Event.current.type == EventType.Repaint)
            {
               this.rectContextMenuWindow = tmpRect;
            }
         }

         var drawingOffset = uScriptGUIPanelProperty.Instance.ScrollviewRect.Position()
                             - uScriptGUIPanelProperty.Instance.ScrollviewOffset;
         Detox.Editor.GUI.Control.AutoCompletePopup.Draw(drawingOffset);
         //Detox.Editor.GUI.Control.AutoCompletePopup.Draw(Vector2.zero);
      }

      this.EndWindows();

      GuiState.Enable();
   }

   private void OnGUIFirstRun()
   {
      if (this.firstRun == false)
      {
         return;
      }

      this.firstRun = false;

      // Make sure the initial window size it not too small
      var minimum = new Rect(200, 200, 620, 550);
      if (this.position.width < minimum.width || this.position.height < minimum.height)
      {
         this.position = minimum;
      }

      LoadSettings();

      uScriptGUI.PanelPropertiesWidth = (int)(Instance.position.width / 3);
      uScriptGUI.PanelScriptsWidth = (int)(Instance.position.width / 3);

      if (Preferences.ShowAtStartup)
      {
         EditorCommands.OpenWelcomeWindow();
      }

      RequestVersionCompatiblyTest();
      RequestUpdateCheck();
   }

   public static void CloseEditorWindow()
   {
      Instance.shouldCloseEditorWindowOnNextUpdate = true;
   }

   private void OnGUIHandleContextMenuInput()
   {
      Event e = Event.current;

      switch (e.type)
      {
         case EventType.ContextClick:
            isContextMenuOpen = false;
            break;

         case EventType.KeyDown:
         case EventType.KeyUp:
            switch (e.keyCode)
            {
               case KeyCode.Escape:
                  isContextMenuOpen = false;
                  break;
            }
            e.Use();
            break;

         case EventType.MouseDown:
            if (rectContextMenuWindow.Contains(e.mousePosition) == false)
            {
               isContextMenuOpen = false;
            }
            else if (e.button != 0)
            {
               isContextMenuOpen = false;
            }
            break;

         //case EventType.MouseUp:
         //   if (e.button != 0)
         //   {
         //      isContextMenuOpen = false;
         //   }
         //   break;

         case EventType.ScrollWheel:
            if (rectContextMenuWindow.Contains(e.mousePosition) == false)
            {
               e.Use();
            }
            break;

         //// paint/layout events
         //case EventType.Layout:
         //   break;
         //case EventType.Repaint:
         //   break;

         //// ignore these events
         //case EventType.Ignore:
         //case EventType.Used:
         //default:
         //   break;
      }

      if (isContextMenuOpen == false)
      {
         e.Use();
      }
   }

   private void OnGUIHandleCanvasInput()
   {
      Event e = Event.current;

      if (e == null)
      {
         Control.ModifierKeys.Pressed = 0;
         return;
      }

      int modifierKeys = 0;

      if (Event.current.alt) modifierKeys |= Keys.Alt;
      if (Event.current.shift) modifierKeys |= Keys.Shift;
      if (Event.current.control || Event.current.command) modifierKeys |= Keys.Control;

      Control.ModifierKeys.Pressed = modifierKeys;

      var allowKeyInput = this.AllowKeyInput();

      // handle normal canvas controls
      switch (e.type)
      {
         case EventType.ContextClick:
            // Display the canvas context menu only when the
            // mouse is over the canvas when the event occurs
            if (this._canvasRect.Contains(e.mousePosition))
            {
               this.ShowCanvasContextMenu();
               e.Use();
            }

            break;

         case EventType.ValidateCommand:
            if (allowKeyInput)
            {
               if (e.commandName == "Copy" && this.m_ScriptEditorCtrl.CanCopy)
               {
                  e.Use();
               }
               else if (e.commandName == "Cut" && this.m_ScriptEditorCtrl.CanCopy)
               {
                  e.Use();
               }
               else if (e.commandName == "Paste" && this.m_ScriptEditorCtrl.CanPaste)
               {
                  e.Use();
               }
               else if (e.commandName == "SelectAll")
               {
                  e.Use();
               }
            }

            break;

         case EventType.ExecuteCommand:
            if (allowKeyInput)
            {
               if (e.commandName == "Copy")
               {
                  this.wantsCopy = true;
               }
               else if (e.commandName == "Cut")
               {
                  this.wantsCut = true;
               }
               else if (e.commandName == "Paste")
               {
                  this.wantsPaste = true;
               }
               else if (e.commandName == "SelectAll")
               {
                  this.m_SelectAllNodes = true;
               }
            }

            break;

         // drag events
         case EventType.DragExited:
            break;

         case EventType.DragPerform:
         case EventType.DragUpdated:
            // update mouse position
            m_MouseMoveArgs.Button = Control.MouseButtons.Buttons;
            m_MouseMoveArgs.X = (int)e.mousePosition.x;
            m_MouseMoveArgs.Y = (int)e.mousePosition.y;
            break;

         // key events
         case EventType.KeyDown:
            if (e.keyCode != KeyCode.None)
            {
               this.pressedKey = e.keyCode;
            }

            if (allowKeyInput)
            {
               // If the shortcut is valid, consume the event to avoid the "invalid key" beep on Mac.
               if (CanvasCommands.Contains(modifierKeys, e.keyCode, MouseButtons.Any))
               {
                  e.Use();
               }
            }
            break;

         case EventType.KeyUp:
            if (allowKeyInput)
            {
               // Invoke the command assigned to the user input
               CanvasCommands.Invoke(modifierKeys, e.keyCode);
            }

            this.pressedKey = KeyCode.None;

            // Keep key events from going to the rest of Unity
            e.Use();
            break;

         // mouse events
         case EventType.MouseDown:
            // Ignore Right-clicks
            if (e.button != 1)
            {
               if (this.mouseDown == false)
               {
                  if (_canvasRect.Contains(e.mousePosition))
                  {
                     GUI.FocusControl("MainView");

                     int button = 0;

                     if (e.button == 0) button = MouseButtons.Left;
                     else if (e.button == 1) button = MouseButtons.Right;
                     else if (e.button == 2) button = MouseButtons.Middle;

                     m_MouseDownArgs = new Detox.Windows.Forms.MouseEventArgs();

                     m_MouseDownArgs.Button = button;
                     m_MouseDownArgs.X = (int)(e.mousePosition.x);
                     if (!uScriptGUI.PanelsHidden) m_MouseDownArgs.X -= uScriptGUI.PanelLeftWidth;
                     m_MouseDownArgs.Y = (int)(e.mousePosition.y - _canvasRect.yMin);

                     this.mouseDownOverCanvas = true;
                  }

                  // Handle Double-Clicks
                  //
                  // NodeClicked is set in FlowChartCtrl_NodeMouseDown(), which executes
                  // after this method completes. When we check NodeClicked, we're getting
                  // the value from the previous click.
                  //
                  // Does this work on all platforms?  Wasn't e.clickCount unstable on one platform?
                  // - It appears to work fine on OS X.
                  //
                  if (e.clickCount == 2 && this.NodeClicked != null)
                  {
                     this.NodeDoubleClicked(this.NodeClicked);
                  }
                  else
                  {
                     // Clear the clicked node in all other cases
                     this.NodeClicked = null;
                  }

                  this.mouseDown = true;

                  // reset drag variables
                  lastMouseX = (int)e.mousePosition.x;
                  lastMouseY = (int)e.mousePosition.y;
               }

               // update the mouse move position whenever there's a click in case we were previously outside the window
               m_MouseMoveArgs.X = (int)e.mousePosition.x;
               m_MouseMoveArgs.Y = (int)e.mousePosition.y;
            }
            break;
         case EventType.MouseDrag:
         case EventType.MouseMove:
            // update mouse position
            m_MouseMoveArgs.Button = Control.MouseButtons.Buttons;
            m_MouseMoveArgs.X = (int)e.mousePosition.x;
            m_MouseMoveArgs.Y = (int)e.mousePosition.y;

            if (m_MouseMoveArgs.Button == MouseButtons.Right)
            {
               // ignore the right-click here, otherwise it thinks its dragging after closing the context menu
            }
            else if (this.mouseDownRegion == MouseRegion.Canvas && _canvasRect.Contains(e.mousePosition))
            {
               // this is the switch to use to turn off panel rendering while panning/marquee selecting
               m_CanvasDragging = true;
            }

            break;
         case EventType.MouseUp:
            if (this.mouseDown && this.mouseDownOverCanvas)
            {
               var button = (e.button == 0) ? MouseButtons.Left
                          : (e.button == 1) ? MouseButtons.Right
                          : (e.button == 2) ? MouseButtons.Middle
                          : MouseButtons.None;

               this.m_MouseUpArgs = new MouseEventArgs
               {
                  Button = button,
                  X = (int)e.mousePosition.x,
                  Y = (int)(e.mousePosition.y - this._canvasRect.yMin)
               };

               if (!uScriptGUI.PanelsHidden)
               {
                  this.m_MouseUpArgs.X -= uScriptGUI.PanelLeftWidth;
               }

               // Invoke the command assigned to the user input
               CanvasCommands.Invoke(modifierKeys, this.pressedKey, button);
            }

            this.mouseDownRegion = MouseRegion.Outside;
            this.mouseDownOverCanvas = false;
            this.mouseDown = false;
            break;

         case EventType.ScrollWheel:
            if (_canvasRect.Contains(e.mousePosition))
            {
               const float Divisor = 300 / 9f;

               this.zoomPoint = new Vector2(
                  Detox.Windows.Forms.Cursor.AbsolutePosition.X,
                  Detox.Windows.Forms.Cursor.AbsolutePosition.Y);

               float newScale = Mathf.Clamp(this.mapScale - Mathf.Clamp(e.delta.y / Divisor, -1, 1), 0.1f, 1.0f);

               this.mapScale = newScale;
            }
            break;
      }
   }

   public void ShowCanvasContextMenu()
   {
      {
         var buildInternalContextMenu = new Profile("BuildInternalContextMenu");

         this.m_ScriptEditorCtrl.BuildContextMenu();

         buildInternalContextMenu.End();
      }

      // We can't rely on the cached context menu, because the breakpoints
      // might have changed and the context menu must update accordingly.
      //
      // We might need to only rebuild the parts of it which changed as we
      // do with m_ScriptEditorCtrl.BuildContextMenu().

      //if (this._canvasContextMenu == null)
      {
         var buildCanvasContextMenu = new Profile("BuildCanvasContextMenu");

         // cache the context menu...
         this.BuildCanvasContextMenu(null, null);

         buildCanvasContextMenu.End();
      }

      // Ensure the cursor context is within the bounds of the visible canvas
      this.m_ScriptEditorCtrl.ContextCursor = this.ClampContextCursor();

      {
         var showAsContext = new Profile("ShowAsContext");

         this._canvasContextMenu.ShowAsContext();

         showAsContext.End();
      }

      //// Stupid hack to prevent the "canvasDragging" behavior
      //if (mouseDown)
      //{
      //   this.mouseDownRegion = MouseRegion.Reference;
      //   mouseDown = false;
      //}
   }

   private Point ClampContextCursor()
   {
      const int Padding = 20;
      var canvasPosition = Event.current.mousePosition;

      // Account for the canvas offset due to the toolbox and toolbar
      canvasPosition.x -= this._canvasRect.x;
      canvasPosition.y -= this._canvasRect.y;

      // Clamp the position to the canvas viewport bounds with right and bottom padding
      canvasPosition.x = Mathf.Clamp(canvasPosition.x, 0, this._canvasRect.width - Padding);
      canvasPosition.y = Mathf.Clamp(canvasPosition.y, 0, this._canvasRect.height - Padding);

      return canvasPosition.ToPoint();
   }

   /// <summary>
   /// GUI.Windows needs special handling, which should be processed at the top of the EditorWindow.OnGUI() method.
   /// </summary>
   private void OnGUIHandleWindowOverrides()
   {
      Detox.Editor.GUI.Control.AutoCompletePopup.InterceptMouseInput();

      // When a Window is open, the non-Window GUI must be disabled except while repainting.
      if (Detox.Editor.GUI.Control.AutoCompletePopup.IsVisible && Event.current.type != EventType.Repaint)
      {
         // Disable the entire GUI until the window is drawn
         GuiState.Disable();
      }

      // CursorRects associated with GUI.Windows must be applied before the rest of the GUI is processed.
      Detox.Editor.GUI.Control.AutoCompletePopup.AddCursorRect();
   }

   private static void SendEventToHotkeyWindow()
   {
#if !UNITY_3_5
      var e = Event.current;

      if (HotkeyWindow != null)
      {
         switch (e.type)
         {
            case EventType.KeyDown:
            case EventType.KeyUp:
            case EventType.MouseDown:
            case EventType.MouseUp:
            case EventType.MouseDrag:
            case EventType.ScrollWheel:
               // Forcing the mousePosition to appear over the toolbar of the target windows
               // to prevent mouse clicks and drags from affecting the window. Y should be
               // somewhere in the range of 22 and 40, probably.
               var modifiedEvent = e;
               modifiedEvent.mousePosition = new Vector2(0, 30);
               HotkeyWindow.SendEvent(modifiedEvent);
               break;
         }
      }
#endif
   }

   private void DropKeyboardFocusWhenNewControlClicked()
   {
      if (this.hasFocus == false)
      {
         return;
      }

      if (GUIUtility.hotControl != 0 && GUIUtility.hotControl != FocusedControl.ID)
      {
         FocusedControl.Clear();
      }
   }

   /// <summary>Notifies uScript that a node should be created and placed the node on canvas.</summary>
   /// <param name='nodeSignature'>The unique node signature as generated by uScript.GetNodeSignature().</param>
   /// <param name='useMousePosition'>When True, the mouse position will be used as the node's initial canvas location.</param>
   public void PlaceNodeOnCanvas(string nodeSignature, bool useMousePosition)
   {
      this.pendingNodeSignature = nodeSignature;
      this.pendingNodeUsesMousePosition = useMousePosition;
   }

   private void OnPlaymodeStateChanged()
   {
      //if we're not debugging values then we're just starting into playing in the editor
      //and warn them, otherwise we've already warned them so don't pop up a warning again
      if (false == m_IsDebuggingValues)
      {
         if (EditorApplication.isPlayingOrWillChangePlaymode && m_ScriptEditorCtrl != null && true == m_ScriptEditorCtrl.IsDirty)
         {
            EditorUtility.DisplayDialog("uScript Not Saved!", "uScript has detected that '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' has been changed, but not saved! You will not see any changes until you save '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' in the uScript Editor.", "OK");
         }
         else if (EditorApplication.isPlayingOrWillChangePlaymode && m_ScriptEditorCtrl != null && true == m_ScriptEditorCtrl.CodeIsStale)
         {
            EditorUtility.DisplayDialog("uScript Not Saved!", "uScript has detected that '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' was quick saved but the code has not been generated! You will not see any changes until you save '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' in the uScript Editor.", "OK");
         }
      }
   }

   internal void OnDestroy()
   {
      //MasterComponent.undoObjectReference = null;
      //ScriptableObject.DestroyImmediate(undoObject);
      //undoObject = null;

      this.WasCurrentGraphSaved(false);

      if (m_ScriptEditorCtrl != null)
      {
         m_ScriptEditorCtrl.ScriptModified -= new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);
         m_ScriptEditorCtrl = null;
      }

      Detox.Utility.Status.StatusUpdate -= new Detox.Utility.Status.StatusUpdateEventHandler(Status_StatusUpdate);

      //trapperm: do not clear change stack because this is called on minimize/maximize
      //and we want to keep the undo stack
      //ClearChangeStack();

      this.currentScriptDirty = false;
      this.currentScript = null;
      this.currentScriptName = null;
      this.complexData = null;
   }

   public void NodeDoubleClicked(Node node)
   {
      var displayNode = node as DisplayNode;
      if (displayNode == null)
      {
         return;
      }

      var entityNode = displayNode.EntityNode;
      switch (Preferences.DoubleClickBehavior)
      {
         case Preferences.DoubleClickBehaviorType.PingSource:
            this.PingSource(entityNode);
            break;

         case Preferences.DoubleClickBehaviorType.OpenSource:
            this.OpenSource(entityNode);
            break;

         case Preferences.DoubleClickBehaviorType.LoadGraphPingSource:
            this.LoadGraphPingSource(entityNode);
            break;

         case Preferences.DoubleClickBehaviorType.LoadGraphOpenSource:
            this.LoadGraphOpenSource(entityNode);
            break;
      }
   }

   private void PingSource(EntityNode entityNode)
   {
      var nodeType = ScriptEditor.FindNodeType(entityNode);
      var relativePath = GetRelativePathToNodeSource(nodeType);
      uScriptGUI.PingObject(relativePath, typeof(TextAsset));
   }

   private void OpenSource(EntityNode entityNode)
   {
      var nodeType = ScriptEditor.FindNodeType(entityNode);
      var relativePath = GetRelativePathToNodeSource(nodeType);
      var assetInstanceID = GetAssetInstanceID(relativePath, typeof(TextAsset));
      AssetDatabase.OpenAsset(assetInstanceID);
   }

   private void LoadGraphPingSource(EntityNode entityNode)
   {
      var nodeType = ScriptEditor.FindNodeType(entityNode);
      var graphPath = GetGraphPath(string.Format("{0}.uscript", nodeType));
      if (graphPath == string.Empty)
      {
         this.PingSource(entityNode);
      }
      else
      {
         this.OpenGraph(graphPath, false);
      }
   }

   private void LoadGraphOpenSource(EntityNode entityNode)
   {
      var nodeType = ScriptEditor.FindNodeType(entityNode);
      var graphPath = GetGraphPath(string.Format("{0}.uscript", nodeType));
      if (graphPath == string.Empty)
      {
         this.OpenSource(entityNode);
      }
      else
      {
         this.OpenGraph(graphPath, false);
      }
   }

   private void DrawMainGUI()
   {
      uScriptGUI.InitPanels();

      // Notify the user when the editor is in play mode, since any changes
      // made to the uScript will be lost when exiting the mode.
      if (Application.isPlaying)
      {
         this.ShowNotification(uScriptGUIContent.messagePlaying);
      }
      else if (EditorApplication.isCompiling)
      {
         PanelScript.Instance.SaveState();
         this.ShowNotification(uScriptGUIContent.messageCompiling);
      }
      else
      {
         this.RemoveNotification();
      }

      // Draw the various GUI panels
      this.DrawGUITopAreas();
      if (!uScriptGUI.PanelsHidden)
      {
         this.DrawGUIHorizontalDivider();

         this.SetMouseRegion(MouseRegion.HandleCanvas); //, 1, -3, -1, 6 );

         this.DrawGUIBottomAreas();
      }

      StatusBar.Draw();

      // TODO: This bool flag could be removed if the GUI is repainted after the canvas stops panning
      if (this._wasMoving)
      {
         this._wasMoving = false;
         RequestRepaint();
      }
   }

   private void DrawGUITopAreas()
   {
      EditorGUILayout.BeginHorizontal();
      {
         if (!uScriptGUI.PanelsHidden)
         {
            // If the palette contents have been updated, update the linear palette control list
            //    Any foldout has been toggled
            //    The master expand/collapse foldout has been toggled
            //    The search filter text field has changed
            //
            // UpdateGUIPalette()
            //    Create a linear list of controls that can be iterated over using a single FOR loop.
            //    The array element should contain information about the button
            //       Text
            //       Click
            //       Indent
            //       Node
            //       Description
            //       Foldout or button
            //       Foldout state
            //       Tooltip
            //
            // DrawGUIPalette()
            //    Iterate through the linear list using a single FOR loop
            //    Draw the button labels during repaint to prevent the appearance of the horizontal scrollbar
            //    Update the help text to display the button text in the refernce panel (non-truncated labels)
            //
            DrawGUIPalette();

            DrawGUIVerticalDivider();

            SetMouseRegion(MouseRegion.HandlePalette);//, -3, 1, 6, -4 );
         }

         DrawGUIContent();
      }
      EditorGUILayout.EndHorizontal();
   }

   private void DrawGUIBottomAreas()
   {
      Rect rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(uScriptGUI.PanelPropertiesHeight));
      if (rect.height != 0.0f && rect.height != (float)uScriptGUI.PanelPropertiesHeight)
      {
         // if we didn't get the height we requested, we must have hit a limit, stop dragging and reset the height
         uScriptGUI.PanelPropertiesHeight = (int)rect.height;
         this.mouseDownRegion = MouseRegion.Canvas;
         ForceReleaseMouse();
      }
      {
         uScriptGUIPanelProperty.Instance.Draw();

         DrawGUIVerticalDivider();
         SetMouseRegion(MouseRegion.HandleProperties);//, -3, 3, 6, -3 );

         uScriptGUIPanelReference.Instance.Draw();

         DrawGUIVerticalDivider();
         SetMouseRegion(MouseRegion.HandleReference);//, -3, 3, 6, -3 );

         //         uScriptGUIPanelScript.Instance.Draw();
         Detox.Editor.GUI.PanelScript.Instance.Draw();
      }
      EditorGUILayout.EndHorizontal();
   }

   private void DrawGUIHorizontalDivider()
   {
      GUILayout.Box(string.Empty, uScriptGUIStyle.HorizontalDivider, GUILayout.Height(uScriptGUI.PanelDividerThickness), GUILayout.ExpandWidth(true));
   }

   private void DrawGUIVerticalDivider()
   {
      GUILayout.Box(string.Empty, uScriptGUIStyle.VerticalDivider, GUILayout.Width(uScriptGUI.PanelDividerThickness), GUILayout.ExpandHeight(true));
   }

   private void DrawGUIPalette()
   {
      if (_paletteMode == 0)
      {
         uScriptGUIPanelToolbox.Instance.Draw();
      }
      else
      {
         uScriptGUIPanelContent.Instance.Draw();
      }

      this.SetMouseRegion(MouseRegion.Palette); //, 1, 1, -4, -4 );
   }

   public void SetMouseRegion(MouseRegion region)
   {
      if (Event.current.type == EventType.Repaint)
      {
         this.mouseRegionRect[region] = GUILayoutUtility.GetLastRect();
      }

      if (isContextMenuOpen)
      {
         return;
      }

      if (this.mouseRegionRect.ContainsKey(region))
      {
         if (GuiState.Enabled)
         {
            switch (region)
            {
               case MouseRegion.HandleCanvas:
                  EditorGUIUtility.AddCursorRect(this.mouseRegionRect[region], MouseCursor.ResizeVertical);
                  break;
               case MouseRegion.HandlePalette:
               case MouseRegion.HandleProperties:
               case MouseRegion.HandleReference:
                  EditorGUIUtility.AddCursorRect(this.mouseRegionRect[region], MouseCursor.ResizeHorizontal);
                  break;
            }
         }
      }
   }

   private static bool IsHiddenRegion(MouseRegion region)
   {
      return uScriptGUI.PanelsHidden && (region != MouseRegion.Canvas && region != MouseRegion.Outside);
   }

   private void CalculateMouseRegion()
   {
      foreach (var kvp in this.mouseRegionRect)
      {
         if (kvp.Value.Contains(Event.current.mousePosition) && IsHiddenRegion(kvp.Key) == false)
         {
            this.mouseRegionUpdate = kvp.Key;
            //EditorGUIUtility.DrawColorSwatch(kvp.Value, UnityEngine.Color.cyan);
            break;
         }
      }
   }

   public void RefreshAssetDatabase(bool quick, bool debug)
   {
      const string Label = "Saved:\t";
      var indent = GUIStyle.none.GetTabIndent(string.Format("uScript: {0}", Label));

      var fileName = Path.GetFileNameWithoutExtension(this.fullPath);
      var relativePath = Preferences.GeneratedScripts.RelativeAssetPath();

      var logicPath = string.Format("{0}/{1}{2}.cs", relativePath, fileName, uScriptConfig.Files.GeneratedCodeExtension);
      var wrapperPath = string.Format("{0}/{1}{2}.cs", relativePath, fileName, uScriptConfig.Files.GeneratedComponentExtension);

      AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

      if (quick)
      {
         uScriptDebug.Log(
            string.Format(
               "{0}{1}\n{2}... [Quick Save]\n\n{3}\n- {4}",
               Label,
               fileName.Bold(),
               indent,
               "Graph:".Bold(),
               this.fullPath.RelativeAssetPath()));
      }
      else
      {
         uScriptDebug.Log(
            string.Format(
               "{0}{1}\n{2}... and generated source files based on the graph.{3}\n\n{4}\n- {5}\n\n{6}\n- {7}\n- {8}",
               Label,
               fileName.Bold(),
               indent,
               debug ? " [Debug Save]" : string.Empty,
               "Graph:".Bold(),
               this.fullPath.RelativeAssetPath(),
               "Generated source files:".Bold(),
               logicPath,
               wrapperPath));

         SetLabelsOnFile(logicPath, new string[] { "uScript", "uScriptCode" });
         SetLabelsOnFile(wrapperPath, new string[] { "uScript", "uScriptCode" });
      }

      SetLabelsOnFile(this.fullPath, new string[] { "uScript", "uScriptSource" });
   }

   private void DrawMenuItemShortcut(string shortcut)
   {
      if (string.IsNullOrEmpty(shortcut))
      {
         return;
      }

      string modifier = (Application.platform == RuntimePlatform.WindowsEditor ? "Alt+" : uScriptGUI.KeyOption);

      Rect r = GUILayoutUtility.GetLastRect();
      Vector2 v = uScriptGUIStyle.MenuDropDownButtonShortcut.CalcSize(new GUIContent(modifier + "W"));

      // place the string at the left inside edge of the previous rect
      r = new Rect(r.x + r.width - v.x - 8, r.y + ((int)(r.height - v.y) / 2), v.x, v.y);

      GUI.Label(r, shortcut, uScriptGUIStyle.MenuDropDownButtonShortcut);
   }

   private static void CommandHelpMenuAbout()
   {
      EditorCommands.OpenAboutWindow();
   }

#if DETOX_STORE_PLE || UNITY_STORE_PLE
   private static void CommandHelpMenuBuyBasic()
   {
      UnityEditorInternal.AssetStore.Open("content/31443");
   }

   private static void CommandHelpMenuBuyPro()
   {
      UnityEditorInternal.AssetStore.Open("content/1808");
   }
#elif DETOX_STORE_BASIC || UNITY_STORE_BASIC
   private static void CommandHelpMenuUpgrade()
   {
      //Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/content/1808");
      UnityEditorInternal.AssetStore.Open("content/1808");
   }
#endif

   private static void CommandHelpMenuWelcome()
   {
      EditorCommands.OpenWelcomeWindow();
   }

   private static void CommandHelpMenuDocs()
   {
      Help.BrowseURL("http://docs.uscript.net/");
   }

   private static void CommandHelpMenuForum()
   {
      Help.BrowseURL("http://uscript.net/forum/");
   }

   private static void CommandHelpMenuShortcuts()
   {
      ReferenceWindow.Init();
   }

   private static void CommandHelpMenuUpdates()
   {
      UpdateNotification.ManualCheck();
   }

   public void CommandCanvasShowPanels()
   {
      // Toggle panel visibility
      //
      //    The BackQuote key doesn't work well on the German keyboard,
      //    so support Backslash as well.

      uScriptGUI.PanelsHidden = !uScriptGUI.PanelsHidden;

      // FIXME: When toggled while the mouse is down, the canvas often shifts around.
      if (uScriptGUI.PanelsHidden)
      {
         // m_ScriptEditorCtrl.FlowChart.Location.X += (int)_canvasRect.x;
         m_ScriptEditorCtrl.FlowChart.Location = new Point(m_ScriptEditorCtrl.FlowChart.Location.X + uScriptGUI.PanelLeftWidth + uScriptGUI.PanelDividerThickness, m_ScriptEditorCtrl.FlowChart.Location.Y);
         m_ScriptEditorCtrl.RebuildScript(null, false);
      }
      else
      {
         // m_ScriptEditorCtrl.FlowChart.Location.X -= (int)_canvasRect.x;
         m_ScriptEditorCtrl.FlowChart.Location = new Point(m_ScriptEditorCtrl.FlowChart.Location.X - uScriptGUI.PanelLeftWidth + uScriptGUI.PanelDividerThickness, m_ScriptEditorCtrl.FlowChart.Location.Y);
         m_ScriptEditorCtrl.RebuildScript(null, false);
      }

      RequestRepaint(2);
   }

   public static void CommandViewMenuGrid()
   {
      Preferences.ShowGrid = !Preferences.ShowGrid;
   }

   public static void CommandViewMenuSnap()
   {
      Preferences.GridSnap = !Preferences.GridSnap;
   }

   public void CommandCanvasZoomIn()
   {
      this.mapScale = Mathf.Min(this.mapScale + 0.09f, 1.0f);
      this.zoomPoint = new Vector2(this._canvasRect.width * 0.5f, this._canvasRect.height * 0.5f);
   }

   public void CommandCanvasZoomOut()
   {
      this.mapScale = Mathf.Max(this.mapScale - 0.09f, 0.1f);
      this.zoomPoint = new Vector2(this._canvasRect.width * 0.5f, this._canvasRect.height * 0.5f);
   }

   public static void CommandCanvasLocateOrigin()
   {
      var script = Instance;
      if (script.m_ScriptEditorCtrl != null)
      {
         script.m_ScriptEditorCtrl.RebuildScript(null, true);
      }
   }

   public void CommandCanvasLocatePreviousEvent()
   {
      this.focusedNode = m_ScriptEditorCtrl.GetPrevNode(this.focusedNode, typeof(EntityEventDisplayNode));
      if (this.focusedNode != null)
      {
         m_ScriptEditorCtrl.CenterOnNode(this.focusedNode);
      }
   }

   public void CommandCanvasLocateNextEvent()
   {
      this.focusedNode = m_ScriptEditorCtrl.GetNextNode(this.focusedNode, typeof(EntityEventDisplayNode));
      if (this.focusedNode != null)
      {
         m_ScriptEditorCtrl.CenterOnNode(this.focusedNode);
      }
   }

   public void CommandCanvasZoomReset()
   {
      this.mapScale = 1.0f;
   }

   public static void FileMenuItem_New()
   {
      var script = Instance;
      if (script.WasCurrentGraphSaved(true))
      {
         script.CreateNewGraph();
      }
   }

   public static void FileMenuItem_Open()
   {
      var path = EditorUtility.OpenFilePanel("Open uScript", Preferences.UserScripts, "uscript");
      if (path.Length > 0)
      {
         Instance.OpenGraph(path, false);
      }
   }

   private static bool SaveDenied()
   {
      if (EditorApplication.isPlayingOrWillChangePlaymode)
      {
         EditorUtility.DisplayDialog("Unable to save", "The Unity Editor is in play mode, and the uScript graph cannot be saved at this time.", "Okay");
         return true;
      }

      return false;
   }

   public bool RequestSave(bool quick, bool debug, bool rename)
   {
      if (SaveDenied())
      {
         return false;
      }

      var saved = false;

      AssetDatabase.StartAssetEditing();
      saved = this.SaveGraph(rename, !quick, debug);
      AssetDatabase.StopAssetEditing();

      if (saved)
      {
         this.RefreshAssetDatabase(quick, debug);
      }

      return saved;
   }

   public static void FileMenuItem_Save()
   {
      Instance.RequestSave(
         Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
         Preferences.SaveMethod == Preferences.SaveMethodType.Debug,
         false);
   }

   public static void FileMenuItem_SaveAs()
   {
      Instance.RequestSave(
         Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
         Preferences.SaveMethod == Preferences.SaveMethodType.Debug,
         true);
   }

   public static void FileMenuItem_QuickSave()
   {
      Instance.RequestSave(true, false, false);
   }

   public static void FileMenuItem_DebugSave()
   {
      Instance.RequestSave(false, true, false);
   }

   public static void FileMenuItem_ReleaseSave()
   {
      Instance.RequestSave(false, false, false);
   }

   public static void FileMenuItem_ExportPNG()
   {
      ExportPNG.BeginExport();
   }

   public static void FileMenuItem_FindMissingGraphs()
   {
      PanelScript.Instance.FindMissingGraphs();
   }

   void FileMenuItem_UpgradeDeprecatedNodes()
   {
      int count = 0;
      int skipped = 0;

      foreach (Node node in m_ScriptEditorCtrl.FlowChart.Nodes)
      {
         DisplayNode dn = node as DisplayNode;
         if (dn != null)
         {
            if (IsNodeTypeDeprecated(dn.EntityNode) == false && m_ScriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(dn.EntityNode))
            {
               if (true == m_ScriptEditorCtrl.ScriptEditor.CanUpgradeNode(dn.EntityNode))
               {
                  System.EventHandler Click = new System.EventHandler(m_ScriptEditorCtrl.m_MenuUpgradeNode_Click);
                  if (Click != null)
                  {
                     count++;
                     // clear all selected nodes first
                     m_ScriptEditorCtrl.DeselectAll();
                     // toggle the clicked node
                     m_ScriptEditorCtrl.ToggleNode(dn.Guid);
                     Click(this, new EventArgs());
                  }
               }
               else
               {
                  skipped++;
               }
            }
         }
      }

      string result = "Upgraded " + count.ToString() + " deprecated nodes.";

      if (skipped > 0)
      {
         result += (skipped == 1 ? "  1 node was skipped." : "  " + skipped.ToString() + " nodes were skipped.");
         result += "\nSkipped nodes will need to be handled manually.";
         Debug.LogWarning(result + "\n");
      }
      else
      {
         Debug.Log(result + "\n");
      }
   }

   void FileMenuItem_RebuildAll()
   {
      RebuildAllScripts();
   }

   private void FileMenuItem_Clean()
   {
      AssetDatabase.StartAssetEditing();
      StubGeneratedCode(Preferences.UserScripts);
      AssetDatabase.StopAssetEditing();
      AssetDatabase.Refresh();
   }

   void DrawGUIContent()
   {
      var isPainting = Event.current.type == EventType.Repaint;

      Rect rect = EditorGUILayout.BeginVertical();
      {
         // Toolbar
         Rect toolbarRect = EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            if (toolbarRect.width != 0 && toolbarRect.height != 0)
            {
               m_NodeToolbarRect = toolbarRect;
            }

            if (GUILayout.Button(uScriptGUIContent.FileMenu, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
            {
               this.ContextMenuFile(this.fileButtonRect);
            }

            if (isPainting)
            {
               this.fileButtonRect = GUILayoutUtility.GetLastRect();
            }

            if (GUILayout.Button(uScriptGUIContent.ViewMenu, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
            {
               this.ContextMenuView(this.viewButtonRect);
            }

            if (isPainting)
            {
               this.viewButtonRect = GUILayoutUtility.GetLastRect();
            }

            if (GUILayout.Button(uScriptGUIContent.HelpMenu, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
            {
               this.ContextMenuHelp(this.helpButtonRect);
            }

            if (isPainting)
            {
               this.helpButtonRect = GUILayoutUtility.GetLastRect();
            }

            GUILayout.FlexibleSpace();

            GUILayout.Label("Default Save Mode:", uScriptGUIStyle.ToolbarLabel);
            var oldMethod = (int)Preferences.SaveMethod;
            var newMethod = EditorGUILayout.Popup(oldMethod, uScriptGUIContent.SaveMethodOptions, EditorStyles.toolbarDropDown, GUILayout.Width(100));
            if (newMethod != oldMethod)
            {
               Preferences.SaveMethod = (Preferences.SaveMethodType)newMethod;
            }

            GUILayout.FlexibleSpace();

            var buildInfo = string.Format("{0} (v{1})", uScriptBuild.Name, uScriptBuild.Number);
            GUILayout.Label(buildInfo, uScriptGUIStyle.ToolbarLabel);
         }
         EditorGUILayout.EndHorizontal();

         // Canvas
         GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
         {
            if (rect.width != 0 && rect.height != 0)
            {
               m_NodeWindowRect = rect;
            }

            GUIStyle style = new GUIStyle();
            style.normal.background = uScriptConfig.CanvasBackgroundTexture;

            GUI.SetNextControlName("MainView");

            _guiContentScrollPos = EditorGUILayout.BeginScrollView(_guiContentScrollPos, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, style, GUILayout.ExpandWidth(true));
            {
               // Get the bounding area of all nodes on the canvas, plus 64px to
               // allow for 32px padding around the edges.  This will allow the
               // scrollbars to span the bounds accurately.
               //
               // For each dimension, use the larger of the bounding area and the
               // canvas mouseRegionRect.
               //
               // When zoom is implemented, make sure the results are accurately scaled
               //
               //            int canvasWidth = (mouseRegionRect.ContainsKey(MouseRegion.Canvas) ? (int)(mouseRegionRect[MouseRegion.Canvas].width) : 0);
               //            int canvasHeight = (mouseRegionRect.ContainsKey(MouseRegion.Canvas) ? (int)(mouseRegionRect[MouseRegion.Canvas].height-18) : 0);
               //
               //            GUILayout.Box(string.Empty, style, GUILayout.Width(canvasWidth), GUILayout.Height(canvasHeight));

               // Paint the graph (nodes, sockets, links, and comments)
               PaintEventArgs args = new PaintEventArgs();
               args.Graphics = new Detox.Drawing.Graphics();

               if (m_ScriptEditorCtrl != null)
               {
                  m_ScriptEditorCtrl.FlowChart.Zoom = this.mapScale;
                  m_ScriptEditorCtrl.FlowChart.ZoomPoint = new Point((int)this.zoomPoint.x, (int)this.zoomPoint.y);

                  m_ScriptEditorCtrl.GuiPaint(args);
               }
            }
            EditorGUILayout.EndScrollView();

            GUI.SetNextControlName(string.Empty);
         }
         GUILayout.EndVertical();

         if (isPainting)
         {
            _canvasRect = GUILayoutUtility.GetLastRect();
         }
      }
      EditorGUILayout.EndVertical();

      SetMouseRegion(MouseRegion.Canvas);//, 3, 1, -2, -4 );
   }

   private void ContextMenuFile(Rect rect)
   {
      var menu = new GenericMenu();

      menu.AddItem(uScriptGUIContent.FileMenuItemNew, false, FileMenuItem_New);
      menu.AddItem(uScriptGUIContent.FileMenuItemOpen, false, FileMenuItem_Open);
      menu.AddSeparator(string.Empty);
      menu.AddItem(uScriptGUIContent.FileMenuItemSave, false, FileMenuItem_Save);
      menu.AddItem(uScriptGUIContent.FileMenuItemSaveAs, false, FileMenuItem_SaveAs);
      menu.AddSeparator(string.Empty);
      menu.AddItem(uScriptGUIContent.FileMenuItemSaveQuick, false, FileMenuItem_QuickSave);
      menu.AddItem(uScriptGUIContent.FileMenuItemSaveDebug, false, FileMenuItem_DebugSave);
      menu.AddItem(uScriptGUIContent.FileMenuItemSaveRelease, false, FileMenuItem_ReleaseSave);
      menu.AddSeparator(string.Empty);
      menu.AddItem(uScriptGUIContent.FileMenuItemExportImage, false, FileMenuItem_ExportPNG);
      menu.AddItem(uScriptGUIContent.FileMenuItemUpgradeNodes, false, this.FileMenuItem_UpgradeDeprecatedNodes);
      menu.AddSeparator(string.Empty);
      menu.AddItem(uScriptGUIContent.FileMenuItemFindMissingGraphs, false, FileMenuItem_FindMissingGraphs);
      menu.AddSeparator(string.Empty);
      menu.AddItem(uScriptGUIContent.FileMenuItemRebuildGraphs, false, this.FileMenuItem_RebuildAll);
      menu.AddItem(uScriptGUIContent.FileMenuItemRemoveSource, false, this.FileMenuItem_Clean);

      // @TODO: Consider changing the delegate function from "FileMenuItem_*" to "Command*"
      // @TODO: Consider adding Reload and Location commands

      menu.DropDown(rect);

      Event.current.Use();
   }

   private void ContextMenuView(Rect rect)
   {
      var menu = new GenericMenu();

      menu.AddItem(uScriptGUIContent.ViewMenuItemPanels, !uScriptGUI.PanelsHidden, this.CommandCanvasShowPanels);
      menu.AddSeparator(string.Empty);
      menu.AddItem(uScriptGUIContent.ViewMenuItemGrid, Preferences.ShowGrid, CommandViewMenuGrid);
      menu.AddItem(uScriptGUIContent.ViewMenuItemSnap, Preferences.GridSnap, CommandViewMenuSnap);
      menu.AddDisabledItem(uScriptGUIContent.ViewMenuItemSnapSelected);
      menu.AddSeparator(string.Empty);

      menu.AddItem(uScriptGUIContent.ViewMenuItemFindCanvasOrigin, false, CommandCanvasLocateOrigin);
      menu.AddItem(uScriptGUIContent.ViewMenuItemFindNextEvent, false, this.CommandCanvasLocateNextEvent);
      menu.AddItem(uScriptGUIContent.ViewMenuItemFindPreviousEvent, false, this.CommandCanvasLocatePreviousEvent);

      menu.AddSeparator(string.Empty);

      if (this.mapScale < 1.0f)
      {
         menu.AddItem(uScriptGUIContent.ViewMenuItemZoomIn, false, this.CommandCanvasZoomIn);
      }
      else
      {
         menu.AddDisabledItem(uScriptGUIContent.ViewMenuItemZoomIn);
      }

      if (this.mapScale > 0.1f)
      {
         menu.AddItem(uScriptGUIContent.ViewMenuItemZoomOut, false, this.CommandCanvasZoomOut);
      }
      else
      {
         menu.AddDisabledItem(uScriptGUIContent.ViewMenuItemZoomOut);
      }

      if (this.mapScale < 1.0f)
      {
         menu.AddItem(uScriptGUIContent.ViewMenuItemZoomReset, false, this.CommandCanvasZoomReset);
      }
      else
      {
         menu.AddDisabledItem(uScriptGUIContent.ViewMenuItemZoomReset);
      }

      menu.DropDown(rect);

      Event.current.Use();
   }

   private void ContextMenuHelp(Rect rect)
   {
      var menu = new GenericMenu();

      menu.AddItem(uScriptGUIContent.HelpMenuItemShortcuts, false, CommandHelpMenuShortcuts);
      menu.AddItem(uScriptGUIContent.HelpMenuItemWelcome, false, CommandHelpMenuWelcome);
      menu.AddSeparator(string.Empty);
      menu.AddItem(uScriptGUIContent.HelpMenuItemOnlineDocs, false, CommandHelpMenuDocs);
      menu.AddItem(uScriptGUIContent.HelpMenuItemOnlineForum, false, CommandHelpMenuForum);
      menu.AddItem(uScriptGUIContent.HelpMenuItemUpdates, false, CommandHelpMenuUpdates);
      menu.AddSeparator(string.Empty);

#if DETOX_STORE_PLE || UNITY_STORE_PLE
      menu.AddItem(uScriptGUIContent.HelpMenuItemBuyBasic, false, CommandHelpMenuBuyBasic);
      menu.AddItem(uScriptGUIContent.HelpMenuItemBuyPro, false, CommandHelpMenuBuyPro);
      menu.AddSeparator(string.Empty);
#elif DETOX_STORE_BASIC || UNITY_STORE_BASIC
      //menu.AddItem(uScriptGUIContent.HelpMenuItemUpgrade, false, CommandHelpMenuUpgrade);
      //menu.AddSeparator(string.Empty);
#endif

      menu.AddItem(uScriptGUIContent.HelpMenuItemAbout, false, CommandHelpMenuAbout);

      menu.DropDown(rect);

      Event.current.Use();
   }

   private void m_ScriptEditorCtrl_ScriptModified(object sender, EventArgs e)
   {
      RequestRepaint();
   }

   private void DrawContextMenuWindow(int windowID)
   {
      GUI.depth = 0;
      if (null == m_CurrentMenu)
      {
         foreach (ToolStripItem item in m_ScriptEditorCtrl.ContextMenuWithReflection.Items)
         {
            if (item.Text == "<hr>")
            {
               uScriptGUI.HorizontalRule();
            }
            else
            {
               if (GUILayout.Button(item.Text.Replace("&", string.Empty), uScriptGUIStyle.MenuContextButton))
               {
                  m_CurrentMenu = item;
                  break;
               }
            }
         }
      }

      if (null != m_CurrentMenu)
      {
         DrawSubItems(m_CurrentMenu as ToolStripMenuItem);
      }
   }

   public static string FindFile(string path, string fileName)
   {
      DirectoryInfo directory = new DirectoryInfo(path);

      FileInfo[] files = directory.GetFiles();

      foreach (FileInfo file in files)
      {
         if (file.Name == fileName)
         {
            return file.FullName;
         }
      }

      foreach (DirectoryInfo subDirectory in directory.GetDirectories())
      {
         var result = FindFile(subDirectory.FullName, fileName);
         if (result != string.Empty)
         {
            return result;
         }
      }

      return string.Empty;
   }

   public static string[] FindAllFiles(string rootPath, string extension)
   {
      List<string> paths = new List<string>();

      DirectoryInfo directory = new DirectoryInfo(rootPath);

      FileInfo[] files = directory.GetFiles();

      foreach (FileInfo file in files)
      {
         if (file.Extension == extension)
         {
            paths.Add(file.FullName);
         }
      }

      foreach (DirectoryInfo subDirectory in directory.GetDirectories())
      {
         string[] results = FindAllFiles(subDirectory.FullName, extension);
         paths.AddRange(results);
      }

      return paths.ToArray();
   }

   private void DrawSubItems(ToolStripMenuItem menuItem)
   {
      if (null == menuItem) return;

      foreach (ToolStripItem item in menuItem.DropDownItems)
      {
         if (GUILayout.Button(item.Text.Replace("&", string.Empty), uScriptGUIStyle.MenuContextButton))
         {
            m_CurrentMenu = item;
            rectContextMenuWindow.width = 10;
            rectContextMenuWindow.height = 10;
            break;
         }
      }

      if (null != m_CurrentMenu && null != m_CurrentMenu.Click)
      {
         ToolStripItem item = m_CurrentMenu;

         m_ContextX = 0;
         m_ContextY = 0;
         m_CurrentMenu = null;
         rectContextMenuWindow = new Rect();

         item.OnClick();
      }
   }

   public void OnMouseDown()
   {
      Control.MouseButtons.Buttons = m_MouseDownArgs.Button;

      Detox.Windows.Forms.Cursor.AbsolutePosition = new Point(m_MouseDownArgs.X, m_MouseDownArgs.Y );
      Detox.Windows.Forms.Cursor.Button = m_MouseDownArgs.Button;

      //      Debug.Log("BUTTON " + Control.MouseButtons.Buttons + " - OnMouseDown() at " + Detox.Windows.Forms.Cursor.Position.ToString() + "\n");

      m_ScriptEditorCtrl.OnMouseDown();
   }

   public void OnMouseUp()
   {
      Detox.Windows.Forms.Cursor.AbsolutePosition = new Point( m_MouseUpArgs.X, m_MouseUpArgs.Y );
      Detox.Windows.Forms.Cursor.Button = m_MouseUpArgs.Button;

      //      Debug.Log("BUTTON " + Control.MouseButtons.Buttons + " - OnMouseUp() at " + Detox.Windows.Forms.Cursor.Position.ToString() + "\n");

      m_ScriptEditorCtrl.OnMouseUp();

      this.currentCanvasPosition = m_ScriptEditorCtrl.FlowChart.Location.X.ToString() + "," + m_ScriptEditorCtrl.FlowChart.Location.Y.ToString();
      if (!String.IsNullOrEmpty(this.fullPath))
      {
         SetSetting("uScript\\" + uScriptConfig.ConstantPaths.RelativePath(this.fullPath) + "\\CanvasPosition", this.currentCanvasPosition);
      }

      Detox.Windows.Forms.Cursor.Button = 0;
      Control.MouseButtons.Buttons = 0;
   }

   public void OnMouseMove()
   {
      //      Debug.Log("OnMouseMove()\n");

      // calculate delta for handle dragging
      int deltaX = m_MouseMoveArgs.X - lastMouseX;
      int deltaY = m_MouseMoveArgs.Y - lastMouseY;
      lastMouseX = m_MouseMoveArgs.X;
      lastMouseY = m_MouseMoveArgs.Y;

      // convert to main canvas space
      m_MouseMoveArgs.X -= (int)_canvasRect.x;
      m_MouseMoveArgs.Y -= (int)_canvasRect.y;

      //      Debug.Log("m_MouseMoveArgs: \t" + m_MouseMoveArgs.X.ToString() + ", " + m_MouseMoveArgs.Y.ToString()
      //                + "\n_canvasRect: \t\t\t" + _canvasRect.x.ToString() + ", " + _canvasRect.y.ToString() + " ... "
      //                + (uScriptGUI.panelLeftWidth + DIVIDER_WIDTH - 1).ToString());

      Detox.Windows.Forms.Cursor.AbsolutePosition = new Point( m_MouseMoveArgs.X, m_MouseMoveArgs.Y );
      Detox.Windows.Forms.Cursor.Button = m_MouseMoveArgs.Button;

      if (this.mouseRegion == MouseRegion.Canvas)
      {
         m_ScriptEditorCtrl.OnMouseMove();
      }

      // convert back to screen
      m_MouseMoveArgs.X += (int)_canvasRect.x;
      m_MouseMoveArgs.Y += (int)_canvasRect.y;

      // check for divider draggging
      if (GuiState.Enabled && !uScriptGUI.PanelsHidden && this.mouseDown)
      {
         if (this.mouseDownRegion == MouseRegion.HandleCanvas && deltaY != 0)
         {
            uScriptGUI.PanelPropertiesHeight -= deltaY;
            RequestRepaint();
         }
         else if (this.mouseDownRegion == MouseRegion.HandlePalette && deltaX != 0)
         {
            uScriptGUI.PanelLeftWidth += deltaX;
            RequestRepaint();
         }
         else if (this.mouseDownRegion == MouseRegion.HandleProperties && deltaX != 0)
         {
            uScriptGUI.PanelPropertiesWidth += deltaX;
            RequestRepaint();
         }
         else if (this.mouseDownRegion == MouseRegion.HandleReference && deltaX != 0)
         {
            uScriptGUI.PanelScriptsWidth -= deltaX;
            RequestRepaint();
         }
      }
   }

   public static void RequestRepaint(int minimumRedraws = 1)
   {
      pendingRepaintRequests = Mathf.Max(pendingRepaintRequests, minimumRedraws);
   }

   private bool WasCurrentGraphSaved(bool allowCancel)
   {
      if (m_ScriptEditorCtrl != null && this.m_ScriptEditorCtrl.IsDirty)
      {
         const string Title = "Save uScript Graph?";
         const string Message = "The current graph has been modified, would you like to save the graph and generate source files?";

         var message = string.IsNullOrEmpty(m_ScriptEditorCtrl.ScriptEditor.Name)
                          ? Message
                          : string.Format(
                             "{0}\n\n\t{1}\n",
                             Message,
                             Path.GetFileNameWithoutExtension(this.m_ScriptEditorCtrl.ScriptEditor.Name));

         int result;

         if (allowCancel)
         {
            result = EditorUtility.DisplayDialogComplex(Title, message, "Yes", "No", "Cancel");
         }
         else
         {
            result = EditorUtility.DisplayDialog(Title, message, "Yes", "No") ? 0 : 1;
         }

         // YES - user wishes to save the graph
         if (result == 0)
         {
            return RequestSave(
               Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
               Preferences.SaveMethod == Preferences.SaveMethodType.Debug,
               false);

            //if (SaveDenied())
            //{
            //   return false;
            //}

            //AssetDatabase.StartAssetEditing();

            //var saved = this.SaveScript(false);

            //AssetDatabase.StopAssetEditing();

            //return saved;
         }

         // NO - user does not want to save before continue operation
         if (result == 1)
         {
            return true;
         }

         // CANCEL - user wants to abort the save and the previous operation
         if (result == 2)
         {
            return false;
         }
      }

      // the graph was not dirty and doesn't need to be saved
      return true;
   }

   public void CreateNewGraph()
   {
      Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor(string.Empty, PopulateEntityTypes(null), PopulateLogicTypes());

      m_ScriptEditorCtrl = new ScriptEditorCtrl(scriptEditor);
      m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);

      m_ScriptEditorCtrl.BuildContextMenu();
      uScriptGUIPanelToolbox.Instance.BuildPaletteMenu();

      //reset zoom we're not in some weird zoom state
      this.mapScale = 1.0f;

      this.currentScriptName = null;

      this.currentCanvasPosition = string.Empty;

      this.currentScriptDirty = false;
      this.currentScript = scriptEditor.ToBase64(null);
      this.currentScriptName = scriptEditor.Name;

      //brand new scriptso clear out any previous caches and undo/redo
      //ClearEntityTypes();
      //ClearLogicTypes();
      ClearChangeStack();
      OpenFromCache();

      this.fullPath = string.Empty;

      //Debug.Log("clearing" );
      uScript.SetSetting("uScript\\LastOpened", string.Empty);
   }

   private void ClearEntityTypes()
   {
      m_EntityTypes = null;
      m_SzEntityTypes = null;
   }

   private void ClearLogicTypes()
   {
      m_LogicTypes = null;
      m_SzLogicTypes = null;
   }

   public void UpdateReflectedTypes()
   {
      this.ClearEntityTypes();
      this.PopulateEntityTypes(null);
      this.OpenFromCache();
   }

   public bool OpenGraph(string fullPath, bool launching)
   {
      if (File.Exists(fullPath) == false)
      {
         // don't spit out an error if we're just launching uscript
         if (launching)
         {
            uScriptDebug.Log(fullPath + " was open last time uScript was open, but is not found now - did it get moved or deleted?", uScriptDebug.Type.Message);
         }
         else
         {
            uScriptDebug.Log("The specified file does not exist: " + fullPath, uScriptDebug.Type.Error);
         }
         return false;
      }

      if (this.WasCurrentGraphSaved(true) == false)
      {
         return false;
      }

      Profile p = new Profile("OpenScript " + fullPath);

      Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor(string.Empty, null, null);
      scriptEditor.Open(fullPath);

      scriptEditor = new Detox.ScriptEditor.ScriptEditor(string.Empty, PopulateEntityTypes(scriptEditor.Types), PopulateLogicTypes());
 
      if (scriptEditor.Open(fullPath))
      {
         #if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(EditorApplication.currentScene);
         #else
            UnityEngine.SceneManagement.Scene scene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
            string sceneName = scene.name;
         #endif
         
         if (Preferences.EnableSceneWarning && scriptEditor.SceneName != string.Empty && scriptEditor.SceneName != sceneName)
         {
            var message =
               string.Format(
                  "This uScript file was attached to the uScript Master GameObject in scene {0}. It may not"
                  + " be compatible with this scene or run correctly if edited while this scene is open.",
                  scriptEditor.SceneName);
            EditorUtility.DisplayDialog("uScript Scene Warning", message, "OK");
         }

         //reset zoom we're not in some weird zoom state
         this.mapScale = 1.0f;

         this.currentScriptName = null;

         if (fullPath != this.fullPath)
         {
            this.currentCanvasPosition = string.Empty;
         }

         this.fullPath = fullPath;

         SetSetting("uScript\\LastOpened", uScriptConfig.ConstantPaths.RelativePath(fullPath).Substring("Assets".Length));

         this.currentCanvasPosition = Preferences.GetString("uScript\\" + uScriptConfig.ConstantPaths.RelativePath(this.fullPath) + "\\CanvasPosition", string.Empty);

         this.currentScriptDirty = false;
         this.currentScript = scriptEditor.ToBase64(null);
         this.currentScriptName = scriptEditor.Name;

         //brand new scriptso clear out any previous caches and undo/redo
         ClearChangeStack();
         //ClearEntityTypes();
         //ClearLogicTypes();
         OpenFromCache();

         //uScriptBackgroundProcess.ForceFileRefresh();

         p.End();
      }
      else
      {
         uScriptDebug.Log("An error occurred opening " + fullPath, uScriptDebug.Type.Error);
         return false;
      }

      return true;
   }

   public void StubGeneratedCode(string path)
   {
      RebuildScripts(path, true);
   }

   public void RebuildAllScripts(bool silent = false)
   {
      // First remove everything so we get rid of any compiler errors,
      // which allows the reflection to properly refresh
      this.FileMenuItem_Clean();

      this.rebuildWhenReady = true;
      this.rebuildSilently = silent;
   }

   public void RebuildScript(string scriptFullName, bool stubCode)
   {
      var scriptEditor = new ScriptEditor(string.Empty, null, null);
      scriptEditor.Open(scriptFullName);

      scriptEditor = new ScriptEditor(string.Empty, this.PopulateEntityTypes(scriptEditor.Types), PopulateLogicTypes());

      if (scriptEditor.Open(scriptFullName))
      {
         if (this.SaveGraph(scriptEditor, scriptFullName, true, this.GenerateDebugInfo, stubCode))
         {
            uScriptDebug.Log(string.Format("Rebuilt:\t{0}", scriptFullName.RelativeAssetPath()));
         }
         else
         {
            uScriptDebug.Log(string.Format("Could not save {0}", scriptFullName.RelativeAssetPath()), uScriptDebug.Type.Error);
         }
      }
   }

   public void RebuildScripts(string path, bool stubCode)
   {
      Debug.Log(string.Format("RebuildScripts({0}, {1})", path, stubCode));
#if (UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
      List<string> files = GetGraphPaths();
      foreach (string file in files)
      {
         this.RebuildScript(file, stubCode);
      }
#else
      var directory = new DirectoryInfo(path);

      var files = directory.GetFiles();

      foreach (var file in files.Where(file => ".uscript" == file.Extension))
      {
         this.RebuildScript(file.FullName, stubCode);
      }

      foreach (var subDirectory in directory.GetDirectories())
      {
         this.RebuildScripts(subDirectory.FullName, stubCode);
      }
#endif
   }

   // returns false if path is not in source control or source control is not active
   // optionally, you can check out the file if it is in source control (defaults behavior is to check out)
   public static bool IsFileInSourceControl(string path, bool checkout = true)
   {
      bool inVC = false;

#if (UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
      // blocking checkout of versioned file, if necessary
      if (UnityEditor.VersionControl.Provider.isActive)
      {
         UnityEditor.VersionControl.Asset asset = UnityEditor.VersionControl.Provider.GetAssetByPath(path.RelativeAssetPath());
         if (asset != null)
         {
            UnityEditor.VersionControl.Task statusTask = UnityEditor.VersionControl.Provider.Status(asset);
            statusTask.Wait();
            if (UnityEditor.VersionControl.Provider.CheckoutIsValid(statusTask.assetList[0]))
            {
               inVC = true;
               if (checkout)
               {
                  UnityEditor.VersionControl.Task coTask = UnityEditor.VersionControl.Provider.Checkout(statusTask.assetList[0], UnityEditor.VersionControl.CheckoutMode.Both);
                  coTask.Wait();
               }
            }
         }
      }
#endif

      return inVC;
   }

   public static bool FileHasLabels(string fullPath, string[] labels)
   {
      UnityEngine.Object obj = AssetDatabase.LoadMainAssetAtPath(fullPath.RelativeAssetPath());
      if (obj != null)
      {
         string[] lbls = AssetDatabase.GetLabels(obj);
         foreach(string label in labels)
         {
            if (!lbls.Contains(label)) return false;
         }
      }

      return true;
   }

   public static void SetLabelsOnFile(string fullPath, string[] labels)
   {
      if (!FileHasLabels(fullPath, labels))
      {
         UnityEngine.Object obj = AssetDatabase.LoadMainAssetAtPath(fullPath.RelativeAssetPath());
         if (obj != null)
         {
            IsFileInSourceControl(fullPath);  // checkout if necessary
            AssetDatabase.SetLabels(obj, labels);
         }
      }
   }

   private string GetGeneratedScriptPath(string binaryPath)
   {
      String fileName = Path.GetFileNameWithoutExtension(binaryPath) + uScriptConfig.Files.GeneratedComponentExtension + ".cs";

      Directory.CreateDirectory(Preferences.GeneratedScripts);

#if (UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
      // first see if we've already saved the file and then just use that path
      List<string> files = GetFilePathsWithLabel("uScriptCode");
      string filename = binaryPath.Substring(binaryPath.LastIndexOf("/"));
      filename = filename.Substring(0, filename.LastIndexOf(".")) + uScriptConfig.Files.GeneratedComponentExtension + ".cs";
      foreach (string file in files)
      {
         if (file.Contains(filename)) return file;
      }

      // not found, fall back to default
      return Preferences.GeneratedScripts + "/" + fileName;
#else
      return Preferences.GeneratedScripts + "/" + fileName;
#endif
   }

   private string GetNestedScriptPath(string binaryPath)
   {
      String fileName = Path.GetFileNameWithoutExtension(binaryPath) + uScriptConfig.Files.GeneratedCodeExtension + ".cs";

      Directory.CreateDirectory(Preferences.NestedScripts);

#if (UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
      // first see if we've already saved the file and then just use that path
      List<string> files = GetFilePathsWithLabel("uScriptCode");
      string filename = binaryPath.Substring(binaryPath.LastIndexOf("/"));
      filename = filename.Substring(0, filename.LastIndexOf(".")) + uScriptConfig.Files.GeneratedCodeExtension + ".cs";
      foreach (string file in files)
      {
         if (file.Contains(filename)) return file;
      }

      // not found, fall back to default
      return Preferences.NestedScripts + "/" + fileName;
#else
      return Preferences.NestedScripts + "/" + fileName;
#endif
   }

   private bool SaveGraph(ScriptEditor script, string binaryPath, bool generateCode, bool generateDebugInfo, bool stubCode)
   {
      bool result;

      if (generateCode)
      {
         string wrapperPath = this.GetGeneratedScriptPath(binaryPath);
         string logicPath = this.GetNestedScriptPath(binaryPath);

         result = script.Save(binaryPath, logicPath, wrapperPath, generateDebugInfo, stubCode);

         //if (result)
         //{
         //   // refresh uScript panel file list
         //   uScriptBackgroundProcess.ForceFileRefresh();
         //}
      }
      else
      {
         result = script.Save(binaryPath);
      }

      return result;
   }

   private bool SaveGraph(bool forceNameRequest, bool generateCode, bool generateDebugInfo)
   {
      ScriptEditor script = this.m_ScriptEditorCtrl.ScriptEditor;

      // No file of this name or force us to ask for the name
      if (this.fullPath == string.Empty || forceNameRequest)
      {
         const string Extension = "uscript";
         bool isSafe = false;
         string chosenPath = "Untitled.uScript";

         // The initial path for the panel should match the location of the current graph, otherwise Preferences.UserScripts
         var currentGraphName = Path.GetFileNameWithoutExtension(script.Name) ?? string.Empty;
         var currentGraphPath = uScriptBackgroundProcess.GraphInfoList.ContainsKey(currentGraphName)
            ? uScriptBackgroundProcess.GraphInfoList[currentGraphName].GraphPath
            : string.Empty;

         var directory = string.IsNullOrEmpty(currentGraphPath) ? Preferences.UserScripts : Path.GetDirectoryName(currentGraphPath);
         var defaultName = script.Name;

         while (!isSafe && chosenPath != string.Empty)
         {
            chosenPath = EditorUtility.SaveFilePanel("Save the uScript Graph As ...", directory, defaultName, Extension);

            // Update the defaults to reflect the most recently selected path
            defaultName = Path.GetFileNameWithoutExtension(chosenPath);
            uScriptDebug.Assert(defaultName != null, "defaultName is null");

            if (chosenPath != string.Empty)
            {
#if UNITY_3_5
               // Validate the chosen graph location
               isSafe = chosenPath.StartsWith(Preferences.UserScripts + "/");
               if (!isSafe)
               {
                  // The specified directory is outside the UserScripts directory
                  var displayPath = Preferences.UserScripts.Substring(Application.dataPath.Length);
                  if (Application.platform == RuntimePlatform.WindowsEditor)
                  {
                     displayPath = displayPath.Replace("/", "\\");
                  }

                  displayPath = string.Format("Assets{0}", displayPath);

                  var errorMessage =
                     string.Format(
                        "The chosen file location is invalid. The graph file must be saved in the uScript graphs directory"
                        + " or in one of its sub-directories.\n\nThe project graph location can be modified through uScript"
                        + " Preferences. It is currently set to:\n\n\t\"{0}\"\n",
                        displayPath);

                  if (EditorUtility.DisplayDialog("Invalid Location", errorMessage, "Try Again", "Cancel") == false)
                  {
                     return false;
                  }

                  continue;
               }
#endif

               // Update the defaults to reflect the most recently selected path
               directory = Path.GetDirectoryName(chosenPath);

               // Sanitize the chosen filename
               var safeName = UnityCSharpGenerator.MakeSyntaxSafe(defaultName, out isSafe);
               if (!isSafe)
               {
                  // filename is not safe - tell the user they need to change it
                  var errorMessage =
                     string.Format(
                        "Filename must be all alpha-numeric characters and must not start with a number."
                        + " A suggested name for the one you entered is: \"{0}\"",
                        safeName);

                  if (EditorUtility.DisplayDialog("Invalid File Name", errorMessage, "Try Again", "Cancel") == false)
                  {
                     return false;
                  }

                  // Update the defaultName to the sanitized version
                  defaultName = string.Format("{0}.{1}", safeName, Extension);

                  continue;
               }

               // Verify that it is not already being used, unless it entirely replaces an existing graph
               var graphName = Path.GetFileNameWithoutExtension(defaultName);
               isSafe = uScriptBackgroundProcess.GraphInfoList.ContainsKey(graphName) == false
                  || chosenPath == uScriptBackgroundProcess.GraphInfoList[graphName].GraphPath;
               if (!isSafe)
               {
                  // The specified graph name is already in use
                  const string ErrorMessage = "The chosen graph name is already in use. Please select a different filename.";
                  if (EditorUtility.DisplayDialog("Graph Name Unavailable", ErrorMessage, "Try Again", "Cancel") == false)
                  {
                     return false;
                  }
               }
            }
         }

         // Early exit, they must have changed their minds
         if (chosenPath == string.Empty)
         {
            return false;
         }

         this.fullPath = chosenPath;
         SetSetting("uScript\\LastOpened", uScriptConfig.ConstantPaths.RelativePath(this.fullPath).Substring("Assets".Length));
      }

      if (this.fullPath == string.Empty)
      {
         return false;
      }

      bool firstSave = false;
      string componentPath = this.GetGeneratedScriptPath(this.fullPath);

      //only attach if they're generating code and it's never been generated before
      //they could have saved without generating code by using quick save
      if (false == File.Exists(componentPath) && generateCode)
      {
         firstSave = true;
      }
      else if (forceNameRequest && generateCode)
      {
         firstSave = true;
      }

      bool pleaseAttachMe = false;
      bool currentlyAttached = false;

      //ask before they've saved so we know
      //whether or not we have to save the scene name with the script
      if (firstSave)
      {
         // ask the user if they want to assign this script to the master game object
         pleaseAttachMe = EditorUtility.DisplayDialog("Assign Graph To Master GameObject?", "This uScript graph has not been assigned to the master GameObject yet.\n\n Select YES to assign it now, or NO to manually assign the graph to a GameObject or Prefab later. ", "Yes", "No");
      }
      else
      {
         currentlyAttached = this.IsAttachedToMaster;
      }

      //if they do want to attach to the master then set
      //the scene name before we save
      if (pleaseAttachMe || currentlyAttached)
      {
         #if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(EditorApplication.currentScene);
         #else
            UnityEngine.SceneManagement.Scene scene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
            string sceneName = scene.name;
         #endif

         script.SceneName = sceneName;
      }
      else
      {
         //could be a save as, so make sure to clear the connection
         script.SceneName = string.Empty;
      }

      if (this.SaveGraph(script, this.fullPath, generateCode, generateDebugInfo, false))
      {
         // When a file is saved (regardless of method), we should update the
         // Dictionary cache for that script.

         //script was saved under a new name, refresh the control
         if (script.Name != this.m_ScriptEditorCtrl.Name)
         {
            this.m_ScriptEditorCtrl = new ScriptEditorCtrl(script);

            m_ScriptEditorCtrl.BuildContextMenu();
            uScriptGUIPanelToolbox.Instance.BuildPaletteMenu();
         }

         string scriptName = Path.GetFileNameWithoutExtension(this.fullPath);
         this.SetStaleState(scriptName, script.GeneratedCodeIsStale);
         this.SetDebugState(scriptName, script.SavedForDebugging);

         this.m_ScriptEditorCtrl.IsDirty = false;

         this.CacheScript();

         uScriptBackgroundProcess.ForceFileRefresh();
         if (uScript.GraphSaved != null) uScript.GraphSaved();

         if (pleaseAttachMe)
         {
            AssetDatabase.Refresh();
            this.AttachToMasterGO(this.fullPath);
         }

#if ENABLE_ANALYTICS
         GetGraphAnalyticsData(script);
#endif

         return true;
      }

      uScriptDebug.Log("there was an error saving " + this.fullPath, uScriptDebug.Type.Error);

      return false;
   }

   /// <summary>
   /// Gets the graph's node analytics data. This code is part of a side project by Scott to potentially store locally node data for an entire Unity project for things like node deletion on project building to remove unused nodes and such.
   /// </summary>
   /// <param name='script'>
   /// The graph you want to grab all the node data for.
   /// </param>
   private void GetGraphAnalyticsData(Detox.ScriptEditor.ScriptEditor script)
   {
      // Create list of unique nodes used and their quantity used on the graph:
      Dictionary<string, KeyValuePair<string, int>> nodesUsed = new Dictionary<string, KeyValuePair<string, int>>();

      // Get all the Action nodes:
      foreach (Detox.ScriptEditor.LogicNode node in script.Logics)
      {
         if (nodesUsed.ContainsKey(node.FriendlyName))
         {
            KeyValuePair<string, int> tmpPair = new KeyValuePair<string, int>("Action", nodesUsed[node.FriendlyName].Value + 1);
            nodesUsed[node.FriendlyName] = tmpPair;
         }
         else
         {
            KeyValuePair<string, int> tmpPair = new KeyValuePair<string, int>("Action", 1);
            nodesUsed.Add(node.FriendlyName, tmpPair);
         }
      }

      // Get all the Event nodes:
      foreach (Detox.ScriptEditor.EntityEvent node in script.Events)
      {
         if (nodesUsed.ContainsKey(node.FriendlyType))
         {
            KeyValuePair<string, int> tmpPair = new KeyValuePair<string, int>("Event", nodesUsed[node.FriendlyType].Value + 1);
            nodesUsed[node.FriendlyType] = tmpPair;
         }
         else
         {
            KeyValuePair<string, int> tmpPair = new KeyValuePair<string, int>("Event", 1);
            nodesUsed.Add(node.FriendlyType, tmpPair);
         }
      }

   }

   private void AttachToMasterGO(String path)
   {
#if UNITY_EDITOR
      MasterComponent.AttachScriptToMaster(path);
#endif
   }

   private void GatherDerivedTypes(Dictionary<Type, Type> uniqueNodes, string path, Type baseType, string label = "")
   {
#if (UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6)
      DirectoryInfo directory = new DirectoryInfo(path);
      List<FileInfo> filesList = new List<FileInfo>();
      FileInfo[] files;
      if (!string.IsNullOrEmpty(label))
      {
         List<string> filePaths = GetFilePathsWithLabel(label);
         foreach(string filepath in filePaths)
         {
            filesList.Add(new FileInfo(filepath));
         }
         files = filesList.ToArray();
      }
      else
      {
         files = directory.GetFiles();
      }
#else
      DirectoryInfo directory = new DirectoryInfo(path);
      FileInfo[] files = directory.GetFiles();
#endif

      foreach (FileInfo file in files)
      {
         if (file.Name.StartsWith(".") || file.Name.StartsWith("_") || !file.Name.EndsWith(".cs")) continue;

         Type type = uScript.GetAssemblyQualifiedType(Path.GetFileNameWithoutExtension(file.Name));

         if (null != type)
         {
            if (false == uniqueNodes.ContainsKey(type) &&
                 baseType.IsAssignableFrom(type))
            {
               uniqueNodes[type] = type;
            }
         }
      }

      foreach (DirectoryInfo subDirectory in directory.GetDirectories())
      {
         if (subDirectory.Name.StartsWith(".") || subDirectory.Name.StartsWith("_")) continue;

         GatherDerivedTypes(uniqueNodes, subDirectory.FullName, baseType, label);
      }
   }

   private LogicNode[] PopulateLogicTypes()
   {
      if (this.m_LogicTypes != null)
      {
         return m_LogicTypes;
      }

      uScriptDebug.Log("Rebuilding Logic Types", uScriptDebug.Type.Debug);

      Hashtable baseMethods = new Hashtable();
      Hashtable baseEvents = new Hashtable();
      Hashtable baseProperties = new Hashtable();

      if (null == m_SzLogicTypes)
      {
         uScriptDebug.Log("Reparsing Logic Types", uScriptDebug.Type.Debug);

         Dictionary<Type, Type> uniqueNodes = new Dictionary<Type, Type>();

         GatherDerivedTypes(uniqueNodes, uScriptConfig.ConstantPaths.RuntimeNodes, typeof(uScriptLogic));

         GatherDerivedTypes(uniqueNodes, Preferences.UserNodes, typeof(uScriptLogic));
         GatherDerivedTypes(uniqueNodes, Preferences.NestedScripts, typeof(uScriptLogic), "uScriptCode");

         m_SzLogicTypes = new string[uniqueNodes.Values.Count];

         int i = 0;

         foreach (Type t in uniqueNodes.Values)
         {
            m_SzLogicTypes[i++] = t.ToString();
         }
      }

      List<Type> types = new List<Type>();

      foreach (string s in m_SzLogicTypes)
      {
         Type t = uScript.Instance.GetType(s);
         if (null != t) types.Add(t);
      }

      MethodInfo[] methods = typeof(uScriptLogic).GetMethods();

      foreach (MethodInfo m in methods)
      {
         if (true == m.IsPublic)
         {
            baseMethods[m.Name] = m.Name;
         }
      }

      //i think these are legacy uScript support and can go away
      //but i want to wait until we're inbetween builds to risk it
      baseMethods["OnDestroy"] = "OnDestroy";
      baseMethods["OnDisable"] = "OnDisable";
      baseMethods["OnEnable"] = "OnEnable";

      baseMethods["Start"] = "Start";
      baseMethods["Update"] = "Update";
      baseMethods["LateUpdate"] = "LateUpdate";
      baseMethods["FixedUpdate"] = "FixedUpdate";
      baseMethods["OnGUI"] = "OnGUI";

      //this function is added to nested uscripts by the code generator
      //and we don't want to expose it to the user
      baseMethods["Awake"] = "Awake";

      EventInfo[] events = typeof(uScriptLogic).GetEvents();

      foreach (EventInfo e in events)
      {
         baseEvents[e.Name] = e.Name;
      }

      PropertyInfo[] properties = typeof(uScriptLogic).GetProperties();

      foreach (PropertyInfo p in properties)
      {
         baseProperties[p.Name] = p.Name;
      }

      List<LogicNode> logicNodes = new List<LogicNode>();

      types.Sort(TypeSorter);

      foreach (Type type in types)
      {
         uScript.Instance.AddType(type);

         LogicNode logicNode = new LogicNode(type.ToString(), FindFriendlyName(type.ToString(), type.GetCustomAttributes(false)));

         List<Plug> inputs = new List<Plug>();
         List<string> drivens = new List<string>();

         Hashtable accessorMethods = new Hashtable();

         foreach (PropertyInfo p in type.GetProperties())
         {
            if (p.GetGetMethod() != null)
            {
               accessorMethods[p.GetGetMethod().Name] = true;
            }

            if (p.GetSetMethod() != null)
            {
               accessorMethods[p.GetSetMethod().Name] = true;
            }
         }

         foreach (EventInfo e in type.GetEvents())
         {
            if (e.GetAddMethod() != null)
            {
               accessorMethods[e.GetAddMethod().Name] = true;
            }

            if (e.GetRaiseMethod() != null)
            {
               accessorMethods[e.GetRaiseMethod().Name] = true;
            }

            if (e.GetRemoveMethod() != null)
            {
               accessorMethods[e.GetRemoveMethod().Name] = true;
            }
         }

         List<Plug> logicEvents = new List<Plug>();
         List<Parameter> logicEventParameters = new List<Parameter>();

         foreach (EventInfo e in type.GetEvents())
         {
            Plug p;
            p.Name = e.Name;
            p.FriendlyName = FindFriendlyName(p.Name, e.GetCustomAttributes(false));

            // All event types must share the same args, so only gather them once
            if (logicEventParameters.Count == 0)
            {
               ParameterInfo[] eventParameters = e.GetAddMethod().GetParameters();

               foreach (ParameterInfo eventParameter in eventParameters)
               {
                  MethodInfo[] eventHandlerMethods = eventParameter.ParameterType.GetMethods();

                  foreach (MethodInfo eventHandlerMethod in eventHandlerMethods)
                  {
                     if (eventHandlerMethod.Name == "Invoke")
                     {
                        ParameterInfo[] methodParameters = eventHandlerMethod.GetParameters();

                        foreach (ParameterInfo methodParameter in methodParameters)
                        {
                           if (typeof(EventArgs).IsAssignableFrom(methodParameter.ParameterType))
                           {
                              logicNode.EventArgs = methodParameter.ParameterType.ToString().Replace("+", ".");

                              PropertyInfo[] eventProperties = methodParameter.ParameterType.GetProperties();

                              foreach (PropertyInfo eventProperty in eventProperties)
                              {
                                 Parameter output = new Parameter();
                                 output.State = FindSocketState(eventProperty.GetCustomAttributes(false)); ;
                                 output.Name = eventProperty.Name;
                                 output.FriendlyName = FindFriendlyName(eventProperty.Name, eventProperty.GetCustomAttributes(false));
                                 output.Type = eventProperty.PropertyType.ToString().Replace("&", string.Empty);
                                 output.AutoLinkType = FindAutoLinkType(output.Type, eventProperty.GetCustomAttributes(false));
                                 output.Input = false;
                                 output.Output = true;
                                 output.DefaultAsObject = FindDefaultValue(string.Empty, eventProperty.GetCustomAttributes(false));

                                 uScript.Instance.AddType(eventProperty.PropertyType);

                                 logicEventParameters.Add(output);

                                 AddParameterDescField(type.ToString(), eventProperty.Name, eventProperty.GetCustomAttributes(false));
                              }
                           }
                        }

                        //break after Invoke parameter, it's the only one we care about
                        break;
                     }
                  }
               }
            }

            logicEvents.Add(p);
         }

         logicNode.Events = logicEvents.ToArray();
         logicNode.EventParameters = logicEventParameters.ToArray();

         methods = type.GetMethods();

         foreach (MethodInfo m in methods)
         {
            if (true == accessorMethods.Contains(m.Name)) continue;
            if (true == baseMethods.Contains(m.Name)) continue;

            if (false == m.IsPublic) continue;
            if (true == m.IsStatic) continue;

            bool driven = FindDrivenAttribute(m.GetCustomAttributes(false));

            //driven functions are called automatically by the code generation
            //and need no other information parsed 
            //(they use the same parameters as the rest of the functions in the node)
            if (true == driven)
            {
               if (m.ReturnParameter.ParameterType == typeof(bool))
               {
                  drivens.Add(m.Name);
               }

               continue;
            }

            ParameterInfo[] parameters = m.GetParameters();

            List<Parameter> variables = new List<Parameter>();

            foreach (ParameterInfo p in parameters)
            {
               Parameter variable = new Parameter();

               if (true == p.IsOut)
               {
                  variable.Input = false;
                  variable.Output = true;
               }
               else if (p.ParameterType.IsByRef)
               {
                  variable.Input = true;
                  variable.Output = true;
               }
               else
               {
                  variable.Input = true;
                  variable.Output = false;
               }

               variable.State = FindSocketState(p.GetCustomAttributes(false));
               variable.Name = p.Name;
               variable.Type = p.ParameterType.ToString().Replace("&", string.Empty);
               variable.AutoLinkType = FindAutoLinkType(variable.Type, p.GetCustomAttributes(false));
               variable.FriendlyName = FindFriendlyName(p.Name, p.GetCustomAttributes(false));
               variable.DefaultAsObject = FindDefaultValue(string.Empty, p.GetCustomAttributes(false));

               AddAssetPathField(type.ToString(), p.Name, p.GetCustomAttributes(false));
               AddParameterDescField(type.ToString(), p.Name, p.GetCustomAttributes(false));
               AddRequiresLink(type.ToString(), p.Name, p.GetCustomAttributes(false));

               uScript.Instance.AddType(p.ParameterType);

               variables.Add(variable);
            }

            if (m.ReturnType != typeof(void))
            {
               Parameter parameter = new Parameter();
               parameter.Name = "Return";
               parameter.Type = m.ReturnType.ToString().Replace("&", string.Empty);
               parameter.Input = false;
               parameter.Output = true;
               parameter.Default = string.Empty;
               parameter.State = FindSocketState(m.GetCustomAttributes(false));
               parameter.AutoLinkType = FindAutoLinkType(parameter.Type, m.GetCustomAttributes(false));
               parameter.FriendlyName = "Return Value";

               uScript.Instance.AddType(m.ReturnType);

               variables.Add(parameter);
            }

            Plug plug;
            plug.Name = m.Name;
            plug.FriendlyName = FindFriendlyName(m.Name, m.GetCustomAttributes(false));
            inputs.Add(plug);

            //variables just set once here because
            //they must be the same for every logic node function
            logicNode.Parameters = variables.ToArray();
         }

         logicNode.Inputs = inputs.ToArray();
         logicNode.Drivens = drivens.ToArray();

         List<Plug> outputs = new List<Plug>();

         foreach (PropertyInfo property in type.GetProperties())
         {
            if (null != property.GetSetMethod()) continue;
            if (null == property.GetGetMethod()) continue;

            Plug plug;
            plug.Name = property.Name;
            plug.FriendlyName = FindFriendlyName(plug.Name, property.GetCustomAttributes(false));
            outputs.Add(plug);
         }

         logicNode.Outputs = outputs.ToArray();

         logicNodes.Add(logicNode);
      }

      m_LogicTypes = OverrideNestedScriptTypes(logicNodes.ToArray());
      return m_LogicTypes;
   }

   private RawScript[] GatherRawScripts()
   {
      List<RawScript> rawScripts = new List<RawScript>();

#if (UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
      string[] files = GetGraphPaths().ToArray();
#else
      string[] files = FindAllFiles(Preferences.UserScripts, ".uscript");
#endif

      foreach (string file in files)
      {
         RawScript rawScript = new RawScript();
         if (false == rawScript.Load(file))
         {
            Detox.Utility.Status.Warning("Could not load " + file + " to use for nested script parameters, reflection will be used instead");
            continue;
         }

         rawScripts.Add(rawScript);

      }

      return rawScripts.ToArray();
   }

   private LogicNode[] OverrideNestedScriptTypes(LogicNode[] logicNodes)
   {
      Dictionary<string, LogicNode> returnNodes = new Dictionary<string, LogicNode>();

      RawScript[] rawScripts = GatherRawScripts();

      foreach (LogicNode logicNode in logicNodes)
      {
         returnNodes[logicNode.Type] = logicNode;
      }

      foreach (RawScript rawScript in rawScripts)
      {
         //only use it if it exposes some type of external
         if (rawScript.ExternalParameters.Length > 0 ||
              rawScript.ExternalInputs.Length > 0 ||
              rawScript.ExternalOutputs.Length > 0 ||
              rawScript.ExternalEvents.Length > 0
            )
         {
            string friendlyName = rawScript.FriendlyName;
            if (string.Empty == friendlyName) friendlyName = rawScript.Type;

            LogicNode logicNode = new LogicNode(rawScript.Type, friendlyName);

            logicNode.Parameters = rawScript.ExternalParameters;
            logicNode.Inputs = rawScript.ExternalInputs;
            logicNode.Outputs = rawScript.ExternalOutputs;
            logicNode.Events = rawScript.ExternalEvents;
            logicNode.Drivens = rawScript.Drivens;
            logicNode.RequiredMethods = rawScript.RequiredMethods;
            logicNode.EventArgs = rawScript.EventArgs;
            logicNode.IsNestedNode = true;
            logicNode.EventParameters = rawScript.ExternalEventParameters;

            m_RawDescription[rawScript.Type] = rawScript.Description;

            returnNodes[rawScript.Type] = logicNode;
         }
         else
         {
            returnNodes.Remove(rawScript.Type);
         }
      }

      return returnNodes.Values.ToArray();
   }

   private void Reflect(Type type, List<EntityDesc> entityDescs, Hashtable baseMethods, Hashtable baseEvents, Hashtable baseProperties)
   {
      EntityDesc entityDesc = new EntityDesc();

      entityDesc.Type = type.ToString();
      uScript.Instance.AddType(type);

      MethodInfo[] methodInfos = type.GetMethods();
      EventInfo[] eventInfos = type.GetEvents();
      PropertyInfo[] propertyInfos = type.GetProperties();
#if !(DETOX_STORE_BASIC || UNITY_STORE_BASIC)
      FieldInfo[] fieldInfos = type.GetFields();
#endif

      List<EntityMethod> entityMethods = new List<EntityMethod>();

      Hashtable accessorMethods = new Hashtable();

      foreach (PropertyInfo p in propertyInfos)
      {
         if (p.GetGetMethod() != null)
         {
            accessorMethods[p.GetGetMethod().Name] = true;
         }

         if (p.GetSetMethod() != null)
         {
            accessorMethods[p.GetSetMethod().Name] = true;
         }
      }

      foreach (MethodInfo m in methodInfos)
      {
         if (accessorMethods.Contains(m.Name)) continue;

         //don't expose our event methods to the user
         if (typeof(uScriptEvent).IsAssignableFrom(type)) continue;

         if (false == m.IsPublic) continue;
         if (true == baseMethods.Contains(m.Name)) continue;

         if (false == m.IsStatic)
         {
            // The generated code assumes Instance is a GameObject
            // and then it does Instance.GetComponent<t>();
            // so if it isn't a component type we'll get compile errors
            // this v1 fix is to not reflect nodes which don't have a compatible type
            if (false == typeof(UnityEngine.Component).IsAssignableFrom(type) &&
                false == typeof(MonoBehaviour).IsAssignableFrom(type))
               continue;
         }

         ParameterInfo[] parameterInfos = m.GetParameters();

         EntityMethod entityMethod = new EntityMethod(type.ToString(), m.Name, FindFriendlyName(m.Name, m.GetCustomAttributes(false)));
         List<Parameter> parameters = new List<Parameter>();

         foreach (ParameterInfo p in parameterInfos)
         {
            Parameter parameter = new Parameter();
            parameter.State = FindSocketState(p.GetCustomAttributes(false));
            parameter.Name = p.Name;
            parameter.Type = p.ParameterType.ToString().Replace("&", string.Empty);
            parameter.AutoLinkType = FindAutoLinkType(parameter.Type, p.GetCustomAttributes(false));
            parameter.FriendlyName = FindFriendlyName(p.Name, p.GetCustomAttributes(false));

            if (true == p.IsOut)
            {
               parameter.Input = false;
               parameter.Output = true;
            }
            else if (p.ParameterType.IsByRef)
            {
               parameter.Input = true;
               parameter.Output = true;
            }
            else
            {
               parameter.Input = true;
               parameter.Output = false;
            }

            parameter.DefaultAsObject = FindDefaultValue(string.Empty, p.GetCustomAttributes(false));

            AddAssetPathField(type.ToString(), p.Name, p.GetCustomAttributes(false));
            AddParameterDescField(type.ToString(), p.Name, p.GetCustomAttributes(false));
            AddRequiresLink(type.ToString(), p.Name, p.GetCustomAttributes(false));
            uScript.Instance.AddType(p.ParameterType);

            parameters.Add(parameter);
         }

         if (m.ReturnType != typeof(void))
         {
            Parameter parameter = new Parameter();
            parameter.State = FindSocketState(m.GetCustomAttributes(false));
            parameter.Name = "Return";
            parameter.Type = m.ReturnType.ToString().Replace("&", string.Empty);
            parameter.AutoLinkType = FindAutoLinkType(parameter.Type, m.GetCustomAttributes(false));
            parameter.Input = false;
            parameter.Output = true;
            parameter.Default = string.Empty;
            parameter.FriendlyName = "Return Value";

            uScript.Instance.AddType(m.ReturnType);

            parameters.Add(parameter);
         }

         entityMethod.IsStatic = m.IsStatic;
         entityMethod.Parameters = parameters.ToArray();
         entityMethods.Add(entityMethod);
      }

      entityDesc.Methods = entityMethods.ToArray();

      List<EntityEvent> entityEvents = new List<EntityEvent>();

      foreach (EventInfo e in eventInfos)
      {
         if (true == baseEvents.Contains(e.Name)) continue;

         List<Parameter> eventOutputs = new List<Parameter>();

         Plug[] outputPlug = new Plug[1];

         outputPlug[0].Name = e.Name;
         outputPlug[0].FriendlyName = FindFriendlyName(e.Name, e.GetCustomAttributes(false));

         EntityEvent entityEvent = new EntityEvent(type.ToString(), FindFriendlyName(type.ToString(), type.GetCustomAttributes(false)), outputPlug);

         entityEvent.IsStatic = e.GetAddMethod().IsStatic;

         ParameterInfo[] eventParameters = e.GetAddMethod().GetParameters();

         foreach (ParameterInfo eventParameter in eventParameters)
         {
            MethodInfo[] eventHandlerMethods = eventParameter.ParameterType.GetMethods();

            foreach (MethodInfo eventHandlerMethod in eventHandlerMethods)
            {
               if (eventHandlerMethod.Name == "Invoke")
               {
                  ParameterInfo[] methodParameters = eventHandlerMethod.GetParameters();

                  foreach (ParameterInfo methodParameter in methodParameters)
                  {
                     if (typeof(EventArgs).IsAssignableFrom(methodParameter.ParameterType))
                     {
                        entityEvent.EventArgs = methodParameter.ParameterType.ToString().Replace("+", ".");

                        PropertyInfo[] eventProperties = methodParameter.ParameterType.GetProperties();

                        foreach (PropertyInfo eventProperty in eventProperties)
                        {
                           Parameter output = new Parameter();
                           output.State = FindSocketState(eventProperty.GetCustomAttributes(false)); ;
                           output.Name = eventProperty.Name;
                           output.FriendlyName = FindFriendlyName(eventProperty.Name, eventProperty.GetCustomAttributes(false));
                           output.Type = eventProperty.PropertyType.ToString().Replace("&", string.Empty);
                           output.AutoLinkType = FindAutoLinkType(output.Type, eventProperty.GetCustomAttributes(false));
                           output.Input = false;
                           output.Output = true;
                           output.DefaultAsObject = FindDefaultValue(string.Empty, eventProperty.GetCustomAttributes(false));

                           uScript.Instance.AddType(eventProperty.PropertyType);

                           eventOutputs.Add(output);

                           AddParameterDescField(type.ToString(), eventProperty.Name, eventProperty.GetCustomAttributes(false));
                        }
                     }
                  }

                  //break after Invoke parameter, it's the only one we care about
                  break;
               }
            }
         }

         entityEvent.Parameters = eventOutputs.ToArray();
         entityEvents.Add(entityEvent);
      }

      entityDesc.Events = entityEvents.ToArray();

      List<EntityProperty> entityProperties = new List<EntityProperty>();

#if !(DETOX_STORE_BASIC || UNITY_STORE_BASIC)
      foreach (PropertyInfo p in propertyInfos)
      {
         bool isInput = p.GetSetMethod() != null;
         bool isOutput = p.GetGetMethod() != null;

         EntityProperty property = new EntityProperty(p.Name, FindFriendlyName(p.Name, p.GetCustomAttributes(false)), type.ToString(), p.PropertyType.ToString(), isInput, isOutput);

         if (true == isInput)
         {
            property.IsStatic = p.GetSetMethod().IsStatic;
         }
         else if (true == isOutput)
         {
            property.IsStatic = p.GetGetMethod().IsStatic;
         }

         entityProperties.Add(property);

         uScript.Instance.AddType(p.PropertyType);
      }

      foreach (FieldInfo f in fieldInfos)
      {
         if (false == f.IsPublic) continue;

         EntityProperty property = new EntityProperty(f.Name, FindFriendlyName(f.Name, f.GetCustomAttributes(false)), type.ToString(), f.FieldType.ToString(), true, true);
         property.IsStatic = f.IsStatic;
         entityProperties.Add(property);

         uScript.Instance.AddType(f.FieldType);
      }
#endif
      entityDesc.Properties = entityProperties.ToArray();

      entityDescs.Add(entityDesc);
   }

   private static int TypeSorter(Type t1, Type t2)
   {
      return String.Compare(uScriptConfig.Variable.FriendlyName(t1.ToString()), uScriptConfig.Variable.FriendlyName(t2.ToString()));
   }

   private EntityDesc[] PopulateEntityTypes(string[] requiredTypes)
   {
      if (this.m_EntityTypes != null)
      {
         if (null != requiredTypes)
         {
            foreach (string t in requiredTypes)
            {
               if (this.m_EntityTypeHash.Contains(t) == false)
               {
                  m_EntityTypes = null;
                  m_SzEntityTypes = null;
                  break;
               }
            }
         }

         if (this.m_EntityTypes != null)
         {
            return m_EntityTypes;
         }
      }

      uScriptDebug.Log("Rebuilding Entity Types", uScriptDebug.Type.Debug);

      Hashtable baseMethods = new Hashtable();
      Hashtable baseEvents = new Hashtable();
      Hashtable baseProperties = new Hashtable();

      List<EntityDesc> entityDescs = new List<EntityDesc>();

#if !(DETOX_STORE_BASIC || UNITY_STORE_BASIC)
      foreach (MethodInfo m in typeof(UnityEngine.Behaviour).GetMethods(BindingFlags.DeclaredOnly))
      {
         baseMethods[m.Name] = m.Name;
      }

      foreach (EventInfo e in typeof(UnityEngine.Behaviour).GetEvents(BindingFlags.DeclaredOnly))
      {
         baseEvents[e.Name] = e.Name;
      }

      foreach (PropertyInfo p in typeof(UnityEngine.Behaviour).GetProperties(BindingFlags.DeclaredOnly))
      {
         baseProperties[p.Name] = p.Name;
      }

      foreach (MethodInfo m in typeof(UnityEngine.MonoBehaviour).GetMethods(BindingFlags.DeclaredOnly))
      {
         baseMethods[m.Name] = m.Name;
      }

      foreach (EventInfo e in typeof(UnityEngine.MonoBehaviour).GetEvents(BindingFlags.DeclaredOnly))
      {
         baseEvents[e.Name] = e.Name;
      }

      foreach (PropertyInfo p in typeof(UnityEngine.MonoBehaviour).GetProperties(BindingFlags.DeclaredOnly))
      {
         baseProperties[p.Name] = p.Name;
      }

      foreach (MethodInfo m in typeof(UnityEngine.Object).GetMethods(BindingFlags.DeclaredOnly))
      {
         baseMethods[m.Name] = m.Name;
      }

      foreach (EventInfo e in typeof(UnityEngine.Object).GetEvents(BindingFlags.DeclaredOnly))
      {
         baseEvents[e.Name] = e.Name;
      }

      foreach (PropertyInfo p in typeof(UnityEngine.Object).GetProperties(BindingFlags.DeclaredOnly))
      {
         baseProperties[p.Name] = p.Name;
      }
#endif

      if (this.m_SzEntityTypes == null)
      {
         uScriptDebug.Log("Reparsing Entity Types", uScriptDebug.Type.Debug);

#if !(DETOX_STORE_BASIC || UNITY_STORE_BASIC)
         List<UnityEngine.Object> allObjects = new List<UnityEngine.Object>(FindObjectsOfType(typeof(UnityEngine.Object)));
#endif
         Dictionary<string, Type> uniqueObjects = new Dictionary<string, Type>();

         Dictionary<Type, Type> eventNodes = new Dictionary<Type, Type>();
         GatherDerivedTypes(eventNodes, uScriptConfig.ConstantPaths.RuntimeNodes, typeof(uScriptEvent));
         GatherDerivedTypes(eventNodes, Preferences.UserNodes, typeof(uScriptEvent));

#if !(DETOX_STORE_BASIC || UNITY_STORE_BASIC)
         foreach (UnityEngine.Object o in allObjects)
         {
            //don't ignore uScriptCode because we want to reflect
            //any public inspector properties

            //ignore our logic scripts, they are handled separately
            if (typeof(uScriptLogic).IsAssignableFrom(o.GetType())) continue;
            if (typeof(uScript_UndoObject).IsAssignableFrom(o.GetType())) continue;

            uniqueObjects[o.GetType().ToString()] = o.GetType();
         }
#endif

         foreach (Type t in eventNodes.Values)
         {
            uniqueObjects[t.ToString()] = t;
         }

#if !(DETOX_STORE_BASIC || UNITY_STORE_BASIC)
         string[] userTypes = UserTypes;

         foreach (string s in userTypes)
         {
            string szType = s.Trim();
            if (string.Empty == szType) continue;

            Type t = uScript.Instance.GetType(szType);

            if (null != t)
            {
               if (true == typeof(uScriptLogic).IsAssignableFrom(t))
               {
                  uScriptDebug.Log("uScriptLogic node " + szType + " should not be added to uScriptUserTypes, these are automatically parsed by uScript", uScriptDebug.Type.Warning);
               }
               else
               {
                  uniqueObjects[t.ToString()] = t;
               }
            }
            else
            {
               uScriptDebug.Log("Cannot Find uScriptUserType: " + s, uScriptDebug.Type.Warning);
            }
         }

         // Don't reflect all unity types, many won't work with our reflection because
         // our reflection is assuming if they need an Instance it's a GameObject, and that isn't always the case
         string unityTypes = "UnityEngine.Component";

         //"UnityEngine.Object,UnityEngine.AnimationClip,UnityEngine.AssetBundle,UnityEngine.AudioClip,UnityEngine.Component,UnityEngine.Behaviour," +
         //"UnityEngine.Animation,UnityEngine.AudioChorusFilter,UnityEngine.AudioDistortionFilter,UnityEngine.AudioEchoFilter,UnityEngine.AudioHighPassFilter," +
         //"UnityEngine.AudioHighPassFilter,UnityEngine.AudioListener,UnityEngine.AudioLowPassFilter,UnityEngine.AudioReverbFilter,UnityEngine.AudioReverbZone," +
         //"UnityEngine.AudioSource,UnityEngine.Camera,UnityEngine.ConstantForce,UnityEngine.GUIElement,UnityEngine.GUIText,UnityEngine.GUITexture,UnityEngine.GUILayer,UnityEngine.LensFlare,UnityEngine.Light," +
         //"UnityEngine.MonoBehaviour,UnityEngine.Terrain,UnityEngine.NavMeshAgent,UnityEngine.NetworkView,UnityEngine.Projector,UnityEngine.Skybox,UnityEngine.Cloth,UnityEngine.InteractiveCloth,UnityEngine.SkinnedCloth," +
         //"UnityEngine.Collider,UnityEngine.BoxCollider,UnityEngine.CapsuleCollider,UnityEngine.CharacterController,UnityEngine.MeshCollider,UnityEngine.SphereCollider,UnityEngine.TerrainCollider," +
         //"UnityEngine.WheelCollider,UnityEngine.Joint,UnityEngine.CharacterJoint,UnityEngine.ConfigurableJoint,UnityEngine.FixedJoint,UnityEngine.HingeJoint,UnityEngine.SpringJoint,UnityEngine.LODGroup," +
         //"UnityEngine.LightProbeGroup,UnityEngine.MeshFilter,UnityEngine.OcclusionArea,UnityEngine.OcclusionPortal,UnityEngine.OffMeshLink,UnityEngine.ParticleAnimator,UnityEngine.ParticleEmitter," +
         //"UnityEngine.ParticleSystem,UnityEngine.Renderer,UnityEngine.ClothRenderer,UnityEngine.LineRenderer,UnityEngine.MeshRenderer,UnityEngine.ParticleRenderer,UnityEngine.ParticleSystemRenderer," +
         //"UnityEngine.SkinnedMeshRenderer,UnityEngine.TrailRenderer,UnityEngine.Rigidbody,UnityEngine.TextMesh,UnityEngine.Transform,UnityEngine.Tree,UnityEngine.Flare,UnityEngine.Font,UnityEngine.GameObject," +
         //"UnityEngine.LightProbes,UnityEngine.Material,UnityEngine.ProceduralMaterial,UnityEngine.Mesh,UnityEngine.NavMesh,UnityEngine.PhysicMaterial,UnityEngine.QualitySettings,UnityEngine.ScriptableObject," +
         //"UnityEngine.GUISkin,UnityEngine.Shader,UnityEngine.TerrainData,UnityEngine.TextAsset,UnityEngine.Texture,UnityEngine.Cubemap,UnityEngine.MovieTexture,UnityEngine.RenderTexture,UnityEngine.Texture2D,UnityEngine.WebCamTexture," +
         //"UnityEngine.RuntimePlatform";

         string[] unityTypeArray = unityTypes.Split(',');

         foreach (string s in unityTypeArray)
         {
            string szType = s.Trim();
            if (string.Empty == szType) continue;

            Type t = uScript.Instance.GetType(szType);
            if (null != t) uniqueObjects[t.ToString()] = t;
         }

         if (null != requiredTypes)
         {
            foreach (string t in requiredTypes)
            {
               if (true == uniqueObjects.ContainsKey(t)) continue;

               Type type = uScript.Instance.GetType(t);

               if (null != type)
               {
                  //ignore any required logic types because those
                  //get populated in PopulateLogicNodes and are not
                  //entity types
                  if (typeof(uScriptLogic).IsAssignableFrom(type)) continue;

                  if (typeof(UnityEngine.Object).IsAssignableFrom(type))
                  {
                     uniqueObjects[t] = type;
                  }
               }
            }
         }

         uniqueObjects[typeof(Math).ToString()] = typeof(Math);
         uniqueObjects[typeof(UnityEngine.Mathf).ToString()] = typeof(UnityEngine.Mathf);
#endif

         m_SzEntityTypes = new string[uniqueObjects.Values.Count];

         int i = 0;

         foreach (Type t in uniqueObjects.Values)
         {
            m_SzEntityTypes[i++] = t.ToString();
         }
      }

      List<Type> types = new List<Type>();

      foreach (string s in m_SzEntityTypes)
      {
         Type t = uScript.Instance.GetType(s);
         if (null != t) types.Add(t);
      }

      types.Sort(TypeSorter);

      foreach (Type t in types)
      {
         if (t == typeof(uScript_MasterComponent)) continue;

         Reflect(t, entityDescs, baseMethods, baseEvents, baseProperties);
      }

      //consolidate like events so they appear on the same node
      EntityDesc[] descs = entityDescs.ToArray();
      for (int i = 0; i < descs.Length; i++)
      {
         EntityDesc desc = descs[i];

         //one or less event? no need to consolidate
         if (desc.Events.Length <= 1) continue;

         Parameter[] parameters = desc.Events[0].Parameters;

         int c;

         for (c = 1; c < desc.Events.Length; c++)
         {
            if (desc.Events[0].IsStatic != desc.Events[c].IsStatic)
            {
               break;
            }

            if (false == ArrayUtil.ArraysAreEqual(parameters, desc.Events[c].Parameters))
            {
               break;
            }
         }

         //all parameters were matching because
         //we never had to break the for loop early
         if (c == desc.Events.Length)
         {
            EntityEvent entityEvent = EntityEvent.Consolidator(desc.Events);
            desc.Events = new EntityEvent[] { entityEvent };

            descs[i] = desc;
         }
      }

      m_EntityTypes = descs;

      m_EntityTypeHash = new Hashtable();

      foreach (EntityDesc d in m_EntityTypes)
      {
         m_EntityTypeHash[d.Type] = true;
      }

      return m_EntityTypes;
   }

   public string AutoAssignInstance(EntityNode entityNode)
   {
      string type = ScriptEditor.FindNodeType(entityNode);
      if (type == string.Empty)
      {
         return string.Empty;
      }

      if (FindNodeAutoAssignMasterInstance(type))
      {
         return uScriptRuntimeConfig.MasterObjectName;
      }

      return string.Empty;
   }

   private void CheckDragDropCanvas()
   {
      foreach (object o in DragAndDrop.objectReferences)
      {
         if (false == (o is UnityEngine.Object)) continue;

         if ((m_ScriptEditorCtrl.CanDragDropOnNode(o) && DragAndDrop.objectReferences.Length == 1) || m_ScriptEditorCtrl.CanDragDropContextMenu(o))
         {
            DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
         }
      }

      if (Event.current.type == EventType.DragPerform)
      {
         // if all objects in the drag are droppable via context menu
         // create a new game object variable for each one
         bool canDropAll = true;
         foreach (object o in DragAndDrop.objectReferences)
         {
            if (!m_ScriptEditorCtrl.CanDragDropOnNode(o) && m_ScriptEditorCtrl.CanDragDropContextMenu(o))
            {
               continue;
            }

            canDropAll = false;
            break;
         }

         if (canDropAll)
         {
            if (m_ScriptEditorCtrl.DoDragDropContextMenu(DragAndDrop.objectReferences))
            {
               m_ContextX = (int)Event.current.mousePosition.x;
               m_ContextY = (int)(Event.current.mousePosition.y - _canvasRect.yMin);

               DragAndDrop.AcceptDrag();
            }
         }
         else
         {
            foreach (object o in DragAndDrop.objectReferences)
            {
               if (true == m_ScriptEditorCtrl.DoDragDrop(o))
               {
                  DragAndDrop.AcceptDrag();
               }
            }
         }
      }
   }

   public static object FindDefaultValue(string defaultValue, object[] attributes)
   {
      if (null == attributes) return defaultValue;

      foreach (object a in attributes)
      {
         if (a is DefaultValue)
         {
            return ((DefaultValue)a).Default;
         }
      }

      return defaultValue;
   }

   public static AssetType GetAssetPathField(EntityNode node, string parameterName)
   {
      string type = ScriptEditor.FindNodeType(node);
      string key = type + "_" + parameterName;

      if (NodeParameterFields.Contains(key))
      {
         return (AssetType)NodeParameterFields[key];
      }

      return AssetType.Invalid;
   }

   public static string GetParameterDescField(string type, string parameterName)
   {
      string key = type + "_" + parameterName;

      if (NodeParameterDescFields.Contains(key))
      {
         return (string)NodeParameterDescFields[key];
      }

      return string.Empty;
   }

   public static bool GetRequiresLink(EntityNode node, string parameterName)
   {
      string type = ScriptEditor.FindNodeType(node);
      string key = type + "_" + parameterName;

      return RequiresLink.Contains(key);
   }

   public static void AddAssetPathField(string type, string parameterName, object[] attributes)
   {
      foreach (object a in attributes)
      {
         if (a is AssetPathField)
         {
            AssetPathField field = (AssetPathField)a;
            string key = type + "_" + parameterName;

            NodeParameterFields[key] = field.AssetType;
            break;
         }
      }
   }

   public static void AddParameterDescField(string type, string parameterName, object[] attributes)
   {
      foreach (object a in attributes)
      {
         if (a is FriendlyNameAttribute)
         {
            FriendlyNameAttribute field = (FriendlyNameAttribute)a;
            string key = type + "_" + parameterName;

            NodeParameterDescFields[key] = field.Desc;
            break;
         }
      }
   }

   public static void AddRequiresLink(string type, string parameterName, object[] attributes)
   {
      foreach (object a in attributes)
      {
         if (a is RequiresLink)
         {
            string key = type + "_" + parameterName;
            RequiresLink[key] = true;
            break;
         }
      }
   }

   public static Parameter.VisibleState FindSocketState(object[] attributes)
   {
      if (null != attributes)
      {
         foreach (object a in attributes)
         {
            if (a is SocketStateAttribute)
            {
               SocketStateAttribute s = (SocketStateAttribute)a;

               Parameter.VisibleState state = Parameter.VisibleState.Visible;

               if (false == s.Visible) state = Parameter.VisibleState.Hidden;
               if (true == s.Locked) state |= Parameter.VisibleState.Locked;

               return state;
            }
         }
      }

      return Parameter.VisibleState.Visible; ;
   }

   public static string FindAutoLinkType(string type, object[] attributes)
   {
      if (null != attributes)
      {
         foreach (object a in attributes)
         {
            if (a is AutoLinkType)
            {
               AutoLinkType c = (AutoLinkType) a;
               return c.LinkType.ToString().Replace("&", string.Empty);
            }
         }
      }

      return type;
   }

   public static bool FindDrivenAttribute(object[] attributes)
   {
      if (null == attributes) return false;

      foreach (object a in attributes)
      {
         if (a is Driven) return true;
      }

      return false;
   }

   public static string FindFriendlyName(EntityNode node)
   {
      string type = ScriptEditor.FindNodeType(node);
      Type uscriptType = uScript.Instance.GetType(type);

      if (null != uscriptType)
      {
         return FindFriendlyName(type, uscriptType.GetCustomAttributes(false));
      }

      return string.Empty;
   }

   public static string FindFriendlyName(string defaultName, object[] attributes)
   {
      if (null == attributes) return defaultName;

      foreach (object a in attributes)
      {
         if (a is FriendlyNameAttribute)
         {
            return ((FriendlyNameAttribute)a).Name;
         }
      }

      return defaultName;
   }

   public static bool NodeNeedsGuiLayout(string type)
   {
      Type uscriptType = uScript.Instance.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return false;

         foreach (object a in attributes)
         {
            if (a is NodeNeedsGuiLayout)
            {
               return ((NodeNeedsGuiLayout)a).Value;
            }
         }
      }

      return false;
   }

   public static string FindParameterDescription(string type, Parameter p)
   {
      // Check non-logic, non-event types first
      //
      // Structures can't have attributes and some parameters are manually added to some nodes. To
      // support descriptions on these parameters, we have to specify this information explicitly.

      if (string.IsNullOrEmpty(type))
      {
         switch (p.FriendlyName)
         {
            case "Comment": return "The comment text to show above this node in uScript's canvas.";
            case "Output Comment": return "If True, the comment text will be sent to Unity's console window when the node fires.";
            case "Instance": return "The GameObject instance associated with this node. This tells uScript which specific GameObject to use that contains this specified event, property, script, trigger, collider, etc.";
            case "Friendly Name": return "Use this graph property to give this graph a name that will be used when shown as a nested node in other uScript graphs.";
            case "Description": return "Use this graph property to give this graph description help text when selected as a nested node in other uScript graphs (shown here in the Reference panel).";
            default: return p.FriendlyName;
         }
      }

      if (type == "CommentNode")
      {
         switch (p.FriendlyName)
         {
            case "Title": return "The title or header for this comment box.";
            case "Body": return "The actual comment text and information. Empty lines are supported.";
            case "Width": return "The width of the comment box (in pixels).";
            case "Height": return "The height of the comment box (in pixels).";
            case "Node Color": return "The comment box color.";
            case "Body Text Color": return "The color of the body text.";
            case "Title Color": return "The color of the title text.";    // Not used?
            default: return p.FriendlyName;
         }
      }

      switch (type)
      {
         case "LocalNode":
            switch (p.FriendlyName)
            {
               case "Name": return "The variable name (optional). Variables that share the same name are automatically linked together and treated as the same variable in your graph. Once linked, changing the value of one will affect all others in the graph. Variables with the same name in different graphs are NOT connected in any way. Use the \"Make Public\" option below in order to access this variable as a reflected property between graphs.";
               case "Value":
                  var searchInstructions = string.Empty;
                  var valueType = Instance.GetType(p.Type);
                  if (valueType == typeof(GameObject) || typeof(Component).IsAssignableFrom(valueType))
                  {
                     searchInstructions =
                        "\n\nEnter text to search for an object in the scene hierarchy. For faster and more accurate results at runtime, specify the complete hierarchy path.";
                  }

                  return string.Format("The value of the variable. Only values supported by this variable type are allowed.{0}", searchInstructions);
               case "Make Public": return "When checked, this will allow you to access this variable from other uScript graphs as a reflected property. You must name this variable before you can use this option (see the Name field above). This is the equivalent of making a variable \"public\" in a script.";
               case "Hide In Inspector": return "When checked, this will hide this variable from Unity so that it will not show up in the Inspector panel for this graph's component. You must name this variable and make it public using the \"Make Public\" checkbox above before you can use this option (see the Name field above). This is the equivalent of using the [HideInInspector] attribute above a variable in a script.";
            }

            break;

         case "ExternalConnection":
            switch (p.FriendlyName)
            {
               case "Name": return "The connection name. This name will be displayed in other graphs for this socket.";
               case "Order": return "The order that the sockets will appear on the nested node in other graphs (from left to right for variable sockets and top to bottom for input/output sockets). Lower numbers have higher priority and will draw first.";
               case "Description": return "The help text for each socket you wish to show up in the uScript Reference panel when users select this nested node in another graph.";
            }

            break;

         case "OwnerConnection":
            if (p.FriendlyName == "Connection")
            {
               return "The GameObject this uScript graph is attached to. Also commonly known as \"this\" in scripting.";
            }

            break;

         case "_reflectedAction":
            break;

         case "_reflectedProperty":
            return "This is the reflected object property that will be referenced and/or modified.";
      }

      return GetParameterDescField(type, p.Name);

      // Any remaining parameters are likely be be reflected.
      //
      // If the parameter is on a Property node
      //    -- can we even identify properties by looking at the parameter or passed type??
   }

   /// <summary>
   /// Gets the InstanceID of the project asset located at the specified path.
   /// </summary>
   /// <param name="assetPathRelativeToProject">The asset path relative to the project folder, such as "Assets/MyTextures/hello.jpg".</param>
   /// <param name="type">The asset type.</param>
   /// <returns>The InstanceID assigned by Unity.</returns>
   public static int GetAssetInstanceID(string assetPathRelativeToProject, Type type)
   {
      var obj = AssetDatabase.LoadAssetAtPath(assetPathRelativeToProject, type);
      return obj == null ? -1 : obj.GetInstanceID();
   }
   
   public static Type GetAssemblyQualifiedType(String typeName)
   {
      if (null == typeName) return null;

      // try the basic version first
      if (Type.GetType(typeName) != null) return Type.GetType(typeName);

      // not found, look through all the assemblies
      foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
         if (Type.GetType(typeName + ", " + assembly.ToString()) != null) return Type.GetType(typeName + ", " + assembly.ToString());
      }

      return null;
   }

   // This method can be expensive, so call it sparingly
   public static string GetRelativePathToNodeSource(string nodeType)
   {
      if (string.IsNullOrEmpty(nodeType))
      {
         return string.Empty;
      }

      const StringComparison IgnoreCase = StringComparison.OrdinalIgnoreCase;

      var path = Application.dataPath;
      var searchPattern = string.Format("{0}.*", nodeType);

      var files =
         Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories)
            .Where(
               s => s.EndsWith(".cs", IgnoreCase) || s.EndsWith(".js", IgnoreCase) || s.EndsWith(".boo", IgnoreCase))
            .ToList();

      uScriptDebug.Assert(files.Count <= 1, string.Format("Multiple files where found matching \"{0}\".", searchPattern));

      var file = files.FirstOrDefault() ?? string.Empty;
      return file.RelativeAssetPath();
   }
}

public class ComplexData
{
}
