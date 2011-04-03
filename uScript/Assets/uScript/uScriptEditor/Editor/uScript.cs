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

//todo
//do all the nodes
//automaic sizing based off padding
//padding numbers in uscript config
//generate all nodes based on padding numbers
// --create node in onpaint so we can get text size

public class uScript : EditorWindow
{
   static private uScript s_Instance = null;
   static public uScript Instance { get { if ( null == s_Instance ) Init( ); return s_Instance; } }
   private bool isPro;

   private ScriptEditorCtrl m_ScriptEditorCtrl = null;
   private bool m_MouseDown  = false;
   private bool m_Repainting = false;
   private bool m_WantsUndo  = false;
   private bool m_WantsRedo  = false;
   private bool m_WantsCopy  = false;
   private bool m_WantsPaste = false;
   private bool m_WantsRefresh = false;

   private string m_FullPath = "";

   static private AppFrameworkData m_AppData = new AppFrameworkData();
   private double m_RefreshTimestamp = -1.0;

   private int m_ContextX = 0;
   private int m_ContextY = 0;
   private ToolStripItem m_CurrentMenu = null;

   Rect m_NodeWindowRect;
   public Rect NodeWindowRect { get { return m_NodeWindowRect; } }

   Rect m_NodeToolbarRect;
   public Rect NodeToolbarRect { get { return m_NodeToolbarRect; } }

   private Hashtable m_Types = new Hashtable();

   /* uScript GUI Window Panel Layout Variables */
      int      _guiDividerSize = 4;
   int      _guiDividerMouseBuffer = 8;
   int      _guiTopMenuHeight = 20;

   int      _guiSidebarWidth = 250;
   Vector2  _guiSidebarScrollPos;

   Vector2  _guiContentScrollPos;
   float    _canvasZoom = 1;

   int      _guiGridHeight = 250;
   int      _guiGridWidth = 450;
   Vector2  _guiGridScrollPos;

   Vector2  _guiHelpScrollPos;

   /* Sidebar Variables */
   private List<SidebarMenuItem> _sidebarMenuItems;
   GUIStyle _guiSidebarButtonStyle;
   GUIStyle _guiSidebarFoldoutStyle;
   int _sidebarPopupIndex = 0;
   String _sidebarFilterText = "";
   String[] _sidebarPopupArray = { "All Nodes" };

   public class SidebarMenuItem : System.Windows.Forms.MenuItem
   {
      public String Name;
      public String Tooltip;
      public System.EventHandler Click;
      public List<SidebarMenuItem> Items;
      public bool Expanded;
      public bool Hidden;
      public int Indent;

      public void OnClick()
      {
         if (Click != null)
         {
            Click(this, new EventArgs());
         }
      }
   }


   //
   // Statusbar Variables
   //
   string _statusbarMessage;


   //
   // Content Panel Variables
   //
   bool _openScriptToggle = false;

   MouseEventArgs m_MouseDownArgs = null;
   MouseEventArgs m_MouseUpArgs   = null;
   MouseEventArgs m_MouseMoveArgs = new MouseEventArgs( );
   //
   // Editor Window Initialization
   //
   [UnityEditor.MenuItem ("Window/uScript %u")]
   static void Init ()
   {
      s_Instance = (uScript) EditorWindow.GetWindow(typeof(uScript));

      System.IO.Directory.CreateDirectory( uScriptConfig.Paths.RootFolder );
      System.IO.Directory.CreateDirectory( uScriptConfig.Paths.uScriptNodes );
      System.IO.Directory.CreateDirectory( uScriptConfig.Paths.ProjectFiles );
      System.IO.Directory.CreateDirectory( uScriptConfig.Paths.uScriptEditor );

      //user paths
      System.IO.Directory.CreateDirectory( uScriptConfig.Paths.UserScripts );
      System.IO.Directory.CreateDirectory( uScriptConfig.Paths.UserNodes );
      System.IO.Directory.CreateDirectory( uScriptConfig.Paths.GeneratedScripts );
      System.IO.Directory.CreateDirectory( uScriptConfig.Paths.SubsequenceScripts );

      //System.IO.Directory.CreateDirectory( uScriptConfig.Paths.TutorialFiles );
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
      m_AppData.Save(uScriptConfig.Paths.RootFolder + "/uScript.settings");
   }

   static void Status_StatusUpdate(Detox.Utility.StatusUpdateEventArgs e)
   {
      uScriptDebug.Type uScriptType = uScriptDebug.Type.Message;

      if ( e.LogType == Detox.Utility.LogType.Error )
      {
         uScriptType = uScriptDebug.Type.Error;
      }
      if ( e.LogType == Detox.Utility.LogType.Warning )
      {
         uScriptType = uScriptDebug.Type.Warning;
      }

      uScriptDebug.Log( e.Message, uScriptType );
   }

   // Unity Methods
   //
   void Awake()
   {
      // Test for Unity Pro - Unity 3.1 Indie does not support RenderTextures
      isPro = ( SystemInfo.supportsRenderTextures );

      EditorApplication.playmodeStateChanged = OnPlaymodeStateChanged;

      if (System.IO.File.Exists(uScriptConfig.Paths.RootFolder + "/uScript.settings"))
      {
         m_AppData.Load(uScriptConfig.Paths.RootFolder + "/uScript.settings");
      }

      _statusbarMessage = "Unity " + (isPro ? "Pro" : "Indie") + " (version " + Application.unityVersion + ")";
   }

   void Update()
   {
       bool contextActive = 0 != m_ContextX || 0 != m_ContextY;

      if (EditorApplication.playmodeStateChanged == null)
      {
         EditorApplication.playmodeStateChanged = OnPlaymodeStateChanged;
      }

	  //uScriptDebug.Log(Input.GetAxis("Mouse ScrollWheel"));

      if ( false == contextActive )
      {
         if ( null != m_MouseDownArgs )
         {
            //uScriptDebug.Log( "mouse down" );
            m_MouseDown = true;
            OnMouseDown( );

            m_MouseDownArgs = null;
         }
         else if ( null != m_MouseUpArgs )
         {
            //uScriptDebug.Log( "mouse up" );
            m_MouseDown = false;
            OnMouseUp( );

            m_MouseUpArgs = null;
         }
      }

      if ( true == m_WantsRefresh )
      {
         m_ScriptEditorCtrl.RefreshScript(null, true);
         m_WantsRefresh = false;
      }
      if ( true == m_WantsCopy )
      {
         m_ScriptEditorCtrl.CopyToClipboard( );
         m_WantsCopy = false;
      }
      if ( true == m_WantsPaste )
      {
         m_ScriptEditorCtrl.PasteFromClipboard( );
         m_WantsPaste = false;
      }
      if ( true == m_WantsUndo )
      {
         m_ScriptEditorCtrl.Undo( );
         m_WantsUndo = false;
      }
      if ( true == m_WantsRedo )
      {
         m_ScriptEditorCtrl.Redo( );
         m_WantsRedo = false;
      }
      OnMouseMove( );
   }


