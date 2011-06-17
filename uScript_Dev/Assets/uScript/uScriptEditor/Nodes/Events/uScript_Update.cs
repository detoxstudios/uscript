// uScript uScript_Update.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when various global events (OnGUI, Update, LateUpdate, and FixedUpdate) take place.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Event Components/Update")]
[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Game Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when various global events (OnGUI, Update, LateUpdate, and FixedUpdate) take place.")]
[NodeDescription("Fires an event signal when various global events (OnGUI, Update, LateUpdate, and FixedUpdate) take place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Global Update")]
public class uScript_Update : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("On GUI")]
   public event uScriptEventHandler OnGui;
   
   [FriendlyName("On Update")]
   public event uScriptEventHandler OnUpdate;
   
   [FriendlyName("On LateUpdate")]
   public event uScriptEventHandler OnLateUpdate;

   [FriendlyName("On FixedUpdate")]
   public event uScriptEventHandler OnFixedUpdate;

   void OnGUI()
   {
      if ( OnGui != null ) OnGui(this, new System.EventArgs());
   }

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
