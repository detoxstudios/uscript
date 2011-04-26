// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Renderer))]

[NodePath("Events/GameObject Events")]

[FriendlyName("Visibility Events")]
public class uScript_Visibility : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   
   [FriendlyName("On Became Visible")]
   public event uScriptEventHandler BecameVisible;

   [FriendlyName("On Became Invisible")]
   public event uScriptEventHandler BecameInvisible;

   void OnBecameVisible()
   {
      if ( BecameVisible != null ) BecameVisible(this, new System.EventArgs());
   }
   
   void OnBecameInvisible()
   {
      if ( BecameInvisible != null ) BecameInvisible(this, new System.EventArgs());
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
