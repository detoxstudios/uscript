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

public class uScript : EditorWindow
{
                                           //format is MAJOR.MINOR.YYMMDDa  
                                           //(where 'a' is incremented if we have more than 1 daily build we release)
   public string    uScriptBuild           { get { return "0.2.110510a"; } }
   public string    RequiredUnityBuild     { get { return  "3.3.0f4"; } }
   public string    RequiredUnityBetaBuild { get { return "3.4.0b1"; } }
   public DateTime  ExpireDate             { get { return new DateTime( 2011, 5, 23 ); } }

   private enum MouseRegion
   {
      Outside,
      Canvas,
      Palette,
      Properties,
      Reference,
      Subsequences,
      HandleCanvas,
      HandlePalette,
      HandleProperties,
      HandleReference
   }
   private MouseRegion _mouseRegion;
   private MouseRegion m_MouseDownRegion = MouseRegion.Outside;

   Dictionary<MouseRegion, Rect> _mouseRegionRect = new Dictionary<MouseRegion, Rect>();

   static private uScript s_Instance = null;
   static public uScript Instance { get { if ( null == s_Instance ) Init( ); return s_Instance; } }
   private static bool isPro;

   private ScriptEditorCtrl m_ScriptEditorCtrl = null;
   private bool m_MouseDown  = false;
   private bool m_Repainting = false;
   private bool m_WantsUndo  = false;
   private bool m_WantsRedo  = false;
   private bool m_WantsCopy  = false;
   private bool m_WantsPaste = false;
   private bool m_WantsClose = false;

   private string m_FullPath = "";
   private string m_CurrentCanvasPosition = "";

   static private AppFrameworkData m_AppData = new AppFrameworkData();
   static private bool m_SettingsLoaded = false;
   private double m_RefreshTimestamp = -1.0;

   private int m_ContextX = 0;
   private int m_ContextY = 0;
   private ToolStripItem m_CurrentMenu = null;

   Rect m_NodeWindowRect;
   public Rect NodeWindowRect { get { return m_NodeWindowRect; } }

   Rect m_NodeToolbarRect;
   public Rect NodeToolbarRect { get { return m_NodeToolbarRect; } }

   private Hashtable m_Types = new Hashtable();
 
   private const int DIVIDER_WIDTH = 4;

   /* uScript GUI Window Panel Layout Variables */

   int      _guiPanelPalette_Width = 250;
   int      _guiPanelProperties_Height = 250;
   int      _guiPanelProperties_Width = 250;
   int      _guiPanelSequence_Width = 250;

   Rect _canvasRect;
   Vector2  _guiPanelPalette_ScrollPos;

   Vector2  _guiContentScrollPos;
   float    _canvasZoom = 1;

   Vector2  _guiPanelProperties_ScrollPos;

   Vector2  _guiHelpScrollPos;

   /* Palette Variables */
   private List<PaletteMenuItem> _paletteMenuItems;
   bool _paletteFoldoutToggle = false;
   String _paletteFilterText = string.Empty;

   public class PaletteMenuItem : System.Windows.Forms.MenuItem
   {
      public String Name;
      public String Tooltip;
      public System.EventHandler Click;
      public List<PaletteMenuItem> Items;
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
   // Sub-Sequence variables
   //
   Vector2 _guiPanelSequence_ScrollPos;
    
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




   #region EULA Variables
   private bool _EULAagreed = false;
   private Vector2 _EULAscroll;
   private bool _EULAtoggle;
   private string _EULAtext = @"IMPORTANT, PLEASE READ CAREFULLY. THIS IS A LICENSE AGREEMENT

	This SOFTWARE PRODUCT is protected by copyright laws and international copyright treaties, as well as other intellectual property laws and treaties. This SOFTWARE PRODUCT is licensed, not sold.

End User License Agreement

This End User License Agreement (""EULA"") is a legal agreement between you (either an individual or a single entity) and Detox Studios LLC with regard to the copyrighted Software (herein referred to as ""SOFTWARE PRODUCT"" or ""SOFTWARE"") provided with this EULA.   The SOFTWARE PRODUCT includes computer software, the associated media, any printed materials, and any ""online"" or electronic documentation. Use of any software and related documentation (""Software"") provided to you by Detox Studios LLC in whatever form or media, will constitute your acceptance of these terms, unless separate terms are provided by the software supplier, in which case certain additional or different terms may apply. If you do not agree with the terms of this EULA, do not download, install, copy or use the Software. By installing, copying or otherwise using the SOFTWARE PRODUCT, you agree to be bound by the terms of this EULA.  If you do not agree to the terms of this EULA, Detox Studios LLC is unwilling to license the SOFTWARE PRODUCT to you. 

1.  Eligible Licensees. This Software is available for license solely to SOFTWARE owners, with no right of duplication or further distribution, licensing, or sub-licensing.  IF YOU DO NOT OWN THE SOFTWARE, THEN DO NOT DOWNLOAD, INSTALL, COPY OR USE THE SOFTWARE.
 
2.  License Grant.  Detox Studios LLC grants to you a personal, non-transferable and non-exclusive right to use the copy of the Software provided with this EULA. You agree you will not copy the Software except as necessary to use it on a single computer. You agree that you may not copy the written materials accompanying the Software. Modifying, translating, renting, copying, transferring or assigning all or part of the Software, or any rights granted hereunder, to any other persons and removing any proprietary notices, labels or marks from the Software is strictly prohibited.  Furthermore, you hereby agree not to create derivative works based on the Software.  You may not transfer this Software.

3.  Copyright.  The Software is licensed, not sold.  You acknowledge that no title to the intellectual property in the Software is transferred to you. You further acknowledge that title and full ownership rights to the Software will remain the exclusive property of Detox Studios LLC and/or its suppliers, and you will not acquire any rights to the Software, except as expressly set forth above. All copies of the Software will contain the same proprietary notices as contained in or on the Software. All title and copyrights in and to the SOFTWARE PRODUCT (including but not limited to any images, photographs, animations, video, audio, music, text and ""applets,"" incorporated into the SOFTWARE PRODUCT), the accompanying printed materials, and any copies of the SOFTWARE PRODUCT, are owned by Detox Studios LLC or its suppliers.  The SOFTWARE PRODUCT is protected by copyright laws and international treaty provisions.  You may not copy the printed materials 
accompanying the SOFTWARE PRODUCT.

4.  Reverse Engineering.  You agree that you will not attempt, and if you are a corporation, you will use your best efforts to prevent your employees and contractors from attempting to reverse compile, modify, translate or disassemble the Software in whole or in part. Any failure to comply with the above or any other terms and conditions contained herein will result in the automatic termination of this license and the reversion of the rights granted hereunder to Detox Studios LLC.

5.  Disclaimer of Warranty. The Software is provided ""AS IS"" without warranty of any kind. Detox Studios LLC and its suppliers disclaim and make no express or implied warranties and specifically disclaim the warranties of merchantability, fitness for a particular purpose and non-infringement of third-party rights. The entire risk as to the quality and performance of the Software is with you. Neither Detox Studios LLC nor its suppliers warrant that the functions contained in the Software will meet your requirements or that the operation of the Software will be uninterrupted or error-free. Detox Studios LLC IS NOT OBLIGATED TO PROVIDE ANY UPDATES TO THE SOFTWARE.

6.  Limitation of Liability. Detox Studios LLC's entire liability and your exclusive remedy under this EULA shall not exceed the price paid for the Software, if any.  In no event shall Detox Studios LLC or its suppliers be liable to you for any consequential, special, incidental or indirect damages of any kind arising out of the use or inability to use the software, even if Detox Studios LLC or its supplier has been advised of the possibility of such damages, or 
any claim by a third party. 

7.  Rental.  You may not loan, rent, or lease the SOFTWARE.  

8.  Upgrades.  If the SOFTWARE is an upgrade from an earlier release or previously released version, you now may use that upgraded product only in accordance with this EULA.  If the SOFTWARE PRODUCT is an upgrade of a software program which you licensed as a single product, the SOFTWARE PRODUCT may be used only as part of that single product package and may not be separated for use on more than one computer.

9.  OEM Product Support. Product support for the SOFTWARE PRODUCT is provided by Detox Studios LLC.  For product support, please call Detox Studios LLC.  Should you have any questions concerning this, please refer to the address provided in the documentation.

10. No Liability for Consequential Damages.  In no event shall Detox Studios LLC or its suppliers be liable for any damages whatsoever (including, without limitation, incidental, direct, indirect special and consequential damages, damages for loss of business profits, business interruption, loss of business information, or other pecuniary loss) arising out of the use or inability to use this ""Your Company"" product, even if Detox Studios LLC has been advised of the possibility of such damages.  Because some states/countries do not allow the exclusion or limitation of liability for consequential or incidental damages, the above limitation may not apply to you.

11. Indemnification By You.  If you distribute the Software in violation of this Agreement, you agree to indemnify, hold harmless and defend Detox Studios LLC and its suppliers from and against any claims or lawsuits, including attorney's fees that arise or result from the use or distribution of the Software in violation of this Agreement.

12. Confidentiality. You agree by accepting this LICENSE AGREEMENT and using the SOFTWARE PRODUCT that your knowledge and experiences with this SOFTWARE PRODUCT is to remain confidential. You agree that you will not provide any information or images regarding this product without express permision from Detox Studios LLC. Detox Studios LLC does grant you the right to share information on our designated Beta Forum with other SOFTWARE PRODUCT beta testers.

Detox Studios LLC
legal@detoxstudios.com
http://www.detoxstudios.com";
   #endregion
   
