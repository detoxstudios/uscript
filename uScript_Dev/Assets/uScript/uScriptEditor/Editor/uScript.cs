#define DEVELOPMENT_BUILD // Allows us to wrap features in progress. Used along with other BUILD settings.

#define UNITY_STORE_BUILD //Don't forget LicenseWindow.cs
//#define DETOX_STORE_BUILD //Don't forget LicenseWindow.cs
//#define FREE_PLE_BUILD // Don't forget uScript_MasterComponent.cs and LicenseWindow.cs
//#define FREE_BETA_BUILD

using UnityEngine;
using UnityEditor;
using Detox.ScriptEditor;
using Detox.Data.Tools;
using Detox.Windows.Forms;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Detox.Drawing;
using Detox.FlowChart;

using System.IO;
using System.Collections.ObjectModel;

public class ComplexData
{
}


public class uScript : EditorWindow
{
   //so we know if the current script we've cached
   //is dirty or has been saved to a file
   public bool   CurrentScriptDirty= false;
   public string CurrentScript     = null;
   public string CurrentScriptName = "";
   public string []m_Patches       = new string[ 0 ];

   private bool m_Launched;

   //complex class which Unity will not serialize
   //so if it goes null I know the app domain has been rebuilt
   private ComplexData m_ComplexData = null;

   // ###############################################################
   // # Version Name and Version Data
   // #

   // Set version - format is MAJOR.MINOR.FOURDIGITSVNCOMMITNUMBER
   static public string BuildNumber { get { return "0.9.2123"; } }

   static public string BuildName { get { return "Professional (Retail Beta 32)"; } }
   static public string BuildNamePLE { get { return "Personal Learning Edition (Retail Beta 32)"; } }

#if FREE_PLE_BUILD
   static public string ProductName { get { return BuildNamePLE; } }
   static public string ProductType { get { return "uScript_PLE"; } }
#elif UNITY_STORE_BUILD
   static public string ProductName { get { return BuildName; } }
   static public string ProductType { get { return "uScript_AssetStore"; } }
#else
   static public string ProductName { get { return BuildName; } }
   static public string ProductType { get { return "uScript_Retail"; } }
#endif

   static public string FullVersionName { get { return ProductName + " (" + BuildNumber + ")"; } }
   //public string LastUnityBuild { get { return "3.3"; } }
   //public string CurrentUnityBuild { get { return "3.4"; } }
   //public string BetaUnityBuild { get { return "3.5"; } }
   //public DateTime ExpireDate { get { return new DateTime(2011, 11, 30); } }
   // #
   // ###############################################################


   public bool isLicenseAccepted = false;

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
   private MouseRegion _mouseRegion = MouseRegion.Outside;
   private MouseRegion _mouseRegionUpdate = MouseRegion.Outside;
   private MouseRegion m_MouseDownRegion = MouseRegion.Outside;
   public MouseRegion MouseDownRegion {
      get { return m_MouseDownRegion; }
      set { m_MouseDownRegion = value; }
   }

   public Dictionary<MouseRegion, Rect> _mouseRegionRect = new Dictionary<MouseRegion, Rect>();

   static private uScript s_Instance = null;
   static public uScript Instance { get { if (null == s_Instance) Init(); return s_Instance; } }
   bool _firstRun = true;

   private ScriptEditorCtrl m_ScriptEditorCtrl = null;
   private bool m_MouseDown = false;
   private bool m_MouseDownOverCanvas = false;
   private bool m_WantsCopy = false;
   private bool m_WantsCut = false;
   private bool m_WantsPaste = false;

   private bool m_RebuildWhenReady = false;

   public float m_MapScale = 1.0f;
   private Point m_ZoomPoint = new Point( 0, 0 );

   private String m_AddVariableNode = "";
   private KeyCode m_PressedKey = KeyCode.None;

   private string m_FullPath = "";
   private string m_CurrentCanvasPosition = "";
   private bool m_ForceCodeValidation = false;

   private Detox.FlowChart.Node m_FocusedNode = null;

   private Hashtable    m_EntityTypeHash = null;
   private EntityDesc []m_EntityTypes = null;
   private LogicNode  []m_LogicTypes  = null;
   private string     []m_SzLogicTypes = null;
   private string     []m_SzEntityTypes = null;

   private static Hashtable m_NodeParameterFields = new Hashtable( );
   private static Hashtable m_NodeParameterDescFields = new Hashtable( );
   private static Hashtable m_RequiresLink = new Hashtable( );  
   private static AppFrameworkData m_AppData = new AppFrameworkData();
   public static  Preferences Preferences = new Preferences();

   private Node _nodeClicked = null;
   public Node NodeClicked { get { return _nodeClicked; } set { _nodeClicked = value; } }

   // This allows you to set the ifdef here but use this info in other clases by calling - uScript.IsDevelopmentBuild
#if DEVELOPMENT_BUILD
    private static bool _isDevelopmentBuild = true;
#else
   private static bool _isDevelopmentBuild = false;
#endif
   public static bool IsDevelopmentBuild { get { return _isDevelopmentBuild; } }


   //   private double m_RefreshTimestamp = -1.0;

   // Used for double-click hack in uScripts panel
   private double clickTime;
   //   private double doubleClickTime = 0.3;

   bool _wasHierarchyChanged = false;

   private bool m_CanvasDragging = false;
   public bool wasCanvasDragged = false;

   public bool  GenerateDebugInfo = true;

