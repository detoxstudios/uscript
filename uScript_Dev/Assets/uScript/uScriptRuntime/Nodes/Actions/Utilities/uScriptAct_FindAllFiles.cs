// uScript Action Node
// (C) 2020 Detox Studios LLC

using System.Collections.Generic;
using System.IO;

[NodePath("Actions/Utilities")]

[NodeCopyright("Copyright 2020 by Detox Studios LLC")]
[NodeToolTip("Recursively find files of type extension in root path.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Find All Files", "Recursively find files of type extension in root path.")]
public class uScriptAct_FindAllFiles: uScriptLogic
{
   int m_NumberCount = 0;

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Root Path", "The root directory to search in for files.")]
      string rootPath,

      [FriendlyName("Extension", "The extension to search for (must include the '.').")]
      string extension,

      [FriendlyName("File List", "List of file paths of found files.")]
      out string[] fileList
   )
   {
      fileList = _findAllFiles(rootPath, extension);
   }

   private string[] _findAllFiles(string rootPath, string extension)
   {
      List<string> paths = new List<string>();

      DirectoryInfo directory = new DirectoryInfo(rootPath);

      FileInfo[] files = directory.GetFiles();

      foreach (FileInfo file in files)
      {
         if (file.Extension == extension)
         {
            paths.Add(file.FullName);
         }
      }

      foreach (DirectoryInfo subDirectory in directory.GetDirectories())
      {
         string[] results = _findAllFiles(subDirectory.FullName, extension);
         paths.AddRange(results);
      }

      return paths.ToArray();
   }
}
