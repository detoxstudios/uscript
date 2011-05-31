// uScript uScript_GameObject.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when Instance is enabled, disabled or destroyed.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events/GameObject Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance is enabled, disabled or destroyed.")]
[NodeDescription("Fires an event signal when Instance is enabled, disabled or destroyed.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("GameObject Events")]
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
