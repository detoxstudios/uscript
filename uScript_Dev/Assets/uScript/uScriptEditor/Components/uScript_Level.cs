   // uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events")]

[FriendlyName("Level Events")]
public class uScript_Level : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, LevelWasLoadedEventArgs args);

   public class LevelWasLoadedEventArgs : System.EventArgs
   {
      private int m_Level;
      
      [FriendlyName("Level Index")]
      public int Level { get { return m_Level; } }

      public LevelWasLoadedEventArgs(int level)
      {
         m_Level = level;
      }
   }
   
   [FriendlyName("On uScript Start")]
   public event uScriptEventHandler LevelWasLoaded;

   void OnLevelWasLoaded(int level)
   {
      if ( LevelWasLoaded != null ) LevelWasLoaded(this, new LevelWasLoadedEventArgs(level));
   }
   
   // uScript GUI Options
   void OnDrawGizmos()
   {
      // @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
      if ( this.name != uScriptConfig.MasterObjectName )
      {
         Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
      }
   }

}
