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
   using Utility.Bxml;
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
         this.GraphName = !string.IsNullOrEmpty( GraphPath ) ? Path.GetFileNameWithoutExtension( GraphPath ) : string.Empty;
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

      private static string StatusDirectoryPath
      {
         get { return UnityEngine.Application.dataPath + "/../Library/uScriptCache/"; }
      }

      public string StatusFilePath
      {
         get { return !string.IsNullOrEmpty( GraphName ) ? StatusDirectoryPath + GraphName + ".status" : string.Empty; }
      }

      private long modifiedTime;

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

         modifiedTime = GetGraphModifiedTime();
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

      private long GetGraphModifiedTime()
      {
         long time = 0;

         if( !string.IsNullOrEmpty( GraphPath ) && File.Exists( GraphPath ) )
         {
            System.DateTime modTime = File.GetLastWriteTimeUtc( GraphPath );

            time = modTime.ToBinary();
         }

         return time;
      }

      public bool Save()
      {
         bool success = false;

         string filePath = StatusFilePath;

         if( string.IsNullOrEmpty( filePath ) == false )
         {
            if( !Directory.Exists( StatusDirectoryPath ) ) Directory.CreateDirectory( StatusDirectoryPath );

            BinaryXml bxml = new BinaryXml( "GraphInfo" );

            BxmlTag tag = null, root = bxml.CurrentTag;

            tag = root.AddChild( "GraphPath" );
            tag.Value = GraphPath;

            tag = root.AddChild( "GraphName" );
            tag.Value = GraphName;

            tag = root.AddChild( "SceneName" );
            tag.Value = SceneName;

            tag = root.AddChild( "SourceState" );
            tag.Value = SourceState.ToString();

            tag = root.AddChild( "FriendlyName" );
            tag.Value = FriendlyName;

            tag = root.AddChild( "ModifiedTime" );
            tag.Value = modifiedTime.ToString();

            success = bxml.Save( filePath );
         }
         return success;
      }

      public bool Load()
      {
         return Load( StatusFilePath );
      }

      public bool Load(string filePath)
      {
         bool success = false;

         BinaryXml bxml = new BinaryXml( "GraphInfo" );

         success = !string.IsNullOrEmpty(filePath) && File.Exists(filePath) && bxml.Load( filePath );

         if( success == true )
         {
            foreach( BxmlTag tag in bxml.CurrentTag.ChildTags )
            {
               switch( tag.Name )
               {
                  case "GraphPath":
                  {
                     GraphPath = tag.Value as string;
                     break;
                  }
                  case "GraphName":
                  {
                     GraphName = tag.Value as string;
                     break;
                  }
                  case "SceneName":
                  {
                     SceneName = tag.Value as string;
                     break;
                  }
                  case "SourceState":
                  {
                     try
                     {
                        SourceState = ( State )System.Enum.Parse( typeof( State ), tag.Value as string );
                     }
                     catch( System.Exception )
                     {
                        SourceState = State.Missing;
                     }
                     break;
                  }
                  case "FriendlyName":
                  {
                     FriendlyName = tag.Value as string;
                     break;
                  }
                  case "ModifiedTime":
                  {
                     if( !long.TryParse( tag.Value as string, out modifiedTime) )
                     {
                        modifiedTime = 0;
                     }
                     break;
                  }
               }
            }
            // Make sure the status data isn't out of date.
            success = modifiedTime == GetGraphModifiedTime();
         }

         return success;
      }
   }
}