   void OnGUI()
   {
      // As little logic as possible should be performed here.  It is better
      // to use Update() to perform tasks once per tick.

      // Initialization
      //
      if (null == m_ScriptEditorCtrl)
      {
         //save all the types from unity so we can use them for quick lookup, we can't use Type.GetType because
         //we don't save the fully qualified type name which is required to return types of assemblies not loaded
         List<UnityEngine.Object> allObjects = new List<UnityEngine.Object>(GameObject.FindObjectsOfType(typeof(UnityEngine.Object)));

         foreach (UnityEngine.Object o in allObjects)
         {
            AddType(o.GetType());
         }

         ScriptEditor scriptEditor = new ScriptEditor("Untitled", PopulateEntityTypes(), PopulateLogicTypes());

         m_ScriptEditorCtrl = new ScriptEditorCtrl(scriptEditor);
         m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);

         m_ScriptEditorCtrl.BuildContextMenu();

         BuildSidebarMenu(null, null);

         Detox.Utility.Status.StatusUpdate += new Detox.Utility.Status.StatusUpdateEventHandler(Status_StatusUpdate);

         GameObject uScriptMaster = GameObject.Find(uScriptConfig.MasterObjectName);

         if (null == uScriptMaster)
         {
            uScriptDebug.Log("Adding default uScript master gameobject: " + uScriptConfig.MasterObjectName);

            uScriptMaster = new GameObject(uScriptConfig.MasterObjectName);
            uScriptMaster.transform.position = new Vector3(0f, 0f, 0f);
         }
         if (null == uScriptMaster.GetComponent<uScript_MasterObject>())
         {
            uScriptDebug.Log("Adding Master Object to master gameobject (" + uScriptConfig.MasterObjectName + ")");
            uScriptMaster.AddComponent(typeof(uScript_MasterObject));
         }
         if (null == uScriptMaster.GetComponent<uScript_Global>())
         {
            uScriptDebug.Log("Adding global to master gameobject (" + uScriptConfig.MasterObjectName + ")");
            uScriptMaster.AddComponent(typeof(uScript_Global));
         }
         if (null == uScriptMaster.GetComponent<uScript_Triggers>())
         {
            uScriptDebug.Log("Adding triggers to master gameobject (" + uScriptConfig.MasterObjectName + ")");
            uScriptMaster.AddComponent(typeof(uScript_Triggers));
         }

         String lastOpened = (String)uScript.GetSetting("uScript\\LastOpened", "");
         if (!String.IsNullOrEmpty(lastOpened))
         {
            m_FullPath = lastOpened;
         }

         //when doing certain operations like 'play' in unity
         //it seems to set any class references back to null
         //since the string isn't a reference it stays valid
         //so reopen our script
         if ("" != m_FullPath)
         {
            OpenScript(m_FullPath);
            m_RefreshTimestamp = EditorApplication.timeSinceStartup;
         }
      }

      //
      // All the GUI drawing code
      //
      DrawGUI();

      bool contextActive = 0 != m_ContextX || 0 != m_ContextY;

      if ( false == contextActive ) contextActive = ( Event.current.type == EventType.ContextClick );


      // Draw window elements, including the context menu
      //
      BeginWindows();

      if ( true == contextActive )
      {
         DrawContextMenu( m_ContextX, m_ContextY );

         if ( Event.current.type == EventType.MouseDown )
         {
            m_ContextX = 0;
            m_ContextY = 0;
            m_CurrentMenu = null;
         }
      }

      if (_openScriptToggle)
      {
          DrawAssetList();
      }
      EndWindows( );


//      uScriptDebug.Log(Event.current.type);
//      if ( Event.current.type == EventType.ScrollWheel )
//      {
//         uScriptDebug.Log( "Scroll Wheel Event" );
//      }

//      Event e = Event.current;
//      if (e.isMouse)
//      {
////         uScriptDebug.Log(EventType.scrollWheel);
////         uScriptDebug.Log(EventType.ScrollWheel);
////         uScriptDebug.Log(e.delta);
//      }





      if ( false == contextActive )
      {
         int modifierKeys = 0;

         if ( Event.current.alt )     modifierKeys |= Keys.Alt;
         if ( Event.current.control ) modifierKeys |= Keys.Control;
         if ( Event.current.shift )   modifierKeys |= Keys.Shift;
         
         Control.ModifierKeys.Pressed = modifierKeys;

         if ( Event.current.type == EventType.ValidateCommand)
         {
            if ( Event.current.commandName == "Copy" )
            {
               if ( m_ScriptEditorCtrl.CanCopy )
               {
                  Event.current.Use( );
               }
            }
            else if ( Event.current.commandName == "Paste" )
            {
               if ( m_ScriptEditorCtrl.CanPaste )
               {
                  Event.current.Use( );
               }
            }
            else if ( Event.current.commandName == "Undo" )
            {
               if ( m_ScriptEditorCtrl.CanUndo )
               {
                  Event.current.Use( );
               }
            }
            else if ( Event.current.commandName == "Redo" )
            {
               if ( m_ScriptEditorCtrl.CanRedo )
               {
                  Event.current.Use( );
               }
            }
         }

         if ( Event.current.type == EventType.ExecuteCommand)
         {
            if ( Event.current.commandName == "Copy" )
            {
               m_WantsCopy = true;
            }
            else if ( Event.current.commandName == "Paste" )
            {
               m_WantsPaste = true;
            }
            else if ( Event.current.commandName == "Undo" )
            {
               m_WantsUndo = true;
            }
            else if ( Event.current.commandName == "Redo" )
            {
               m_WantsRedo = true;
            }
         }

         if ( Event.current.type == EventType.KeyDown ||
              Event.current.type == EventType.KeyUp )
         {
            if ( Event.current.keyCode == KeyCode.Delete )
            {
               m_ScriptEditorCtrl.DeleteSelectedNodes( );
            }

            //keep key events from going to the rest of unity
            Event.current.Use( );
         }

         if ( false == m_MouseDown && Event.current.type == EventType.MouseDown )
         {
            if ((int)Event.current.mousePosition.x - _guiSidebarWidth - _guiDividerSize - _guiDividerMouseBuffer >= 0)
             {
                 m_MouseDownArgs = new System.Windows.Forms.MouseEventArgs();

                int button = 0;

                if ( Event.current.button == 0 ) button = MouseButtons.Left;
                else if ( Event.current.button == 2 ) button = MouseButtons.Right;
 
                 m_MouseDownArgs.Button = button;
                 m_MouseDownArgs.X = (int)Event.current.mousePosition.x - _guiSidebarWidth - _guiDividerSize - _guiDividerMouseBuffer;
                 m_MouseDownArgs.Y = (int)Event.current.mousePosition.y - _guiTopMenuHeight;
             }

            if ( Event.current.clickCount == 2 )
            {
               OpenLogicNode( );
            }
         }
         else if ( true == m_MouseDown && Event.current.type == EventType.MouseUp )
         {
            m_MouseUpArgs = new System.Windows.Forms.MouseEventArgs( );

            int button = 0;

            if ( Event.current.button == 0 ) button = MouseButtons.Left;
            else if ( Event.current.button == 2 ) button = MouseButtons.Right;

            m_MouseUpArgs.Button = button;
            m_MouseUpArgs.X = (int)Event.current.mousePosition.x - _guiSidebarWidth - _guiDividerSize - _guiDividerMouseBuffer;
            m_MouseUpArgs.Y = (int) Event.current.mousePosition.y - _guiTopMenuHeight;
         }

         m_MouseMoveArgs.Button = Control.MouseButtons.Buttons;
         m_MouseMoveArgs.X = (int)Event.current.mousePosition.x - _guiSidebarWidth - _guiDividerSize - _guiDividerMouseBuffer;
         m_MouseMoveArgs.Y = (int) Event.current.mousePosition.y - _guiTopMenuHeight;
      }
      else
      {
         if ( true == m_MouseDown )
         {
            m_MouseUpArgs = new System.Windows.Forms.MouseEventArgs( );

            m_MouseUpArgs.Button = MouseButtons.Left;
            m_MouseUpArgs.X = (int) Event.current.mousePosition.x;
            m_MouseUpArgs.Y = (int) Event.current.mousePosition.y - _guiTopMenuHeight;
         }
      }

      if ( Event.current.type == EventType.ContextClick )
      {
         m_ScriptEditorCtrl.BuildContextMenu( );

         BuildSidebarMenu(null, null);

		 m_ContextX = (int) Event.current.mousePosition.x;
         m_ContextY = (int) Event.current.mousePosition.y - _guiTopMenuHeight;

         //refresh screen so context menu shows up
         Repaint( );
      }

      CheckDragDrop();