   bool _isContextMenuOpen = false;
   public bool isContextMenuOpen
   {
      get { return _isContextMenuOpen; }
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
//               Event.current.Use();
            }
         }
      }
   }

   private int m_UndoNumber = 0;
   public string [] m_UndoPatches = new string[ 0 ];

   private int m_ContextX = 0;
   private int m_ContextY = 0;
   private ToolStripItem m_CurrentMenu = null;

   Rect m_NodeWindowRect;
   public Rect NodeWindowRect { get { return m_NodeWindowRect; } }

   Rect m_NodeToolbarRect;
   public Rect NodeToolbarRect { get { return m_NodeToolbarRect; } }

   public Rect _canvasRect;
   Vector2 _guiPanelPalette_ScrollPos;

   public Vector2 _guiContentScrollPos;

   Vector2 _guiPanelProperties_ScrollPos;

   Vector2 _guiHelpScrollPos;


   Rect rectContextMenuWindow = new Rect(10, 10, 10, 10);

   Rect rectFileMenuButton = new Rect();
   Rect rectFileMenuWindow = new Rect(20, 20, 10, 10);


   /* Palette Variables */
   String _graphListFilterText = string.Empty;


   //
   // Sub-Sequence variables
   //
   Vector2 _guiPanelSequence_ScrollPos;

   //
   // Statusbar Variables
   //
   string _statusbarMessage;

   //IMPORTANT - THIS CANNOT BE CACHED
   //BECAUSE WE END UP WITH STALE VERSIONS
   public static GameObject MasterObject
   {
      get
      {
         return uScript_MasterComponent.LatestMaster;
         //return GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
      }
   }

   //IMPORTANT - THIS CANNOT BE CACHED
   //BECAUSE WE END UP WITH STALE VERSIONS AS THE UNITY UNDO STACK IS MODIFIED
   public static uScript_UndoComponent UndoComponent
   {
      get
      {
         GameObject uScriptMaster = MasterObject;//GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
         if (null == uScriptMaster)
         {
            uScriptDebug.Log("Adding default uScript master gameobject: " + uScriptRuntimeConfig.MasterObjectName, uScriptDebug.Type.Debug);

            uScriptMaster = new GameObject(uScriptRuntimeConfig.MasterObjectName);
            uScriptMaster.transform.position = new Vector3(0f, 0f, 0f);
         }
         if (null == uScriptMaster.GetComponent<uScript_UndoComponent>())
         {
            uScriptDebug.Log("Adding Undo Object to master gameobject (" + uScriptRuntimeConfig.MasterObjectName + ")", uScriptDebug.Type.Debug);
            uScriptMaster.AddComponent(typeof(uScript_UndoComponent));
         }
         return uScriptMaster.GetComponent<uScript_UndoComponent>();
      }
   }

   //IMPORTANT - THIS CANNOT BE CACHED
   //BECAUSE WE END UP WITH STALE VERSIONS
   public static uScript_MasterComponent MasterComponent
   {
      get
      {
         GameObject uScriptMaster = MasterObject;//GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
         if (null == uScriptMaster)
         {
            uScriptDebug.Log("Adding default uScript master gameobject: " + uScriptRuntimeConfig.MasterObjectName, uScriptDebug.Type.Debug);

            uScriptMaster = new GameObject(uScriptRuntimeConfig.MasterObjectName);
            uScriptMaster.transform.position = new Vector3(0f, 0f, 0f);
         }
         if (null == uScriptMaster.GetComponent<uScript_MasterComponent>())
         {
            uScriptDebug.Log("Adding Master Object to master gameobject (" + uScriptRuntimeConfig.MasterObjectName + ")", uScriptDebug.Type.Debug);
            uScriptMaster.AddComponent(typeof(uScript_MasterComponent));
         }
         return uScriptMaster.GetComponent<uScript_MasterComponent>();
      }
   }

   private static float m_UnityVersion = 0.0f;
 
   public static float UnityVersion
   {
      get
      {
         if ( 0.0f == m_UnityVersion )
         {
            Type t = uScript.MasterComponent.GetType("uScriptUnityVersion");
            if ( null != t ) 
            {
               uScriptIUnityVersion v = Activator.CreateInstance( t ) as uScriptIUnityVersion; 
               if ( null != v ) m_UnityVersion = v.Version;
            }

            if ( 0.0f != m_UnityVersion )
            {
               uScriptDebug.Log("Unity Version: " + m_UnityVersion, uScriptDebug.Type.Debug );
            }
            else
            {
               uScriptDebug.Log( "Unable to get Unity Version", uScriptDebug.Type.Debug );
            }
         }

         return m_UnityVersion;
      }
   }

   public static string []UserTypes
   {
      get
      {
         Type t = uScript.MasterComponent.GetType("uScriptUserTypes");
         if ( null != t ) 
         {
            FieldInfo p = t.GetField( "Types" );
            if ( null != p )
            {
               object instance = Activator.CreateInstance( t );

               object v = p.GetValue( instance );
               if ( v is string ) return ((string)v).Split( ',' );
            }
         }

         return new string[0];
      }
   }
   
   public bool AllowKeyInput()
   {
      return (UnityVersion <= 3.5f && "MainView" == GUI.GetNameOfFocusedControl()) || GUIUtility.keyboardControl == 0;
   }
   
   public ScriptEditorCtrl ScriptEditorCtrl
   {
      get { return m_ScriptEditorCtrl; }
   }


   //
   // Content Panel Variables
   //
   MouseEventArgs m_MouseDownArgs = null;
   MouseEventArgs m_MouseUpArgs = null;
   MouseEventArgs m_MouseMoveArgs = new MouseEventArgs();

   public bool m_SelectAllNodes = false;
   public bool isPreferenceWindowOpen = false;

   public bool IsAttachedToMaster
   {
      get
      {
         if (MasterObject != null && !String.IsNullOrEmpty(m_FullPath))
         {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(m_FullPath);
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
         if (!String.IsNullOrEmpty(m_FullPath))
         {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(m_FullPath);
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


   private Dictionary<string, bool> _staleScriptCache = new Dictionary<string, bool>();

   public bool IsStale(string scriptName)
   {
      if (_staleScriptCache.ContainsKey(scriptName))
      {
         return _staleScriptCache[scriptName];
      }
      else
      {
         string path = FindFile( Preferences.UserScripts, scriptName + ".uscript" );

         if ( "" != path )
         {
            ScriptEditor s = new ScriptEditor( "", null, null );
            if ( true == s.Open(path) )
            {
               bool stale = s.GeneratedCodeIsStale;

               if ( false == stale )
               {
                  string wrapperPath = GetGeneratedScriptPath(path);
                  string logicPath   = GetNestedScriptPath(path);
               
                  if ( false == File.Exists(wrapperPath) || 
                       false == File.Exists(logicPath) )
                  {
                     stale = true;
                  }
               }

               SetStaleState( scriptName, stale );
            }
         }
         
         //if we failed to find it, mark it as always stale
         if ( false == _staleScriptCache.ContainsKey(scriptName) )
         {
            SetStaleState( scriptName, true );
         }

         return _staleScriptCache[ scriptName ];
      }
   }

   // The stale script state cache should be updated whenever a script's stale state changes, and when uScript first launches.
   //
   public void SetStaleState(string scriptName, bool isStale)
   {
      _staleScriptCache[scriptName] = isStale;
   }



   private Dictionary<string, bool> _debugScriptCache = new Dictionary<string, bool>();

   public bool HasDebugCode(string scriptName)
   {
      if (_debugScriptCache.ContainsKey(scriptName))
      {
         return _debugScriptCache[scriptName];
      }
      else
      {
         string path = FindFile( Preferences.UserScripts, scriptName + ".uscript" );

         if ( string.Empty != path )
         {
            ScriptEditor s = new ScriptEditor( "", null, null );
            if ( true == s.Open(path) )
            {
               bool debugCode = s.SavedForDebugging;

               SetDebugState( scriptName, debugCode );
            }
         }

         // if we failed to find it, mark it as note containing debug info
         if ( false == _debugScriptCache.ContainsKey(scriptName) )
         {
            SetDebugState( scriptName, false );
         }

         return _debugScriptCache[ scriptName ];
      }
 }

   // The debug script state cache should be updated whenever a script's debug state changes, and when uScript first launches.
   //
   public void SetDebugState(string scriptName, bool hasDebugCode)
   {
      _debugScriptCache[scriptName] = hasDebugCode;
   }




   //
   // Editor Window Initialization
   //
   [UnityEditor.MenuItem("Tools/Detox Studios/uScript Editor %u")]
   static void Init()
   {
      s_Instance = (uScript)EditorWindow.GetWindow(typeof(uScript), false, "uScript Editor");
      s_Instance.Launching( );

      UpdateNotification.StartupCheck();

   }
   
   // call to force release the mouse and stop a drag operation
   public void ForceReleaseMouse()
   {
      m_MouseDown = false;
   }

   private void Launching( )
   {
      if ( null != m_ComplexData ) return;

      //Debug.Log( "Launching" );

      if ( false == m_Launched )
      {
         LaunchingFromUnity( );
         m_Launched = true;
      }
      else
      {
         RelaunchingFromRebuiltAppDomain( );
      }
   }

   private void LaunchingFromUnity( )
   {
      uScriptDebug.Log("Launching From Unity.", uScriptDebug.Type.Debug );

      LoadSettings();
      
      wantsMouseMove = true;

      System.IO.Directory.CreateDirectory(uScriptConfig.ConstantPaths.RootFolder);
      System.IO.Directory.CreateDirectory(uScriptConfig.ConstantPaths.uScriptNodes);
      System.IO.Directory.CreateDirectory(uScriptConfig.ConstantPaths.uScriptEditor);

      System.IO.Directory.CreateDirectory(Preferences.ProjectFiles);
      System.IO.Directory.CreateDirectory(Preferences.UserScripts);
      System.IO.Directory.CreateDirectory(Preferences.UserNodes);
      System.IO.Directory.CreateDirectory(Preferences.GeneratedScripts);
      System.IO.Directory.CreateDirectory(Preferences.NestedScripts);

      // Move the uScriptUserTypes.cs.template file into the uScriptProjectFiles folder if one doesn't already exist.
      string userTypesFileTemplate = uScriptConfig.ConstantPaths.Templates + "/uScriptUserTypes.cs.template";
      string userTypesFile = uScriptConfig.ConstantPaths.SettingsPath + "/uScriptUserTypes.cs";
      if (File.Exists(userTypesFileTemplate) && !File.Exists(userTypesFile))
      {
         System.IO.File.Copy(userTypesFileTemplate, userTypesFile, false);
         AssetDatabase.Refresh();
      }

      // Create the Gizmos folder if it doesn't already exist in the project.
      string gizmos = UnityEngine.Application.dataPath + "/Gizmos";
      if (!Directory.Exists(gizmos))
      {
         System.IO.Directory.CreateDirectory(gizmos);
      }

      //copy gizmos into root
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( uScriptConfig.ConstantPaths.Gizmos );
      
      foreach ( System.IO.FileInfo file in directory.GetFiles( ) )
      {
         if (!System.IO.File.Exists( gizmos + "/" + file.Name ))
         {
            System.IO.File.Copy( file.FullName, gizmos + "/" + file.Name, false );
         }
      }

      //save all the types from unity so we can use them for quick lookup, we can't use Type.GetType because
      //we don't save the fully qualified type name which is required to return types of assemblies not loaded
      List<UnityEngine.Object> allObjects = new List<UnityEngine.Object>(GameObject.FindObjectsOfType(typeof(UnityEngine.Object)));
        
      foreach (UnityEngine.Object o in allObjects)
      {
         MasterComponent.AddType(o.GetType());
      }

      foreach (uScriptConfigBlock b in uScriptConfig.Variables)
      {
         MasterComponent.AddType(b.Type);
      }

      String lastOpened = (String)uScript.GetSetting("uScript\\LastOpened", "");
      String lastScene  = (String)uScript.GetSetting("uScript\\LastScene", "");
      //Debug.Log("last = " + lastOpened + ", lastScene = " + lastScene );
      if (!String.IsNullOrEmpty(lastOpened) && lastScene == UnityEditor.EditorApplication.currentScene)
      {
         m_FullPath = UnityEngine.Application.dataPath + lastOpened;
         //Debug.Log("fp loaded from settings" );
      }
      
      //Debug.Log("fp = " + m_FullPath );

      //clear any old script undo data laying around
      ClearChangeStack( );

      if ("" != m_FullPath)
      {
         if ( false == OpenScript(m_FullPath) )
         {
            m_FullPath = "";
         }
      }

      if ( "" == m_FullPath )
      {
         OpenFromCache( );
      }
      
      m_ComplexData = new ComplexData( );

      Detox.Utility.Status.StatusUpdate += new Detox.Utility.Status.StatusUpdateEventHandler(Status_StatusUpdate);

      uScriptBackgroundProcess.ForceFileRefresh();
   }

   private void RelaunchingFromRebuiltAppDomain( )
   {
      uScriptDebug.Log("Relaunching from Rebuilt AppDomain", uScriptDebug.Type.Debug );

      LoadSettings();

      m_ComplexData = new ComplexData( );

      OpenFromCache( );

      uScriptBackgroundProcess.ForceFileRefresh();
   }

   private void ClearChangeStack( )
   {
      m_UndoNumber = 0;
      UndoComponent.UndoNumber = m_UndoNumber;
      UnityEditor.Undo.ClearUndo(UndoComponent);

      m_UndoPatches = new string[ 0 ];
      m_Patches     = new string[ 0 ];
   }

   private void OpenFromCache( )
   {
      Profile p = new Profile( "OpenFromCache" );

      m_ScriptEditorCtrl = null;

      #if FREE_BETA_BUILD // See if expiration date and build cap should be used. Not needed for commercial version.
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

      if (!String.IsNullOrEmpty(CurrentScript))
      {
         //Debug.Log("Opening from valid script");
         scriptEditor = new ScriptEditor(string.Empty, PopulateEntityTypes(null), PopulateLogicTypes());
         scriptEditor.OpenFromBase64(null, CurrentScriptName, CurrentScript);
      }
      
      if ( null == scriptEditor )
      {
         scriptEditor = new ScriptEditor(string.Empty, PopulateEntityTypes(null), PopulateLogicTypes());
         //Debug.Log("no valid script");
      }

      Point loc = Point.Empty;
      if (false == String.IsNullOrEmpty(m_CurrentCanvasPosition))
      {
         loc = new Point(Int32.Parse(m_CurrentCanvasPosition.Substring(0, m_CurrentCanvasPosition.IndexOf(","))),
                         Int32.Parse(m_CurrentCanvasPosition.Substring(m_CurrentCanvasPosition.IndexOf(",") + 1)));
      }

      foreach ( string patch in m_Patches )
      {
         if ( false == String.IsNullOrEmpty(patch) )
         {
            ApplyPatch( null, scriptEditor, patch );
         }
      }

      m_ScriptEditorCtrl = new ScriptEditorCtrl(scriptEditor, loc);
      m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);

      m_ScriptEditorCtrl.BuildContextMenu();
      uScriptGUIPanelPalette.Instance.BuildPaletteMenu();
   
      m_ScriptEditorCtrl.IsDirty = CurrentScriptDirty || m_Patches.Length > 0;

      //clear out all patches and cache new copy of the script
      CacheScript( );

       p.End();
   }

   public void ApplyPatch(ScriptEditorCtrl ctrl, ScriptEditor scriptEditor, string patch)
   {
      object data;
      Detox.Data.ObjectSerializer o = new Detox.Data.ObjectSerializer( );

      byte[] binary = Convert.FromBase64String( patch );

      MemoryStream stream = new MemoryStream( binary );

      if ( true == o.Load(new BinaryReader(stream), out data) )
      {
         Detox.Patch.PatchData p = data as Detox.Patch.PatchData;

         //Debug.Log( "Applying Patch: " + p.GetType( ) + ", " + p.Name );
         p.Apply( scriptEditor );

         if ( null != ctrl )
         {
            ctrl.PatchDisplay( p );
         }
      }

      stream.Close( );
   }

   public void RemovePatch(ScriptEditorCtrl ctrl, ScriptEditor scriptEditor, string patch)
   {
      object data;
      Detox.Data.ObjectSerializer o = new Detox.Data.ObjectSerializer( );

      byte[] binary = Convert.FromBase64String( patch );

      MemoryStream stream = new MemoryStream( binary );

      if ( true == o.Load(new BinaryReader(stream), out data) )
      {
         Detox.Patch.PatchData p = data as Detox.Patch.PatchData;

         //Debug.Log( "Removing Patch: " + p.GetType( ) + ", " + p.Name );
         p.Remove( scriptEditor );

         if ( null != ctrl )
         {
            ctrl.UnpatchDisplay( p );
         }
      }

      stream.Close( );
   }

   public void CacheScript( )
   {
      m_Patches = new string[ 0 ];
      CurrentScript = m_ScriptEditorCtrl.ScriptEditor.ToBase64( null );
      CurrentScriptDirty = m_ScriptEditorCtrl.IsDirty;
      CurrentScriptName = m_ScriptEditorCtrl.Name;     
   }

   static public object GetSetting(string key)
   {
      return m_AppData.Get(key);
   }

   static public object GetSetting(string key, object defaultValue)
   {
      object value = m_AppData.Get(key);
      return null != value ? value : defaultValue;
   }

   static public void SetSetting(string key, object value)
   {
      m_AppData.Set(key, value);
      m_AppData.Save(uScriptConfig.ConstantPaths.SettingsPath + "/" + uScriptConfig.Files.SettingsFile);
   }

   static public void LoadSettings()
   {
      if (System.IO.File.Exists(uScriptConfig.ConstantPaths.SettingsPath + "/" + uScriptConfig.Files.SettingsFile))
      {
         m_AppData.Load(uScriptConfig.ConstantPaths.SettingsPath + "/" + uScriptConfig.Files.SettingsFile);
      }

      Preferences.Load( );
   }

   static void Status_StatusUpdate(Detox.Utility.StatusUpdateEventArgs e)
   {
      uScriptDebug.Type uScriptType = uScriptDebug.Type.Message;

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
      if (null != UndoComponent)
      {
         string base64 = p.ToBase64( );

         UndoComponent.UndoNumber = m_UndoNumber;

         Array.Resize( ref m_Patches, m_Patches.Length + 1 );
         m_Patches[ m_Patches.Length - 1 ] = base64;
         
         if ( m_UndoPatches.Length <= m_UndoNumber )
         {
            Array.Resize( ref m_UndoPatches, m_UndoNumber + 1 );
         }
         
         m_UndoPatches[ m_UndoNumber ] = base64;

         //Debug.Log("undo " + m_UndoNumber );
         UnityEditor.Undo.RegisterUndo(UndoComponent, p.Name + " (uScript)");

         //now increment and if the old one is restored
         //the numbers won't match
         ++m_UndoNumber;
         UndoComponent.UndoNumber = m_UndoNumber;
      }
   }

   // Unity Methods
   //
   void Awake()
   {
      EditorApplication.playmodeStateChanged = OnPlaymodeStateChanged;
      m_ForceCodeValidation = true;
   }


   public static bool isPro
   {
      // Test for Unity Pro - Unity 3.1 Indie does not support RenderTextures
      get { return SystemInfo.supportsRenderTextures; }
   }

   private string m_CurrentBreakpoint = "";
   private bool   m_IsDebuggingValues = false;

   void Update()
   {
      if ( null == m_ComplexData )
      {
         RelaunchingFromRebuiltAppDomain( );
         return;
      }

      if ( null == m_ScriptEditorCtrl ) return;



#if (!UNITY_STORE_BUILD)
      // Initialize the LicenseWindow here if needed. Doing it during OnGUI may
      // cause issues, such as null exception errors and reports that OnGUI calls
      // are being made outside of OnGUI.
      //
      if (isLicenseAccepted == false)
      {
         isLicenseAccepted = LicenseWindow.HasUserAcceptedLicense();
         if (isLicenseAccepted == false && LicenseWindow.isOpen == false)
         {
            LicenseWindow.Init();
         }
      }
#else
      // Force the license acceptance
      isLicenseAccepted = true;
#endif

      if ( EditorApplication.isPlaying )
      {
         //if the current breakpoint has changed we need to repaint
         //so the node visuals are properly reflected
         if (uScript.MasterComponent.CurrentBreakpoint != m_CurrentBreakpoint)
         {
            m_CurrentBreakpoint = uScript.MasterComponent.CurrentBreakpoint;
            uScript.RequestRepaint( );
         }

         m_ScriptEditorCtrl.UpdateRemoteValues( );
         m_IsDebuggingValues = true;
      }
      else if ( true == m_IsDebuggingValues )
      {
         //no longer playing then reset
         //our script to the previous state
         m_IsDebuggingValues = false;
         OpenFromCache( );
      
         //keep our undo stack at the value it was
         //when they last undid
         UndoComponent.UndoNumber = m_UndoNumber;
      }

      // Update the reference panel with the node palette's hot selection.
      uScriptGUIPanelReference.Instance.hotSelection = uScriptGUIPanelPalette.Instance._hotSelection;


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
      _mouseRegion = _mouseRegionUpdate;


      if (true == CodeValidator.RequireRebuild(m_ForceCodeValidation))
      {
         RebuildAllScripts();
      }

      //rebuild was requested but we have to wait until the editor
      //is done compiling so it properly reflects everything
      if (true == m_RebuildWhenReady && false == EditorApplication.isCompiling)
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

         m_RebuildWhenReady = false;
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


      if ( UndoComponent.UndoNumber != m_UndoNumber )
      {
         //if their number is greater then it was a redo
         //so apply the patch
         if ( UndoComponent.UndoNumber > m_UndoNumber )
         {
            //for some reason we're going out of range when starting Unity with uScript open
            //so make sure it's clamped here until i figure out the cause
            if (m_UndoPatches.Length <= UndoComponent.UndoNumber - 1)
            {
               UndoComponent.UndoNumber = m_UndoPatches.Length;
            }

            ApplyPatch( m_ScriptEditorCtrl, m_ScriptEditorCtrl.ScriptEditor, m_UndoPatches[UndoComponent.UndoNumber - 1] );      
         }
         else
         {
            //if their number was less then it was an undo
            //so remove the previous change

            //for some reason we're going out of range when starting Unity with uScript open
            //so make sure it's clamped here until i figure out the cause
            if (m_UndoPatches.Length <= UndoComponent.UndoNumber)
            {
               UndoComponent.UndoNumber = m_UndoPatches.Length - 1;
            }

            RemovePatch( m_ScriptEditorCtrl, m_ScriptEditorCtrl.ScriptEditor, m_UndoPatches[UndoComponent.UndoNumber] );
         }
         
         //recache the script since we're out of date with the patches
         CacheScript( );

         m_UndoNumber = UndoComponent.UndoNumber;
         
         //Debug.Log("applied undo " + m_UndoNumber );
      }

      if (_wasHierarchyChanged)
      {
         _wasHierarchyChanged = false;
         OpenFromCache( );
      }

      if (true == m_WantsCopy)
      {
         m_ScriptEditorCtrl.CopyToClipboard();
         m_WantsCopy = false;
      }
      if (true == m_WantsCut)
      {
         m_ScriptEditorCtrl.CopyToClipboard();
         m_ScriptEditorCtrl.DeleteSelectedNodes();
         m_WantsCut = false;
      }
      if (true == m_WantsPaste)
      {
         m_ScriptEditorCtrl.PasteFromClipboard(Point.Empty);
         m_WantsPaste = false;
      }
      if (m_ScriptEditorCtrl != null && !String.IsNullOrEmpty(m_AddVariableNode))
      {
         if (m_AddVariableNode == "Comment")
         {
            m_ScriptEditorCtrl.ContextCursor = Detox.Windows.Forms.Cursor.Position;
            m_ScriptEditorCtrl.AddVariableNode(new CommentNode(""));
         }
         else if (m_AddVariableNode == "External")
         {
            m_ScriptEditorCtrl.ContextCursor = new Point(Detox.Windows.Forms.Cursor.Position.X - 28, Detox.Windows.Forms.Cursor.Position.Y - 28);
            m_ScriptEditorCtrl.AddVariableNode(new ExternalConnection(Guid.NewGuid()));
         }
         else if (m_AddVariableNode == "Log")
         {
            m_ScriptEditorCtrl.ContextCursor = new Point(Detox.Windows.Forms.Cursor.Position.X - 10, Detox.Windows.Forms.Cursor.Position.Y - 10);
            m_ScriptEditorCtrl.AddVariableNode(m_ScriptEditorCtrl.GetLogicNode("uScriptAct_Log"));
         }
         else
         {
            m_ScriptEditorCtrl.ContextCursor = new Point(Detox.Windows.Forms.Cursor.Position.X - 28, Detox.Windows.Forms.Cursor.Position.Y - 28);
            m_ScriptEditorCtrl.AddVariableNode(new LocalNode("", m_AddVariableNode, ""));
         }
         m_AddVariableNode = "";
      }

      if (_requestedCloseMap)
      {
         _requestedCloseMap = false;

         // Center the canvas on _requestCanvasLocation
         m_ScriptEditorCtrl.CenterOnPoint(_requestCanvasLocation);
      }

      //we can't ignore if the context menu is up
      //because we need to send the mouse up
      //after it has been activated
      //
      // is this still the case?
      if ( false == isContextMenuOpen )
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

      // Repaint if a request was previously made
      //
      if (_wasRepaintRequested)
      {
         _wasRepaintRequested = false;
         uScript.Instance.Repaint();
//         Debug.Log("Repaint\n");
      }
   }


   bool _requestedCloseMap = false;
   Point _requestCanvasLocation = Point.Empty;




   //
   // Canvas Context Menu
   //
   GenericMenu _canvasContextMenu = new GenericMenu();

   private void BuildCanvasContextMenu(ToolStripItem contextMenuItem, string path)
   {
      GUIContent content;

      if (contextMenuItem == null || string.IsNullOrEmpty(path))
      {
         //
         // Create a new context menu, destroying the old one
         //
         _canvasContextMenu = new GenericMenu();

         foreach (ToolStripItem item in m_ScriptEditorCtrl.ContextMenu.Items.Items)
         {
            if (item is ToolStripMenuItem)
            {
               ToolStripMenuItem menuItem = item as ToolStripMenuItem;

               if (menuItem.DropDownItems.Items.Count > 0)
               {
                  // This is the parent of a submenu
                  foreach (ToolStripItem subitem in menuItem.DropDownItems.Items)
                  {
                     BuildCanvasContextMenu(subitem, item.Text.Replace("...", string.Empty) + "/");
                  }
               }
               else
               {
                  // This is a menu item
                  content = new GUIContent(item.Text.Replace("&", string.Empty),
                                           FindNodeToolTip(ScriptEditor.FindNodeType(item.Tag as EntityNode)));

                  _canvasContextMenu.AddItem(content, false, ContextMenuCallback, item);
               }
            }
            else
            {
               if (item.Text == "<hr>")
               {
                  // This is a separator
                  _canvasContextMenu.AddSeparator("");
               }
            }

//            // We can support disabled items, but the ScriptEditorCtrl doesn't at the moment
//            _canvasContextMenu.AddDisabledItem(new GUIContent("DisabledItem"));
         }
      }
      else if (!(contextMenuItem is ToolStripSeparator))
      {
         if ((contextMenuItem is ToolStripMenuItem) && ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items.Count > 0)
         {
            // There are sub items
            string parent = contextMenuItem.Text.Replace("...", string.Empty);

            foreach (ToolStripItem item in ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items)
            {
               BuildCanvasContextMenu(item, path + parent + "/");
            }
         }
         else
         {
            content = new GUIContent(path + contextMenuItem.Text.Replace("&", string.Empty),
                                     FindNodeToolTip(ScriptEditor.FindNodeType(contextMenuItem.Tag as EntityNode)));

            _canvasContextMenu.AddItem(content, false, ContextMenuCallback, contextMenuItem);
         }
      }
      else
      {
         uScriptDebug.Log("The contextMenuItem (" + contextMenuItem.Text + ") is a " + contextMenuItem.GetType() + " and is unhandled!\n", uScriptDebug.Type.Warning);
      }
   }


   private void ContextMenuCallback(object obj)
   {
      ToolStripItem item = obj as ToolStripItem;

      if (item == null)
      {
         Debug.LogError("The context menu callback received an invalid data\n");
      }
      else
      {
         if (item.Click != null)
         {
            item.Click(item, new EventArgs());
         }
         else
         {
            Debug.Log("Context menu selection had no event handler.\n");
         }
      }
   }


   void OnHierarchyChange()
   {
      _wasHierarchyChanged = true;
      uScriptGUIPanelPalette.Instance._panelFilterText = string.Empty;
   }


   void OnGUI()
   {
      // Store the current event locally since it is reference so frequently
      Event e = Event.current;

      //
      // Make sure the initial window size it not too small
      //
      if (_firstRun)
      {
         _firstRun = false;

         Rect minSize = new Rect(200, 200, 620, 550);
         if (position.width < minSize.width || position.height < minSize.height)
         {
            position = minSize;
         }

         uScriptGUI.panelPropertiesWidth = (int)(uScript.Instance.position.width / 3);
         uScriptGUI.panelScriptsWidth = (int)(uScript.Instance.position.width / 3);

         if (Preferences.ShowAtStartup)
         {
            WelcomeWindow.Init();
         }
      }

      if (m_ScriptEditorCtrl == null)
      {
         return;
      }

      //must be done in OnGUI rather than on demand
      m_ScriptEditorCtrl.ParseClipboardData( );

      GUI.enabled = isLicenseAccepted && !isPreferenceWindowOpen;

      // Set the default mouse region
      _mouseRegionUpdate = uScript.MouseRegion.Outside;

      // As little logic as possible should be performed here.  It is better
      // to use Update() to perform tasks once per tick.

      bool lastMouseDown = m_MouseDown;

      isContextMenuOpen = 0 != m_ContextX || 0 != m_ContextY;
      if (false == isPreferenceWindowOpen)
      {
         if (isContextMenuOpen)
         {
            OnGUI_HandleInput_ContextMenu();
         }
         else if (isFileMenuOpen)
         {
            OnGUI_HandleInput_FileMenu();
         }
         else
         {
            OnGUI_HandleInput_Canvas();
         }
      }
      else
      {
         if (true == m_MouseDown)
         {
            m_MouseDownArgs = null;
            m_MouseDown = false;

            m_MouseUpArgs = new Detox.Windows.Forms.MouseEventArgs();
            m_MouseUpArgs.Button = MouseButtons.Left;
            m_MouseUpArgs.X = (int)e.mousePosition.x;
            m_MouseUpArgs.Y = (int)(e.mousePosition.y - _canvasRect.yMin);
         }
      }


      //
      // All the GUI drawing code
      //
      DrawMainGUI();

      // where is the mouse?
      CalculateMouseRegion();

      // do external windows/popups
      DrawPopups();



      if (Event.current.type == EventType.Repaint)
      {
         // Process the PNG export first
         //
         // The user should not be able to input during this process
         //
         uScriptExportPNG.ProcessImageExport();

         uScriptGUI.MonitorGUIControlFocusChanges();
      }




      if (m_MouseDown == false)
      {
         // turn panel rendering back on
         m_CanvasDragging = false;
      }

      // the following code must be here because it needs to happen 
      // after we've figured out what region the mouse is in
      if (_mouseRegion == uScript.MouseRegion.Outside)
      {
         // if the mouse is not over our window, don't look for mouse move events
         // fixes an exception when trying to close a dirty uscript
         wantsMouseMove = false;
      }
      else
      {
         // when the mouse is over our window, look for mouse move events
         wantsMouseMove = true;
      }

      // mark mouse down region for dragging resize handles
      if (lastMouseDown == false && m_MouseDown)
      {
         // mouse was pressed down this event, set the current region
         m_MouseDownRegion = _mouseRegion;
      }

      // Do this after the event processing has taken place so that we 
      // know we don't have a duplicate mouse up event
      if (true == m_MouseDown && _mouseRegion == MouseRegion.Outside && m_MouseUpArgs == null)
      {
         m_MouseUpArgs = new Detox.Windows.Forms.MouseEventArgs();

         int button = 0;

         if (e.button == 0) button = MouseButtons.Left;
         else if (e.button == 1) button = MouseButtons.Right;
         else if (e.button == 2) button = MouseButtons.Middle;

         m_MouseUpArgs.Button = button;
         m_MouseUpArgs.X = (int)(e.mousePosition.x);
         if (!uScriptGUI.panelsHidden) m_MouseUpArgs.X -= uScriptGUI.panelLeftWidth;
         m_MouseUpArgs.Y = (int)(e.mousePosition.y - _canvasRect.yMin);

         m_MouseDownRegion = MouseRegion.Outside;
         m_MouseDown = false;
      }

      if (e.type == EventType.DragPerform || e.type == EventType.DragUpdated)
      {
         if (_mouseRegion == MouseRegion.Canvas)
         {
            CheckDragDropCanvas();
            e.Use();
         }
      }
   }




   void OnGUI_HandleInput_ContextMenu()
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

//         case EventType.MouseUp:
//            if (e.button != 0)
//            {
//               isContextMenuOpen = false;
//            }
//            break;

         case EventType.ScrollWheel:
            if (rectContextMenuWindow.Contains(e.mousePosition) == false)
            {
               e.Use();
            }
            break;

//         // paint/layout events
//         case EventType.Layout:
//            break;
//         case EventType.Repaint:
//            break;
//
//         // ignore these events
//         case EventType.Ignore:
//         case EventType.Used:
//         default:
//            break;
      }

      if (isContextMenuOpen == false)
      {
         e.Use();
      }
   }




   void OnGUI_HandleInput_FileMenu()
   {
      Event e = Event.current;

      int modifierKeys = 0;

      if (Event.current.alt) modifierKeys |= Keys.Alt;
      if (Event.current.shift) modifierKeys |= Keys.Shift;
      if (Event.current.control || Event.current.command) modifierKeys |= Keys.Control;

      switch (e.type)
      {
         case EventType.ContextClick:
            isFileMenuOpen = false;
            break;

         case EventType.KeyDown:
            e.Use();
            break;

         case EventType.KeyUp:
            if (modifierKeys == Keys.None || modifierKeys == Keys.Alt)
            {
               switch (e.keyCode)
               {
                  case KeyCode.Escape:
                     isFileMenuOpen = false;
                     break;
                  case KeyCode.N:
                     FileMenuItem_New();
                     break;
                  case KeyCode.O:
                     FileMenuItem_Open();
                     break;
                  case KeyCode.S:
                     FileMenuItem_Save();
                     break;
                  case KeyCode.A:
                     FileMenuItem_SaveAs();
                     break;
                  case KeyCode.Q:
                     FileMenuItem_QuickSave();
                     break;
                  case KeyCode.D:
                     FileMenuItem_DebugSave();
                     break;
                  case KeyCode.R:
                     FileMenuItem_ReleaseSave();
                     break;
                  case KeyCode.E:
                     FileMenuItem_ExportPNG();
                     break;
               }
            }
            e.Use();
            break;

         case EventType.MouseDown:
            if (rectFileMenuWindow.Contains(e.mousePosition) == false)
            {
               isFileMenuOpen = false;
            }
            else if (e.button != 0)
            {
               isFileMenuOpen = false;
            }
            break;

         case EventType.MouseUp:
            if (e.button != 0)
            {
               isFileMenuOpen = false;
            }
            break;

         case EventType.ScrollWheel:
            e.Use();
            break;

//         // paint/layout events
//         case EventType.Layout:
//            break;
//         case EventType.Repaint:
//            break;
//
//         // ignore these events
//         case EventType.Ignore:
//         case EventType.Used:
//         default:
//            break;
      }
   }




   void OnGUI_HandleInput_Canvas()
   {
      Event e = Event.current;

      int modifierKeys = 0;

      if (Event.current.alt) modifierKeys |= Keys.Alt;
      if (Event.current.shift) modifierKeys |= Keys.Shift;
      if (Event.current.control || Event.current.command) modifierKeys |= Keys.Control;

      Control.ModifierKeys.Pressed = modifierKeys;

      //
      // handle normal canvas controls
      //
      switch (e.type)
      {
         // command events

         case EventType.ContextClick:
            //
            // Display the canvas context menu only when the
            // mouse is over the canvas when the event occurs
            //
            if (_canvasRect.Contains(e.mousePosition))
            {
               // Use the new context menu in Unity 3.4 and higher

               if ( UnityVersion < 3.4f )
               {
                  m_ScriptEditorCtrl.BuildContextMenu();
                  uScriptGUIPanelPalette.Instance.BuildPaletteMenu();

                  m_ContextX = (int)e.mousePosition.x;
                  m_ContextY = (int)(e.mousePosition.y - _canvasRect.yMin);

//                  //refresh screen so context menu shows up
//                  RequestRepaint();
               }
               else
               {
                  Profile overall = new Profile ("BuildContextMenu");

                  m_ScriptEditorCtrl.BuildContextMenu();
                  BuildCanvasContextMenu(null, null);

                  _canvasContextMenu.ShowAsContext();

                  overall.End();

//                  e.Use();
//
//                  // stupid hack to prevent the "canvasDragging" behavior
//                  if (m_MouseDown)
//                  {
//                     m_MouseDownRegion = MouseRegion.Reference;
//                     m_MouseDown = false;
//                  }
               }
            }
            break;

         case EventType.ValidateCommand:
            if (e.commandName == "Copy")
            {
               if (m_ScriptEditorCtrl.CanCopy && AllowKeyInput())
               {
                  e.Use();
               }
            }
            else if (e.commandName == "Cut")
            {
               if (m_ScriptEditorCtrl.CanCopy && AllowKeyInput())
               {
                  e.Use();
               }
            }
            else if (e.commandName == "Paste" && AllowKeyInput())
            {
               if (m_ScriptEditorCtrl.CanPaste)
               {
                  e.Use();
               }
            }
            else if (e.commandName == "SelectAll" && AllowKeyInput())
            {
               e.Use();
            }
            break;

         case EventType.ExecuteCommand:
            if (e.commandName == "Copy" && AllowKeyInput())
            {
               m_WantsCopy = true;
            }
            else if (e.commandName == "Cut" && AllowKeyInput())
            {
               m_WantsCut = true;
            }
            else if (e.commandName == "Paste" && AllowKeyInput())
            {
               m_WantsPaste = true;
            }
            else if (e.commandName == "SelectAll" && AllowKeyInput())
            {
               m_SelectAllNodes = true;
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
               m_PressedKey = e.keyCode;
            }
   
            if (AllowKeyInput())
            {
               // Check for valid shortcut keys, and eat the KeyDown
               // event to avoid the "invalid key" beep on Mac.

               if (modifierKeys == Keys.Control)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.F:   // Open File Menu
                     case KeyCode.G:   // Toggle grid visibility
                     case KeyCode.H:   // Position graph at (0, 0)
                     case KeyCode.W:   // Close uScript Editor window
                        e.Use();
                        break;
                  }
               }
               else if (modifierKeys == Keys.Alt)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.A:   // Save As ...
                     case KeyCode.D:   // Debug Save
                     case KeyCode.E:   // Export PNG
                     case KeyCode.F:   // Open File Menu
                     case KeyCode.N:   // New uScript graph
                     case KeyCode.O:   // Open uScript graph
                     case KeyCode.Q:   // Quick Save
                     case KeyCode.R:   // Release Save
                     case KeyCode.S:   // Save
                        e.Use();
                        break;
                  }
               }
