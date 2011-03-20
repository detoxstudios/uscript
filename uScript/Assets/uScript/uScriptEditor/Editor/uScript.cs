using UnityEngine;
using UnityEditor;
using Detox.ScriptEditor;
using System.Windows.Forms;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

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
   private bool m_KeyDown    = false;
   private bool m_Repainting = false;
   private string m_FullPath = "";

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


   //
   // Mouse and Input Variables
   //
   bool m_TriggerKeyDown   = false;
   bool m_TriggerKeyUp     = false;

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

      System.IO.Directory.CreateDirectory( uScriptConfig.Paths.TutorialFiles );
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

      _statusbarMessage = "Unity " + (isPro ? "Pro" : "Indie") + " (version " + Application.unityVersion + ")";
   }

   void Update()
   {
      bool contextActive = 0 != m_ContextX || 0 != m_ContextY;

//      Debug.Log(Input.GetAxis("Mouse ScrollWheel"));

      if ( false == contextActive )
      {
         if ( true == m_TriggerKeyDown )
         {
            //Debug.Log( "key down" );
            m_KeyDown = true;
            OnKeyDown( );

            m_TriggerKeyDown = false;
         }
         else if ( true == m_TriggerKeyUp )
         {
            //Debug.Log( "key up" );
            m_KeyDown = false;
            OnKeyUp( );

            m_TriggerKeyUp = false;
         }

         if ( null != m_MouseDownArgs )
         {
            //Debug.Log( "mouse down" );
            m_MouseDown = true;
            OnMouseDown( );

            m_MouseDownArgs = null;
         }
         else if ( null != m_MouseUpArgs )
         {
            //Debug.Log( "mouse up" );
            m_MouseDown = false;
            OnMouseUp( );

            m_MouseUpArgs = null;
         }
      }

      OnMouseMove( );
   }

   void OnGUI()
   {
      // As little logic as possible should be performed here.  It is better
      // to use Update() to perform tasks once per tick.

      // Initialization
      //
      if ( null == m_ScriptEditorCtrl )
      {
         //save all the types from unity so we can use them for quick lookup, we can't use Type.GetType because
         //we don't save the fully qualified type name which is required to return types of assemblies not loaded
         List<UnityEngine.Object> allObjects = new List<UnityEngine.Object>( GameObject.FindObjectsOfType(typeof(UnityEngine.Object)) );

         foreach ( UnityEngine.Object o in allObjects )
         {
            AddType( o.GetType() );
         }

         ScriptEditor scriptEditor = new ScriptEditor( "Untitled", PopulateEntityTypes( ), PopulateLogicTypes( ) );

         m_ScriptEditorCtrl = new ScriptEditorCtrl( scriptEditor );
         m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);

         m_ScriptEditorCtrl.BuildContextMenu( );

         BuildSidebarMenu();

         Detox.Utility.Status.StatusUpdate += new Detox.Utility.Status.StatusUpdateEventHandler(Status_StatusUpdate);

         //when doing certain operations like 'play' in unity
         //it seems to set any class references back to null
         //since the string isn't a reference it stays valid
         //so reopen our script
         if ( "" != m_FullPath )
         {
            OpenScript( m_FullPath );
         }

         GameObject uScriptMaster = GameObject.Find( "_uScript" );
         
         if ( null == uScriptMaster )
         {
            Debug.Log( "Adding default _uScript object" );

            uScriptMaster = new GameObject("_uScript");
		      uScriptMaster.transform.position = new Vector3(0f, 0f, 0f);
		      uScriptMaster.AddComponent(typeof(uScript_Global));
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
      }

      if (_openScriptToggle)
      {
          DrawAssetList();
      }
      EndWindows( );


//      Debug.Log(Event.current.type);
//      if ( Event.current.type == EventType.ScrollWheel )
//      {
//         Debug.Log( "Scroll Wheel Event" );
//      }

//      Event e = Event.current;
//      if (e.isMouse)
//      {
////         Debug.Log(EventType.scrollWheel);
////         Debug.Log(EventType.ScrollWheel);
////         Debug.Log(e.delta);
//      }





      if ( false == contextActive )
      {
         if ( false == m_KeyDown && Event.current.type == EventType.KeyDown )
         {
            m_TriggerKeyDown = true;

            //keep key events from going to the rest of unity
            Event.current.Use( );
         }
         else if ( true == m_KeyDown && Event.current.type == EventType.KeyUp )
         {
            m_TriggerKeyUp = true;

            //keep key events from going to the rest of unity
            Event.current.Use( );
         }

         if ( false == m_MouseDown && Event.current.type == EventType.MouseDown )
         {
             if ((int)Event.current.mousePosition.x - _guiSidebarWidth - _guiDividerSize - _guiDividerMouseBuffer >= 0)
             {
                 m_MouseDownArgs = new System.Windows.Forms.MouseEventArgs();

                 m_MouseDownArgs.Button = MouseButtons.Left;
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

            m_MouseUpArgs.Button = MouseButtons.Left;
            m_MouseUpArgs.X = (int)Event.current.mousePosition.x - _guiSidebarWidth - _guiDividerSize - _guiDividerMouseBuffer;
            m_MouseUpArgs.Y = (int) Event.current.mousePosition.y - _guiTopMenuHeight;
         }

         m_MouseMoveArgs.Button = MouseButtons.Left;
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
         if ( 0 == m_ContextX && 0 == m_ContextY )
         {
            m_ScriptEditorCtrl.BuildContextMenu( );

            m_ContextX = (int) Event.current.mousePosition.x;
            m_ContextY = (int) Event.current.mousePosition.y - _guiTopMenuHeight;
         }
         else
         {
            m_ContextX = 0;
            m_ContextY = 0;
            m_CurrentMenu = null;
         }

         //refresh screen so context menu shows up
         Repaint( );
      }

      CheckDragDrop( );
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
      _guiSidebarButtonStyle.active.textColor = Color.white;

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
            _sidebarFilterText = EditorGUILayout.TextField(new GUIContent(), _sidebarFilterText, "toolbarTextField");
            EditorGUILayout.Space();
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




   private void BuildSidebarMenu()
   {
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

   private void BuildSidebarMenu(ToolStripItem contextMenuItem, SidebarMenuItem sidebarMenuItem)
   {
      if (contextMenuItem == null || sidebarMenuItem == null)
      {
         Debug.LogError("BuildSidebarMenu() recieved one or more null parameters!\n");
         return;
      }

      if (!(contextMenuItem is ToolStripSeparator))
      {
         if ((contextMenuItem is ToolStripMenuItem) && ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items.Count > 0)
         {
            sidebarMenuItem.Name = contextMenuItem.Text.Replace("...", "");
            sidebarMenuItem.Items = new List<SidebarMenuItem>();

            foreach (ToolStripItem item in ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items)
            {
               SidebarMenuItem newItem = new SidebarMenuItem();
               newItem.Indent = sidebarMenuItem.Indent + 1;
               BuildSidebarMenu(item, newItem);
               sidebarMenuItem.Items.Add(newItem);
            }
         }
         else
         {
            sidebarMenuItem.Name = contextMenuItem.Text.Replace("&", "");
            sidebarMenuItem.Click = contextMenuItem.Click;
            sidebarMenuItem.Tag   = contextMenuItem.Tag;
         }
      }
      else
      {
         Debug.LogWarning("The contextMenuItem (" + contextMenuItem.Text + ") is a " + contextMenuItem.GetType() + " and is unhandled!\n");
      }
   }

   private void DrawSidebarMenu(SidebarMenuItem item)
   {
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

         if (GUILayout.Button(new GUIContent(item.Name, item.Name), style))
         {
            if (item.Click != null)
            {
               item.OnClick();
               Debug.Log("Clicked '" + item.Name + "'\n");
            }
            else
            {
               Debug.Log("Cannot execute menu item: " + item.Name + "\n");
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

      //Debug.Log( "refreshing " + logicPath );
      //Debug.Log( "refreshing " + wrapperPath );

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
//               Debug.Log("ToolbarButton3");
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
               Debug.Log("Sort the grid by property name\n");
            }
            if ( GUILayout.Button( "Value", EditorStyles.toolbarButton ) )
            {
               Debug.Log("Sort the grid by value\n");
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
            GUILayout.Label( "GUI.matrix:\n\n" + GUI.matrix );
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

      if ( null == type )
      {
         Debug.LogError( "Unity type " + typeName + " was not recognized" );
      }

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








   public void OnKeyDown( )
   {
      Control.ModifierKeys.Pressed = Keys.Control;
   }

   public void OnKeyUp( )
   {
      Control.ModifierKeys.Pressed = 0;
   }

   public void OnMouseDown( )
   {
      Control.MouseButtons.Buttons = MouseButtons.Left;

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
      Control.MouseButtons.Buttons = 0;
      //Debug.Log( "buttons = " + Control.MouseButtons.Buttons);

      System.Windows.Forms.Cursor.Position.X = m_MouseUpArgs.X;
      System.Windows.Forms.Cursor.Position.Y = m_MouseUpArgs.Y;

      m_ScriptEditorCtrl.OnMouseUp( m_MouseUpArgs );
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
      if ( true == m_ScriptEditorCtrl.IsDirty )
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

         m_FullPath = fullPath;
      }
      else
      {
         Debug.LogError( "An error occured opening " + fullPath );
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
               UnityEngine.Debug.Log( "Rebuilt " + file.FullName );
            }
            else
            {
               UnityEngine.Debug.LogError( "Could not save " + file.FullName );
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
            Debug.LogError( "there was an error saving " + m_FullPath );
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
         
         //Debug.Log( "type = " + type );

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
               accessorMethods[ p.GetGetMethod( ).Name ] = true;
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

            EntityEvent entityEvent = new EntityEvent( type.ToString( ), e.Name, FindFriendlyName(e.Name, e.GetCustomAttributes(false)) );

            entityEvent.Parameters = new Parameter[ 0 ];
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

            //below for reference if they are dragging scripts in
            //foreach ( string o in DragAndDrop.paths )
            //{
            //   if ( System.IO.Path.GetExtension(o) != ".cs" ) continue;

            //   string result = System.IO.Path.GetFileNameWithoutExtension( o );
            //   Debug.Log( "type = " + result );

            //   UnityEngine.Object []bs = FindObjectsOfType( typeof(MonoBehaviour) );

            //   Type type = null;
            //   foreach ( UnityEngine.Object b in bs )
            //   {
            //      if ( b.GetType().ToString( ) == result )
            //      {
            //         type = b.GetType( );
            //         break;
            //      }
            //   }

            //   MethodInfo []methods = type.GetMethods( );

            //   foreach ( MethodInfo m in methods )
            //   {
            //      if ( true == m.IsPublic )
            //      {
            //         Debug.Log( "method = " + m.Name );
            //      }
            //   }

            //   EventInfo []events = type.GetEvents( );

            //   foreach ( EventInfo e in events )
            //   {
            //      Debug.Log( "event = " + e.Name );
            //   }

            //   PropertyInfo []properties = type.GetProperties( );

            //   foreach ( PropertyInfo p in properties )
            //   {
            //      Debug.Log( "property = " + p.Name );
            //   }

            //   break;
            //}
         }

         Event.current.Use( );
      }
   }
   
   public static string FindFriendlyName(string defaultName, object [] attributes)
   {
      foreach ( object a in attributes )
      {
         if ( a is FriendlyName ) 
         {
            return ((FriendlyName)a).Name;
         }
      }

      return defaultName;
   }

   public static string FindCategoryName(string defaultCategory, string type)
   {
      Type uscriptType  = uScript.Instance.GetType(type);

      if ( type != null )
      {
         object [] attributes = uscriptType.GetCustomAttributes(false);

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
}
