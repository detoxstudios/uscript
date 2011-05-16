using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Detox.ScriptEditor;

#if UNITY_EDITOR

[InitializeOnLoad]
public class uScriptGOAttacher
{
   static GameObject s_Master = null;
   static uScript_MasterObject s_Component = null;
   
   static uScriptGOAttacher ()
   {
      EditorApplication.update += Update;
   }
   
   static void Update ()
   {
      // cache the master object and component
      if (s_Master == null)
      {
         s_Master = GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
         
         if (s_Master != null)
         {
            s_Component = (uScript_MasterObject)s_Master.GetComponent(typeof(uScript_MasterObject));
         }
      }
      else if (s_Component == null)
      {
         s_Component = (uScript_MasterObject)s_Master.GetComponent(typeof(uScript_MasterObject));
      }

      // process any waiting uScripts that need attaching
      if (s_Component != null && !EditorApplication.isCompiling)
      {
         if (s_Component.uScriptsToAttach.Length > 0)
         {
            foreach(string path in s_Component.uScriptsToAttach)
            {
               // add the new uScript to the master object
               System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
               String typeName = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".")) + uScriptConfig.Files.GeneratedComponentExtension;
               //Debug.Log("TYPENAME: " + typeName);

               s_Master.AddComponent(typeName);
            }
  
            s_Component.ClearAttachList();
         }
      }
   }
}

#endif