//               else if (modifierKeys == Keys.Shift)
//               {
//               }
//               else if (modifierKeys == Keys.ControlAlt)
//               {
//               }
//               else if (modifierKeys == Keys.ControlShift)
//               {
//               }
//               else if (modifierKeys == Keys.AltShift)
//               {
//               }
//               else if (modifierKeys == Keys.ControlAltShift)
//               {
//               }
               else // (modifierKeys == Keys.None)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.F1:              // Open uScript online documentation
                     case KeyCode.Backspace:       // Delete graph selection
                     case KeyCode.Delete:          // Delete graph selection
                     case KeyCode.Escape:          // Drop graph selection
                     case KeyCode.Home:            // Position graph at (0, 0)
                     case KeyCode.LeftBracket:     // Position graph at previous Event node
                     case KeyCode.RightBracket:    // Position graph at next Event node
                     case KeyCode.BackQuote:       // Toggle panel visibility
                     case KeyCode.Backslash:       // Toggle panel visibility
                     case KeyCode.Alpha0:          // Zoom graph default
                     case KeyCode.Minus:           // Zoom graph out
                     case KeyCode.Equals:          // Zoom graph in
                     case KeyCode.B:               // (onMouseUp) Place Bool variable node
                     case KeyCode.C:               // (onMouseUp) Place Comment
                     case KeyCode.E:               // (onMouseUp) Place External variable node
                     case KeyCode.F:               // (onMouseUp) Place Float variable node
                     case KeyCode.G:               // (onMouseUp) Place GameObject variable node
                     case KeyCode.I:               // (onMouseUp) Place Int variable node
                     case KeyCode.L:               // (onMouseUp) Place Log action node
                     case KeyCode.O:               // (onMouseUp) Place Object variable node
                     case KeyCode.S:               // (onMouseUp) Place String variable node
                     case KeyCode.V:               // (onMouseUp) Place Vector3 variable node
                        e.Use();
                        break;
                  }
               }
            }
            break;

         case EventType.KeyUp:
            if (AllowKeyInput())
            {
               if (modifierKeys == Keys.Control)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.F:
                        //
                        // Open File Menu
                        //
                        isFileMenuOpen = true;
                        break;

                     case KeyCode.G:
                        //
                        // Toggle grid visibility
                        //
                        Preferences.ShowGrid = !Preferences.ShowGrid;
                        Preferences.Save();
                        break;

                     case KeyCode.H:
                        //
                        // Position graph at (0, 0)
                        //
                        if (m_ScriptEditorCtrl != null)
                        {
                           m_ScriptEditorCtrl.RebuildScript(null, true);
                        }
                        break;

                     case KeyCode.W:
                        //
                        // Close uScript Editor window
                        //
                        this.Close();
                        break;
                  }
               }
               else if (modifierKeys == Keys.Alt)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.A:
                        FileMenuItem_SaveAs();
                        break;

                     case KeyCode.D:
                        FileMenuItem_DebugSave();
                        break;

                     case KeyCode.E:
                        FileMenuItem_ExportPNG();
                        break;

                     case KeyCode.F:
                        isFileMenuOpen = true;
                        break;

                     case KeyCode.N:
                        FileMenuItem_New();
                        break;

                     case KeyCode.O:
                        FileMenuItem_Open();
                        break;

                     case KeyCode.Q:
                        FileMenuItem_QuickSave();
                        break;

                     case KeyCode.R:
                        FileMenuItem_ReleaseSave();
                        break;

                     case KeyCode.S:
                        FileMenuItem_Save();
                        break;
                  }
               }
