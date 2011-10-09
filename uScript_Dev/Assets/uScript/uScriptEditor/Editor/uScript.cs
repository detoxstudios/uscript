//#define UNITY_STORE_BUILD
//#define DETOX_STORE_BUILD
//#define FREE_PLE_BUILD
#define FREE_BETA_BUILD

using UnityEngine;
using UnityEditor;
using Detox.ScriptEditor;
using Detox.Data.Tools;
using System.Windows.Forms;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Detox.FlowChart;

public class uScript : EditorWindow
{

   //format is MAJOR.MINOR.FOURDIGITSVNCOMMITNUMBER
   public string BuildNumber { get { return "0.9.1363"; } }
#if FREE_PLE_BUILD
    static string ProductName { get { return "Personal Learning Edition"; } }
#else
   static string ProductName { get { return "Retail Beta 5"; } }
#endif
   public string FullVersionName { get { return ProductName + " (" + BuildNumber + ")"; } }
   public string LastUnityBuild { get { return "3.3"; } }
   public string CurrentUnityBuild { get { return "3.4"; } }
   //public string BetaUnityBuild { get { return "3.5"; } }
   public DateTime ExpireDate { get { return new DateTime(2011, 10, 31); } }

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

   public Dictionary<MouseRegion, Rect> _mouseRegionRect = new Dictionary<MouseRegion, Rect>();

   static private uScript s_Instance = null;
   static public uScript Instance { get { if (null == s_Instance) Init(); return s_Instance; } }
   bool _firstRun = true;

   private ScriptEditorCtrl m_ScriptEditorCtrl = null;
   private bool m_MouseDown = false;
   private bool m_MouseDownOverCanvas = false;
   private bool m_Repainting = false;
   private bool m_WantsCopy = false;
   private bool m_WantsCut = false;
   private bool m_WantsPaste = false;

   private bool m_RebuildWhenReady = false;

   private float m_MapScale = 1.0f;
   private Point m_ZoomPoint = new Point( 0, 0 );

   private String m_AddVariableNode = "";
   private KeyCode m_PressedKey = KeyCode.None;

   private string m_FullPath = "";
   private string m_CurrentCanvasPosition = "";
   private bool m_ForceCodeValidation = false;

   private Detox.FlowChart.Node m_FocusedNode = null;

   public static Hashtable m_NodeParameterFields = new Hashtable( );
   public static Hashtable m_RequiresLink = new Hashtable( );
   static public Preferences Preferences = new Preferences();
   static private AppFrameworkData m_AppData = new AppFrameworkData();
   static private bool m_SettingsLoaded = false;
   private double m_RefreshTimestamp = -1.0;

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

   private int m_ContextX = 0;
   private int m_ContextY = 0;
   private ToolStripItem m_CurrentMenu = null;

   Rect m_NodeWindowRect;
   public Rect NodeWindowRect { get { return m_NodeWindowRect; } }

   Rect m_NodeToolbarRect;
   public Rect NodeToolbarRect { get { return m_NodeToolbarRect; } }

   private const int DIVIDER_WIDTH = 4;

   /* uScript GUI Window Panel Layout Variables */


   bool m_HidePanelMode = false;
   public int _guiPanelPalette_Width = 250;
   int _guiPanelProperties_Height = 250;
   public int _guiPanelProperties_Width = 250;
   public int _guiPanelSequence_Width = 250;


   Rect _canvasRect;
   Vector2 _guiPanelPalette_ScrollPos;

   public Vector2 _guiContentScrollPos;

   Vector2 _guiPanelProperties_ScrollPos;

   Vector2 _guiHelpScrollPos;


   Rect rectContextMenuWindow = new Rect(10, 10, 10, 10);

   Rect rectFileMenuButton = new Rect();
   Rect rectFileMenuWindow = new Rect(20, 20, 10, 10);

   int _saveMethod = 1;    // 0:Quick, 1:Debug, 2:Release


   /* Palette Variables */
   private List<PaletteMenuItem> _paletteMenuItems;
   bool _paletteFoldoutToggle = false;
   String _paletteFilterText = string.Empty;
   String _graphListFilterText = string.Empty;

   public class PaletteMenuItem : System.Windows.Forms.MenuItem
   {
      public String Name;
      public String Tooltip;
      public string Path;
      public List<PaletteMenuItem> Items;
      public System.EventHandler Click;
      public bool Hidden;
      public int Indent;

//      public bool Expanded;
//      public Rect Position;
//      public string ID;

      public void OnClick()
      {
         if (Click != null)
         {
            Click(this, new EventArgs());
         }
      }
   }


   //
   // Sub-Sequence variables
   //
   Vector2 _guiPanelSequence_ScrollPos;

   //
   // Statusbar Variables
   //
   string _statusbarMessage;

   //IMPORTANT - THIS CANNOT BE CACHED
   //BECAUSE WE END UP WITH STALE VERSIONS AS THE UNITY UNDO STACK IS MODIFIED
   public static GameObject MasterObject
   {
      get
      {
         return GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
      }
   }

