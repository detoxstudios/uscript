// uScript uScript_GameObject.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/GameObject Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance is enabled, disabled or destroyed.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GameObject Events", "Fires an event signal when Instance is enabled, disabled or destroyed.")]
public class uScript_GameObject : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   
   [FriendlyName("On Enable")]
   public event uScriptEventHandler EnableEvent;

   [FriendlyName("On Disable")]
   public event uScriptEventHandler DisableEvent;

   [FriendlyName("On Destroy")]
   public event uScriptEventHandler DestroyEvent;

   void OnEnable()
   {
      if ( EnableEvent != null ) EnableEvent(this, new System.EventArgs());
   }
   
   void OnDisable()
   {
      if ( DisableEvent != null ) DisableEvent(this, new System.EventArgs());
   }

   void OnDestroy()
   {
      if ( DestroyEvent != null ) DestroyEvent(this, new System.EventArgs());
   }
}
