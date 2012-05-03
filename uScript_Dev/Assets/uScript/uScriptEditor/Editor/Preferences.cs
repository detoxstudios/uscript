using System.Collections;

// Adding this comment to test SVN commit ... another change ... 3rd change ... 4th change ... 5th change

public class Preferences
{
   public enum DoubleClickBehaviorType
   {
      PingSource,
      OpenSource,
      LoadGraphPingSource,
      LoadGraphOpenSource
   }

   public enum VariableExpansionType
   {
      AlwaysExpanded,
      AlwaysCollapsed,
      Dynamic
   }

   public enum SaveMethodType
   {
      Quick,
      Debug,
      Release
   }
   
   public string ProjectFiles 
   { 
      get { LoadIfRequired( ); return UnityEngine.Application.dataPath + (m_Preferences[ "RelativeProjectFiles" ] as string); } 
      set { LoadIfRequired( ); m_Preferences[ "RelativeProjectFiles" ] = uScriptConfig.ConstantPaths.RelativePathInAssets(value); }       
   }

   public string UserScripts
   { 
      get { LoadIfRequired( ); return UnityEngine.Application.dataPath + (m_Preferences[ "RelativeUserScripts" ] as string); } 
      set { LoadIfRequired( ); m_Preferences[ "RelativeUserScripts" ] = uScriptConfig.ConstantPaths.RelativePathInAssets(value); }       
   }

   public string UserNodes
   { 
      get { LoadIfRequired( ); return UnityEngine.Application.dataPath + (m_Preferences[ "RelativeUserNodes" ] as string); } 
      set { LoadIfRequired( ); m_Preferences[ "RelativeUserNodes" ] = uScriptConfig.ConstantPaths.RelativePathInAssets(value); }       
   }

   public string GeneratedScripts
   { 
      get { LoadIfRequired( ); return UnityEngine.Application.dataPath + (m_Preferences[ "RelativeGeneratedScripts" ] as string); } 
      set { LoadIfRequired( ); m_Preferences[ "RelativeGeneratedScripts" ] = uScriptConfig.ConstantPaths.RelativePathInAssets(value); }       
   }

   public string NestedScripts
   { 
      get { LoadIfRequired( ); return UnityEngine.Application.dataPath + (m_Preferences[ "RelativeNestedScripts" ] as string); } 
      set { LoadIfRequired( ); m_Preferences[ "RelativeNestedScripts" ] = uScriptConfig.ConstantPaths.RelativePathInAssets(value); }       
   }

   public bool DrawPanelsOnUpdate
   {
      get { LoadIfRequired( ); return (bool) m_Preferences[ "DrawPanelsOnUpdate" ]; }
      set { LoadIfRequired( ); m_Preferences[ "DrawPanelsOnUpdate" ] = value; }
   }

   public int MaximumNodeRecursionCount
   {
      get { LoadIfRequired( ); return (int) m_Preferences[ "MaximumNodeRecursionCount" ]; }
      set { LoadIfRequired( ); m_Preferences[ "MaximumNodeRecursionCount" ] = value; }
   }

   public SaveMethodType SaveMethod
   {
      get { LoadIfRequired( ); return (SaveMethodType) m_Preferences[ "SaveMethod" ]; }
      set { LoadIfRequired( ); m_Preferences[ "SaveMethod" ] = value; }
   }

   public bool ShowGrid
   {
      get { LoadIfRequired( ); return (bool) m_Preferences[ "ShowGrid" ]; } 
      set { LoadIfRequired( ); m_Preferences[ "ShowGrid" ] = value; }       
   }

   public float GridSizeVertical
   {
      get { LoadIfRequired( ); return (float) m_Preferences[ "GridSizeVertical" ]; } 
      set { LoadIfRequired( ); m_Preferences[ "GridSizeVertical" ] = value; }       
   }

   public float GridSizeHorizontal
   {
      get { LoadIfRequired( ); return (float) m_Preferences[ "GridSizeHorizontal" ]; } 
      set { LoadIfRequired( ); m_Preferences[ "GridSizeHorizontal" ] = value; }       
   }

   public int GridMajorLineSpacing
   {
      get { LoadIfRequired( ); return (int) m_Preferences[ "GridMajorLineSpacing" ]; } 
      set { LoadIfRequired( ); m_Preferences[ "GridMajorLineSpacing" ] = value; }       
   }

   public UnityEngine.Color GridColorMajor
   {
      get { LoadIfRequired( ); return (UnityEngine.Color) m_Preferences[ "GridColorMajor" ]; } 
      set { LoadIfRequired( ); m_Preferences[ "GridColorMajor" ] = value; }       
   }

   public UnityEngine.Color GridColorMinor
   {
      get { LoadIfRequired( ); return (UnityEngine.Color) m_Preferences[ "GridColorMinor" ]; } 
      set { LoadIfRequired( ); m_Preferences[ "GridColorMinor" ] = value; }       
   }

   public DoubleClickBehaviorType DoubleClickBehavior
   {
      get { LoadIfRequired( ); return (DoubleClickBehaviorType) m_Preferences[ "DoubleClickBehavior" ]; }
      set { LoadIfRequired( ); m_Preferences[ "DoubleClickBehavior" ] = value; }
   }

   public VariableExpansionType VariableExpansion
   {
      get { LoadIfRequired( ); return (VariableExpansionType) m_Preferences[ "VariableExpansion" ]; }
      set { LoadIfRequired( ); m_Preferences[ "VariableExpansion" ] = value; }
   }