   //IMPORTANT - THIS CANNOT BE CACHED
   //BECAUSE WE END UP WITH STALE VERSIONS AS THE UNITY UNDO STACK IS MODIFIED
   public static uScript_MasterComponent MasterComponent
   {
      get
      {
         GameObject uScriptMaster = GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
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

   public string CurrentScript = null;
   public string CurrentScriptName = "";
   public string CurrentScene = "";




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

   //
   // Editor Window Initialization
   //
   [UnityEditor.MenuItem("Tools/Detox Studios/uScript Editor %u")]
   static void Init()
   {
      s_Instance = (uScript)EditorWindow.GetWindow(typeof(uScript), false, "uScript Editor");
      s_Instance.wantsMouseMove = true;

      System.IO.Directory.CreateDirectory(uScriptConfig.ConstantPaths.RootFolder);
      System.IO.Directory.CreateDirectory(uScriptConfig.ConstantPaths.uScriptNodes);
      System.IO.Directory.CreateDirectory(uScriptConfig.ConstantPaths.uScriptEditor);

      System.IO.Directory.CreateDirectory(Preferences.ProjectFiles);
      System.IO.Directory.CreateDirectory(Preferences.UserScripts);
      System.IO.Directory.CreateDirectory(Preferences.UserNodes);
      System.IO.Directory.CreateDirectory(Preferences.GeneratedScripts);
      System.IO.Directory.CreateDirectory(Preferences.NestedScripts);

      //copy gizmos into root
      string gizmos = UnityEngine.Application.dataPath + "/Gizmos";
      System.IO.Directory.CreateDirectory( gizmos );
      
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( uScriptConfig.ConstantPaths.Gizmos );
      
      foreach ( System.IO.FileInfo file in directory.GetFiles( ) )
      {
		 if (!System.IO.File.Exists( gizmos + "/" + file.Name ))
			{
				System.IO.File.Copy( file.FullName, gizmos + "/" + file.Name, false );
			}
      }
   }

   static public object GetSetting(string key)
   {
      if (!m_SettingsLoaded) LoadSettings();
      m_SettingsLoaded = true;

      return m_AppData.Get(key);
   }

   static public object GetSetting(string key, object defaultValue)
   {
      if (!m_SettingsLoaded) LoadSettings();
      m_SettingsLoaded = true;

      object value = m_AppData.Get(key);
      return null != value ? value : defaultValue;
   }

   static public void SetSetting(string key, object value)
   {
      if (!m_SettingsLoaded) LoadSettings();
      m_SettingsLoaded = true;

      m_AppData.Set(key, value);
      m_AppData.Save(uScriptConfig.ConstantPaths.SettingsPath + "/" + uScriptConfig.Files.SettingsFile);
   }

   static public void LoadSettings()
   {
      if (System.IO.File.Exists(uScriptConfig.ConstantPaths.SettingsPath + "/" + uScriptConfig.Files.SettingsFile))
      {
         m_AppData.Load(uScriptConfig.ConstantPaths.SettingsPath + "/" + uScriptConfig.Files.SettingsFile);
      }
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


   public void RegisterUndo(string name, ScriptEditor oldScript, ScriptEditor newScript)
   {
      if (null != MasterComponent)
      {
         MasterComponent.Script = oldScript.ToBase64();
         MasterComponent.ScriptName = oldScript.Name;

         //save the old one to the undo stack
         UnityEditor.Undo.RegisterUndo(MasterComponent, name + " (uScript)");

         //register the new one with uscript and the master component
         CurrentScript = newScript.ToBase64();
         CurrentScriptName = newScript.Name;

         MasterComponent.Script = CurrentScript;
         MasterComponent.ScriptName = newScript.Name;
      }
   }


   // Unity Methods
   //
   void Awake()
   {
      EditorApplication.playmodeStateChanged = OnPlaymodeStateChanged;

      _statusbarMessage = "Unity " + (isPro ? "Pro" : "Indie") + " (version " + Application.unityVersion + ")";

      m_ForceCodeValidation = true;
   }


   public static bool isPro
   {
      // Test for Unity Pro - Unity 3.1 Indie does not support RenderTextures
      get { return SystemInfo.supportsRenderTextures; }
   }

   void Update()
   {
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



      uScriptGUIPanelReference.Instance.hotSelection = _hotSelection;


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
            RebuildScripts(Preferences.UserScripts);
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

      // Initialization
      //

      if (EditorApplication.currentScene != CurrentScene)
      {
         MasterComponent.Script = CurrentScript;
         MasterComponent.ScriptName = CurrentScriptName;
      }
      CurrentScene = EditorApplication.currentScene;

      //force a rebuild if undo was performed
      bool rebuildScript = false;

      if (null != MasterComponent && CurrentScript != MasterComponent.Script )
      {
         //it's possible these will not equal, which means a different script is being undone then the one loaded
         //in that case it would clobber the current script with a different one.  Here is how it could happen:
         //1. User is editing script A and presses play
         //2. User loads script B
         //3. User edits script B
         //4. User presses stop.
         //This causes unity to revert everything to the state right before 'play' was pressed
         //which includes the object we keep on the master component - so now our object
         //is different then the current script, but it wasn't due to a user undo action
         if ( null == CurrentScriptName || CurrentScriptName == MasterComponent.ScriptName )
         {
            rebuildScript = true;
         }
      }

      if (_wasHierarchyChanged)
      {
         _wasHierarchyChanged = false;
         rebuildScript = true;
      }

      if (null == m_ScriptEditorCtrl || true == rebuildScript)
      {
         if (null == m_ScriptEditorCtrl)
         {
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
                     uScriptDebug.Log(ProductName + " (" + BuildNumber + ") " + "has expired.\n", uScriptDebug.Type.Error);
                     return;
                  }
                  else
                  {
                     uScriptDebug.Log(ProductName + " (" + BuildNumber + ") " + "will expire in " + (ExpireDate - DateTime.Now).Days + " days.", uScriptDebug.Type.Message);
                  }
			    }
#endif
         }

         m_ScriptEditorCtrl = null;

         GameObject uScriptMaster = GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
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

         bool isRestored = false;
         bool isDirty = false;

         ScriptEditor scriptEditor = null;

         if (!String.IsNullOrEmpty(MasterComponent.Script))
         {
            //open with no preexisting types which means it loads the data direct
            //and we can figure out what required types we need
            scriptEditor = new ScriptEditor("", null, null);
            if (true == scriptEditor.OpenFromBase64(MasterComponent.ScriptName, MasterComponent.Script))
            {
               scriptEditor = new ScriptEditor("Untitled", PopulateEntityTypes(scriptEditor.Types), PopulateLogicTypes());
               scriptEditor.OpenFromBase64(MasterComponent.ScriptName, MasterComponent.Script);

               //I think I can put restored true only if current script is not null
               //if it is null and we're here then we're coming back from a unity crash
               //and we don't really have the file loaded (which means we would be restoring the
               //last version cached by unity and not what's latest in our file)
               //I'll be looking at this now so please don't remove this comment
               isRestored = true;

               //if we're restoring over an old script
               //we need to flag us as dirty (because this was do to an undo/redo being triggered)
               if (CurrentScript != MasterComponent.Script && null != CurrentScript)
               {
                  isDirty = true;
               }

               CurrentScript = MasterComponent.Script;
               CurrentScriptName = MasterComponent.ScriptName;
            }
         }
         else
         {
            scriptEditor = new ScriptEditor("Untitled", PopulateEntityTypes(null), PopulateLogicTypes());
         }

         if (String.IsNullOrEmpty(m_FullPath))
         {
            String lastOpened = (String)uScript.GetSetting("uScript\\LastOpened", "");
            String lastScene  = (String)uScript.GetSetting("uScript\\LastScene", "");
            if (!String.IsNullOrEmpty(lastOpened) && lastScene == UnityEditor.EditorApplication.currentScene)
            {
               m_FullPath = UnityEngine.Application.dataPath + lastOpened;
            }
         }

         Point loc = Point.Empty;
         if (!String.IsNullOrEmpty(m_FullPath))
         {
            m_CurrentCanvasPosition = (String)GetSetting("uScript\\" + uScriptConfig.ConstantPaths.RelativePath(m_FullPath) + "\\CanvasPosition", "");
         }
         if (false == String.IsNullOrEmpty(m_CurrentCanvasPosition))
         {
            loc = new Point(Int32.Parse(m_CurrentCanvasPosition.Substring(0, m_CurrentCanvasPosition.IndexOf(","))),
                            Int32.Parse(m_CurrentCanvasPosition.Substring(m_CurrentCanvasPosition.IndexOf(",") + 1)));
         }

         m_ScriptEditorCtrl = new ScriptEditorCtrl(scriptEditor, loc);

         m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);

         m_ScriptEditorCtrl.BuildContextMenu();
         BuildPaletteMenu(null, null, string.Empty);

         Detox.Utility.Status.StatusUpdate += new Detox.Utility.Status.StatusUpdateEventHandler(Status_StatusUpdate);

         //when doing certain operations like 'play' in unity
         //it seems to set any class references back to null
         //since the string isn't a reference it stays valid
         //so reopen our script
         if ("" != m_FullPath && false == isRestored)
         {
            if (!OpenScript(m_FullPath)) m_FullPath = "";
            m_RefreshTimestamp = EditorApplication.timeSinceStartup;
         }

         if (true == isDirty)
         {
            //force rebuilt from undo so mark as dirty
            m_ScriptEditorCtrl.IsDirty = true;
         }


         _guiPanelProperties_Width = (int)(uScript.Instance.position.width / 3);
         _guiPanelSequence_Width = (int)(uScript.Instance.position.width / 3);
      }

      if (m_RefreshTimestamp > 0.0 && EditorApplication.timeSinceStartup - m_RefreshTimestamp >= 0.05)
      {
         // re-center now that the gui is initialized
         if (m_ScriptEditorCtrl != null)
         {
            m_ScriptEditorCtrl.RefreshScript(null, true);
            if (!String.IsNullOrEmpty(m_FullPath))
            {
               m_CurrentCanvasPosition = (String)GetSetting("uScript\\" + uScriptConfig.ConstantPaths.RelativePath(m_FullPath) + "\\CanvasPosition", "");
            }
            if (!String.IsNullOrEmpty(m_CurrentCanvasPosition))
            {
               Point loc = new Point(Int32.Parse(m_CurrentCanvasPosition.Substring(0, m_CurrentCanvasPosition.IndexOf(","))), Int32.Parse(m_CurrentCanvasPosition.Substring(m_CurrentCanvasPosition.IndexOf(",") + 1)));
               m_ScriptEditorCtrl.FlowChart.Location = loc;
            }
            // reset menu offset
            m_ScriptEditorCtrl.BuildContextMenu();
            BuildPaletteMenu(null, null, string.Empty);
         }
         m_RefreshTimestamp = -1.0;
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
            m_ScriptEditorCtrl.ContextCursor = System.Windows.Forms.Cursor.Position;
            m_ScriptEditorCtrl.AddVariableNode(new CommentNode(""));
         }
         else if (m_AddVariableNode == "External")
         {
            m_ScriptEditorCtrl.ContextCursor = new Point(System.Windows.Forms.Cursor.Position.X - 28, System.Windows.Forms.Cursor.Position.Y - 28);
            m_ScriptEditorCtrl.AddVariableNode(new ExternalConnection(Guid.NewGuid()));
         }
         else if (m_AddVariableNode == "Log")
         {
            m_ScriptEditorCtrl.ContextCursor = new Point(System.Windows.Forms.Cursor.Position.X - 10, System.Windows.Forms.Cursor.Position.Y - 10);
            m_ScriptEditorCtrl.AddVariableNode(m_ScriptEditorCtrl.GetLogicNode("uScriptAct_Log"));
         }
         else
         {
            m_ScriptEditorCtrl.ContextCursor = new Point(System.Windows.Forms.Cursor.Position.X - 28, System.Windows.Forms.Cursor.Position.Y - 28);
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
//      _paletteFilterText = string.Empty;
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

            m_MouseUpArgs = new System.Windows.Forms.MouseEventArgs();
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
         m_MouseUpArgs = new System.Windows.Forms.MouseEventArgs();

         int button = 0;

         if (e.button == 0) button = MouseButtons.Left;
         else if (e.button == 1) button = MouseButtons.Right;
         else if (e.button == 2) button = MouseButtons.Middle;

         m_MouseUpArgs.Button = button;
         m_MouseUpArgs.X = (int)(e.mousePosition.x);
         if (!m_HidePanelMode) m_MouseUpArgs.X -= _guiPanelPalette_Width;
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

      switch (e.type)
      {
         case EventType.ContextClick:
            isFileMenuOpen = false;
            break;

         case EventType.KeyDown:
         case EventType.KeyUp:
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
                  BuildPaletteMenu(null, null, string.Empty);

                  m_ContextX = (int)e.mousePosition.x;
                  m_ContextY = (int)(e.mousePosition.y - _canvasRect.yMin);

//                  //refresh screen so context menu shows up
//                  Repaint();
               }
               else
               {
                  m_ScriptEditorCtrl.BuildContextMenu();
                  BuildCanvasContextMenu(null, null);

                  _canvasContextMenu.ShowAsContext();

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
               if (m_ScriptEditorCtrl.CanCopy && "MainView" == GUI.GetNameOfFocusedControl())
               {
                  e.Use();
               }
            }
            else if (e.commandName == "Cut")
            {
               if (m_ScriptEditorCtrl.CanCopy && "MainView" == GUI.GetNameOfFocusedControl())
               {
                  e.Use();
               }
            }
            else if (e.commandName == "Paste" && "MainView" == GUI.GetNameOfFocusedControl())
            {
               if (m_ScriptEditorCtrl.CanPaste)
               {
                  e.Use();
               }
            }
            else if (e.commandName == "SelectAll" && "MainView" == GUI.GetNameOfFocusedControl())
            {
               e.Use();
            }
            break;

         case EventType.ExecuteCommand:
            if (e.commandName == "Copy" && "MainView" == GUI.GetNameOfFocusedControl())
            {
               m_WantsCopy = true;
            }
            else if (e.commandName == "Cut" && "MainView" == GUI.GetNameOfFocusedControl())
            {
               m_WantsCut = true;
            }
            else if (e.commandName == "Paste" && "MainView" == GUI.GetNameOfFocusedControl())
            {
               m_WantsPaste = true;
            }
            else if (e.commandName == "SelectAll" && "MainView" == GUI.GetNameOfFocusedControl())
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

            if ("MainView" == GUI.GetNameOfFocusedControl() || GUIUtility.keyboardControl == 0)
            {
               if (  (e.keyCode == KeyCode.F
                     && (e.modifiers == EventModifiers.Alt
                        || e.modifiers == EventModifiers.Control))
                  || (e.keyCode == KeyCode.S
                     && (e.modifiers == EventModifiers.Alt
                        || e.modifiers == EventModifiers.Control))
                  || e.keyCode == KeyCode.BackQuote
                  || e.keyCode == KeyCode.Home
                  || (e.keyCode == KeyCode.G && (modifierKeys & Keys.Control) != 0)
                  || (e.keyCode == KeyCode.H && (modifierKeys & Keys.Control) != 0)
                  || (e.keyCode == KeyCode.W && (modifierKeys & Keys.Control) != 0)
                  || e.keyCode == KeyCode.Delete
                  || e.keyCode == KeyCode.Backspace
                  || e.keyCode == KeyCode.Escape
                  || e.keyCode == KeyCode.F1
                  || e.keyCode == KeyCode.RightBracket
                  || e.keyCode == KeyCode.LeftBracket
                  || e.keyCode == KeyCode.Alpha0
                  || e.keyCode == KeyCode.Minus
                  || e.keyCode == KeyCode.Equals )
               {
                  e.Use();
               }
            }
            break;
         case EventType.KeyUp:
            if ("MainView" == GUI.GetNameOfFocusedControl())
            {
               if (e.keyCode == KeyCode.F
                   && (e.modifiers == EventModifiers.Alt
                       || e.modifiers == EventModifiers.Control
//                       || e.modifiers == EventModifiers.Command
                      )
                  )
               {
                  isFileMenuOpen = true;
                  e.Use();
               }
               else if (e.keyCode == KeyCode.Delete || e.keyCode == KeyCode.Backspace)
               {
                  m_ScriptEditorCtrl.DeleteSelectedNodes();
               }
               else if (e.keyCode == KeyCode.Home || (e.keyCode == KeyCode.H && (modifierKeys & Keys.Control) != 0))
               {
                  // re-center the graph
                  if (m_ScriptEditorCtrl != null)
                  {
                     m_ScriptEditorCtrl.RefreshScript(null, true);
                  }
               }
               else if (e.keyCode == KeyCode.W && (modifierKeys & Keys.Control) != 0)
               {
                  // close the window
                  this.Close();
               }
               else if (e.keyCode == KeyCode.Escape)
               {
                  m_ScriptEditorCtrl.DeselectAll();
               }
               else if (e.keyCode == KeyCode.F1)
               {
                  Help.BrowseURL("http://www.uscript.net/docs/index.php?title=Main_Page");
               }
               else if (e.keyCode == KeyCode.G && (modifierKeys & Keys.Control) != 0)
               {
                  Preferences.ShowGrid = !Preferences.ShowGrid;
                  Preferences.Save();
               }
               else if (e.keyCode == KeyCode.RightBracket)
               {
                  m_FocusedNode = m_ScriptEditorCtrl.GetNextNode(m_FocusedNode, typeof(EntityEventDisplayNode));
                  if (m_FocusedNode != null) m_ScriptEditorCtrl.CenterOnNode(m_FocusedNode);
               }
               else if (e.keyCode == KeyCode.LeftBracket)
               {
                  m_FocusedNode = m_ScriptEditorCtrl.GetPrevNode(m_FocusedNode, typeof(EntityEventDisplayNode));
                  if (m_FocusedNode != null) m_ScriptEditorCtrl.CenterOnNode(m_FocusedNode);
               }
               else if (e.keyCode == KeyCode.Alpha0)
               {
                  m_MapScale = 1.0f;
               }
               else if (e.keyCode == KeyCode.Minus)
               {
                  m_MapScale = Mathf.Max(m_MapScale - 0.1f, 0.1f);
               }
               else if (e.keyCode == KeyCode.Equals)
               {
                  m_MapScale = Mathf.Min(m_MapScale + 0.1f, 1.0f);

                  if ( 1 == m_MapScale ) m_MapScale = 1.0f;
               }
            }

            if (e.keyCode == KeyCode.BackQuote && (GUI.GetNameOfFocusedControl() == "MainView" || GUIUtility.keyboardControl == 0))
            {
               m_HidePanelMode = !m_HidePanelMode;

               // FIXME: When toggled while the mouse is down, the canvas often shifts around.
               if (m_HidePanelMode)
               {
//                  m_ScriptEditorCtrl.FlowChart.Location.X += (int)_canvasRect.x;
                  m_ScriptEditorCtrl.FlowChart.Location.X += _guiPanelPalette_Width + DIVIDER_WIDTH;
                  m_ScriptEditorCtrl.RefreshScript(null, false);
               }
               else
               {
//                  m_ScriptEditorCtrl.FlowChart.Location.X -= (int)_canvasRect.x;
                  m_ScriptEditorCtrl.FlowChart.Location.X -= _guiPanelPalette_Width + DIVIDER_WIDTH;
                  m_ScriptEditorCtrl.RefreshScript(null, false);
               }
            }

            m_PressedKey = KeyCode.None;

            //keep key events from going to the rest of unity
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

                     m_MouseDownArgs = new System.Windows.Forms.MouseEventArgs();

                     m_MouseDownArgs.Button = button;
                     m_MouseDownArgs.X = (int)(e.mousePosition.x);
                     if (!m_HidePanelMode) m_MouseDownArgs.X -= _guiPanelPalette_Width;
                     m_MouseDownArgs.Y = (int)(e.mousePosition.y - _canvasRect.yMin);

                     m_MouseDownOverCanvas = true;
                  }

                  // Does this work on all platforms?  Wasn't e.clickCount unstable on one platform?
                  if (e.clickCount == 2)
                  {
                     OpenLogicNode();
                  }

                  m_MouseDown = true;
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
               m_MouseUpArgs = new System.Windows.Forms.MouseEventArgs();

               int button = 0;

               if (e.button == 0) button = MouseButtons.Left;
               else if (e.button == 1) button = MouseButtons.Right;
               else if (e.button == 2) button = MouseButtons.Middle;

               m_MouseUpArgs.Button = button;
               m_MouseUpArgs.X = (int)(e.mousePosition.x);
               if (!m_HidePanelMode) m_MouseUpArgs.X -= _guiPanelPalette_Width;
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
               m_ZoomPoint = System.Windows.Forms.Cursor.Position;

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
      if (EditorApplication.isPlayingOrWillChangePlaymode && m_ScriptEditorCtrl != null && true == m_ScriptEditorCtrl.IsDirty)
      {
         EditorUtility.DisplayDialog("uScript Not Saved!", "uScript has detected that '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' has been changed, but not saved! You will not see any changes until you save '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' in the uScript Editor.", "OK");
      }
      else if (EditorApplication.isPlayingOrWillChangePlaymode && m_ScriptEditorCtrl != null && true == m_ScriptEditorCtrl.CodeIsStale )
      {
         EditorUtility.DisplayDialog("uScript Not Saved!", "uScript has detected that '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' was quick saved but the code has not been generated! You will not see any changes until you save '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' in the uScript Editor.", "OK");
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

      MasterComponent.Script = null;
      MasterComponent.ScriptName = null;

      CurrentScript = null;
      CurrentScriptName = null;

      // reset settings so they get re-loaded
      m_SettingsLoaded = false;
      m_AppData = new AppFrameworkData();
      Preferences = new Preferences();
   }

   void OpenLogicNode()
   {
      if (m_ScriptEditorCtrl.SelectedNodes.Length == 1)
      {
         EntityNode entityNode = m_ScriptEditorCtrl.SelectedNodes[0].EntityNode;

         if (entityNode is LogicNode)
         {
            LogicNode logicNode = (LogicNode)entityNode;

            string uscriptPath = Preferences.UserScripts;

            if (logicNode.Type.EndsWith(uScriptConfig.Files.GeneratedCodeExtension))
            {
               string script = uscriptPath + "/" + logicNode.Type.Substring(0, logicNode.Type.LastIndexOf(uScriptConfig.Files.GeneratedCodeExtension));
               script += ".uscript";

               if (System.IO.File.Exists(script))
               {
                  OpenScript(script);
               }
            }
         }
      }
   }



   void DrawMainGUI()
   {
      uScriptGUIContent.Init();
      uScriptGUIStyle.Init();
      uScriptGUI.InitPanels();

      DrawGUITopAreas();
      if (!m_HidePanelMode)
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
         Repaint();
      }
   }

