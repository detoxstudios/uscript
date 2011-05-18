// uScript utility class
// (C) 2011 Detox Studios LLC
// Desc: Class used to perform tasks that need to be run whether or not a uScript window is open.

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Detox.ScriptEditor;

#if UNITY_EDITOR

[InitializeOnLoad]
public class uScriptBackgroundProcess
{
   static uScriptBackgroundProcess()
   {
      EditorApplication.update += Update;
   }
   
   static void Update ()
   {
      // cache the master object and component
      if (uScript.MasterObject == null || uScript.MasterComponent == null) return;

      // process any waiting uScripts that need attaching
      if (!EditorApplication.isCompiling)
      {
         AttachUScripts();
      }
   }
   
   private static void AttachUScripts()
   {
      if (uScript.MasterComponent.uScriptsToAttach.Length > 0)
      {
         foreach(string path in uScript.MasterComponent.uScriptsToAttach)
         {
            // add the new uScript to the master object
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
            String typeName = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".")) + uScriptConfig.Files.GeneratedComponentExtension;
            //Debug.Log("TYPENAME: " + typeName);

            uScript.MasterObject.AddComponent(typeName);
         }

         uScript.MasterComponent.ClearAttachList();
      }
   }
}

#endif