   public bool IsAttached
   {
      get
      {
         GameObject uScriptMaster = GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
         if (uScriptMaster != null && !String.IsNullOrEmpty(m_FullPath))
         {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(m_FullPath);
            bool isSafe = false;
            string safePath = UnityCSharpGenerator.MakeSyntaxSafe(fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".")), out isSafe);
            return uScriptMaster.GetComponent(safePath) != null;
         }
         return false;
      }
   }

   //
   // Editor Window Initialization
   //
   [UnityEditor.MenuItem ("Detox Tools/uScript Editor %u")]
   static void Init ()
   {
      s_Instance = (uScript) EditorWindow.GetWindow(typeof(uScript), false, "uScript Editor");
      s_Instance.wantsMouseMove = true;

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
      m_AppData.Save(uScriptConfig.Paths.RootFolder + "/uScript.settings");
   }
   
   static public void LoadSettings()
   {
      if (System.IO.File.Exists(uScriptConfig.Paths.RootFolder + "/uScript.settings"))
      {
         m_AppData.Load(uScriptConfig.Paths.RootFolder + "/uScript.settings");
      }
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
      
      _statusbarMessage = "Unity " + (isPro ? "Pro" : "Indie") + " (version " + Application.unityVersion + ")";
   }
   
   void Update()
   {
      bool contextActive = 0 != m_ContextX || 0 != m_ContextY;

      if (EditorApplication.playmodeStateChanged == null)
      {
         EditorApplication.playmodeStateChanged = OnPlaymodeStateChanged;
      }
      
      // Initialization
      //
      if (null == m_ScriptEditorCtrl)
      {
         InitializeGUIButtons();

         if (Application.unityVersion == RequiredUnityBuild || Application.unityVersion == RequiredUnityBetaBuild)
         {
         }
         else
         {
            uScriptDebug.Log("This uScript build (" + uScriptBuild + ") will not work with Unity version " + Application.unityVersion + ".", uScriptDebug.Type.Error);
            return;
         }

         if ( DateTime.Now > ExpireDate )
         {
            uScriptDebug.Log( "This uScript build (" + uScriptBuild + ") has expired.\n", uScriptDebug.Type.Error );
            return;
         }
         else
         {
            uScriptDebug.Log( "This uScript build (" + uScriptBuild + ") will expire in " + (ExpireDate - DateTime.Now).Days + " days.", uScriptDebug.Type.Message );
         }

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

         BuildPaletteMenu(null, null);

         Detox.Utility.Status.StatusUpdate += new Detox.Utility.Status.StatusUpdateEventHandler(Status_StatusUpdate);

         GameObject uScriptMaster = GameObject.Find(uScriptRuntimeConfig.MasterObjectName);

         if (null == uScriptMaster)
         {
            uScriptDebug.Log("Adding default uScript master gameobject: " + uScriptRuntimeConfig.MasterObjectName, uScriptDebug.Type.Debug);

            uScriptMaster = new GameObject(uScriptRuntimeConfig.MasterObjectName);
            uScriptMaster.transform.position = new Vector3(0f, 0f, 0f);
         }
         if (null == uScriptMaster.GetComponent<uScript_MasterObject>())
         {
            uScriptDebug.Log("Adding Master Object to master gameobject (" + uScriptRuntimeConfig.MasterObjectName + ")", uScriptDebug.Type.Debug);
            uScriptMaster.AddComponent(typeof(uScript_MasterObject));
         }
         if (null == uScriptMaster.GetComponent<uScript_Assets>())
         {
            uScriptDebug.Log("Adding Asset Object to master gameobject (" + uScriptRuntimeConfig.MasterObjectName + ")", uScriptDebug.Type.Debug);
            uScriptMaster.AddComponent(typeof(uScript_Assets));
         }

         foreach ( uScriptConfigBlock b in uScriptConfig.Variables )
         {
            AddType(b.Type);
         }

         if (String.IsNullOrEmpty(m_FullPath))
         {
            String lastOpened = (String)uScript.GetSetting("uScript\\LastOpened", "");
            if (!String.IsNullOrEmpty(lastOpened))
            {
               m_FullPath = UnityEngine.Application.dataPath + lastOpened;
            }
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

         _guiPanelProperties_Width = (int)(uScript.Instance.position.width / 3);
         _guiPanelSequence_Width = (int)(uScript.Instance.position.width / 3);
      }

      if (m_WantsClose)
      {
         Close();
         m_WantsClose = false;
         return;
      }
      m_WantsClose = false;

      if ( false == contextActive )
      {
         if ( null != m_MouseDownArgs )
         {
            //uScriptDebug.Log( "mouse down" );
            OnMouseDown( );
            m_MouseDownArgs = null;
         }
         else if ( null != m_MouseUpArgs )
         {
            //uScriptDebug.Log( "mouse up" );
            OnMouseUp( );
            m_MouseUpArgs = null;
         }
      }

      if (m_RefreshTimestamp > 0.0 && EditorApplication.timeSinceStartup - m_RefreshTimestamp >= 0.05)
      {
         // re-center now that the gui is initialized
         if (m_ScriptEditorCtrl != null)
         {
            m_ScriptEditorCtrl.RefreshScript(null, true);
            if (!String.IsNullOrEmpty(m_CurrentCanvasPosition))
            {
               Point loc = new Point(Int32.Parse(m_CurrentCanvasPosition.Substring(0, m_CurrentCanvasPosition.IndexOf(","))), Int32.Parse(m_CurrentCanvasPosition.Substring(m_CurrentCanvasPosition.IndexOf(",") + 1)));
               m_ScriptEditorCtrl.FlowChart.Location = loc;
            }
            // reset menu offset
            m_ScriptEditorCtrl.BuildContextMenu();
         }
         m_RefreshTimestamp = -1.0;
      }
      
      if ( true == m_WantsCopy )
      {
         m_ScriptEditorCtrl.CopyToClipboard( );
         m_WantsCopy = false;
      }
      if ( true == m_WantsPaste )
      {
         m_ScriptEditorCtrl.PasteFromClipboard( Point.Empty );
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
      if (m_ScriptEditorCtrl == null) return;
      
      if (!_EULAagreed)
      {
         _EULAagreed = (bool) uScript.GetSetting( "EULA\\Agreed", false );
         GUI.enabled = _EULAagreed;
      }
      
      // Set the default mouse region
      _mouseRegion = uScript.MouseRegion.Outside;
      
      // As little logic as possible should be performed here.  It is better
      // to use Update() to perform tasks once per tick.

      bool lastMouseDown = m_MouseDown;
      
      bool contextActive = 0 != m_ContextX || 0 != m_ContextY;
      if ( false == contextActive )
      {
         int modifierKeys = 0;

         if ( Event.current.alt )     modifierKeys |= Keys.Alt;
         if ( Event.current.shift )   modifierKeys |= Keys.Shift;
         if ( Event.current.control || Event.current.command ) modifierKeys |= Keys.Control;
         
         Control.ModifierKeys.Pressed = modifierKeys;

         Event e = Event.current;
         //Debug.Log(e.type);
         switch (e.type)
         {
            // command events
            case EventType.ContextClick:
               m_ScriptEditorCtrl.BuildContextMenu( );
      
               BuildPaletteMenu(null, null);
      
               m_ContextX = (int) Event.current.mousePosition.x;
               m_ContextY = (int)(Event.current.mousePosition.y - _canvasRect.yMin);
      
               //refresh screen so context menu shows up
               Repaint( );
               break;
            case EventType.ValidateCommand:
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
               break;
            case EventType.ExecuteCommand:
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
               break;
   
            // drag events
            case EventType.DragExited:
               break;
            case EventType.DragPerform:
            case EventType.DragUpdated:
               // update mouse position
               m_MouseMoveArgs.Button = Control.MouseButtons.Buttons;
               m_MouseMoveArgs.X = (int)Event.current.mousePosition.x;
               m_MouseMoveArgs.Y = (int)Event.current.mousePosition.y;
               break;
            
            // key events
            case EventType.KeyDown:
               break;
            case EventType.KeyUp:
               if ( "MainView" == GUI.GetNameOfFocusedControl( ) )
               {
                  if ( Event.current.keyCode == KeyCode.Delete )
                  {
                     m_ScriptEditorCtrl.DeleteSelectedNodes( );
                  }
                  else if ( Event.current.keyCode == KeyCode.Home || (Event.current.keyCode == KeyCode.H && (modifierKeys & Keys.Control) != 0) )
                  {
                     // re-center the graph
                     if (m_ScriptEditorCtrl != null)
                     {
                        m_ScriptEditorCtrl.RefreshScript(null, true);
                     }
                  }
               }
   
               //keep key events from going to the rest of unity
               Event.current.Use( );
               break;
      
            // mouse events
            case EventType.MouseDown:
               if ( false == m_MouseDown )
               {
                  GUI.FocusControl( "MainView" );
      
                  if ( _canvasRect.Contains( Event.current.mousePosition ) )
                  {
                     m_MouseDownArgs = new System.Windows.Forms.MouseEventArgs();
      
                     int button = 0;
      
                     if ( Event.current.button == 0 ) button = MouseButtons.Left;
                     else if ( Event.current.button == 2 ) button = MouseButtons.Right;
       
                     m_MouseDownArgs.Button = button;
                     m_MouseDownArgs.X = (int)(Event.current.mousePosition.x - _guiPanelPalette_Width);
                     m_MouseDownArgs.Y = (int)(Event.current.mousePosition.y - _canvasRect.yMin);
                  }
      
                  if ( Event.current.clickCount == 2 )
                  {
                     OpenLogicNode( );
                  }
               }
               m_MouseDown = true;
               break;
            case EventType.MouseDrag:
            case EventType.MouseMove:
               // update mouse position
               m_MouseMoveArgs.Button = Control.MouseButtons.Buttons;
               m_MouseMoveArgs.X = (int)Event.current.mousePosition.x;
               m_MouseMoveArgs.Y = (int)Event.current.mousePosition.y;
               break;
            case EventType.MouseUp:
               if ( true == m_MouseDown )
               {
                  m_MouseUpArgs = new System.Windows.Forms.MouseEventArgs( );
      
                  int button = 0;
      
                  if ( Event.current.button == 0 ) button = MouseButtons.Left;
                  else if ( Event.current.button == 2 ) button = MouseButtons.Right;
      
                  m_MouseUpArgs.Button = button;
                  m_MouseUpArgs.X = (int)(Event.current.mousePosition.x - _guiPanelPalette_Width);
                  m_MouseUpArgs.Y = (int)(Event.current.mousePosition.y - _canvasRect.yMin);

               }
               m_MouseDownRegion = MouseRegion.Outside;
               m_MouseDown = false;
               break;
            case EventType.ScrollWheel:
               break;
      
            // paint/layout events
            case EventType.Layout:
               break;
            case EventType.Repaint:
               break;
      
            // ignore these events
            case EventType.Ignore:
            case EventType.Used:
            default:
               break;
         }
      }
      else
      {
         if ( true == m_MouseDown )
         {
            m_MouseUpArgs = new System.Windows.Forms.MouseEventArgs( );

            m_MouseUpArgs.Button = MouseButtons.Left;
            m_MouseUpArgs.X = (int) Event.current.mousePosition.x;
            m_MouseUpArgs.Y = (int)(Event.current.mousePosition.y - _canvasRect.yMin);
         }
      }
      
      //
      // All the GUI drawing code
      //
      DrawMainGUI();
      DrawPopups(contextActive);
      
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
      if ( true == m_MouseDown && _mouseRegion == MouseRegion.Outside && m_MouseUpArgs == null )
      {
         m_MouseUpArgs = new System.Windows.Forms.MouseEventArgs( );

         int button = 0;

         if ( Event.current.button == 0 ) button = MouseButtons.Left;
         else if ( Event.current.button == 2 ) button = MouseButtons.Right;

         m_MouseUpArgs.Button = button;
         m_MouseUpArgs.X = (int)(Event.current.mousePosition.x - _guiPanelPalette_Width);
         m_MouseUpArgs.Y = (int)(Event.current.mousePosition.y - _canvasRect.yMin);

         m_MouseDownRegion = MouseRegion.Outside;
         m_MouseDown = false;
      }
      
      if (Event.current.type == EventType.DragPerform || Event.current.type == EventType.DragUpdated)
      {
         if ( _mouseRegion == MouseRegion.Canvas )
         {
            CheckDragDropCanvas( );
            Event.current.Use( );
         }
      }
   }
   
   public void DrawPopups(bool contextActive)
   {
      // Draw window elements, including the context menu
      //
      GUI.enabled = true;
      BeginWindows();

      if (!_EULAagreed)
      {
         _EULAagreed = (bool) uScript.GetSetting( "EULA\\Agreed", false );
         
         if (!_EULAagreed)
         {
            int w = 550;
            int h = Math.Max(300, (int)position.height - 400);
            Rect r = new Rect((position.width-w)/2, (position.height-h)/2, w, h);
            
            GUI.Window(110, r, DoWindowEULA, "End User License Agreement");
         }
      }
      
      if (_EULAagreed)
      {
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
      }
      EndWindows( );
   }

   void OnPlaymodeStateChanged()
   {
      if (EditorApplication.isPlayingOrWillChangePlaymode)
      {
         AllowNewFile(false);
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



   void DrawMainGUI()
   {
      if (uScriptStyles.panelTitle == null)
      {
         // CustomGUI styles haven't been initialized yet
         uScriptStyles.Init();
      }

      DrawGUITopAreas();
      DrawGUIHorizontalDivider();

      SetMouseRegion( MouseRegion.HandleCanvas );//, 1, -3, -1, 6 );

      DrawGUIBottomAreas();
      DrawGUIStatusbar();
   }

   void DrawGUITopAreas()
   {
      EditorGUILayout.BeginHorizontal();
      {
         DrawGUIPalette();
         DrawGUIVerticalDivider();

         SetMouseRegion( MouseRegion.HandlePalette );//, -3, 1, 6, -4 );

         DrawGUIContent();
      }
      EditorGUILayout.EndHorizontal();
   }

   void DrawGUIBottomAreas()
   {
      EditorGUILayout.BeginHorizontal( GUILayout.Height( _guiPanelProperties_Height ) );
      {
         DrawGUIPropertyGrid();
         DrawGUIVerticalDivider();

         SetMouseRegion( MouseRegion.HandleProperties );//, -3, 3, 6, -3 );

         DrawGUIHelp();
         DrawGUIVerticalDivider();

         SetMouseRegion( MouseRegion.HandleReference );//, -3, 3, 6, -3 );

         DrawGUISubsequences();
      }
      EditorGUILayout.EndHorizontal();
   }

   void DrawGUIHorizontalDivider()
   {
       GUILayout.Box("", uScriptStyles.hDivider, GUILayout.Height(DIVIDER_WIDTH), GUILayout.ExpandWidth(true));
   }

   void DrawGUIVerticalDivider()
   {
       GUILayout.Box("", uScriptStyles.vDivider, GUILayout.Width(DIVIDER_WIDTH), GUILayout.ExpandHeight(true));
   }

   void DrawGUIStatusbar()
   {
      if (GUI.tooltip != _statusbarMessage || Event.current.type == EventType.MouseMove)
      {
         _statusbarMessage = GUI.tooltip;
      }

      EditorGUILayout.BeginHorizontal();
      {
         GUILayout.Label( _statusbarMessage, GUILayout.ExpandWidth( true ) );
         GUILayout.Label( (Event.current.modifiers != 0 ? Event.current.modifiers + " :: " : "")
                           + (int)Event.current.mousePosition.x + ", "
                           + (int)Event.current.mousePosition.y + " (" + _mouseRegion + ")",
                           GUILayout.ExpandWidth( false ));
      }
      EditorGUILayout.EndHorizontal();

//      Redraw();  // This is taking to much CPU time.
   }


   void DrawGUIPalette()
   {
      Rect r = EditorGUILayout.BeginVertical( uScriptStyles.panelBox, GUILayout.Width( _guiPanelPalette_Width ) );
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
         {
            GUILayout.Label("Nodes", uScriptStyles.panelTitle, GUILayout.ExpandWidth(true));

//            // Collapse hierarchy
//            if ( GUILayout.Button( Button.Content( Button.ID.Collapse ), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
//            {
//               CollapsePaletteMenuItem(null);
//            }
//
//            // Expand hierarchy
//            if ( GUILayout.Button( Button.Content( Button.ID.Expand ), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
//            {
//               ExpandPaletteMenuItem(null);
//            }

            // Toggle hierarchy foldouts
			bool newToggleState = GUILayout.Toggle(_paletteFoldoutToggle, (_paletteFoldoutToggle ? Button.Content(Button.ID.Collapse) : Button.Content(Button.ID.Expand)), uScriptStyles.paletteToolbarButton, GUILayout.ExpandWidth(false));
			if (_paletteFoldoutToggle != newToggleState)
            {
               _paletteFoldoutToggle = newToggleState;
               if (_paletteFoldoutToggle)
               {
                  ExpandPaletteMenuItem(null);
               }
               else
               {
                  CollapsePaletteMenuItem(null);
               }
            }

            GUI.SetNextControlName ("FilterSearch" );
			string _filterText = uScriptGUI.ToolbarSearchField(_paletteFilterText, GUILayout.Width(100));
//            string _filterText = GUILayout.TextField(_paletteFilterText, 10, "toolbarTextField", GUILayout.Width(80));
            GUI.SetNextControlName ("" );
            if (_filterText != _paletteFilterText)
            {
               // Drop focus if the user inserted a newline (hit enter)
               if (_filterText.Contains('\n'))
               {
                  GUIUtility.keyboardControl = 0;
               }

               // Only allow letters and digits
//               _filterText = new string(_filterText.Where(ch => char.IsLetterOrDigit(ch)).ToArray());

               // Trim leading whitespace
               _filterText = _filterText.TrimStart( new char[] { ' ' } );

               _paletteFilterText = _filterText;
               FilterPaletteMenuItems();
            }

//            // Clear the node text filter
//            if ( GUILayout.Button( Button.Content( Button.ID.ClearFilter ), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
//            {
//               GUIUtility.keyboardControl = 0;
//               _paletteFilterText = String.Empty;
//               FilterPaletteMenuItems();
//            }
         }
         EditorGUILayout.EndHorizontal();

         // Node list
         //
         _guiPanelPalette_ScrollPos = EditorGUILayout.BeginScrollView ( _guiPanelPalette_ScrollPos, false, false, "horizontalScrollbar", "verticalScrollbar", "scrollview", GUILayout.ExpandWidth(true) );
         {
            foreach (PaletteMenuItem item in _paletteMenuItems)
            {
               DrawPaletteMenu(item);
            }
         }
         EditorGUILayout.EndScrollView();
      }
      EditorGUILayout.EndVertical();
      
      if ((int)r.width != 0 && (int)r.width != _guiPanelPalette_Width)
      {
         _guiPanelPalette_Width = (int)r.width;
      }

      SetMouseRegion( MouseRegion.Palette );//, 1, 1, -4, -4 );
   }

   void SetMouseRegion( MouseRegion region )
   {
      if (Event.current.type == EventType.Repaint)
      {
         _mouseRegionRect[region] = GUILayoutUtility.GetLastRect();
      }

      if ( _mouseRegionRect.ContainsKey(region) )
      {
         if (GUI.enabled)
         {
            switch ( region )
            {
               case MouseRegion.HandleCanvas:
                  EditorGUIUtility.AddCursorRect( _mouseRegionRect[region], MouseCursor.ResizeVertical);
                  break;
               case MouseRegion.HandlePalette:
               case MouseRegion.HandleProperties:
               case MouseRegion.HandleReference:
                  EditorGUIUtility.AddCursorRect( _mouseRegionRect[region], MouseCursor.ResizeHorizontal);
                  break;
            }
         }

         if ( _mouseRegionRect[region].Contains( Event.current.mousePosition ) )
         {
            _mouseRegion = region;
            //EditorGUIUtility.DrawColorSwatch(_mouseRegionRect[region], UnityEngine.Color.cyan);
         }
      }
   }


   private void ExpandPaletteMenuItem(PaletteMenuItem paletteMenuItem)
   {
      if (paletteMenuItem == null)
      {
         foreach (PaletteMenuItem item in _paletteMenuItems)
         {
            ExpandPaletteMenuItem(item);
         }
      }
      else if (paletteMenuItem.Items != null && paletteMenuItem.Items.Count > 0)
      {
         paletteMenuItem.Expanded = true;
         foreach (PaletteMenuItem item in paletteMenuItem.Items)
         {
            if (item == null)
            {
               uScriptDebug.Log(paletteMenuItem.Name + " has a null child!\n", uScriptDebug.Type.Error);
               return;
            }
            ExpandPaletteMenuItem(item);
         }
      }
   }


   private void CollapsePaletteMenuItem(PaletteMenuItem paletteMenuItem)
   {
      if (paletteMenuItem == null)
      {
         foreach (PaletteMenuItem item in _paletteMenuItems)
         {
            CollapsePaletteMenuItem(item);
         }
      }
      else if (paletteMenuItem.Items != null && paletteMenuItem.Items.Count > 0)
      {
         paletteMenuItem.Expanded = false;
         foreach (PaletteMenuItem item in paletteMenuItem.Items)
         {
            if (item == null)
            {
               uScriptDebug.Log(paletteMenuItem.Name + " has a null child!\n", uScriptDebug.Type.Error);
               return;
            }
            CollapsePaletteMenuItem(item);
         }
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


   private void BuildPaletteMenu(ToolStripItem contextMenuItem, PaletteMenuItem paletteMenuItem)
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

                  BuildPaletteMenu(subitem, paletteItem);

                  _paletteMenuItems.Add(paletteItem);
               }
            }
         }
      }
      else if (!(contextMenuItem is ToolStripSeparator))
      {
         if ((contextMenuItem is ToolStripMenuItem) && ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items.Count > 0)
         {
            paletteMenuItem.Name = contextMenuItem.Text.Replace("...", "");
            paletteMenuItem.Items = new List<PaletteMenuItem>();

            foreach (ToolStripItem item in ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items)
            {
               PaletteMenuItem newItem = new PaletteMenuItem();
               newItem.Indent = paletteMenuItem.Indent + 1;
               if (item == null || newItem == null)
               {
                  uScriptDebug.Log("Trying to pass a null parameter to BuildPaletteMenu()!\n", uScriptDebug.Type.Error);
                  return;
               }
               BuildPaletteMenu(item, newItem);
               paletteMenuItem.Items.Add(newItem);
            }
         }
         else
         {
            paletteMenuItem.Name = contextMenuItem.Text.Replace("&", "");
            paletteMenuItem.Tooltip = FindNodeToolTip( FindNodeType(contextMenuItem.Tag as EntityNode) );
            paletteMenuItem.Click = contextMenuItem.Click;
            paletteMenuItem.Tag   = contextMenuItem.Tag;
         }
      }
      else
      {
         uScriptDebug.Log("The contextMenuItem (" + contextMenuItem.Text + ") is a " + contextMenuItem.GetType() + " and is unhandled!\n", uScriptDebug.Type.Warning);
      }
   }

   private void DrawPaletteMenu(PaletteMenuItem item)
   {
      if (item.Hidden)
      {
         return;
      }

      if (item.Items != null)
      {
         // This is should be a folding menu item that contains more buttons
         GUIStyle tmpStyle = new GUIStyle(uScriptStyles.paletteFoldout);
         tmpStyle.margin = new RectOffset(tmpStyle.margin.left + (item.Indent * 12), 0, 0, 0);

         item.Expanded = GUILayout.Toggle(item.Expanded, item.Name, tmpStyle);
         if (item.Expanded)
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
         GUIStyle tmpStyle = new GUIStyle(uScriptStyles.paletteButton);
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
      {
         if ( rect.width != 0 && rect.height != 0 )
         {
            m_NodeWindowRect = rect;
         }

         // Toolbar

         Rect toolbarRect = EditorGUILayout.BeginHorizontal (EditorStyles.toolbar );

         if (toolbarRect.width != 0 && toolbarRect.height != 0)
         {
            m_NodeToolbarRect = toolbarRect;
         }

         {
            if ( GUILayout.Button( Button.Content( Button.ID.New ), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               if (AllowNewFile(true))
               {
                  NewScript();
               }
            }

            if ( GUILayout.Button( Button.Content( Button.ID.Open ), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               string path = EditorUtility.OpenFilePanel( "Open uScript", uScriptConfig.Paths.UserScripts, "uscript" );
               if ( path.Length > 0 )
               {
                  OpenScript( path );
               }
            }

//            _openScriptToggle = GUILayout.Toggle(_openScriptToggle, "Open Active uScripts...", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false));

            if ( GUILayout.Button( Button.Content( Button.ID.Save ), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  SaveScript( false );
               AssetDatabase.StopAssetEditing( );
            
               RefreshScript( );
            }
            if ( GUILayout.Button( Button.Content( Button.ID.SaveAs ), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  SaveScript( true );
               AssetDatabase.StopAssetEditing( );

               RefreshScript( );
            }
            if ( GUILayout.Button( Button.Content( Button.ID.RebuildAll ), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  RebuildScripts( uScriptConfig.Paths.UserScripts );
               AssetDatabase.StopAssetEditing( );
               AssetDatabase.Refresh();
            }
            if ( GUILayout.Button( Button.Content( Button.ID.RemoveGenerated ), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  RemoveGeneratedCode( uScriptConfig.Paths.GeneratedScripts );
               AssetDatabase.StopAssetEditing( );
               AssetDatabase.Refresh();
            }
            GUILayout.FlexibleSpace();

//            Button.StyleID newStyle = (Button.StyleID)EditorGUILayout.EnumPopup(Button.Style);
//            if (newStyle != Button.Style)
//            {
//               Button.Style = newStyle;
//            }

//            EditorGUILayout.Space();
//            _canvasZoom = EditorGUILayout.Slider(_canvasZoom, 0.25f, 1.0f);
//            if ( GUILayout.Button( "ToolbarButton3", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
//            {
//               uScriptDebug.Log("ToolbarButton3");
//            }
         }
         EditorGUILayout.EndHorizontal();

         // Canvas
         //
         //_guiContentScrollPos = EditorGUILayout.BeginScrollView(_guiContentScrollPos, false, false, "horizontalScrollbar", "verticalScrollbar", "scrollview", GUILayout.Width(_guiPaletteWidth));

         GUI.skin.scrollView.normal.background = uScriptConfig.canvasBackgroundTexture;

         GUI.SetNextControlName ("MainView" );
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
         GUI.SetNextControlName ("");

         if (Event.current.type == EventType.Repaint)
         {
            _canvasRect = GUILayoutUtility.GetLastRect();
         }
      }
      EditorGUILayout.EndVertical();

      SetMouseRegion( MouseRegion.Canvas );//, 3, 1, -2, -4 );
   }




	// TEMP Variables for testing the new property grid methods
   Rect _svRect;

   KeyCode[] _arrayKeyCode;
   bool _arrayFoldoutBool;

   bool _newPropertyGrid = false;
   Vector2 _scrollNewProperties;
   // END TEMP Variables




   void DrawGUIPropertyGrid()
   {
      EditorGUILayout.BeginVertical( uScriptStyles.panelBox, GUILayout.Width( _guiPanelProperties_Width ) );
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal( EditorStyles.toolbar );
         {
            GUILayout.Label("Properties", uScriptStyles.panelTitle);
            GUILayout.FlexibleSpace();
            _newPropertyGrid = GUILayout.Toggle(_newPropertyGrid, "Toggle New Panel", EditorStyles.toolbarButton);
         }
         EditorGUILayout.EndHorizontal();

         _guiPanelProperties_ScrollPos = EditorGUILayout.BeginScrollView(_guiPanelProperties_ScrollPos, false, false, "horizontalScrollbar", "verticalScrollbar", "scrollview");
         {
            m_ScriptEditorCtrl.PropertyGrid.OnPaint();
         }
         EditorGUILayout.EndScrollView();
      }
      EditorGUILayout.EndVertical();

      SetMouseRegion( MouseRegion.Properties );//, 1, 3, -4, -3 );
   }


   void DrawGUIHelp()
   {
      EditorGUILayout.BeginVertical(uScriptStyles.panelBox);
      {
         string helpDescription = String.Empty;
         string helpButtonURL = String.Empty;

         if (m_ScriptEditorCtrl.SelectedNodes.Length == 1)
         {
            helpButtonURL = FindNodeHelp(FindNodeType(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode));
            if (m_ScriptEditorCtrl.SelectedNodes[0] != null)
            {
               helpDescription = FindNodeDescription(FindNodeType(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode));
            }
         }
         else if (m_ScriptEditorCtrl.SelectedNodes.Length > 1)
         {
            helpDescription = "Help cannot be provided when multiple nodes are selected.";
         }
         else
         {
            helpDescription = "Select a node on the canvas to view usage and behavior information.";
         }

         // Show the online reference button
         if (String.IsNullOrEmpty(helpButtonURL))
         {
            helpButtonURL = "http://www.uscript.net/wiki/";
         }

         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label("Reference", uScriptStyles.panelTitle, GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();

            Button.ChangeTooltip( Button.ID.OnlineReference, "Open the online reference for the selected node in the default web browser. (" + helpButtonURL + ")" );
            if ( GUILayout.Button( Button.Content( Button.ID.OnlineReference ), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               Help.BrowseURL(helpButtonURL);
            }
         }
         EditorGUILayout.EndHorizontal();

         // New Properties panel
         //
         if (_newPropertyGrid)
         {
            GUIStyle vsb = new GUIStyle(GUI.skin.verticalScrollbar);
            vsb.margin = new RectOffset();

            GUIStyle hsb = new GUIStyle(GUI.skin.horizontalScrollbar);
            hsb.margin = new RectOffset();

            _scrollNewProperties = EditorGUILayout.BeginScrollView(_scrollNewProperties, hsb, vsb);
            {
               uScriptGUI.BeginColumns("Property", "Value", "Type", _scrollNewProperties, _svRect);
               {
                     m_ScriptEditorCtrl.PropertyGrid.OnPaintNew();
               }
               uScriptGUI.EndColumns();
            }
            EditorGUILayout.EndScrollView();

            if (Event.current.type == EventType.Repaint)
            {
               _svRect = GUILayoutUtility.GetLastRect();
            }
         }
         else
         {
            _guiHelpScrollPos = EditorGUILayout.BeginScrollView(_guiHelpScrollPos, false, false, "horizontalScrollbar", "verticalScrollbar", "scrollview");
            {
               // prevent the help TextArea from getting focus
               GUI.SetNextControlName("helpTextArea");
               GUILayout.TextArea(helpDescription, uScriptStyles.referenceText);
               if (GUI.GetNameOfFocusedControl() == "helpTextArea")
               {
                  GUIUtility.keyboardControl = 0;
               }
            }
            EditorGUILayout.EndScrollView ();
         }
      }
      EditorGUILayout.EndVertical();

      SetMouseRegion( MouseRegion.Reference );//, 3, 3, -6, -3 );
   }


   void DrawGUISubsequences()
   {
      EditorGUILayout.BeginVertical(uScriptStyles.panelBox, GUILayout.Width(_guiPanelSequence_Width));
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label("uScripts", uScriptStyles.panelTitle, GUILayout.ExpandWidth(true));
         }
         EditorGUILayout.EndHorizontal();

         _guiPanelSequence_ScrollPos = EditorGUILayout.BeginScrollView(_guiPanelSequence_ScrollPos, false, false, "horizontalScrollbar", "verticalScrollbar", "scrollview");
         {
            foreach (UnityEngine.Object o in GameObject.FindObjectsOfType(typeof(uScriptCode)))
            {
               uScriptCode code = o as uScriptCode;

               if (code.GetType().ToString() == System.IO.Path.GetFileNameWithoutExtension(m_ScriptEditorCtrl.Name))
               {
                  GUIStyle style = new GUIStyle(uScriptStyles.paletteButton);
                  style.normal.background = style.active.background;
                  GUILayout.Label(code.GetType().ToString(), style);
               }
               else
               {
                  GUIContent content = new GUIContent(code.GetType().ToString(), "Double-click to open this uScript. Drag this button onto the canvas to add an instance of this uScript.");
                  if (GUILayout.Button(content, uScriptStyles.paletteButton) && Event.current.clickCount == 2)
                  {
                     string path = FindFile(Application.dataPath, code.GetType().ToString() + ".uscript");
                     if ("" != path)
                     {
                        _openScriptToggle = false;
                        OpenScript(path);
                     }
                  }
               }
            }
         }
         EditorGUILayout.EndScrollView();
      }
      EditorGUILayout.EndVertical();

      SetMouseRegion(MouseRegion.Subsequences );//, 3, 3, -2, -3);
   }


   void DoWindowEULA(int windowID)
   {
      GUIStyle EULAstyle = new GUIStyle("box");
      EULAstyle.padding = new RectOffset(1, 1, 1, 1);

      GUILayout.BeginHorizontal(EULAstyle);
      {
         _EULAscroll = GUILayout.BeginScrollView(_EULAscroll);
         {
            // prevent the help TextArea from getting focus
            GUI.SetNextControlName("EULA");
            GUILayout.TextArea(_EULAtext, uScriptStyles.referenceText);
            if (GUI.GetNameOfFocusedControl() == "EULA")
            {
               GUIUtility.keyboardControl = 0;
            }
         }
         GUILayout.EndScrollView();
      }
      GUILayout.EndHorizontal();

      GUILayout.BeginHorizontal();
      {
         GUILayout.Space(10);

         _EULAtoggle = GUILayout.Toggle(_EULAtoggle, "  I agree to the terms of this license agreement.");

         GUI.enabled = false;
         if (_EULAtoggle)
         {
            GUI.enabled = true;
         }

         GUILayout.FlexibleSpace();
         if (GUILayout.Button("Accept", GUILayout.Width(100)))
         {
            uScript.SetSetting( "EULA\\Agreed", true );
            _EULAagreed = true;
         }
         
         GUI.enabled = true;

         GUILayout.FlexibleSpace();
         if (GUILayout.Button("Close uScript", GUILayout.Width(100)))
         {
            m_WantsClose = true;
         }

         GUILayout.Space(10);
      }
      GUILayout.EndHorizontal();
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
      Rect windowRect = new Rect( _canvasRect.xMin + 50, 50, 10, 10 );
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
            if ( item.Text == "<hr>" )
            {
               GUILayout.HorizontalSlider( 0, 0, 0 );
            }
            else
            {
               bool pressed = GUILayout.Button( item.Text.Replace("&", ""), EditorStyles.label );

               if ( true == pressed )
               {
                  m_CurrentMenu = item;
                  break;
               }
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
      Type type = m_Types[ typeName ] as Type;

      if ( null == type ) type = GetAssemblyQualifiedType( typeName );

      return type;
   }

   public Type GetAssemblyQualifiedType(String typeName)
   {
      if ( null == typeName ) return null;

      // try the basic version first
      if ( Type.GetType(typeName) != null ) return Type.GetType(typeName);
      
      // not found, look through all the assemblies
      foreach ( Assembly assembly in AppDomain.CurrentDomain.GetAssemblies() )
      {
         if ( Type.GetType(typeName + ", " + assembly.ToString()) != null ) return Type.GetType(typeName + ", " + assembly.ToString());
      }
      
      return null;
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
 
   static int lastMouseX = 0;
   static int lastMouseY = 0;
   
   public void OnMouseMove( )
   {
      // calculate delta for handle dragging
      int deltaX = m_MouseMoveArgs.X - lastMouseX;
      int deltaY = m_MouseMoveArgs.Y - lastMouseY;
      lastMouseX = m_MouseMoveArgs.X;
      lastMouseY = m_MouseMoveArgs.Y;

      // convert to main canvas space
      m_MouseMoveArgs.X -= _guiPanelPalette_Width;
      m_MouseMoveArgs.Y -= (int)_canvasRect.yMin;
      
      System.Windows.Forms.Cursor.Position.X = m_MouseMoveArgs.X;
      System.Windows.Forms.Cursor.Position.Y = m_MouseMoveArgs.Y;

      if (_mouseRegion == MouseRegion.Canvas)
      {
         m_ScriptEditorCtrl.OnMouseMove( m_MouseMoveArgs );
      }

      // convert back to screen
      m_MouseMoveArgs.X += _guiPanelPalette_Width;
      m_MouseMoveArgs.Y += (int)_canvasRect.yMin;
      
      if (GUI.enabled)
      {
         // check for divider draggging
         foreach ( KeyValuePair<MouseRegion, Rect>kvp in _mouseRegionRect)
         {
            MouseRegion region = kvp.Key;
            switch ( region )
            {
               case MouseRegion.HandleCanvas:
                  if (m_MouseDown && region == m_MouseDownRegion)
                  {
                     _guiPanelProperties_Height -= deltaY;
                     Repaint();
                  }
                  break;
               case MouseRegion.HandlePalette:
                  if (m_MouseDown && region == m_MouseDownRegion)
                  {
                     _guiPanelPalette_Width += deltaX;
                     Repaint();
                  }
                  break;
               case MouseRegion.HandleProperties:
                  if (m_MouseDown && region == m_MouseDownRegion)
                  {
                     _guiPanelProperties_Width += deltaX;
                     Repaint();
                  }
                  break;
               case MouseRegion.HandleReference:
                  if (m_MouseDown && region == m_MouseDownRegion)
                  {
                     _guiPanelSequence_Width -= deltaX;
                     Repaint();
                  }
                  break;
            }
         }
      }
   }

   public void OnMouseUp( )
   {
      System.Windows.Forms.Cursor.Position.X = m_MouseUpArgs.X;
      System.Windows.Forms.Cursor.Position.Y = m_MouseUpArgs.Y;
      
      m_ScriptEditorCtrl.OnMouseUp( m_MouseUpArgs );
      
      m_CurrentCanvasPosition = m_ScriptEditorCtrl.FlowChart.Location.X.ToString() + "," + m_ScriptEditorCtrl.FlowChart.Location.Y.ToString();
      
      Control.MouseButtons.Buttons = 0;
   }
 
   public void Redraw( )
   {
      if ( true == m_Repainting )  return;

      m_Repainting = true;

      Repaint( );

      m_Repainting = false;
   }

   private bool AllowNewFile(bool allowCancel)
   {
      if (m_ScriptEditorCtrl != null && true == m_ScriptEditorCtrl.IsDirty)
      {
         int result;
         
         if ( true == allowCancel )
         {
            result = EditorUtility.DisplayDialogComplex( "Save File?", m_ScriptEditorCtrl.Name + " has been modified, would you like to save?", "Yes", "No", "Cancel" );
         }
         else
         {
            bool yes = EditorUtility.DisplayDialog( "Save File?", m_ScriptEditorCtrl.Name + " has been modified, would you like to save?", "Yes", "No" );
            
            if ( true == yes ) result = 0;
            else result = 1;
         }

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
   
   public void NewScript()
   {
      Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor( "", PopulateEntityTypes( ), PopulateLogicTypes( ) );

      m_ScriptEditorCtrl = new ScriptEditorCtrl( scriptEditor );
      m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);
      
      m_ScriptEditorCtrl.BuildContextMenu();
      BuildPaletteMenu(null, null);
      
      m_FullPath = "";
      
      uScript.SetSetting("uScript\\LastOpened", "");
   }

   public void OpenScript(string fullPath)
   {
      if ( false == AllowNewFile(true) ) return;

      Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor( "", PopulateEntityTypes( ), PopulateLogicTypes( ) );

      if ( true == scriptEditor.Open(fullPath) )
      {
		 Point loc = Point.Empty;
		 if (fullPath != m_FullPath) m_CurrentCanvasPosition = "";	// reset canvas position
		 if (!String.IsNullOrEmpty(m_CurrentCanvasPosition)) loc = new Point(Int32.Parse(m_CurrentCanvasPosition.Substring(0, m_CurrentCanvasPosition.IndexOf(","))), Int32.Parse(m_CurrentCanvasPosition.Substring(m_CurrentCanvasPosition.IndexOf(",") + 1)));
         m_ScriptEditorCtrl = new ScriptEditorCtrl( scriptEditor, loc );
         m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);
			
		 m_ScriptEditorCtrl.BuildContextMenu();
		 BuildPaletteMenu(null, null);

         m_FullPath = fullPath;

         uScript.SetSetting("uScript\\LastOpened", uScriptConfig.Paths.RelativePath(fullPath).Substring("Assets".Length));
      }
      else
      {
         uScriptDebug.Log( "An error occured opening " + fullPath, uScriptDebug.Type.Error );
      }
   }

   public void RemoveGeneratedCode( string path )
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( path );

      System.IO.FileInfo [] files = directory.GetFiles( );

      foreach ( System.IO.FileInfo file in files )
      {
         string relativePath = uScriptConfig.Paths.RelativePath(file.FullName);
         AssetDatabase.DeleteAsset( relativePath );
      }

      foreach ( System.IO.DirectoryInfo subDirectory in directory.GetDirectories( ) )
      {
         RemoveGeneratedCode( subDirectory.FullName );
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
		 bool isSafe = false;
         string path = "Untitled.uScript";
	     while ( !isSafe && path != "" )
		 {
	         path = EditorUtility.SaveFilePanel( "Save uScript As", uScriptConfig.Paths.UserScripts, script.Name, "uscript" );
			 if ( path != "" )
			 {
			    System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
			    string safePath = UnityCSharpGenerator.MakeSyntaxSafe(fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".")), out isSafe);
			    if ( !isSafe )
			    {
			       // filename is not safe - tell the user they need to change it
				   if (!EditorUtility.DisplayDialog("Invalid File Name", "Filename must be all alpha-numeric characters and must not start with a number. A suggested name for the one you entered is: " + safePath, "Try Again", "Cancel")) return false;
			    }
			 }
		 }

         //early exit, they must have changed their minds
         if ( "" == path ) return false;

         m_FullPath = path;
      }

      if ( "" != m_FullPath )
      {
         bool firstSave = false;
         if (!System.IO.File.Exists(m_FullPath))
         {
            firstSave = true;
         }

         if ( true == SaveScript(script, m_FullPath) )
         {
            m_ScriptEditorCtrl.IsDirty = false;
    
            if (firstSave)
            {
               // ask the user if they want to assign this script to the master game object
               if (EditorUtility.DisplayDialog("Assign To Master Game Object", "This uScript has not been assigned to the master game object yet. Would you like to assign it now?", "Yes", "No"))
               {
                  AssetDatabase.Refresh( );
                  AttachToMasterGO();
               }
            }
   
            return true;
         }
         else
         {
            uScriptDebug.Log( "there was an error saving " + m_FullPath, uScriptDebug.Type.Error );
         }
      }

      return false;
   }
   
   void AttachToMasterGO()
   {
      GameObject uScriptMaster = GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
      if (uScriptMaster != null)
      {
         uScript_MasterObject component = (uScript_MasterObject)uScriptMaster.GetComponent(typeof(uScript_MasterObject));
         if (component != null)
         {
#if UNITY_EDITOR
            component.AttachScriptToMaster(m_FullPath);
#endif
         }
      }
   }

   void GatherDerivedTypes( Dictionary<Type, Type> uniqueNodes, string path, Type baseType )
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( path );

      System.IO.FileInfo [] files = directory.GetFiles( );

      foreach ( System.IO.FileInfo file in files )
      {
         if ( file.Name.StartsWith(".") || file.Name.StartsWith("_")  || !file.Name.EndsWith(".cs") ) continue;

         Type type = uScript.Instance.GetAssemblyQualifiedType( System.IO.Path.GetFileNameWithoutExtension(file.Name) );

         if ( null != type )
         {
            if ( false == uniqueNodes.ContainsKey(type) &&
                 baseType.IsAssignableFrom(type) )
            {
               uniqueNodes[ type ] = type;
            }
         }
      }

      foreach ( System.IO.DirectoryInfo subDirectory in directory.GetDirectories( ) )
      {
         if ( subDirectory.Name.StartsWith(".") || subDirectory.Name.StartsWith("_") ) continue;

         GatherDerivedTypes( uniqueNodes, subDirectory.FullName, baseType );
      }
   }

   private LogicNode[] PopulateLogicTypes( )
   {
      Hashtable baseMethods    = new Hashtable( );
      Hashtable baseEvents     = new Hashtable( );
      Hashtable baseProperties = new Hashtable( );

      Dictionary<Type, Type> uniqueNodes = new Dictionary<Type, Type>( );

      GatherDerivedTypes( uniqueNodes, uScriptConfig.Paths.UserNodes, typeof(uScriptLogic) );
      GatherDerivedTypes( uniqueNodes, uScriptConfig.Paths.SubsequenceScripts, typeof(uScriptLogic) );
      GatherDerivedTypes( uniqueNodes, uScriptConfig.Paths.uScriptNodes, typeof(uScriptLogic) );

      MethodInfo []methods = typeof(uScriptLogic).GetMethods( );

      foreach ( MethodInfo m in methods )
      {
         if ( true == m.IsPublic )
         {
            baseMethods[ m.Name ] = m.Name;
         }
      }

      methods = typeof(ScriptableObject).GetMethods( );

      foreach ( MethodInfo m in methods )
      {
         if ( true == m.IsPublic )
         {
            baseMethods[ m.Name ] = m.Name;
         }
      }

      //i think these are legacy uScript support and can go away
      //but i want to wait until we're inbetween builds to risk it
      baseMethods[ "OnDestroy" ] = "OnDestroy";
      baseMethods[ "OnDisable" ] = "OnDisable";
      baseMethods[ "OnEnable" ]  = "OnEnable";
      
      //this function is added to nested uscripts by the code generator
      //and we don't want to expose it to the user
      baseMethods[ "Awake" ] = "Awake";

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

      foreach ( Type type in uniqueNodes.Values )
      {
         AddType( type );

         LogicNode logicNode = new LogicNode( type.ToString( ), FindFriendlyName(type.ToString(), type.GetCustomAttributes(false)) );
         
         List<Plug>  inputs   = new List<Plug>( );
         List<string> drivens = new List<string>( );

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
            if ( true  == accessorMethods.Contains(m.Name) ) continue;
            if ( true  == baseMethods.Contains(m.Name) ) continue;

            if ( false == m.IsPublic ) continue;
            if ( true  == m.IsStatic ) continue;
            
            bool driven = FindDrivenAttribute( m.GetCustomAttributes(false) );

            //driven functions are called automatically by the code generation
            //and need no other information parsed 
            //(they use the same parameters as the rest of the functions in the node)
            if ( true == driven ) 
            {
               if ( m.ReturnParameter.ParameterType == typeof(bool) )
               {
                  drivens.Add( m.Name );
               }

               continue;
            }

            ParameterInfo [] parameters = m.GetParameters( );

            List<Parameter> variables = new List<Parameter>( );

            foreach ( ParameterInfo p in parameters )
            {
               Parameter variable = new Parameter( );

               if ( true == p.IsOut )
               {
                  variable.Input  = false;
                  variable.Output = true;
               }
               else if ( p.ParameterType.IsByRef )
               {
                  variable.Input  = true;
                  variable.Output = true;
               }
               else
               {
                  variable.Input  = true;
                  variable.Output = false;
               }

               variable.Name   = p.Name;
               variable.Type   = p.ParameterType.ToString( ).Replace( "&", "" );
               variable.FriendlyName = FindFriendlyName( p.Name, p.GetCustomAttributes(false) );
               variable.DefaultAsObject = FindDefaultValue( "", p.GetCustomAttributes(false) );
               
               AddType( p.ParameterType );

               variables.Add( variable );
            }

            if ( m.ReturnType != typeof(void) )
            {
               Parameter parameter = new Parameter( );
               parameter.Name    = "Return";
               parameter.Type    = m.ReturnType.ToString( ).Replace( "&", "" );
               parameter.Input   = false;
               parameter.Output  = true;         
               parameter.Default = "";
               parameter.FriendlyName = "Return Value";

               AddType( m.ReturnType );
                  
               variables.Add( parameter );
            }

            Plug plug;
            plug.Name = m.Name;
            plug.FriendlyName = FindFriendlyName( m.Name, m.GetCustomAttributes(false) );
            inputs.Add( plug );

            //variables just set once here because
            //they must be the same for every logic node function
            logicNode.Parameters = variables.ToArray( );
         }

         logicNode.Inputs  = inputs.ToArray( );
         logicNode.Drivens = drivens.ToArray( );

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

   private void Reflect(Type type, List<EntityDesc> entityDescs, Hashtable baseMethods, Hashtable baseEvents, Hashtable baseProperties )
   {
      EntityDesc entityDesc = new EntityDesc( );

      entityDesc.Type = type.ToString( );
      AddType( type );

      MethodInfo   []methodInfos   = type.GetMethods( );
      EventInfo    []eventInfos    = type.GetEvents( );
      PropertyInfo []propertyInfos = type.GetProperties( );
      FieldInfo    []fieldInfos   = type.GetFields( );

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
         if ( m.IsStatic ) continue;

         //don't expose our event methods to the user
         if ( typeof(uScriptEvent).IsAssignableFrom(type) ) continue;

         if ( false == m.IsPublic ) continue;
         if ( true  == baseMethods.Contains(m.Name) ) continue;

         ParameterInfo [] parameterInfos = m.GetParameters( );

         EntityMethod entityMethod = new EntityMethod( type.ToString( ), m.Name, FindFriendlyName(m.Name, m.GetCustomAttributes(false)) );
         List<Parameter> parameters = new List<Parameter>( );

         foreach ( ParameterInfo p in parameterInfos )
         {
            Parameter parameter = new Parameter( );
            parameter.Name    = p.Name;
            parameter.FriendlyName = FindFriendlyName(p.Name, p.GetCustomAttributes(false));
            parameter.Type    = p.ParameterType.ToString( ).Replace( "&", "" );

            if ( true == p.IsOut )
            {
               parameter.Input  = false;
               parameter.Output = true;
            }
            else if ( p.ParameterType.IsByRef )
            {
               parameter.Input  = true;
               parameter.Output = true;
            }
            else
            {
               parameter.Input  = true;
               parameter.Output = false;
            }

            parameter.DefaultAsObject = FindDefaultValue( "", p.GetCustomAttributes(false) );

            AddType( p.ParameterType );
            
            parameters.Add( parameter );
         }

         if ( m.ReturnType != typeof(void) )
         {
            Parameter parameter = new Parameter( );
            parameter.Name    = "Return";
            parameter.Type    = m.ReturnType.ToString( ).Replace( "&", "" );
            parameter.Input   = false;
            parameter.Output  = true;         
            parameter.Default = "";
            parameter.FriendlyName = "Return Value";

            AddType( m.ReturnType );
               
            parameters.Add( parameter );
         }

         entityMethod.Parameters = parameters.ToArray( );
         entityMethods.Add( entityMethod );
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
               input.DefaultAsObject = FindDefaultValue("", p.GetCustomAttributes(false));

               AddType( p.PropertyType );
            
               eventInputsOutpus.Add( input );
            }
         }

         Plug []outputPlug = new Plug[ 1 ];

         outputPlug[ 0 ].Name = e.Name;
         outputPlug[ 0 ].FriendlyName = FindFriendlyName(e.Name, e.GetCustomAttributes(false));

         EntityEvent entityEvent = new EntityEvent( type.ToString( ), FindFriendlyName(type.ToString(), type.GetCustomAttributes(false)), outputPlug );

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
                           output.DefaultAsObject = FindDefaultValue( "", eventProperty.GetCustomAttributes(false) );

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

         bool isInput = p.GetSetMethod( ) != null;
         bool isOutput= p.GetGetMethod( ) != null;

         EntityProperty property = new EntityProperty( p.Name, FindFriendlyName(p.Name, p.GetCustomAttributes(false)), type.ToString( ), p.PropertyType.ToString( ), isInput, isOutput );
         entityProperties.Add( property );

         AddType( p.PropertyType );
      }
      
      foreach ( FieldInfo f in fieldInfos )
      {
         if ( false == f.IsPublic ) continue;
         if ( true  == f.IsStatic ) continue;   

         EntityProperty property = new EntityProperty( f.Name, FindFriendlyName(f.Name, f.GetCustomAttributes(false)), type.ToString( ), f.FieldType.ToString( ), true, true );
         entityProperties.Add( property );

         AddType( f.FieldType );
      }


      entityDesc.Properties = entityProperties.ToArray( );

      entityDescs.Add( entityDesc );
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
      Dictionary<Type, Type> uniqueObjects = new Dictionary<Type, Type>( );

      Dictionary<Type, Type> eventNodes = new Dictionary<Type,Type>( );
      GatherDerivedTypes( eventNodes, uScriptConfig.Paths.uScriptNodes, typeof(uScriptEvent) );

      foreach ( UnityEngine.Object o in allObjects )
      {
         //ignore our uscripts, they are handled separately
         if ( typeof(uScriptCode).IsAssignableFrom(o.GetType()) ) continue;
         if ( typeof(uScriptLogic).IsAssignableFrom(o.GetType()) ) continue;

         uniqueObjects[ o.GetType() ] = o.GetType();
      }

      foreach ( Type t in eventNodes.Values )
      {
         uniqueObjects[ t ] = t;
      }

      foreach ( Type t in uniqueObjects.Values )
      {
         Reflect( t, entityDescs, baseMethods, baseEvents, baseProperties );
      }

      Reflect( typeof(UnityEngine.RuntimePlatform), entityDescs, baseMethods, baseEvents, baseProperties );

      //consolidate like events so they appear on the same node
      EntityDesc [] descs = entityDescs.ToArray( );
      for ( int i = 0; i < descs.Length; i++ )
      {
         EntityDesc desc = descs[ i ];

         //one or less event? no need to consolidate
         if ( desc.Events.Length <= 1 ) continue;

         Parameter [] parameters = desc.Events[0].Parameters;
         
         int c;

         for ( c = 1; c < desc.Events.Length; c++ )
         {
            if ( false == ArrayUtil.ArraysAreEqual(parameters, desc.Events[c].Parameters) )
            {
               break;
            }
         }

         //all parameters were matching because
         //we never had to break the for loop early
         if ( c == desc.Events.Length )
         {
            EntityEvent entityEvent = EntityEvent.Consolidator(desc.Events);
            desc.Events = new EntityEvent[] {entityEvent};

            descs[ i ] = desc;
         }
      }

      return descs;
   }

   public string AutoAssignInstance(EntityNode entityNode)
   {
      string type = uScript.FindNodeType(entityNode);
      if ( "" == type ) return "";

      if ( true == uScript.FindNodeAutoAssignMasterInstance(type) )
      {
         return uScriptRuntimeConfig.MasterObjectName;
      }

      return "";
   }

   //go through the master uscript and see if there
   //is an attach script which works this component
   //and if so return the script type so we can attach
   //it to the parent game object
   private Type FindMatchingScript(Component component)
   {
      if ( null == component ) return null;

      GameObject master = GameObject.Find( uScriptRuntimeConfig.MasterObjectName );
      if ( null == master ) return null;

      Component []eventScripts = master.GetComponents<uScriptEvent>( );

      foreach ( Component eventScript in eventScripts )
      {
         NodeComponentType requiredComponentType = FindNodeComponentType(eventScript.GetType());
         if ( null == requiredComponentType ) return null;

         if ( requiredComponentType.ContainsType(component.GetType()) )
         {
            return eventScript.GetType( );
         }

         //Type type = FindNodeComponentType(eventScript.GetType());
         //if ( null == type ) return null;

         //if ( type.IsAssignableFrom(component.GetType()) )
         //{
         //   return eventScript.GetType();
         //}
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

   //when adding an instance for an event script, asks the event script what 
   //component needs to exist for it to work
   //then go through all components and if the required component exists, allow the instance
   //and attach the event script to the game object
   public enum AttachError
   {
      None,
      NotFound,
      MissingComponent,
   }

   public AttachError AttachEventScript(string eventType, string objectName)
   {
      //what game object do we want to be the instance for our event script
      GameObject gameObject = GameObject.Find( objectName );
      if ( null == gameObject ) return AttachError.NotFound; //game object can't be found, let them proceed it might be created at runtime

      //unity type of our event script
      Type type = GetType(eventType);
      if ( null == type ) return AttachError.NotFound; //type can't be found, just let them proceed

      NodeComponentType requiredComponentType = FindNodeComponentType(type);
      if ( null == requiredComponentType ) return AttachError.None; //no required component

      //uScriptDebug.Log ("uScript.cs - GameObject = " + gameObject);
      //uScriptDebug.Log ("uScript.cs - RequiredType = " + requiredComponentType);

      //go through all the components and see if the required one exists
      Component [] components = gameObject.GetComponents<Component>( );

      foreach ( Component c in components )
      {
         //yes for some reason unity is giving me null components
         if ( null == c ) continue;

         //uScriptDebug.Log ("Checking component = " + c.GetType());

         //if the required component exists then attach the script
         if ( requiredComponentType.ContainsType(c.GetType()) )
         {
            //uScriptDebug.Log ("Is Assignable!");
            
            if ( null == gameObject.GetComponent(type) )
            {
               gameObject.AddComponent( type ); 
            }

            return AttachError.None;
         }
      }

      string names = "";

      foreach ( Type t in requiredComponentType.ComponentTypes )
      {
         names += t + ", ";
      }

      if ( names.Length >= 2 ) names = names.Substring( 0, names.Length - 2 );

      uScriptDebug.Log( "Could not attach " + objectName + " to " + eventType + " because " + 
                         objectName + " requires at one of the following components: " + names + ".", uScriptDebug.Type.Warning );

      return AttachError.MissingComponent;
   }

   private void CheckDragDropCanvas( )
   {
      foreach ( object o in DragAndDrop.objectReferences )
      {
         if ( false == (o is UnityEngine.Object) ) continue;

         if ( (m_ScriptEditorCtrl.CanDragDropOnNode(o) && DragAndDrop.objectReferences.Length == 1) || m_ScriptEditorCtrl.CanDragDropContextMenu(o) )
         {
            DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
         }
      }

      if ( Event.current.type == EventType.DragPerform )
      {
         // if all objects in the drag are droppable via context menu
         // create a new game object variable for each one
         bool canDropAll = true;
         foreach ( object o in DragAndDrop.objectReferences )
         {
            if ( !m_ScriptEditorCtrl.CanDragDropOnNode(o) && m_ScriptEditorCtrl.CanDragDropContextMenu(o) )
            {
               continue;
            }
            
            canDropAll = false;
            break;
         }
         
         if (canDropAll)
         {
            if (m_ScriptEditorCtrl.DoDragDropContextMenu( DragAndDrop.objectReferences ))
            {
               m_ContextX = (int) Event.current.mousePosition.x;
               m_ContextY = (int)(Event.current.mousePosition.y - _canvasRect.yMin);

               DragAndDrop.AcceptDrag( );
            }
         }
         else
         {
            foreach ( object o in DragAndDrop.objectReferences )
            {
               //we are going to perform a dragdrop, so before we do
               //see if there are any event scripts which can be
               //attached to this game object
               if ( true == m_ScriptEditorCtrl.CanDragDropOnNode(o) )
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
            }
         }
      }
   }
   
   public static object FindDefaultValue(string defaultValue, object [] attributes)
   {
      if ( null == attributes ) return defaultValue;

      foreach ( object a in attributes )
      {
         if ( a is DefaultValue ) 
         {
            return ((DefaultValue)a).Default;
         }
      }

      return defaultValue;
   }

   public static bool FindDrivenAttribute(object [] attributes)
   {
      if ( null == attributes ) return false;

      foreach ( object a in attributes )
      {
         if ( a is Driven ) return true;
      }

      return false;
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

   public static bool FindNodeAutoAssignMasterInstance(string type)
   {
      Type uscriptType = uScript.Instance.GetType(type);

      if ( uscriptType != null )
      {
         object [] attributes = uscriptType.GetCustomAttributes(false);
         if ( null == attributes ) return false;

         foreach ( object a in attributes )
         {
            if ( a is NodeAutoAssignMasterInstance ) 
            {
               return ((NodeAutoAssignMasterInstance)a).Value;
            }
         }
      }

      return false;
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

   public static string FindNodePropertiesPath(string defaultCategory, string type)
   {
      Type uscriptType = uScript.Instance.GetType(type);

      if ( uscriptType != null )
      {
         object [] attributes = uscriptType.GetCustomAttributes(false);
         if ( null == attributes ) return "";

         foreach ( object a in attributes )
         {
            if ( a is NodePropertiesPath ) 
            {
               return ((NodePropertiesPath)a).Value;
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
         return entityEvent.ComponentType;
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

   public static NodeComponentType FindNodeComponentType(Type type)
   {
      if ( type != null )
      {
         object [] attributes = type.GetCustomAttributes(false);
         if ( null == attributes ) return null;

         foreach ( object a in attributes )
         {
            if ( a is NodeComponentType ) 
            {
               return ((NodeComponentType)a);
            }
         }
      }

      return null;
   }


   void InitializeGUIButtons()
   {
      Button.Default(Button.ID.New,             "iconNew",              "New",                     "Create a new uScript. The active uScript will be closed automatically.");
      Button.Default(Button.ID.Open,            "iconOpen",             "Open...",                 "Open a uScript using the file browser.");
      Button.Default(Button.ID.Save,            "iconSave",             "Save",                    "Save the current uScript.");
      Button.Default(Button.ID.SaveAs,          "iconSaveAs",           "Save As...",              "Save the current uScript using the file browser.");
      Button.Default(Button.ID.RebuildAll,      "iconRebuildAll",       "Rebuild All uScripts",    "Rebuild all uScripts in the scene.");
      Button.Default(Button.ID.RemoveGenerated, "iconDeleteGenerated",  "Remove Generated Code",   "Removes all code generated by uScript.");
      Button.Default(Button.ID.Collapse,        "iconCollapse",         String.Empty,              "Collapse all node categories.");
      Button.Default(Button.ID.Expand,          "iconExpand",           String.Empty,              "Expand all node categories.");
      Button.Default(Button.ID.ClearFilter,     "iconClearFilter",      String.Empty,              "Clear the node search filter.");
      Button.Default(Button.ID.OnlineReference, "iconOnlineReference",  "Online Reference",        "");
//      Open Active uScript
//      Zoom In
//      Zoom Out
   }


   static class Button
   {
      public enum ID { New, Open, OpenAs, Save, SaveAs, RebuildAll, RemoveGenerated, Collapse, Expand, ClearFilter, OnlineReference }

      public enum StyleID { Icon, IconText, Text }

      static Dictionary<ID, GUIContent> _defaultGUIContent = new Dictionary<ID, GUIContent>();
      static Dictionary<ID, GUIContent> _currentGUIContent = new Dictionary<ID, GUIContent>();

      static StyleID _currentStyle = StyleID.IconText;

      static public StyleID Style
      {
         get { return _currentStyle; }
         set
         {
//            Debug.Log("Changing style from " + _currentStyle + " to " + value + "\n");
            _currentStyle = value;
            UpdateAll();
         }
      }

      static public void Default(ID id, string imageFilename, string text, string tooltip)
      {
         _defaultGUIContent[id] = new GUIContent(text, UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/" + imageFilename + (isPro ? "_pro" : string.Empty) + ".png", typeof(UnityEngine.Texture)) as UnityEngine.Texture, tooltip);
         Update(id);
      }

      static public GUIContent Content(ID id)
      {
         return _currentGUIContent[id];
      }

      static public void ChangeTooltip(ID id, string tooltip)
      {
         GUIContent content = _defaultGUIContent[id];
         content.tooltip = tooltip;
         _defaultGUIContent[id] = content;
         Update(id);
      }

      static void Update(ID id)
      {
         if ( (_currentStyle == uScript.Button.StyleID.Text && !String.IsNullOrEmpty(_defaultGUIContent[id].text) )
             || _defaultGUIContent[id].image == null)
         {
            _currentGUIContent[id] = new GUIContent(_defaultGUIContent[id].text, _defaultGUIContent[id].tooltip);
         }
         else if (_currentStyle == uScript.Button.StyleID.Icon || String.IsNullOrEmpty(_defaultGUIContent[id].text))
         {
            _currentGUIContent[id] = new GUIContent(_defaultGUIContent[id].image, _defaultGUIContent[id].tooltip);
         }
         else
         {
            _currentGUIContent[id] = new GUIContent(_defaultGUIContent[id]);
         }
      }

      static void UpdateAll()
      {
         foreach(KeyValuePair<ID, GUIContent> entry in _defaultGUIContent)
         {
            Update(entry.Key);
         }
      }
   }

}