//               else if (modifierKeys == Keys.Shift)
//               {
//               }
//               else if (modifierKeys == Keys.ControlAlt)
//               {
//               }
//               else if (modifierKeys == Keys.ControlShift)
//               {
//               }
//               else if (modifierKeys == Keys.AltShift)
//               {
//               }
//               else if (modifierKeys == Keys.ControlAltShift)
//               {
//               }
               else // (modifierKeys == Keys.None)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.F1:
                        //
                        // Open uScript online documentation
                        //
                        Help.BrowseURL("http://www.uscript.net/docs/index.php?title=Main_Page");
                        break;

                     case KeyCode.Backspace:
                     case KeyCode.Delete:
                        //
                        // Delete graph selection
                        //
                        m_ScriptEditorCtrl.DeleteSelectedNodes();
                        break;

                     case KeyCode.Escape:
                        //
                        // Drop graph selection
                        //
                        m_ScriptEditorCtrl.DeselectAll();
                        break;

                     case KeyCode.Home:
                        //
                        // Position graph at (0, 0)
                        //
                        if (m_ScriptEditorCtrl != null)
                        {
                           m_ScriptEditorCtrl.RebuildScript(null, true);
                        }
                        break;

                     case KeyCode.LeftBracket:
                        //
                        // Position graph at previous Event node
                        //
                        m_FocusedNode = m_ScriptEditorCtrl.GetPrevNode(m_FocusedNode, typeof(EntityEventDisplayNode));
                        if (m_FocusedNode != null)
                        {
                           m_ScriptEditorCtrl.CenterOnNode(m_FocusedNode);
                        }
                        break;

                     case KeyCode.RightBracket:
                        //
                        // Position graph at next Event node
                        //
                        m_FocusedNode = m_ScriptEditorCtrl.GetNextNode(m_FocusedNode, typeof(EntityEventDisplayNode));
                        if (m_FocusedNode != null)
                        {
                           m_ScriptEditorCtrl.CenterOnNode(m_FocusedNode);
                        }
                        break;

                     case KeyCode.BackQuote:
                     case KeyCode.Backslash:
                        //
                        // Toggle panel visibility
                        //
                        //    The BackQuote key doesn't work well on the German keyboard,
                        //    so support Backslash as well.
                        //
                        uScriptGUI.panelsHidden = !uScriptGUI.panelsHidden;

                        // FIXME: When toggled while the mouse is down, the canvas often shifts around.
                        if (uScriptGUI.panelsHidden)
                        {
                           // m_ScriptEditorCtrl.FlowChart.Location.X += (int)_canvasRect.x;
                           m_ScriptEditorCtrl.FlowChart.Location.X += uScriptGUI.panelLeftWidth + uScriptGUI.panelDividerThickness;
                           m_ScriptEditorCtrl.RebuildScript(null, false);
                        }
                        else
                        {
                           // m_ScriptEditorCtrl.FlowChart.Location.X -= (int)_canvasRect.x;
                           m_ScriptEditorCtrl.FlowChart.Location.X -= uScriptGUI.panelLeftWidth + uScriptGUI.panelDividerThickness;
                           m_ScriptEditorCtrl.RebuildScript(null, false);
                        }
                        break;

                     case KeyCode.Alpha0:
                        //
                        // Zoom graph default
                        //
                        m_MapScale = 1.0f;
                        break;

                     case KeyCode.Minus:
                        //
                        // Zoom graph out
                        //
                        m_MapScale = Mathf.Max(m_MapScale - 0.1f, 0.1f);
                        break;

                     case KeyCode.Equals:
                        //
                        // Zoom graph in
                        //
                        m_MapScale = Mathf.Min(m_MapScale + 0.1f, 1.0f);
                        break;
                  }
               }
            }

            m_PressedKey = KeyCode.None;

            // Keep key events from going to the rest of Unity
            e.Use();
            break;

         // mouse events
         case EventType.MouseDown:
            // Ignore Right-clicks
            if (e.button != 1)
            {
               if (false == m_MouseDown)
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
                     if (!uScriptGUI.panelsHidden) m_MouseDownArgs.X -= uScriptGUI.panelLeftWidth;
                     m_MouseDownArgs.Y = (int)(e.mousePosition.y - _canvasRect.yMin);

                     m_MouseDownOverCanvas = true;
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
                  if (e.clickCount == 2 && NodeClicked != null)
                  {
                     OpenNode(NodeClicked);
                  }
                  else
                  {
                     // Clear the clicked node in all other cases
                     NodeClicked = null;
                  }

                  m_MouseDown = true;

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
            else if (m_MouseDownRegion == uScript.MouseRegion.Canvas && _canvasRect.Contains(e.mousePosition))
            {
               // this is the switch to use to turn off panel rendering while panning/marquee selecting
               m_CanvasDragging = true;
            }
            break;
         case EventType.MouseUp:
            if (m_MouseDown && m_MouseDownOverCanvas)
            {
               m_MouseUpArgs = new Detox.Windows.Forms.MouseEventArgs();

               int button = 0;

               if (e.button == 0) button = MouseButtons.Left;
               else if (e.button == 1) button = MouseButtons.Right;
               else if (e.button == 2) button = MouseButtons.Middle;

               m_MouseUpArgs.Button = button;
               m_MouseUpArgs.X = (int)(e.mousePosition.x);
               if (!uScriptGUI.panelsHidden) m_MouseUpArgs.X -= uScriptGUI.panelLeftWidth;
               m_MouseUpArgs.Y = (int)(e.mousePosition.y - _canvasRect.yMin);

               if (m_PressedKey == KeyCode.S)
               {
                  m_AddVariableNode = "System.String";
               }
               else if (m_PressedKey == KeyCode.V)
               {
                  m_AddVariableNode = "UnityEngine.Vector3";
               }
               else if (m_PressedKey == KeyCode.I)
               {
                  m_AddVariableNode = "System.Int32";
               }
               else if (m_PressedKey == KeyCode.F)
               {
                  m_AddVariableNode = "System.Single";
               }
               else if (m_PressedKey == KeyCode.B)
               {
                  m_AddVariableNode = "System.Boolean";
               }
               else if (m_PressedKey == KeyCode.G)
               {
                  m_AddVariableNode = "UnityEngine.GameObject";
               }
               else if (m_PressedKey == KeyCode.O)
               {
                  m_AddVariableNode = "UnityEngine.Object";
               }
               else if (m_PressedKey == KeyCode.C)
               {
                  m_AddVariableNode = "Comment";
               }
               else if (m_PressedKey == KeyCode.E)
               {
                  m_AddVariableNode = "External";
               }
               else if (m_PressedKey == KeyCode.L)
               {
                  m_AddVariableNode = "Log";
               }
            }
            m_MouseDownRegion = MouseRegion.Outside;
            m_MouseDownOverCanvas = false;
            m_MouseDown = false;
            break;

         case EventType.ScrollWheel:
            if (_canvasRect.Contains(e.mousePosition))
            {
               m_ZoomPoint = Detox.Windows.Forms.Cursor.Position;

               float newScale = Mathf.Clamp(m_MapScale - Mathf.Clamp(e.delta.y * 0.01f, -1, 1), 0.1f, 1.0f);

               //make sure we stop on 1.0 before going lower or higher
               if ( m_MapScale < 1 && newScale > 1 ) newScale = 1;
               if ( m_MapScale > 1 && newScale < 1 ) newScale = 1;

               m_MapScale = newScale;

//               Debug.Log("SCROLLWHEEL: " + e.delta + "\n");
            }
            break;

//         // paint/layout events
//         case EventType.Layout:
//            break;
//         case EventType.Repaint:
//            break;
//
//         // ignore these events
//         case EventType.Ignore:
//         case EventType.Used:
//         default:
//            break;
      }
   }






   public void DrawPopups()
   {
      // Draw window elements, including the context menu
      //
      GUI.enabled = true;
      BeginWindows();
      {
         if (isContextMenuOpen)
         {
            int _paddingAroundContextMenu = 4;

            // try to put the window where the user clicked
            rectContextMenuWindow.x = m_ContextX;
            rectContextMenuWindow.y = m_ContextY;

            // update the x, y, width, and height to ensure the context menu appears within the _canvasRect bounds
            //
            // they should be handled in the xMax, xMin and then yMax and yMin order
            //
            if (_canvasRect.xMax - _paddingAroundContextMenu < rectContextMenuWindow.xMax)
            {
               rectContextMenuWindow.x -= rectContextMenuWindow.xMax - (_canvasRect.xMax - _paddingAroundContextMenu);
            }

            if (_canvasRect.xMin + _paddingAroundContextMenu > rectContextMenuWindow.xMin)
            {
               rectContextMenuWindow.x = (_canvasRect.xMin + _paddingAroundContextMenu);
            }

            if (position.height - _paddingAroundContextMenu < rectContextMenuWindow.yMax)
            {
               rectContextMenuWindow.y -= rectContextMenuWindow.yMax - (position.height - _paddingAroundContextMenu);
            }

            if (_canvasRect.yMin + _paddingAroundContextMenu > rectContextMenuWindow.yMin)
            {
               rectContextMenuWindow.y = (_canvasRect.yMin + _paddingAroundContextMenu);
            }

            Rect tmpRect = GUILayout.Window("ContextMenu".GetHashCode(), rectContextMenuWindow, DrawContextMenuWindow, string.Empty, uScriptGUIStyle.menuContextWindow);
            if (Event.current.type == EventType.Repaint)
            {
               rectContextMenuWindow = tmpRect;
            }
         }
         else if (isFileMenuOpen)
         {
            rectFileMenuWindow = GUILayout.Window("FileMenu".GetHashCode(), rectFileMenuWindow, DrawFileMenuWindow, string.Empty, uScriptGUIStyle.menuDropDownWindow);
         }
      }
      EndWindows();
   }


   void OnPlaymodeStateChanged()
   {
      //if we're not debugging values then we're just starting into playing in the editor
      //and warn them, otherwise we've already warned them so don't pop up a warning again
      if ( false == m_IsDebuggingValues )
      {
         if (EditorApplication.isPlayingOrWillChangePlaymode && m_ScriptEditorCtrl != null && true == m_ScriptEditorCtrl.IsDirty)
         {
            EditorUtility.DisplayDialog("uScript Not Saved!", "uScript has detected that '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' has been changed, but not saved! You will not see any changes until you save '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' in the uScript Editor.", "OK");
         }
         else if (EditorApplication.isPlayingOrWillChangePlaymode && m_ScriptEditorCtrl != null && true == m_ScriptEditorCtrl.CodeIsStale )
         {
            EditorUtility.DisplayDialog("uScript Not Saved!", "uScript has detected that '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' was quick saved but the code has not been generated! You will not see any changes until you save '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' in the uScript Editor.", "OK");
         }
      }
   }

   void OnDestroy()
   {
      AllowNewFile(false);

      if (m_ScriptEditorCtrl != null)
      {
         m_ScriptEditorCtrl.ScriptModified -= new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);
         m_ScriptEditorCtrl = null;
      }
      Detox.Utility.Status.StatusUpdate -= new Detox.Utility.Status.StatusUpdateEventHandler(Status_StatusUpdate);

      ClearChangeStack( );

      CurrentScriptDirty = false;
      CurrentScript = null;
      CurrentScriptName = null;
      m_ComplexData = null;
   }


   public void OpenNode(Node node)
   {
      if (node is DisplayNode)
      {
         //
         // Ping the source, Open the source in the default editor, or Load the Nested Graph
         //

         string currentNodeClassName = ScriptEditor.FindNodeType(((DisplayNode)node).EntityNode);
         string currentNodeClassPath = GetClassPath(currentNodeClassName);
         string scriptPath = FindFile( Preferences.UserScripts, currentNodeClassName + ".uscript" );
         int assetInstanceID = 0;

         if (Preferences.DoubleClickBehavior == Preferences.DoubleClickBehaviorType.PingSource)
         {
            // PING node source, PING script source
            uScriptGUI.PingObject(currentNodeClassPath, typeof(TextAsset));
         }
         else if (Preferences.DoubleClickBehavior == Preferences.DoubleClickBehaviorType.OpenSource)
         {
            // OPEN node source, OPEN script source
            assetInstanceID = GetAssetInstanceID(currentNodeClassPath, typeof(TextAsset));
            AssetDatabase.OpenAsset(assetInstanceID);
         }
         else if (Preferences.DoubleClickBehavior == Preferences.DoubleClickBehaviorType.LoadGraphPingSource)
         {
            // PING node source, LOAD script
            if (scriptPath == string.Empty)
            {
               uScriptGUI.PingObject(uScript.GetClassPath(currentNodeClassName), typeof(TextAsset));
            }
            else
            {
               OpenScript(scriptPath);
            }
         }
         else
         {
            // OPEN node source, LOAD script
            if (scriptPath == string.Empty)
            {
               assetInstanceID = GetAssetInstanceID(currentNodeClassPath, typeof(TextAsset));
               AssetDatabase.OpenAsset(assetInstanceID);
            }
            else
            {
               OpenScript(scriptPath);
            }
         }
      }
   }


   void DrawMainGUI()
   {
      uScriptGUIContent.Init();
      uScriptGUIStyle.Init();
      uScriptGUI.InitPanels();

      // Notify the user when the editor is in play mode, since any changes
      // made to the uScript will be lost when exiting the mode.
      //
      if (Application.isPlaying)
      {
         ShowNotification(uScriptGUIContent.messagePlaying);
      }
      else if (EditorApplication.isCompiling)
      {
         ShowNotification(uScriptGUIContent.messageCompiling);
      }
      else
      {
         RemoveNotification();
      }

      // Draw the various GUI panels
      //
      DrawGUITopAreas();
      if (!uScriptGUI.panelsHidden)
      {
         DrawGUIHorizontalDivider();

         SetMouseRegion(MouseRegion.HandleCanvas);//, 1, -3, -1, 6 );

         DrawGUIBottomAreas();
      }
      OnGUI_DrawStatusbar();

      // @TODO: This bool flag could be removed if the GUI is repainted after the canvas stops panning
      if (_wasMoving)
      {
         _wasMoving = false;
         RequestRepaint();
      }
   }

   void DrawGUITopAreas()
   {
      EditorGUILayout.BeginHorizontal();
      {
         if (!uScriptGUI.panelsHidden)
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

   void DrawGUIBottomAreas()
   {
      Rect rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(uScriptGUI.panelPropertiesHeight));
      if ( rect.height != 0.0f && rect.height != (float)uScriptGUI.panelPropertiesHeight )
      {
         // if we didn't get the height we requested, we must have hit a limit, stop dragging and reset the height
         uScriptGUI.panelPropertiesHeight = (int)rect.height;
         m_MouseDownRegion = MouseRegion.Canvas;
         ForceReleaseMouse();
      }
      {
         uScriptGUIPanelProperty.Instance.Draw();

         DrawGUIVerticalDivider();
         SetMouseRegion(MouseRegion.HandleProperties);//, -3, 3, 6, -3 );

         uScriptGUIPanelReference.Instance.Draw();

         DrawGUIVerticalDivider();
         SetMouseRegion(MouseRegion.HandleReference);//, -3, 3, 6, -3 );

         uScriptGUIPanelScript.Instance.Draw();
      }
      EditorGUILayout.EndHorizontal();
   }

   void DrawGUIHorizontalDivider()
   {
      GUILayout.Box("", uScriptGUIStyle.hDivider, GUILayout.Height(uScriptGUI.panelDividerThickness), GUILayout.ExpandWidth(true));
   }

   void DrawGUIVerticalDivider()
   {
      GUILayout.Box("", uScriptGUIStyle.vDivider, GUILayout.Width(uScriptGUI.panelDividerThickness), GUILayout.ExpandHeight(true));
   }

//   int counter = 0;

   void OnGUI_DrawStatusbar()
   {
      Event e = Event.current;

      if (GUI.tooltip != _statusbarMessage || e.type == EventType.MouseMove)
      {
         _statusbarMessage = GUI.tooltip;
      }

      if (uScript.IsDevelopmentBuild == false)
      {
         GUILayout.Label(_statusbarMessage, GUILayout.ExpandWidth(true));
      }
      else
      {
         // Get mouse position and region
         string extraDetails = ((int)e.mousePosition.x).ToString() + ", "
                               + ((int)e.mousePosition.y).ToString()
                               + " (" + _mouseRegion.ToString() + ")";

         // Get button state
         if (Control.MouseButtons.Buttons != 0)
         {
            extraDetails = (Control.MouseButtons.Buttons == MouseButtons.Left ? "Left-Click"
                            : Control.MouseButtons.Buttons == MouseButtons.Middle ? "Middle-Click"
                            : "Right-Click")
                           + " :: " + extraDetails;
         }

         // Get modifiers
         if (e.modifiers != 0)
         {
            extraDetails = e.modifiers.ToString().Replace(",", " +")
                           + (Control.MouseButtons.Buttons != 0 ? " + " : " :: ")
                           + extraDetails;
         }

//         extraDetails = "Counter: " + (int)(counter++ / 50) + " - " + extraDetails;

         EditorGUILayout.BeginHorizontal();
         {
            GUILayout.Label("#" + GUIUtility.keyboardControl
               + "\t\t[" + GUI.GetNameOfFocusedControl() + "]"
               + "\t\t" + _statusbarMessage, GUILayout.ExpandWidth(true));
//            GUILayout.Label(_statusbarMessage, GUILayout.ExpandWidth(true));
            GUILayout.Label(extraDetails, GUILayout.ExpandWidth(false));
         }
         EditorGUILayout.EndHorizontal();
      }
   }


   void DrawGraphContentsPanel()
   {
      paletteRect = EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, GUILayout.Width(uScriptGUI.panelLeftWidth));
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
         {
            string[] options = new string[] { "Toolbox", "Contents" };

            Vector2 size = uScriptGUIStyle.panelTitleDropDown.CalcSize(new GUIContent(options[1]));

            _paletteMode = EditorGUILayout.Popup(_paletteMode, options, uScriptGUIStyle.panelTitleDropDown, GUILayout.Width(size.x));

            //            GUILayout.Label("Nodes", uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));

            GUILayout.FlexibleSpace();

            if (_paletteMode == 0)
            {
            }
            else
            {
               // This is where the Graph Contents toolbar buttons will go

               GUI.SetNextControlName("FilterSearch");
               string _filterText = uScriptGUI.ToolbarSearchField(_graphListFilterText, GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
               GUI.SetNextControlName("");
               if (_filterText != _graphListFilterText)
               {
                  // Drop focus if the user inserted a newline (hit enter)
                  if (_filterText.Contains('\n'))
                  {
                     GUIUtility.keyboardControl = 0;
                  }

                  // Trim leading whitespace
                  _filterText = _filterText.TrimStart(new char[] { ' ' });

                  _graphListFilterText = _filterText;
               }
            }
         }
         EditorGUILayout.EndHorizontal();


         // Draw the contents
         //
         if (m_CanvasDragging && Preferences.DrawPanelsOnUpdate == false)
         {
            _wasMoving = true;

            // Hide the panels while the canvas is moving
            string message =
               "The " + (_paletteMode == 0 ? "Node Palette" : "Graph Contents") + " panel is not drawn while the canvas is updated.\n\nThe drawing can be enabled via the Preferences panel, although canvas performance may be affected.";

            GUILayout.Label(message, uScriptGUIStyle.panelMessage, GUILayout.ExpandHeight(true));
         }
         else
         {
            int filterMatches = 0;

            if (_paletteMode == 0)
            {
            }
            else
            {
               //
               // Graph Contents list
               //
               // Every node in the graph should be listed here, categorized by type.
               //

               // Process all nodes and place them in the appropriate list
               Dictionary<string, Dictionary<string, List<DisplayNode>>> categories = new Dictionary<string, Dictionary<string, List<DisplayNode>>>();

               DisplayNode displayNode;
               string category;
               string name;
               string comment;

               categories.Add("Comments", new Dictionary<string, List<DisplayNode>>());
               categories.Add("Actions", new Dictionary<string, List<DisplayNode>>());
               categories.Add("Conditions", new Dictionary<string, List<DisplayNode>>());
               categories.Add("Events", new Dictionary<string, List<DisplayNode>>());
               categories.Add("Properties", new Dictionary<string, List<DisplayNode>>());
               categories.Add("Variables", new Dictionary<string, List<DisplayNode>>());
               categories.Add("Miscellaneous", new Dictionary<string, List<DisplayNode>>());

               if (_foldoutsGraphContent.Count == 0)
               {
                  foreach (KeyValuePair<string, Dictionary<string, List<DisplayNode>>> kvpCategory in categories)
                  {
                     // Default each foldout to "expanded"
                     _foldoutsGraphContent.Add(kvpCategory.Key, true);
                  }
               }

               // @TODO: clean up this code

               foreach (Node node in m_ScriptEditorCtrl.FlowChart.Nodes)
               {
                  displayNode = node as DisplayNode;
                  category = string.Empty;
                  name = string.Empty;
                  comment = string.Empty;

                  if (displayNode is EntityEventDisplayNode)
                  {
                     category = "Events";
                     name = ((EntityEventDisplayNode)displayNode).EntityEvent.FriendlyType;
                     comment = ((EntityEventDisplayNode)displayNode).EntityEvent.Comment.Default;
                  }
                  else if (displayNode is LogicNodeDisplayNode)
                  {
                     category = "Actions";
                     name = ((LogicNodeDisplayNode)displayNode).LogicNode.FriendlyName;
                     comment = ((LogicNodeDisplayNode)displayNode).LogicNode.Comment.Default;
                  }
                  else if (displayNode is LocalNodeDisplayNode)
                  {
                     category = "Variables";
                     name = ((LocalNodeDisplayNode)displayNode).LocalNode.Value.Type; // get FriendlyName
                     name = uScriptConfig.Variable.FriendlyName(name).Replace("UnityEngine.", string.Empty);
                     name = name + " (" + (name == "String" ? "\"" + ((LocalNodeDisplayNode)displayNode).LocalNode.Value.Default + "\"" : ((LocalNodeDisplayNode)displayNode).LocalNode.Value.Default) + ")";
                     comment = ((LocalNodeDisplayNode)displayNode).LocalNode.Name.Default;
                  }
                  else if (displayNode is OwnerConnectionDisplayNode)
                  {
                     category = "Variables";
                     name = "Owner GameObject";
//                     comment = ((OwnerConnectionDisplayNode)displayNode).OwnerConnection.Instance.FriendlyName;
                  }
                  else if (displayNode is CommentDisplayNode)
                  {
                     category = "Comments";
                     name = ((CommentDisplayNode)displayNode).Comment.TitleText.FriendlyName;
                     comment = ((CommentDisplayNode)displayNode).Comment.TitleText.Default;
                  }
                  else if (displayNode is EntityPropertyDisplayNode)
                  {
                     category = "Properties";
                     name = ((EntityPropertyDisplayNode)displayNode).DisplayName.Replace("\n", ": ");
                     comment = ((EntityPropertyDisplayNode)displayNode).DisplayValue;
                  }
                  else
                  {
                     category = "Miscellaneous";
                  }

                  // Validate strings
                  name = (String.IsNullOrEmpty(name) ? "UNKNOWN" : name);
                  comment = (String.IsNullOrEmpty(comment) ? string.Empty : " (" + comment + ")");

                  string fullName = name + comment;

                  if (String.IsNullOrEmpty(_graphListFilterText) || fullName.ToLower().Contains(_graphListFilterText.ToLower()))
                  {
                     filterMatches++;

                     if (categories[category].ContainsKey(name) == false)
                     {
                        categories[category].Add(name, new List<DisplayNode>());
                     }

                     // Add the node to the list
                     categories[category][name].Add(displayNode);
                  }
               }

               _guiPanelPalette_ScrollPos = EditorGUILayout.BeginScrollView(_guiPanelPalette_ScrollPos, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview", GUILayout.ExpandWidth(true));
               {
                  GUIContent nodeButtonContent = new GUIContent(string.Empty, "Click to select node. Shift-click to toggle the selection.");

                  foreach (KeyValuePair<string, Dictionary<string, List<DisplayNode>>> kvpCategory in categories)
                  {
                     if (kvpCategory.Value.Count > 0)
                     {
                        // The category contains at least one item to show

                        // This is should be a folding menu item that contains more buttons
                        GUIStyle tmpStyle = new GUIStyle(uScriptGUIStyle.paletteFoldout);
                        tmpStyle.margin = new RectOffset(tmpStyle.margin.left + (0 * 12), 0, 0, 0);

                        _foldoutsGraphContent[kvpCategory.Key] = GUILayout.Toggle(_foldoutsGraphContent[kvpCategory.Key], kvpCategory.Key, tmpStyle);
                        if (_foldoutsGraphContent[kvpCategory.Key])
                        {
                           List<string> nodeList = kvpCategory.Value.Keys.ToList();
                           nodeList.Sort();

                           foreach (string s in nodeList)
                           {
                              List<DisplayNode> dnList = kvpCategory.Value[s];

                              // Show each node
                              foreach (DisplayNode dn in dnList)
                              {
                                 // Get the name and comment strings
                                 name = string.Empty;
                                 comment = string.Empty;

                                 if (dn is EntityEventDisplayNode)
                                 {
                                    name = ((EntityEventDisplayNode)dn).EntityEvent.FriendlyType;
                                    comment = ((EntityEventDisplayNode)dn).EntityEvent.Comment.Default;
                                 }
                                 else if (dn is LogicNodeDisplayNode)
                                 {
                                    name = ((LogicNodeDisplayNode)dn).LogicNode.FriendlyName;
                                    comment = ((LogicNodeDisplayNode)dn).LogicNode.Comment.Default;
                                 }
                                 else if (dn is LocalNodeDisplayNode)
                                 {
                                    name = ((LocalNodeDisplayNode)dn).LocalNode.Value.Type; // get FriendlyName
                                    name = uScriptConfig.Variable.FriendlyName(name).Replace("UnityEngine.", string.Empty);
                                    name = name + " (" + (name == "String" ? "\"" + ((LocalNodeDisplayNode)dn).LocalNode.Value.Default + "\"" : ((LocalNodeDisplayNode)dn).LocalNode.Value.Default) + ")";
                                    comment = ((LocalNodeDisplayNode)dn).LocalNode.Name.Default;
                                 }
                                 else if (dn is OwnerConnectionDisplayNode)
                                 {
                                    category = "Variables";
                                    name = "Owner GameObject";
//                                    comment = ((OwnerConnectionDisplayNode)dn).OwnerConnection.Instance.FriendlyName;
                                 }
                                 else if (dn is CommentDisplayNode)
                                 {
                                    name = ((CommentDisplayNode)dn).Comment.TitleText.FriendlyName;
                                    comment = ((CommentDisplayNode)dn).Comment.TitleText.Default;
                                 }
                                 else if (dn is EntityPropertyDisplayNode)
                                 {
                                    category = "Properties";
                                    name = ((EntityPropertyDisplayNode)dn).DisplayName.Replace("\n", ": ");
                                    comment = ((EntityPropertyDisplayNode)dn).DisplayValue;
                                 }

                                 // Validate strings
                                 name = (String.IsNullOrEmpty(name) ? "UNKNOWN" : name);
                                 comment = (String.IsNullOrEmpty(comment) ? string.Empty : " (" + comment + ")");

                                 GUILayout.BeginHorizontal();
                                 {
                                    if (Event.current.type == EventType.Repaint)
                                    {
                                       nodeButtonContent.text = name + comment;
                                    }


                                    UnityEngine.Color tmpColor = GUI.color;
                                    UnityEngine.Color textColor = uScriptGUIStyle.nodeButtonLeft.normal.textColor;

                                    if (IsNodeTypeDeprecated(dn.EntityNode) || m_ScriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(dn.EntityNode))
                                    {
                                       GUI.color = new UnityEngine.Color(1, 0.5f, 1, 1);
                                       uScriptGUIStyle.nodeButtonLeft.normal.textColor = UnityEngine.Color.white;
                                    }

                                    bool selected = dn.Selected;
                                    selected = GUILayout.Toggle(selected, nodeButtonContent, uScriptGUIStyle.nodeButtonLeft);
                                    if (selected != dn.Selected)
                                    {
                                       // is the shift key modifier being used?
                                       if (Event.current.modifiers != EventModifiers.Shift)
                                       {
                                          // clear all selected nodes first
                                          m_ScriptEditorCtrl.DeselectAll();
                                       }
                                       // toggle the clicked node
                                       m_ScriptEditorCtrl.ToggleNode(dn.Guid);
                                    }


                                    GUI.color = tmpColor;
                                    uScriptGUIStyle.nodeButtonLeft.normal.textColor = textColor;


                                    if (IsNodeTypeDeprecated(dn.EntityNode) == false && m_ScriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(dn.EntityNode))
                                    {
                                       if ( true == m_ScriptEditorCtrl.ScriptEditor.CanUpgradeNode(dn.EntityNode) )
                                       {
                                          if (GUILayout.Button(uScriptGUIContent.buttonNodeUpgrade, uScriptGUIStyle.nodeButtonMiddle, GUILayout.Width(20)))
                                          {
                                             System.EventHandler Click = new System.EventHandler(m_ScriptEditorCtrl.m_MenuUpgradeNode_Click);
                                             if (Click != null)
                                             {
                                                // clear all selected nodes first
                                                m_ScriptEditorCtrl.DeselectAll();
                                                // toggle the clicked node
                                                m_ScriptEditorCtrl.ToggleNode(dn.Guid);
                                                Click(this, new EventArgs());
                                             }
                                          }
                                       }
                                       else
                                       {
                                          if (GUILayout.Button(uScriptGUIContent.buttonNodeDeleteMissing, uScriptGUIStyle.nodeButtonMiddle, GUILayout.Width(20)))
                                          {
                                             System.EventHandler Click = new System.EventHandler(m_ScriptEditorCtrl.m_MenuDeleteMissingNode_Click);
                                             if (Click != null)
                                             {
                                                // clear all selected nodes first
                                                m_ScriptEditorCtrl.DeselectAll();
                                                // toggle the clicked node
                                                m_ScriptEditorCtrl.ToggleNode(dn.Guid);
                                                Click(this, new EventArgs());
                                             }
                                          }
                                       }
                                    }

                                    if (GUILayout.Button(uScriptGUIContent.buttonNodeFind, uScriptGUIStyle.nodeButtonRight, GUILayout.Width(20)))
                                    {
                                       uScript.Instance.ScriptEditorCtrl.CenterOnNode(uScript.Instance.ScriptEditorCtrl.GetNode(dn.Guid));
                                    }

                                 }
                                 GUILayout.EndHorizontal();
                              }
                           }
                        }
                     }
                  }

                  if (filterMatches == 0)
                  {
                     GUILayout.Label("The search found no matches!", uScriptGUIStyle.panelMessageBold);
                  }
               }
               EditorGUILayout.EndScrollView();
            }
         }
      }
      EditorGUILayout.EndVertical();

      if ((int)paletteRect.width != 0 && (int)paletteRect.width != uScriptGUI.panelLeftWidth)
      {
         uScriptGUI.panelLeftWidth = (int)paletteRect.width;
      }
   }


   Dictionary<string, bool> _foldoutsGraphContent = new Dictionary<string, bool>();

   public Rect paletteRect = new Rect();

   void DrawGUIPalette()
   {
      if (_paletteMode == 0)
      {
         uScriptGUIPanelPalette.Instance.Draw();
      }
      else
      {
         DrawGraphContentsPanel();
      }  // if (_paletteMode != 0)

      SetMouseRegion(MouseRegion.Palette);//, 1, 1, -4, -4 );
   }





   public void SetMouseRegion(MouseRegion region)
   {
      if (Event.current.type == EventType.Repaint)
      {
         _mouseRegionRect[region] = GUILayoutUtility.GetLastRect();
      }

      if (isContextMenuOpen || isFileMenuOpen)
      {
         return;
      }

      if (_mouseRegionRect.ContainsKey(region))
      {
         if (GUI.enabled)
         {
            switch (region)
            {
               case MouseRegion.HandleCanvas:
                  EditorGUIUtility.AddCursorRect(_mouseRegionRect[region], MouseCursor.ResizeVertical);
                  break;
               case MouseRegion.HandlePalette:
               case MouseRegion.HandleProperties:
               case MouseRegion.HandleReference:
                  EditorGUIUtility.AddCursorRect(_mouseRegionRect[region], MouseCursor.ResizeHorizontal);
                  break;
            }
         }
      }
   }

   bool HiddenRegion(MouseRegion region)
   {
      if (!uScriptGUI.panelsHidden) return false;

      return region != uScript.MouseRegion.Canvas && region != uScript.MouseRegion.Outside;
   }

   void CalculateMouseRegion()
   {
      foreach (KeyValuePair<MouseRegion, Rect> kvp in _mouseRegionRect)
      {
         if (kvp.Value.Contains(Event.current.mousePosition) && !HiddenRegion(kvp.Key))
         {
            _mouseRegionUpdate = kvp.Key;
            break;
            //EditorGUIUtility.DrawColorSwatch(_mouseRegionRect[region], UnityEngine.Color.cyan);
         }
      }
   }




   public void RefreshScript()
   {
      string relativePath = "Assets\\" + m_FullPath.Substring(UnityEngine.Application.dataPath.Length + 1);
      String fileName = System.IO.Path.GetFileNameWithoutExtension(relativePath);

      relativePath = System.IO.Path.GetDirectoryName(relativePath);
      relativePath = relativePath.Replace('\\', '/');

      string logicPath = relativePath + "/" + fileName + uScriptConfig.Files.GeneratedCodeExtension + ".cs";
      string wrapperPath = relativePath + "/" + fileName + uScriptConfig.Files.GeneratedComponentExtension + ".cs";

      uScriptDebug.Log("refreshing " + logicPath);
      uScriptDebug.Log("refreshing " + wrapperPath);

      AssetDatabase.ImportAsset(logicPath, ImportAssetOptions.ForceUpdate);
      AssetDatabase.ImportAsset(wrapperPath, ImportAssetOptions.ForceUpdate);
      AssetDatabase.Refresh();
   }


   bool _isFileMenuOpen = false;
   public bool isFileMenuOpen
   {
      get { return _isFileMenuOpen; }
      set
      {
         if (_isFileMenuOpen != value)
         {
            _isFileMenuOpen = value;
            Event.current.Use();
         }
      }
   }




   void DrawMenuItemShortcut(string shortcut)
   {
      if (string.IsNullOrEmpty(shortcut))
      {
         return;
      }

      Rect r = GUILayoutUtility.GetLastRect();
      Vector2 v = EditorStyles.miniButton.CalcSize(new GUIContent("ALT+W"));

      // place the string at the left inside edge of the previous rect
      r = new Rect(r.x + r.width - v.x - 8, r.y + ((int)(r.height - v.y) / 2), v.x, v.y);

      GUI.Label(r, shortcut, EditorStyles.miniButton);
   }


   void DrawFileMenuWindow(int windowID)
   {
      Vector2 v1 = uScriptGUIStyle.menuDropDownButton.CalcSize(uScriptGUIContent.buttonScriptExportPNG);
      Vector2 v2 = EditorStyles.miniButton.CalcSize(new GUIContent("ALT+W"));

      GUILayout.BeginVertical(GUILayout.Width(v1.x + 16 + v2.x));
      {
         if (GUILayout.Button(uScriptGUIContent.buttonScriptNew, uScriptGUIStyle.menuDropDownButton))
         {
            FileMenuItem_New();
         }
         DrawMenuItemShortcut("ALT+N");
   
         if (GUILayout.Button(uScriptGUIContent.buttonScriptOpen, uScriptGUIStyle.menuDropDownButton))
         {
            FileMenuItem_Open();
         }
         DrawMenuItemShortcut("ALT+O");
   
         if (GUILayout.Button(uScriptGUIContent.buttonScriptSave, uScriptGUIStyle.menuDropDownButton))
         {
            FileMenuItem_Save();
         }
         DrawMenuItemShortcut("ALT+S");
   
         if (GUILayout.Button(uScriptGUIContent.buttonScriptSaveAs, uScriptGUIStyle.menuDropDownButton))
         {
            FileMenuItem_SaveAs();
         }
         DrawMenuItemShortcut("ALT+A");
   
         if (GUILayout.Button(uScriptGUIContent.buttonScriptSaveQuick, uScriptGUIStyle.menuDropDownButton))
         {
            FileMenuItem_QuickSave();
         }
         DrawMenuItemShortcut("ALT+Q");
   
         if (GUILayout.Button(uScriptGUIContent.buttonScriptSaveDebug, uScriptGUIStyle.menuDropDownButton))
         {
            FileMenuItem_DebugSave();
         }
         DrawMenuItemShortcut("ALT+D");
   
         if (GUILayout.Button(uScriptGUIContent.buttonScriptSaveRelease, uScriptGUIStyle.menuDropDownButton))
         {
            FileMenuItem_ReleaseSave();
         }
         DrawMenuItemShortcut("ALT+R");
   
         uScriptGUI.HR();
   
         if (GUILayout.Button(uScriptGUIContent.buttonScriptExportPNG, uScriptGUIStyle.menuDropDownButton))
         {
            FileMenuItem_ExportPNG();
         }
         DrawMenuItemShortcut("ALT+E");

         if (GUILayout.Button(uScriptGUIContent.buttonScriptUpgradeNodes, uScriptGUIStyle.menuDropDownButton))
         {
            FileMenuItem_UpgradeDeprecatedNodes();
         }
   
         uScriptGUI.HR();
   
         if (GUILayout.Button(uScriptGUIContent.buttonScriptsRebuildAll, uScriptGUIStyle.menuDropDownButton))
         {
            FileMenuItem_RebuildAll();
         }
   
         if (GUILayout.Button(uScriptGUIContent.buttonScriptsRemoveGenerated, uScriptGUIStyle.menuDropDownButton))
         {
            FileMenuItem_Clean();
         }
      }
      GUILayout.EndVertical();
   }

   void FileMenuItem_New()
   {
      if (AllowNewFile(true))
      {
         NewScript();
      }
      isFileMenuOpen = false;
   }

   void FileMenuItem_Open()
   {
      string path = EditorUtility.OpenFilePanel("Open uScript", Preferences.UserScripts, "uscript");
      if (path.Length > 0)
      {
         OpenScript(path);
      }
      isFileMenuOpen = false;
   }

   private bool SaveDenied( )
   {
      if (EditorApplication.isPlayingOrWillChangePlaymode)
      {
         EditorUtility.DisplayDialog("Unable to save", "The Unity Editor is in play mode, and the uScript graph cannot be saved at this time.", "Okay");
         return true;
      }

      return false;
   }

   public void RequestSave(bool quick, bool debug, bool rename)
   {
      if (false == SaveDenied( ) )
      {
         if (quick)
         {
   //         Debug.Log("QUICK SAVE\n");
            SaveScript(rename, false);
         }
         else
         {
   //         Debug.Log(debug ? "DEBUG SAVE\n" : "RELEASE SAVE\n");
            bool saved = false;
            GenerateDebugInfo = debug;
   
            AssetDatabase.StartAssetEditing();
            saved = SaveScript(rename);
            AssetDatabase.StopAssetEditing();
   
            GenerateDebugInfo = Preferences.SaveMethod != Preferences.SaveMethodType.Release;

            if (saved) RefreshScript();
         }
      }
      isFileMenuOpen = false;
   }

   void FileMenuItem_Save()
   {
      RequestSave(Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
                  Preferences.SaveMethod == Preferences.SaveMethodType.Debug, false);
   }

   void FileMenuItem_SaveAs()
   {
      RequestSave(Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
                  Preferences.SaveMethod == Preferences.SaveMethodType.Debug, true);
   }

   void FileMenuItem_QuickSave()
   {
      RequestSave(true, false, false);
   }

   void FileMenuItem_DebugSave()
   {
      RequestSave(false, true, false);
   }

   void FileMenuItem_ReleaseSave()
   {
      RequestSave(false, false, false);
   }

   void FileMenuItem_ExportPNG()
   {
      uScriptExportPNG.Start();
      isFileMenuOpen = false;
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
               if ( true == m_ScriptEditorCtrl.ScriptEditor.CanUpgradeNode(dn.EntityNode) )
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

      isFileMenuOpen = false;
   }

   void FileMenuItem_RebuildAll()
   {
      RebuildAllScripts();
      isFileMenuOpen = false;
   }

   void FileMenuItem_Clean()
   {
      AssetDatabase.StartAssetEditing();
      StubGeneratedCode(Preferences.UserScripts);
      AssetDatabase.StopAssetEditing();
      AssetDatabase.Refresh();
      isFileMenuOpen = false;
   }


   void DrawGUIContent()
   {
      Rect rect = EditorGUILayout.BeginVertical();
      {
         // Toolbar
         //
         Rect toolbarRect = EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            if (toolbarRect.width != 0 && toolbarRect.height != 0)
            {
               m_NodeToolbarRect = toolbarRect;
            }

            isFileMenuOpen = GUILayout.Toggle(isFileMenuOpen, "File Menu", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false));
            if (Event.current.type == EventType.Repaint)
            {
               rectFileMenuButton = GUILayoutUtility.GetLastRect();
               rectFileMenuWindow.x = rectFileMenuButton.x;
               rectFileMenuWindow.y = rectFileMenuButton.y + rectFileMenuButton.height;
            }

            if (GUILayout.Button(uScriptGUIContent.buttonPreferences, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
            {
               PreferenceWindow.Init();
            }

            GUILayout.FlexibleSpace();

            GUILayout.Label("Save Method:", uScriptGUIStyle.toolbarLabel);
            Preferences.SaveMethodType newMethod = (Preferences.SaveMethodType)EditorGUILayout.EnumPopup(Preferences.SaveMethod, EditorStyles.toolbarDropDown, GUILayout.Width(uScriptGUI.SaveMethodPopupWidth));
            if (newMethod != Preferences.SaveMethod)
            {
               Preferences.SaveMethod = newMethod;
               Preferences.Save();
               GenerateDebugInfo = Preferences.SaveMethod != Preferences.SaveMethodType.Release;
            }

            GUILayout.FlexibleSpace();

            GUILayout.Label(FullVersionName, uScriptGUIStyle.toolbarLabel);
         }
         EditorGUILayout.EndHorizontal();

         GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
         {
            // Canvas
            //
            if (rect.width != 0 && rect.height != 0)
            {
               m_NodeWindowRect = rect;
            }

            GUIStyle style = new GUIStyle();
            style.normal.background = uScriptConfig.canvasBackgroundTexture;

            GUI.SetNextControlName("MainView");

            _guiContentScrollPos = EditorGUILayout.BeginScrollView(_guiContentScrollPos, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, style, GUILayout.ExpandWidth(true));
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
               //            int canvasWidth = (_mouseRegionRect.ContainsKey(MouseRegion.Canvas) ? (int)(_mouseRegionRect[MouseRegion.Canvas].width) : 0);
               //            int canvasHeight = (_mouseRegionRect.ContainsKey(MouseRegion.Canvas) ? (int)(_mouseRegionRect[MouseRegion.Canvas].height-18) : 0);
               //
               //            GUILayout.Box(string.Empty, style, GUILayout.Width(canvasWidth), GUILayout.Height(canvasHeight));

               // Paint the graph (nodes, sockets, links, and comments)
               PaintEventArgs args = new PaintEventArgs();
               args.Graphics = new Detox.Drawing.Graphics();

               if (m_ScriptEditorCtrl != null) 
               {
                  m_ScriptEditorCtrl.FlowChart.Zoom      = m_MapScale;
                  m_ScriptEditorCtrl.FlowChart.ZoomPoint = m_ZoomPoint;

                  m_ScriptEditorCtrl.GuiPaint(args);
               }
            }
            EditorGUILayout.EndScrollView();

            GUI.SetNextControlName("");
         }
         GUILayout.EndVertical();

         if (Event.current.type == EventType.Repaint)
         {
            _canvasRect = GUILayoutUtility.GetLastRect();
         }
      }
      EditorGUILayout.EndVertical();

      SetMouseRegion(MouseRegion.Canvas);//, 3, 1, -2, -4 );
   }


   // TEMP Variables for testing the new property grid methods
   Rect _svRect;

   KeyCode[] _arrayKeyCode;
   bool _arrayFoldoutBool;

   public static int _paletteMode = 0;
   bool _wasMoving = false;

   Vector2 _scrollNewProperties;
   // END TEMP Variables





   void m_ScriptEditorCtrl_ScriptModified(object sender, EventArgs e)
   {
      RequestRepaint();
   }



   void DrawContextMenuWindow(int windowID)
   {
      GUI.depth = 0;
      if (null == m_CurrentMenu)
      {
         foreach (ToolStripItem item in m_ScriptEditorCtrl.ContextMenu.Items.Items)
         {
            if (item.Text == "<hr>")
            {
               uScriptGUI.HR();
            }
            else
            {
               if (GUILayout.Button(item.Text.Replace("&", ""), uScriptGUIStyle.menuContextButton))
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

   public string FindFile(string path, string fileName)
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);

      System.IO.FileInfo[] files = directory.GetFiles();

      foreach (System.IO.FileInfo file in files)
      {
         if (file.Name == fileName)
         {
            return file.FullName;
         }
      }

      foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
      {
         string result = FindFile(subDirectory.FullName, fileName);
         if (result != "") return result;
      }

      return "";
   }

   private string[] FindAllFiles(string rootPath, string extension)
   {
      List<string> paths = new List<string>();

      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(rootPath);

      System.IO.FileInfo[] files = directory.GetFiles();

      foreach (System.IO.FileInfo file in files)
      {
         if (file.Extension == extension)
         {
            paths.Add(file.FullName);
         }
      }

      foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
      {
         string[] results = FindAllFiles(subDirectory.FullName, extension);
         paths.AddRange(results);
      }

      return paths.ToArray();
   }


   private void DrawSubItems(ToolStripMenuItem menuItem)
   {
      if (null == menuItem) return;

      foreach (ToolStripItem item in menuItem.DropDownItems.Items)
      {
         if (GUILayout.Button(item.Text.Replace("&", ""), uScriptGUIStyle.menuContextButton))
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

      Detox.Windows.Forms.Cursor.Position.X = m_MouseDownArgs.X;
      Detox.Windows.Forms.Cursor.Position.Y = m_MouseDownArgs.Y;

//      Debug.Log("BUTTON " + Control.MouseButtons.Buttons + " - OnMouseDown() at " + Detox.Windows.Forms.Cursor.Position.ToString() + "\n");

      m_ScriptEditorCtrl.OnMouseDown(m_MouseDownArgs);
   }

   public void OnMouseUp()
   {
      Detox.Windows.Forms.Cursor.Position.X = m_MouseUpArgs.X;
      Detox.Windows.Forms.Cursor.Position.Y = m_MouseUpArgs.Y;

//      Debug.Log("BUTTON " + Control.MouseButtons.Buttons + " - OnMouseUp() at " + Detox.Windows.Forms.Cursor.Position.ToString() + "\n");

      m_ScriptEditorCtrl.OnMouseUp(m_MouseUpArgs);

      m_CurrentCanvasPosition = m_ScriptEditorCtrl.FlowChart.Location.X.ToString() + "," + m_ScriptEditorCtrl.FlowChart.Location.Y.ToString();
      if (!String.IsNullOrEmpty(m_FullPath))
      {
         SetSetting("uScript\\" + uScriptConfig.ConstantPaths.RelativePath(m_FullPath) + "\\CanvasPosition", m_CurrentCanvasPosition);
      }

      Control.MouseButtons.Buttons = 0;
   }

   static int lastMouseX = 0;
   static int lastMouseY = 0;
   
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

      Detox.Windows.Forms.Cursor.Position.X = m_MouseMoveArgs.X;
      Detox.Windows.Forms.Cursor.Position.Y = m_MouseMoveArgs.Y;

      if (_mouseRegion == MouseRegion.Canvas)
      {
         m_ScriptEditorCtrl.OnMouseMove(m_MouseMoveArgs);
      }

      // convert back to screen
      m_MouseMoveArgs.X += (int)_canvasRect.x;
      m_MouseMoveArgs.Y += (int)_canvasRect.y;

      // check for divider draggging
      if (GUI.enabled && !uScriptGUI.panelsHidden && m_MouseDown)
      {
         if (m_MouseDownRegion == MouseRegion.HandleCanvas && deltaY != 0)
         {
            uScriptGUI.panelPropertiesHeight -= deltaY;
            RequestRepaint();
         }
         else if (m_MouseDownRegion == MouseRegion.HandlePalette && deltaX != 0)
         {
            uScriptGUI.panelLeftWidth += deltaX;
            RequestRepaint();
         }
         else if (m_MouseDownRegion == MouseRegion.HandleProperties && deltaX != 0)
         {
            uScriptGUI.panelPropertiesWidth += deltaX;
            RequestRepaint();
         }
         else if (m_MouseDownRegion == MouseRegion.HandleReference && deltaX != 0)
         {
            uScriptGUI.panelScriptsWidth -= deltaX;
            RequestRepaint();
         }
      }
   }


   private static bool _wasRepaintRequested;
   public static void RequestRepaint()
   {
      _wasRepaintRequested = true;
   }

//   public void Redraw()
//   {
//      if (true == m_Repainting) return;
//
//      m_Repainting = true;
//
//      Repaint();
//
//      m_Repainting = false;
//   }

   private bool AllowNewFile(bool allowCancel)
   {
      if (m_ScriptEditorCtrl != null && true == m_ScriptEditorCtrl.IsDirty)
      {
         int result;

         if (true == allowCancel)
         {
            result = EditorUtility.DisplayDialogComplex("Save File?", m_ScriptEditorCtrl.ScriptEditor.Name + " has been modified, would you like to save?", "Yes", "No", "Cancel");
         }
         else
         {
            bool yes = EditorUtility.DisplayDialog("Save File?", m_ScriptEditorCtrl.ScriptEditor.Name + " has been modified, would you like to save?", "Yes", "No");

            if (true == yes) result = 0;
            else result = 1;
         }

         if (0 == result)
         {
            if ( true == SaveDenied( ) )
            {
               return false;
            }

            bool scriptSaved;

            AssetDatabase.StartAssetEditing();

            scriptSaved = SaveScript(false);

            AssetDatabase.StopAssetEditing();

            return scriptSaved;
         }

         //user did not want to clean file
         else if (1 == result) return true;

         //file was not cleaned
         else if (2 == result) return false;
      }

      //file was not dirty
      return true;
   }

   public void NewScript()
   {
      Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor(string.Empty, PopulateEntityTypes(null), PopulateLogicTypes());

      m_ScriptEditorCtrl = new ScriptEditorCtrl(scriptEditor);
      m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);

      m_ScriptEditorCtrl.BuildContextMenu();
      uScriptGUIPanelPalette.Instance.BuildPaletteMenu();

      //reset zoom we're not in some weird zoom state
      m_MapScale = 1.0f;

      CurrentScriptName = null;
 
      m_CurrentCanvasPosition = "";

      CurrentScriptDirty = false;
      CurrentScript = scriptEditor.ToBase64( null );
      CurrentScriptName = scriptEditor.Name;

      //brand new scriptso clear out any previous caches and undo/redo
      //ClearEntityTypes();
      //ClearLogicTypes();
      ClearChangeStack( );
      OpenFromCache( );
      
      m_FullPath = "";

      //Debug.Log("clearing" );
      uScript.SetSetting("uScript\\LastOpened", "");
      uScript.SetSetting("uScript\\LastScene", UnityEditor.EditorApplication.currentScene);
   }

   private void ClearEntityTypes()
   {
      m_EntityTypes = null;
      m_SzEntityTypes = null;
   }
   
   private void ClearLogicTypes()
   {
      m_LogicTypes  = null;
      m_SzLogicTypes = null;
   }

   public bool OpenScript(string fullPath)
   {
      if (false == AllowNewFile(true) || !System.IO.File.Exists(fullPath)) return false;

       Profile p = new Profile( "OpenScript " + fullPath );

      Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor("", null, null);
      scriptEditor.Open(fullPath);

      scriptEditor = new Detox.ScriptEditor.ScriptEditor("", PopulateEntityTypes(scriptEditor.Types), PopulateLogicTypes());
      
      if (true == scriptEditor.Open(fullPath))
      {
         if ("" != scriptEditor.SceneName && scriptEditor.SceneName != System.IO.Path.GetFileNameWithoutExtension(UnityEditor.EditorApplication.currentScene))
         {
            EditorUtility.DisplayDialog("uScript Scene Warning", "This uScript file was attached to the uScript Master GameObject in scene " + scriptEditor.SceneName + ".  " +
                                        "It may not be compatible with this scene or run correctly if edited while this scene is open.", "OK");
         }

         //reset zoom we're not in some weird zoom state
         m_MapScale = 1.0f;

         CurrentScriptName = null;

         if (fullPath != m_FullPath) m_CurrentCanvasPosition = "";

         m_FullPath = fullPath;

         uScript.SetSetting("uScript\\LastOpened", uScriptConfig.ConstantPaths.RelativePath(fullPath).Substring("Assets".Length));
         uScript.SetSetting("uScript\\LastScene", UnityEditor.EditorApplication.currentScene);

         m_CurrentCanvasPosition = (String)GetSetting("uScript\\" + uScriptConfig.ConstantPaths.RelativePath(m_FullPath) + "\\CanvasPosition", "");
    
         CurrentScriptDirty = false;
         CurrentScript = scriptEditor.ToBase64( null );
         CurrentScriptName = scriptEditor.Name;

         //brand new scriptso clear out any previous caches and undo/redo
         ClearChangeStack( );
         //ClearEntityTypes();
         //ClearLogicTypes();
         OpenFromCache( );

         uScriptBackgroundProcess.ForceFileRefresh();
      
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

   public void RebuildAllScripts()
   {
      //first remove everything so we get rid of any compiler errors
      //which allows the reflection to properly refresh
      AssetDatabase.StartAssetEditing();
      StubGeneratedCode(Preferences.UserScripts);
      AssetDatabase.StopAssetEditing();
      AssetDatabase.Refresh();

      m_RebuildWhenReady = true;
   }

   public void RebuildScripts(string path, bool stubCode)
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);

      System.IO.FileInfo[] files = directory.GetFiles();

      foreach (System.IO.FileInfo file in files)
      {
         if (".uscript" != file.Extension) continue;

         Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor("", null, null);
         scriptEditor.Open(file.FullName);

         scriptEditor = new Detox.ScriptEditor.ScriptEditor("", PopulateEntityTypes(scriptEditor.Types), PopulateLogicTypes());

         if (true == scriptEditor.Open(file.FullName))
         {
            if (true == SaveScript(scriptEditor, file.FullName, true, GenerateDebugInfo, stubCode))
            {
               uScriptDebug.Log("Rebuilt " + file.FullName);
            }
            else
            {
               uScriptDebug.Log("Could not save " + file.FullName, uScriptDebug.Type.Error);
            }
         }
      }

      foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
      {
         RebuildScripts(subDirectory.FullName, stubCode);
      }
   }

   private string GetGeneratedScriptPath(string binaryPath)
   {
      System.IO.Directory.CreateDirectory(Preferences.GeneratedScripts);

      string wrapperPath = Preferences.GeneratedScripts;

      String fileName = System.IO.Path.GetFileNameWithoutExtension(binaryPath);

      wrapperPath += "/" + fileName + uScriptConfig.Files.GeneratedComponentExtension + ".cs";
   
      return wrapperPath;
   }

   private string GetNestedScriptPath(string binaryPath)
   {
      System.IO.Directory.CreateDirectory(Preferences.NestedScripts);

      string logicPath = Preferences.NestedScripts;

      String fileName = System.IO.Path.GetFileNameWithoutExtension(binaryPath);

      logicPath += "/" + fileName + uScriptConfig.Files.GeneratedCodeExtension + ".cs";

      return logicPath;
   }

   private bool SaveScript(Detox.ScriptEditor.ScriptEditor script, string binaryPath, bool generateCode, bool generateDebugInfo, bool stubCode)
   {
      bool result;

      if ( true == generateCode )
      {
         string wrapperPath = GetGeneratedScriptPath(binaryPath);
         string logicPath   = GetNestedScriptPath(binaryPath);

         result = script.Save(binaryPath, logicPath, wrapperPath, generateDebugInfo, stubCode);

         if (true == result)
         {
            // refresh uScript panel file list
            uScriptBackgroundProcess.ForceFileRefresh();
         }
      }
      else
      {
         result = script.Save(binaryPath);
      }

      return result;
   }

   public bool SaveScript(bool forceNameRequest)
   {
      return SaveScript(forceNameRequest, true);
   }

   public bool SaveScript(bool forceNameRequest, bool generateCode)
   {
      Detox.ScriptEditor.ScriptEditor script = m_ScriptEditorCtrl.ScriptEditor;

      //no file of this name or force us to ask for the name
      if ("" == m_FullPath || true == forceNameRequest)
      {
         bool isSafe = false;
         string path = "Untitled.uScript";
         while (!isSafe && path != "")
         {
            path = EditorUtility.SaveFilePanel("Save uScript As", Preferences.UserScripts, script.Name, "uscript");
            if (path != "")
            {
               System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
               string safePath = UnityCSharpGenerator.MakeSyntaxSafe(fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".")), out isSafe);
               if (!isSafe)
               {
                  // filename is not safe - tell the user they need to change it
                  if (!EditorUtility.DisplayDialog("Invalid File Name", "Filename must be all alpha-numeric characters and must not start with a number. A suggested name for the one you entered is: " + safePath, "Try Again", "Cancel")) return false;
               }
            }
         }

         //early exit, they must have changed their minds
         if ("" == path) return false;

         m_FullPath = path;
         uScript.SetSetting("uScript\\LastOpened", uScriptConfig.ConstantPaths.RelativePath(m_FullPath).Substring("Assets".Length));
         uScript.SetSetting("uScript\\LastScene", UnityEditor.EditorApplication.currentScene);
      }

      if ("" != m_FullPath)
      {
         bool firstSave = false;
         string componentPath = GetGeneratedScriptPath(m_FullPath);

         //only attach if they're generating code and it's never been generated before
         //they could have saved without generating code by using quick save
         if (false == System.IO.File.Exists(componentPath) && true == generateCode)
         {
            firstSave = true;
         }
         else if (true == forceNameRequest && true == generateCode)
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
            pleaseAttachMe = EditorUtility.DisplayDialog("Assign uScript To Master GameObject?", "This uScript has not been assigned to the master game object yet. Would you like to assign it now?", "Yes", "No");
         }
         else
         {
            currentlyAttached = IsAttachedToMaster;
         }

         //if they do want to attach to the master then set
         //the scene name before we save
         if (true == pleaseAttachMe || true == currentlyAttached)
         {
            script.SceneName = System.IO.Path.GetFileNameWithoutExtension(UnityEditor.EditorApplication.currentScene);
         }
         else if (false == pleaseAttachMe && false == currentlyAttached)
         {
            //could be a save as, so make sure to clear the connection
            script.SceneName = "";
         }

         if (true == SaveScript(script, m_FullPath, generateCode, GenerateDebugInfo, false))
         {
            // When a file is saved (regardless of method), we should updated the
            // Dictionary cache for that script.
            //
            
            //script was saved under a new name, refresh the control
             if (script.Name != m_ScriptEditorCtrl.Name)
            {
                m_ScriptEditorCtrl = new Detox.ScriptEditor.ScriptEditorCtrl(script);
            }

            string scriptName = System.IO.Path.GetFileNameWithoutExtension(m_FullPath);
            SetStaleState(scriptName, script.GeneratedCodeIsStale);
            SetDebugState(scriptName, script.SavedForDebugging);

            m_ScriptEditorCtrl.IsDirty = false;

            CacheScript( );
            
            if (true == pleaseAttachMe)
            {
               AssetDatabase.Refresh();
               AttachToMasterGO(m_FullPath);
            }

            return true;
         }
         else
         {
            uScriptDebug.Log("there was an error saving " + m_FullPath, uScriptDebug.Type.Error);
         }
      }

      return false;
   }

   void AttachToMasterGO(String path)
   {
#if UNITY_EDITOR
      MasterComponent.AttachScriptToMaster(path);
#endif
   }

   void GatherDerivedTypes(Dictionary<Type, Type> uniqueNodes, string path, Type baseType)
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);

      System.IO.FileInfo[] files = directory.GetFiles();

      foreach (System.IO.FileInfo file in files)
      {
         if (file.Name.StartsWith(".") || file.Name.StartsWith("_") || !file.Name.EndsWith(".cs")) continue;

         Type type = uScript.MasterComponent.GetAssemblyQualifiedType(System.IO.Path.GetFileNameWithoutExtension(file.Name));

         if (null != type)
         {
            if (false == uniqueNodes.ContainsKey(type) &&
                 baseType.IsAssignableFrom(type))
            {
               uniqueNodes[type] = type;
            }
         }
      }

      foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
      {
         if (subDirectory.Name.StartsWith(".") || subDirectory.Name.StartsWith("_")) continue;

         GatherDerivedTypes(uniqueNodes, subDirectory.FullName, baseType);
      }
   }

   private LogicNode[] PopulateLogicTypes()
   {
      if ( null != m_LogicTypes ) return m_LogicTypes;

      uScriptDebug.Log( "Rebuilding Logic Types", uScriptDebug.Type.Debug );

      Hashtable baseMethods = new Hashtable();
      Hashtable baseEvents = new Hashtable();
      Hashtable baseProperties = new Hashtable();

      if ( null == m_SzLogicTypes )
      {
         uScriptDebug.Log( "Reparsing Logic Types", uScriptDebug.Type.Debug );

         Dictionary<Type, Type> uniqueNodes = new Dictionary<Type, Type>();

         GatherDerivedTypes(uniqueNodes, uScriptConfig.ConstantPaths.uScriptNodes, typeof(uScriptLogic));

         GatherDerivedTypes(uniqueNodes, Preferences.UserNodes, typeof(uScriptLogic));
         GatherDerivedTypes(uniqueNodes, Preferences.NestedScripts, typeof(uScriptLogic));
      
         m_SzLogicTypes = new string[ uniqueNodes.Values.Count ];

         int i = 0;

         foreach ( Type t in uniqueNodes.Values )
         {
            m_SzLogicTypes[ i++ ] = t.ToString();
         }
      }

      List<Type> types = new List<Type>();

      foreach ( string s in m_SzLogicTypes )
      {
         Type t = MasterComponent.GetType(s);
         if ( null != t ) types.Add( t );
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

      baseMethods["Start"]       = "Start";
      baseMethods["Update"]      = "Update";
      baseMethods["LateUpdate"]  = "LateUpdate";
      baseMethods["FixedUpdate"] = "FixedUpdate";
      baseMethods["OnGUI"]       = "OnGUI";

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
         MasterComponent.AddType(type);

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
         List<Parameter> logicEventParameters = new List<Parameter>( );

         foreach (EventInfo e in type.GetEvents())
         {
            Plug p;
            p.Name = e.Name;
            p.FriendlyName = FindFriendlyName(p.Name, e.GetCustomAttributes(false));

            if ( "" == logicNode.EventArgs )
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
                                 output.Type = eventProperty.PropertyType.ToString().Replace("&", "");
                                 output.Input  = false;
                                 output.Output = true;
                                 output.DefaultAsObject = FindDefaultValue("", eventProperty.GetCustomAttributes(false));

                                 MasterComponent.AddType(eventProperty.PropertyType);

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
               variable.Type = p.ParameterType.ToString().Replace("&", "");
               variable.FriendlyName = FindFriendlyName(p.Name, p.GetCustomAttributes(false));
               variable.DefaultAsObject = FindDefaultValue("", p.GetCustomAttributes(false));

               AddAssetPathField(type.ToString(), p.Name, p.GetCustomAttributes(false));
               AddParameterDescField(type.ToString(), p.Name, p.GetCustomAttributes(false));
               AddRequiresLink(type.ToString(), p.Name, p.GetCustomAttributes(false));

               MasterComponent.AddType(p.ParameterType);

               variables.Add(variable);
            }

            if (m.ReturnType != typeof(void))
            {
               Parameter parameter = new Parameter();
               parameter.Name = "Return";
               parameter.Type = m.ReturnType.ToString().Replace("&", "");
               parameter.Input = false;
               parameter.Output = true;
               parameter.Default = "";
               parameter.State = FindSocketState(m.GetCustomAttributes(false));
               parameter.FriendlyName = "Return Value";

               MasterComponent.AddType(m.ReturnType);

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

   RawScript[] GatherRawScripts()
   {
      List<RawScript> rawScripts = new List<RawScript>();

      string[] files = FindAllFiles(Preferences.UserScripts, ".uscript");

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

   static private Hashtable m_RawDescription = new Hashtable( );

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
         //omly use it if it exposes some type of external
         if ( rawScript.ExternalParameters.Length > 0 ||
              rawScript.ExternalInputs.Length     > 0 ||
              rawScript.ExternalOutputs.Length    > 0 ||
              rawScript.ExternalEvents.Length     > 0
            )
         {
            string friendlyName = rawScript.FriendlyName;
            if ( "" == friendlyName ) friendlyName = rawScript.Type;

            LogicNode logicNode = new LogicNode(rawScript.Type, friendlyName);
   
            logicNode.Parameters      = rawScript.ExternalParameters;
            logicNode.Inputs          = rawScript.ExternalInputs;
            logicNode.Outputs         = rawScript.ExternalOutputs;
            logicNode.Events          = rawScript.ExternalEvents;
            logicNode.Drivens         = rawScript.Drivens;
            logicNode.RequiredMethods = rawScript.RequiredMethods;
            logicNode.EventArgs       = rawScript.EventArgs;
            logicNode.EventParameters = rawScript.ExternalEventParameters;

            m_RawDescription[rawScript.Type] = rawScript.Description;

            returnNodes[rawScript.Type] = logicNode;
         }
         else
         {
            returnNodes.Remove( rawScript.Type );
         }
      }

      return returnNodes.Values.ToArray();
   }

   private void Reflect(Type type, List<EntityDesc> entityDescs, Hashtable baseMethods, Hashtable baseEvents, Hashtable baseProperties)
   {
      EntityDesc entityDesc = new EntityDesc();

      entityDesc.Type = type.ToString();
      MasterComponent.AddType(type);

      MethodInfo[] methodInfos = type.GetMethods();
      EventInfo[] eventInfos = type.GetEvents();
      PropertyInfo[] propertyInfos = type.GetProperties();
      FieldInfo[] fieldInfos = type.GetFields();

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
            parameter.Type = p.ParameterType.ToString().Replace("&", "");
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

            parameter.DefaultAsObject = FindDefaultValue("", p.GetCustomAttributes(false));

            AddAssetPathField(type.ToString(), p.Name, p.GetCustomAttributes(false));
            AddParameterDescField(type.ToString(), p.Name, p.GetCustomAttributes(false));
            AddRequiresLink(type.ToString(), p.Name, p.GetCustomAttributes(false));
            MasterComponent.AddType(p.ParameterType);

            parameters.Add(parameter);
         }

         if (m.ReturnType != typeof(void))
         {
            Parameter parameter = new Parameter();
            parameter.State = FindSocketState(m.GetCustomAttributes(false));
            parameter.Name = "Return";
            parameter.Type = m.ReturnType.ToString().Replace("&", "");
            parameter.Input = false;
            parameter.Output = true;
            parameter.Default = "";
            parameter.FriendlyName = "Return Value";

            MasterComponent.AddType(m.ReturnType);

            parameters.Add(parameter);
         }

         entityMethod.IsStatic   = m.IsStatic;
         entityMethod.Parameters = parameters.ToArray();
         entityMethods.Add(entityMethod);
      }

      entityDesc.Methods = entityMethods.ToArray();

      List<EntityEvent> entityEvents = new List<EntityEvent>();

      bool propertiesUsedForEvents = false;

      foreach (EventInfo e in eventInfos)
      {
         if (true == baseEvents.Contains(e.Name)) continue;

         List<Parameter> eventInputsOutpus = new List<Parameter>();

         //look for any set properties which will exist on the event
         //because we can't set them via method parameters
         foreach (PropertyInfo p in propertyInfos)
         {
            propertiesUsedForEvents = true;

            if (baseProperties.Contains(p.Name)) continue;

            if (p.GetSetMethod() != null)
            {
               //only input properties directly declared in this event
               //are valid to be set, otherwise this gets spammed
               //with every property of the class heirarchy
               if (p.DeclaringType == type)
               {
                  Parameter input = new Parameter();

                  //inputs to events can never be connected because there is no source to trigger
                  //them and push in the value
                  input.State = Parameter.VisibleState.Locked | Parameter.VisibleState.Hidden;
                  input.Name = p.Name;
                  input.Type = p.PropertyType.ToString().Replace("&", "");
                  input.Input = true;
                  input.Output = false;
                  input.DefaultAsObject = FindDefaultValue("", p.GetCustomAttributes(false));
                  input.FriendlyName = FindFriendlyName(p.Name, p.GetCustomAttributes(false));

                  AddAssetPathField(type.ToString(), p.Name, p.GetCustomAttributes(false));
                  AddParameterDescField(type.ToString(), p.Name, p.GetCustomAttributes(false));
                  AddRequiresLink(type.ToString(), p.Name, p.GetCustomAttributes(false));
                  MasterComponent.AddType(p.PropertyType);

                  eventInputsOutpus.Add(input);
               }
            }
         }

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
                           output.Type = eventProperty.PropertyType.ToString().Replace("&", "");
                           output.Input = false;
                           output.Output = true;
                           output.DefaultAsObject = FindDefaultValue("", eventProperty.GetCustomAttributes(false));

                           MasterComponent.AddType(eventProperty.PropertyType);

                           eventInputsOutpus.Add(output);

                           AddParameterDescField(type.ToString(), eventProperty.Name, eventProperty.GetCustomAttributes(false));
                        }
                     }
                  }

                  //break after Invoke parameter, it's the only one we care about
                  break;
               }
            }
         }

         
         entityEvent.Parameters = eventInputsOutpus.ToArray();
         entityEvents.Add(entityEvent);
      }

      entityDesc.Events = entityEvents.ToArray();

      List<EntityProperty> entityProperties = new List<EntityProperty>();

      if (false == propertiesUsedForEvents)
      {
         foreach (PropertyInfo p in propertyInfos)
         {
            bool isInput = p.GetSetMethod() != null;
            bool isOutput = p.GetGetMethod() != null;

            EntityProperty property = new EntityProperty(p.Name, FindFriendlyName(p.Name, p.GetCustomAttributes(false)), type.ToString(), p.PropertyType.ToString(), isInput, isOutput);
            
            if ( true == isInput )
            {
               property.IsStatic = p.GetSetMethod().IsStatic;
            }
            else if ( true == isOutput )
            {
               property.IsStatic = p.GetGetMethod().IsStatic;
            }

            entityProperties.Add(property);

            MasterComponent.AddType(p.PropertyType);
         }

         foreach (FieldInfo f in fieldInfos)
         {
            if (false == f.IsPublic) continue;

            EntityProperty property = new EntityProperty(f.Name, FindFriendlyName(f.Name, f.GetCustomAttributes(false)), type.ToString(), f.FieldType.ToString(), true, true);
            property.IsStatic = f.IsStatic;
            entityProperties.Add(property);

            MasterComponent.AddType(f.FieldType);
         }
      }

      entityDesc.Properties = entityProperties.ToArray();

      entityDescs.Add(entityDesc);
   }

   private static int TypeSorter(Type t1, Type t2)
   {
      return String.Compare(uScriptConfig.Variable.FriendlyName(t1.ToString()), uScriptConfig.Variable.FriendlyName(t2.ToString()));
   }

   private EntityDesc[] PopulateEntityTypes(string[] requiredTypes)
   {
      if ( null != m_EntityTypes ) 
      {
         if ( null != requiredTypes )
         {
            foreach ( string t in requiredTypes )
            {
               if ( false == m_EntityTypeHash.Contains(t) )
               {
                  m_EntityTypes   = null;
                  m_SzEntityTypes = null;
                  break;
               }
            }
         }
      
         if ( null != m_EntityTypes ) return m_EntityTypes;
      }



      uScriptDebug.Log( "Rebuilding Entity Types", uScriptDebug.Type.Debug );

      Hashtable baseMethods = new Hashtable();
      Hashtable baseEvents = new Hashtable();
      Hashtable baseProperties = new Hashtable();

      List<EntityDesc> entityDescs = new List<EntityDesc>();

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

      if ( null == m_SzEntityTypes )
      {
         uScriptDebug.Log( "Reparsing Entity Types", uScriptDebug.Type.Debug );
          
         List<UnityEngine.Object> allObjects = new List<UnityEngine.Object>(FindObjectsOfType(typeof(UnityEngine.Object)));
         Dictionary<string, Type> uniqueObjects = new Dictionary<string, Type>();

         Dictionary<Type, Type> eventNodes = new Dictionary<Type, Type>();
         GatherDerivedTypes(eventNodes, uScriptConfig.ConstantPaths.uScriptNodes, typeof(uScriptEvent));
         GatherDerivedTypes(eventNodes, Preferences.UserNodes, typeof(uScriptEvent));

         foreach (UnityEngine.Object o in allObjects)
         {
            //don't ignore uScriptCode because we want to reflect
            //any public inspector properties

            //ignore our logic scripts, they are handled separately
            if (typeof(uScriptLogic).IsAssignableFrom(o.GetType())) continue;
            if (typeof(uScript_UndoComponent).IsAssignableFrom(o.GetType())) continue;

            uniqueObjects[o.GetType().ToString()] = o.GetType();
         }

         foreach (Type t in eventNodes.Values)
         {
            uniqueObjects[t.ToString()] = t;
         }

         
         string []userTypes = UserTypes;

         foreach ( string s in userTypes )
         {
            string szType = s.Trim();
            if ("" == szType) continue;

            Type t = MasterComponent.GetType( szType );

            if ( null != t )
            {
               if ( true == typeof(uScriptLogic).IsAssignableFrom(t) )
               {
                  uScriptDebug.Log( "uScriptLogic node " + szType + " should not be added to uScriptUserTypes, these are automatically parsed by uScript", uScriptDebug.Type.Warning );
               }
               else
               {
                  uniqueObjects[t.ToString()] = t;
               }
            }
            else
            {
               uScriptDebug.Log( "Cannot Find uScriptUserType: " + s, uScriptDebug.Type.Warning );
            }
         }

         // Don't reflect all unity types, many won't work with our reflection because
         // our reflection is assuming if they need an Instance it's a GameObject, and that isn't always the case
         string unityTypes =  "UnityEngine.Component";

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

         string []unityTypeArray = unityTypes.Split(',');

         foreach ( string s in unityTypeArray )
         {
            string szType = s.Trim();
            if ("" == szType) continue;

            Type t = MasterComponent.GetType( szType );
            if ( null != t ) uniqueObjects[t.ToString()] = t;
         }

         if (null != requiredTypes)
         {
            foreach (string t in requiredTypes)
            {
               if (true == uniqueObjects.ContainsKey(t)) continue;

               Type type = uScript.MasterComponent.GetType(t);

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

         m_SzEntityTypes = new string[ uniqueObjects.Values.Count ];

         int i = 0;

         foreach ( Type t in uniqueObjects.Values )
         {
            m_SzEntityTypes[ i++ ] = t.ToString();
         }
      }

      List<Type> types = new List<Type>();

      foreach ( string s in m_SzEntityTypes )
      {
         Type t = MasterComponent.GetType( s );
         if ( null != t ) types.Add( t );
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

      m_EntityTypeHash = new Hashtable( );

      foreach ( EntityDesc d in m_EntityTypes )
      {
         m_EntityTypeHash[ d.Type ] = true;
      }

      return m_EntityTypes;
   }

   public string AutoAssignInstance(EntityNode entityNode)
   {
      string type = ScriptEditor.FindNodeType(entityNode);
      if ("" == type) return "";

      if (true == uScript.FindNodeAutoAssignMasterInstance(type))
      {
         return uScriptRuntimeConfig.MasterObjectName;
      }

      return "";
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
      string key  = type + "_" + parameterName;

      if ( true == m_NodeParameterFields.Contains(key) )
      {
         return (AssetType) m_NodeParameterFields[ key ];     
      }

      return AssetType.Invalid;
   }

   public static string GetParameterDescField(string type, string parameterName)
   {
      string key  = type + "_" + parameterName;

      if ( true == m_NodeParameterDescFields.Contains(key) )
      {
         return (string) m_NodeParameterDescFields[ key ];     
      }

      return string.Empty;
   }

   public static bool GetRequiresLink(EntityNode node, string parameterName)
   {
      string type = ScriptEditor.FindNodeType(node);
      string key  = type + "_" + parameterName;

      return m_RequiresLink.Contains(key);
   }

   public static void AddAssetPathField(string type, string parameterName, object []attributes)
   {
      foreach (object a in attributes)
      {
         if (a is AssetPathField)
         {
            AssetPathField field = (AssetPathField) a;
            string key = type + "_" + parameterName;

            m_NodeParameterFields[ key ] = field.AssetType;         
            break;
         }
      }
   }

   public static void AddParameterDescField(string type, string parameterName, object []attributes)
   {
      foreach (object a in attributes)
      {
         if (a is FriendlyNameAttribute)
         {
            FriendlyNameAttribute field = (FriendlyNameAttribute) a;
            string key = type + "_" + parameterName;

            m_NodeParameterDescFields[ key ] = field.Desc;         
            break;
         }
      }
   }


   public static void AddRequiresLink(string type, string parameterName, object []attributes)
   {
      foreach (object a in attributes)
      {
         if (a is RequiresLink)
         {
            string key = type + "_" + parameterName;
            m_RequiresLink[ key ] = true;         
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
      Type uscriptType = uScript.MasterComponent.GetType(type);

      if ( null != uscriptType )
      {
         return FindFriendlyName( type, uscriptType.GetCustomAttributes(false) );
      }

      return "";
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
      Type uscriptType = uScript.MasterComponent.GetType(type);

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

   public static bool FindNodeAutoAssignMasterInstance(string type)
   {
      Type uscriptType = uScript.MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return false;

         foreach (object a in attributes)
         {
            if (a is NodeAutoAssignMasterInstance)
            {
               return ((NodeAutoAssignMasterInstance)a).Value;
            }
         }
      }

      return false;
   }

   public static string FindNodePath(string defaultCategory, string type)
   {
      Type uscriptType = uScript.MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodePath)
            {
               return ((NodePath)a).Value;
            }
         }
      }

      return defaultCategory;
   }

   public static string FindNodePropertiesPath(string defaultCategory, string type)
   {
      Type uscriptType = uScript.MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodePropertiesPath)
            {
               return ((NodePropertiesPath)a).Value;
            }
         }
      }

      return defaultCategory;
   }

   public static bool IsNodeTypeDeprecated(EntityNode node)
   {
      string type = ScriptEditor.FindNodeType(node);
      if ("" == type) return false;

      Type uscriptType = uScript.MasterComponent.GetType(type);
      if (null == uscriptType) return false;

      object[] attributes = uscriptType.GetCustomAttributes(false);
      if (null == attributes) return false;

      foreach (object a in attributes)
      {
         if (a is NodeDeprecated)
         {
            return true;
         }
      }

      return false;
   }

   public static Type GetNodeUpgradeType(EntityNode node)
   {
      string type = ScriptEditor.FindNodeType(node);
      if ("" == type) return null;

      Type uscriptType = uScript.MasterComponent.GetType(type);
      if (null == uscriptType) return null;

      object[] attributes = uscriptType.GetCustomAttributes(false);
      if (null == attributes) return null;

      foreach (object a in attributes)
      {
         if (a is NodeDeprecated)
         {
            return ((NodeDeprecated)a).UpgradeType;
         }
      }

      return null;
   }

   /*public static string FindNodeLicense(string type)
   {
      Type uscriptType = uScript.MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodeLicense)
            {
               return ((NodeLicense)a).Value;
            }
         }
      }

      return "";
   }*/

   public static string FindNodeCopyright(string type)
   {
      Type uscriptType = uScript.MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodeCopyright)
            {
               return ((NodeCopyright)a).Value;
            }
         }
      }

      return "";
   }

   public static string FindNodeToolTip(string type)
   {
      Type uscriptType = uScript.MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodeToolTip)
            {
               return ((NodeToolTip)a).Value;
            }
         }
      }

      return "";
   }


   public static string FindNodeName(string type, EntityNode node)
   {
      // Check non-logic, non-event types first, because structs can't have attributes,
      // so we have to specify this information here, explicitly

      if (type == "CommentNode")
      {
         return "Comment";
      }
      else if (type == "ExternalConnection")
      {
         return "External Connection";
      }
      else if (type == "OwnerConnection")
      {
         return "Owner GameObject";
      }
      else if (type == "LocalNode")
      {
         return uScriptConfig.Variable.FriendlyName(((LocalNode)node).Value.Type).Replace("UnityEngine.", string.Empty);
      }

      Type uscriptType = uScript.MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         foreach (object a in attributes)
         {
            if (a is FriendlyNameAttribute)
            {
               return ((FriendlyNameAttribute)a).Name;
            }
         }
      }

      // If there is no name at this point, the node is likely reflected
      if (node is EntityMethod)
      {
         return "Reflected " + type.Replace("UnityEngine.", string.Empty) + " action";
      }
      else if (node is EntityProperty)
      {
         return "Reflected " + type.Replace("UnityEngine.", string.Empty) + " property";
      }

      return string.Empty;
   }

   public static string FindNodeDescription(string type, EntityNode node)
   {
      // check non-logic, non-event types first...
      // structs can't have attributes, so we have to specify this information here, explicitly
      if (type == "CommentNode")
      {
         return "Use a comment box to comment or hint at what a particular block of uScript nodes" +
            " does. Comment boxes can be resized so that they surround the nodes that they are" +
            " referencing.\n\nTo resize a comment box, drag the bottom-right corner of the comment" +
            " box or set its width/height properties explicitly in the Properties panel.";
      }
      else if (type == "ExternalConnection")
      {
         return "Use External Connections to create nested uScript graphs that show up as a single node in other graphs they are used in. An External Connection node" +
            " will turn into a socket when the current graph is used as a nested node inside" +
            " other graphs. The type of socket it turns into will be determined by the type of" +
            " socket it is connected to in this uScript.\n\nTo place this uScript graph in another" +
            " uScript as a nested node, save it and then look for it under the \"Graphs\" section" +
            " of the Toolbox panel or 'Add' context menu.";
      }
      else if (type == "OwnerConnection")
      {
         return "Owner GameObject variables are a special kind of GameObject variable. They" +
            " represent the GameObject that this uScript is attached to.";
      }
      else if (type == "LocalNode")
      {
         LocalNode variable = (LocalNode)node;
         string friendlyType = uScriptConfig.Variable.FriendlyName(variable.Value.Type);

         switch (friendlyType)
         {
            case "Bool":
               return "A Boolean variable, which stores the value of True or False.";
            case "Color":
               return "A Color variable. The color is defined in RGB color space and contains an Alpha (opacity) channel.";
            case "Float":
               return "A floating-point variable may store a real number (e.g., 1.234, 5.0, -3.21).";
            case "Int":
               return "An integer variable may store a whole number (e.g., 1, 0, -3).";
            case "Vector2":
               return "A Vector2 variable represents a 2-dimensional point in space (x,y).";
            case "Vector3":
               return "A Vector3 variable represents a 3-dimensional point or direction in space (x,y,z).";
            case "Vector4":
               return "A Vector4 variable represents a 3-dimensional point or direction in space with an additional 'W' component (x,y,z,w).";
            case "Rect":
               return "A Rect variable represents a 2-dimensional position (x,y) and an area (width, height).";
            case "Quaternion":
               return "A Quaternion variable stores a quaternion representation of a rotation in space.";
            case "GameObject":
               return "A GameObject variable that stores a refernce to a GameObject in the scene.\n\nNote that if a GameObject is being used as a node's input parameter, it is set by name and when this is done, it must be unique in the scene.";
            case "String":
               return "A String variable, which stores text data.";
            default:
               return "Use variables to store data in your uScript.";
         }
      }

      Type uscriptType = uScript.MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is FriendlyNameAttribute)
            {
               if ( ((FriendlyNameAttribute)a).Desc != string.Empty )
               {
                  return ((FriendlyNameAttribute)a).Desc;
               }
            }
         }

         foreach (object a in attributes)
         {
            if (a is NodeDescription)
            {
               return ((NodeDescription)a).Value;
            }
         }
      }
      //if type was null it could be a nested script
      else if ( node is LogicNode )
      {
         if ( m_RawDescription.Contains(((LogicNode)node).Type) )
         {
            return m_RawDescription[((LogicNode)node).Type] as string;
         }
      }

      return "";
   }


   public static string FindParameterDescription(string type, Parameter p)
   {
      // Check non-logic, non-event types first
      //
      // Structs can't have attributes and some parameters are manually added to some nodes. To
      // support descriptions on these parameters, we have to specify this information explicitly.
      //
      if (string.IsNullOrEmpty(type))
      {
         switch (p.FriendlyName)
         {
            case "Comment":            return "The comment text to show above this node in uScript's canvas.";
            case "Output Comment":     return "If True, the comment text will be sent to Unity's console window when the node fires.";
            case "Instance":           return "The GameObject instance associated with this node. This tells uScript which specific GameObject to use that contains this specified event, property, script, trigger, collider, etc.";
            default:                   return p.FriendlyName;
         }
      }
      if (type == "CommentNode")
      {
         switch (p.FriendlyName)
         {
            case "Title":              return "The title or header for this comment box.";
            case "Body":               return "The actual comment text and information. Empty lines are supported.";
            case "Width":              return "The width of the comment box (in pixels).";
            case "Height":             return "The height of the comment box (in pixels).";
            case "Node Color":         return "The comment box color.";
            case "Body Text Color":    return "The color of the body text.";
            case "Title Color":        return "The color of the title text.";    // Not used?
            default:                   return p.FriendlyName;
         }
      }
      else if (type == "LocalNode")
      {
         if (p.FriendlyName == "Name")
            return "The variable name (optional). Variables that share the same name are automatically linked together and treated as the same variable in your graph. Once linked, changing the value of one will affect all others in the graph. Variables with the same name in different graphs are NOT connected in any way. Use the \"Expose to Unity\" option below in order to access this variable as a reflected property between graphs.";
         else if (p.FriendlyName == "Value")
            return "The value of the variable. Only values supported by this variable type are allowed.";
         else if (p.FriendlyName == "Expose to Unity")
            return "When checked, this will expose this variable to Unity so that it will show up in the Inspector panel for this graph's component as well as allow you to access this variable from other uScript graphs as a reflected property. You must name this variable before you can use this oiption (see the Name field above). This is the equivelent of making a variable \"public\" in a script.";
      }
      else if (type == "ExternalConnection")
      {
         if (p.FriendlyName == "Name")
            return "The connection name. This name will be displayed in other graphs for this socket.";
         else if (p.FriendlyName == "Order")
            return "The order that the sockets will appear on the nested node in other graphs (from left to right for variable sockets and top to bottom for input/output sockets). Lower numbers have higher priority and will draw first.";
         else if (p.FriendlyName == "Description")
            return "The help text for each socket you wish to show up in the uScript Reference panel when users select this nested node in another graph.";
      }
      else if (type == "OwnerConnection")
      {
         if (p.FriendlyName == "Connection")
            return "The GameObject this uScript graph is attached to. Also commonly known as \"this\" in scripting.";
      }
      else if (type == "_reflectedAction")
      {
      }
      else if (type == "_reflectedProperty")
      {
         return "This is the reflected object property that will be referenced and/or modified.";
      }


      return uScript.GetParameterDescField(type, p.Name);

         // Any remaining parameters are likely be be reflected.
         //
         // If the parameter is on a Property node
         //    -- can we even identify properties by looking at the parameter or passed type??
         //
   }

   public static string FindNodeAuthorName(string type)
   {
      Type uscriptType = uScript.MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodeAuthor)
            {
               return ((NodeAuthor)a).Value;
            }
         }
      }

      return "";
   }

   public static string FindNodeAuthorURL(string type)
   {
      Type uscriptType = uScript.MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodeAuthor)
            {
               return ((NodeAuthor)a).URL;
            }
         }
      }

      return "";
   }

   public static string FindNodeHelp(string type, EntityNode node)
   {
      // check non-logic, non-event types first...
      // structs can't have attributes, so we have to specify this information here, explicitly
      if (type == "CommentNode")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Comment_Node";
      }
      else if (type == "ExternalConnection")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#External_Connection";
      }
      else if (type == "LocalNode")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Variable_Nodes";
      }
      else if (type == "OwnerConnection")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Owner_Variable";
      }

      Type uscriptType = uScript.MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodeHelp)
            {
               return ((NodeHelp)a).Value;
            }
         }
      }

      return "";
   }

   public static int GetAssetInstanceID(string path, Type type)
   {
      UnityEngine.Object obj = Resources.LoadAssetAtPath(path, type);
      if (obj == null)
      {
//         Debug.Log("File not found:\t" + path + "\n");
         return -1;
      }

      return obj.GetInstanceID();
   }


   //
   // This method can be expensive, so call it sparingly
   //
   public static string GetClassPath(string newName)
   {
      if (string.IsNullOrEmpty(newName) == false)
      {
         // Find the associated class file
         string startPath = Application.dataPath;
         string[] exts = new string[] { ".cs", ".js", ".boo" };

         foreach (string ext in exts)
         {
            string[] files = Directory.GetFiles(startPath, newName + ext, SearchOption.AllDirectories);
            if (files.Length == 1)
            {
               return files[0].Remove(0, startPath.Length - 6);
            }
         }
      }

      return string.Empty;
   }

}