      if (m_RefreshTimestamp > 0.0 && EditorApplication.timeSinceStartup - m_RefreshTimestamp >= 0.05)
      {
         // re-center now that the gui is initialized
         m_WantsRefresh = true;
         m_RefreshTimestamp = -1.0;
      }
   }

   void OnPlaymodeStateChanged()
   {
      if (EditorApplication.isPlayingOrWillChangePlaymode)
      {
         AllowNewFile();
      }
   }

   void OnDestroy()
   {
      AllowNewFile();
   }

   void OpenLogicNode( )
   {
      if ( m_ScriptEditorCtrl.SelectedNodes.Length == 1 )
      {
         EntityNode entityNode = m_ScriptEditorCtrl.SelectedNodes[0].EntityNode;

         if ( entityNode is LogicNode )
         {
            LogicNode logicNode = (LogicNode) entityNode;

            string uscriptPath = uScriptConfig.Paths.UserScripts;

            if ( logicNode.Type.StartsWith("SubSeq_") )
            {
               string script = uscriptPath + "/" + logicNode.Type.Substring( "SubSeq_".Length );
               script += ".uscript";

               if ( System.IO.File.Exists(script) )
               {
                  OpenScript( script );
               }
            }
         }
      }
   }

   void DrawGUI()
   {
      _guiSidebarFoldoutStyle = new GUIStyle(EditorStyles.foldout);
      _guiSidebarFoldoutStyle.padding = new RectOffset(12, 4, 2, 2);
      _guiSidebarFoldoutStyle.margin = new RectOffset(4, 4, 0, 0);

      _guiSidebarButtonStyle = new GUIStyle(GUI.skin.button);
      _guiSidebarButtonStyle.alignment = TextAnchor.UpperLeft;
      _guiSidebarButtonStyle.padding = new RectOffset( 4, 4, 2, 2 );
      _guiSidebarButtonStyle.margin = new RectOffset( 4, 4, 0, 0 );
      _guiSidebarButtonStyle.active.textColor = UnityEngine.Color.white;

      DrawGUITopAreas();
      DrawGUIHorizontalDivider();
      DrawGUIBottomAreas();
      DrawGUIStatusbar();
   }

   void DrawGUITopAreas()
   {
      EditorGUILayout.BeginHorizontal();
      {
         DrawGUISidebar();
         DrawGUIVerticalDivider();
         DrawGUIContent();
      }
      EditorGUILayout.EndHorizontal();
   }

   void DrawGUIBottomAreas()
   {
      EditorGUILayout.BeginHorizontal( GUILayout.Height( _guiGridHeight ) );
      {
         DrawGUIPropertyGrid();
         DrawGUIVerticalDivider();
         DrawGUIHelp();
      }
      EditorGUILayout.EndHorizontal();
   }

   void DrawGUIHorizontalDivider()
   {
      GUILayout.Box( "", GUILayout.Height( _guiDividerSize ), GUILayout.ExpandWidth(true) );
   }

   void DrawGUIVerticalDivider()
   {
      GUILayout.Box( "", GUILayout.Width( _guiDividerSize ), GUILayout.ExpandHeight(true) );
   }

   void DrawGUIStatusbar()
   {
      GUILayout.Label( (GUI.tooltip != "" ? GUI.tooltip : _statusbarMessage), GUILayout.ExpandWidth( true ) );
   }

   void DrawGUISidebar()
   {
      EditorGUILayout.BeginVertical( GUILayout.Width( _guiSidebarWidth ) );
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal( EditorStyles.toolbar, GUILayout.Width( _guiSidebarWidth ) );
         {
            _sidebarPopupIndex = EditorGUILayout.Popup(_sidebarPopupIndex, _sidebarPopupArray, "toolbarDropDown");

            Texture icon;  // temporary icon for toolbar buttons -- reuse when possible

            // Collapse hierarchy
            icon = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/collapse_hierarchy.png", typeof(UnityEngine.Texture)) as UnityEngine.Texture;
            if (icon && GUILayout.Button(icon, "toolbarButton"))
            {
               CollapseSidebarMenuItem(null);
            }

            // Expand hierarchy
            icon = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/expand_hierarchy.png", typeof(UnityEngine.Texture)) as UnityEngine.Texture;
            if (icon && GUILayout.Button(icon, "toolbarButton"))
            {
               ExpandSidebarMenuItem(null);
            }

            string _filterText = GUILayout.TextField(_sidebarFilterText, 10, "toolbarTextField", GUILayout.Width(80));
            if (_filterText != _sidebarFilterText)
            {
                // Drop focus if the user inserted a newline (hit enter)
                if (_filterText.Contains('\n'))
                {
                    GUIUtility.keyboardControl = 0;
                }

                // Only allow letters and digits
                _filterText = new string(_filterText.Where(ch => char.IsLetterOrDigit(ch)).ToArray());

                _sidebarFilterText = _filterText;
               FilterSidebarMenuItems();
            }
         }
         EditorGUILayout.EndHorizontal();

         // Node list
         //
         _guiSidebarScrollPos = EditorGUILayout.BeginScrollView ( _guiSidebarScrollPos, false, false, "horizontalScrollbar", "verticalScrollbar", "scrollview", GUILayout.Width( _guiSidebarWidth ) );
         {
            foreach (SidebarMenuItem item in _sidebarMenuItems)
            {
               DrawSidebarMenu(item);
            }
         }
         EditorGUILayout.EndScrollView();
      }
      EditorGUILayout.EndVertical();
   }


   private void ExpandSidebarMenuItem(SidebarMenuItem sidebarMenuItem)
   {
      if (sidebarMenuItem == null)
      {
         foreach (SidebarMenuItem item in _sidebarMenuItems)
         {
            ExpandSidebarMenuItem(item);
         }
      }
      else if (sidebarMenuItem.Items != null && sidebarMenuItem.Items.Count > 0)
      {
         sidebarMenuItem.Expanded = true;
         foreach (SidebarMenuItem item in sidebarMenuItem.Items)
         {
            if (item == null)
            {
               uScriptDebug.Log(sidebarMenuItem.Name + " has a null child!\n", uScriptDebug.Type.Error);
               return;
            }
            ExpandSidebarMenuItem(item);
         }
      }
   }


   private void CollapseSidebarMenuItem(SidebarMenuItem sidebarMenuItem)
   {
      if (sidebarMenuItem == null)
      {
         foreach (SidebarMenuItem item in _sidebarMenuItems)
         {
            CollapseSidebarMenuItem(item);
         }
      }
      else if (sidebarMenuItem.Items != null && sidebarMenuItem.Items.Count > 0)
      {
         sidebarMenuItem.Expanded = false;
         foreach (SidebarMenuItem item in sidebarMenuItem.Items)
         {
            if (item == null)
            {
               uScriptDebug.Log(sidebarMenuItem.Name + " has a null child!\n", uScriptDebug.Type.Error);
               return;
            }
            CollapseSidebarMenuItem(item);
         }
      }
   }


   private void FilterSidebarMenuItems()
   {
      foreach (SidebarMenuItem item in _sidebarMenuItems)
      {
         item.Hidden = FilterSidebarMenuItem(item, false);
      }
   }

   private bool FilterSidebarMenuItem(SidebarMenuItem sidebarMenuItem, bool shouldForceVisible)
   {
      // return TRUE if the parent or item should be hidden
      if (shouldForceVisible || sidebarMenuItem.Name.ToLower().Contains(_sidebarFilterText.ToLower()))
      {
         // filter matched, so this and all children should be visible
         if (sidebarMenuItem.Items != null)
         {
            foreach (SidebarMenuItem item in sidebarMenuItem.Items)
            {
                item.Hidden = FilterSidebarMenuItem(item, true);
            }
         }
         return false;
      }
      else if (sidebarMenuItem.Items != null)
      {
         // check each child to see if this should be visible
         bool shouldHideParent = true;
         foreach (SidebarMenuItem item in sidebarMenuItem.Items)
         {
            item.Hidden = FilterSidebarMenuItem(item, false);
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


   private void BuildSidebarMenu(ToolStripItem contextMenuItem, SidebarMenuItem sidebarMenuItem)
   {
      if (contextMenuItem == null || sidebarMenuItem == null)
      {
         //
         // Create a new sidebar menu, destroying the old one
         //
         _sidebarMenuItems = new List<SidebarMenuItem>();

         foreach (ToolStripItem item in m_ScriptEditorCtrl.ContextMenu.Items.Items)
         {
            if ((item is ToolStripMenuItem) && (item.Text == "Add..."))
            {
               foreach (ToolStripItem subitem in ((ToolStripMenuItem)item).DropDownItems.Items)
               {
                  SidebarMenuItem sidebarItem = new SidebarMenuItem();
                  sidebarItem.Indent = 0;

                  BuildSidebarMenu(subitem, sidebarItem);

                  _sidebarMenuItems.Add(sidebarItem);
               }
            }
         }
      }
      else if (!(contextMenuItem is ToolStripSeparator))
      {
         if ((contextMenuItem is ToolStripMenuItem) && ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items.Count > 0)
         {
            sidebarMenuItem.Name = contextMenuItem.Text.Replace("...", "");
            sidebarMenuItem.Items = new List<SidebarMenuItem>();

            foreach (ToolStripItem item in ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items)
            {
               SidebarMenuItem newItem = new SidebarMenuItem();
               newItem.Indent = sidebarMenuItem.Indent + 1;
               if (item == null || newItem == null)
               {
                  uScriptDebug.Log("Trying to pass a null parameter to BuildSidebarMenu()!\n", uScriptDebug.Type.Error);
                  return;
               }
               BuildSidebarMenu(item, newItem);
               sidebarMenuItem.Items.Add(newItem);
            }
         }
         else
         {
            sidebarMenuItem.Name = contextMenuItem.Text.Replace("&", "");
            sidebarMenuItem.Tooltip = FindNodeToolTip( FindNodeType(contextMenuItem.Tag as EntityNode) );
            sidebarMenuItem.Click = contextMenuItem.Click;
            sidebarMenuItem.Tag   = contextMenuItem.Tag;
         }
      }
      else
      {
         uScriptDebug.Log("The contextMenuItem (" + contextMenuItem.Text + ") is a " + contextMenuItem.GetType() + " and is unhandled!\n", uScriptDebug.Type.Warning);
      }
   }

   private void DrawSidebarMenu(SidebarMenuItem item)
   {
      if (item.Hidden)
      {
         return;
      }

      if (item.Items != null)
      {
         // This is should be a folding menu item that contains more buttons
         GUIStyle style = new GUIStyle(_guiSidebarFoldoutStyle);
         style.margin = new RectOffset(style.margin.left + (item.Indent * 12), 0, 0, 0);

         item.Expanded = GUILayout.Toggle(item.Expanded, item.Name, style);
         if (item.Expanded)
         {
            foreach (SidebarMenuItem subitem in item.Items)
            {
               DrawSidebarMenu(subitem);
            }
         }
      }
      else
      {
         // This is a simple menu item
         GUIStyle style = new GUIStyle(_guiSidebarButtonStyle);
         style.margin = new RectOffset(style.margin.left + 0 + (item.Indent * 12),
                                       _guiSidebarButtonStyle.margin.right,
                                       _guiSidebarButtonStyle.margin.top,
                                       _guiSidebarButtonStyle.margin.bottom);

         if (GUILayout.Button(new GUIContent(item.Name, item.Tooltip), style))
         {
            if (item.Click != null)
            {
               // Create the node on the canvas
               int halfWidth = (int)(uScript.Instance.NodeWindowRect.width / 2.0f);
               int halfHeight = (int)(uScript.Instance.NodeWindowRect.height / 2.0f);
               Point center = new Point(halfWidth, halfHeight);
               m_ScriptEditorCtrl.ContextCursor = center;
               item.OnClick();
               uScriptDebug.Log("Clicked '" + item.Name + "'\n");
            }
            else
            {
               uScriptDebug.Log("Cannot execute menu item: " + item.Name + "\n");
            }
         }
      }
   }




   void RefreshScript( )
   {
      string relativePath = "Assets\\" + m_FullPath.Substring( UnityEngine.Application.dataPath.Length + 1 );
      String fileName = System.IO.Path.GetFileNameWithoutExtension( relativePath );

      relativePath = System.IO.Path.GetDirectoryName( relativePath );
      relativePath = relativePath.Replace( '\\', '/' );

      string logicPath = relativePath + "/SubSeq_" + fileName + ".cs";
      string wrapperPath = relativePath + "/" + fileName + ".cs";

      //uScriptDebug.Log( "refreshing " + logicPath );
      //uScriptDebug.Log( "refreshing " + wrapperPath );

      AssetDatabase.ImportAsset( logicPath, ImportAssetOptions.ForceUpdate );
      AssetDatabase.ImportAsset( wrapperPath, ImportAssetOptions.ForceUpdate );
      AssetDatabase.Refresh( );
   }

   void DrawGUIContent()
   {
      Rect rect = EditorGUILayout.BeginVertical();
      
      if ( rect.width != 0 && rect.height != 0 )
      {
         m_NodeWindowRect = rect;
      }

      {
         // Toolbar

         Rect toolbarRect = EditorGUILayout.BeginHorizontal (EditorStyles.toolbar );

         if (toolbarRect.width != 0 && toolbarRect.height != 0)
         {
            m_NodeToolbarRect = toolbarRect;
         }

         {
            if ( GUILayout.Button( "Open...", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               string path = EditorUtility.OpenFilePanel( "Open uScript", uScriptConfig.Paths.UserScripts, "uscript" );
               if ( path.Length > 0 )
               {
                  OpenScript( path );
               }
            }

                _openScriptToggle = GUILayout.Toggle(_openScriptToggle, "Open Active uScripts...", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false));
            if ( GUILayout.Button( "Save", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  SaveScript( false );
               AssetDatabase.StopAssetEditing( );
            
               RefreshScript( );
            }
            if ( GUILayout.Button( "Save As...", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  SaveScript( true );
               AssetDatabase.StopAssetEditing( );

               RefreshScript( );
            }
            if ( GUILayout.Button( "Rebuild All Scripts", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  RebuildScripts( uScriptConfig.Paths.UserScripts );
               AssetDatabase.StopAssetEditing( );
               AssetDatabase.Refresh();
            }
            EditorGUILayout.Space();
            _canvasZoom = EditorGUILayout.Slider(_canvasZoom, 0.25f, 1.0f);
//            if ( GUILayout.Button( "ToolbarButton3", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
//            {
//               uScriptDebug.Log("ToolbarButton3");
//            }
         }
         EditorGUILayout.EndHorizontal();

         // Canvas
         //
         //_guiContentScrollPos = EditorGUILayout.BeginScrollView(_guiContentScrollPos, false, false, "horizontalScrollbar", "verticalScrollbar", "scrollview", GUILayout.Width(_guiSidebarWidth));

         GUI.skin.scrollView.normal.background = uScriptConfig.canvasBackgroundTexture;

         _guiContentScrollPos = EditorGUILayout.BeginScrollView(_guiContentScrollPos, false, false, "horizontalScrollbar", "verticalScrollbar", "scrollview", GUILayout.ExpandWidth(true));
         {               
            GUI.skin.scrollView.normal.background = null;

            Matrix4x4 oldMatrix = GUI.matrix;
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(Vector3.zero), new Vector3(_canvasZoom, _canvasZoom, 1));

//            GUILayout.Box("test", GUILayout.Width(4096));
            PaintEventArgs args = new PaintEventArgs();
            args.Graphics = new System.Drawing.Graphics();

            m_ScriptEditorCtrl.GuiPaint(args);

            GUI.matrix = oldMatrix;
         }
         EditorGUILayout.EndScrollView();
      }
      EditorGUILayout.EndVertical();
   }

   void DrawGUIPropertyGrid()
   {
      EditorGUILayout.BeginVertical( "window", GUILayout.Width( _guiGridWidth ) );
      {
         // Toolbar
         //
/*
         EditorGUILayout.BeginHorizontal( EditorStyles.toolbar );
         {
            if ( GUILayout.Button( "Name", EditorStyles.toolbarButton ) )
            {
               uScriptDebug.Log("Sort the grid by property name\n");
            }
            if ( GUILayout.Button( "Value", EditorStyles.toolbarButton ) )
            {
               uScriptDebug.Log("Sort the grid by value\n");
            }
         }
         EditorGUILayout.EndHorizontal();
*/

         GUILayout.Label("Properties");

         _guiGridScrollPos = EditorGUILayout.BeginScrollView ( _guiGridScrollPos, false, false, "horizontalScrollbar", "verticalScrollbar", "scrollview" );
         {
            m_ScriptEditorCtrl.PropertyGrid.OnPaint( );
         }
         EditorGUILayout.EndScrollView ();
      }
		

      EditorGUILayout.EndVertical();
   }


   void DrawGUIHelp()
   {
      EditorGUILayout.BeginVertical( "window" );
      {
         _guiHelpScrollPos = EditorGUILayout.BeginScrollView ( _guiHelpScrollPos, false, false, "horizontalScrollbar", "verticalScrollbar", "scrollview" );
         {
             string helpDescription = String.Empty;
             string helpButtonURL = String.Empty;

             if (m_ScriptEditorCtrl.SelectedNodes.Length == 1)
             {
                 helpButtonURL = FindNodeHelp( FindNodeType(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode) );
                 if (m_ScriptEditorCtrl.SelectedNodes[0] != null)
                 {
                     helpDescription = FindNodeDescription( FindNodeType(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode) );
                 }
             }
             else if (m_ScriptEditorCtrl.SelectedNodes.Length > 1)
             {
                 helpDescription = "Help cannot be provided when multiple nodes are selected.";
             }

             // Show the online reference button
             if (String.IsNullOrEmpty(helpButtonURL))
             {
                 helpButtonURL = "http://www.uscript.net/wiki/";
             }
             if (GUILayout.Button(new GUIContent("Online Reference", "Open the online reference for the selected node in the default web browser. (" + helpButtonURL + ")")))
             {
                 Help.BrowseURL(helpButtonURL);
             }
             
            
            // prevent the help TextArea from getting focus
            GUI.SetNextControlName("helpTextArea");
            GUILayout.TextArea(helpDescription, "label");
            if (GUI.GetNameOfFocusedControl() == "helpTextArea")
            {
                GUIUtility.keyboardControl = 0;
            }
         }
         EditorGUILayout.EndScrollView ();
      }
      EditorGUILayout.EndVertical();
   }

   void m_ScriptEditorCtrl_ScriptModified(object sender, EventArgs e)
   {
      Repaint( );
   }

   public void DrawContextMenu( int x, int y )
   {
      List<string> options = new List<string>( );

      foreach ( ToolStripItem item in m_ScriptEditorCtrl.ContextMenu.Items.Items )
      {
         options.Add( item.Text );
      }

      Rect windowRect = new Rect( x, y, 10, 10 );
      windowRect = GUILayout.Window(0, windowRect, DoContextMenu, "");
   }

   public void DrawAssetList( )
   {
      Rect windowRect = new Rect( _guiDividerSize + _guiSidebarWidth + 50, 50, 10, 10 );
      windowRect = GUILayout.Window(10000, windowRect, DoAssetList, "");
   }

   void DoAssetList(int windowID)
   {
      GUILayout.Label( "uScripts", EditorStyles.boldLabel );

      foreach ( UnityEngine.Object o in GameObject.FindObjectsOfType(typeof(uScriptCode)) )
      {
         uScriptCode code = o as uScriptCode;

         bool pressed = GUILayout.Button( code.GetType().ToString(), EditorStyles.label );

         if ( true == pressed )
         {
            string path = FindFile( Application.dataPath, code.GetType().ToString() + ".uscript" );
            if ( "" != path )
            {
                _openScriptToggle = false;
               OpenScript( path );
            }
         }
      }
   }

   void DoContextMenu(int windowID)
   {
      if ( null == m_CurrentMenu )
      {
         foreach ( ToolStripItem item in m_ScriptEditorCtrl.ContextMenu.Items.Items )
         {
            bool pressed = GUILayout.Button( item.Text.Replace("&", ""), EditorStyles.label );

            if ( true == pressed )
            {
               m_CurrentMenu = item;
               break;
            }
         }
      }

      if ( null != m_CurrentMenu )
      {
         DrawSubItems( m_CurrentMenu as ToolStripMenuItem );
      }
   }

   public Type GetType(string typeName)
   {
      Type type = Type.GetType(typeName);

      if ( null == type ) type = m_Types[ typeName ] as Type;

      return type;
   }

   public void AddType(Type type)
   {
      m_Types[ type.ToString( ) ] = type;
   }

   private string FindFile( string path, string fileName )
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( path );

      System.IO.FileInfo [] files = directory.GetFiles( );

      foreach ( System.IO.FileInfo file in files )
      {
         if ( file.Name == fileName )
         {
            return file.FullName;
         }
      }

      foreach ( System.IO.DirectoryInfo subDirectory in directory.GetDirectories( ) )
      {
         string result = FindFile( subDirectory.FullName, fileName );
         if ( result != "" ) return result;
      }

      return "";
   }

   private void DrawSubItems( ToolStripMenuItem menuItem )
   {
      if ( null == menuItem ) return;

      foreach ( ToolStripItem item in menuItem.DropDownItems.Items )
      {
         bool pressed = GUILayout.Button( item.Text.Replace("&", ""), EditorStyles.label );

         if ( true == pressed )
         {
            m_CurrentMenu = item;
            break;
         }
      }

      if ( null != m_CurrentMenu && null != m_CurrentMenu.Click )
      {
         ToolStripItem item = m_CurrentMenu;

         m_ContextX = 0;
         m_ContextY = 0;
         m_CurrentMenu = null;

         item.OnClick( );
      }
   }

   public void OnMouseDown( )
   {
      Control.MouseButtons.Buttons = m_MouseDownArgs.Button;

      System.Windows.Forms.Cursor.Position.X = m_MouseDownArgs.X;
      System.Windows.Forms.Cursor.Position.Y = m_MouseDownArgs.Y;

      m_ScriptEditorCtrl.OnMouseDown( m_MouseDownArgs );
   }

   public void OnMouseMove( )
   {
      if ( System.Windows.Forms.Cursor.Position.X != m_MouseMoveArgs.X ||
           System.Windows.Forms.Cursor.Position.Y != m_MouseMoveArgs.Y )
      {
         System.Windows.Forms.Cursor.Position.X = m_MouseMoveArgs.X;
         System.Windows.Forms.Cursor.Position.Y = m_MouseMoveArgs.Y;

         m_ScriptEditorCtrl.OnMouseMove( m_MouseMoveArgs );
      }
   }

   public void OnMouseUp( )
   {
      System.Windows.Forms.Cursor.Position.X = m_MouseUpArgs.X;
      System.Windows.Forms.Cursor.Position.Y = m_MouseUpArgs.Y;

      m_ScriptEditorCtrl.OnMouseUp( m_MouseUpArgs );

      Control.MouseButtons.Buttons = 0;
   }

   public void Redraw( )
   {
      if ( true == m_Repainting )  return;

      m_Repainting = true;

      Repaint( );

      m_Repainting = false;
   }

   private bool AllowNewFile( )
   {
      if (m_ScriptEditorCtrl != null && true == m_ScriptEditorCtrl.IsDirty)
      {
         int result = EditorUtility.DisplayDialogComplex( "Save File?", m_ScriptEditorCtrl.Name + " has been modified, would you like to save?", "Yes", "No", "Cancel" );

         if ( 0 == result )
         {
            bool scriptSaved;

            AssetDatabase.StartAssetEditing( );

               scriptSaved = SaveScript( false );

            AssetDatabase.StopAssetEditing( );

            return scriptSaved;
         }

         //user did not want to clean file
         else if ( 1 == result ) return true;

         //file was not cleaned
         else if ( 2 == result ) return false;
      }

      //file was not dirty
      return true;
   }

   public void OpenScript(string fullPath)
   {
      if ( false == AllowNewFile( ) ) return;

      Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor( "", PopulateEntityTypes( ), PopulateLogicTypes( ) );

      if ( true == scriptEditor.Open(fullPath) )
      {
         m_ScriptEditorCtrl = new ScriptEditorCtrl( scriptEditor );
         m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);
			
		 m_ScriptEditorCtrl.BuildContextMenu();
		 BuildSidebarMenu(null, null);

         m_FullPath = fullPath;

         uScript.SetSetting("uScript\\LastOpened", fullPath);
      }
      else
      {
         uScriptDebug.Log( "An error occured opening " + fullPath, uScriptDebug.Type.Error );
      }
   }

   public void RebuildScripts( string path )
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( path );

      System.IO.FileInfo [] files = directory.GetFiles( );

      foreach ( System.IO.FileInfo file in files )
      {
         if ( ".uscript" != file.Extension ) continue;

         Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor( "", PopulateEntityTypes( ), PopulateLogicTypes( ) );

         if ( true == scriptEditor.Open(file.FullName) )
         {
            if ( true == SaveScript(scriptEditor, file.FullName) )
            {
               uScriptDebug.Log( "Rebuilt " + file.FullName );
            }
            else
            {
               uScriptDebug.Log( "Could not save " + file.FullName, uScriptDebug.Type.Error );
            }
         }
      }

      foreach ( System.IO.DirectoryInfo subDirectory in directory.GetDirectories( ) )
      {
         RebuildScripts( subDirectory.FullName );
      }
   }

   private bool SaveScript( Detox.ScriptEditor.ScriptEditor script, string binaryPath )
   {
      System.IO.Directory.CreateDirectory( uScriptConfig.Paths.GeneratedScripts );
      System.IO.Directory.CreateDirectory( uScriptConfig.Paths.SubsequenceScripts );

      string wrapperPath = uScriptConfig.Paths.GeneratedScripts;
      string logicPath   = uScriptConfig.Paths.SubsequenceScripts;

      String fileName = System.IO.Path.GetFileNameWithoutExtension( binaryPath );

      logicPath   += "/SubSeq_" + fileName + ".cs";
      wrapperPath += "/" + fileName + ".cs";

      return script.Save( binaryPath, logicPath, wrapperPath );
   }

   public bool SaveScript(bool forceNameRequest)
   {
      Detox.ScriptEditor.ScriptEditor script = m_ScriptEditorCtrl.ScriptEditor;

      //no file of this name or force us to ask for the name
      if ( "" == m_FullPath || true == forceNameRequest )
      {
         string path = EditorUtility.SaveFilePanel( "Save uScript As", uScriptConfig.Paths.UserScripts, script.Name, "uscript" );

         //early exit, they must have changed their minds
         if ( "" == path ) return false;

         m_FullPath = path;
      }

      if ( "" != m_FullPath )
      {
         if ( true == SaveScript(script, m_FullPath) )
         {
            m_ScriptEditorCtrl.IsDirty = false;

            return true;
         }
         else
         {
            uScriptDebug.Log( "there was an error saving " + m_FullPath, uScriptDebug.Type.Error );
         }
      }

      return false;
   }

   void CreateLogicNodes( Dictionary<Type, uScriptLogic> uniqueNodes, string path )
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( path );

      System.IO.FileInfo [] files = directory.GetFiles( );

      foreach ( System.IO.FileInfo file in files )
      {
         if ( file.Name.StartsWith(".") || file.Name.StartsWith("_")  || !file.Name.EndsWith(".cs") ) continue;

         ScriptableObject scriptableObject = null;

         try
         {
            scriptableObject = ScriptableObject.CreateInstance( System.IO.Path.GetFileNameWithoutExtension(file.Name) );
         }
         catch ( Exception ) {}

         if ( null != scriptableObject )
         {
            if ( false == uniqueNodes.ContainsKey(scriptableObject.GetType()) &&
                 typeof(uScriptLogic).IsAssignableFrom(scriptableObject.GetType()) )
            {
               uniqueNodes[ scriptableObject.GetType() ] = scriptableObject as uScriptLogic;
            }
            else
            {
               ScriptableObject.DestroyImmediate( scriptableObject );
            }
         }
      }

      foreach ( System.IO.DirectoryInfo subDirectory in directory.GetDirectories( ) )
      {
         if ( subDirectory.Name.StartsWith(".") || subDirectory.Name.StartsWith("_") ) continue;

         CreateLogicNodes( uniqueNodes, subDirectory.FullName );
      }
   }

   private LogicNode[] PopulateLogicTypes( )
   {
      Hashtable baseMethods    = new Hashtable( );
      Hashtable baseEvents     = new Hashtable( );
      Hashtable baseProperties = new Hashtable( );

      Dictionary<Type, uScriptLogic> uniqueNodes = new Dictionary<Type,uScriptLogic>( );

      CreateLogicNodes( uniqueNodes, uScriptConfig.Paths.UserNodes );
      CreateLogicNodes( uniqueNodes, uScriptConfig.Paths.SubsequenceScripts );
      CreateLogicNodes( uniqueNodes, uScriptConfig.Paths.uScriptNodes );

      MethodInfo []methods = typeof(uScriptLogic).GetMethods( );

      foreach ( MethodInfo m in methods )
      {
         if ( true == m.IsPublic )
         {
            baseMethods[ m.Name ] = m.Name;
         }
      }

      EventInfo []events = typeof(uScriptLogic).GetEvents( );

      foreach ( EventInfo e in events )
      {
         baseEvents[ e.Name ] = e.Name;
      }

      PropertyInfo []properties = typeof(uScriptLogic).GetProperties( );

      foreach ( PropertyInfo p in properties )
      {
         baseProperties[ p.Name ] = p.Name;
      }

      List<LogicNode> logicNodes = new List<LogicNode>( );

      foreach ( uScriptLogic logic in uniqueNodes.Values )
      {
         Type type = logic.GetType( );
         AddType( type );

         LogicNode logicNode = new LogicNode( type.ToString( ), FindFriendlyName(type.ToString(), type.GetCustomAttributes(false)) );
         
         List<Plug> inputs = new List<Plug>( );

         Hashtable accessorMethods = new Hashtable( );

         foreach ( PropertyInfo p in type.GetProperties( ) )
         {
            if ( p.GetGetMethod( ) != null )
            {
               accessorMethods[ p.GetGetMethod( ).Name ] = true;
            }

            if ( p.GetSetMethod( ) != null )
            {
               accessorMethods[ p.GetSetMethod( ).Name ] = true;
            }
         }

         foreach ( EventInfo e in type.GetEvents( ) )
         {
            if ( e.GetAddMethod( ) != null )
            {
               accessorMethods[ e.GetAddMethod( ).Name ] = true;
            }

            if ( e.GetRaiseMethod( ) != null )
            {
               accessorMethods[ e.GetRaiseMethod( ).Name ] = true;
            }

            if ( e.GetRemoveMethod( ) != null )
            {
               accessorMethods[ e.GetRemoveMethod( ).Name ] = true;
            }
         }

         List<Plug> logicEvents = new List<Plug>( );

         foreach ( EventInfo e in type.GetEvents( ) )
         {
            Plug p;
            p.Name = e.Name;
            p.FriendlyName = FindFriendlyName( p.Name, e.GetCustomAttributes(false) ); 

            logicEvents.Add( p );
         }

         logicNode.Events = logicEvents.ToArray( );


         methods = type.GetMethods( );

         foreach ( MethodInfo m in methods )
         {
            if ( true == accessorMethods.Contains(m.Name) ) continue;
            if ( false == m.IsPublic ) continue;
            if ( true  == baseMethods.Contains(m.Name) ) continue;
            if ( true == m.IsStatic && "Create"  == m.Name ) continue;
            if ( true == m.IsStatic && "Destroy" == m.Name ) continue;

            ParameterInfo [] parameters = m.GetParameters( );

            List<Parameter> variables = new List<Parameter>( );

            foreach ( ParameterInfo p in parameters )
            {
               Parameter variable = new Parameter( );

               variable.Input  = false == p.IsOut;
               variable.Output = true  == p.IsOut;
               variable.Name   = p.Name;
               variable.Type   = p.ParameterType.ToString( ).Replace( "&", "" );
               variable.Default= (null != p.DefaultValue) ? p.DefaultValue.ToString( ) : "";
               variable.FriendlyName = FindFriendlyName( p.Name, p.GetCustomAttributes(false) );

               AddType( p.ParameterType );

               variables.Add( variable );
            }

            Plug plug;
            plug.Name = m.Name;
            plug.FriendlyName = FindFriendlyName( m.Name, m.GetCustomAttributes(false) );
            inputs.Add( plug );

            //variables just set once here because
            //they must be the same for every logic node function
            logicNode.Parameters = variables.ToArray( );

            ScriptableObject.DestroyImmediate( logic );
         }

         logicNode.Inputs = inputs.ToArray( );

         List<Plug> outputs = new List<Plug>( );

         foreach ( PropertyInfo property in type.GetProperties( ) )
         {
            if ( null != property.GetSetMethod( ) ) continue;
            if ( null == property.GetGetMethod( ) ) continue;

            Plug plug;
            plug.Name = property.Name;
            plug.FriendlyName = FindFriendlyName( plug.Name, property.GetCustomAttributes(false) );
            outputs.Add( plug );
         }

         logicNode.Outputs = outputs.ToArray( );

         logicNodes.Add( logicNode );
      }

      return logicNodes.ToArray( );
   }

   private EntityDesc[] PopulateEntityTypes( )
   {
      Hashtable baseMethods    = new Hashtable( );
      Hashtable baseEvents     = new Hashtable( );
      Hashtable baseProperties = new Hashtable( );

      List<EntityDesc> entityDescs = new List<EntityDesc>( );

      foreach ( MethodInfo m in typeof(UnityEngine.Behaviour).GetMethods( ) )
      {
         baseMethods[ m.Name ] = m.Name;
      }

      foreach ( EventInfo e in typeof(UnityEngine.Behaviour).GetEvents( ) )
      {
         baseEvents[ e.Name ] = e.Name;
      }

      foreach ( PropertyInfo p in typeof(UnityEngine.Behaviour).GetProperties( ) )
      {
         baseProperties[ p.Name ] = p.Name;
      }

      foreach ( MethodInfo m in typeof(UnityEngine.MonoBehaviour).GetMethods( ) )
      {
         baseMethods[ m.Name ] = m.Name;
      }

      foreach ( EventInfo e in typeof(UnityEngine.MonoBehaviour).GetEvents( ) )
      {
         baseEvents[ e.Name ] = e.Name;
      }

      foreach ( PropertyInfo p in typeof(UnityEngine.MonoBehaviour).GetProperties( ) )
      {
         baseProperties[ p.Name ] = p.Name;
      }

      foreach ( MethodInfo m in typeof(UnityEngine.Object).GetMethods( ) )
      {
         baseMethods[ m.Name ] = m.Name;
      }

      foreach ( EventInfo e in typeof(UnityEngine.Object).GetEvents( ) )
      {
         baseEvents[ e.Name ] = e.Name;
      }

      foreach ( PropertyInfo p in typeof(UnityEngine.Object).GetProperties( ) )
      {
         baseProperties[ p.Name ] = p.Name;
      }

      foreach ( MethodInfo m in typeof(UnityEngine.GameObject).GetMethods( ) )
      {
         baseMethods[ m.Name ] = m.Name;
      }

      foreach ( EventInfo e in typeof(UnityEngine.GameObject).GetEvents( ) )
      {
         baseEvents[ e.Name ] = e.Name;
      }

      foreach ( PropertyInfo p in typeof(UnityEngine.GameObject).GetProperties( ) )
      {
         baseProperties[ p.Name ] = p.Name;
      }

      foreach ( MethodInfo m in typeof(UnityEngine.Component).GetMethods( ) )
      {
         baseMethods[ m.Name ] = m.Name;
      }

      foreach ( EventInfo e in typeof(UnityEngine.Component).GetEvents( ) )
      {
         baseEvents[ e.Name ] = e.Name;
      }

      foreach ( PropertyInfo p in typeof(UnityEngine.Component).GetProperties( ) )
      {
         baseProperties[ p.Name ] = p.Name;
      }

      List<UnityEngine.Object> allObjects = new List<UnityEngine.Object>( FindObjectsOfType(typeof(UnityEngine.Object)) );
      Dictionary<Type, UnityEngine.Object> uniqueObjects = new Dictionary<Type, UnityEngine.Object>( );

      foreach ( UnityEngine.Object o in allObjects )
      {
         //ignore our uscripts, they are handled separately
         if ( typeof(uScriptCode).IsAssignableFrom(o.GetType()) ) continue;
         if ( typeof(uScriptLogic).IsAssignableFrom(o.GetType()) ) continue;

         uniqueObjects[ o.GetType() ] = o;
      }

      foreach ( UnityEngine.Object node in uniqueObjects.Values )
      {
         EntityDesc entityDesc = new EntityDesc( );

         Type type = node.GetType( );
         entityDesc.Type = type.ToString( );
         AddType( type );

         MethodInfo   []methodInfos   = type.GetMethods( );
         EventInfo    []eventInfos    = type.GetEvents( );
         PropertyInfo []propertyInfos = type.GetProperties( );

         List<EntityMethod> entityMethods = new List<EntityMethod>( );

         Hashtable accessorMethods = new Hashtable( );

         foreach ( PropertyInfo p in propertyInfos )
         {
            if ( p.GetGetMethod( ) != null )
            {
               accessorMethods[ p.GetGetMethod( ).Name ]  = true;
            }

            if ( p.GetSetMethod( ) != null )
            {
               accessorMethods[ p.GetSetMethod( ).Name ] = true;
            }
         }

         foreach ( MethodInfo m in methodInfos )
         {
            if ( accessorMethods.Contains(m.Name) ) continue;

            //don't expose our event methods to the user
            if ( typeof(uScriptEvent).IsAssignableFrom(node.GetType()) ) continue;

            if ( false == m.IsPublic ) continue;
            if ( true  == baseMethods.Contains(m.Name) ) continue;

            ParameterInfo [] parameters = m.GetParameters( );

            EntityMethod entityMethod = new EntityMethod( type.ToString( ), m.Name, FindFriendlyName(m.Name, m.GetCustomAttributes(false)) );
            List<Parameter> inputs = new List<Parameter>( );

            bool cancel = false;

            foreach ( ParameterInfo p in parameters )
            {
               if ( false == p.IsOut )
               {
                  Parameter input = new Parameter( );
                  input.Name    = p.Name;
                  input.FriendlyName = FindFriendlyName(p.Name, p.GetCustomAttributes(false));
                  input.Type    = p.ParameterType.ToString( ).Replace( "&", "" );
                  input.Input   = true;
                  input.Output  = false;
                  input.Default = (null != p.DefaultValue) ? p.DefaultValue.ToString( ) : "";

                  AddType( p.ParameterType );

                  inputs.Add( input );
               }
               else
               {
                  cancel = true;
               }
            }

            if ( false == cancel )
            {
               entityMethod.Parameters = inputs.ToArray( );
               entityMethods.Add( entityMethod );
            }
         }

         entityDesc.Methods = entityMethods.ToArray( );

         List<EntityEvent> entityEvents = new List<EntityEvent>( );
   
         foreach ( EventInfo e in eventInfos )
         {
            if ( true == baseEvents.Contains(e.Name) ) continue;

            List<Parameter> eventInputsOutpus = new List<Parameter>( );

            //look for any set properties which will exist on the event
            //because we can't set them via method parameters
            foreach ( PropertyInfo p in propertyInfos )
            {
               if ( baseProperties.Contains(p.Name) ) continue;

               if ( p.GetSetMethod( ) != null )
               {
                  Parameter input = new Parameter( );
                  
                  input.Name     = p.Name;
                  input.FriendlyName = FindFriendlyName(p.Name, p.GetCustomAttributes(false));
                  input.Type    = p.PropertyType.ToString( ).Replace( "&", "" );
                  input.Input   = true;
                  input.Output  = false;
                  input.Default = "";

                  AddType( p.PropertyType );
               
                  eventInputsOutpus.Add( input );
               }
            }

            EntityEvent entityEvent = new EntityEvent( type.ToString( ), FindFriendlyName(type.ToString(), type.GetCustomAttributes(false)), 
                                                        e.Name, FindFriendlyName(e.Name, e.GetCustomAttributes(false)));

            ParameterInfo [] eventParameters = e.GetAddMethod( ).GetParameters( );

            foreach ( ParameterInfo eventParameter in eventParameters )
            {
               MethodInfo [] eventHandlerMethods = eventParameter.ParameterType.GetMethods( );

               foreach ( MethodInfo eventHandlerMethod in eventHandlerMethods )
               {
                  if ( eventHandlerMethod.Name == "Invoke" )
                  {
                     ParameterInfo [] methodParameters = eventHandlerMethod.GetParameters( );

                     foreach ( ParameterInfo methodParameter in methodParameters )
                     {
                        if ( typeof(EventArgs).IsAssignableFrom(methodParameter.ParameterType) )
                        {
                           entityEvent.EventArgs = methodParameter.ParameterType.ToString( ).Replace( "+", "." );
                           
                           PropertyInfo []eventProperties = methodParameter.ParameterType.GetProperties( );
                        
                           foreach ( PropertyInfo eventProperty in eventProperties )
                           {
                              Parameter output = new Parameter( );
                              output.Name    = eventProperty.Name;
                              output.FriendlyName = FindFriendlyName(eventProperty.Name, eventProperty.GetCustomAttributes(false));
                              output.Type    = eventProperty.PropertyType.ToString( ).Replace( "&", "" );
                              output.Input   = false;
                              output.Output  = true;
                              output.Default = "";

                              AddType( eventProperty.PropertyType );

                              eventInputsOutpus.Add( output );                           
                           }
                        }
                     }
                     
                     //break after Invoke parameter, it's the only one we care about
                     break;
                  }
               }
            }

            entityEvent.Parameters = eventInputsOutpus.ToArray( );
            entityEvents.Add( entityEvent );
         }

         entityDesc.Events = entityEvents.ToArray( );

         List<EntityProperty> entityProperties = new List<EntityProperty>( );

         foreach ( PropertyInfo p in propertyInfos )
         {
            if ( true == baseProperties.Contains(p.Name) ) continue;

            EntityProperty property = new EntityProperty( p.Name, FindFriendlyName(p.Name, p.GetCustomAttributes(false)), type.ToString( ), p.PropertyType.ToString( ) );
            entityProperties.Add( property );

            AddType( p.PropertyType );
         }

         entityDesc.Properties = entityProperties.ToArray( );

         entityDescs.Add( entityDesc );
      }

      return entityDescs.ToArray( );
   }

   //go through the master uscript and see if there
   //is an attach script which works this component
   //and if so return the script type so we can attach
   //it to the parent game object
   private Type FindMatchingScript(Component component)
   {
      GameObject master = GameObject.Find( uScriptConfig.MasterObjectName );
      if ( null == master ) return null;

      Component []eventScripts = master.GetComponents<uScriptEvent>( );

      foreach ( Component eventScript in eventScripts )
      {
         Type type = FindNodeComponentType(eventScript.GetType());

         if ( type.IsAssignableFrom(component.GetType()) )
         {
            return eventScript.GetType();
         }
      }

      return null;
   }

   //loop through all the components and see if we have any
   //event scripts which match up with them.  if so
   //then attach them to the parent game object
   public void AttachEventScripts(string objectName)
   {
      GameObject gameObject = GameObject.Find( objectName );
      if ( null == gameObject ) return;

      Component [] components = gameObject.GetComponents<Component>( );

      foreach ( Component c in components )
      {
         Type type = FindMatchingScript( c );
         
         if ( null != type )
         {
            if ( null == gameObject.GetComponent(type) )
            {
               gameObject.AddComponent( type );
            }
         }
      }
   }

   //loop through all the components and see if
   //any match up with the event script we're trying to add
   //if so then attach them to the parent game object
   public bool AttachEventScript(string eventType, string objectName)
   {
      GameObject gameObject = GameObject.Find( objectName );
      uScriptDebug.Log ("uScript.cs - GameObject = " + gameObject);
      if ( null == gameObject ) return false;

      Type type = GetType(eventType);
      uScriptDebug.Log ("uScript.cs - Type = " + type);
      if ( null == type ) return false;

      Component [] components = gameObject.GetComponents<Component>( );

      foreach ( Component c in components )
      {
         Type scriptType = FindMatchingScript( c );
         
         //if we can add the script type we care about
         //then add it and return true
         if ( scriptType == type )
         {
            if ( null == gameObject.GetComponent(type) )
            {
               gameObject.AddComponent( type );
            }

            return true;
         }
      }

      return false;
   }

   public bool AttachVariableScript(string objectName)
   {
      GameObject gameObject = GameObject.Find( objectName );
      if ( null == gameObject ) return false;

      Component component = gameObject.GetComponent<uScript_Variable_Gizmo>( );

      if ( null == component )
      {
         gameObject.AddComponent<uScript_Variable_Gizmo>( );
      }

      return true;
   }

   private void CheckDragDrop( )
   {
      if ( Event.current.type == EventType.DragUpdated ||
           Event.current.type == EventType.DragPerform )
      {
         foreach ( object o in DragAndDrop.objectReferences )
         {
            if ( false == (o is UnityEngine.Object) ) continue;

            if ( true == m_ScriptEditorCtrl.CanDragDrop(o) )
            {
               DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
            }
         }

         if ( Event.current.type == EventType.DragPerform )
         {
            foreach ( object o in DragAndDrop.objectReferences )
            {
               //we are going to perform a dragdrop, so before we do
               //see if there are any event scripts which can be
               //attached to this game object
               if ( true == m_ScriptEditorCtrl.CanDragDrop(o) )
               {
                  if ( o is GameObject )
                  {
                     AttachEventScripts( (o as GameObject).name );
                  }
               }

               if ( true == m_ScriptEditorCtrl.DoDragDrop(o) )
               {
                  DragAndDrop.AcceptDrag( );
               }
               else if ( true == m_ScriptEditorCtrl.DoDragDropContextMenu(o) )
               {
                  m_ContextX = (int) Event.current.mousePosition.x;
                  m_ContextY = (int) Event.current.mousePosition.y - _guiTopMenuHeight;

                  DragAndDrop.AcceptDrag( );
               }
            }
         }

         Event.current.Use( );
      }
   }
   
   public static string FindFriendlyName(string defaultName, object [] attributes)
   {
      if ( null == attributes ) return defaultName;

      foreach ( object a in attributes )
      {
         if ( a is FriendlyName ) 
         {
            return ((FriendlyName)a).Name;
         }
      }

      return defaultName;
   }

   public static string FindNodePath(string defaultCategory, string type)
   {
      Type uscriptType = uScript.Instance.GetType(type);

      if ( uscriptType != null )
      {
         object [] attributes = uscriptType.GetCustomAttributes(false);
         if ( null == attributes ) return "";

         foreach ( object a in attributes )
         {
            if ( a is NodePath ) 
            {
               return ((NodePath)a).Value;
            }
         }
      }

      return defaultCategory;
   }

   public static string FindNodeType(EntityNode node)
   {
      if ( node is EntityEvent )
      {
         EntityEvent entityEvent = (EntityEvent) node;         
         return entityEvent.Instance.Type;
      }
      else if ( node is LogicNode )
      {
         LogicNode logicNode = (LogicNode) node;         
         return logicNode.Type;
      }

      return "";
   }

   public static string FindNodeLicense(string type)
   {
      Type uscriptType = uScript.Instance.GetType(type);

      if ( uscriptType != null )
      {
         object [] attributes = uscriptType.GetCustomAttributes(false);
         if ( null == attributes ) return "";

         foreach ( object a in attributes )
         {
            if ( a is NodeLicense ) 
            {
               return ((NodeLicense)a).Value;
            }
         }
      }

      return "";
   }

   public static string FindNodeCopyright(string type)
   {
      Type uscriptType = uScript.Instance.GetType(type);

      if ( uscriptType != null )
      {
         object [] attributes = uscriptType.GetCustomAttributes(false);
         if ( null == attributes ) return "";

         foreach ( object a in attributes )
         {
            if ( a is NodeCopyright ) 
            {
               return ((NodeCopyright)a).Value;
            }
         }
      }

      return "";
   }

   public static string FindNodeToolTip(string type)
   {
      Type uscriptType = uScript.Instance.GetType(type);

      if ( uscriptType != null )
      {
         object [] attributes = uscriptType.GetCustomAttributes(false);
         if ( null == attributes ) return "";

         foreach ( object a in attributes )
         {
            if ( a is NodeToolTip ) 
            {
               return ((NodeToolTip)a).Value;
            }
         }
      }

      return "";
   }

   public static string FindNodeDescription(string type)
   {
      Type uscriptType = uScript.Instance.GetType(type);

      if ( uscriptType != null )
      {
         object [] attributes = uscriptType.GetCustomAttributes(false);
         if ( null == attributes ) return "";

         foreach ( object a in attributes )
         {
            if ( a is NodeDescription ) 
            {
               return ((NodeDescription)a).Value;
            }
         }
      }

      return "";
   }

   public static string FindNodeAuthorName(string type)
   {
      Type uscriptType = uScript.Instance.GetType(type);

      if ( uscriptType != null )
      {
         object [] attributes = uscriptType.GetCustomAttributes(false);
         if ( null == attributes ) return "";

         foreach ( object a in attributes )
         {
            if ( a is NodeAuthor ) 
            {
               return ((NodeAuthor)a).Value;
            }
         }
      }

      return "";
   }

   public static string FindNodeAuthorURL(string type)
   {
      Type uscriptType = uScript.Instance.GetType(type);

      if ( uscriptType != null )
      {
         object [] attributes = uscriptType.GetCustomAttributes(false);
         if ( null == attributes ) return "";

         foreach ( object a in attributes )
         {
            if ( a is NodeAuthor ) 
            {
               return ((NodeAuthor)a).URL;
            }
         }
      }

      return "";
   }

   public static string FindNodeHelp(string type)
   {
      Type uscriptType = uScript.Instance.GetType(type);

      if ( uscriptType != null )
      {
         object [] attributes = uscriptType.GetCustomAttributes(false);
         if ( null == attributes ) return "";

         foreach ( object a in attributes )
         {
            if ( a is NodeHelp ) 
            {
               return ((NodeHelp)a).Value;
            }
         }
      }

      return "";
   }

   public static Type FindNodeComponentType(Type type)
   {
      if ( type != null )
      {
         object [] attributes = type.GetCustomAttributes(false);
         if ( null == attributes ) return null;

         foreach ( object a in attributes )
         {
            if ( a is NodeComponentType ) 
            {
               return ((NodeComponentType)a).ComponentType;
            }
         }
      }

      return null;
   }
}
