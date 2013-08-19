// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios, LLC" file="uScriptBackgroundProcess.cs">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Utility class used to perform tasks that need to be run whether or not a uScript window is open.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;

using Detox.Editor;
using Detox.ScriptEditor;

using UnityEditor;

#if UNITY_EDITOR

// TODO: Rename the class to GraphBackgroundProcess or just BackgroundProcess

[InitializeOnLoad]
public class uScriptBackgroundProcess
{
   private const int FilesPerTick = 5;

   private static int currentKeyIndex = -1;

   static uScriptBackgroundProcess()
   {
      GraphInfoList = new Dictionary<string, GraphInfo>();

      EditorApplication.update += Update;
   }

   public static Dictionary<string, GraphInfo> GraphInfoList { get; private set; }

   private static void AttachUScripts()
   {
      if (uScript.MasterComponent.uScriptsToAttach.Length <= 0)
      {
         return;
      }

      foreach (var path in uScript.MasterComponent.uScriptsToAttach)
      {
         // Add the new graph to the master object
         var fileInfo = new FileInfo(path);
         var typeName = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".", System.StringComparison.Ordinal)) + uScriptConfig.Files.GeneratedComponentExtension;
         //Debug.Log("Type name: " + typeName);

         uScript.MasterObject.AddComponent(typeName);
      }

      ForceFileRefresh();
      uScript.MasterComponent.ClearAttachList();
   }

   public static void ForceFileRefresh()
   {
      GraphInfoList.Clear();

      foreach (var path in uScript.GetGraphPaths())
      {
         var graphName = Path.GetFileNameWithoutExtension(path);
         if (graphName != null)
         {
            GraphInfoList.Add(graphName, new GraphInfo(path));
         }
      }

      currentKeyIndex = 0;
   }

   private static void Update()
   {
      // Cache the master object and component
      if (uScript.MasterObject == null || uScript.MasterComponent == null)
      {
         return;
      }

      // Process any waiting uScripts that need attaching
      if (!EditorApplication.isCompiling)
      {
         AttachUScripts();
      }

      // Any graphs left to process? Process using multiple ticks, if necessary.
      if (GraphInfoList.Count <= 0 || currentKeyIndex >= GraphInfoList.Count)
      {
         return;
      }

      int i;
      var keys = new List<string>(GraphInfoList.Keys).ToArray();

      for (i = 0; i < FilesPerTick && currentKeyIndex < GraphInfoList.Count; i++, currentKeyIndex++)
      {
         var info = GraphInfoList[keys[currentKeyIndex]];

         var p = new Profile("Opening \"" + info.GraphPath + "\"");

         var scriptEditor = new ScriptEditor(string.Empty, null, null);
         scriptEditor.Open(info.GraphPath);
         info.Update(scriptEditor);

         p.End();
      }
   }
}

#endif
