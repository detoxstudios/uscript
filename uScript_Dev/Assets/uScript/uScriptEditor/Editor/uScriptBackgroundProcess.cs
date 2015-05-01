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
	
   private static bool m_SkipLabelsCheck = false;

   static uScriptBackgroundProcess()
   {
      GraphInfoList = new Dictionary<string, GraphInfo>();

      EditorApplication.projectWindowChanged += ForceFileRefresh;
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

         System.Type type = uScriptUtils.GetAssemblyQualifiedType(typeName);
         uScript.MasterObject.AddComponent(type);
      }

      ForceFileRefresh();
      uScript.MasterComponent.ClearAttachList();
   }

   public static void ForceFileRefresh()
   {
      if (uScript.IsOpen == false)
      {
         return;
      }

      GraphInfoList.Clear();

      foreach (var path in uScript.GetGraphPaths())
      {
         var graphName = Path.GetFileNameWithoutExtension(path);
         GraphInfo gi = new GraphInfo(path);
         if (graphName != null && !GraphInfoList.TryGetValue(graphName, out gi))
         {
            GraphInfoList.Add(graphName, new GraphInfo(path));
         }
      }

      currentKeyIndex = 0;
   }

   public static UnityEngine.Object[] GetAtPath(string path, string filterString = "*")
   {
      List<UnityEngine.Object> al = new List<UnityEngine.Object>();
      string[] fileEntries = Directory.GetFiles(path, filterString, SearchOption.AllDirectories);

      foreach (string fileName in fileEntries)
      {
         UnityEngine.Object t = AssetDatabase.LoadMainAssetAtPath(fileName.RelativeAssetPath());
         if (t != null) al.Add(t);
      }

      return al.ToArray();
   }
   
   private static void Update()
   {
      if (uScript.IsOpen == false)
      {
         if (!m_SkipLabelsCheck)
         {
            // check for asset labels
            UnityEngine.Object[] objs = GetAtPath(uScript.Preferences.UserScripts, "*.uscript");
            foreach (UnityEngine.Object obj in objs)
            {
               string[] labels = AssetDatabase.GetLabels(obj);
               if (labels == null) continue;
               foreach (string label in labels)
               {
                  if (label.Contains("uScript"))
                  {
                     m_SkipLabelsCheck = true;
                     return;
                  }
               }
            }
				
            // if we made it this far, assign labels
            foreach (UnityEngine.Object obj in objs)
            {
               AssetDatabase.SetLabels(obj, new string[] { "uScript", "uScriptSource" });
            }
            objs = GetAtPath(uScript.Preferences.UserScripts + "/_GeneratedCode", "*.cs");
            foreach (UnityEngine.Object obj in objs)
            {
               AssetDatabase.SetLabels(obj, new string[] { "uScript", "uScriptCode" });
            }
            m_SkipLabelsCheck = true;
         }
         return;
      }

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
