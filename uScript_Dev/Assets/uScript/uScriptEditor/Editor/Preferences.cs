using System.Collections;

public class Preferences
{
   public string ProjectFiles 
   { 
      get { LoadIfRequired( ); return m_Preferences[ "ProjectFiles" ] as string; } 
      set { LoadIfRequired( ); m_Preferences[ "ProjectFiles" ] = value; }       
   }

   public string UserScripts
   { 
      get { LoadIfRequired( ); return m_Preferences[ "UserScripts" ] as string; } 
      set { LoadIfRequired( ); m_Preferences[ "UserScripts" ] = value; }       
   }

   public string UserNodes
   { 
      get { LoadIfRequired( ); return m_Preferences[ "UserNodes" ] as string; } 
      set { LoadIfRequired( ); m_Preferences[ "UserNodes" ] = value; }       
   }

   public string GeneratedScripts
   { 
      get { LoadIfRequired( ); return m_Preferences[ "GeneratedScripts" ] as string; } 
      set { LoadIfRequired( ); m_Preferences[ "GeneratedScripts" ] = value; }       
   }

   public string NestedScripts
   { 
      get { LoadIfRequired( ); return m_Preferences[ "NestedScripts" ] as string; } 
      set { LoadIfRequired( ); m_Preferences[ "NestedScripts" ] = value; }       
   }

   public bool DrawPanelsOnUpdate
   {
      get { LoadIfRequired( ); return (bool) m_Preferences[ "DrawPanelsOnUpdate" ]; }
      set { LoadIfRequired( ); m_Preferences[ "DrawPanelsOnUpdate" ] = value; }
   }

   public int ToolbarButtonStyle
   {
      get { LoadIfRequired( ); return (int) m_Preferences[ "ToolbarButtonStyle" ]; }
      set { LoadIfRequired( ); m_Preferences[ "ToolbarButtonStyle" ] = value; }
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
      if ( null == m_Preferences[ "ProjectFiles" ] )         m_Preferences[ "ProjectFiles" ]         = UnityEngine.Application.dataPath + "/uScriptProjectFiles";
      if ( null == m_Preferences[ "UserScripts" ] )          m_Preferences[ "UserScripts" ]          = ProjectFiles + "/uScripts";
      if ( null == m_Preferences[ "UserNodes" ] )            m_Preferences[ "UserNodes" ]            = ProjectFiles + "/Nodes";
      if ( null == m_Preferences[ "GeneratedScripts" ] )     m_Preferences[ "GeneratedScripts" ]     = UserScripts  + "/_GeneratedCode";
      if ( null == m_Preferences[ "NestedScripts" ] )        m_Preferences[ "NestedScripts" ]        = GeneratedScripts;
      if ( null == m_Preferences[ "DrawPanelsOnUpdate" ] )   m_Preferences[ "DrawPanelsOnUpdate" ]   = false;
      if ( null == m_Preferences[ "ToolbarButtonStyle" ] )   m_Preferences[ "ToolbarButtonStyle" ]   = 1;
      if ( null == m_Preferences[ "ShowGrid" ] )             m_Preferences[ "ShowGrid" ]             = uScriptConfig.Style.ShowGrid;
      if ( null == m_Preferences[ "GridSizeVertical" ] )     m_Preferences[ "GridSizeVertical" ]     = uScriptConfig.Style.GridSizeVertical;
      if ( null == m_Preferences[ "GridSizeHorizontal" ] )   m_Preferences[ "GridSizeHorizontal" ]   = uScriptConfig.Style.GridSizeHorizontal;
      if ( null == m_Preferences[ "GridMajorLineSpacing" ] ) m_Preferences[ "GridMajorLineSpacing" ] = uScriptConfig.Style.GridMajorLineSpacing;
      if ( null == m_Preferences[ "GridColorMajor" ] )       m_Preferences[ "GridColorMajor" ]       = uScriptConfig.Style.GridColorMajor;
      if ( null == m_Preferences[ "GridColorMinor" ] )       m_Preferences[ "GridColorMinor" ]       = uScriptConfig.Style.GridColorMinor;
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
