// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Game Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when uScript starts.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("uScript Events", "Fires an event signal when uScript starts.")]
public class uScript_Global : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   
   [FriendlyName("On Graph Start")]
   public event uScriptEventHandler uScriptStart;

   [FriendlyName("On Graph Late Start")]
   public event uScriptEventHandler uScriptLateStart;

   private bool m_UpdateSent = false;
   private bool m_LateUpdateSent = false;

   //can't perform in Start because we aren't guaranteed
   //all the listeners are registered
   void Update()
   {
      if ( true == m_UpdateSent ) return;
      
      m_UpdateSent = true;
      if ( uScriptStart != null ) uScriptStart(this, new System.EventArgs());
   }

   //can't perform in Start because we aren't guaranteed
   //all the listeners are registered
   void LateUpdate()
   {
      if ( true == m_LateUpdateSent || false == m_UpdateSent ) return;
      
      m_LateUpdateSent = true;
      if ( uScriptLateStart != null ) uScriptLateStart(this, new System.EventArgs());
   }
}
