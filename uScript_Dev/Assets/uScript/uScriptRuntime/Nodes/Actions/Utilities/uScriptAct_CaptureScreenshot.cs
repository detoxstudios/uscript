// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;
using System.IO;

[NodePath("Actions/Utilities")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Captures a screenshot as a PNG file.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Capture_Screenshot")]

[FriendlyName("Capture Screenshot", "Captures a screenshot as a PNG file. If the file already exists, it will be overwritten. If no path is defined or a bad path is provided, the screenshot will be placed in the root folder of the project." +
 "\n\nNote: This node will not function when run from the web player or a Dashboard widget.")]
public class uScriptAct_CaptureScreenshot : uScriptLogic
{
	int m_NumberCount = 0;
	
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("File Name", "The name of the file. You do not need to provide the extension.")]
      string FileName,
      
      [FriendlyName("Path", "The path where you wish to save the screenshot file to.")]
      string Path,

      [FriendlyName("Relative To Data Folder", "Applies the project's root data folder path to the begining of the specified path (the same location as your project's Assets folder).")]
      [DefaultValue(true), SocketState(false, false)]
      bool RelativeToDataFolder,
      
      [FriendlyName("Append Number", "If true, this will append an incrementing number in the format of \"_#####\" to the end of the file name.")]
      [DefaultValue(false), SocketState(false, false)]
      bool AppendNumber,
      
      [FriendlyName("File Saved", "Outputs the full path and filename of the saved screenshot.")]
      [DefaultValue(false), SocketState(false, false)]
      out string FileSaved
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
            Path = FileName;
         }
      }
      else
      {
         Path = FileName;
      }
		
		if(AppendNumber)
		{	m_NumberCount++;
			
			string numberBuffer = "";
			if (m_NumberCount < 10) { numberBuffer = "0000"; }
			if (m_NumberCount > 9 && m_NumberCount < 100) { numberBuffer = "000"; }
			if (m_NumberCount > 99 && m_NumberCount < 1000) { numberBuffer = "00"; }
			if (m_NumberCount > 999 && m_NumberCount < 10000) { numberBuffer = "0"; }
			if (m_NumberCount > 9999 && m_NumberCount < 100000) { numberBuffer = ""; }
			if (m_NumberCount > 100000) { numberBuffer = "0000"; m_NumberCount = 0; }
			
			Path = Path + "_" + numberBuffer + m_NumberCount.ToString();
			
		}
		else
		{
			// Reset the picture count
			m_NumberCount = 0;
		}
		
	  Path = Path + ".png";

      Application.CaptureScreenshot(Path);
	  
	  FileSaved = Path;

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

#endif