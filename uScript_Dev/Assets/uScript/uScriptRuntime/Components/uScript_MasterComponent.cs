// uScript utility class
// (C) 2011 Detox Studios LLC
// Desc: The master uScript component. This class is also used as a data transport class between the uScript window and the uScriptBackgroundProcess.

using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class uScript_MasterComponent : MonoBehaviour
{
   //keep track of the latest master so uScripts loading
   //will know which master loaded with them for their scene infomration
   public static GameObject LatestMaster = null;

   public void Awake( )
   {
      LatestMaster = this.gameObject;

#if UNITY_EDITOR
      GameObject []gameObjects = (GameObject[]) GameObject.FindObjectsOfType( typeof(GameObject) );

      PruneGameObjects( );

      //build up our cache
      foreach ( GameObject gameObject in gameObjects )
      {
         CacheGameObject( gameObject );
      }
#endif
   }

#if UNITY_EDITOR
   private string CacheGameObject( GameObject gameObject )
   {
      int i;

      //do we know about it already? if so return the guid
      for ( i = 0; i < GameObjects.Length; i++ )
      {
         if ( GameObjects[ i ] == gameObject ) return GameObjectGuids[ i ];
      }

      //do we not know about it but it exists? 
      //then create a new guid for it
      Array.Resize( ref GameObjects, GameObjects.Length + 1 );
      Array.Resize( ref GameObjectGuids, GameObjectGuids.Length + 1 );
   
      GameObjects[ i ] = gameObject;
      GameObjectGuids[ i ] = Guid.NewGuid( ).ToString( );
   
      return GameObjectGuids[ i ];
   }

   private void PruneGameObjects( )
   {
      for ( int i = 0; i < GameObjects.Length; i++ )
      {
         if ( null == GameObjects[ i ] )
         {
            GameObjects    [ i ] = GameObjects    [ GameObjects.Length - 1 ];
            GameObjectGuids[ i ] = GameObjectGuids[ GameObjects.Length - 1 ];

            Array.Resize( ref GameObjects,     GameObjects.Length - 1 );
            Array.Resize( ref GameObjectGuids, GameObjectGuids.Length - 1 );
         }
      }
   }

   public string GetGameObject( string oldName, string referenceGuid )
   {
      //do we know about it already? if so return the guid
      for ( int i = 0; i < GameObjects.Length; i++ )
      {
         if ( null == GameObjects[ i ] ) continue;

         if ( GameObjectGuids[ i ] == referenceGuid ) return GameObjects[ i ].name;
      }

      //doesn't exist so return the old name
      return oldName;
   }

   public string GetGameObjectGuid( string name )
   {
      //do we know about it already? if so return the guid
      for ( int i = 0; i < GameObjects.Length; i++ )
      {
         if ( null == GameObjects[ i ] ) continue;

         if ( GameObjects[ i ].name == name ) return GameObjectGuids[ i ];
      }

      //do we not know about it but it exists? 
      //then create a new guid for it
      GameObject gameObject = GameObject.Find( name );

      if ( null != gameObject )
      {
         return CacheGameObject( gameObject );      
      }

      //doesn't exist so return nothing
      return "";
   }

   [HideInInspector]
   public GameObject [] GameObjects = new GameObject[0];

   [HideInInspector]
   public string [] GameObjectGuids = new string[0];

   [HideInInspector]
   public string Script     = null;

   [HideInInspector]
   public string ScriptName = null;

   [HideInInspector]
   public string []m_uScriptsToAttach = new string[0];
   public string[] uScriptsToAttach
   {
      get { return m_uScriptsToAttach; }
   }
   
   private Hashtable m_Types = new Hashtable();
 
   public void ClearAttachList() { m_uScriptsToAttach = new string[0]; }
   
   public void AttachScriptToMaster(string fullPath)
   {
      System.Array.Resize(ref m_uScriptsToAttach, m_uScriptsToAttach.Length + 1 );
      m_uScriptsToAttach[ m_uScriptsToAttach.Length - 1 ] = fullPath;
   }

   void OnDrawGizmos( )
   {
      Gizmos.DrawIcon(gameObject.transform.position, "uscript_gizmo_master.png");      
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

#endif
}
