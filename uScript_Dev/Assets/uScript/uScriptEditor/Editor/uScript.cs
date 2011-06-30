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
   public string    uScriptBuild           { get { return "0.6.0936(RC1)"; } }
   public string    RequiredUnityBuild     { get { return "3.3"; } }
   public string    RequiredUnityBetaBuild { get { return "3.4"; } }
   public DateTime  ExpireDate             { get { return new DateTime( 2011, 7, 18 ); } }
   public int       EULAVersion            { get { return 20110630; } }

   private enum MouseRegion
   {
      Outside,
      Canvas,
      Palette,
      Properties,
      Reference,
      NestedScripts,
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
   bool _firstRun = true;

   private ScriptEditorCtrl m_ScriptEditorCtrl = null;
   private bool m_MouseDown  = false;
   private bool m_Repainting = false;
   private bool m_WantsCopy  = false;
   private bool m_WantsCut   = false;
   private bool m_WantsPaste = false;
   private bool m_WantsClose = false;

   private bool m_RebuildWhenReady = false;

   private String m_AddVariableNode = "";
   private KeyCode m_PressedKey = KeyCode.None;
   
   private string m_FullPath = "";
   private string m_CurrentCanvasPosition = "";
   private bool   m_ForceCodeValidation = false;
   
   private Detox.FlowChart.Node m_FocusedNode = null;
   
   static public Preferences Preferences = new Preferences( );
   static private AppFrameworkData m_AppData = new AppFrameworkData();
   static private bool m_SettingsLoaded = false;
   private double m_RefreshTimestamp = -1.0;

   // Used for double-click hack in uScripts panel
   private double clickTime;
//   private double doubleClickTime = 0.3;
 
   private bool m_CanvasDragging = false;
   
   private int m_ContextX = 0;
   private int m_ContextY = 0;
   private ToolStripItem m_CurrentMenu = null;

   Rect m_NodeWindowRect;
   public Rect NodeWindowRect { get { return m_NodeWindowRect; } }

   Rect m_NodeToolbarRect;
   public Rect NodeToolbarRect { get { return m_NodeToolbarRect; } }

   private const int DIVIDER_WIDTH = 4;

   /* uScript GUI Window Panel Layout Variables */


   bool     m_HidePanelMode = false;
   int      _guiPanelPalette_Width = 250;
   int      _guiPanelProperties_Height = 250;
   int      _guiPanelProperties_Width = 250;
   int      _guiPanelSequence_Width = 250;


   Rect _canvasRect;
   Vector2  _guiPanelPalette_ScrollPos;

   public Vector2  _guiContentScrollPos;

   Vector2  _guiPanelProperties_ScrollPos;

   Vector2  _guiHelpScrollPos;

   /* Palette Variables */
   private List<PaletteMenuItem> _paletteMenuItems;
   bool _paletteFoldoutToggle = false;
   String _paletteFilterText = string.Empty;
   String _graphListFilterText = string.Empty;

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

   public ScriptEditorCtrl ScriptEditorCtrl
   {
      get { return m_ScriptEditorCtrl; }
   }


   //
   // Content Panel Variables
   //
   bool _openScriptToggle = false;

   MouseEventArgs m_MouseDownArgs = null;
   MouseEventArgs m_MouseUpArgs   = null;
   MouseEventArgs m_MouseMoveArgs = new MouseEventArgs( );

   public bool m_SelectAllNodes = false;
   public bool m_DoPreferences  = false;

   public string CurrentScript = null;
   public string CurrentScriptName = "";
   public string CurrentScene = "";
   #region EULA Variables
   private int _EULAagreed = -1;
   private Vector2 _EULAscroll;
   private bool _EULAtoggle;
   private string _EULAtext = @"IMPORTANT, PLEASE READ CAREFULLY. THIS IS A LICENSE AGREEMENT

USCRIPT VISUAL SCRIPTING TOOL BETA EVALUATION LICENSE

This SOFTWARE PRODUCT is protected by copyright laws and international copyright treaties, as well as other intellectual property laws and treaties. This SOFTWARE PRODUCT is licensed, not sold.

End User License Agreement

This End User License Agreement (""EULA"") is a legal agreement between you (either an individual or a single entity) and Detox Studios LLC with regard to the copyrighted Software (herein referred to as ""SOFTWARE PRODUCT"" or ""SOFTWARE"") provided with this EULA.   The SOFTWARE PRODUCT includes computer software, the associated media, any printed materials, and any ""online"" or electronic documentation. Use of any software and related documentation provided to you by Detox Studios LLC in whatever form or media, will constitute your acceptance of these terms, unless separate terms are provided by the software supplier, in which case certain additional or different terms may apply. If you do not agree with the terms of this EULA do not use the Software and uninstall it. By continuing past this EULA, and/or using the SOFTWARE PRODUCT, you agree to be bound by the terms of this EULA.  If you do not agree to the terms of this EULA, Detox Studios LLC is unwilling to license the SOFTWARE PRODUCT to you. 

1.  Eligible Licensees. This Software is available for license solely to SOFTWARE owners, with no right of duplication or further distribution, licensing, or sub-licensing.  IF YOU DO NOT OWN THE SOFTWARE, THEN DO NOT DOWNLOAD, INSTALL, COPY OR USE THE SOFTWARE.
 
2.  License Grant.  Detox Studios LLC grants to you a personal, non-transferable and non-exclusive right to use the copy of the Software provided with this EULA for evaluation purposes only. You agree you will not copy the Software except as necessary for your single and individual use. You agree that you may not copy the written materials accompanying the Software. Modifying, translating, renting, copying, transferring or assigning all or part of the Software, or any rights granted hereunder, to any other persons and removing any proprietary notices, labels or marks from the Software is strictly prohibited.  Furthermore, you hereby agree not to create derivative works based on the Software.  You may not transfer this Software.  You may not use this software, directly or indirectly, to generate commercial product for yourself, or recieve compensation from use of this software.

3.  Copyright.  The Software is licensed, not sold.  You acknowledge that no title to the intellectual property in the Software is transferred to you. You further acknowledge that title and full ownership rights to the Software will remain the exclusive property of Detox Studios LLC and/or its suppliers, and you will not acquire any rights to the Software, except as expressly set forth above. All copies of the Software will contain the same proprietary notices as contained in or on the Software. All title and copyrights in and to the SOFTWARE PRODUCT (including but not limited to any images, photographs, animations, video, audio, music, text and ""applets,"" incorporated into the SOFTWARE PRODUCT), the accompanying printed materials, and any copies of the SOFTWARE PRODUCT, are owned by Detox Studios LLC or its suppliers.  The SOFTWARE PRODUCT is protected by copyright laws and international treaty provisions.  You may not copy the printed materials accompanying the SOFTWARE PRODUCT.

4.  Reverse Engineering.  You agree that you will not attempt, and if you are a corporation, you will use your best efforts to prevent your employees and contractors from attempting to reverse compile, modify, translate or disassemble the Software in whole or in part. Any failure to comply with the above or any other terms and conditions contained herein will result in the automatic termination of this license and the reversion of the rights granted hereunder to Detox Studios LLC.

5.  Disclaimer of Warranty. The Software is provided ""AS IS"" without warranty of any kind. Detox Studios LLC and its suppliers disclaim and make no express or implied warranties and specifically disclaim the warranties of merchantability, fitness for a particular purpose and non-infringement of third-party rights. The entire risk as to the quality and performance of the Software is with you. Neither Detox Studios LLC nor its suppliers warrant that the functions contained in the Software will meet your requirements or that the operation of the Software will be uninterrupted or error-free. Detox Studios LLC IS NOT OBLIGATED TO PROVIDE ANY UPDATES TO THE SOFTWARE.

6.  Copyright.  The Software is licensed, not sold.  You acknowledge that no title to the intellectual property in the Software is transferred to you. You further acknowledge that title and full ownership rights to the Software will remain the exclusive property of Detox Studios LLC and/or its suppliers, and you will not acquire any rights to the Software, except as expressly set forth above. All copies of the Software will contain the same proprietary notices as contained in or on the Software. All title and copyrights in and to the SOFTWARE PRODUCT (including but not limited to any images, photographs, animations, video, audio, music, text and ""applets,"" incorporated into the SOFTWARE PRODUCT), the accompanying printed materials, and any copies of the SOFTWARE PRODUCT, are owned by Detox Studios LLC or its suppliers.  The SOFTWARE PRODUCT is protected by copyright laws and international treaty provisions.  You may not copy the printed materials accompanying the SOFTWARE PRODUCT.

7.  Rental.  You may not loan, rent, or lease the SOFTWARE.  

8.  Upgrades.  If the SOFTWARE is an upgrade from an earlier release or previously released version, you now may use that upgraded product only in accordance with this EULA.  If the SOFTWARE PRODUCT is an upgrade of a software program which you licensed as a single product, the SOFTWARE PRODUCT may be used only as part of that single product package and may not be separated for use by anyone other than the individual user who has been granted the license.

9.  OEM Product Support. Product support for the SOFTWARE PRODUCT is provided by Detox Studios LLC through an online website and documentation.  For product support, please visit http://uscript.net.  Should you have any questions concerning this, please refer to the email address provided in the documentation.

10. No Liability for Consequential Damages.  In no event shall Detox Studios LLC or its suppliers be liable for any damages whatsoever (including, without limitation, incidental, direct, indirect special and consequential damages, damages for loss of business profits, business interruption, loss of business information, or other pecuniary loss) arising out of the use or inability to use this SOFTWARE PRODUCT, even if Detox Studios LLC has been advised of the possibility of such damages.  Because some states/countries do not allow the exclusion or limitation of liability for consequential or incidental damages, the above limitation may not apply to you.

11. Indemnification By You.  If you distribute the Software in violation of this Agreement, you agree to indemnify, hold harmless and defend Detox Studios LLC and its suppliers from and against any claims or lawsuits, including attorney's fees that arise or result from the use or distribution of the Software in violation of this Agreement.

12. Termination of Use. You agree to not use the SOFTWARE PRODUCT beyond its calendar end date as specified in the Unity console window. You may update your beta evaluation software if one is publiclly provided by Detox Studios LLC. If no new beta evaluation build are provided, you must stop using the SOFTWARE PRODUCT until a full license is purchased.

Detox Studios LLC
info@detoxstudios.com
http://www.detoxstudios.com
http://uscript.net

(06/30/2011)";
   #endregion
   
   public bool IsAttachedToMaster
   {
      get
      {
         if (MasterObject != null && !String.IsNullOrEmpty(m_FullPath))
         {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(m_FullPath);
            bool isSafe = false;
            string safePath = UnityCSharpGenerator.MakeSyntaxSafe(fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".")), out isSafe);
            return MasterObject.GetComponent(safePath+uScriptConfig.Files.GeneratedComponentExtension) != null;
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
            string componentPath = safePath+uScriptConfig.Files.GeneratedComponentExtension;
    
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
   [UnityEditor.MenuItem ("Tools/Detox Studios/uScript Editor %u")]
   static void Init ()
   {
      s_Instance = (uScript) EditorWindow.GetWindow(typeof(uScript), false, "uScript Editor");
      s_Instance.wantsMouseMove = true;

      System.IO.Directory.CreateDirectory( uScriptConfig.ConstantPaths.RootFolder );
      System.IO.Directory.CreateDirectory( uScriptConfig.ConstantPaths.uScriptNodes );
      System.IO.Directory.CreateDirectory( uScriptConfig.ConstantPaths.uScriptEditor );

      System.IO.Directory.CreateDirectory( Preferences.ProjectFiles );
      System.IO.Directory.CreateDirectory( Preferences.UserScripts );
      System.IO.Directory.CreateDirectory( Preferences.UserNodes );
      System.IO.Directory.CreateDirectory( Preferences.GeneratedScripts );
      System.IO.Directory.CreateDirectory( Preferences.NestedScripts );

      //System.IO.Directory.CreateDirectory( Preferences.TutorialFiles );
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

   static public string PackageAsset(object asset, Type type)
   {
      GameObject uScriptMaster = GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
      uScript_Assets assetComponent = null;
   
      if ( null != uScriptMaster ) assetComponent = uScriptMaster.GetComponent<uScript_Assets>( );                        
      
      if ( null != assetComponent )
      {
         object assetInstance = asset;
      
         //if it was saved as a string - assume it's a path
         if ( assetInstance is string )
         {
            assetInstance = UnityEditor.AssetDatabase.LoadAssetAtPath( assetInstance as string, type );
         }

         if ( assetInstance is UnityEngine.Object )
         {
            UnityEngine.Object objectInstance = assetInstance as UnityEngine.Object;

            //append the name as part of the unique key - because some items (like fbx files) have multiple assets in them
            string uniqueKey = uScriptConfig.GetAssetPackageKey( asset, type ); 
            assetComponent.Add( uniqueKey, objectInstance );
         
            return uniqueKey;
         }
      }

      return "";
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


   public void RegisterUndo(string name, ScriptEditor oldScript, ScriptEditor newScript)
   {
      if ( null != MasterComponent )
      {
         MasterComponent.Script = oldScript.ToBase64( );
         MasterComponent.ScriptName = oldScript.Name;

         //save the old one to the undo stack
         UnityEditor.Undo.RegisterUndo( MasterComponent, name + " (uScript)" );

         //register the new one with uscript and the master component
         CurrentScript = newScript.ToBase64( );
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
      if ( true == CodeValidator.RequireRebuild(m_ForceCodeValidation) )
      {
         RebuildAllScripts( );
      }
      
      //rebuild was requested but we have to wait until the editor
      //is done compiling so it properly reflects everything
      if ( true == m_RebuildWhenReady && false == EditorApplication.isCompiling )
      {         
         //now build any scripts which are used as nested nodes
         //when these are done we will then build any scripts which references these
         //see the m_DoRebuildScripts below
         AssetDatabase.StartAssetEditing( );
            RebuildScripts( Preferences.UserScripts );
         AssetDatabase.StopAssetEditing( );
         AssetDatabase.Refresh();

         m_RebuildWhenReady = false;
      }

      if ( true == m_SelectAllNodes )
      {
         m_ScriptEditorCtrl.SelectAllNodes();
         m_ScriptEditorCtrl.SelectAllLinks();

         m_SelectAllNodes = false;
      }

      bool contextActive = 0 != m_ContextX || 0 != m_ContextY;

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

      if ( null != MasterComponent && CurrentScript != MasterComponent.Script )
      {
         rebuildScript = true;
      }
      
      if (null == m_ScriptEditorCtrl || true == rebuildScript)
      {
         if ( null == m_ScriptEditorCtrl )
         {
            //if ( Application.unityVersion == RequiredUnityBuild || Application.unityVersion == RequiredUnityBetaBuild || Application.unityVersion == RequiredUnityBetaBuildPrevious )
            if (Application.unityVersion.Contains(RequiredUnityBuild) || Application.unityVersion.Contains(RequiredUnityBetaBuild))
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
         if (null == uScriptMaster.GetComponent<uScript_Assets>())
         {
            uScriptDebug.Log("Adding Asset Object to master gameobject (" + uScriptRuntimeConfig.MasterObjectName + ")", uScriptDebug.Type.Debug);
            uScriptMaster.AddComponent(typeof(uScript_Assets));
         }

         //save all the types from unity so we can use them for quick lookup, we can't use Type.GetType because
         //we don't save the fully qualified type name which is required to return types of assemblies not loaded
         List<UnityEngine.Object> allObjects = new List<UnityEngine.Object>(GameObject.FindObjectsOfType(typeof(UnityEngine.Object)));

         foreach (UnityEngine.Object o in allObjects)
         {
            MasterComponent.AddType(o.GetType());
         }

         foreach ( uScriptConfigBlock b in uScriptConfig.Variables )
         {
            MasterComponent.AddType(b.Type);
         }

         bool isRestored = false;
         bool isDirty    = false;
         
         ScriptEditor scriptEditor = null;

         if ( !String.IsNullOrEmpty(MasterComponent.Script) )
         {
            //open with no preexisting types which means it loads the data direct
            //and we can figure out what required types we need
            scriptEditor = new ScriptEditor("", null, null);
            if ( true == scriptEditor.OpenFromBase64(MasterComponent.ScriptName, MasterComponent.Script) )
            {
               scriptEditor = new ScriptEditor("Untitled", PopulateEntityTypes( scriptEditor.Types ), PopulateLogicTypes());
               scriptEditor.OpenFromBase64(MasterComponent.ScriptName, MasterComponent.Script) ;
               
               isRestored = true;

               //if we're restoring over an old script
               //we need to flag us as dirty (because this was do to an undo/redo being triggered)
               if ( CurrentScript != MasterComponent.Script && null != CurrentScript )
               {
                  isDirty = true;
               }

               CurrentScript = MasterComponent.Script;
               CurrentScriptName = MasterComponent.ScriptName;
            }
         }
         else
         {
            scriptEditor = new ScriptEditor("Untitled", PopulateEntityTypes( null ), PopulateLogicTypes());
         }

         if (String.IsNullOrEmpty(m_FullPath))
         {
            String lastOpened = (String)uScript.GetSetting("uScript\\LastOpened", "");
            if (!String.IsNullOrEmpty(lastOpened))
            {
               m_FullPath = UnityEngine.Application.dataPath + lastOpened;
            }
         }

   		Point loc = Point.Empty;
         if ( !String.IsNullOrEmpty(m_FullPath) )
         {
            m_CurrentCanvasPosition = (String)GetSetting("uScript\\" + uScriptConfig.ConstantPaths.RelativePath(m_FullPath) + "\\CanvasPosition", "");
         }
         if ( false == String.IsNullOrEmpty(m_CurrentCanvasPosition) )
         {
            loc = new Point(Int32.Parse(m_CurrentCanvasPosition.Substring(0, m_CurrentCanvasPosition.IndexOf(","))), 
                            Int32.Parse(m_CurrentCanvasPosition.Substring(m_CurrentCanvasPosition.IndexOf(",") + 1)));
         }
         
         m_ScriptEditorCtrl = new ScriptEditorCtrl( scriptEditor, loc );

         m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);

         m_ScriptEditorCtrl.BuildContextMenu();

         BuildPaletteMenu(null, null);

         Detox.Utility.Status.StatusUpdate += new Detox.Utility.Status.StatusUpdateEventHandler(Status_StatusUpdate);

         //when doing certain operations like 'play' in unity
         //it seems to set any class references back to null
         //since the string isn't a reference it stays valid
         //so reopen our script
         if ("" != m_FullPath && false == isRestored )
         {
            if (!OpenScript(m_FullPath)) m_FullPath = "";
            m_RefreshTimestamp = EditorApplication.timeSinceStartup;
         }
         
         if ( true == isDirty )
         {
            //force rebuilt from undo so mark as dirty
            m_ScriptEditorCtrl.IsDirty = true;
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

      //we can't ignore if the context menu is up
      //because we need to send the mouse up
      //after it has been activated
      //if ( false == contextActive )
      {
         if ( null != m_MouseDownArgs )
         {
            OnMouseDown( );
            m_MouseDownArgs = null;
         }
         else if ( null != m_MouseUpArgs )
         {
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
            if ( !String.IsNullOrEmpty(m_FullPath) )
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
         }
         m_RefreshTimestamp = -1.0;
      }
      
      if ( true == m_WantsCopy )
      {
         m_ScriptEditorCtrl.CopyToClipboard( );
         m_WantsCopy = false;
      }
      if ( true == m_WantsCut )
      {
         m_ScriptEditorCtrl.CopyToClipboard( );
         m_ScriptEditorCtrl.DeleteSelectedNodes( );
         m_WantsCut = false;
      }
      if ( true == m_WantsPaste )
      {
         m_ScriptEditorCtrl.PasteFromClipboard( Point.Empty );
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

      if ( _requestedCloseMap )
      {
         _requestedCloseMap = false;
         mapToggle = false;

         // Center the canvas on _requestCanvasLocation
         m_ScriptEditorCtrl.CenterOnPoint( _requestCanvasLocation );
      }

      if ( false == contextActive )
      {
         OnMouseMove( );
      }
   }


   bool _requestedCloseMap = false;
   Point _requestCanvasLocation = Point.Empty;



   void OnGUI()
   {
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
      }

      if (m_ScriptEditorCtrl == null)
      {
         return;
      }

      GUI.enabled = !m_DoPreferences;

      //
      // Show the EULA if the user hasn't yet agreed to it
      //
      if (_EULAagreed != EULAVersion)
      {
         _EULAagreed = (int) uScript.GetSetting( "EULA\\AgreedVersion", -1 );
         GUI.enabled = _EULAagreed == EULAVersion;
      }


      // Set the default mouse region
      _mouseRegion = uScript.MouseRegion.Outside;
      
      // As little logic as possible should be performed here.  It is better
      // to use Update() to perform tasks once per tick.

      bool lastMouseDown = m_MouseDown;
      
      bool contextActive = 0 != m_ContextX || 0 != m_ContextY;
      if ( false == contextActive && false == m_DoPreferences)
      {
         int modifierKeys = 0;

         if ( Event.current.alt )     modifierKeys |= Keys.Alt;
         if ( Event.current.shift )   modifierKeys |= Keys.Shift;
         if ( Event.current.control || Event.current.command ) modifierKeys |= Keys.Control;
         
         Control.ModifierKeys.Pressed = modifierKeys;

         Event e = Event.current;
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
                  if ( m_ScriptEditorCtrl.CanCopy && "MainView" == GUI.GetNameOfFocusedControl( ) )
                  {
                     Event.current.Use( );
                  }
               }
               else if ( Event.current.commandName == "Cut" )
               {
                  if ( m_ScriptEditorCtrl.CanCopy && "MainView" == GUI.GetNameOfFocusedControl( )  )
                  {
                     Event.current.Use( );
                  }
               }
               else if ( Event.current.commandName == "Paste" && "MainView" == GUI.GetNameOfFocusedControl( )  )
               {
                  if ( m_ScriptEditorCtrl.CanPaste )
                  {
                     Event.current.Use( );
                  }
               }
               else if ( Event.current.commandName == "SelectAll" && "MainView" == GUI.GetNameOfFocusedControl( )  )
               {
                  Event.current.Use( );
               }
               break;
            case EventType.ExecuteCommand:
               if ( Event.current.commandName == "Copy" && "MainView" == GUI.GetNameOfFocusedControl( )  )
               {
                  m_WantsCopy = true;
               }
               else if ( Event.current.commandName == "Cut" && "MainView" == GUI.GetNameOfFocusedControl( )  )
               {
                  m_WantsCut = true;
               }
               else if ( Event.current.commandName == "Paste" && "MainView" == GUI.GetNameOfFocusedControl( )  )
               {
                  m_WantsPaste = true;
               }
               else if ( Event.current.commandName == "SelectAll" && "MainView" == GUI.GetNameOfFocusedControl( )  )
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
               m_MouseMoveArgs.X = (int)Event.current.mousePosition.x;
               m_MouseMoveArgs.Y = (int)Event.current.mousePosition.y;
               break;
            
            // key events
            case EventType.KeyDown:
               if (Event.current.keyCode != KeyCode.None)
               {
                  m_PressedKey = Event.current.keyCode;
               }
               break;
            case EventType.KeyUp:
               if ( "MainView" == GUI.GetNameOfFocusedControl( ) )
               {
                  if ( Event.current.keyCode == KeyCode.Delete || Event.current.keyCode == KeyCode.Backspace )
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
                  else if ( Event.current.keyCode == KeyCode.W && (modifierKeys & Keys.Control) != 0 )
                  {
                     // close the window
                     m_WantsClose = true;
                  }
                  else if ( Event.current.keyCode == KeyCode.M )
                  {
                     mapToggle = !mapToggle;
                  }
                  else if ( Event.current.keyCode == KeyCode.Space )
                  {
                     m_HidePanelMode = !m_HidePanelMode;
                  
                     if (m_HidePanelMode)
                     {
                        m_ScriptEditorCtrl.FlowChart.Location.X += _guiPanelPalette_Width + DIVIDER_WIDTH;
                        m_ScriptEditorCtrl.RefreshScript(null, false);
                     }
                     else
                     {
                        m_ScriptEditorCtrl.FlowChart.Location.X -= _guiPanelPalette_Width + DIVIDER_WIDTH;
                        m_ScriptEditorCtrl.RefreshScript(null, false);
                     }
                  }
                  else if ( Event.current.keyCode == KeyCode.Escape )
                  {
                     if ( "MainView" == GUI.GetNameOfFocusedControl( ) )
                     {
                        m_ScriptEditorCtrl.DeselectAll();
                     }
                  }
                  else if ( Event.current.keyCode == KeyCode.F1 )
                  {
                     Help.BrowseURL("http://www.uscript.net/docs/index.php?title=Main_Page");
                  }
                  else if ( Event.current.keyCode == KeyCode.G && (modifierKeys & Keys.Control) != 0 )
                  {
                     Preferences.ShowGrid = ! Preferences.ShowGrid;
                     Preferences.Save( );
                  }
                  else if ( Event.current.keyCode == KeyCode.RightBracket )
                  {
                     m_FocusedNode = m_ScriptEditorCtrl.GetNextNode(m_FocusedNode, typeof(EntityEventDisplayNode));
                     if (m_FocusedNode != null) m_ScriptEditorCtrl.CenterOnNode(m_FocusedNode);
                  }
                  else if ( Event.current.keyCode == KeyCode.LeftBracket )
                  {
                     m_FocusedNode = m_ScriptEditorCtrl.GetPrevNode(m_FocusedNode, typeof(EntityEventDisplayNode));
                     if (m_FocusedNode != null) m_ScriptEditorCtrl.CenterOnNode(m_FocusedNode);
                  }
               }
   
               m_PressedKey = KeyCode.None;

               //keep key events from going to the rest of unity
               Event.current.Use( );
               break;

            // mouse events
            case EventType.MouseDown:
               if ( false == m_MouseDown )
               {
                  GUI.FocusControl( "MainView" );

                  if ( mapToggle )
                  {
                     MiniMapClick();
                  }
                  else
                  {
                     if ( _canvasRect.Contains( Event.current.mousePosition ) )
                     {
                        m_MouseDownArgs = new System.Windows.Forms.MouseEventArgs();
   
                        int button = 0;
   
                        if ( Event.current.button == 0 ) button = MouseButtons.Left;
                        else if ( Event.current.button == 1 ) button = MouseButtons.Right;
                        else if ( Event.current.button == 2 ) button = MouseButtons.Middle;
   
                        m_MouseDownArgs.Button = button;
                        m_MouseDownArgs.X = (int)(Event.current.mousePosition.x);
                        if (!m_HidePanelMode) m_MouseDownArgs.X -= _guiPanelPalette_Width;
                        m_MouseDownArgs.Y = (int)(Event.current.mousePosition.y - _canvasRect.yMin);
                     }
   
                     if ( Event.current.clickCount == 2 )
                     {
                        OpenLogicNode( );
                     }
                  }
               }

               // update the mouse move position whenever there's a click in case we were previously outside the window
               m_MouseMoveArgs.X = (int)Event.current.mousePosition.x;
               m_MouseMoveArgs.Y = (int)Event.current.mousePosition.y;

               m_MouseDown = true;
               break;
            case EventType.MouseDrag:
            case EventType.MouseMove:
               // update mouse position
               m_MouseMoveArgs.Button = Control.MouseButtons.Buttons;
               m_MouseMoveArgs.X = (int)Event.current.mousePosition.x;
               m_MouseMoveArgs.Y = (int)Event.current.mousePosition.y;
               if (m_MouseDownRegion == uScript.MouseRegion.Canvas)
               {
                  // this is the switch to use to turn off panel rendering while panning/marquee selecting
                  m_CanvasDragging = true;
               }
               break;
            case EventType.MouseUp:
               if ( true == m_MouseDown )
               {
                  m_MouseUpArgs = new System.Windows.Forms.MouseEventArgs( );
      
                  int button = 0;
      
                  if ( Event.current.button == 0 ) button = MouseButtons.Left;
                  else if ( Event.current.button == 1 ) button = MouseButtons.Right;
                  else if ( Event.current.button == 2 ) button = MouseButtons.Middle;
      
                  m_MouseUpArgs.Button = button;
                  m_MouseUpArgs.X = (int)(Event.current.mousePosition.x);
                  if (!m_HidePanelMode) m_MouseUpArgs.X -= _guiPanelPalette_Width;
                  m_MouseUpArgs.Y = (int)(Event.current.mousePosition.y - _canvasRect.yMin);
               
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
            m_MouseDownArgs = null;
            m_MouseDown = false;

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

      // where is the mouse?
      CalculateMouseRegion();
  
      // do external windows/popups
      DrawPopups(contextActive);
      
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
      if ( true == m_MouseDown && _mouseRegion == MouseRegion.Outside && m_MouseUpArgs == null )
      {
         m_MouseUpArgs = new System.Windows.Forms.MouseEventArgs( );

         int button = 0;

         if ( Event.current.button == 0 ) button = MouseButtons.Left;
         else if ( Event.current.button == 1 ) button = MouseButtons.Right;
         else if ( Event.current.button == 2 ) button = MouseButtons.Middle;

         m_MouseUpArgs.Button = button;
         m_MouseUpArgs.X = (int)(Event.current.mousePosition.x);
         if (!m_HidePanelMode) m_MouseUpArgs.X -= _guiPanelPalette_Width;
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

      if (_EULAagreed != EULAVersion)
      {
         _EULAagreed = (int) uScript.GetSetting( "EULA\\AgreedVersion", -1 );
         
         if (_EULAagreed != EULAVersion)
         {
            int w = 550;
            int h = Math.Max(300, (int)position.height - 400);
            Rect r = new Rect((position.width-w)/2, (position.height-h)/2, w, h);
            
            GUI.Window(110, r, DoWindowEULA, "End User License Agreement");
         }
      }
      
      if (_EULAagreed == EULAVersion)
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

      if (m_DoPreferences)
      {
         DrawPreferences( );
      }
      EndWindows( );
   }

   void OnPlaymodeStateChanged()
   {
      if (EditorApplication.isPlayingOrWillChangePlaymode && m_ScriptEditorCtrl != null && true == m_ScriptEditorCtrl.IsDirty)
      {
         EditorUtility.DisplayDialog( "uScript Not Saved!", "uScript has detected that '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' has been changed, but not saved! You will not see any changes until you save '" + m_ScriptEditorCtrl.ScriptEditor.Name + "' in the uScript Editor.", "OK" );
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

   void OpenLogicNode( )
   {
      if ( m_ScriptEditorCtrl.SelectedNodes.Length == 1 )
      {
         EntityNode entityNode = m_ScriptEditorCtrl.SelectedNodes[0].EntityNode;

         if ( entityNode is LogicNode )
         {
            LogicNode logicNode = (LogicNode) entityNode;

            string uscriptPath = Preferences.UserScripts;

            if ( logicNode.Type.EndsWith( uScriptConfig.Files.GeneratedCodeExtension ) )
            {
               string script = uscriptPath + "/" + logicNode.Type.Substring(0, logicNode.Type.LastIndexOf(uScriptConfig.Files.GeneratedCodeExtension));
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
      uScriptGUIContent.Init((uScriptGUIContent.ContentStyle)Preferences.ToolbarButtonStyle);
      uScriptGUIStyle.Init();

      DrawGUITopAreas();
      if (!m_HidePanelMode)
      {
         DrawGUIHorizontalDivider();

         SetMouseRegion( MouseRegion.HandleCanvas );//, 1, -3, -1, 6 );
  
         DrawGUIBottomAreas();
      }
      DrawGUIStatusbar();

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
            DrawGUIPalette();
            DrawGUIVerticalDivider();
   
            SetMouseRegion( MouseRegion.HandlePalette );//, -3, 1, 6, -4 );
         }

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

         DrawGUINestedScripts();
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


      if (Event.current.type == EventType.Repaint)
      {
//         _statusbarRect = GUILayoutUtility.GetLastRect();
      }

      //      Redraw();  // This is taking to much CPU time.
   }

//   Rect _statusbarRect = new Rect();

   void DrawGUIPalette()
   {
      Rect r = EditorGUILayout.BeginVertical( uScriptGUIStyle.panelBox, GUILayout.Width( _guiPanelPalette_Width ) );
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
                                                      (_paletteFoldoutToggle ? uScriptGUIContent.toolbarButtonCollapse : uScriptGUIContent.toolbarButtonExpand),
                                                      uScriptGUIStyle.paletteToolbarButton,
                                                      GUILayout.ExpandWidth(false));
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
//               string _filterText = GUILayout.TextField(_paletteFilterText, 10, "toolbarTextField", GUILayout.Width(80));
               GUI.SetNextControlName ("" );
               if (_filterText != _paletteFilterText)
               {
                  // Drop focus if the user inserted a newline (hit enter)
                  if (_filterText.Contains('\n'))
                  {
                     GUIUtility.keyboardControl = 0;
                  }

//                  // Only allow letters and digits
//                  _filterText = new string(_filterText.Where(ch => char.IsLetterOrDigit(ch)).ToArray());

                  // Trim leading whitespace
                  _filterText = _filterText.TrimStart( new char[] { ' ' } );

                  _paletteFilterText = _filterText;
                  FilterPaletteMenuItems();
               }

//               // Clear the node text filter
//               if ( GUILayout.Button( Button.Content( Button.ID.ClearFilter ), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
//               {
//                  GUIUtility.keyboardControl = 0;
//                  _paletteFilterText = String.Empty;
//                  FilterPaletteMenuItems();
//               }
            }
            else
            {
               // This is where the Graph Contents toolbar buttons will go

               // Toggle hierarchy foldouts
//               bool newToggleState = GUILayout.Toggle(_paletteFoldoutToggle,
//                                                      (_paletteFoldoutToggle ? uScriptGUIContent.toolbarButtonCollapse : uScriptGUIContent.toolbarButtonExpand),
//                                                      uScriptGUIStyle.paletteToolbarButton,
//                                                      GUILayout.ExpandWidth(false));
//               if (_paletteFoldoutToggle != newToggleState)
//               {
//                  _paletteFoldoutToggle = newToggleState;
//                  if (_paletteFoldoutToggle)
//                  {
//                     ExpandPaletteMenuItem(null);
//                  }
//                  else
//                  {
//                     CollapsePaletteMenuItem(null);
//                  }
//               }

               GUI.SetNextControlName ("FilterSearch" );
               string _filterText = uScriptGUI.ToolbarSearchField(_graphListFilterText, GUILayout.Width(100));
               GUI.SetNextControlName ("" );
               if (_filterText != _graphListFilterText)
               {
                  // Drop focus if the user inserted a newline (hit enter)
                  if (_filterText.Contains('\n'))
                  {
                     GUIUtility.keyboardControl = 0;
                  }

                  // Trim leading whitespace
                  _filterText = _filterText.TrimStart( new char[] { ' ' } );

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

            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.wordWrap = true;
            style.padding = new RectOffset(16, 16, 16, 16);

            GUILayout.Label(message, style, GUILayout.ExpandHeight(true));
         }
         else
         {
            if (_paletteMode == 0)
            {
               // Node list
               //
               _guiPanelPalette_ScrollPos = EditorGUILayout.BeginScrollView( _guiPanelPalette_ScrollPos, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview", GUILayout.ExpandWidth(true) );
               {
                  foreach (PaletteMenuItem item in _paletteMenuItems)
                  {
                     DrawPaletteMenu(item);
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
                     name = name + ": " + (name == "String" ? "\"" + ((LocalNodeDisplayNode)displayNode).LocalNode.Value.Default + "\"" : ((LocalNodeDisplayNode)displayNode).LocalNode.Value.Default);
                     comment = ((LocalNodeDisplayNode)displayNode).LocalNode.Name.Default;
                  }
                  else if (displayNode is CommentDisplayNode)
                  {
                     category = "Comments";
                     name = ((CommentDisplayNode)displayNode).Comment.TitleText.FriendlyName;
                     comment = ((CommentDisplayNode)displayNode).Comment.TitleText.Default;
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
                     if (categories[category].ContainsKey(name) == false)
                     {
                        categories[category].Add(name, new List<DisplayNode>());
                     }
   
                     // Add the node to the list
                     categories[category][name].Add(displayNode);
                  }
               }

               _guiPanelPalette_ScrollPos = EditorGUILayout.BeginScrollView ( _guiPanelPalette_ScrollPos, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview", GUILayout.ExpandWidth(true) );
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
   
                        bool tmpBool = true;
                        tmpBool = GUILayout.Toggle(tmpBool, kvpCategory.Key, tmpStyle);
                        if (tmpBool)
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
                                    name = name + ": " + (name == "String" ? "\"" + ((LocalNodeDisplayNode)dn).LocalNode.Value.Default + "\"" : ((LocalNodeDisplayNode)dn).LocalNode.Value.Default);
                                    comment = ((LocalNodeDisplayNode)dn).LocalNode.Name.Default;
                                 }
                                 else if (dn is CommentDisplayNode)
                                 {
                                    name = ((CommentDisplayNode)dn).Comment.TitleText.FriendlyName;
                                    comment = ((CommentDisplayNode)dn).Comment.TitleText.Default;
                                 }
      
                                 // Validate strings
                                 name = (String.IsNullOrEmpty(name) ? "UNKNOWN" : name);
                                 comment = (String.IsNullOrEmpty(comment) ? string.Empty : " (" + comment + ")");
   
                                 GUILayout.BeginHorizontal();
                                 {
                                    nodeButtonContent.text = name + comment;
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
   
                                    if (GUILayout.Button(uScriptGUIContent.listMiniSearch, uScriptGUIStyle.nodeButtonRight, GUILayout.Width(20)))
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
      }
   }
   
   bool HiddenRegion(MouseRegion region)
   {
      if (!m_HidePanelMode) return false;

      return region != uScript.MouseRegion.Canvas && region != uScript.MouseRegion.Outside;
   }
   
   void CalculateMouseRegion()
   {
      foreach( KeyValuePair<MouseRegion, Rect> kvp in _mouseRegionRect )
      {
         if ( kvp.Value.Contains( Event.current.mousePosition ) && !HiddenRegion(kvp.Key) )
         {
            _mouseRegion = kvp.Key;
            break;
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
            paletteMenuItem.Tooltip = FindNodeToolTip( ScriptEditor.FindNodeType(contextMenuItem.Tag as EntityNode) );
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
         GUIStyle tmpStyle = new GUIStyle(uScriptGUIStyle.paletteFoldout);
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
      }
   }




   void RefreshScript( )
   {
      string relativePath = "Assets\\" + m_FullPath.Substring( UnityEngine.Application.dataPath.Length + 1 );
      String fileName = System.IO.Path.GetFileNameWithoutExtension( relativePath );

      relativePath = System.IO.Path.GetDirectoryName( relativePath );
      relativePath = relativePath.Replace( '\\', '/' );

      string logicPath = relativePath + "/" + fileName + uScriptConfig.Files.GeneratedCodeExtension + ".cs";
      string wrapperPath = relativePath + "/" + fileName + uScriptConfig.Files.GeneratedComponentExtension + ".cs";

      uScriptDebug.Log( "refreshing " + logicPath );
      uScriptDebug.Log( "refreshing " + wrapperPath );

      AssetDatabase.ImportAsset( logicPath, ImportAssetOptions.ForceUpdate );
      AssetDatabase.ImportAsset( wrapperPath, ImportAssetOptions.ForceUpdate );
      AssetDatabase.Refresh( );
   }


   void DrawGUIContent()
   {
      Rect rect = EditorGUILayout.BeginVertical();
      {
         // Toolbar
         //
         Rect toolbarRect = EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);

         if (toolbarRect.width != 0 && toolbarRect.height != 0)
         {
            m_NodeToolbarRect = toolbarRect;
         }


         {
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonNew, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               if (AllowNewFile(true))
               {
                  NewScript();
               }
            }

            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonOpen, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               string path = EditorUtility.OpenFilePanel( "Open uScript", Preferences.UserScripts, "uscript" );
               if ( path.Length > 0 )
               {
                  OpenScript( path );
               }
            }

//            _openScriptToggle = GUILayout.Toggle(_openScriptToggle, "Open Active uScripts...", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false));

            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonSave, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  bool saved = SaveScript( false );
               AssetDatabase.StopAssetEditing( );
            
               if (saved) RefreshScript( );
            }
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonSaveAs, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  bool saved = SaveScript( true );
               AssetDatabase.StopAssetEditing( );

               if (saved) RefreshScript( );
            }
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonRebuildAll, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               RebuildAllScripts( );
            }
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonRemoveGenerated, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  RemoveGeneratedCode( Preferences.GeneratedScripts );
               AssetDatabase.StopAssetEditing( );
               AssetDatabase.Refresh();
            }
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonPreferences, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               m_DoPreferences = true;
            }

            GUILayout.Space(20);

            mapToggle = GUILayout.Toggle(mapToggle, "Map", EditorStyles.toolbarButton);

            if (mapToggle)
            {
               mapScale = GUILayout.HorizontalSlider(mapScale, 0.1f, 0.7f, GUILayout.Width(100));
            }

            GUILayout.FlexibleSpace();

            GUIStyle style2 = new GUIStyle(EditorStyles.boldLabel);
            style2.padding = new RectOffset(16, 4, 2, 2);
            style2.margin = new RectOffset();
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
         }
         EditorGUILayout.EndHorizontal();

         GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
         {

            if (mapToggle)
            {
               MiniMapDraw();
            }
            else
            {
               // Canvas
               //
               if ( rect.width != 0 && rect.height != 0 )
               {
                  m_NodeWindowRect = rect;
               }
   
               GUIStyle style = new GUIStyle();
               style.normal.background = uScriptConfig.canvasBackgroundTexture;
   
               GUI.SetNextControlName ("MainView" );
   
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
                  m_ScriptEditorCtrl.GuiPaint(args);
               }
               EditorGUILayout.EndScrollView();
   
               GUI.SetNextControlName ("");

            }
         }
         GUILayout.EndVertical();

         if (Event.current.type == EventType.Repaint)
         {
            _canvasRect = GUILayoutUtility.GetLastRect();
         }
      }
      EditorGUILayout.EndVertical();

      SetMouseRegion( MouseRegion.Canvas );//, 3, 1, -2, -4 );
   }

   Rect mapSize = new Rect();
   Rect mapBounds = new Rect();
   Point mapMouse = new Point();

   bool mapToggle = false;
   float mapScale = 0.5f;
   Vector2 mapScroll = Vector2.zero;


   void MiniMapClick()
   {
      if ( _canvasRect.Contains( Event.current.mousePosition ) )
      {
         _requestedCloseMap = true;

         // Enter the correct canvas position here using the current mapScale, scrollbar positions, etc.
         _requestCanvasLocation = new Point( (int)((mapMouse.X - (mapSize.x - mapBounds.x)) / mapScale),
                                             (int)((mapMouse.Y - (mapSize.y - mapBounds.y)) / mapScale)
                                           );

                     //  + mapSize.x - mapBounds.x
//         Debug.Log( "RESULT: " + _requestCanvasLocation
//                    + "\n\t ViewportCenter: " + screenBoundsCenter
//                       + "\t\t\tMousePosition: " + mapMouse
//                       + "\t\t\tDiff: " + screenClickOffsetX
//                       + " (" + screenClickOffsetX / mapScale + ")"
//
//                    + "\n\t\tMapScale: " + mapScale + ", \t\tmapScroll: " + mapScroll
//                    + "\nMapBounds: " + mapBounds + ", \t\tMapSize: " + mapSize + "\n");
      }
   }


   void MiniMapDraw()
   {
      Node node;
      DisplayNode displayNode;


      //
      // Get the dimensions of the entire map at the specified scale
      //
      mapBounds = new Rect();
      
      // Start with the first ...
      if (m_ScriptEditorCtrl.FlowChart.Nodes.Length > 0)
      {
         node = m_ScriptEditorCtrl.FlowChart.Nodes[0];
         mapBounds = new Rect(node.Bounds.X, node.Bounds.Y, node.Bounds.Width, node.Bounds.Height);
      }
      
      // ... then loop through the remaining nodes ...
      for (int i=1; i < m_ScriptEditorCtrl.FlowChart.Nodes.Length; i++)
      {
         mapBounds.x = Math.Min(mapBounds.x, m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.X);
         mapBounds.y = Math.Min(mapBounds.y, m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.Y);
         mapBounds.width = Math.Max(mapBounds.width, m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.X
                                               + m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.Width);
         mapBounds.height = Math.Max(mapBounds.height, m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.Y
                                                 + m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.Height);
      }
      
      // ... and finally, apply the scaling
      mapBounds.x *= mapScale;
      mapBounds.y *= mapScale;
      mapBounds.width *= mapScale;
      mapBounds.height *= mapScale;
      
      
      //
      // Set the size of the viewRect
      //
      Rect viewRect = new Rect();
      viewRect.width = (mapBounds.width - mapBounds.x);
      viewRect.height = (mapBounds.height - mapBounds.y);
      
      
      Rect mapRect = new Rect();

      if (_mouseRegionRect.ContainsKey(MouseRegion.HandleCanvas))
      {
         mapRect.x = _guiPanelPalette_Width + 3;
         mapRect.y = 17;
         mapRect.width = position.width - (_guiPanelPalette_Width + 3);
         mapRect.height = position.height - 18 - 2 - 17 - _guiPanelProperties_Height - 8;
      }

//      Debug.Log("_canvasRect: " + _canvasRect + "\t\tposition: " + position + "\n"
//                + "PaletteWidth: " + _guiPanelPalette_Width + ", PropertiesHeight: " + _guiPanelProperties_Height + ", StatusbarRect: " + _statusbarRect + ", mapRect: " + mapRect);

      GUI.skin.scrollView.normal.background = uScriptConfig.canvasBackgroundTexture;
      mapScroll = GUI.BeginScrollView(mapRect, mapScroll, viewRect, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar);


      // Get the local mouse coordinates
      mapMouse = new Point((int)Event.current.mousePosition.x, (int)Event.current.mousePosition.y);


      // Temporary box that represents the bounding area
      mapSize = new Rect(0, 0, Math.Abs(mapBounds.width - mapBounds.x), Math.Abs(mapBounds.height - mapBounds.y));
      mapSize.x = (mapSize.width < mapRect.width ? (mapRect.width - mapSize.width) * 0.5f : 0);
      mapSize.y = (mapSize.height < mapRect.height ? (mapRect.height - mapSize.height) * 0.5f : 0);
      GUIStyle tmpStyle = new GUIStyle(GUI.skin.box);
      tmpStyle.margin = new RectOffset();
      //GUI.Box(mapSize, string.Empty, tmpStyle);

//      Debug.Log("CanvasRect: " + mapRect + ", \tMapBounds: " + mapBounds + ",\tScale: " + mapScale + "\nViewRect: " + viewRect + ", \t\t\t\tViewOffset: " + viewOffset
//                + "\t\tmapSize: " + mapSize);


      // Draw the canvas viewport rect
      Rect viewportRect = new Rect(-m_ScriptEditorCtrl.FlowChart.Location.X * mapScale + mapSize.x - mapBounds.x,
                                   -m_ScriptEditorCtrl.FlowChart.Location.Y * mapScale + mapSize.y - mapBounds.y,
                                   mapRect.width * mapScale,
                                   mapRect.height * mapScale);

      // Change the GUI color to tint the viewportRect
      UnityEngine.Color normalColor = GUI.color;
      GUI.color = UnityEngine.Color.green;
      tmpStyle.normal.background = uScriptConfig.minimapScreenBorder;
      GUI.Box(viewportRect, string.Empty, tmpStyle);
      GUI.color = normalColor;

      //
      // Paint the nodes
      //
      foreach (Node n in m_ScriptEditorCtrl.FlowChart.Nodes)
      {
         displayNode = n as DisplayNode;

         Rect nodeRect = new Rect(n.Bounds.X * mapScale + mapSize.x - mapBounds.x,
                                  n.Bounds.Y * mapScale + mapSize.y - mapBounds.y,
                                  n.Bounds.Width * mapScale,
                                  n.Bounds.Height * mapScale );

//         Debug.Log("\tNode -- Location: " + n.Location + ", \tRect: " + nodeRect + ", \t\t" + n.Name + "\n");


         

         // Style the node by type
         GUIStyle tmpNodeStyle = new GUIStyle(GUI.skin.box);
         UnityEngine.Color nodeTextGrey = new UnityEngine.Color(0.737f, 0.737f, 0.737f);
         if (displayNode is EntityEventDisplayNode)
         {
            tmpNodeStyle.normal.background = uScriptConfig.nodeEventTexture;
            tmpNodeStyle.normal.textColor = nodeTextGrey;
            GUI.Box(nodeRect, n.Name, tmpNodeStyle);
         }
         else if (displayNode is LogicNodeDisplayNode)
         {
            tmpNodeStyle.normal.background = uScriptConfig.nodeDefaultTexture;
            tmpNodeStyle.normal.textColor = nodeTextGrey;
            GUI.Box(nodeRect, n.Name, tmpNodeStyle);
         }
         else if (displayNode is LocalNodeDisplayNode)
         {
            tmpNodeStyle.normal.background = uScriptConfig.nodeVariableTexture;
            tmpNodeStyle.normal.textColor = nodeTextGrey;
            GUI.Box(nodeRect, n.Name, tmpNodeStyle);
         }
         else if (displayNode is CommentDisplayNode)
         {
            //tmpNodeStyle.normal.background = uScriptConfig.nodeDefaultTexture;
            GUI.color = UnityEngine.Color.cyan;
            GUI.Box(nodeRect, n.Name, tmpNodeStyle);
            GUI.color = normalColor;
         }
         else
         {
            tmpNodeStyle.normal.background = uScriptConfig.nodeDefaultTexture;
            GUI.Box(nodeRect, n.Name, tmpNodeStyle);
         }

      }
   

      foreach (Link l in m_ScriptEditorCtrl.FlowChart.Links)
      {
         Handles.color = UnityEngine.Color.black;

         Vector3 start = new Vector3(mapSize.x - mapBounds.x + (l.Source.Node.Location.X + l.Source.Node.Size.Width) * mapScale,
                                     mapSize.y - mapBounds.y + (l.Source.Node.Location.Y + l.Source.Anchor.Y) * mapScale,
                                     0);
         Vector3 end = new Vector3(mapSize.x - mapBounds.x + (l.Destination.Node.Location.X) * mapScale,
                                   mapSize.y - mapBounds.y + (l.Destination.Node.Location.Y + l.Destination.Anchor.Y) * mapScale,
                                   0);

         Handles.DrawLine(start, end);
      }

      GUI.EndScrollView();
      GUI.skin.scrollView.normal.background = null;
   }










	// TEMP Variables for testing the new property grid methods
   Rect _svRect;

   KeyCode[] _arrayKeyCode;
   bool _arrayFoldoutBool;

   private int _paletteMode = 0;
   bool _wasMoving = false;

Vector2 _scrollNewProperties;
   // END TEMP Variables




   void DrawGUIPropertyGrid()
   {
      EditorGUILayout.BeginVertical( uScriptGUIStyle.panelBox, GUILayout.Width( _guiPanelProperties_Width ) );
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal( EditorStyles.toolbar );
         {
            GUILayout.Label("Properties", uScriptGUIStyle.panelTitle);
//            GUILayout.FlexibleSpace();
         }
         EditorGUILayout.EndHorizontal();

         if (m_CanvasDragging && Preferences.DrawPanelsOnUpdate == false)
         {
            _wasMoving = true;

            // Hide the panels while the canvas is moving
            string message =
               "The Properties panel is not drawn while the canvas is updated.\n\nThe drawing can be enabled via the Preferences panel, although canvas performance may be affected.";

            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.wordWrap = true;
            style.padding = new RectOffset(16, 16, 16, 16);

            GUILayout.Label(message, style, GUILayout.ExpandHeight(true));
         }
         else
         {
            _guiPanelProperties_ScrollPos = EditorGUILayout.BeginScrollView(_guiPanelProperties_ScrollPos, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar);
            {
               uScriptGUI.BeginColumns("Property", "Value", "Type", _guiPanelProperties_ScrollPos, _svRect);
               {
                  m_ScriptEditorCtrl.PropertyGrid.OnPaint();
               }
               uScriptGUI.EndColumns();
            }
            EditorGUILayout.EndScrollView();

            if (Event.current.type == EventType.Repaint)
            {
               _svRect = GUILayoutUtility.GetLastRect();
            }
         }
      }
      EditorGUILayout.EndVertical();

      SetMouseRegion( MouseRegion.Properties );//, 1, 3, -4, -3 );
   }


   void DrawGUIHelp()
   {
      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox);
      {
         string helpDescription     = "Select a node on the canvas to view usage and behavior information.";
         string helpButtonTooltip   = "Open the online uScript reference in the default web browser.";
         string helpButtonURL       = "http://www.uscript.net/wiki/";

         if (m_ScriptEditorCtrl.SelectedNodes.Length == 1)
         {
            if (m_ScriptEditorCtrl.SelectedNodes[0] != null)
            {
               string nodeType = ScriptEditor.FindNodeType(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode);
               if (string.IsNullOrEmpty(nodeType))
               {
                  // other node types...
                  if (m_ScriptEditorCtrl.SelectedNodes[0].EntityNode is CommentNode)
                  {
                     nodeType = "CommentNode";
                  }
                  else if (m_ScriptEditorCtrl.SelectedNodes[0].EntityNode is ExternalConnection)
                  {
                     nodeType = "ExternalConnection";
                  }
                  else if (m_ScriptEditorCtrl.SelectedNodes[0].EntityNode is OwnerConnection)
                  {
                     nodeType = "OwnerConnection";
                  }
                  else if (m_ScriptEditorCtrl.SelectedNodes[0].EntityNode is LocalNode)
                  {
                     nodeType = "LocalNode";
                  }
               }
               helpButtonURL = FindNodeHelp(nodeType, m_ScriptEditorCtrl.SelectedNodes[0]);
               helpDescription = FindNodeDescription(nodeType, m_ScriptEditorCtrl.SelectedNodes[0]);
               helpButtonTooltip = "Open the online reference for the selected node in the default web browser.";
            }
         }
         else if (m_ScriptEditorCtrl.SelectedNodes.Length > 1)
         {
            helpDescription = "Help cannot be provided when multiple nodes are selected.";
         }

         helpButtonTooltip += " (" + helpButtonURL + ")";

         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label("Reference", uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();

            if (helpButtonURL == string.Empty)
            {
               GUI.enabled = false;
            }

            uScriptGUIContent.ChangeTooltip(uScriptGUIContent.ContentID.OnlineReference, helpButtonTooltip);
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonOnlineReference, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               Help.BrowseURL(helpButtonURL);
            }

            GUI.enabled = true;
         }
         EditorGUILayout.EndHorizontal();

         _guiHelpScrollPos = EditorGUILayout.BeginScrollView(_guiHelpScrollPos, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
         {
            // prevent the help TextArea from getting focus
            GUI.SetNextControlName("helpTextArea");
            GUILayout.TextArea(helpDescription, uScriptGUIStyle.referenceText);
            if (GUI.GetNameOfFocusedControl() == "helpTextArea")
            {
               GUIUtility.keyboardControl = 0;
            }
         }
         EditorGUILayout.EndScrollView ();
      }
      EditorGUILayout.EndVertical();

      SetMouseRegion( MouseRegion.Reference );//, 3, 3, -6, -3 );
   }


   void DrawGUINestedScripts()
   {
      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, GUILayout.Width(_guiPanelSequence_Width));
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            string currentUScript = "";
            if (m_ScriptEditorCtrl != null)
            {
               if (string.IsNullOrEmpty(m_ScriptEditorCtrl.ScriptName))
               {
                  currentUScript = " (New)";
               }
               else
               {
                  currentUScript = " (" + System.IO.Path.GetFileNameWithoutExtension(m_ScriptEditorCtrl.ScriptName) + ")";
               }
            }

            GUILayout.Label("uScripts" + currentUScript, uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));
         }
         EditorGUILayout.EndHorizontal();

         if (m_CanvasDragging && Preferences.DrawPanelsOnUpdate == false)
         {
            _wasMoving = true;

            // Hide the panels while the canvas is moving
            string message =
               "The uScripts panel is not drawn while the canvas is updated.\n\nThe drawing can be enabled via the Preferences panel, although canvas performance may be affected.";

            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.wordWrap = true;
            style.padding = new RectOffset(16, 16, 16, 16);

            GUILayout.Label(message, style, GUILayout.ExpandHeight(true));
         }
         else
         {
            _guiPanelSequence_ScrollPos = EditorGUILayout.BeginScrollView(_guiPanelSequence_ScrollPos, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
            {
//               GUILayout.Label("Canvas Location: \t\t\t" + m_ScriptEditorCtrl.FlowChart.Location);
//
//               Point center = m_ScriptEditorCtrl.FlowChart.Location;
//               center.X = -center.X + (int)(uScript.Instance.NodeWindowRect.width * 0.5f);
//               center.Y = -center.Y + (int)((uScript.Instance.NodeWindowRect.height - uScript.Instance.NodeToolbarRect.height) * 0.5f);
//
//               GUILayout.Label("Canvas Center Point: \t" + center);
//               GUILayout.Label("Mouse Screen Position: \t" + mapMouse);
//
//               Repaint();

               List<string> keylist = new List<string>();
               keylist.AddRange(uScriptBackgroundProcess.s_uScriptInfo.Keys);
               string[] keys = keylist.ToArray();
               foreach (string fileName in keys)
               {
                  string scriptName = System.IO.Path.GetFileNameWithoutExtension(fileName);
                  string scriptFile = System.IO.Path.GetFileName(fileName).Replace(".cs", ".uscript");

                  GUIStyle scriptStyle = new GUIStyle(EditorStyles.label);
                  bool currentScript = (scriptName == System.IO.Path.GetFileNameWithoutExtension(m_ScriptEditorCtrl.ScriptName));
                  bool attached = false;
                  bool dirty = false;

                  GUILayout.BeginHorizontal();
                  {
                     // uScript Label
                     string sceneName = "None";
                     if (!string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[scriptFile].m_SceneName))
                     {
                        sceneName = uScriptBackgroundProcess.s_uScriptInfo[scriptFile].m_SceneName;
                     }
                     if (currentScript)
                     {
                        scriptStyle.fontStyle = FontStyle.Bold;
                        attached = sceneName == System.IO.Path.GetFileNameWithoutExtension(UnityEditor.EditorApplication.currentScene);
                        if (!attached)
                        {
                           scriptStyle.normal.textColor = UnityEngine.Color.red;
                        }
                        dirty = m_ScriptEditorCtrl.IsDirty;
                     }
                     if (sceneName == "None")
                     {
                        GUILayout.Label(scriptName + (dirty ? "*" : ""), scriptStyle);
                     }
                     else
                     {
                        GUILayout.Label(scriptName + " (" + sceneName + ")" + (dirty ? "*" : ""), scriptStyle);
                     }

                     GUILayout.FlexibleSpace();

                     // Load or Reload
                     GUIContent content = new GUIContent((currentScript ? "Reload" : "Load"), "Click to load this uScript.");
                     if (GUILayout.Button(content, (currentScript ? EditorStyles.miniButton : EditorStyles.miniButtonLeft)))
                     {
                        string path = FindFile(Preferences.UserScripts, scriptName + ".uscript");

                        if ("" != path)
                        {
                           _openScriptToggle = false;
                           OpenScript(path);
                        }
                     }

                     // Insert as Nested uScript
                     if (currentScript == false)
                     {
                        content = new GUIContent("Insert", "Click to add an instance of this uScript.");
                        if (GUILayout.Button(content, EditorStyles.miniButtonRight))
                        {
                           if (m_ScriptEditorCtrl != null)
                           {
                              float canvasX = _mouseRegionRect[MouseRegion.Canvas].x;
                              float canvasY = _mouseRegionRect[MouseRegion.Canvas].y;
                              m_ScriptEditorCtrl.ContextCursor = new Point((int)(canvasX - _guiPanelPalette_Width + uScript.Instance.NodeWindowRect.width / 2.0f), (int)(canvasY + uScript.Instance.NodeWindowRect.height / 2.0f));
                              m_ScriptEditorCtrl.AddVariableNode(m_ScriptEditorCtrl.GetLogicNode(scriptName));
                           }
                        }
                     }
                  }
                  GUILayout.EndHorizontal();

                  if (currentScript && !attached)
                  {
                     GUIStyle errorStyle = new GUIStyle(GUI.skin.label);
                     errorStyle.normal.textColor = UnityEngine.Color.red;
                     errorStyle.wordWrap = true;
                     GUILayout.Label("The Unity Scene this uScript uses is not loaded in Unity or it has not been saved yet. Work may be lost if you save!", errorStyle);
                  }
               }
            }
            EditorGUILayout.EndScrollView();
         }
      }
      EditorGUILayout.EndVertical();

      SetMouseRegion(MouseRegion.NestedScripts );//, 3, 3, -2, -3);
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
            GUILayout.TextArea(_EULAtext, uScriptGUIStyle.referenceText);
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
            uScript.SetSetting( "EULA\\AgreedVersion", EULAVersion );
            _EULAagreed = EULAVersion;
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


   Rect _windowRectPreferences;

   public void DrawPreferences( )
   {
      _windowRectPreferences.x = (position.width - _windowRectPreferences.width) / 2;
      _windowRectPreferences.y = Math.Max(0, (position.height - _windowRectPreferences.height) / 2);

      GUIStyle style3 = new GUIStyle(GUI.skin.window);
      style3.padding = new RectOffset(16, 18, 19, 16);

      _windowRectPreferences = GUILayout.Window(10001, _windowRectPreferences, DoPreferences, "Preferences", style3);

//         _windowRectPreferences.width = 250;
//      if (_windowRectPreferences == new Rect())
//      {
//         _windowRectPreferences.width = 550;
//         int w = 550;
//         int h = Math.Max(400, (int)position.height - 400);
//         Rect r = new Rect((position.width-w)/2, (position.height-h)/2, w, h);
//      }


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
  
      UnityEngine.Object []objects = GameObject.FindObjectsOfType(typeof(uScriptCode));
      foreach ( UnityEngine.Object o in objects )
      {
         uScriptCode code = o as uScriptCode;

         if (GUILayout.Button(code.GetType().ToString(), EditorStyles.label))
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

   void DoPreferences(int windowID)
   {
      EditorGUIUtility.LookLikeControls(180, 50);
      EditorGUI.indentLevel = 1;

      EditorGUILayout.Separator();

      //
      // Project Settings
      //
      GUILayout.Label("Project File Location", EditorStyles.boldLabel);

      string path = uScriptConfig.ConstantPaths.RelativePath(Preferences.UserScripts);
      if ( path.Length > 64 ) path = path.Substring( 0, 64 ) + "...";

      if (GUILayout.Button( path, uScriptGUIStyle.ContextMenu))
      {
         path = EditorUtility.OpenFolderPanel( "uScript Project Files", Preferences.UserScripts, "" );
         if ( "" != path ) Preferences.UserScripts = path;
      }

      EditorGUILayout.Separator( );

      //
      // Code Generation Settings
      //
      GUILayout.Label( "CodeGeneration", EditorStyles.boldLabel );

      Preferences.MaximumNodeRecursionCount = (int) EditorGUILayout.IntField( "Maximum Node Recursion", Preferences.MaximumNodeRecursionCount);

      EditorGUILayout.Separator( );

      //
      // Panel Settings
      //
      GUILayout.Label( "Panel Settings", EditorStyles.boldLabel );

      Preferences.DrawPanelsOnUpdate   = EditorGUILayout.Toggle("Draw Panels During Update", Preferences.DrawPanelsOnUpdate);
      Preferences.ToolbarButtonStyle   = (int)(uScriptGUIContent.ContentStyle)EditorGUILayout.EnumPopup( "Toolbar Button Style", (uScriptGUIContent.ContentStyle)Preferences.ToolbarButtonStyle);

      EditorGUILayout.Separator( );

      //
      // Grid Settings
      //
      GUILayout.Label( "Grid Settings", EditorStyles.boldLabel );

      //background grid size
      int minGridSize = 8;
      int maxGridSize = 100;
      int minGridMajorSpacing = 1;
      int maxGridMagicSpacing = 10;

      Preferences.ShowGrid             = EditorGUILayout.Toggle    ( "Show Grid", Preferences.ShowGrid );
      Preferences.GridSizeVertical     = Math.Min(maxGridSize, Math.Max(minGridSize, EditorGUILayout.FloatField( "Grid Size Vertical", Preferences.GridSizeVertical) ) );
      Preferences.GridSizeHorizontal   = Math.Min(maxGridSize, Math.Max(minGridSize, EditorGUILayout.FloatField( "Grid Size Horizontal", Preferences.GridSizeHorizontal) ) );
      Preferences.GridMajorLineSpacing = Math.Min(maxGridMagicSpacing, Math.Max(minGridMajorSpacing, EditorGUILayout.IntField  ( "Grid Major Line Spacing", Preferences.GridMajorLineSpacing) ) );
      Preferences.GridColorMajor       = EditorGUILayout.ColorField( "Grid Color Major", Preferences.GridColorMajor );
      Preferences.GridColorMinor       = EditorGUILayout.ColorField( "Grid Color Minor", Preferences.GridColorMinor );

      EditorGUILayout.Separator( );
      EditorGUILayout.Space();
      EditorGUILayout.Separator( );

      
      //revert to default
      if (GUILayout.Button("Revert All Settings to Default Values"))
      {
         Preferences.Revert();
      }

      EditorGUILayout.Separator( );


      //save or cancel
      EditorGUILayout.BeginHorizontal();
      {
         GUIStyle btnStyle = new GUIStyle(GUI.skin.button);
         btnStyle.margin = new RectOffset(0, 0, 3, 3);
         btnStyle.fixedWidth = 120;

         if (GUILayout.Button("Save", btnStyle))
         {
            Preferences.Save( );
            uScriptGUIContent.Style = (uScriptGUIContent.ContentStyle)Preferences.ToolbarButtonStyle;

            m_DoPreferences = false;
         }

         GUILayout.Space(16);

         if (GUILayout.Button("Cancel", btnStyle))
         {
            //cancel was pressed so revert to saved version
            Preferences.Load( );
            uScriptGUIContent.Style = (uScriptGUIContent.ContentStyle)Preferences.ToolbarButtonStyle;

            m_DoPreferences = false;
         }
      }
      EditorGUILayout.EndHorizontal();

      EditorGUI.indentLevel = 0;
   }

   void DoContextMenu(int windowID)
   {
      if ( null == m_CurrentMenu )
      {
         foreach ( ToolStripItem item in m_ScriptEditorCtrl.ContextMenu.Items.Items )
         {
            if ( item.Text == "<hr>" )
            {
               GUILayout.Button( "", uScriptGUIStyle.hDivider );
            }
            else
            {
               if (GUILayout.Button(item.Text.Replace("&", ""), uScriptGUIStyle.ContextMenu))
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

   private string[] FindAllFiles( string rootPath, string extension )
   {
      List<string> paths = new List<string>( );

      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( rootPath );

      System.IO.FileInfo [] files = directory.GetFiles( );

      foreach ( System.IO.FileInfo file in files )
      {
         if ( file.Extension == extension )
         {
            paths.Add( file.FullName );
         }
      }

      foreach ( System.IO.DirectoryInfo subDirectory in directory.GetDirectories( ) )
      {
         string []results = FindAllFiles( subDirectory.FullName, extension );
         paths.AddRange( results );
      }

      return paths.ToArray( );
   }

   private void DrawSubItems( ToolStripMenuItem menuItem )
   {
      if ( null == menuItem ) return;

      foreach ( ToolStripItem item in menuItem.DropDownItems.Items )
      {
         if ( GUILayout.Button( item.Text.Replace("&", ""), uScriptGUIStyle.ContextMenu ) )
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
      if (!m_HidePanelMode) m_MouseMoveArgs.X -= _guiPanelPalette_Width;
      m_MouseMoveArgs.Y -= (int)_canvasRect.yMin;
      
      System.Windows.Forms.Cursor.Position.X = m_MouseMoveArgs.X;
      System.Windows.Forms.Cursor.Position.Y = m_MouseMoveArgs.Y;

      if (_mouseRegion == MouseRegion.Canvas)
      {
         m_ScriptEditorCtrl.OnMouseMove( m_MouseMoveArgs );
      }

      // convert back to screen
      if (!m_HidePanelMode) m_MouseMoveArgs.X += _guiPanelPalette_Width;
      m_MouseMoveArgs.Y += (int)_canvasRect.yMin;
      
      if (GUI.enabled && !m_HidePanelMode)
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
      if (!String.IsNullOrEmpty(m_FullPath))
      {
         SetSetting("uScript\\" + uScriptConfig.ConstantPaths.RelativePath(m_FullPath) + "\\CanvasPosition", m_CurrentCanvasPosition);
      }
      
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
            result = EditorUtility.DisplayDialogComplex( "Save File?", m_ScriptEditorCtrl.ScriptEditor.Name + " has been modified, would you like to save?", "Yes", "No", "Cancel" );
         }
         else
         {
            bool yes = EditorUtility.DisplayDialog( "Save File?", m_ScriptEditorCtrl.ScriptEditor.Name + " has been modified, would you like to save?", "Yes", "No" );
            
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
      Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor( "", PopulateEntityTypes(null), PopulateLogicTypes( ) );

      m_ScriptEditorCtrl = new ScriptEditorCtrl( scriptEditor );
      m_ScriptEditorCtrl.ScriptModified += new ScriptEditorCtrl.ScriptModifiedEventHandler(m_ScriptEditorCtrl_ScriptModified);
      
      m_ScriptEditorCtrl.BuildContextMenu();
      BuildPaletteMenu(null, null);
      
      m_FullPath = "";
      
      uScript.SetSetting("uScript\\LastOpened", "");
   }

   public bool OpenScript(string fullPath)
   { 
      if ( false == AllowNewFile(true) || !System.IO.File.Exists(fullPath) ) return false;

      Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor( "", null, null );
      scriptEditor.Open(fullPath);

      scriptEditor = new Detox.ScriptEditor.ScriptEditor( "", PopulateEntityTypes(scriptEditor.Types), PopulateLogicTypes( ) );

      if ( true == scriptEditor.Open(fullPath) )
      {
         if ( "" != scriptEditor.SceneName && scriptEditor.SceneName != System.IO.Path.GetFileNameWithoutExtension(UnityEditor.EditorApplication.currentScene) )
         {
            EditorUtility.DisplayDialog("uScript Scene Warning", "This uScript file was attached to the uScript Master GameObject in scene " + scriptEditor.SceneName + ".  " +
                                        "It may not be compatible with this scene or run correctly if edited while this scene is open.", "OK");
         }


         UnityEditor.Undo.ClearUndo( MasterComponent );
         
         //force a change which will for a script rebuild in Update
         //this keeps all the loading in the same place
         MasterComponent.Script = scriptEditor.ToBase64( );
         MasterComponent.ScriptName = scriptEditor.Name;
       
         CurrentScript = null;
         CurrentScriptName = null;

         if (fullPath != m_FullPath) m_CurrentCanvasPosition = "";

         m_FullPath = fullPath;

         uScript.SetSetting("uScript\\LastOpened", uScriptConfig.ConstantPaths.RelativePath(fullPath).Substring("Assets".Length));
      }
      else
      {
         uScriptDebug.Log( "An error occured opening " + fullPath, uScriptDebug.Type.Error );
         return false;
      }
      
      return true;
   }

   public void RemoveGeneratedCode( string path )
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( path );

      System.IO.FileInfo [] files = directory.GetFiles( );

      foreach ( System.IO.FileInfo file in files )
      {
         string relativePath = uScriptConfig.ConstantPaths.RelativePath(file.FullName);
         AssetDatabase.DeleteAsset( relativePath );
      }

      foreach ( System.IO.DirectoryInfo subDirectory in directory.GetDirectories( ) )
      {
         RemoveGeneratedCode( subDirectory.FullName );
      }
   }

   public void RebuildAllScripts( )
   {
      //first remove everything so we get rid of any compiler errors
      //which allows the reflection to properly refresh
      AssetDatabase.StartAssetEditing( );
         RemoveGeneratedCode( Preferences.GeneratedScripts );
      AssetDatabase.StopAssetEditing( );
      AssetDatabase.Refresh();

      m_RebuildWhenReady = true;
      }

   public void RebuildScripts( string path )
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( path );

      System.IO.FileInfo [] files = directory.GetFiles( );

      foreach ( System.IO.FileInfo file in files )
      {
         if ( ".uscript" != file.Extension ) continue;

         Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor( "", null, null );
         scriptEditor.Open(file.FullName);

         scriptEditor = new Detox.ScriptEditor.ScriptEditor( "", PopulateEntityTypes(scriptEditor.Types), PopulateLogicTypes( ) );

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
      System.IO.Directory.CreateDirectory( Preferences.GeneratedScripts );
      System.IO.Directory.CreateDirectory( Preferences.NestedScripts );

      string wrapperPath = Preferences.GeneratedScripts;
      string logicPath   = Preferences.NestedScripts;

      String fileName = System.IO.Path.GetFileNameWithoutExtension( binaryPath );

      logicPath   += "/" + fileName + uScriptConfig.Files.GeneratedCodeExtension + ".cs";
      wrapperPath += "/" + fileName + uScriptConfig.Files.GeneratedComponentExtension + ".cs";

      bool result = script.Save( binaryPath, logicPath, wrapperPath );
   
      if ( true == result )
      {         
         //we're attempting to just attach components at runtime
         //but i'm leaving this function here just in case we want
         //to call it to help performance by auto attaching the scripts before they run
         //AttachEventScriptsToOwners(script);
         
         // refresh uScript panel file list
         uScriptBackgroundProcess.ForceFileRefresh();
      }

      return result;
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
            path = EditorUtility.SaveFilePanel( "Save uScript As", Preferences.UserScripts, script.Name, "uscript" );
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
         uScript.SetSetting("uScript\\LastOpened", uScriptConfig.ConstantPaths.RelativePath(m_FullPath).Substring("Assets".Length));
      }

      if ( "" != m_FullPath )
      {
         bool firstSave = false;
         if (!System.IO.File.Exists(m_FullPath))
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
         if ( true == pleaseAttachMe || true == currentlyAttached )
         {
            script.SceneName = System.IO.Path.GetFileNameWithoutExtension(UnityEditor.EditorApplication.currentScene);
         }

         if ( true == SaveScript(script, m_FullPath) )
         {
            m_ScriptEditorCtrl.IsDirty = false;

            //force a sync here just in case somehwere in code
            //we missed a call to the change stack
            MasterComponent.Script = script.ToBase64( );
            MasterComponent.ScriptName = script.Name;

            CurrentScript = MasterComponent.Script;
            CurrentScriptName = MasterComponent.ScriptName;

            if (true == pleaseAttachMe)
            {
               AssetDatabase.Refresh( );            
               AttachToMasterGO(m_FullPath);
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

   void AttachEventScriptsToOwners(ScriptEditor script)
   {
      foreach ( EntityEvent entityEvent in script.Events )
      {
         LinkNode []links = script.GetLinksByDestination(entityEvent.Guid, entityEvent.Instance.Name);

         if ( "" != entityEvent.Instance.Default )
         {
            AttachEventScriptToGameObject( GameObject.Find(entityEvent.Instance.Default), entityEvent.ComponentType);
         }

         foreach ( LinkNode link in links )
         {
            EntityNode node = script.GetNode(link.Source.Guid);
            
            //for each owner connected to an event instance
            //add the required event component script
            if ( node is OwnerConnection )
            {
               AttachEventScriptToGameObjects(script.Name, entityEvent.ComponentType);
            }
            else if ( node is LocalNode )
            {
               //for each gameobject used as an event instance
               //add the required event component script
               AttachEventScriptToGameObject( GameObject.Find(((LocalNode)node).Value.Default), entityEvent.ComponentType);
            }
         }
      }
   }

   //go through all game objects and if they have the uscript attached to them
   //then also attach the event component script
   void AttachEventScriptToGameObjects(string scriptWhichMustExist, string componentTypeToAttach)
   {
      UnityEngine.Object []objects = FindObjectsOfType(typeof(GameObject));
   
      foreach ( UnityEngine.Object o in objects )
      {
         GameObject gameObject = o as GameObject;

         if ( null != gameObject.GetComponent(scriptWhichMustExist) )
         {
            AttachEventScriptToGameObject( o as GameObject, componentTypeToAttach );
         }
      }
   }

   //attach the event component script if it's not already on the game object
   void AttachEventScriptToGameObject(GameObject gameObject, string componentTypeToAttach)
   {
      if ( null == gameObject ) return;

      if ( null == gameObject.GetComponent(componentTypeToAttach) )
      {
         gameObject.AddComponent(componentTypeToAttach);
      }

      //print out a warning if the newly attached script still won't function
      //because some other required component is missing
      NodeComponentType requiredComponentType = FindNodeComponentType(MasterComponent.GetType(componentTypeToAttach));
      
      bool componentWarning = true;

      if ( null != requiredComponentType ) 
      {
         //go through all the components and see if the required one exists
         Component [] components = gameObject.GetComponents<Component>( );

         foreach ( Component c in components )
         {
            //yes for some reason unity is giving me null components
            if ( null == c ) continue;

            if ( requiredComponentType.ContainsType(c.GetType()) )
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

      if ( true == componentWarning )
      {
         string names = "";

         foreach ( Type t in requiredComponentType.ComponentTypes )
         {
            names += t + ", ";
         }

         if ( names.Length >= 2 ) names = names.Substring( 0, names.Length - 2 );

         Debug.LogWarning( componentTypeToAttach + " was attached to " + gameObject.name + 
                           " but one of the following additional components is required for it to function properly " + names ); 
      }
   }

   void AttachToMasterGO(String path)
   {
#if UNITY_EDITOR
      MasterComponent.AttachScriptToMaster(path);
#endif
   }

   void GatherDerivedTypes( Dictionary<Type, Type> uniqueNodes, string path, Type baseType )
   {
      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( path );

      System.IO.FileInfo [] files = directory.GetFiles( );

      foreach ( System.IO.FileInfo file in files )
      {
         if ( file.Name.StartsWith(".") || file.Name.StartsWith("_")  || !file.Name.EndsWith(".cs") ) continue;

         Type type = uScript.MasterComponent.GetAssemblyQualifiedType( System.IO.Path.GetFileNameWithoutExtension(file.Name) );

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

      GatherDerivedTypes( uniqueNodes, uScriptConfig.ConstantPaths.uScriptNodes, typeof(uScriptLogic) );

      GatherDerivedTypes( uniqueNodes, Preferences.UserNodes, typeof(uScriptLogic) );
      GatherDerivedTypes( uniqueNodes, Preferences.NestedScripts, typeof(uScriptLogic) );

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

      List<Type> types = new List<Type>( uniqueNodes.Values );
      types.Sort(TypeSorter);

      foreach ( Type type in types )
      {
         MasterComponent.AddType( type );

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

               variable.State  = FindSocketState(p.GetCustomAttributes(false));
               variable.Name   = p.Name;
               variable.Type   = p.ParameterType.ToString( ).Replace( "&", "" );
               variable.FriendlyName = FindFriendlyName( p.Name, p.GetCustomAttributes(false) );
               variable.DefaultAsObject = FindDefaultValue( "", p.GetCustomAttributes(false) );
               
               MasterComponent.AddType( p.ParameterType );

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
               parameter.State   = FindSocketState(m.GetCustomAttributes(false));
               parameter.FriendlyName = "Return Value";

               MasterComponent.AddType( m.ReturnType );
                  
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

      return OverrideNestedScriptTypes( logicNodes.ToArray( ) );
   }

   RawScript [] GatherRawScripts( )
   {
      List<RawScript> rawScripts = new List<RawScript>( );

      string []files = FindAllFiles( Preferences.UserScripts, ".uscript" );

      foreach ( string file in files )
      {
         RawScript rawScript = new RawScript( );
         if ( false == rawScript.Load(file) ) 
         {
            Detox.Utility.Status.Warning( "Could not load " + file + " to use for nested script parameters, reflection will be used instead" );
            continue;
         }

         rawScripts.Add( rawScript );

      }

      return rawScripts.ToArray( );
   }

   private LogicNode [] OverrideNestedScriptTypes( LogicNode [] logicNodes )
   {
      Dictionary<string, LogicNode> returnNodes = new Dictionary<string, LogicNode>( );

      RawScript [] rawScripts = GatherRawScripts( );

      foreach ( LogicNode logicNode in logicNodes )
      {
         returnNodes[ logicNode.Type ] = logicNode;
      }

      foreach ( RawScript rawScript in rawScripts )
      {
         LogicNode logicNode = new LogicNode( rawScript.Type, rawScript.Type );
         
         logicNode.Parameters = rawScript.ExternalParameters;
         logicNode.Inputs     = rawScript.ExternalInputs;
         logicNode.Outputs    = rawScript.ExternalOutputs;
         logicNode.Events     = rawScript.ExternalEvents;
         logicNode.Drivens    = rawScript.Drivens;

         returnNodes[ rawScript.Type ] = logicNode;
      }

      return returnNodes.Values.ToArray( );
   }

   private void Reflect(Type type, List<EntityDesc> entityDescs, Hashtable baseMethods, Hashtable baseEvents, Hashtable baseProperties )
   {
      EntityDesc entityDesc = new EntityDesc( );

      entityDesc.Type = type.ToString( );
      MasterComponent.AddType( type );

      MethodInfo   []methodInfos   = type.GetMethods( );
      EventInfo    []eventInfos    = type.GetEvents( );
      PropertyInfo []propertyInfos = type.GetProperties( );
      FieldInfo    []fieldInfos    = type.GetFields( );

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
            parameter.State     = FindSocketState(p.GetCustomAttributes(false));
            parameter.Name      = p.Name;
            parameter.Type      = p.ParameterType.ToString( ).Replace( "&", "" );
            parameter.FriendlyName = FindFriendlyName(p.Name, p.GetCustomAttributes(false));

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

            MasterComponent.AddType( p.ParameterType );
            
            parameters.Add( parameter );
         }

         if ( m.ReturnType != typeof(void) )
         {
            Parameter parameter = new Parameter( );
            parameter.State   = FindSocketState(m.GetCustomAttributes(false));
            parameter.Name    = "Return";
            parameter.Type    = m.ReturnType.ToString( ).Replace( "&", "" );
            parameter.Input   = false;
            parameter.Output  = true;         
            parameter.Default = "";
            parameter.FriendlyName = "Return Value";

            MasterComponent.AddType( m.ReturnType );
               
            parameters.Add( parameter );
         }

         entityMethod.Parameters = parameters.ToArray( );
         entityMethods.Add( entityMethod );
      }

      entityDesc.Methods = entityMethods.ToArray( );

      List<EntityEvent> entityEvents = new List<EntityEvent>( );

      bool propertiesUsedForEvents = false;
         
      foreach ( EventInfo e in eventInfos )
      {
         if ( true == baseEvents.Contains(e.Name) ) continue;

         List<Parameter> eventInputsOutpus = new List<Parameter>( );

         //look for any set properties which will exist on the event
         //because we can't set them via method parameters
         foreach ( PropertyInfo p in propertyInfos )
         {
            propertiesUsedForEvents = true;

            if ( baseProperties.Contains(p.Name) ) continue;

            if ( p.GetSetMethod( ) != null )
            {
               Parameter input = new Parameter( );
               
               //inputs to events can never be connected because there is no source to trigger
               //them and push in the value
               input.State   = Parameter.VisibleState.Locked | Parameter.VisibleState.Hidden;
               input.Name    = p.Name;
               input.Type    = p.PropertyType.ToString( ).Replace( "&", "" );
               input.Input   = true;
               input.Output  = false;
               input.DefaultAsObject = FindDefaultValue("", p.GetCustomAttributes(false));
               input.FriendlyName = FindFriendlyName(p.Name, p.GetCustomAttributes(false));
               
               MasterComponent.AddType( p.PropertyType );
            
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
                           output.State   = FindSocketState(eventProperty.GetCustomAttributes(false));;
                           output.Name    = eventProperty.Name;
                           output.FriendlyName = FindFriendlyName(eventProperty.Name, eventProperty.GetCustomAttributes(false));
                           output.Type    = eventProperty.PropertyType.ToString( ).Replace( "&", "" );
                           output.Input   = false;
                           output.Output  = true;
                           output.DefaultAsObject = FindDefaultValue( "", eventProperty.GetCustomAttributes(false) );

                           MasterComponent.AddType( eventProperty.PropertyType );

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

      if ( false == propertiesUsedForEvents )
      {
         foreach ( PropertyInfo p in propertyInfos )
         {
            if ( true == baseProperties.Contains(p.Name) ) continue;

            bool isInput = p.GetSetMethod( ) != null;
            bool isOutput= p.GetGetMethod( ) != null;

            EntityProperty property = new EntityProperty( p.Name, FindFriendlyName(p.Name, p.GetCustomAttributes(false)), type.ToString( ), p.PropertyType.ToString( ), isInput, isOutput );
            entityProperties.Add( property );

            MasterComponent.AddType( p.PropertyType );
         }
         
         foreach ( FieldInfo f in fieldInfos )
         {
            if ( false == f.IsPublic ) continue;
            if ( true  == f.IsStatic ) continue;   

            EntityProperty property = new EntityProperty( f.Name, FindFriendlyName(f.Name, f.GetCustomAttributes(false)), type.ToString( ), f.FieldType.ToString( ), true, true );
            entityProperties.Add( property );

            MasterComponent.AddType( f.FieldType );
         }
      }

      entityDesc.Properties = entityProperties.ToArray( );

      entityDescs.Add( entityDesc );
   }

   private static int TypeSorter(Type t1, Type t2)
   {
      return String.Compare( uScriptConfig.Variable.FriendlyName(t1.ToString()), uScriptConfig.Variable.FriendlyName(t2.ToString())); 
   }

   private EntityDesc[] PopulateEntityTypes( string [] requiredTypes )
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
      Dictionary<string, Type> uniqueObjects = new Dictionary<string, Type>( );

      Dictionary<Type, Type> eventNodes = new Dictionary<Type,Type>( );
      GatherDerivedTypes( eventNodes, uScriptConfig.ConstantPaths.uScriptNodes, typeof(uScriptEvent) );
      GatherDerivedTypes( eventNodes, Preferences.UserNodes, typeof(uScriptEvent) );

      foreach ( UnityEngine.Object o in allObjects )
      {
         //ignore our uscripts, they are handled separately
         if ( typeof(uScriptCode).IsAssignableFrom(o.GetType()) ) continue;
         if ( typeof(uScriptLogic).IsAssignableFrom(o.GetType()) ) continue;

         uniqueObjects[ o.GetType().ToString( ) ] = o.GetType();
      }

      foreach ( Type t in eventNodes.Values )
      {
         uniqueObjects[ t.ToString( ) ] = t;
      }

      if ( null != requiredTypes )
      {
         foreach ( string t in requiredTypes )
         {
            if ( true == uniqueObjects.ContainsKey(t) ) continue;

            Type type = uScript.MasterComponent.GetType(t);

            if ( null != type ) 
            {
               if ( typeof(UnityEngine.Object).IsAssignableFrom(type) )
               {
                  uniqueObjects[ t ] = type;
               }
            }
         }
      }

      List<Type> types = new List<Type>( uniqueObjects.Values );
      types.Sort(TypeSorter);
      
      foreach ( Type t in types )
      {
         if ( t == typeof(uScript_Assets) ) continue;
         if ( t == typeof(uScript_MasterComponent) ) continue;

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
      string type = ScriptEditor.FindNodeType(entityNode);
      if ( "" == type ) return "";

      if ( true == uScript.FindNodeAutoAssignMasterInstance(type) )
      {
         return uScriptRuntimeConfig.MasterObjectName;
      }

      return "";
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

   public static Parameter.VisibleState FindSocketState(object [] attributes)
   {
      if ( null != attributes ) 
      {
         foreach ( object a in attributes )
         {
            if ( a is SocketState ) 
            {
               SocketState s = (SocketState) a;

               Parameter.VisibleState state = Parameter.VisibleState.Visible;

               if ( false == s.Visible ) state = Parameter.VisibleState.Hidden;
               if ( true  == s.Locked ) state |= Parameter.VisibleState.Locked;

               return state;
            }
         }
      }

      return Parameter.VisibleState.Visible;;
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
      Type uscriptType = uScript.MasterComponent.GetType(type);

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
      Type uscriptType = uScript.MasterComponent.GetType(type);

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
      Type uscriptType = uScript.MasterComponent.GetType(type);

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

   public static bool IsNodeTypeDeprecated(EntityNode node)
   {
      string type = ScriptEditor.FindNodeType(node);
      if ( "" == type ) return false;

      Type uscriptType = uScript.MasterComponent.GetType(type);
      if ( null == uscriptType ) return false;

      object [] attributes = uscriptType.GetCustomAttributes(false);
      if ( null == attributes ) return false;

      foreach ( object a in attributes )
      {
         if ( a is NodeDeprecated ) 
         {
            return true;
         }
      }

      return false;
   }

   public static Type GetNodeUpgradeType(EntityNode node)
   {
      string type = ScriptEditor.FindNodeType(node);
      if ( "" == type ) return null;

      Type uscriptType = uScript.MasterComponent.GetType(type);
      if ( null == uscriptType ) return null;

      object [] attributes = uscriptType.GetCustomAttributes(false);
      if ( null == attributes ) return null;

      foreach ( object a in attributes )
      {
         if ( a is NodeDeprecated ) 
         {
            return ((NodeDeprecated)a).UpgradeType;
         }
      }

      return null;
   }

   public static string FindNodeLicense(string type)
   {
      Type uscriptType = uScript.MasterComponent.GetType(type);

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
      Type uscriptType = uScript.MasterComponent.GetType(type);

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
      Type uscriptType = uScript.MasterComponent.GetType(type);

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

   public static string FindNodeDescription(string type, DisplayNode node)
   {
      // check non-logic, non-event types first...
      // structs can't have attributes, so we have to specify this information here, explicitly
      if (type == "CommentNode")
      {
         return "Use a comment box to comment or hint at what a particular block of uScript nodes does. Comment boxes can be resized so that they surround the nodes that they are referencing.\n \nTo resize a comment box, drag the bottom-right corner of the comment box or set its size properties explicitly in the Properties panel.\n \nTitle: The title or header for this comment box.\nBody: The actual comment text and information. Empty lines are supported.\nSize: The size of the comment box in pixels (width, height).";
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
         LocalNodeDisplayNode variable = node as LocalNodeDisplayNode;
         string friendlyType = uScriptConfig.Variable.FriendlyName(variable.LocalNode.Value.Type);
         
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
      Type uscriptType = uScript.MasterComponent.GetType(type);

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
      Type uscriptType = uScript.MasterComponent.GetType(type);

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

   public static string FindNodeHelp(string type, DisplayNode node)
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
}