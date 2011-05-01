// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Game Events")]

[FriendlyName("uScript Events")]
public class uScript_Global : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   
   [FriendlyName("On uScript Start")]
   public event uScriptEventHandler uScriptStart;

   void Start()
   {
      if ( uScriptStart != null ) uScriptStart(this, new System.EventArgs());
   }
   
#if UNITY_EDITOR
   // uScript GUI Options
   void OnDrawGizmos()
   {
      // @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
      if ( this.name != uScriptConfig.MasterObjectName )
      {
         Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
      }
   }
#endif

}
