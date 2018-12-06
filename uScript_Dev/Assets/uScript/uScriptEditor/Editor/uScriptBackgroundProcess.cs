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

         System.Type type = uScript.GetAssemblyQualifiedType(typeName);
         uScript.MasterObject.AddComponent(type);
      }

      ForceFileRefresh();
      uScript.MasterComponent.ClearAttachList();
   }

   private static void AddFilesToVC()
   {
      if (uScript.MasterComponent.FilesToAddToVC.Length <= 0)
      {
         return;
      }

#if UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_2017 || UNITY_2018
      foreach (var path in uScript.MasterComponent.FilesToAddToVC)
      {
         // blocking add of unversioned file, if necessary
         if (UnityEditor.VersionControl.Provider.isActive)
         {
            UnityEditor.VersionControl.Asset asset = UnityEditor.VersionControl.Provider.GetAssetByPath(path);
            if (asset != null && UnityEditor.VersionControl.Provider.AddIsValid(new UnityEditor.VersionControl.AssetList() { asset }))
            {
               UnityEditor.VersionControl.Provider.Add(asset, false).Wait();
            }
         }
      }

      ForceFileRefresh();
#endif
      uScript.MasterComponent.ClearAddList();
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
            // TODO: We should probably use "uScriptGraph" for graphs and "uScriptCode" for generated files.
            //       The term 'source' is vague, and used to refer to generated code elsewhere in the UI.

            // the following code is used to update existing uscripts and their generated code
            // so that .uscript files have a "uScript" and "uScriptSource" label and the
            // generated files have a "uScript" and "uScriptCode" label
            if (Directory.Exists(Preferences.UserScripts))
            {
               // check for asset labels
               UnityEngine.Object[] objs = GetAtPath(Preferences.UserScripts, "*.uscript");
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

               objs = GetAtPath(Preferences.UserScripts + "/_GeneratedCode", "*.cs");
               foreach (UnityEngine.Object obj in objs)
               {
                  AssetDatabase.SetLabels(obj, new string[] { "uScript", "uScriptCode" });
               }
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
         AddFilesToVC();
      }

      // Any graphs left to process? Process using multiple ticks, if necessary.
      if (GraphInfoList.Count <= 0 || currentKeyIndex >= GraphInfoList.Count)
      {
         return;
      }

#if UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_2017 || UNITY_2018
      var graphs = uScript.GetGraphPaths();
      if (GraphInfoList.Count != graphs.Count)
      {
         // refresh file list
         ForceFileRefresh();
      }
#endif

      int i;
      var keys = new List<string>(GraphInfoList.Keys).ToArray();

      for (i = 0; i < FilesPerTick && currentKeyIndex < GraphInfoList.Count; i++, currentKeyIndex++)
      {
         GraphInfo info = GraphInfoList[keys[currentKeyIndex]];
         // Try to load the graph status cache file first before loading the whole graph.
         if( !info.Load() )
         {
            var p = new Profile("Opening \"" + info.GraphPath + "\"");

            var scriptEditor = new ScriptEditor(string.Empty, null, null);
            scriptEditor.Open( info.GraphPath );
            info.Update( scriptEditor );
            // Update this graph's status cache file.
            info.Save();

            p.End();
         }
      }
   }
}

#endif
