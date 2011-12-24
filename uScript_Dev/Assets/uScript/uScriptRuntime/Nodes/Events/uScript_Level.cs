// uScript uScript_Level.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Game Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a level is finished loading.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Level_Load")]

[FriendlyName("Level Load", "Fires an event signal when a level is finished loading.")]
public class uScript_Level : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, LevelWasLoadedEventArgs args);

   public class LevelWasLoadedEventArgs : System.EventArgs
   {
      private int m_Level;
      
      [FriendlyName("Level Index", "The index of the level that was loaded.")]
      public int Level { get { return m_Level; } }

      public LevelWasLoadedEventArgs(int level)
      {
         m_Level = level;
      }
   }

   [FriendlyName("On Level Was Loaded")]
   public event uScriptEventHandler LevelWasLoaded;

   void OnLevelWasLoaded(int level)
   {
      if ( LevelWasLoaded != null ) LevelWasLoaded(this, new LevelWasLoadedEventArgs(level));
   }
}