   void DrawGUITopAreas()
   {
      EditorGUILayout.BeginHorizontal();
      {
         if (!m_HidePanelMode)
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
      EditorGUILayout.BeginHorizontal(GUILayout.Height(_guiPanelProperties_Height));
      {
         uScriptGUIPanelProperty.Instance.Draw();
//         DrawGUIPropertyGrid();

         DrawGUIVerticalDivider();
         SetMouseRegion(MouseRegion.HandleProperties);//, -3, 3, 6, -3 );

         uScriptGUIPanelReference.Instance.Draw();
//         DrawGUIHelp();

         DrawGUIVerticalDivider();
         SetMouseRegion(MouseRegion.HandleReference);//, -3, 3, 6, -3 );

         uScriptGUIPanelScript.Instance.Draw();
//         DrawGUINestedScripts();
      }
      EditorGUILayout.EndHorizontal();
   }

   void DrawGUIHorizontalDivider()
   {
      GUILayout.Box("", uScriptGUIStyle.hDivider, GUILayout.Height(DIVIDER_WIDTH), GUILayout.ExpandWidth(true));
   }

   void DrawGUIVerticalDivider()
   {
      GUILayout.Box("", uScriptGUIStyle.vDivider, GUILayout.Width(DIVIDER_WIDTH), GUILayout.ExpandHeight(true));
   }

//   int counter = 0;

   void OnGUI_DrawStatusbar()
   {
      Event e = Event.current;

      if (GUI.tooltip != _statusbarMessage || e.type == EventType.MouseMove)
      {
         _statusbarMessage = GUI.tooltip;
      }

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

//      extraDetails = "Counter: " + (int)(counter++ / 50) + " - " + extraDetails;

      EditorGUILayout.BeginHorizontal();
      {
//         GUILayout.Label(GUIUtility.keyboardControl + "\t\t" + _statusbarMessage, GUILayout.ExpandWidth(true));
         GUILayout.Label(_statusbarMessage, GUILayout.ExpandWidth(true));
         GUILayout.Label(extraDetails, GUILayout.ExpandWidth(false));
      }
      EditorGUILayout.EndHorizontal();
   }




   Dictionary<string, bool> _foldoutsGraphContent = new Dictionary<string, bool>();


   void DrawGUIPalette()
   {
      Rect r = EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, GUILayout.Width(_guiPanelPalette_Width));
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
         {
            string[] options = new string[] { "Nodes Palette", "Graph Contents" };

            Vector2 size = uScriptGUIStyle.panelTitleDropDown.CalcSize(new GUIContent(options[1]));

            _paletteMode = EditorGUILayout.Popup(_paletteMode, options, uScriptGUIStyle.panelTitleDropDown, GUILayout.Width(size.x));

            //            GUILayout.Label("Nodes", uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));

            GUILayout.FlexibleSpace();

            if (_paletteMode == 0)
            {
               // Toggle hierarchy foldouts
               bool newToggleState = GUILayout.Toggle(_paletteFoldoutToggle,
                                                      (_paletteFoldoutToggle ? uScriptGUIContent.buttonListCollapse : uScriptGUIContent.buttonListExpand),
                                                      uScriptGUIStyle.paletteToolbarButton,
                                                      GUILayout.ExpandWidth(false));
               if (_paletteFoldoutToggle != newToggleState)
               {
                  _paletteFoldoutToggle = newToggleState;
                  ExpandPaletteMenuItemFoldouts(_paletteFoldoutToggle);
               }

               GUI.SetNextControlName("FilterSearch");
               string _filterText = uScriptGUI.ToolbarSearchField(_paletteFilterText, GUILayout.Width(100));
               //               string _filterText = GUILayout.TextField(_paletteFilterText, 10, "toolbarTextField", GUILayout.Width(80));
               GUI.SetNextControlName("");
               if (_filterText != _paletteFilterText)
               {
                  // Drop focus if the user inserted a newline (hit enter)
                  if (_filterText.Contains('\n'))
                  {
                     GUIUtility.keyboardControl = 0;
                  }

                  // Trim leading whitespace
                  _filterText = _filterText.TrimStart(new char[] { ' ' });

                  _paletteFilterText = _filterText;
                  FilterPaletteMenuItems();
               }
            }
            else
            {
               // This is where the Graph Contents toolbar buttons will go

               GUI.SetNextControlName("FilterSearch");
               string _filterText = uScriptGUI.ToolbarSearchField(_graphListFilterText, GUILayout.Width(100));
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
               // Node list
               //
               _guiPanelPalette_ScrollPos = EditorGUILayout.BeginScrollView(_guiPanelPalette_ScrollPos, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview", GUILayout.ExpandWidth(true));
               {
                  if (Event.current.type == EventType.Repaint)
                  {
                     _hotSelection = null;
                  }

                  foreach (PaletteMenuItem item in _paletteMenuItems)
                  {
                     if (DrawPaletteMenu(item))
                     {
                        filterMatches++;
                     }
                  }

                  if (filterMatches == 0)
                  {
                     GUILayout.Label("The search found no matches!", uScriptGUIStyle.panelMessageBold);
                  }
               }
               EditorGUILayout.EndScrollView();
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

      if ((int)r.width != 0 && (int)r.width != _guiPanelPalette_Width)
      {
         _guiPanelPalette_Width = (int)r.width;
      }

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
      if (!m_HidePanelMode) return false;

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


   private static Dictionary<string, bool> _paletteMenuItemFoldout = new Dictionary<string, bool>();


   //
   // Use recursion to set all menu item foldouts in the node palette
   //
   private void ExpandPaletteMenuItemFoldouts(bool state)
   {
      string[] keys = _paletteMenuItemFoldout.Keys.ToArray();
      foreach (string key in keys)
      {
         _paletteMenuItemFoldout[key] = state;
      }
   }


   private void FilterPaletteMenuItems()
   {
      foreach (PaletteMenuItem item in _paletteMenuItems)
      {
         item.Hidden = FilterPaletteMenuItem(item, false);
      }
   }


   private bool FilterPaletteMenuItem(PaletteMenuItem paletteMenuItem, bool shouldForceVisible)
   {
      // return TRUE if the parent or item should be hidden
      if (shouldForceVisible || paletteMenuItem.Name.ToLower().Contains(_paletteFilterText.ToLower()))
      {
         // filter matched, so this and all children should be visible
         if (paletteMenuItem.Items != null)
         {
            foreach (PaletteMenuItem item in paletteMenuItem.Items)
            {
               item.Hidden = FilterPaletteMenuItem(item, true);
            }
         }
         return false;
      }
      else if (paletteMenuItem.Items != null)
      {
         // check each child to see if this should be visible
         bool shouldHideParent = true;
         foreach (PaletteMenuItem item in paletteMenuItem.Items)
         {
            item.Hidden = FilterPaletteMenuItem(item, false);
            if (item.Hidden == false)
            {
               shouldHideParent = false;
            }
         }

         return shouldHideParent;
      }

      // has no children and wasn't a match
      return true;
   }





   private void BuildPaletteMenu(ToolStripItem contextMenuItem, PaletteMenuItem paletteMenuItem, string paletteMenuItemParent)
   {
      if (contextMenuItem == null || paletteMenuItem == null)
      {
         //
         // Create a new palette menu, destroying the old one
         //
         _paletteMenuItems = new List<PaletteMenuItem>();

         foreach (ToolStripItem item in m_ScriptEditorCtrl.ContextMenu.Items.Items)
         {
            if ((item is ToolStripMenuItem) && (item.Text == "Add..."))
            {
               foreach (ToolStripItem subitem in ((ToolStripMenuItem)item).DropDownItems.Items)
               {
                  PaletteMenuItem paletteItem = new PaletteMenuItem();
                  paletteItem.Indent = 0;

                  BuildPaletteMenu(subitem, paletteItem, string.Empty);

                  _paletteMenuItems.Add(paletteItem);
               }
            }
         }
      }
      else if (!(contextMenuItem is ToolStripSeparator))
      {
         if ((contextMenuItem is ToolStripMenuItem) && ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items.Count > 0)
         {
            // This is a foldout
            paletteMenuItem.Name = contextMenuItem.Text.Replace("...", "");
            paletteMenuItem.Path = (string.IsNullOrEmpty(paletteMenuItemParent) ? string.Empty : paletteMenuItemParent + "/") + paletteMenuItem.Name;
            paletteMenuItem.Items = new List<PaletteMenuItem>();

            if (_paletteMenuItemFoldout.ContainsKey(paletteMenuItem.Path) == false)
            {
               _paletteMenuItemFoldout.Add(paletteMenuItem.Path, false);
            }

            foreach (ToolStripItem item in ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items)
            {
               PaletteMenuItem newItem = new PaletteMenuItem();
               newItem.Indent = paletteMenuItem.Indent + 1;
               if (item == null || newItem == null)
               {
                  uScriptDebug.Log("Trying to pass a null parameter to BuildPaletteMenu()!\n", uScriptDebug.Type.Error);
                  return;
               }
               BuildPaletteMenu(item, newItem, paletteMenuItem.Path);
               paletteMenuItem.Items.Add(newItem);
            }
         }
         else
         {
            // This is a menu item
            paletteMenuItem.Name = contextMenuItem.Text.Replace("&", "");
            paletteMenuItem.Tooltip = FindNodeToolTip(ScriptEditor.FindNodeType(contextMenuItem.Tag as EntityNode));
            paletteMenuItem.Click = contextMenuItem.Click;
            paletteMenuItem.Tag = contextMenuItem.Tag;
         }
      }
      else
      {
         uScriptDebug.Log("The contextMenuItem (" + contextMenuItem.Text + ") is a " + contextMenuItem.GetType() + " and is unhandled!\n", uScriptDebug.Type.Warning);
      }
   }

   private bool DrawPaletteMenu(PaletteMenuItem item)
   {
      if (item.Hidden)
      {
         return false;
      }

      if (item.Items != null)
      {
         // This is should be a folding menu item that contains more buttons
         GUIStyle tmpStyle = new GUIStyle(uScriptGUIStyle.paletteFoldout);
         tmpStyle.margin = new RectOffset(tmpStyle.margin.left + (item.Indent * 12), 0, 0, 0);

         _paletteMenuItemFoldout[item.Path] = GUILayout.Toggle(_paletteMenuItemFoldout[item.Path], item.Name, tmpStyle);
         if (_paletteMenuItemFoldout[item.Path])
         {
            foreach (PaletteMenuItem subitem in item.Items)
            {
               DrawPaletteMenu(subitem);
            }
         }
      }
      else
      {
         // This is a simple menu item
         GUIStyle tmpStyle = new GUIStyle(uScriptGUIStyle.paletteButton);
         tmpStyle.margin = new RectOffset(tmpStyle.margin.left + 0 + (item.Indent * 12),
                                       tmpStyle.margin.right,
                                       tmpStyle.margin.top,
                                       tmpStyle.margin.bottom);

         if (GUILayout.Button(new GUIContent(item.Name, item.Tooltip), tmpStyle))
         {
            if (item.Click != null)
            {
               // Create the node on the canvas
               int halfWidth = (int)(uScript.Instance.NodeWindowRect.width / 2.0f);
               int halfHeight = (int)(uScript.Instance.NodeWindowRect.height / 2.0f);
               Point center = new Point(halfWidth, halfHeight);
               m_ScriptEditorCtrl.ContextCursor = center;
               item.OnClick();
               uScriptDebug.Log("Clicked '" + item.Name + "'\n", uScriptDebug.Type.Debug);
            }
            else
            {
               uScriptDebug.Log("Cannot execute menu item: " + item.Name + "\n", uScriptDebug.Type.Debug);
            }
         }

         // if hovering over the button, display the reference description
         if (Event.current.type == EventType.Repaint)
         {
            Rect rect = GUILayoutUtility.GetLastRect();
            rect.width = Mathf.Min(rect.width, _guiPanelPalette_Width - rect.x - 15);
            if (rect.Contains(Event.current.mousePosition))
            {
//               Debug.Log(_guiPanelPalette_Width.ToString() + ", " + rect.width.ToString() + "\n");
               _hotSelection = item.Tag as EntityNode;
            }
         }
      }

      return true;
   }



   EntityNode _hotSelection = null;





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
      Vector2 v = EditorStyles.boldLabel.CalcSize(new GUIContent(shortcut));

      // place the string at the left inside edge of the previous rect
      r = new Rect(r.x + r.width - 20 + ((12 - v.x) / 2), r.y + 2, v.x, v.y);

//      Debug.Log("Shortcut: '" + shortcut + "' is " + v.x + "px wide\n");
      GUI.Label(r, shortcut, EditorStyles.boldLabel);
   }


   void DrawFileMenuWindow(int windowID)
   {
      if (GUILayout.Button(uScriptGUIContent.buttonScriptNew, uScriptGUIStyle.menuDropDownButton))
      {
         FileMenuItem_New();
      }
      DrawMenuItemShortcut("N");

      if (GUILayout.Button(uScriptGUIContent.buttonScriptOpen, uScriptGUIStyle.menuDropDownButton))
      {
         FileMenuItem_Open();
      }
      DrawMenuItemShortcut("O");

      if (GUILayout.Button(uScriptGUIContent.buttonScriptSave, uScriptGUIStyle.menuDropDownButton))
      {
         FileMenuItem_Save();
      }
      DrawMenuItemShortcut("S");

      if (GUILayout.Button(uScriptGUIContent.buttonScriptSaveAs, uScriptGUIStyle.menuDropDownButton))
      {
         FileMenuItem_SaveAs();
      }
      DrawMenuItemShortcut("A");

      if (GUILayout.Button(uScriptGUIContent.buttonScriptSaveQuick, uScriptGUIStyle.menuDropDownButton))
      {
         FileMenuItem_QuickSave();
      }
      DrawMenuItemShortcut("Q");

      if (GUILayout.Button(uScriptGUIContent.buttonScriptSaveDebug, uScriptGUIStyle.menuDropDownButton))
      {
         FileMenuItem_DebugSave();
      }
      DrawMenuItemShortcut("D");

      if (GUILayout.Button(uScriptGUIContent.buttonScriptSaveRelease, uScriptGUIStyle.menuDropDownButton))
      {
         FileMenuItem_ReleaseSave();
      }
      DrawMenuItemShortcut("R");

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



   void RequestSave(bool quick, bool debug, bool rename)
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

         GenerateDebugInfo = _saveMethod != 2;  // "Release" is not selected

         if (saved) RefreshScript();
      }
      isFileMenuOpen = false;
   }

   void FileMenuItem_Save()
   {
      RequestSave(_saveMethod == 0, _saveMethod == 1, false);
   }

   void FileMenuItem_SaveAs()
   {
      RequestSave(_saveMethod == 0, _saveMethod == 1, true);
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


   void FileMenuItem_RebuildAll()
   {
      RebuildAllScripts();
      isFileMenuOpen = false;
   }

   void FileMenuItem_Clean()
   {
      AssetDatabase.StartAssetEditing();
      RemoveGeneratedCode(Preferences.GeneratedScripts);
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

            _saveMethod = uScriptGUI.ToolbarButtonGroup("Save method: ", _saveMethod, new GUIContent[] { uScriptGUIContent.buttonSaveModeQuick, uScriptGUIContent.buttonSaveModeDebug, uScriptGUIContent.buttonSaveModeRelease });
            GenerateDebugInfo = _saveMethod != 2;  // "Release" is not selected

            GUILayout.FlexibleSpace();

            GUIStyle style2 = new GUIStyle(EditorStyles.label);
            style2.padding = new RectOffset(16, 4, 2, 2);
            style2.margin = new RectOffset();
			   GUILayout.Label(FullVersionName, style2); // Changed this to show the build number.
				
			/*
   			GUIStyle style2 = new GUIStyle(EditorStyles.boldLabel);
            style2.padding = new RectOffset(16, 4, 2, 2);
            style2.margin = new RectOffset();
	   		GUILayout.Label(FullVersionName, style2); // Changed this to show the build number.
            if (m_ScriptEditorCtrl != null && !string.IsNullOrEmpty(m_ScriptEditorCtrl.ScriptName))
            {
               int dot = m_ScriptEditorCtrl.ScriptName.IndexOf(".");
               string filename = m_ScriptEditorCtrl.ScriptName;
               if (dot != -1)
               {
                  filename = m_ScriptEditorCtrl.ScriptName.Substring(0, m_ScriptEditorCtrl.ScriptName.IndexOf("."));
               }

               GUILayout.Label(filename, style2);
            }
            */
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
               args.Graphics = new System.Drawing.Graphics();

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

   private int _paletteMode = 0;
   bool _wasMoving = false;

   Vector2 _scrollNewProperties;
   // END TEMP Variables




   void m_ScriptEditorCtrl_ScriptModified(object sender, EventArgs e)
   {
      Repaint();
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

      System.Windows.Forms.Cursor.Position.X = m_MouseDownArgs.X;
      System.Windows.Forms.Cursor.Position.Y = m_MouseDownArgs.Y;

//      Debug.Log("BUTTON " + Control.MouseButtons.Buttons + " - OnMouseDown() at " + System.Windows.Forms.Cursor.Position.ToString() + "\n");

      m_ScriptEditorCtrl.OnMouseDown(m_MouseDownArgs);
   }

   public void OnMouseUp()
   {
      System.Windows.Forms.Cursor.Position.X = m_MouseUpArgs.X;
      System.Windows.Forms.Cursor.Position.Y = m_MouseUpArgs.Y;

//      Debug.Log("BUTTON " + Control.MouseButtons.Buttons + " - OnMouseUp() at " + System.Windows.Forms.Cursor.Position.ToString() + "\n");

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
//                + (_guiPanelPalette_Width + DIVIDER_WIDTH - 1).ToString());

      System.Windows.Forms.Cursor.Position.X = m_MouseMoveArgs.X;
      System.Windows.Forms.Cursor.Position.Y = m_MouseMoveArgs.Y;

      if (_mouseRegion == MouseRegion.Canvas)
      {
         m_ScriptEditorCtrl.OnMouseMove(m_MouseMoveArgs);
      }

      // convert back to screen
      m_MouseMoveArgs.X += (int)_canvasRect.x;
      m_MouseMoveArgs.Y += (int)_canvasRect.y;

      // check for divider draggging
      if (GUI.enabled && !m_HidePanelMode && m_MouseDown)
      {
         if (m_MouseDownRegion == MouseRegion.HandleCanvas)
         {
            _guiPanelProperties_Height -= deltaY;
            Repaint();
         }
         else if (m_MouseDownRegion == MouseRegion.HandlePalette)
         {
            _guiPanelPalette_Width += deltaX;
            Repaint();
         }
         else if (m_MouseDownRegion == MouseRegion.HandleProperties)
         {
            _guiPanelProperties_Width += deltaX;
            Repaint();
         }
         else if (m_MouseDownRegion == MouseRegion.HandleReference)
         {
            _guiPanelSequence_Width -= deltaX;
            Repaint();
         }
      }
   }



   public void Redraw()
   {
      if (true == m_Repainting) return;

      m_Repainting = true;

      Repaint();

      m_Repainting = false;
   }

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
      Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor("", PopulateEntityTypes(null), PopulateLogicTypes());

      m_ScriptEditorCtrl = new ScriptEditorCtrl(scriptEditor);
      m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);

      m_ScriptEditorCtrl.BuildContextMenu();
      BuildPaletteMenu(null, null, string.Empty);

      m_FullPath = "";

      uScript.SetSetting("uScript\\LastOpened", "");
      uScript.SetSetting("uScript\\LastScene", UnityEditor.EditorApplication.currentScene);
   }

   public bool OpenScript(string fullPath)
   {
      if (false == AllowNewFile(true) || !System.IO.File.Exists(fullPath)) return false;

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

         UnityEditor.Undo.ClearUndo(MasterComponent);

         //force a change which will for a script rebuild in Update
         //this keeps all the loading in the same place
         MasterComponent.Script = scriptEditor.ToBase64();
         MasterComponent.ScriptName = scriptEditor.Name;

         CurrentScript = null;
         CurrentScriptName = null;

         if (fullPath != m_FullPath) m_CurrentCanvasPosition = "";

         m_FullPath = fullPath;

         uScript.SetSetting("uScript\\LastOpened", uScriptConfig.ConstantPaths.RelativePath(fullPath).Substring("Assets".Length));
         uScript.SetSetting("uScript\\LastScene", UnityEditor.EditorApplication.currentScene);
      }
      else
      {
         uScriptDebug.Log("An error occured opening " + fullPath, uScriptDebug.Type.Error);
         return false;
      }

      return true;
   }

   public void StubComponentFile(string path)
   {
      try
      {
         System.IO.StreamWriter stream = new System.IO.StreamWriter( path );
         stream.WriteLine( "using UnityEngine;" );
         stream.WriteLine( "public class " + System.IO.Path.GetFileNameWithoutExtension(path) + " : uScriptCode" );
         stream.WriteLine( "{}" );

         stream.Close( );
      }
      catch ( Exception e )
      {
         uScriptDebug.Log("An error occured stubbing component file " + path + "(" + e.Message + ")", uScriptDebug.Type.Error);
      }
   }

   public void RemoveGeneratedCode(string path)
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);

