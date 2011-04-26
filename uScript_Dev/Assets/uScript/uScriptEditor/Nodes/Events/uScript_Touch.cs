// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Input Events")]

[FriendlyName("Touch Events")]
public class uScript_Touch : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, TouchEventArgs args);
  
   public class TouchEventArgs : System.EventArgs
   {
      public Touch[] Touches { get { return m_Touches; } }
      private Touch [] m_Touches;
     
      public TouchEventArgs(Touch []touches)
      {
         m_Touches = touches;
      }
   }

   [FriendlyName("On Touch Event")]
   public event uScriptEventHandler OnTouches;

   void Update()
   {
      if ( Input.touchCount > 0 )
      {
         if ( null != OnTouches ) OnTouches( this, new TouchEventArgs(Input.touches) );     
      }
   }
}
