// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events")]

[FriendlyName("Input Events")]
public class uScript_Input : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("On Key Event")]
   public event uScriptEventHandler KeyEvent;

   private bool m_AnyKeyWasDown = false;

   void Update()
   {
      if (Input.anyKey)
      {
         m_AnyKeyWasDown = true;

         if (KeyEvent != null) KeyEvent(this, new System.EventArgs());
      }
      else if ( true == m_AnyKeyWasDown )
      {
         //no key is down now but it was the last frame
         //so send a key up
         m_AnyKeyWasDown = false;

         if (KeyEvent != null) KeyEvent(this, new System.EventArgs());
      }
   }

   // uScript GUI Options
   void OnDrawGizmos()
   {
      // @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
      if (this.name != uScriptConfig.MasterObjectName)
      {
         Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
      }
   }

}