   public bool ShowAtStartup
   {
      get { LoadIfRequired( ); return (bool) m_Preferences[ "ShowAtStartup" ]; }
      set { LoadIfRequired( ); m_Preferences[ "ShowAtStartup" ] = value; }
   }

   public bool CheckForUpdate
   {
      get { LoadIfRequired( ); return (bool) m_Preferences[ "CheckForUpdate" ]; }
      set { LoadIfRequired( ); m_Preferences[ "CheckForUpdate" ] = value; }
   }

   public int LastUpdateCheck
   {
      get { LoadIfRequired( ); return (int) m_Preferences[ "LastUpdateCheck" ]; }
      set { LoadIfRequired( ); m_Preferences[ "LastUpdateCheck" ] = value; }
   }

   public string IgnoreUpdateBuild
   {
      get { LoadIfRequired( ); return m_Preferences[ "IgnoreUpdateBuild" ] as string; }
      set { LoadIfRequired( ); m_Preferences[ "IgnoreUpdateBuild" ] = value; }
   }

   private Hashtable m_Preferences = null;

   public void Revert( )
   {
      //clear out the hash table
      //to force the defaults to load
      m_Preferences.Clear( );

      LoadDefaultsIfRequired( );
   }
   
   public void Load( )
   {
      Hashtable preferences = uScript.GetSetting( "Preferences" ) as Hashtable;
      
      if ( null == preferences )
      {
         preferences = new Hashtable( );
      }

      m_Preferences = new Hashtable( preferences );

      LoadDefaultsIfRequired( );
   }

   private void LoadDefaultsIfRequired( )
   {
      if ( null == m_Preferences[ "DrawPanelsOnUpdate" ] )   m_Preferences[ "DrawPanelsOnUpdate" ]   = false;
      if ( null == m_Preferences[ "ShowGrid" ] )             m_Preferences[ "ShowGrid" ]             = uScriptConfig.Style.ShowGrid;
      if ( null == m_Preferences[ "GridSizeVertical" ] )     m_Preferences[ "GridSizeVertical" ]     = uScriptConfig.Style.GridSizeVertical;
      if ( null == m_Preferences[ "GridSizeHorizontal" ] )   m_Preferences[ "GridSizeHorizontal" ]   = uScriptConfig.Style.GridSizeHorizontal;
      if ( null == m_Preferences[ "GridMajorLineSpacing" ] ) m_Preferences[ "GridMajorLineSpacing" ] = uScriptConfig.Style.GridMajorLineSpacing;
      if ( null == m_Preferences[ "GridColorMajor" ] )       m_Preferences[ "GridColorMajor" ]       = uScriptConfig.Style.GridColorMajor;
      if ( null == m_Preferences[ "GridColorMinor" ] )       m_Preferences[ "GridColorMinor" ]       = uScriptConfig.Style.GridColorMinor;
      if ( null == m_Preferences[ "DoubleClickBehavior" ] )  m_Preferences[ "DoubleClickBehavior" ]  = DoubleClickBehaviorType.PingSource;
      if ( null == m_Preferences[ "VariableExpansion" ] )    m_Preferences[ "VariableExpansion" ]    = VariableExpansionType.Dynamic;
      if ( null == m_Preferences[ "ShowAtStartup" ] )        m_Preferences[ "ShowAtStartup" ]        = true;
      if ( null == m_Preferences[ "CheckForUpdate" ] )       m_Preferences[ "CheckForUpdate" ]       = true;
      if ( null == m_Preferences[ "LastUpdateCheck" ] )      m_Preferences[ "LastUpdateCheck" ]      = 0;
      if ( null == m_Preferences[ "IgnoreUpdateBuild" ] )    m_Preferences[ "IgnoreUpdateBuild" ]    = string.Empty;

      if ( null == m_Preferences[ "RelativeProjectFiles" ] )      m_Preferences[ "RelativeProjectFiles" ]      = uScriptConfig.ConstantPaths.RelativePathInAssets(UnityEngine.Application.dataPath + "/uScriptProjectFiles");
      if ( null == m_Preferences[ "RelativeUserScripts" ] )       m_Preferences[ "RelativeUserScripts" ]       = uScriptConfig.ConstantPaths.RelativePathInAssets(ProjectFiles + "/uScripts");
      if ( null == m_Preferences[ "RelativeUserNodes" ] )         m_Preferences[ "RelativeUserNodes" ]         = uScriptConfig.ConstantPaths.RelativePathInAssets(ProjectFiles + "/Nodes");
      if ( null == m_Preferences[ "RelativeNestedScripts" ] )     m_Preferences[ "RelativeNestedScripts" ]     = uScriptConfig.ConstantPaths.RelativePathInAssets(UserScripts + "/_GeneratedCode");
      if ( null == m_Preferences[ "RelativeGeneratedScripts" ] )  m_Preferences[ "RelativeGeneratedScripts" ]  = uScriptConfig.ConstantPaths.RelativePathInAssets(UserScripts + "/_GeneratedCode");
      if ( null == m_Preferences[ "MaximumNodeRecursionCount" ] ) m_Preferences[ "MaximumNodeRecursionCount" ] = 1000;
      if ( null == m_Preferences[ "SaveMethod" ] )                m_Preferences[ "SaveMethod" ]                = 1;   // 0:Quick, 1:Debug, 2:Release
   }
   
   public void Save( )
   {
      LoadIfRequired( );

      uScript.SetSetting( "Preferences", new Hashtable(m_Preferences) );
   }
   
   private void LoadIfRequired( )
   {
      if ( null == m_Preferences )
      {
         Load( );
      }
   }
}
