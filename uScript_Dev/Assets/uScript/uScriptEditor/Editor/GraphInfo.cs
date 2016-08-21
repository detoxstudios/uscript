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
      // Application.dataPath:
      //    C:/full/file/system/path/Assets

      // Preferences.UserScripts:
      //    C:/full/file/system/path/Assets/uScriptProjectFiles/uScripts

      // FullPath:
      //    C:/full/file/system/path/Assets/uScriptProjectFiles/uScripts/nested/path/ScriptName.uscript

      // ProjectRelativePath:
      //    Assets/uScriptProjectFiles/uScripts/nested/path/ScriptName.uscript

      // GraphRelativePath:
      //    nested/path/ScriptName.uscript

      // GraphName
      //    ScriptName.uscript

      public GraphInfo(string graphPath)
      {
         this.GraphPath = graphPath;

         this.FriendlyName = string.Empty;
         this.GraphName = string.Empty;
         this.SceneName = string.Empty;
      }

      public enum State
      {
         Missing,
         Stale,
         Debug,
         Release
      }

      public string FriendlyName { get; private set; }

      public string GraphName { get; private set; }

      public string GraphPath { get; private set; }

      public string SceneName { get; private set; }

      public State SourceState { get; private set; }

      public void Update(ScriptEditor scriptEditor)
      {
         this.GraphName = Path.GetFileNameWithoutExtension(scriptEditor.Name);

         this.FriendlyName = string.IsNullOrEmpty(scriptEditor.FriendlyName.Default)
            ? this.GraphName
            : scriptEditor.FriendlyName.Default;

         this.SceneName = scriptEditor.SceneName;

         this.SourceState = uScriptGUI.IsGeneratedScriptMissing(this.GraphName)
            ? State.Missing
            : (scriptEditor.GeneratedCodeIsStale
               ? State.Stale
               : (scriptEditor.SavedForDebugging
                  ? State.Debug
                  : State.Release));

         uScript.Instance.SetDebugState(this.GraphName, scriptEditor.SavedForDebugging);
      }

      public override string ToString()
      {
         return string.Format(
            //"GraphInfo(GraphPath: \"{0}\", GraphName: \"{1}\", SceneName: \"{2}\", SourceState: {3}, FriendlyName: \"{4}\")",
            "GraphInfo(\"{0}\", \"{1}\", \"{2}\", {3}, \"{4}\")",
            this.GraphPath,
            this.GraphName,
            this.SceneName,
            this.SourceState,
            this.FriendlyName);
      }
   }
}
