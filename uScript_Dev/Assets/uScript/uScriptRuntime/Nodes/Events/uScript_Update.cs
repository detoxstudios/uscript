// uScript uScript_Update.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Game Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when various global events take place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Global Update", "Fires an event signal when various global events (Update, LateUpdate, and FixedUpdate) take place.")]
public class uScript_Update : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("On Update")]
   public event uScriptEventHandler OnUpdate;
   
   [FriendlyName("On Late Update")]
   public event uScriptEventHandler OnLateUpdate;

   [FriendlyName("On Fixed Update")]
   public event uScriptEventHandler OnFixedUpdate;

   void Update()
   {
      if ( OnUpdate != null ) OnUpdate(this, new System.EventArgs());
   }

   void LateUpdate()
   {
      if ( OnLateUpdate != null ) OnLateUpdate(this, new System.EventArgs());
   }

   void FixedUpdate()
   {
      if ( OnFixedUpdate != null ) OnFixedUpdate(this, new System.EventArgs());
   }
}
