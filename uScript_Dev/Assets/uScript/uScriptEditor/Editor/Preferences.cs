using System.Collections;

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

   public bool Profiling
   {
      get { LoadIfRequired( ); return (bool) m_Preferences[ "Profiling" ]; }
      set { LoadIfRequired( ); m_Preferences[ "Profiling" ] = value; }
   }

   public float ProfileMin
   {
      get { LoadIfRequired( ); return (float) m_Preferences[ "ProfileMin" ]; }
      set { LoadIfRequired( ); m_Preferences[ "ProfileMin" ] = value; }
   }

   public int GridSize
   {
      get { LoadIfRequired( ); return (int) m_Preferences[ "GridSize" ]; }
      set { LoadIfRequired( ); m_Preferences[ "GridSize" ] = value; }
   }

   public int GridSubdivisions
   {
      get { LoadIfRequired( ); return (int) m_Preferences[ "GridSubdivisions" ]; }
      set { LoadIfRequired( ); m_Preferences[ "GridSubdivisions" ] = value; }
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

   public bool GridSnap
   {
      get { LoadIfRequired( ); return (bool) m_Preferences[ "GridSnap" ]; }
      set { LoadIfRequired( ); m_Preferences[ "GridSnap" ] = value; }
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

   public int PropertyPanelNodeLimit
   {
      get { LoadIfRequired( ); return (int) m_Preferences[ "PropertyPanelNodeLimit" ]; }
      set { LoadIfRequired( ); m_Preferences[ "PropertyPanelNodeLimit" ] = value; }
   }

   public bool ExpandFavoritePanel
   {
      get { LoadIfRequired( ); return (bool) m_Preferences[ "ExpandFavoritePanel" ]; }
      set { LoadIfRequired( ); m_Preferences[ "ExpandFavoritePanel" ] = value; }
   }

   public string FavoriteNode1
   {
      get { LoadIfRequired( ); return m_Preferences[ "FavoriteNode1" ] as string; }
      set { LoadIfRequired( ); m_Preferences[ "FavoriteNode1" ] = value; }
   }

   public string FavoriteNode2
   {
      get { LoadIfRequired( ); return m_Preferences[ "FavoriteNode2" ] as string; }
      set { LoadIfRequired( ); m_Preferences[ "FavoriteNode2" ] = value; }
   }

   public string FavoriteNode3
   {
      get { LoadIfRequired( ); return m_Preferences[ "FavoriteNode3" ] as string; }
      set { LoadIfRequired( ); m_Preferences[ "FavoriteNode3" ] = value; }
   }

   public string FavoriteNode4
   {
      get { LoadIfRequired( ); return m_Preferences[ "FavoriteNode4" ] as string; }
      set { LoadIfRequired( ); m_Preferences[ "FavoriteNode4" ] = value; }
   }

   public string FavoriteNode5
   {
      get { LoadIfRequired( ); return m_Preferences[ "FavoriteNode5" ] as string; }
      set { LoadIfRequired( ); m_Preferences[ "FavoriteNode5" ] = value; }
   }

   public string FavoriteNode6
   {
      get { LoadIfRequired( ); return m_Preferences[ "FavoriteNode6" ] as string; }
      set { LoadIfRequired( ); m_Preferences[ "FavoriteNode6" ] = value; }
   }

   public string FavoriteNode7
   {
      get { LoadIfRequired( ); return m_Preferences[ "FavoriteNode7" ] as string; }
      set { LoadIfRequired( ); m_Preferences[ "FavoriteNode7" ] = value; }
   }

   public string FavoriteNode8
   {
      get { LoadIfRequired( ); return m_Preferences[ "FavoriteNode8" ] as string; }
      set { LoadIfRequired( ); m_Preferences[ "FavoriteNode8" ] = value; }
   }

   public string FavoriteNode9
   {
      get { LoadIfRequired( ); return m_Preferences[ "FavoriteNode9" ] as string; }
      set { LoadIfRequired( ); m_Preferences[ "FavoriteNode9" ] = value; }
   }
   
   public string[] FavoriteNodes
   {
      get
      {
         return new string[] { FavoriteNode1, FavoriteNode2, FavoriteNode3, FavoriteNode4, FavoriteNode5, FavoriteNode6, FavoriteNode7, FavoriteNode8, FavoriteNode9 };
      }
   }

   public string GetFavoriteNode(int number)
   {
      if (number < 1 || number > 9)
      {
         uScriptDebug.Log("An invalid Favorite number was specified: " + number.ToString(), uScriptDebug.Type.Error);
         return string.Empty;
      }

      return m_Preferences["FavoriteNode" + number.ToString()] as string;
   }

   public void UpdateFavoriteNode(int number, string value)
   {
      if (number < 1 || number > 9)
      {
         uScriptDebug.Log("An invalid Favorite number was specified: " + number.ToString(), uScriptDebug.Type.Error);
         return;
      }

      m_Preferences["FavoriteNode" + number.ToString()] = value;
      Save();
   }

   public void SwapFavoriteNodes(int number1, int number2)
   {
      if (number1 < 1 || number1 > 9)
      {
         uScriptDebug.Log("An invalid Favorite number was specified: " + number1.ToString(), uScriptDebug.Type.Error);
         return;
      }

      if (number2 < 1 || number2 > 9)
      {
         uScriptDebug.Log("An invalid Favorite number was specified: " + number2.ToString(), uScriptDebug.Type.Error);
         return;
      }

      string original = m_Preferences["FavoriteNode" + number1.ToString()] as string;
      m_Preferences["FavoriteNode" + number1.ToString()] = m_Preferences["FavoriteNode" + number2.ToString()];
      m_Preferences["FavoriteNode" + number2.ToString()] = original;
      Save();
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
      if ( null == m_Preferences[ "GridSize" ] )             m_Preferences[ "GridSize" ]             = uScriptConfig.Style.GridSize;
      if ( null == m_Preferences[ "GridSubdivisions" ] )     m_Preferences[ "GridSubdivisions" ]     = uScriptConfig.Style.GridSubdivisions;
      if ( null == m_Preferences[ "GridColorMajor" ] )       m_Preferences[ "GridColorMajor" ]       = uScriptConfig.Style.GridColorMajor;
      if ( null == m_Preferences[ "GridColorMinor" ] )       m_Preferences[ "GridColorMinor" ]       = uScriptConfig.Style.GridColorMinor;
      if ( null == m_Preferences[ "DoubleClickBehavior" ] )  m_Preferences[ "DoubleClickBehavior" ]  = DoubleClickBehaviorType.PingSource;
      if ( null == m_Preferences[ "VariableExpansion" ] )    m_Preferences[ "VariableExpansion" ]    = VariableExpansionType.Dynamic;
      if ( null == m_Preferences[ "GridSnap" ] )             m_Preferences[ "GridSnap" ]             = false;
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
      if ( null == m_Preferences[ "ProfileMin" ] )                m_Preferences[ "ProfileMin" ]                = 1f;
      if ( null == m_Preferences[ "Profiling" ] )                 m_Preferences[ "Profiling" ]                 = false;
      if ( null == m_Preferences[ "PropertyPanelNodeLimit" ] )    m_Preferences[ "PropertyPanelNodeLimit" ]    = 1;

      if ( null == m_Preferences[ "ExpandFavoritePanel" ] )       m_Preferences[ "ExpandFavoritePanel" ]       = true;

      if ( null == m_Preferences[ "FavoriteNode1" ] ) m_Preferences[ "FavoriteNode1" ] = string.Empty;
      if ( null == m_Preferences[ "FavoriteNode2" ] ) m_Preferences[ "FavoriteNode2" ] = string.Empty;
      if ( null == m_Preferences[ "FavoriteNode3" ] ) m_Preferences[ "FavoriteNode3" ] = string.Empty;
      if ( null == m_Preferences[ "FavoriteNode4" ] ) m_Preferences[ "FavoriteNode4" ] = string.Empty;
      if ( null == m_Preferences[ "FavoriteNode5" ] ) m_Preferences[ "FavoriteNode5" ] = string.Empty;
      if ( null == m_Preferences[ "FavoriteNode6" ] ) m_Preferences[ "FavoriteNode6" ] = string.Empty;
      if ( null == m_Preferences[ "FavoriteNode7" ] ) m_Preferences[ "FavoriteNode7" ] = string.Empty;
      if ( null == m_Preferences[ "FavoriteNode8" ] ) m_Preferences[ "FavoriteNode8" ] = string.Empty;
      if ( null == m_Preferences[ "FavoriteNode9" ] ) m_Preferences[ "FavoriteNode9" ] = string.Empty;
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
