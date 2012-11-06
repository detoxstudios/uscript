// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Game Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when uScript starts.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#uScript_Events")]

[FriendlyName("uScript Events", "Fires an event signal when uScript starts.")]
public class uScript_Global : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   
   [FriendlyName("On Graph Start")]
   public event uScriptEventHandler uScriptStart;

   private bool m_Sent = false;

   //can't perform in Start because we aren't guaranteed
   //all the listeners are registered
   void Update()
   {
      if ( true == m_Sent ) return;

      m_Sent = true;
      if ( uScriptStart != null ) uScriptStart(this, new System.EventArgs());
   }
}
