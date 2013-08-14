// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios, LLC" file="GraphInfo.cs">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Utility class used to perform tasks that need to be run whether or not a uScript window is open.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   using System.IO;

   using ScriptEditor = Detox.ScriptEditor.ScriptEditor;

   public class GraphInfo
   {
      public GraphInfo(string graphPath)
      {
         this.GraphPath = graphPath;
         this.SceneName = string.Empty;
      }

      public GraphInfo(string graphPath, ScriptEditor scriptEditor)
      {
         var graphName = Path.GetFileNameWithoutExtension(scriptEditor.Name);

         this.GraphName = string.IsNullOrEmpty(scriptEditor.FriendlyName.Default)
            ? graphName
            : scriptEditor.FriendlyName.Default;
         this.GraphPath = graphPath;

         this.SceneName = scriptEditor.SceneName;

         this.SourceState = uScriptGUI.IsGeneratedScriptMissing(graphName)
            ? State.Missing
            : (scriptEditor.GeneratedCodeIsStale
               ? State.Stale
               : (scriptEditor.SavedForDebugging
                  ? State.Debug
                  : State.Release));

         uScript.Instance.SetDebugState(graphName, scriptEditor.SavedForDebugging);
      }

      public enum State
      {
         Missing,
         Stale,
         Debug,
         Release
      }

      public string GraphName { get; private set; }

      public string GraphPath { get; private set; }

      public string SceneName { get; private set; }

      public State SourceState { get; private set; }
   }
}
