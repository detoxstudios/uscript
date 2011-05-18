// uScript utility class
// (C) 2011 Detox Studios LLC
// Desc: The master uScript component. This class is also used as a data transport class between the uScript window and the uScriptBackgroundProcess.

using UnityEngine;
using System.Collections.Generic;

public class uScript_MasterObject : MonoBehaviour
{
#if UNITY_EDITOR
   [HideInInspector]
   public string Script     = null;

   [HideInInspector]
   public string ScriptName = null;

   private List<string> m_uScriptsToAttach = new List<string>();
   
   public string[] uScriptsToAttach
   {
      get { return m_uScriptsToAttach.ToArray(); }
   }
   
   public void ClearAttachList() { m_uScriptsToAttach.Clear(); }
   
   public void AttachScriptToMaster(string fullPath)
   {
      m_uScriptsToAttach.Add(fullPath);
   }

   void OnDrawGizmos( )
   {
      Gizmos.DrawIcon(gameObject.transform.position, "uscript_gizmo_master.png");      
   }
#endif
}
