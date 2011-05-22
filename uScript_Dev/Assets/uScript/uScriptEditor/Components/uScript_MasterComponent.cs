// uScript utility class
// (C) 2011 Detox Studios LLC
// Desc: The master uScript component. This class is also used as a data transport class between the uScript window and the uScriptBackgroundProcess.

using UnityEngine;
using System.Collections.Generic;

public class uScript_MasterComponent : MonoBehaviour
{
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
   
   public void ClearAttachList() { m_uScriptsToAttach = new string[0]; }
   
   public void AttachScriptToMaster(string fullPath)
   {
      System.Array.Resize(ref m_uScriptsToAttach, m_uScriptsToAttach.Length + 1 );
      m_uScriptsToAttach[ m_uScriptsToAttach.Length ] = fullPath;
   }

   void OnDrawGizmos( )
   {
      Gizmos.DrawIcon(gameObject.transform.position, "uscript_gizmo_master.png");      
   }
#endif
}
