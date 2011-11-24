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
   public class uScriptInfo
   {
      public string m_SceneName = "";
      public string m_FullPath = "";
      
      public uScriptInfo(string fullPath)
      {
         m_FullPath = fullPath;
         m_SceneName = "";
      }

      public uScriptInfo(string fullPath, string sceneName)
      {
         m_FullPath = fullPath;
         m_SceneName = sceneName;
      }
   };
   
   private const float USCRIPT_PROCESS_TIME = 30.0f;
   private const int   FILES_PER_TICK = 5;
   
   public static Dictionary<string, uScriptInfo> s_uScriptInfo = new Dictionary<string, uScriptInfo>();
   private static int s_CurrentKeyIndex = -1;
   
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
      
      // any uScrupts left to process? Process them FILES_PER_TICK at a time each tick
      if (s_uScriptInfo.Count > 0 && s_CurrentKeyIndex < s_uScriptInfo.Count)
      {
         int i;
         List<string> keylist = new List<string>();
         keylist.AddRange(s_uScriptInfo.Keys);
         string[] keys = keylist.ToArray();
         for (i = 0; i < FILES_PER_TICK && s_CurrentKeyIndex < s_uScriptInfo.Count; i++, s_CurrentKeyIndex++)
         {
            uScriptInfo info = s_uScriptInfo[keys[s_CurrentKeyIndex]];
            Detox.ScriptEditor.ScriptEditor scriptEditor = new Detox.ScriptEditor.ScriptEditor( "", null, null );
            scriptEditor.Open(info.m_FullPath);
            s_uScriptInfo[keys[s_CurrentKeyIndex]] = new uScriptInfo(keys[s_CurrentKeyIndex], scriptEditor.SceneName);
         }
      }
   }
   
   public static void ForceFileRefresh()
   {
      // get list of uScripts every USCRIPT_PROCESS_TIME seconds
      s_uScriptInfo.Clear();

      foreach (string fileName in System.IO.Directory.GetFiles(uScript.Preferences.UserScripts))
      {
         if (fileName.EndsWith(".uscript"))
         {
            s_uScriptInfo.Add(System.IO.Path.GetFileName(fileName), new uScriptInfo(fileName));
         }
      }
      
      s_CurrentKeyIndex = 0;
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

         ForceFileRefresh();
         uScript.MasterComponent.ClearAttachList();
      }
   }
}

#endif