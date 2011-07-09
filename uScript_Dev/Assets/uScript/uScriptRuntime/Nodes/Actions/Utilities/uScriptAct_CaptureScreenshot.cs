// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Captures a screenshot as a PNG file.

using UnityEngine;
using System.Collections;
using System.IO;

[NodePath("Actions/Utilities")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Captures a screenshot as a PNG file.")]
[NodeDescription("Captures a screenshot as a PNG file. If the file already exists, it will be overwritten. If no path is defined or a bad path is provided, the screenshot will be placed in the root folder of the project. Note: This node will not function when run from the web player or a Dashboard widget.\n\nFile Name: The name of the file. You do not need to provide the extension.\nPath: The path where you wish to save the screenshot file to.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Capture_Screenshot")]

[FriendlyName("Capture Screenshot")]
public class uScriptAct_CaptureScreenshot : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("File Name")] string FileName, 
      string Path,
      [FriendlyName("Relative To Data Folder"), DefaultValue(true), SocketState(false, false)] bool RelativeToDataFolder
      )
   {
      //Remove any slashes from the filename.
      FileName = FileName.Replace("/", "");
      FileName = FileName.Replace("\\", "");

      if (Path != "")
      {
         //Replace any back slashes with forward ones
         Path = Path.Replace("\\", "/");

         // Strip Path leading slash if it exists
         if (Path.StartsWith("/"))
         {
            Path = Path.Remove(0,1);
         }

         // Strip Path ending slash if it exists
         if (Path.EndsWith("/"))
         {
            int tmpPathLength = Path.Length - 1;

            Path = Path.Remove(tmpPathLength,1);
         }

         if (RelativeToDataFolder)
         {
            Path = Application.dataPath + "/" + Path;
         }

         
         if (CheckFullPath(Path))
         {
            Path = Path + "/" + FileName + ".png";
         }
         else
         {
            Path = FileName + ".png";
         }
      }
      else
      {
         Path = FileName + ".png";
      }

      Application.CaptureScreenshot(Path);

   }


   private bool CheckFullPath(string FullPath)
   {
      if ( System.IO.Directory.Exists(FullPath) )
      {
         return true;
      }
      else
      {
         return false;
      }
   }

}