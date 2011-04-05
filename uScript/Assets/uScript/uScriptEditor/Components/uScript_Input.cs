// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(uScript_Input))]

[NodePath("Events")]

[FriendlyName("Input Events")]
public class uScript_Input : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   
   [FriendlyName("On Key Press")]
   public event uScriptEventHandler KeyPress;

   void Update()
   {
      if (Input.anyKeyDown)
      {
         if( KeyPress != null ) KeyPress(this, new System.EventArgs());
      }
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
