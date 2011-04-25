// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events")]

[FriendlyName("Game Object Events")]
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