      System.IO.FileInfo[] files = directory.GetFiles();

      foreach (System.IO.FileInfo file in files)
      {
         string relativePath = uScriptConfig.ConstantPaths.RelativePath(file.FullName);

         if (file.FullName.EndsWith(uScriptConfig.Files.GeneratedComponentExtension + ".cs"))
         {
            StubComponentFile(relativePath);
         }
         else
         {
            AssetDatabase.DeleteAsset(relativePath);
         }
      }
   }

   public void RebuildAllScripts()
   {
      //first remove everything so we get rid of any compiler errors
      //which allows the reflection to properly refresh
      AssetDatabase.StartAssetEditing();
      RemoveGeneratedCode(Preferences.GeneratedScripts);
      AssetDatabase.StopAssetEditing();
      AssetDatabase.Refresh();

      m_RebuildWhenReady = true;
   }

   public void RebuildScripts(string path)
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
            if (true == SaveScript(scriptEditor, file.FullName, true, GenerateDebugInfo))
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
         RebuildScripts(subDirectory.FullName);
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

   private bool SaveScript(Detox.ScriptEditor.ScriptEditor script, string binaryPath, bool generateCode, bool generateDebugInfo)
   {
      bool result;

      if ( true == generateCode )
      {
         string wrapperPath = GetGeneratedScriptPath(binaryPath);
         string logicPath   = GetNestedScriptPath(binaryPath);

         result = script.Save(binaryPath, logicPath, wrapperPath, generateDebugInfo);

         if (true == result)
         {
            //we're attempting to just attach components at runtime
            //but i'm leaving this function here just in case we want
            //to call it to help performance by auto attaching the scripts before they run
            //AttachEventScriptsToOwners(script);

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

//uScriptDebug.Log("6 - Inside SaveScript(): " + script.Name + "\n", uScriptDebug.Type.Warning);

         if (true == SaveScript(script, m_FullPath, generateCode, GenerateDebugInfo))
         {

//uScriptDebug.Log("7 - Inside SaveScript(): " + script.Name + "\n\t\t\t\t At this point, script.Name lost the file extension!", uScriptDebug.Type.Error);

            m_ScriptEditorCtrl.IsDirty = false;

            //force a sync here just in case somehwere in code
            //we missed a call to the change stack
            MasterComponent.Script = script.ToBase64();
            MasterComponent.ScriptName = script.Name;

            CurrentScript = MasterComponent.Script;
            CurrentScriptName = MasterComponent.ScriptName;

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

   void AttachEventScriptsToOwners(ScriptEditor script)
   {
      foreach (EntityEvent entityEvent in script.Events)
      {
         LinkNode[] links = script.GetLinksByDestination(entityEvent.Guid, entityEvent.Instance.Name);

         if ("" != entityEvent.Instance.Default)
         {
            AttachEventScriptToGameObject(GameObject.Find(entityEvent.Instance.Default), entityEvent.ComponentType);
         }

         foreach (LinkNode link in links)
         {
            EntityNode node = script.GetNode(link.Source.Guid);

            //for each owner connected to an event instance
            //add the required event component script
            if (node is OwnerConnection)
            {
               AttachEventScriptToGameObjects(script.Name, entityEvent.ComponentType);
            }
            else if (node is LocalNode)
            {
               //for each gameobject used as an event instance
               //add the required event component script
               AttachEventScriptToGameObject(GameObject.Find(((LocalNode)node).Value.Default), entityEvent.ComponentType);
            }
         }
      }
   }

   //go through all game objects and if they have the uscript attached to them
   //then also attach the event component script
   void AttachEventScriptToGameObjects(string scriptWhichMustExist, string componentTypeToAttach)
   {
      UnityEngine.Object[] objects = FindObjectsOfType(typeof(GameObject));

      foreach (UnityEngine.Object o in objects)
      {
         GameObject gameObject = o as GameObject;

         if (null != gameObject.GetComponent(scriptWhichMustExist))
         {
            AttachEventScriptToGameObject(o as GameObject, componentTypeToAttach);
         }
      }
   }

   //attach the event component script if it's not already on the game object
   void AttachEventScriptToGameObject(GameObject gameObject, string componentTypeToAttach)
   {
      if (null == gameObject) return;

      if (null == gameObject.GetComponent(componentTypeToAttach))
      {
         gameObject.AddComponent(componentTypeToAttach);
      }

      //print out a warning if the newly attached script still won't function
      //because some other required component is missing
      NodeComponentType requiredComponentType = FindNodeComponentType(MasterComponent.GetType(componentTypeToAttach));

      bool componentWarning = true;

      if (null != requiredComponentType)
      {
         //go through all the components and see if the required one exists
         Component[] components = gameObject.GetComponents<Component>();

         foreach (Component c in components)
         {
            //yes for some reason unity is giving me null components
            if (null == c) continue;

            if (requiredComponentType.ContainsType(c.GetType()))
            {
               componentWarning = false;
               break;
            }
         }
      }
      else
      {
         componentWarning = false;
      }

      if (true == componentWarning)
      {
         string names = "";

         foreach (Type t in requiredComponentType.ComponentTypes)
         {
            names += t + ", ";
         }

         if (names.Length >= 2) names = names.Substring(0, names.Length - 2);

         Debug.LogWarning(componentTypeToAttach + " was attached to " + gameObject.name +
                           " but one of the following additional components is required for it to function properly " + names);
      }
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
      Hashtable baseMethods = new Hashtable();
      Hashtable baseEvents = new Hashtable();
      Hashtable baseProperties = new Hashtable();

      Dictionary<Type, Type> uniqueNodes = new Dictionary<Type, Type>();

      GatherDerivedTypes(uniqueNodes, uScriptConfig.ConstantPaths.uScriptNodes, typeof(uScriptLogic));

      GatherDerivedTypes(uniqueNodes, Preferences.UserNodes, typeof(uScriptLogic));
      GatherDerivedTypes(uniqueNodes, Preferences.NestedScripts, typeof(uScriptLogic));

      MethodInfo[] methods = typeof(uScriptLogic).GetMethods();

      foreach (MethodInfo m in methods)
      {
         if (true == m.IsPublic)
         {
            baseMethods[m.Name] = m.Name;
         }
      }

      methods = typeof(ScriptableObject).GetMethods();

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

      List<Type> types = new List<Type>(uniqueNodes.Values);
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

         foreach (EventInfo e in type.GetEvents())
         {
            Plug p;
            p.Name = e.Name;
            p.FriendlyName = FindFriendlyName(p.Name, e.GetCustomAttributes(false));

            logicEvents.Add(p);
         }

         logicNode.Events = logicEvents.ToArray();


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

      return OverrideNestedScriptTypes(logicNodes.ToArray());
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
            LogicNode logicNode = new LogicNode(rawScript.Type, rawScript.Type);
   
            logicNode.Parameters = rawScript.ExternalParameters;
            logicNode.Inputs = rawScript.ExternalInputs;
            logicNode.Outputs = rawScript.ExternalOutputs;
            logicNode.Events = rawScript.ExternalEvents;
            logicNode.Drivens = rawScript.Drivens;
            logicNode.RequiredMethods = rawScript.RequiredMethods;

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
               AddRequiresLink(type.ToString(), p.Name, p.GetCustomAttributes(false));
               MasterComponent.AddType(p.PropertyType);

               eventInputsOutpus.Add(input);
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
            if (true == baseProperties.Contains(p.Name)) continue;

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
      Hashtable baseMethods = new Hashtable();
      Hashtable baseEvents = new Hashtable();
      Hashtable baseProperties = new Hashtable();

      List<EntityDesc> entityDescs = new List<EntityDesc>();

      foreach (MethodInfo m in typeof(UnityEngine.Behaviour).GetMethods())
      {
         baseMethods[m.Name] = m.Name;
      }

      foreach (EventInfo e in typeof(UnityEngine.Behaviour).GetEvents())
      {
         baseEvents[e.Name] = e.Name;
      }

      foreach (PropertyInfo p in typeof(UnityEngine.Behaviour).GetProperties())
      {
         baseProperties[p.Name] = p.Name;
      }

      foreach (MethodInfo m in typeof(UnityEngine.MonoBehaviour).GetMethods())
      {
         baseMethods[m.Name] = m.Name;
      }

      foreach (EventInfo e in typeof(UnityEngine.MonoBehaviour).GetEvents())
      {
         baseEvents[e.Name] = e.Name;
      }

      foreach (PropertyInfo p in typeof(UnityEngine.MonoBehaviour).GetProperties())
      {
         baseProperties[p.Name] = p.Name;
      }

      foreach (MethodInfo m in typeof(UnityEngine.Object).GetMethods())
      {
         baseMethods[m.Name] = m.Name;
      }

      foreach (EventInfo e in typeof(UnityEngine.Object).GetEvents())
      {
         baseEvents[e.Name] = e.Name;
      }

      foreach (PropertyInfo p in typeof(UnityEngine.Object).GetProperties())
      {
         baseProperties[p.Name] = p.Name;
      }

      foreach (MethodInfo m in typeof(UnityEngine.GameObject).GetMethods())
      {
         baseMethods[m.Name] = m.Name;
      }

      foreach (EventInfo e in typeof(UnityEngine.GameObject).GetEvents())
      {
         baseEvents[e.Name] = e.Name;
      }

      foreach (PropertyInfo p in typeof(UnityEngine.GameObject).GetProperties())
      {
         baseProperties[p.Name] = p.Name;
      }

      foreach (MethodInfo m in typeof(UnityEngine.Component).GetMethods())
      {
         baseMethods[m.Name] = m.Name;
      }

      foreach (EventInfo e in typeof(UnityEngine.Component).GetEvents())
      {
         baseEvents[e.Name] = e.Name;
      }

      foreach (PropertyInfo p in typeof(UnityEngine.Component).GetProperties())
      {
         baseProperties[p.Name] = p.Name;
      }

      List<UnityEngine.Object> allObjects = new List<UnityEngine.Object>(FindObjectsOfType(typeof(UnityEngine.Object)));
      Dictionary<string, Type> uniqueObjects = new Dictionary<string, Type>();

      Dictionary<Type, Type> eventNodes = new Dictionary<Type, Type>();
      GatherDerivedTypes(eventNodes, uScriptConfig.ConstantPaths.uScriptNodes, typeof(uScriptEvent));
      GatherDerivedTypes(eventNodes, Preferences.UserNodes, typeof(uScriptEvent));

      foreach (UnityEngine.Object o in allObjects)
      {
         //ignore our uscripts, they are handled separately
         if (typeof(uScriptCode).IsAssignableFrom(o.GetType())) continue;
         if (typeof(uScriptLogic).IsAssignableFrom(o.GetType())) continue;

         uniqueObjects[o.GetType().ToString()] = o.GetType();
      }

      foreach (Type t in eventNodes.Values)
      {
         uniqueObjects[t.ToString()] = t;
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

      List<Type> types = new List<Type>(uniqueObjects.Values);
      types.Sort(TypeSorter);

      foreach (Type t in types)
      {
         if (t == typeof(uScript_MasterComponent)) continue;

         Reflect(t, entityDescs, baseMethods, baseEvents, baseProperties);
      }

      Reflect(typeof(UnityEngine.RuntimePlatform), entityDescs, baseMethods, baseEvents, baseProperties);

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

      return descs;
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
            if (a is SocketState)
            {
               SocketState s = (SocketState)a;

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

   public static string FindFriendlyName(string defaultName, object[] attributes)
   {
      if (null == attributes) return defaultName;

      foreach (object a in attributes)
      {
         if (a is FriendlyName)
         {
            return ((FriendlyName)a).Name;
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

   public static string FindNodeDescription(string type, EntityNode node)
   {
      // check non-logic, non-event types first...
      // structs can't have attributes, so we have to specify this information here, explicitly
      if (type == "CommentNode")
      {
         return "Use a comment box to comment or hint at what a particular block of uScript nodes does. Comment boxes can be resized so that they surround the nodes that they are referencing.\n \nTo resize a comment box, drag the bottom-right corner of the comment box or set its width/height properties explicitly in the Properties panel.\n \nTitle: The title or header for this comment box.\nBody: The actual comment text and information. Empty lines are supported.\nWidth: The width of the comment box in pixels.\nHeight: The height of the comment box in pixels.";
      }
      else if (type == "ExternalConnection")
      {
         return "Use External Connections to create nested uScripts. An External Connection node will turn into a socket when the current uScript is used as a nested uScript inside another uScript. The type of socket it turns into will be determined by the type of socket it is connected to in this uScript.\n \nTo place this uScript in another uScript as a nested uScript, save it and then look for it under the Scene()->Logic menu of the node palette or 'Add' context menu.";
      }
      else if (type == "OwnerConnection")
      {
         return "Owner GameObject variables are a special kind of GameObject variable. They represent the GameObject that this uScript is attached to.";
      }
      else if (type == "LocalNode")
      {
         LocalNode variable = (LocalNode)node;
         string friendlyType = uScriptConfig.Variable.FriendlyName(variable.Value.Type);

         switch (friendlyType)
         {
            case "Bool":
               return "A Boolean variable.\n \nValue can be True or False.";
            case "Color":
               return "A Color variable.\n \nValue is a color represented by an R,G,B triplet.";
            case "Float":
               return "A Floating point variable.\n \nValue is any real number (ex. 1.234, 5.0, -3.21).";
            case "Int":
               return "An Integer variable.\n \nValue is any whole number (ex. 1, 0, -3).";
            case "Vector2":
               return "A Vector2 variable.\n \nValue is a 2-dimensional point in space (x,y).";
            case "Vector3":
               return "A Vector3 variable.\n \nValue is a 3-dimensional point or direction in space (x,y,z).";
            case "Vector4":
               return "A Vector4 variable.\n \nValue is a 3-dimensional point or direction in space with a w-value (x,y,z,w).";
            case "Rect":
               return "A Rect variable.\n \nValue contains a 2-dimensional position (x,y) and an area (width, height).";
            case "Quaternion":
               return "A Quaternion variable.\n \nValue is quaternion representation of a rotation in space.";
            case "GameObject":
               return "A GameObject variable.\n \nValue is a GameObject in the scene. Note that if a GameObject is being used as a node's input parameter, it is set by name and when this is done, it must be unique in the scene.";
            case "String":
               return "A String variable.\n \nValue is text data.";
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
            if (a is NodeDescription)
            {
               return ((NodeDescription)a).Value;
            }
         }
      }

      return "";
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

   public static NodeComponentType FindNodeComponentType(Type type)
   {
      if (type != null)
      {
         object[] attributes = type.GetCustomAttributes(false);
         if (null == attributes) return null;

         foreach (object a in attributes)
         {
            if (a is NodeComponentType)
            {
               return ((NodeComponentType)a);
            }
         }
      }

      return null;
   }
}