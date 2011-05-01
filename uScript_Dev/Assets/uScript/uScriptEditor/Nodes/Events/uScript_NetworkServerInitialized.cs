// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Network))]

[NodePath("Events/Network Events")]

[FriendlyName("Network Server Initialized")]
public class uScript_NetworkServerInitialized: uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("On Server Initialized")]
   public event uScriptEventHandler OnInitialized;

   void OnServerInitialized( )
   {
      if (OnInitialized != null) OnInitialized(this, new System.EventArgs());
   }

#if UNITY_EDITOR
   // uScript GUI Options
   void OnDrawGizmos()
   {
      // @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
      if (this.name != uScriptConfig.MasterObjectName)
      {
         Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
      }
   }
#endif

}
