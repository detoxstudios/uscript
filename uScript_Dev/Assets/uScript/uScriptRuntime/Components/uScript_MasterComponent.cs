// uScript utility class
// (C) 2011 Detox Studios LLC
// Desc: The master uScript component. This class is also used as a data transport class between the uScript window and the uScriptBackgroundProcess.

using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

public class uScript_MasterComponent : MonoBehaviour
{
   //keep track of the latest master so uScripts loading
   //will know which master loaded with them for their scene infomration
   public static GameObject LatestMaster = null;

   public void Awake( )
   {
      LatestMaster = gameObject;
   }

#if UNITY_EDITOR
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
